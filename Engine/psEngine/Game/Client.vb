Namespace GamePlayer
    Public Class GameClient
        Overridable Sub OnQuickResume()
            'Do nothing
        End Sub

        Overridable Sub BeginRendering()
            f.Show()
            f.Visible = True
            f.[Select]()
            Application.DoEvents()
            RenderLoop()
        End Sub

        Overridable Sub SetupGameObject()
            'Setup the game object
            Game = New PlatformStudio.psGame
            With Game
                .InEditor = False
                'If .Init(f.p.Handle.ToInt32, f.p) = False Then End
                .hwnd = f.Handle.ToInt32
                .p = f
                NewPresetActions = New PresetActions
                .PresetActions = NewPresetActions
            End With

            'Load the game file
            psFile = New PlatformStudio.psFileHandler
            If Client.LoadGameFile = False Then Exit Sub
            If Game.GameProperties.Windowed Then Game.p = f.p
            Game.Audio.OnLoad()
        End Sub

        Overridable Function ShowError(ByVal ErrorType As String, ByVal OccuredWhile As String, ByVal ErrorText As String, Optional ByVal CanIgnore As Boolean = False, Optional ByVal CanIgnoreAll As Boolean = True) As DialogResult
            Dim f As New GamePlayer.frmError
            QuickPause()
            Dim tmp As DialogResult = f.ShowDialog(ErrorType, OccuredWhile & ".", ErrorText, CanIgnore, CanIgnoreAll)
            QuickResume()
            Return tmp
        End Function

        Overridable Sub AddHighScore()
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
                'If Game.GameProperties.Windowed Then
                Dim f As New frmHighScore
                f.ShowDialog(Name)
                f.Dispose()
                'Else
                '    Try
                '        Game.Drawing.StoreBackbuffer()
                '        EnterString = True
                '        Game.Drawing.img_Add(Application.StartupPath & "\High Score.png", "&HighScores", Color.FromArgb(0), 512, 256)
                '        f.TextBox1.Text = "Anonymous"
                '        f.TextBox1.MaxLength = 18
                '        f.TextBox1.Visible = True
                '        f.TextBox1.Location = New Point((Game.windows.Width - 298) \ 2 + 14, (Game.windows.Height - 136) \ 2 + 71)
                '        f.TextBox1.Select(0, f.TextBox1.Text.Length)
                '        f.TextBox1.Focus()
                '        While EnterString
                '            Application.DoEvents()
                '            Game.Drawing.Clear()
                '            Game.Drawing.DrawSprite("Backbuffer", 0, 0)
                '            Game.Drawing.DrawSprite("&HighScores", (Game.windows.Width - 298) \ 2, (Game.windows.Height - 136) \ 2)

                '            'Draw the text in the textbox
                '            Dim Caret, Caret2 As SizeF
                '            Game.Drawing.DrawText(f.TextBox1.Text, _
                '                (Game.windows.Width - 298) \ 2 + 14, _
                '                (Game.windows.Height - 136) \ 2 + 71, _
                '                Color.Black)
                '            If f.TextBox1.SelectionStart > 0 Then
                '                Caret = f.TextBox1.CreateGraphics.MeasureString( _
                '                    f.TextBox1.Text.Substring( _
                '                    0, f.TextBox1.SelectionStart), f.TextBox1.Font)
                '            Else
                '                Caret = New SizeF(0, f.TextBox1.CreateGraphics.MeasureString( _
                '                    "asdf", f.TextBox1.Font).Height)
                '            End If
                '            If f.TextBox1.SelectionStart + f.TextBox1.SelectionLength > 0 Then
                '                Caret2 = f.TextBox1.CreateGraphics.MeasureString( _
                '                    f.TextBox1.Text.Substring( _
                '                    0, f.TextBox1.SelectionStart + f.TextBox1.SelectionLength), f.TextBox1.Font)
                '            Else
                '                Caret2 = Caret
                '            End If
                '            If Caret2.Width = Caret.Width Then Caret2.Width += 1
                '            Game.Drawing.DrawFilledBox _
                '                ((Game.windows.Width - 298) \ 2 + 14 + Caret.Width, _
                '                (Game.windows.Height - 136) \ 2 + 71, _
                '                Caret2.Width - Caret.Width, _
                '                Caret.Height, _
                '                Color.FromArgb(255, 49, 106, 197))
                '            Game.Drawing.DrawText(f.TextBox1.SelectedText, _
                '                (Game.windows.Width - 298) \ 2 + 14 + Caret.Width, _
                '                (Game.windows.Height - 136) \ 2 + 71, _
                '                Color.White)
                '            Game.Drawing.RenderToScreen()
                '        End While
                '        Name = f.TextBox1.Text
                '        f.TextBox1.Visible = False
                '        f.p.Focus()
                '    Catch ex As Exception
                '        Stop
                '        MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                '    End Try
                'End If
            End If
            With HighScores(hsIndex)
                .Name = Name
                .Level = StoppedAtLevel
                .Score = Score
            End With
            CurHighScore = hsIndex
            GamePlayer.Game.CurWinIndex = hsWindow
        End Sub

        Overridable Sub ClearHighscores()
            CurHighScore = 0
            ReDim HighScores(0)
        End Sub

        Overridable Sub [End]()
            '
        End Sub

        Overridable Function LoadGameFile() As Boolean
            Dim b As Boolean = psFile.LoadGame(5938195395831283597, Filename, AddressOf psFile.fo)
            Try
                'TODO: This is a bookmark for using psTest as startup
                IO.File.Delete(Game.TempRoot & "\~_tmp.tmp")
            Catch
            End Try
            Return b
        End Function

        Overridable Sub LoadHighScores()
            ReDim HighScores(0)
        End Sub

        Overridable ReadOnly Property WindowText() As String
            Get
                Return GamePlayer.Game.GameProperties.WindowTitle & " - " & f.Text
            End Get
        End Property
    End Class

    Public Structure HighScore
        Dim Name As String
        Dim Level As String
        Dim Score As Long
    End Structure

    Public Module modClient
        Public Client As GameClient

        Public psFile As psFileHandler

        Public f As MainForm

        Public Filename As String
        Public SkipWindows As Boolean
        Public Invincible As Boolean
        Public StartAtLevel As Integer
        Public DLLFilename As String
        Public ShowFPS As Boolean

        Public HighScores() As HighScore
        Public HighScoreCtrl As psUI.psControl.psHighScoresArea
        Public hsWindow As Integer, hsCtrl As Integer
        Public CurHighScore As Integer
        Public StoppedAtLevel As String
        Public RenderingWindow As Boolean

#Region "JumpCraft Objects"
        Public WithEvents Game As psGame

        Private Sub Game_ClickControl(ByRef ctrl As PlatformStudio.psUI.psControl, ByVal Index As Integer) Handles Game.ClickControl
            If Game.InEditor Then Return
            If PlayingMovie Then Exit Sub
            ActionProcessor.ProcessActions("wcli" & ctrl.Name)
        End Sub

        Private Sub Game_CounterChanged(ByVal CounterIndex As Integer) Handles Game.CounterChanged
            If Game.InEditor Then Return
            If NoCounterActions Then Exit Sub
            ActionProcessor.ProcessActions("cval" & CounterIndex, curCounter)
        End Sub

        Private Sub Game_DisappearTile(ByVal index As Integer, ByVal layer As Integer) Handles Game.DisappearTile
            If Game.InEditor Then Return
            With Game.CurMap.Cells1D2(index, layer)
                If Game.tileset.tiles(.tile).Anim(1).Interval > 0 Then
                    ReDim Preserve Anim(UBound(Anim) + 1)
                    If .Path.Exists = False Then
                        Anim(UBound(Anim)).Init((Game.CurMap.Conv1DTo2D(index).X - 1) * Game.tileW, (Game.CurMap.Conv1DTo2D(index).Y - 1) * Game.tileH, .tile, Game.tileset.tiles(.tile).Anim(1).StartFrame, 1, .Frame)
                    Else
                        Anim(UBound(Anim)).Init(.PathX, .PathY, .tile, Game.tileset.tiles(.tile).Anim(1).StartFrame, 1, .Frame)
                    End If
                End If
            End With
        End Sub

        Private Sub Game_LoadedGameProperties() Handles Game.LoadedGameProperties
            If Game.InEditor Then Return
            SetupWindow()
        End Sub
#End Region

#Region "Quick Pause/Resume"
        Dim quickPaused As Boolean

        Sub QuickPause()
            If Game.CurWinIndex = GameWindow Then
                Game.PresetActions.PauseGame()
                quickPaused = True
            End If
        End Sub

        Sub QuickResume()
            If quickPaused Then
                quickPaused = False
                Game.CurWinIndex = GameWindow
                Paused = False
                Character.OnResume()
            End If
            Client.OnQuickResume()
        End Sub
#End Region

        Public Sub DrawHighScores()            
            With HighScoreCtrl
                .Draw()

                Dim RankX As Integer = 0, RankW As Integer = 40
                Dim NameX As Integer, NameW As Integer
                Dim ScoreX As Integer, ScoreW As Integer
                Dim LevelX As Integer = .Width - 70, LevelW As Integer = 70
                Dim BodyWidth As Integer = .Width - RankX - RankW

                If .ShowLevel Then BodyWidth -= 70
                If .ShowName Then BodyWidth -= 70

                If .ShowName Then
                    NameX = RankX + RankW
                    NameW = BodyWidth
                    ScoreX = NameX + NameW
                    ScoreW = 70
                Else
                    ScoreX = RankX + RankW
                    ScoreW = BodyWidth
                End If

                'Draw lines
                If .Border Then
                    Game.Drawing.DrawBox(0, 0, .Width - 1, .Height - 1, .BorderColor)
                    Game.Drawing.DrawLine(0, 16, .Width, 16, .BorderColor)
                    Game.Drawing.DrawLine(RankX + RankW, 0, RankX + RankW, .Height, .BorderColor)
                    If .ShowLevel Then
                        Game.Drawing.DrawLine(LevelX, 0, LevelX, .Height, .BorderColor)
                    End If
                    Game.Drawing.DrawLine(ScoreX, 0, ScoreX, .Height, .BorderColor)
                End If

                'Draw headers
                Game.Drawing.DrawText("HighScoresHeader", GetString("highScores_Rank"), New Rectangle(RankX, 0, RankW, 16), .ForeColor)
                If .ShowLevel Then
                    Game.Drawing.DrawText("HighScoresHeader", GetString("highScores_Level"), New Rectangle(LevelX, 0, LevelW, 16), .ForeColor)
                End If
                If .ShowName Then
                    Game.Drawing.DrawText("HighScoresHeader", GetString("highScores_Name"), New Rectangle(NameX, 0, NameW, 16), .ForeColor)
                End If
                Game.Drawing.DrawText("HighScoresHeader", GetString("highScores_Score"), New Rectangle(ScoreX, 0, ScoreW, 16), .ForeColor)

                'Draw body
                Dim tmpColor As Color, tmpFont As String
                For i As Integer = 1 To UBound(HighScores)
                    If i = CurHighScore Then
                        If .GetForeColor.ToArgb = Color.White.ToArgb Then
                            tmpColor = Color.Yellow
                        Else
                            tmpColor = Color.White
                        End If
                        tmpFont = "HighScoresHeader"
                    Else
                        tmpColor = .ForeColor
                        tmpFont = .ID
                    End If
                    Game.Drawing.DrawText(tmpFont, i, New Rectangle(RankX, 16 * i, RankW, 16), tmpColor)
                    If .ShowLevel Then
                        Game.Drawing.DrawText(tmpFont, HighScores(i).Level, New Rectangle(LevelX, 16 * i, LevelW, 16), tmpColor)
                    End If
                    If .ShowName Then
                        Game.Drawing.DrawText(tmpFont, HighScores(i).Name, New Rectangle(NameX, 16 * i, NameW, 16), tmpColor)
                    End If
                    Game.Drawing.DrawText(tmpFont, HighScores(i).Score, New Rectangle(ScoreX, 16 * i, ScoreW, 16), tmpColor)
                Next
            End With
        End Sub
    End Module
End Namespace