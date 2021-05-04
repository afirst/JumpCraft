Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer
Imports System.Collections.Generic

Namespace GamePlayer
    Public Module Loader
        Public ScriptDLL As psDLL
        Public Triggers As SortedList
        Public PathTiles As New List(Of TilePtr) '1-dimensional tile index
        Public CharTex As Integer
        Public LevelText As String

        Sub Load()
            '        MsgBox("Starting up")

            RenderingWindow = False

            'Start loading
            Cursor.Current = Cursors.WaitCursor

            Client.SetupGameObject()

            'Load the script DLL
            LoadDLL()
            If f.RequestedClose Then Return

            'Get any other data and store it for instant use
            InitGame()
            If f.RequestedClose Then Return

            'Show the main window
            If SkipWindows Then
                Game.CurWinIndex = GameWindow
            Else
                Game.CurWinIndex = 1
            End If

            'Done loading
            Cursor.Current = Cursors.Default
            Client.BeginRendering()
        End Sub

        Sub LoadDLL()
            ScriptDLL = New psDLL
            ScriptDLL.LoadDLL(DLLFilename, "Script", "ScriptObject")

            Try
                ScriptDLL.CallSetProperty("Game", Game.PresetActions)
            Catch ex As Exception
                Client.ShowError(GetString("actionProc_ErrorType"), GetString("actionProc_LoadScriptDesc"), GetString("actionProc_GameObjectDoesntExistError") & "\nPublic Game As PlatformStudio.IGame", True, False)
                If f.RequestedClose Then Return
            End Try
            Try
                For i As Integer = 1 To UBound(Game.windows.Windows)
                    For j As Integer = 1 To Game.windows.Windows(i).NumCtrls
                        ScriptDLL.CallSetProperty(Game.windows.Windows(i).Controls(j).Name, Game.windows.Windows(i).Controls(j))
                    Next
                Next
            Catch ex As Exception
                Client.ShowError(GetString("actionProc_ErrorType"), GetString("actionProc_LoadScriptDesc"), GetString("actionProc_CouldNotInitVarsError"), True, False)
                If f.RequestedClose Then Return
            End Try

            'Init trigger list
            Triggers = New SortedList
            For i As Integer = 1 To UBound(Game.actions.Actions)
                If Triggers.ContainsKey(Game.actions.Actions(i).Trigger) = False Then
                    Triggers.Add(Game.actions.Actions(i).Trigger, i)
                End If
            Next
        End Sub

        Sub InitGame()
            'Reset application data
            '----------------------
            StartedNewGame = False
            tmpMaps = Nothing
            tmpActions = Nothing

            'Find the window containing the game
            '-----------------------------------
            Dim i As Integer, j As Integer
            For i = 1 To Game.numWindows
                For j = 1 To Game.windows.Windows(i).NumCtrls
                    If Game.windows.Windows(i).Controls(j).Type = PlatformStudio.psUI.psControl.psCtrlType.GameArea Then
                        GameWindow = i
                        GameCtl = Game.windows.Windows(i).Controls(j)
                        GoTo DoneFindGameWindow
                    End If
                Next
            Next
DoneFindGameWindow:

            'Find the window containing the high scores control
            '--------------------------------------------------
            For i = 1 To Game.numWindows
                For j = 1 To Game.windows.Windows(i).NumCtrls
                    If Game.windows.Windows(i).Controls(j).Type = PlatformStudio.psUI.psControl.psCtrlType.HighScoresArea Then
                        hsWindow = i
                        hsCtrl = j
                        HighScoreCtrl = Game.windows.Windows(i).Controls(j)
                        GoTo DoneFindHighScoresArea
                    End If
                Next
            Next
DoneFindHighScoresArea:
            If hsWindow > 0 Then Client.LoadHighScores()
            'If hsWindow > 0 Then Client.LoadHighScores() '??? why again?

            'Find the win window, the lose window, and the
            'level complete windows
            '---------------------------------------------
            ReDim LevelCompleteWindow(Game.numMaps)
            For i = 1 To Game.numWindows
                If MatchAny(Game.windows.Windows(i).Name, "windows_PauseWindow") Then
                    PauseWindow = i
                ElseIf MatchAny(Game.windows.Windows(i).Name, "windows_WinWindow") Then
                    WinWindow = i
                ElseIf MatchAny(Game.windows.Windows(i).Name, "windows_LoseWindow") Then
                    LoseWindow = i
                ElseIf MatchAny(Game.windows.Windows(i).Name, "windows_HelpWindow") Then
                    HelpWindow = i
                ElseIf MatchAny(Game.windows.Windows(i).Name, "windows_AboutWindow") Then
                    AboutWindow = i
                ElseIf MatchAny(Game.windows.Windows(i).Name, "windows_LevelCompletedWindow") Then
                    For j = 1 To Game.numMaps
                        If LevelCompleteWindow(j) = 0 Then LevelCompleteWindow(j) = i
                    Next
                Else
                    For j = 1 To Game.numMaps
                        If MatchAny(Game.windows.Windows(i).Name, String.Format("windows_LevelXCompletedWindow", Game.maps(j).MapName)) Then
                            LevelCompleteWindow(j) = i
                            Exit For
                        End If
                    Next
                End If
            Next

            'Find the Help file
            '------------------
            For i = 1 To Game.windows.Windows(HelpWindow).NumCtrls
                If Game.windows.Windows(HelpWindow).Controls(i).Type = PlatformStudio.psUI.psControl.psCtrlType.Button AndAlso MatchAny(Game.windows.Windows(HelpWindow).Controls(i).Text, "windows_HelpButtonText") Then
                    For j = 1 To UBound(Game.actions.Actions)
                        If Game.actions.Actions(j).Action.Behavior.Name = "Open File" Then
                            HelpFile = Game.actions.Actions(j).Action.param(1)
                        End If
                    Next
                    GoTo BreakForI
                End If
            Next
BreakForI:

            'Store the character bounds for each frame
            '-----------------------------------------
            '1. Find the character tile
            Dim CharTile As psTile
            For i = 1 To Game.tileset.NumTiles
                If Game.tileset.tiles(i).behavior = psTile.TileBehavior.Character Then
                    CharTex = i
                    CharTile = Game.tileset.tiles(CharTex)
                    Exit For
                End If
            Next

            '(No character tile exists = Error)
            If Game.tileset.NumTiles = 0 Then
                Client.ShowError(GetString("tilesetError"), GetString("tilesetErrorOccurredWhileLoadingGame"), GetString("tilesetErrorNoTiles"))
                If f.RequestedClose Then Return
            End If
            If CharTex = 0 Then
                If Client.ShowError(GetString("tilesetError"), GetString("tilesetErrorOccuredWhileFindingCharacterTile"), GetString("tilesetErrorNoCharacter"), True, False) = DialogResult.Retry Then
                    CharTex = 1
                    CharTile = Game.tileset.tiles(CharTex)
                End If
                If f.RequestedClose Then Return
            End If

            '2. Find the bounds of each frame
            Dim Frames As Integer = (CharTile.width \ CharTile.sectionw) * (CharTile.height \ CharTile.sectionh)
            Dim FrameRect As Rectangle
            Dim CharBits(,,) As Byte
            Dim x As Integer, y As Integer
            ReDim psCharacter.CharBounds(Frames)
            CharBits = Game.Drawing.img_ForceGetBits(CharTile.name)
            For i = 1 To Frames
                FrameRect = PlatformStudio.CurRect(CharTile, i)
                psCharacter.CharBounds(i) = FindBounds(CharTex, FrameRect, CharBits)
            Next
            Dim avgY As Integer, avgH As Integer
            Dim total As Integer
            For i = 1 To Frames
                If psCharacter.CharBounds(i).Width > 0 Then
                    avgY += psCharacter.CharBounds(i).Y
                    avgH += psCharacter.CharBounds(i).Height
                    total += 1
                End If
            Next
            avgY = Math.Round(avgY / total)
            avgH = Math.Round(avgH / total)
            For i = 1 To Frames
                psCharacter.CharBounds(i).Y = avgY
                psCharacter.CharBounds(i).Height = avgH
            Next
            'If CharBounds(i).Bottom < MaxBottom Then
            '    CharBounds(i).Y = MaxBottom - CharBounds(i).Y
            'End If6

            'Find the bounds for animated tiles
            '----------------------------------
            Dim Bounds() As Rectangle
            ReDim Bounds(Game.tileset.NumTiles)
            For i = 1 To Game.tileset.NumTiles
                If Game.tileset.tiles(i).Boundaries.Style = BoundaryType.Default Then
                    Game.tileset.tiles(i).Boundaries.Style = BoundaryType.Rectangular
                    'If Game.tileset.tiles(i).Anim(0).Interval > 0 And Game.tileset.tiles(i).behavior = psTile.TileBehavior.Solid Then
                    '    'Animated solid tile
                    '    '
                    '    'Store the bits
                    '    Dim Bits(,,) As Byte = Game.Drawing.img_GetBits(Game.tileset.tileName(i))

                    '    'Get the amount of frames
                    '    Dim numFrames As Integer = (Game.tileset.tileWidth(i) \ Game.tileset.tileSecW(i)) * (Game.tileset.tileHeight(i) \ Game.tileset.tileSecH(i))

                    '    'Loop through all the frames
                    '    For j = 1 To numFrames

                    '        'Calculate the frame rectangle
                    '        Dim rectFrame As Rectangle = CurRect(Game.tileset.tiles(i), j)

                    '        'Calculate the boundaries for the rectangle
                    '        Bounds(i) = FindBounds(j, rectFrame, Bits)
                    '        If Bounds(i).X = 32767 Then numFrames -= 1
                    '    Next

                    '    'Find the average bounds
                    '    Dim AvgRect As Rectangle
                    '    For j = 1 To UBound(Bounds)
                    '        If Bounds(j).X < 32767 Then
                    '            AvgRect.X += Bounds(j).X
                    '            AvgRect.Y += Bounds(j).Y
                    '            AvgRect.Width += Bounds(j).Width
                    '            AvgRect.Height += Bounds(j).Height
                    '        End If
                    '    Next
                    '    AvgRect.X /= numFrames
                    '    AvgRect.Y /= numFrames
                    '    AvgRect.Width /= numFrames
                    '    AvgRect.Height /= numFrames

                    '    'Loop through all the frames
                    '    For j = 1 To numFrames

                    '        'Calculate the frame rectangle
                    '        Dim rectFrame As Rectangle = CurRect(Game.tileset.tiles(i), j)

                    '        'Modify the bits to ensure bounding box collision
                    '        'is performed instead of pixel-perfect collision
                    '        'so no strange collision glitches will occur.
                    '        For x = rectFrame.Left + AvgRect.Left To Math.Min(rectFrame.Left + AvgRect.Left + AvgRect.Width - 1, UBound(Bits, 1))
                    '            For y = rectFrame.Top + AvgRect.Top To Math.Min(rectFrame.Top + AvgRect.Top + AvgRect.Height - 1, UBound(Bits, 2))
                    '                If Bits(x, y, 0) = 0 Then Bits(x, y, 0) = 1
                    '            Next
                    '        Next
                    '    Next

                    '    'Copy the bits back to the tile
                    '    Game.Drawing.img_SetBits(Game.tileset.tileName(i), Bits)
                    'End If
                End If
            Next

            'Setup bits for ledge tiles
            '--------------------------
            For i = 1 To Game.tileset.NumTiles
                If Game.tileset.tiles(i).behavior = psTile.TileBehavior.Ledge Then
                    Game.tileset.tiles(i).Boundaries.Style = BoundaryType.Default
                    Game.Drawing.img_ForceGetBits((Game.tileset.tiles(i).name))
                    With Game.Drawing.Tex(Game.tileset.tiles(i).name)
                        For x_ As Integer = 0 To .width - .sectionw Step .sectionw
                            For y_ As Integer = 0 To .height - .sectionh Step .sectionh
                                Dim FoundTopY As Boolean
                                For x = 0 To .sectionw - 1 'UBound(.Bits, 1)
                                    FoundTopY = False
                                    For y = 0 To .sectionh - 1 'UBound(.Bits, 2)
                                        If FoundTopY Then
                                            .Bits(x_ + x, y_ + y, 0) = 0
                                        ElseIf .Bits(x_ + x, y_ + y, 0) > 0 Then
                                            FoundTopY = True
                                        End If
                                    Next
                                Next
                            Next
                        Next
                    End With
                End If
            Next
        End Sub

        Private Function FindBounds(ByVal Tile As Integer, ByVal FrameRect As Rectangle, ByVal Bits(,,) As Byte) As Rectangle
            If Bits Is Nothing Then
                Return New Rectangle(0, 0, FrameRect.Width, FrameRect.Height)
            End If
            Dim tmpRect As Rectangle
            tmpRect = New Rectangle(32767, 32767, 0, 0)
            Dim tmpRight As Integer, tmpBottom As Integer
            For x As Integer = FrameRect.Left To FrameRect.Right - 1
                For y As Integer = FrameRect.Top To FrameRect.Bottom - 1
                    If x < Bits.GetUpperBound(0) AndAlso y < Bits.GetUpperBound(1) AndAlso Bits(x, y, 0) > 0 Then
                        If tmpRect.X > x - FrameRect.Left Then
                            tmpRect.X = x - FrameRect.Left
                        End If
                        If tmpRect.Y > y - FrameRect.Top Then
                            tmpRect.Y = y - FrameRect.Top
                        End If
                        If tmpRight < x - FrameRect.Left Then
                            tmpRight = x - FrameRect.Left
                        End If
                        If tmpBottom < y - FrameRect.Top Then
                            tmpBottom = y - FrameRect.Top
                        End If
                        'If tmpRect.Bottom > MaxBottom Then MaxBottom = tmpRect.Bottom
                    End If
                Next
            Next
            tmpRect.Width = tmpRight - tmpRect.Left
            tmpRect.Height = tmpBottom - tmpRect.Top
            Return tmpRect
        End Function

        Public StartedNewGame As Boolean
        Dim tmpMaps() As psMap, tmpActions As psActions
        Public NoCounterActions As Boolean
        Sub NewGame()
            CurHighScore = 0

            'Reset game
            NoCounterActions = True
            If Not IsNothing(tmpMaps) Then
                Game.actions = tmpActions.Clone
                Game.maps = tmpMaps.Clone
                tmpActions = Nothing
                Erase tmpMaps
                tmpMaps = Nothing
            End If
            Character = New psCharacter
            Character.AffectedByGravity = True

            'Store current game state so the game
            'can be reset when the user wants
            'to start a new game later.
            tmpMaps = Game.CloneMaps
            tmpActions = Game.actions.Clone
            NoCounterActions = False

            'Load the first level
            LoadLevel(StartAtLevel)
            If f.RequestedClose Then Return
            StartedNewGame = True

            ActionProcessor.ProcessActions("nbgm")
        End Sub

        Public JustLoadedLevel As Boolean

        Sub LoadLevel(ByVal Level As Integer)
            Dim tmp As Boolean = Paused
            Paused = True

            ReDim Anim(0)
            PathTiles.Clear()
            DropTiles.Clear()
            BulletTiles.Clear()

            'Find character
            Game.CurMapIndex = Level
            Dim NoChar As Boolean = True
            Dim i As Integer, j As Integer
            For i = 1 To 3
                For j = 1 To Game.CurMap.MapSize1D
                    If Game.tileset.tiles(Game.CurMap.Cells1D2(j, i).tile).behavior = psTile.TileBehavior.Character Then
                        With Character
                            .SetMapTileLocation(i, j)
                        End With
                        NoChar = False
                        Exit For
                    End If
                Next
                If NoChar = False Then Exit For
            Next
            If NoChar Then
                If Client.ShowError(GetString("levelError"), GetString("levelErrorOccurredWhileLoadingLevel"), String.Format(GetString("levelErrorNoCharacter"), Game.CurMap.MapName), True, False) = DialogResult.Retry Then
                    Character.SetMapTileLocation(2, 1)
                End If
            End If

            For n As Byte = 1 To 3
                For i = 1 To Game.CurMap.MapSize1D
                    'Find all tiles with a path
                    If Game.CurMap.Cells1D2(i, n).Path.Exists Then
                        'Add entry to path list
                        PathTiles.Add(New TilePtr(i, n))
                        ResetFallenTiles()
                    End If

                    'Reset hitpoints
                    Dim tmpTile As psMapTile = Game.CurMap.Cells1D2(i, n)
                    tmpTile.HitPoints = Game.tileset.tiles(Game.CurMap.Cells1D(i, n)).HitPoints
                    If tmpTile.HitPoints > 0 Then Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmpTile
                Next
            Next

            'Play background music
            Game.Audio.PlayMusic(Game.CurMap.Music, Game.CurMap.Volume)

            FirstFrame = True

            LevelText = Format(Level, "00000")
            JustLoadedLevel = True

            Paused = tmp

            ActionProcessor.ProcessActions("nblv")
            ActionProcessor.ProcessActions("nblv" & LevelText & "_")
        End Sub

        Sub ResetFallenTiles()
            DropTiles.Clear()
            BulletTiles.Clear()
            ReDim Anim(0)
            For n As Byte = 1 To 3
                For i As Integer = 1 To Game.CurMap.MapSize1D
                    If Game.CurMap.Cells1D2(i, n).Path.Exists Then
                        If UBound(Game.CurMap.Cells1D2(i, n).Path.Pts) > 0 Then
                            If UBound(Game.CurMap.Cells1D2(i, n).Path.Pts) > 0 AndAlso Game.CurMap.Cells1D2(i, n).Path.Pts(1).Length < 0 Then
                                Dim tmp As psMapTile
                                tmp = Game.maps(Game.CurMapIndex).Cells1D2(i, n)
                                Dim tmpPath As psPath = tmp.Path
                                With tmpPath
                                    .Exists = False
                                    .Speed = 0
                                    ReDim .Pts(0)
                                    '.Pts(1).Length = Math.Sqrt((.Pts(0).XPoint(0) - .Pts(1).XPoint(0)) ^ 2 + (.Pts(0).YPoint(0) - .Pts(1).YPoint(0)) ^ 2)
                                End With
                                tmp.Path = tmpPath
                                tmp.PathX = 0
                                tmp.PathY = 0
                                tmp.Invisible = False
                                Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmp
                            End If
                        End If
                    ElseIf Game.CurMap.Cells1D2(i, n).Invisible Then
                        Dim tmp As psMapTile
                        tmp = Game.maps(Game.CurMapIndex).Cells1D2(i, n)
                        tmp.Invisible = False
                        Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmp
                    End If
                Next
            Next
        End Sub

        Sub SetupWindow()
            With Game.GameProperties
                If .Windowed Then
                    f.Size = New Size(.ResWidth, .ResHeight)
                    f.Text = Client.WindowText
                    If .Menus Then
                        f.MenuItem10.Visible = .mnuSupport
                        f.MenuItem11.Visible = .mnuWebsite
                        f.MenuItem9.Visible = .mnuAbout
                        If (.mnuSupport = False And .mnuWebsite = False) Or (.mnuAbout = False) Then f.MenuItem12.Visible = False
                        If (.mnuSupport = False And .mnuWebsite = False And .mnuAbout = False) Then f.MenuItem8.Visible = False
                        f.MenuItem1.Visible = True
                        f.MenuItem2.Visible = True
                    End If
                    f.p.Size = f.Size
                    f.Size = New Size(f.Size.Width + .ResWidth - f.p.Width, f.Size.Height + .ResHeight - f.p.Height)
                    With Screen.PrimaryScreen.Bounds
                        f.Location = New Point((.Width - f.Width) / 2, (.Height - f.Height) / 2)
                    End With
                    f.p.Visible = False
                Else
                    f.FormBorderStyle = FormBorderStyle.None
                    f.Size = New Size(.ResWidth, .ResHeight)
                    f.Size = New Size(f.Size.Width + .ResWidth - f.p.Width, f.Size.Height + .ResHeight - f.p.Height)
                    f.Text = Client.WindowText
                    f.p.Visible = False
                End If
                f.p.Dock = DockStyle.None
                f.p.Location = New Point(0, 0)
            End With
        End Sub
    End Module
End Namespace