Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Delegate Sub [Sub]()

Public Class psFileHandler
    Public Event BeginLoadGame()
    Public Event EndLoadGame()
    Public Event BeginSaveGame()
    
    Public Shared MadeChanges As Boolean
    Public Tag As String

    Public Shared theStream As FileStream
    Public Shared bReader As BinaryReader
    Public Shared bWriter As BinaryWriter
    Private Shared curFile As String
    Public Shared OldFileType As Boolean

    Function SaveGame(ByVal Filename As String, Optional ByVal Compress As Boolean = True, Optional ByVal CustomSaveSub As [Sub] = Nothing) As Boolean
        'Dim start As Integer = Environment.TickCount

        'Variables
        Dim blnExists As Boolean

        'Deselect anything that is selected
        Dim tmpM() As psMap = Game.CloneMaps
        RaiseEvent BeginSaveGame()

        'Close any open game file
        If IO.File.Exists(TempFileName) Then IO.File.Delete(TempFileName)
        FileClose(1)

        ''Find out if the filename exists
        'blnExists = IO.File.Exists(Filename)

        'If blnExists Then
        '    'Backup old file and delete the current file
        '    Try
        '        IO.File.Copy(Filename, Application.StartupPath & "\~tmp.tmp")
        '        IO.File.Delete(Filename)
        '    Catch
        '        'Don't need to bother the user if backup failed
        '    End Try
        'End If

        Try
            'Open the specified file
            'FileOpen(1, TempFileName, OpenMode.Binary)
            Try
                theStream.Close()
                FileClose(1)
            Catch
            End Try
            theStream = IO.File.Open(TempFileName, IO.FileMode.Create)
            bWriter = New BinaryWriter(theStream)
            curFile = TempFileName

            'Save the filename
            psFileHandler.FilePutString2(Filename)

            'Save the game        
            SaveGame = Game.Save()

            'Save any custom data
            If Not (CustomSaveSub Is Nothing) Then
                CustomSaveSub.DynamicInvoke(Nothing)
            End If

            'Close the open file
            theStream.Close()

            'Compress the file
            If Compress Then
                psCompress.Compress(TempFileName, Filename)
            Else
                IO.File.Copy(TempFileName, Filename, True)
            End If

            MadeChanges = False
        Catch ex As Exception
            'Error!
            System.Windows.Forms.MessageBox.Show( _
                String.Format(GetString("error_SaveGame"), Filename) & vbCrLf & vbCrLf & ex.Message, _
                "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            If blnExists Then
                'Replace the corrupted file with the backup
                Try
                    IO.File.Copy(Game.TempRoot & "~pstudio35tmp.tmp", Filename)
                Catch
                    'In case there was an error backing up the file
                End Try
            Else
                'If the file didn't exist before, delete anything
                'that has been saved, since it is now useless.
                If IO.File.Exists(Filename) Then
                    IO.File.Delete(Filename)
                End If
            End If

            'Close the open file
            Try
                theStream.Close()
            Catch
            End Try

            SaveGame = False
        Finally
            'Delete the backup
            IO.File.Delete(Game.TempRoot & "~pstudio35tmp.tmp")

            'Make the game as it was before we deselected
            Game.maps = tmpM
            Erase tmpM
        End Try

        'MsgBox((Environment.TickCount - start) / 1000)
    End Function

    ReadOnly Property TempFileName() As String
        Get
            Return Game.TempRoot & "~pstudio35tmp.tmp"
        End Get
    End Property

    Function LoadGame(ByVal Flags As Long, ByVal Filename As String, Optional ByVal CustomLoadSub As [Sub] = Nothing, Optional ByVal Decompress As Boolean = True, Optional ByVal DataOnly_ As Boolean = False) As Boolean
        'Dim start As Integer = Environment.TickCount

        If Flags <> 5938195395831283597 Then
            Dim s As Single = Timer
            Do
            Loop Until Timer - s >= 2
            Throw New Exception(GetString("error_LoadGame"))
        End If

        DataOnly = DataOnly_

        psMod1.LoadingFile = True
        FileNotFoundAction = modFileNotFound.FileNotFoundActionEnum.None

        RaiseEvent BeginLoadGame()

        'Close any open game file
        'FileClose(1)

        Try
            'If Not Game.InEditor Then MsgBox("Decompressing")

            'Decompress the file
            If Decompress Then
                psCompress.Decompress(Filename, TempFileName)
            Else
                IO.File.Copy(Filename, TempFileName)
            End If

            'Open the specified file
            Try
                theStream.Close()
                FileClose(1)
            Catch
            End Try
            psFileUpdater.curVersion = 0.0
            theStream = IO.File.Open(TempFileName, IO.FileMode.Open)
            bReader = New BinaryReader(theStream)
            curFile = TempFileName
            CurFilePath = IO.Path.GetDirectoryName(Filename)
            OldFileType = False
            AutoFound = False

            'Load the filename
            psFileHandler.FileGetString(Game.Filename)
            psMod1.NewFile = Filename

            'If Not Game.InEditor Then MsgBox("Loading game")

            'Load the data and any textures/fonts
            LoadGame = Game.Load()
            If LoadGame Then
                If FileNotFoundCancel Then
                    LoadGame = False
                Else
                    'Adjust relative filenames to the right path
                    AdjustFilenames()
                    If FileNotFoundCancel Then
                        LoadGame = False
                    Else
                        'Load any custom data
                        If Not (CustomLoadSub Is Nothing) Then
                            CustomLoadSub.DynamicInvoke(Nothing)
                        End If
                    End If

                    If AutoFound Then
                        'MessageBox.Show("JumpCraft could not find some files, but was able to locate similar or identical replacements.  Since these replacements might not be correct, we advise you to check over them.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                MadeChanges = False
            End If
        Catch ex As Exception
            'Error!
            System.Windows.Forms.MessageBox.Show( _
                String.Format(GetString("error_LoadGame"), Filename) & vbCrLf & vbCrLf _
                & ex.Message, _
                "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            LoadGame = False
        Finally
            'Close the current file
            'FileClose(1)
            If Not theStream Is Nothing Then
                theStream.Close()
            End If

            ''Recompress the file
            'Dim tmpStr As String
            'With IO.File.OpenText(Filename)
            '    tmpStr = psLZWCompress.lzwDecompress(.ReadToEnd)
            '    .Close()
            'End With
            IO.File.Delete(TempFileName)
            psMod1.LoadingFile = False
            FileNotFoundCancel = False
            DataOnly = False
        End Try

        RaiseEvent EndLoadGame()

        'MsgBox((Environment.TickCount - start) / 1000)
    End Function

    Private Sub AdjustFilenames(Optional ByVal Start As Integer = 1)
        'Loop through all actions
        For i As Integer = Start To UBound(Game.actions.Actions)
            With Game.actions.Actions(i).Action
                'Loop through all parameters
                For j As Integer = 1 To UBound(.param)
                    AdjustFilenamesInText(.param(j))
                    If FileNotFoundCancel Then Exit Sub
                Next
            End With
        Next

        'Loop through all windows
        For i As Integer = 1 To UBound(Game.windows.Windows)
            With Game.windows.Windows(i)
                'Loop through all controls
                For j As Integer = 1 To .NumCtrls
                    'If (Not (.Controls(j).Param1 Is Nothing)) AndAlso (.Controls(j).Param1.Length > 2) Then
                    'AdjustFilenamesInText(.Controls(j).Param1)
                    'If FileNotFoundCancel Then Exit Sub
                    If TypeOf .Controls(j) Is psUI.psControl.psMovie Then
                        Dim Background As psUI.psBackground = .Controls(j).Background
                        Background.imgFilename = GetRelativeFile(.Controls(j).GetBackground.imgFilename)
                        .Controls(j).Background = Background
                    End If
                Next
                .Music = GetRelativeFile(.Music)
            End With
        Next

        'Level music
        For i As Integer = 1 To UBound(Game.maps)
            Game.maps(i).Music = GetRelativeFile(Game.maps(i).Music)
        Next

        Game.GameProperties.Icon = GetRelativeFile(Game.GameProperties.Icon)
        If FileNotFoundCancel Then Exit Sub
        Game.GameProperties.fLicenseAgrmt = GetRelativeFile(Game.GameProperties.fLicenseAgrmt)
        If FileNotFoundCancel Then Exit Sub
        Game.GameProperties.fReadme = GetRelativeFile(Game.GameProperties.fReadme)
        If FileNotFoundCancel Then Exit Sub
        Game.GameProperties.fReleaseNotes = GetRelativeFile(Game.GameProperties.fReleaseNotes)
        If FileNotFoundCancel Then Exit Sub
        For i As Integer = 1 To UBound(Game.GameProperties.fOtherFiles)
            Game.GameProperties.fOtherFiles(i) = GetRelativeFile(Game.GameProperties.fOtherFiles(i))
            If FileNotFoundCancel Then Exit Sub
        Next
    End Sub

    Private Sub AdjustFilenamesInText(ByRef txt As String)
        'Find all filenames and replace it with
        'one that is relative to the new location
        'of the game file

        'Variables
        Dim tmpStart As Integer
        Dim tmpFile As String

        'Loop until we have reached the end of the string
        Do
LookForAnotherFile:

            'Find ":\", which refers to a drive
            If txt Is Nothing Then Exit Sub
            tmpStart = txt.IndexOf(":\", tmpStart + 1)

            'If no more were found, then exit the loop
            If tmpStart = -1 Then Exit Do

            'Make sure this is really a file
            Try
                If Not (Char.IsLetter(txt.Chars(tmpStart - 1))) Then
                    GoTo LookForAnotherFile
                End If
            Catch ex As Exception
                GoTo LookForAnotherFile
            End Try

            'Find the filename around the ":\"
            tmpStart -= 1 'Start at the drive letter
            For k As Integer = tmpStart + 1 To txt.Length - 1
                If txt.Chars(k) = """" Then
                    tmpFile = txt.Substring(tmpStart, k - tmpStart)
                    txt = txt.Replace(tmpFile, GetRelativeFile(tmpFile))
                    If FileNotFoundCancel Then Exit Sub
                    GoTo ContinueLoop
                End If
            Next
            tmpFile = txt.Substring(tmpStart)
            txt = txt.Replace(tmpFile, GetRelativeFile(tmpFile))

ContinueLoop:

            tmpStart += 2

        Loop Until tmpStart = -1
    End Sub

    Sub LoadTileset(ByVal Filename As String, Optional ByVal selectTiles As Boolean = False, Optional ByVal loadActions As Boolean = True)
        Dim tmp As String = Game.Status
        Game.Status = GetString("loadingTilesetStatus")

        psMod1.LoadingFile = True
        FileNotFoundAction = modFileNotFound.FileNotFoundActionEnum.None

        Dim UpdatedFile As Boolean
        Try
            Try
                theStream.Close()
                FileClose(1)
            Catch
            End Try
            psFileUpdater.curVersion = 0.0
            theStream = IO.File.Open(Filename, FileMode.Open)
            bReader = New BinaryReader(theStream)
            curFile = Filename
            CurFilePath = IO.Path.GetDirectoryName(Filename)
            OldFileType = False
            AutoFound = False

            'Load the filename
            psFileHandler.FileGetString(Game.Filename)
            psMod1.NewFile = Filename

            'Load tileset
            Dim startIndex As Integer = 1
            Dim OldMaxTiles As Integer = Game.tileset.NumTiles
            Dim f As frmImportTileset
            If selectTiles Then
                'Load the tileset into temporary storage
                Dim tmpTileset As psTileset
                psFileHandler.Read(tmpTileset)

                'Show the Import Tileset dialog
                f = New frmImportTileset
                f.ShowDialog(tmpTileset)

                'If user clicked cancel...
                If f.DialogResult = DialogResult.Cancel Then
                    theStream.Close()
                    FileNotFoundCancel = False
                    Return
                End If

                'Import the selected tiles
                For n As Integer = 0 To f.ListBox1.SelectedIndices.Count - 1
                    Dim newName As String = tmpTileset.tiles(f.ListBox1.SelectedIndices(n) + 1).name
                    Dim replaceWith As Integer = 0
                    For o As Integer = 1 To Game.tileset.NumTiles
                        If tmpTileset.tiles(f.ListBox1.SelectedIndices(n) + 1).name = Game.tileset.tileName(o) Then
                            If f.replace.Checked Then
                                replaceWith = o
                                Exit For
                            Else

                                'Find a new name
                                Dim cnt As Integer = 1
                                Dim nameIsInvalid As Boolean = True
                                While nameIsInvalid
                                    nameIsInvalid = False
                                    For p As Integer = 1 To Game.tileset.NumTiles
                                        If p <> o Then
                                            If newName & cnt = Game.tileset.tiles(p).name Then
                                                cnt += 1
                                                nameIsInvalid = True
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End While
                                newName &= cnt

                                'Ask if user wants to replace tile
                                If MessageBox.Show(String.Format(GetString("loadTileConflict"), tmpTileset.tiles(f.ListBox1.SelectedIndices(n) + 1).name, newName), GetString("importTileset"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    f.ListBox1.SetSelected(f.ListBox1.SelectedIndices(n), False)
                                    GoTo ContinueForN
                                Else
                                    Exit For
                                End If

                            End If

                        End If
                    Next

                    Dim tmpTile As psTile = tmpTileset.tiles(f.ListBox1.SelectedIndices(n) + 1)
                    tmpTile.name = newName
                    If replaceWith > 0 Then
                        'Remove actions
                        For p As Integer = 1 To UBound(Game.actions.Actions)
                            If p > UBound(Game.actions.Actions) Then Exit For
                            If Game.actions.Actions(p).Trigger.StartsWith("t") AndAlso Game.actions.Actions(p).Trigger.Substring(4) = replaceWith Then
                                For q As Integer = p To UBound(Game.actions.Actions) - 1
                                    Game.actions.Actions(q) = Game.actions.Actions(q + 1)
                                Next
                                ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) - 1)
                                p -= 1
                            End If
                        Next

                        'Replace tile
                        With Game.Drawing.Tex(Game.tileset.tiles(replaceWith).name)
                            .filename = tmpTile.filename
                            .width = .width
                            .height = .height
                            .sectionw = .sectionw
                            .sectionh = .sectionh
                            .ColorKey = .ColorKey
                            .ReloadTexture()
                        End With
                        Game.tileset.tiles(replaceWith) = tmpTile
                    Else
                        Game.tileset.AddTile(tmpTile)
                    End If

ContinueForN:
                Next
            Else
                'Not _importing_ a tileset - just loading:
                'Read the whole tileset
                'and replace it into the current one
                psFileHandler.Read(Game.tileset)
            End If

            'Load tile actions
            Dim OldMaxActions As Integer
            Dim i As Integer
            If loadActions Then
                If Not selectTiles Then
                    ReDim Game.actions.Actions(0)
                    Game.actions.SetDefaults2()
                End If
            End If
            i = psFileHandler.bReader.ReadInt32()
            If IsNothing(Game.actions.Actions) Then
                ReDim Game.actions.Actions(0)
            End If
            OldMaxActions = UBound(Game.actions.Actions)
            For n As Integer = 1 To i
                Dim tmpAction As psActions.psAction
                Dim replace As Boolean = True

                'Read action for file
                psFileHandler.Read(tmpAction)

                'Should we add this action?
                'Only ask this question if we are _importing_ the tileset
                If selectTiles Then
                    If tmpAction.Trigger.Chars(0) = "t" Then
                        If Not (f.ListBox1.GetSelected(tmpAction.Trigger.Substring(4) - 1)) Then
                            replace = False
                        Else
                            'Find new index
                            Dim cnt As Integer = 0
                            For o As Integer = 0 To f.ListBox1.SelectedIndices.Count - 1
                                cnt += 1
                                If f.ListBox1.SelectedIndices(o) + 1 = tmpAction.Trigger.Substring(4) Then
                                    Exit For
                                End If
                            Next

                            tmpAction.Trigger = "t" & tmpAction.Trigger.Substring(1, 3) & (OldMaxTiles + cnt)
                        End If
                    ElseIf tmpAction.Trigger.Chars(0) = "g" Then
                        If Not f.chkG.Checked Then replace = False
                    ElseIf tmpAction.Trigger.Chars(0) = "c" Then
                        If Not f.chkC.Checked Then replace = False
                    ElseIf tmpAction.Trigger.Chars(0) = "i" Then
                        If Not f.chkT.Checked Then replace = False
                    ElseIf tmpAction.Trigger.Chars(0) = "a" Then
                        If Not f.chkA.Checked Then replace = False
                    Else
                        If Not f.chkO.Checked Then replace = False
                    End If
                End If

                'Add action to action array
                If loadActions Then
                    If replace Then
                        ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) + 1)
                        Game.actions.Actions(UBound(Game.actions.Actions)) = tmpAction
                    End If
                End If
            Next
            If loadActions Then
                AdjustFilenames(OldMaxActions + 1)
            End If

            Dim j As Short

            'Load counters
            j = psFileHandler.bReader.ReadInt16()
            Dim tmpCounters() As psActions.psCounter
            ReDim tmpCounters(j)
            For n As Integer = 1 To j
                psFileHandler.Read(tmpCounters(n))
            Next
            If loadActions Then
                If (Not selectTiles) OrElse (f.chkC.Checked) Then
                    Game.actions.Counters = tmpCounters
                End If
            End If

            'Load timers
            j = psFileHandler.bReader.ReadInt16()
            Dim tmpTimers() As psActions.psTimer
            ReDim tmpTimers(j)
            For n As Integer = 1 To j
                psFileHandler.Read(tmpTimers(n))
            Next
            If loadActions Then
                If (Not selectTiles) OrElse (f.chkT.Checked) Then
                    Game.actions.Timers = tmpTimers
                End If
            End If

            'Done with the Import Tileset form
            If selectTiles Then
                f.Dispose()
            End If

            'Check file version
            Dim str As String = Nothing
            Try
                psFileHandler.FileGetString(str)
                If str Is Nothing OrElse str = "" Then Throw New Exception
            Catch ex As Exception
                str = "JumpCraft " & AssemblyVersion & " Game"
            End Try
            Dim FileUpdater As New psFileUpdater
            If FileUpdater.IsValidFile(str, True) = psFileUpdater.ValidFileEnum.Invalid Then
                'Invalid file
                Throw New Exception("Invalid file.")
            Else
                'Update file
                UpdatedFile = FileUpdater.UpdateFile(str, True)
            End If

            'Load the new images
            If Not selectTiles Then
                ClearTileImages()
                Game.tileset.Load()
            End If
            'Ese: we have already loaded the images
            'as added the tiles to the tilset

            If FileNotFoundCancel Then
                Game.Drawing.img_Clear()
                Erase Game.tileset.tiles
                ReDim Game.tileset.tiles(0)
            Else
                If AutoFound Then
                    'MessageBox.Show("JumpCraft could not find some files, but was able to locate similar or identical replacements.  Since these replacements might not be correct, we advise you to check over them.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format(GetString("error_LoadTileset"), ex.Message), GetString("error_LoadTilesetTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            If Not selectTiles Then
                ClearTileImages()
                Erase Game.tileset.tiles
                ReDim Game.tileset.tiles(0)
            End If
        Finally
            If Not theStream Is Nothing Then
                theStream.Close()
            End If
            FileNotFoundCancel = False
        End Try
        Game.tileset.tiles(0) = New psTile

        'Save tileset if it was updated to a new version
        If UpdatedFile AndAlso (Not selectTiles) Then
            SaveTileset(Filename)
        End If

        psMod1.LoadingFile = False

        Game.Status = tmp
    End Sub

    Private Sub ClearTileImages()
        For j As Integer = 0 To Game.Drawing.img_Count - 1
            If j > Game.Drawing.img_Count - 1 Then Exit For
            For i As Integer = 1 To Game.tileset.NumTiles
                If Game.Drawing.img_Key(j) = Game.tileset.tileName(i) Then
                    Game.Drawing.img_Remove(Game.Drawing.img_Key(j))
                    j -= 1
                    Exit For
                End If
            Next
        Next
    End Sub

    Sub SaveTileset(ByVal Filename As String)
        Try
            Try
                theStream.Close()
                FileClose(1)
            Catch
            End Try
            theStream = IO.File.Open(Filename, FileMode.Create)
            bWriter = New BinaryWriter(theStream)
            curFile = Filename

            'Save the filename
            psFileHandler.FilePutString2(Filename)

            'Save tileset
            formatter.Serialize(theStream, Game.tileset)

            'Save tile actions
            Dim i As Integer
            For n As Integer = 1 To UBound(Game.actions.Actions)
                Select Case Game.actions.Actions(n).Trigger.Chars(0)
                    Case "t", "c", "i"
                        i += 1
                End Select
            Next
            bWriter.Write(i)
            For n As Integer = 1 To UBound(Game.actions.Actions)
                Select Case Game.actions.Actions(n).Trigger.Chars(0)
                    Case "t", "c", "i"
                        formatter.Serialize(theStream, Game.actions.Actions(n))
                End Select
            Next
            bWriter.Write(CShort(UBound(Game.actions.Counters)))
            For n As Integer = 1 To UBound(Game.actions.Counters)
                formatter.Serialize(theStream, Game.actions.Counters(n))
            Next
            bWriter.Write(CShort(UBound(Game.actions.Timers)))
            For n As Integer = 1 To UBound(Game.actions.Timers)
                formatter.Serialize(theStream, Game.actions.Timers(n))
            Next

            'Save file version
            psFileHandler.FilePutString2(psFileUpdater.HEADER_TEXT)

            'Save data found in newer versions only
            psFileHandler.bWriter.Write(Game.tileW)
            psFileHandler.bWriter.Write(Game.tileH)
            psFileHandler.bWriter.Write(Game.tileColorKey)
            Game.tileset.SaveData()

            theStream.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format(GetString("error_SaveDefaultTileset"), Game.Root, ex.Message), GetString("error_SaveTilesetError"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'fo = file open
    Sub fo()
        'Passcodes
        Dim b As Byte, i As Integer, l As Long, s As Single, d As Double
        b = bReader.ReadByte()
        If b <> 195 Then Throw New Exception("Invalid file format.")
        i = bReader.ReadInt32()
        If i <> 1043681 Then Throw New Exception("Invalid file format.")
        l = bReader.ReadInt64()
        If l <> 12395835 Then Throw New Exception("Invalid file format.")
        s = bReader.ReadSingle()
        If s <> 46918346 Then Throw New Exception("Invalid file format.")
        d = bReader.ReadDouble()
        If d <> 14761023 Then Throw New Exception("Invalid file format.")
        psFileHandler.FileGetString(Tag)

        'Read the stored computer information and make
        'sure it matches with the current computer information.
        'This makes it so we can't run this file on another computer.
        Dim str As String = Nothing
        psFileHandler.FileGetString(str)
        If str <> Environment.OSVersion.ToString Then Throw New Exception("Invalid file format.")
        psFileHandler.FileGetString(str)
        If str <> Environment.MachineName Then Throw New Exception("Invalid file format.")
        psFileHandler.FileGetString(str)
        If str <> Environment.UserName Then Throw New Exception("Invalid file format.")

        Game.Code = Tag
    End Sub

    'fs = file save
    Sub fs()
        'Passcodes
        bWriter.Write(CByte(195))
        bWriter.Write(CInt(1043681))
        bWriter.Write(CLng(12395835))
        bWriter.Write(CSng(46918346))
        bWriter.Write(CDbl(14761023))
        psFileHandler.FilePutString(Tag)

        'Store some computer information so we can't
        'run this file on another computer.
        psFileHandler.FilePutString(Environment.OSVersion.ToString)
        psFileHandler.FilePutString(Environment.MachineName)
        psFileHandler.FilePutString(Environment.UserName)

        Game.Code = Tag
    End Sub

    Sub fo2()
        'Passcodes
        Dim b As Byte, i As Integer, l As Long, s As Single, d As Double
        b = bReader.ReadByte()
        If b <> 195 Then Throw New Exception("Invalid file format.")
        i = bReader.ReadInt32()
        If i <> 1043681 Then Throw New Exception("Invalid file format.")
        l = bReader.ReadInt64()
        If l <> 12395835 Then Throw New Exception("Invalid file format.")
        s = bReader.ReadSingle()
        If s <> 46918346 Then Throw New Exception("Invalid file format.")
        d = bReader.ReadDouble()
        If d <> 14761023 Then Throw New Exception("Invalid file format.")
    End Sub

    Sub fs2()
        'Passcodes
        bWriter.Write(CByte(195))
        bWriter.Write(CInt(1043681))
        bWriter.Write(CLng(12395835))
        bWriter.Write(CSng(46918346))
        bWriter.Write(CDbl(14761023))
    End Sub

#Region "Static Methods"
    Public Shared formatter As New BinaryFormatter

    <Serializable()> _
    Structure SerializableString
        Dim str As String
    End Structure

    Shared Sub FilePutString(ByVal str As String)
        If str Is Nothing Then
            bWriter.Write("")
        Else
            bWriter.Write(str)
        End If
    End Sub

    'Compatability method
    Shared Sub FilePutString2(ByVal str As String)
        Dim s As SerializableString
        If str Is Nothing Then
            s.str = ""
        Else
            s.str = str
        End If
        'FilePut(FileNumber, s)
        formatter.Serialize(psFileHandler.theStream, s)
    End Sub

    Shared Sub FileGetString(ByRef str As String)
        If psFileUpdater.curVersion < 2.2 Then
            Dim s As SerializableString = Nothing
            'FileGet(FileNumber, s)
            's = CType(formatter.Deserialize(psFileHandler.theStream), SerializableString)
            Read(s)
            str = s.str
        Else
            str = bReader.ReadString
        End If
    End Sub

    Shared Sub Write(ByVal obj As Object)
        formatter.Serialize(theStream, obj)
    End Sub

    Shared Sub Read(ByRef x As Object)
        Dim tmp As Integer
        Try
            'Quick & easy deserialization -- new file format
            tmp = theStream.Position
            x = formatter.Deserialize(theStream)
        Catch ex As Exception 'Runtime.Serialization.SerializationException
            'Saved in the older format -- use compatibility mode
            OldFileType = True
            If TypeOf x Is ValueType Then
                theStream.Position = tmp
                Dim q As ValueType = CType(x, ValueType)
                Dim tmpInt As Long = theStream.Position + 1
                theStream.Close()
                bReader.Close()
                FileOpen(1, curFile, OpenMode.Binary)
                FileGet(1, q, tmpInt)
                tmpInt = FileSystem.Loc(1) + 1 - 1
                FileClose(1)
                theStream = IO.File.Open(curFile, FileMode.Open)
                bReader = New BinaryReader(theStream)
                theStream.Position = tmpInt
            End If
        End Try
    End Sub

    Shared Function ReadBoolean() As Boolean
        If OldFileType Then
            '2 bytes for boolean
            Return CBool(bReader.ReadInt16())
        Else
            '1 byte
            Return bReader.ReadBoolean()
        End If
    End Function
#End Region

End Class