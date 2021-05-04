Imports PlatformStudio
Imports PlatformStudio.GamePlayer

Public Class myClient
    Inherits GamePlayer.GameClient

    Overrides Function ShowError(ByVal ErrorType As String, ByVal OccuredWhile As String, ByVal ErrorText As String, Optional ByVal CanIgnore As Boolean = False, Optional ByVal CanIgnoreAll As Boolean = True) As DialogResult
        Dim f As New frmError
        Return LogError(ErrorType, OccuredWhile & ".", ErrorText, CanIgnore, CanIgnoreAll)
    End Function

    Private Function LogError(ByVal ErrorType As String, ByVal OccuredWhile As String, ByVal ErrorText As String, Optional ByVal CanIgnore As Boolean = False, Optional ByVal CanIgnoreAll As Boolean = True) As DialogResult
        FileOpen(10, EXEDir & "\errlog.txt", OpenMode.Append)
        Print(10, Today.Month & "/" & Today.Day & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second & vbCrLf & String.Format(GetString("errLog"), OccuredWhile, ErrorText) & vbCrLf & vbCrLf)
        FileClose(10)
        If CanIgnore Then
            Return DialogResult.Retry
        Else
            MessageBox.Show(String.Format(GetString("fatalError"), GamePlayer.Game.GameProperties.Name), GamePlayer.Game.GameProperties.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            f.DoClose()
            End
        End If
    End Function

    Public Overrides Sub AddHighScore()
        Dim Score As Long = GamePlayer.Game.actions.Counters(1).Value
        If hsWindow = 0 Then Exit Sub
        If Score <= 0 Then Exit Sub
        Dim BeatScore As Integer
        Dim hsIndex As Integer
        For i As Integer = 1 To UBound(HighScores)
            If HighScores(i).Score < Score Then
                BeatScore = i
                Exit For
            End If
        Next
        If BeatScore > 0 Then
            ReDim Preserve HighScores(UBound(HighScores) + 1)
            For i As Integer = UBound(HighScores) To BeatScore + 1 Step -1
                HighScores(i) = HighScores(i - 1)
            Next
            hsIndex = BeatScore
            If UBound(HighScores) > HighScoreCtrl.NumberOfScores Then
                ReDim Preserve HighScores(HighScoreCtrl.NumberOfScores)
                If hsIndex > UBound(HighScores) Then Exit Sub
            End If
        ElseIf UBound(HighScores) < HighScoreCtrl.NumberOfScores Then
            ReDim Preserve HighScores(UBound(HighScores) + 1)
            hsIndex = UBound(HighScores)
        Else
            Exit Sub
        End If
        Dim Name As String = GetString("anonymous")
        If HighScoreCtrl.ShowName Then
            Dim f As New frmHighScore
            f.ShowDialog(Name)
            f.Dispose()
        End If
        With HighScores(hsIndex)
            .Name = Name
            .Level = StoppedAtLevel
            .Score = Score
        End With
        CurHighScore = hsIndex
        GamePlayer.Game.CurWinIndex = hsWindow
        SaveHighScores()
    End Sub

    Public Overrides Sub [End]()
        End
    End Sub

    Public Overrides Function LoadGameFile() As Boolean
        Return psFile.LoadGame(5938195395831283597, Filename, AddressOf psFile.fo2, False)
    End Function

    Public Overrides Sub LoadHighScores()
        Try
            ReDim HighScores(0)
            FileOpen(1, EXEDir & "\data2.dat", OpenMode.Binary, OpenAccess.Read)
            Dim l As Long
            FileGet(1, l)
            If l <> 3235938437815663125 Then Throw New Exception(GetString("invalidData2File"))
            Dim tmpInt As Integer
            FileGet(1, tmpInt)
            ReDim HighScores(tmpInt)
            For i As Integer = 1 To tmpInt
                FileGet(1, HighScores(i))
            Next
            For i As Integer = 1 To UBound(HighScores)
                Dim tmpStr As String = ""
                For j As Integer = 0 To HighScores(i).Name.Length - 1
                    tmpStr &= Chr(255 - Asc(HighScores(i).Name.Chars(j)))
                Next
                HighScores(i).Name = tmpStr
                tmpStr = ""
                For j As Integer = 0 To HighScores(i).Level.Length - 1
                    tmpStr &= Chr(255 - Asc(HighScores(i).Level.Chars(j)))
                Next
                HighScores(i).Level = tmpStr
            Next
            FileClose(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, GetString("error_"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            f.DoClose()
            End
            'Throw New Exception("Unable to load, ""data2.dat"".")
        End Try
    End Sub

    Sub SaveHighScores()
        Try
            FileOpen(1, EXEDir & "\data2.dat", OpenMode.Binary, OpenAccess.Write)
            Dim tmpHighScores() As HighScore
            tmpHighScores = HighScores.Clone
            FilePut(1, 3235938437815663125)
            For i As Integer = 1 To UBound(HighScores)
                Dim tmpStr As String = ""
                For j As Integer = 0 To HighScores(i).Name.Length - 1
                    tmpStr &= Chr(255 - Asc(HighScores(i).Name.Chars(j)))
                Next
                HighScores(i).Name = tmpStr
                tmpStr = ""
                For j As Integer = 0 To HighScores(i).Level.Length - 1
                    tmpStr &= Chr(255 - Asc(HighScores(i).Level.Chars(j)))
                Next
                HighScores(i).Level = tmpStr
            Next
            FilePut(1, CInt(UBound(HighScores)))
            For i As Integer = 1 To UBound(HighScores)
                FilePut(1, HighScores(i))
            Next
            HighScores = tmpHighScores.Clone
            FileClose(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, GetString("error_"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            f.DoClose()
            End
        End Try
    End Sub

    Public Overrides ReadOnly Property WindowText() As String
        Get
            Return GamePlayer.Game.GameProperties.WindowTitle
        End Get
    End Property

    Public Overrides Sub ClearHighscores()
        MyBase.ClearHighscores()
        SaveHighScores()
    End Sub
End Class