Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Namespace GamePlayer
    Public Module Renderer
        'Global variables
        Public Keys(255) As Boolean

        'Stores data for immediate use
        Public GameWindow As Integer, GameCtl As psUI.psControl
        Public MenuWindow As Integer = 1
        Public WinWindow As Integer, LoseWindow As Integer
        Public PauseWindow As Integer
        Public HelpWindow As Integer, AboutWindow As Integer
        Public LevelCompleteWindow() As Integer
        Public Paused As Boolean, PauseStart As Single
        Public HelpFile As String
        Public OldWindow As Integer
        Public WinStart As Single
        Public MLButton, MRButton, MMButton, ClickGroup As Boolean
        Public PauseRendering As Boolean

        'Camera
        Public AutoUpdateCamera As Boolean = True
        Public MoveCameraToDefaultPosition As Boolean
        Public mctdpX As Integer
        Public mctdpY As Integer
        Public tmpAutoUpdate As Boolean
        Public FirstFrame As Boolean 'used in ActionProcessor.EnsureVisible

        'FPS
        Public start As Single, frames As Integer, fps As Single
        Public elapsed As Double

        Sub ResetState()
            GameWindow = 0 : GameCtl = Nothing
            MenuWindow = 1
            WinWindow = 0 : LoseWindow = 0
            PauseWindow = 0
            HelpWindow = 0 : AboutWindow = 0
            LevelCompleteWindow = Nothing
            Paused = False : PauseStart = 0
            HelpFile = ""
            OldWindow = 0
            WinStart = 0
            MLButton = False : MRButton = False : MMButton = False : ClickGroup = False
            PauseRendering = False

            AutoUpdateCamera = True
            MoveCameraToDefaultPosition = False
            mctdpX = 0
            mctdpY = 0
            tmpAutoUpdate = False
            FirstFrame = False

            start = 0 : frames = 0 : fps = 0
            elapsed = 0

            Anim = Nothing

            PrevWindow = 0
            LastDifferentWindow = 0
            CamMoveScale = 0
            NeedToClear = False
            tmpTrans = psUI.psWindows.psWindow.TransitionType.None
            tmpTransLen = 0
            DrawingTransition = False
        End Sub

        Structure Animation
            Dim X, Y As Integer
            Dim Tile, Frame, AnimIndex As Integer
            Dim StartTime As Single
            Dim Done As Boolean
            Dim Key As Single
            Private _Effect As Short
            Dim Flipped As Boolean

            Enum AnimationEffect
                None = 0
                Fade
                Flatten
                Fall
                BlinkOnce
                BlinkTwice
                BlinkThrice
            End Enum

            Property Effect() As AnimationEffect
                Get
                    Return _Effect
                End Get
                Set(ByVal Value As AnimationEffect)
                    _Effect = Value
                End Set
            End Property

            Sub Init(ByVal _X As Integer, ByVal _Y As Integer, ByVal _Tile As Integer, ByVal _Frame As Integer, ByVal _AnimIndex As Integer, ByVal _CurFrame As Integer)
                X = _X
                Y = _Y
                Tile = _Tile
                Frame = _Frame
                AnimIndex = _AnimIndex
                StartTime = Timer

                'Get whether the tile is flipped or not
                For i As Integer = 0 To PathTiles.Count - 1
                    If PathTiles(i).X = X And PathTiles(i).Y = Y Then
                        Flipped = PathTiles(i).Flip
                        Exit For
                    End If
                Next

                'For disappear effects
                If Frame < 0 Then
                    Effect = -Frame
                    Frame = _CurFrame
                Else
                    Effect = AnimationEffect.None
                End If
            End Sub

            Function GetTile() As psTile
                Return Game.tileset.tiles(Tile)
            End Function

            Function GetAnim() As psTile.psTileAnimation
                Return Game.tileset.tiles(Tile).Anim(AnimIndex)
            End Function

            Function GetSrcRect() As Rectangle
                Return CurRect(Game.tileset.tiles(Tile), AnimIndex, StartTime, Frame, False)
            End Function

            Sub Draw()
                Dim offX As Integer, scaleW As Integer
                If Flipped Then
                    scaleW = -1
                    offX = GetTile.sectionw
                Else
                    scaleW = 1
                End If
                If Effect = AnimationEffect.None Then
                    Dim OldFrame As Integer = Frame
                    Dim SrcRect As Rectangle = GetSrcRect()
                    If (GetAnim.StopFrame > GetAnim.StartFrame And Frame < OldFrame) Or _
                       (GetAnim.StopFrame < GetAnim.StartFrame And Frame > OldFrame) Then
                        Done = True
                        Exit Sub
                    End If
                    Game.Drawing.DrawSprite(GetTile.name, GetSrcRect, offX + X, Y, scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.White)
                Else
                    Dim Time As Single = (Timer - StartTime) / GetAnim.Interval
                    If Time > 1 Then
                        Done = True
                        Exit Sub
                    ElseIf Time < 0 Then
                        Time = 0
                    End If
                    Select Case Effect
                        Case AnimationEffect.Fade
                            Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y, scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.FromArgb(255 - (Time * 255), 255, 255, 255))
                        Case AnimationEffect.Flatten
                            Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y + (Time * GetTile.sectionh), scaleW * GetTile.sectionw, (GetTile.sectionh - Time * GetTile.sectionh), 0, Color.White)
                        Case AnimationEffect.Fall
                            Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y + (Time * (Game.cam.h - (Y - Game.cam.Y))), scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.White)
                        Case AnimationEffect.BlinkOnce
                            If Int(Time * 2) Mod 2 = 1 Then
                                Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y, scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.White)
                            End If
                        Case AnimationEffect.BlinkTwice
                            If Int(Time * 4) Mod 2 = 1 Then
                                Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y, scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.White)
                            End If
                        Case AnimationEffect.BlinkThrice
                            If Int(Time * 6) Mod 2 = 1 Then
                                Game.Drawing.DrawSprite(GetTile.name, CurRect(GetTile, Frame), offX + X, Y, scaleW * GetTile.sectionw, GetTile.sectionh, 0, Color.White)
                            End If
                    End Select
                End If
            End Sub
        End Structure
        Public Anim() As Animation

        Sub DrawAnim()
            For i As Integer = 1 To UBound(Anim)
                If i > UBound(Anim) Then Exit For
                If Anim(i).Tile > 0 Then Anim(i).Draw()
                If Anim(i).Done Or Anim(i).Tile = 0 Then
                    For j As Integer = i To UBound(Anim) - 1
                        Anim(j) = Anim(j + 1)
                    Next
                    ReDim Preserve Anim(UBound(Anim) - 1)
                    i -= 1
                End If
            Next
        End Sub

        Public PrevWindow As Integer
        Public LastDifferentWindow As Integer
        Public CamMoveScale As Single
        Public NeedToClear As Boolean
        Public tmpTrans As psUI.psWindows.psWindow.TransitionType
        Public tmpTransLen As Single
        Public DrawingTransition As Boolean

        Sub Render()
            If RenderingWindow = False Then Exit Sub

            ChangedLevel = False
            DrawingTransition = False

            'Window transitions
            If Game.CurWinIndex <> OldWindow Then
                If OldWindow = WinWindow Then
                    Client.AddHighScore()
                ElseIf OldWindow = LoseWindow Then
                    Client.AddHighScore()
                End If

                LastDifferentWindow = OldWindow

                'Play movie
                Dim PlayedMovie As Boolean
                For i As Integer = 1 To Game.CurWindow.NumCtrls
                    If Game.CurWindow.Controls(i).Type = psUI.psControl.psCtrlType.Movie Then
                        Dim tmpMovie As psUI.psControl.psMovie = Game.CurWindow.Controls(i)
                        If tmpMovie.PlayOnce = False Or tmpMovie.Played = False Then
                            Game.PresetActions.PlayMovie(tmpMovie.GetBackground.imgFilename, tmpMovie.Volume, tmpMovie.PressKeyToStop, tmpMovie.X, tmpMovie.Y, tmpMovie.Width, tmpMovie.Height, tmpMovie.BlackBackground)
                            tmpMovie.Played = True
                            PlayedMovie = True
                        End If
                        tmpMovie = Nothing
                    End If
                Next
                f.Focus()

                'Play window/game music
                If Game.CurWinIndex = GameWindow Then
                    If Game.CurMap.Music <> "" Then
                        Game.Audio.PlayMusic(Game.CurMap.Music, Game.CurMap.Volume)
                    Else
                        If Game.CurWindow.Music <> "" Then Game.Audio.PlayMusic(Game.CurWindow.Music, Game.CurWindow.Volume)
                    End If
                Else
                    If Game.CurWindow.Music <> "" Then Game.Audio.PlayMusic(Game.CurWindow.Music, Game.CurWindow.Volume)
                End If

                If PlayedMovie = False Then
                    'Find the type of transition
                    If LastDifferentWindow > 0 AndAlso Game.windows.Windows(LastDifferentWindow).TransitionOut <> psUI.psWindows.psWindow.TransitionType.None Then
                        tmpTrans = Game.windows.Windows(LastDifferentWindow).TransitionOut
                        tmpTransLen = Game.windows.Windows(LastDifferentWindow).TransitionOutLength
                    Else
                        tmpTrans = Game.CurWindow.TransitionIn
                        tmpTransLen = Game.CurWindow.TransitionInLength
                    End If

                    'Random transition
                    If tmpTrans = psUI.psWindows.psWindow.TransitionType.Random Then
                        Randomize()
                        tmpTrans = Int(Rnd(1) * (UBound(System.Enum.GetValues(GetType(psUI.psWindows.psWindow.TransitionType))) - 1) + 1)
                    End If

                    'The only valid transition from nothing is "Fade"
                    If tmpTrans <> psUI.psWindows.psWindow.TransitionType.None And tmpTrans <> psUI.psWindows.psWindow.TransitionType.Fade And OldWindow = 0 Then
                        tmpTrans = psUI.psWindows.psWindow.TransitionType.Fade
                    End If

                    'Stores the current view in a texture
                    'so we can use it as a sprite when drawing transitions
                    If OldWindow = 0 Then
                        If Game.Drawing.StoreBlankBackbuffer() = False Then
                            tmpTrans = psUI.psWindows.psWindow.TransitionType.None
                        End If
                    Else
                        If Game.Drawing.StoreBackbuffer() = False Then
                            tmpTrans = psUI.psWindows.psWindow.TransitionType.None
                        End If
                    End If
                Else
                    tmpTrans = psUI.psWindows.psWindow.TransitionType.None
                End If

                'Update the window start time
                WinStart = swatch2.ElapsedTime
            End If

            'Advance to the next window after a specified amount of time
            If swatch2.ElapsedTime - WinStart >= Game.CurWindow.TransitionAfter + tmpTransLen Then
                If Game.CurWindow.TransitionTo > 0 Then
                    OldWindow = Game.CurWinIndex
                    Game.CurWinIndex = Game.CurWindow.TransitionTo
                    Exit Sub
                End If
            End If

            'Determine if we are drawing a transition or not
            If tmpTrans <> psUI.psWindows.psWindow.TransitionType.None AndAlso swatch2.ElapsedTime - WinStart < tmpTransLen Then
                DrawingTransition = True
            End If

DoneTrans:

            OldWindow = Game.CurWinIndex

            'Clear
            NeedToClear = True

            'Draw the current window
            If Game.CurWinIndex <> PauseWindow And Paused And DrawingTransition = False Then
                Paused = False
                Character.OnResume()
            End If
            DrawWindow(Game.CurWinIndex)
            If ChangedLevel Then Exit Sub

            'Clear
            If NeedToClear Then
                Game.Drawing.Clear()
                NeedToClear = False
            End If

            'Draw the transition
            If DrawingTransition Then
                Dim tmp As Single = (swatch2.ElapsedTime - WinStart) / tmpTransLen
                Dim w As Integer = Game.cam.w
                Dim h As Integer = Game.cam.h
                If tmp <= 0 Then tmp = 0
                If tmp <= 1 Then
                    Select Case tmpTrans
                        Case psUI.psWindows.psWindow.TransitionType.Fade
                            Game.Drawing.DrawSprite("Backbuffer", 0, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FadeThroughBlack
                            If tmp <= 0.5 Then
                                Game.Drawing.DrawFilledBox(0, 0, w, h, Color.FromArgb(255, 0, 0, 0))
                                Game.Drawing.DrawSprite("Backbuffer", 0, 0, Color.FromArgb(255 - (tmp * 2) * 255, 255, 255, 255))
                            Else
                                Game.Drawing.DrawFilledBox(0, 0, w, h, Color.FromArgb(255 - ((tmp - 0.5) * 2) * 255, 0, 0, 0))
                            End If
                        Case psUI.psWindows.psWindow.TransitionType.FlipHorizontal
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w, 0, (w - tmp * w * 2), h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FlipVertical
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, tmp * h, w, (h - tmp * h * 2), 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.RotateCCW
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w * 0.5, tmp * h * 0.5, w - tmp * w, h - tmp * h, tmp * (3.14159265358979), Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.RotateCW
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w * 0.5, tmp * h * 0.5, w - tmp * w, h - tmp * h, tmp * (-3.14159265358979), Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.ZoomIn
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), -tmp * w * 0.5, -tmp * h * 0.5, w + tmp * w, h + tmp * h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.ZoomOut
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w * 0.5, tmp * h * 0.5, w - tmp * w, h - tmp * h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FlyLeft
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), -tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FlyRight
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FlyUp
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, -tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.FlyDown
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.DivideHorizontally
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), -tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.DivideVertically
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, -tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                        Case psUI.psWindows.psWindow.TransitionType.DivideBoth
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), -tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), tmp * w, 0, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, -tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                            Game.Drawing.DrawSprite("Backbuffer", New Rectangle(0, 0, w, h), 0, tmp * h, w, h, 0, Color.FromArgb(255 - tmp * 255, 255, 255, 255))
                    End Select
                End If
            End If

            PrevWindow = Game.CurWinIndex

            'Update the FPS
            If start = 0 Then start = Microsoft.VisualBasic.Timer
            frames = frames + 1
            If Microsoft.VisualBasic.Timer - start >= 1 Then
                start = Microsoft.VisualBasic.Timer
                fps = frames
                frames = 0
            End If

            'Draw the FPS
            If ShowFPS Then
                Game.Drawing.RelativeToCam = False
                Game.Drawing.DrawText(fps & " " & GetString("fpsUnit"), 2, 2, Color.White)
            End If

            'Done drawing this frame
            Game.Drawing.RenderToScreen()

            'Window transitions
            If Game.CurWinIndex <> OldWindow Then
                'WinStart = swatch2.ElapsedTime
                'LastDifferentWindow = OldWindow
            Else
                OldWindow = Game.CurWinIndex
            End If
        End Sub

        Sub DrawWindow(ByVal Window As Integer)
            If Window = PauseWindow And GameWindow <> PauseWindow Then
                DrawWindow(GameWindow)
                Game.windows.set__CurWinIndex(Window)
            End If
            Dim i As Integer
            Dim tmp As Integer = Game.CurWinIndex
            Game.windows.set__CurWinIndex(Window)
            With Game
                '.Audio.UpdateMusic()
                If Game.CurWinIndex = GameWindow Then
                    If StartedNewGame = False Then
                        NewGame()
                        MenuWindow = LastDifferentWindow
                    Else
                        Game.Audio.ResumeMusic()
                    End If

                    If (Character.Wait = False And Paused = False And DrawingTransition = False) Or JustLoadedLevel Then
                        JustLoadedLevel = False

                        'Store anything that the user wants to draw
                        'in a buffer, so we can draw it on top of the map
                        .Drawing.DrawLater = 1971116
                        .Drawing.RelativeToCam = False
                        .Drawing.IgnoreOffsets = True

                        'Process keyboard actions
                        For i = 0 To 255
                            If Keys(i) Then
                                ActionProcessor.ProcessActions("khol" & i)
                                If ChangedLevel Then GoTo EndSub
                            End If
                        Next

                        'Process mouse actions
                        If MLButton Then ActionProcessor.ProcessActions("mlho")
                        If MRButton Then ActionProcessor.ProcessActions("mrho")
                        If MMButton Then ActionProcessor.ProcessActions("mmho")
                        Dim tp As TilePtr = GetHoverTile()
                        If tp.Layer >= 1 And tp.Layer <= 3 Then
                            CurTile = tp
                            SetCurGroup(tp.GetTile.Group, tp.X, tp.Y, tp.Width, tp.Height, tp.GetTile.HitPoints, tp.GetTile.Frame, tp.GetTile.AnimIndex, tp.GetTile.GetTile.name)
                            ActionProcessor.ProcessActions("thov" & tp.GetTile.tile, curGroup)
                            ActionProcessor.ProcessActions("ghov" & LevelText & curGroup.Name, curGroup)
                            If ClickGroup Then
                                ActionProcessor.ProcessActions("tcli" & tp.GetTile.tile, curGroup)
                                ActionProcessor.ProcessActions("gcli" & LevelText & curGroup.Name, curGroup)
                            End If
                        End If

                        'Update the character and process character actions
                        If StartedNewGame Then
                            Character.Update()
                            If ChangedLevel Then
                                GoTo EndSub
                            End If
                        End If
                    End If

                    'Stop copying the draw data to the buffer
                    .Drawing.DrawLater = 6111791

                    'Clear
                    If NeedToClear Then
                        Game.Drawing.Clear()
                        NeedToClear = False
                    End If

                    'Draw background
                    Game.CurWindow.Background.Draw(0, 0, Game.windows.Width, Game.windows.Height)

                    'Set the viewport
                    .Drawing.RelativeToCam = True
                    .Drawing.IgnoreOffsets = False
                    .Drawing.OffsetX = GameCtl.X
                    .Drawing.OffsetY = GameCtl.Y
                    .cam.CustomWidth = GameCtl.Width
                    .cam.CustomHeight = GameCtl.Height
                    .Drawing.SetClippingRect(GameCtl.Rectangle)

                    'Update the camera
                    If Paused = False Then
                        If MoveCameraToDefaultPosition Then AutoUpdateCamera = True

                        Dim DestCamX As Single = Character.rawX + (Character.rawWidth - .cam.w) \ 2
                        Dim DestCamY As Single = Character.rawY + (Character.rawHeight - .cam.h) \ 2
                        If DestCamX < 0 Then DestCamX = 0
                        If DestCamY < 0 Then DestCamY = 0
                        If DestCamX + .cam.w > .tileW * .CurMapWidth Then DestCamX = .tileW * .CurMapWidth - .cam.w
                        If DestCamY + .cam.h > .tileH * .CurMapHeight Then DestCamY = .tileH * .CurMapHeight - .cam.h
                        If MoveCameraToDefaultPosition Then
                            DestCamX += mctdpX
                            DestCamY += mctdpY
                        End If

                        If FoundDieAnim() Then
                            'Wait for character to die
                        Else
                            'Gradually move camera
                            If Character.Wait And Character.WaitStart > 0 Then
                                'Just finished die animation (WaitStart = 1),
                                'so set a new WaitStart.
                                If Character.WaitStart = 1 Then Character.WaitStart = Timer

                                Dim TotalDistance As Single = Math.Sqrt((DestCamX - Character.WaitCamX) ^ 2 + (DestCamY - Character.WaitCamY) ^ 2)
                                Dim DistanceGone As Single = Math.Sqrt((Game.cam.X - Character.WaitCamX) ^ 2 + (Game.cam.Y - Character.WaitCamY) ^ 2)
                                If Math.Round(DistanceGone) >= Math.Round(TotalDistance) Or (Not AutoUpdateCamera) Then
                                    If AutoUpdateCamera Then
                                        .cam.X = DestCamX
                                        .cam.Y = DestCamY
                                    End If
                                    Character.Wait = False
                                Else
                                    Dim BaseScale As Single = 32 * Game.tileW * TimeElapsed
                                    If DistanceGone < TotalDistance / 2 Then
                                        CamMoveScale += BaseScale
                                    Else
                                        CamMoveScale -= BaseScale
                                    End If
                                    If CamMoveScale < BaseScale Then CamMoveScale = BaseScale
                                    If AutoUpdateCamera Then
                                        .cam.X += ((DestCamX - Character.WaitCamX) / TotalDistance) * TimeElapsed * CamMoveScale
                                        .cam.Y += ((DestCamY - Character.WaitCamY) / TotalDistance) * TimeElapsed * CamMoveScale
                                    End If
                                End If
                                If MoveCameraToDefaultPosition Then
                                    AutoUpdateCamera = tmpAutoUpdate
                                End If
                            Else
                                If AutoUpdateCamera Then
                                    .cam.X = DestCamX
                                    .cam.Y = DestCamY
                                End If
                                If MoveCameraToDefaultPosition Then
                                    AutoUpdateCamera = tmpAutoUpdate
                                    MoveCameraToDefaultPosition = False
                                End If
                            End If
                        End If
                    End If

                    'Draw the game
                    DrawGame()

                    'Reset the viewport
                    .Drawing.OffsetX = 0
                    .Drawing.OffsetY = 0
                    .cam.CustomWidth = 0
                    .cam.CustomHeight = 0
                    .Drawing.SetClippingRect(New Rectangle(0, 0, Game.cam.w, Game.cam.h))
                    .Drawing.IgnoreOffsets = True
                    .Drawing.RelativeToCam = False

                    'Now draw the buffer
                    .Drawing.DrawItemsInBuffer(1971116)

                    'Draw the rest of the controls
                    Game.Drawing.RelativeToCam = False
                    Game.Drawing.AffectedByScrollSpeed = False
                    For i = 1 To Game.CurWindow.NumCtrls
                        Game.CurWindow.Controls(i).Draw()
                    Next
                Else
                    'Clear
                    If NeedToClear Then
                        Game.Drawing.Clear()
                        NeedToClear = False
                    End If

                    .CurWindow.Draw()

                    If Game.CurWinIndex = hsWindow Then
                        .Drawing.RelativeToCam = False
                        .Drawing.IgnoreOffsets = False
                        .Drawing.OffsetX = HighScoreCtrl.X
                        .Drawing.OffsetY = HighScoreCtrl.Y
                        .cam.CustomWidth = HighScoreCtrl.Width
                        .cam.CustomHeight = HighScoreCtrl.Height
                        .Drawing.SetClippingRect(HighScoreCtrl.Rectangle)
                        DrawHighScores()
                        .Drawing.OffsetX = 0
                        .Drawing.OffsetY = 0
                        .cam.CustomWidth = 0
                        .cam.CustomHeight = 0
                        .Drawing.SetClippingRect(New Rectangle(0, 0, Game.cam.w, Game.cam.h))
                        .Drawing.IgnoreOffsets = True
                        .Drawing.RelativeToCam = False
                    End If
                End If
            End With
EndSub:
            Game.Drawing.DrawLater = 6111791
            If Window <> GameWindow Then Game.windows.set__CurWinIndex(tmp)
            ClickGroup = False
        End Sub

        Function FoundDieAnim() As Boolean
            For i As Integer = 1 To UBound(Anim)
                '-1 denotes character is dying
                If Anim(i).Key = -1 Then Return True
            Next
        End Function

        Private Function GetHoverTile() As TilePtr
            Dim mx, my, tilex, tiley As Integer
            mx = Game.PresetActions.MouseX - GameCtl.X + Game.cam.X
            my = Game.PresetActions.MouseY - GameCtl.Y + Game.cam.Y
            tilex = mx \ Game.tileW + 1
            tiley = my \ Game.tileH + 1
            If tilex < 1 Or tiley < 1 Or tilex > Game.CurMapWidth Or tiley > Game.CurMapHeight Then Return TilePtr.Empty
            For i As Integer = 0 To PathTiles.Count - 1
                If Not ((PathTiles(i).Layer < 1 Or PathTiles(i).Layer > 3) OrElse PathTiles(i).GetTile.tile = 0 OrElse PathTiles(i).GetTile.Invisible) Then
                    If Game.Math.Collide_PtBox(mx, my, PathTiles(i).Rectangle) Then
                        'Valid tile
                        Return PathTiles(i)
                    End If
                End If
            Next
            For x As Integer = tilex To Math.Max(1, tilex - 3) Step -1
                For y As Integer = tiley To Math.Max(1, tiley - 3) Step -1
                    For n As Integer = 1 To 3
                        Dim mapCell As psMapTile = Game.CurMap.Cells2(x, y, n)
                        If Not (mapCell.tile = 0 OrElse mapCell.Invisible OrElse mapCell.Path.Exists) Then
                            If Game.Math.Collide_PtBox(mx, my, (x - 1) * Game.tileW, (y - 1) * Game.tileH, mapCell.w, mapCell.h) Then
                                'Valid tile
                                Return New TilePtr(Game.CurMap.Get1DIndex(x, y), n)
                            End If
                        End If
                    Next
                Next
            Next
            Return TilePtr.Empty
        End Function

        Public swatch2 As New Stopwatch
        Public Rendered As Boolean
        Sub RenderLoop()
            RenderingWindow = True
            Dim swatch As New Stopwatch("Frame")
            swatch2.Start()
            While f.Created
                swatch.Start("Frame")
                If Not PauseRendering Then
                    If f.Visible Then
                        If Game.Drawing.device.CheckCooperativeLevel = False Then
                            Game.Drawing.Re_Init(Game.p)
                        Else
                            Render()
                        End If
                    End If
                End If
                Rendered = True
                If (swatch.ElapsedTime() < 1.0 / 60.0) Then
                    Threading.Thread.Sleep(CInt(Math.Max(0, 1000.0 / 60.0 - 1000 * swatch.ElapsedTime())))
                End If
                elapsed = swatch.Done()
                Application.DoEvents()
            End While
        End Sub

        Sub ProcessTimerActions()
            For i As Integer = 1 To UBound(Game.actions.Timers)
                With Game.actions.Timers(i)
                    If .Enabled Then
                        If .StartTime = 0 Then
                            .StartTime = swatch2.ElapsedTime
                        ElseIf swatch2.ElapsedTime - .StartTime >= .Interval Then
                            Game.set_CurrentTimer(.Name)
                            .StartTime = swatch2.ElapsedTime
                            ActionProcessor.ProcessActions("itic" & i, curTimer)
                            If ChangedLevel Then Exit Sub
                        End If
                    End If
                End With
            Next
        End Sub

        Sub DrawGame()
            Game.Drawing.RelativeToCam = True
            PlatformStudio.PauseAnimations = Paused
            Game.maps(Game.CurMapIndex).Draw(False, AddressOf DrawRestOfLayer)
            DrawAnim()
        End Sub

        Sub DrawRestOfLayer(ByVal CurLayer As Integer)
            'Path tiles
            For i As Integer = 0 To PathTiles.Count - 1
                If PathTiles(i).Layer = CurLayer Then
                    If PathTiles(i).GetTile.Path.Exists Then
                        Game.CurMap.DrawTile((PathTiles(i).X / Game.tileW) + 1, (PathTiles(i).Y / Game.tileH) + 1, CurLayer, PathTiles(i).GetTile, True, , , , , , , PathTiles(i).Flip)
                    End If
                End If
            Next

            'Character
            If CurLayer = Character.Layer Then
                Character.Draw()
            End If

            'Bullet tiles
            For i As Integer = 0 To BulletTiles.Count - 1
                If BulletTiles(i).Layer = CurLayer Then
                    Game.CurMap.DrawTile((BulletTiles(i).X / Game.tileW) + 1, (BulletTiles(i).Y / Game.tileH) + 1, CurLayer, BulletTiles(i).Tile, True, , , , , False)
                End If
            Next
        End Sub

        ReadOnly Property TimeElapsed() As Double
            Get
                If elapsed = 0 Then
                    Return 0.01 '100 fps default
                ElseIf elapsed > 0.05 Then
                    Return 0.05 'min. 20 fps
                Else
                    Return elapsed  'Return 1 / fps 'ticks * 0.001 is not accurate enough
                End If
            End Get
        End Property
    End Module
End Namespace