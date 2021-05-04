Imports System.Resources
Imports System.Reflection
Imports System.Collections.Generic
Imports PlatformStudio.psMap.psLayer

Public Module psMod1
    Public Game As psGame

    Private v As Version = New Version(Application.ProductVersion)
    Public AssemblyVersion As String = v.Major & "." & v.Minor

    Public DefaultNumActions As Integer
    Public DefaultActData As psActionData
    Public DefaultFont As System.Drawing.Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)

    'So we don't waste memory (in terms of 3 MB per undo update)
    'and time (in terms of 3 seconds per undo update)
    Public DoNotLoadImages As Boolean

    Public MIDI As psAudio.MidiFile
    Enum MIDIEventType
        Play = 0
        [Stop]
        Pause
        [Resume]
    End Enum
    Structure MIDIEvent
        Dim Type As MIDIEventType
        Dim param As String
    End Structure
    Public MIDIEvents() As MIDIEvent
    Public MIDIHalt As Boolean

    Public DataOnly As Boolean

    Private Resources_En_Us As New ResourceManager("PlatformStudio.Localization", [Assembly].GetExecutingAssembly())
    Private Resources As ResourceManager = Resources_En_Us
    Private AllResources As List(Of ResourceManager)

    Public Function GetString(ByVal key As String) As String
        Return GetString(key, Resources)
    End Function

    Public Function GetString(ByVal key As String, ByVal RM As ResourceManager) As String
        Dim s As String = RM.GetString(key)
        Return s.Replace("\n", vbCrLf)
    End Function

    Public Function MatchAny(ByVal text As String, ByVal matchToKey As String) As Boolean
        If AllResources Is Nothing Then
            AllResources = New List(Of ResourceManager)
            AllResources.Add(Resources_En_Us)
        End If
        For Each rm As ResourceManager In AllResources
            If (GetString(matchToKey, rm) = text) Then
                Return True
            End If
        Next
        Return False
    End Function

    <Serializable()> _
    Structure psFileReplace
        Dim OldFile As String
        Dim NewFile As String
    End Structure
    Public filerepl() As psFileReplace
    Public filerepldir As String
    Public Compiled As Boolean

    Public RootPath As String
    Public NewFile As String
    Public CurFilePath As String
    Public LoadingFile As Boolean
    Public AutoFound As Boolean
    Function GetRelativeFile(ByVal Filename As String) As String
        If Filename Is Nothing OrElse Filename = "" Then Return ""
        If Filename.StartsWith("(") Then Return Filename
        Filename = Filename.Trim("""")

        Dim tmpNewFile As String = NewFile

        If Compiled Then
            For i As Integer = 1 To UBound(filerepl)
                If filerepl(i).OldFile = Filename Then
                    Return filerepldir & "\" & filerepl(i).NewFile
                End If
            Next
            Return Filename
        End If

        FileNotFoundCancel = False

        Dim OldFile As String = Game.Filename
        Dim tmpFile As String = Filename
        Dim FilenameOnly As String = GetFilename(tmpFile)
        If NewFile = OldFile Then
            tmpFile = Filename
            GoTo ReadyToCheck
        End If
        OldFile = GetPath(OldFile)
        NewFile = GetPath(NewFile)
        tmpFile = GetPath(tmpFile)
        If NewFile = OldFile Then
            tmpFile = Filename
            GoTo ReadyToCheck
        End If

        'Find difference in filenames
        Dim Common As String
        For i As Integer = 1 To Math.Min(NewFile.Length, OldFile.Length)
            If NewFile.Chars(NewFile.Length - i) <> OldFile.Chars(OldFile.Length - i) Then
                Common = NewFile.Substring(NewFile.Length - i + 1)
                NewFile = NewFile.Substring(0, NewFile.Length - (i - 1))
                OldFile = OldFile.Substring(0, OldFile.Length - (i - 1))
                Exit For
            End If
        Next
        If NewFile.Length <= 3 Then
            tmpFile &= FilenameOnly
        Else
            If tmpFile.StartsWith(OldFile) Then
                tmpFile = tmpFile.Replace(OldFile, NewFile) & FilenameOnly
            End If
        End If

ReadyToCheck:
        If Not IO.File.Exists(tmpFile) Then
            searching_bestMatch = ""
            searching_similarity = 0

            'Check in application folder
            CheckPathRecursively(Application.StartupPath.ToLower, IO.Path.GetFileName(Filename), IO.Path.GetDirectoryName(Filename).ToLower)
            If searching_bestMatch.Trim <> "" Then
                NewFile = tmpNewFile
                AutoFound = True
                Return searching_bestMatch
            End If
            'Check in game's previous folder
            CheckPathRecursively(IO.Path.GetDirectoryName(Game.Filename).ToLower, IO.Path.GetFileName(Filename), IO.Path.GetDirectoryName(Filename).ToLower)
            If searching_bestMatch.Trim <> "" Then
                NewFile = tmpNewFile
                AutoFound = True
                Return searching_bestMatch
            End If
            'Check in game's current folder
            CheckPathRecursively(CurFilePath.ToLower, IO.Path.GetFileName(Filename), IO.Path.GetDirectoryName(Game.Filename).ToLower)
            If searching_bestMatch.Trim <> "" Then
                NewFile = tmpNewFile
                AutoFound = True
                Return searching_bestMatch
            End If
        End If

        If Not IO.File.Exists(tmpFile) Then
            tmpFile = Filename
        End If

        FileNotFoundTries = 0
CheckAgain:
        If Not IO.File.Exists(tmpFile) Then
            Dim f As New psfrmFileNotFound
            Dim dr As DialogResult
            dr = f.ShowDialog(tmpFile)
            f.Dispose()
            If dr = DialogResult.OK Then GoTo CheckAgain
        End If

        NewFile = tmpNewFile
        Return tmpFile
    End Function
    Function GetPath(ByVal str As String) As String
        Dim out As String = str
        For i As Integer = out.Length - 1 To 0 Step -1
            If out.Chars(i) = "\" Then Return out.Substring(0, i + 1)
        Next
        Return out
    End Function
    Function GetFilename(ByVal str As String) As String
        Dim out As String = str
        For i As Integer = out.Length - 1 To 0 Step -1
            If out.Chars(i) = "\" Then Return out.Substring(i + 1)
        Next
        Return out
    End Function
    Private searching_bestMatch As String
    Private searching_similarity As Integer
    'returns True if user chooses to stop early
    Function CheckPathRecursively(ByVal path As String, ByVal file As String, ByVal pathHint As String, Optional ByVal time As Integer = -1) As Boolean
        If Not IO.Directory.Exists(path) Then Return False
        If time = -1 Then
            time = Environment.TickCount
        End If
        If IO.File.Exists(path & "\" & file) Then
            searching_bestMatch = path & "\" & file
            searching_similarity = 100000
            Return True
        End If
        For Each dir As String In IO.Directory.GetDirectories(path)
            If IO.File.Exists(dir & "\" & file) Then

                'Found!
                Dim sim As Integer = 0
                For i As Integer = 1 To Math.Min(dir.Length, pathHint.Length)
                    If dir.Chars(dir.Length - i) <> pathHint.Chars(pathHint.Length - i) Then
                        sim = i - 1
                        Exit For
                    End If
                Next
                If sim >= searching_similarity Then
                    searching_bestMatch = dir & "\" & file
                    searching_similarity = sim
                End If

            Else
                If CheckPathRecursively(dir, file, pathHint, time) Then Return True
            End If
            If time > 0 AndAlso Environment.TickCount - time >= 2000 Then
                time = -2
                If MessageBox.Show(String.Format(GetString("lookingForFileMessage"), file), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Public Function HelpCHM() As String
        Return Application.StartupPath & "\pshelp.chm"
    End Function

    Sub MakeValidRectangle(ByRef r As Rectangle, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer)
        If mx - sx < 0 Then
            r.X = mx
            r.Width = sx - mx
        Else
            r.X = sx
            r.Width = mx - sx
        End If
        If my - sy < 0 Then
            r.Y = my
            r.Height = sy - my
        Else
            r.Y = sy
            r.Height = my - sy
        End If
        r.X = r.X - Game.cam.X + Game.cam.X * Game.ScrollSpeed
        r.Y = r.Y - Game.cam.Y + Game.cam.Y * Game.ScrollSpeed
    End Sub

    Sub ConvertToNumber(ByRef ctl As Object, ByVal min As Single, ByVal max As Single, ByVal def As Single, Optional ByVal DigitsAfterDecimal As Integer = 0)
        With ctl
            If IsNumeric(.Text) Then
                If .Text <= min Then .Text = min
                If .Text >= max Then .Text = max
                .Text = CSng(Math.Round(CDec(.Text), DigitsAfterDecimal))
            Else
                ctl.Text = def
                .Text = CSng(Math.Round(CDec(.Text), DigitsAfterDecimal))
            End If
        End With
    End Sub

    Public PauseAnimations As Boolean
    Sub UpdateFrame(ByVal tile As psTile, ByVal animindex As Integer, ByRef StartTime As Single, ByRef Frame As Short, ByVal Stopped As Boolean)
        If PauseAnimations Then Exit Sub

        With tile.Anim(animindex)
            'Update animation
            If StartTime = 0 Then StartTime = Microsoft.VisualBasic.Timer
            If Frame = 0 Then Frame = .StartFrame
            Dim FirstFrame As Integer = Math.Min(.StartFrame, .StopFrame)
            Dim LastFrame As Integer = Math.Max(.StartFrame, .StopFrame)
            If .Interval > 0 And Stopped = False Then
                If (Frame > LastFrame Or Frame < FirstFrame) Then Frame = .StartFrame
                If Microsoft.VisualBasic.Timer - StartTime >= .Interval Then
                    Frame += Math.Sign(.StopFrame - .StartFrame)
                    If .StartFrame = .StopFrame Then Frame = .StartFrame
                    If (Math.Sign(.StopFrame - .StartFrame) = 1 And Frame > .StopFrame) Or _
                       (Math.Sign(.StopFrame - .StartFrame) = -1 And Frame < .StopFrame) Then
                        If Microsoft.VisualBasic.Timer - StartTime >= .Interval + .AnimInterval Then
                            Frame = .StartFrame
                            StartTime = Microsoft.VisualBasic.Timer
                        Else
                            Frame = .StopFrame
                        End If
                    Else
                        StartTime = Microsoft.VisualBasic.Timer
                    End If
                End If
            ElseIf Stopped Then
                'We still have to be on the right animation
                If (Math.Sign(.StopFrame - .StartFrame) = 1 And (Frame > .StopFrame Or Frame < .StartFrame)) Or _
                   (Math.Sign(.StopFrame - .StartFrame) = -1 And (Frame < .StopFrame Or Frame > .StartFrame)) Then
                    Frame = .StartFrame
                End If
            End If
        End With
    End Sub

    Public DoNotUpdateAnim As Boolean
    Function CurRect(ByVal tile As psTile, ByVal animindex As Integer, ByRef StartTime As Single, ByRef Frame As Integer, ByVal Stopped As Boolean) As System.Drawing.Rectangle
        If tile.Anim Is Nothing OrElse animindex > UBound(tile.Anim) Then
            Return New Rectangle(0, 0, tile.sectionw, tile.sectionh)
            Exit Function
        End If

        If Not DoNotUpdateAnim Then
            UpdateFrame(tile, animindex, StartTime, Frame, Stopped)
        End If

        'Get current section of image
        Return CurRect(tile, Frame)
    End Function

    Function CurRect(ByVal tile As psTile, ByVal Frame As Integer) As Rectangle
        'Gets the current frame from a sectioned image
        '
        '   Ex:
        '   OOOO     Current frame = 6
        '   OXOO <-- X = current frame location
        '
        With tile
            Return New Rectangle( _
                ((Frame - 1) Mod (tile.width \ tile.sectionw)) * tile.sectionw _
              , (RoundUp(Frame, (tile.width \ tile.sectionw)) - 1) * tile.sectionh _
              , tile.sectionw _
              , tile.sectionh)
        End With
    End Function

    Function ScaleRect(ByVal r As Rectangle, ByVal x As Double, ByVal y As Double) As Rectangle
        Return New Rectangle(r.X * x, r.Y * y, r.Width * x, r.Height * y)
    End Function

    Function RoundUp(ByVal num1 As Double, ByVal num2 As Double) As Double
        If num1 / num2 = num1 \ num2 Then
            Return num1 \ num2
        Else
            Return num1 \ num2 + 1
        End If
    End Function

    Function MakeInRange(ByVal num As Integer, ByVal min As Integer, ByVal max As Integer) As Integer
        If num < min Then
            Return min
        ElseIf num > max Then
            Return max
        Else
            Return num
        End If
    End Function

    Sub GetOffset(ByVal i As Integer, ByVal n As Integer, ByRef tile As psMapTile, ByRef ox As Single, ByRef oy As Single, Optional ByVal Update As Boolean = True)
        If tile.Path.Exists = False OrElse _
        UBound(tile.Path.Pts) = 0 Then Exit Sub
        If tile.Path.Start = 0 Or (Timer - tile.Path.Start) < 0 Then tile.Path.Start = Timer
        If Timer - tile.Path.Start >= tile.Path.Speed Then
            tile.Path.Start = Timer
        End If
        Dim OneWay As Boolean, OneWayFinished As Boolean, StayThere As Boolean
        PathHelper.Path_GetPos(tile.Path, Timer - tile.Path.Start, ox, oy, OneWay, OneWayFinished, StayThere)

        If OneWay Then
            If OneWayFinished Then
                If StayThere = False Then
                    'Destroy temporary path
                    ReDim tile.Path.Pts(0)
                    tile.Path.Exists = False

                    'Show the disappear ("poof") animation
                    Game._DisappearTile(i, n)
                End If
            End If
        End If

        ox = ox - tile.w * 0.5
        oy = oy - tile.h * 0.5
    End Sub

    Private sw As Stopwatch

    ReadOnly Property Timer() As Double
        Get
            If (sw Is Nothing) Then
                sw = New Stopwatch()
                sw.Start()
                Return sw.Elapsed.TotalSeconds
            End If
            'PlatformStudio.GamePlayer.Renderer.TimeElapsed
            Return Microsoft.VisualBasic.Timer
        End Get
    End Property

    Function ListGroups(ByVal level As Integer) As String()
        Dim tmpS() As String
        ReDim tmpS(0)
        Dim j As Integer, k As Integer, l As Integer
        For j = 0 To 3
            For k = 1 To Game.maps(level).MapSize1D
                With Game.maps(level).Cells1D2(k, j)
                    If .Group <> "" Then
                        For l = 1 To UBound(tmpS)
                            If tmpS(l) = .Group Then GoTo NextK
                        Next
                        ReDim Preserve tmpS(UBound(tmpS) + 1)
                        tmpS(UBound(tmpS)) = .Group
                    End If
                End With
NextK:
            Next
        Next
        Return tmpS
    End Function

    Function GetCounter(ByVal CounterName As String) As Integer
        For i As Integer = 1 To UBound(Game.actions.Counters)
            If Game.actions.Counters(i).Name = CounterName Then
                Return i
            End If
        Next
    End Function

    Function GetTimer(ByVal TimerName As String) As Integer
        For i As Integer = 1 To UBound(Game.actions.Timers)
            If Game.actions.Timers(i).Name = TimerName Then
                Return i
            End If
        Next
    End Function

    Function Mod2(ByVal Num1 As Integer, ByVal Num2 As Integer) As Integer
        'Returns Num1 Mod Num2, but all outputs of 0 change to Num2
        '(Range is 1 to Num2 instead of 0 to (Num2 - 1)
        Dim tmpOut As Integer = Num1 Mod Num2
        If tmpOut = 0 Then
            Return Num2
        Else
            Return tmpOut
        End If
    End Function

    Sub SetCurGroup(ByVal Name As String, ByVal X As Integer, ByVal Y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal hp As Integer, ByVal frame As Integer, ByVal animIndex As Integer, ByVal tileName As String)
        curGroup = New CurrentGroup
        With curGroup
            ._Name = Name
            ._CurTileX = X
            ._CurTileY = Y
            ._CurTileW = w
            ._CurTileH = h
            ._CurTileHP = hp
            ._CurTileFrame = frame
            ._CurTileAnimIndex = animIndex
            ._CurTileName = tileName
        End With
    End Sub


    'Function Path2Action(ByVal Path As String) As String
    '    'Variables
    '    Dim i As Integer
    '    Dim Output As String = ""

    '    'First clip off the "Triggers\"
    '    Path = Path.Remove(1, 9)

    '    'Find the child of the root
    '    Select Case FindChild(Path, Path)
    '        Case "Tiles"
    '            'Find tile index
    '            i = FindChild(Path, Path)

    '            'Find action
    '            Select Case FindChild(Path, Path)
    '                Case "Hit"
    '                    Return "hit" & i
    '                Case "Hit Left"
    '                    Return "lef" & i
    '                Case "Hit Right"
    '                    Return "rig" & i
    '                Case "Hit Top"
    '                    Return "top" & i
    '                Case "Hit Bottom"
    '                    Return "bot" & i
    '                Case "Exclusively on Top"
    '                    Return "exc" & i
    '            End Select
    '        Case "Locations"
    '            'Find the index
    '            i = FindChild(Path, Path)

    '            'Find action
    '            Select Case FindChild(Path, Path)
    '                Case "Enter"
    '                Case "Exit"
    '                Case "Inside"
    '            End Select
    '        Case "Keyboard"
    '            'Find the index
    '            i = FindChild(Path, Path)

    '            'Find action
    '            Select Case FindChild(Path, Path)
    '                Case "Press"
    '                Case "Release"
    '                Case "Hold"
    '            End Select
    '    End Select
    'End Function

    'Private Function FindChild(ByVal txt As String, ByRef EndString As String) As String
    '    Dim i As Integer
    '    For i = 0 To txt.Length - 1
    '        If txt.Chars(i) = "\" Then
    '            EndString = txt.Substring(i + 1)
    '            Return txt.Substring(1, i - 1)
    '        End If
    '    Next
    'End Function

    'Function Action2Path() As String

    'End Function
End Module
