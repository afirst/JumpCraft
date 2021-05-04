Imports PlatformStudio
Imports System.Math
Imports PlatformStudio.psMap.psLayer

Namespace GamePlayer
    Public Module ActionProcessor

        Public PlayingMovie As Boolean
        Public ClickToSkipMovie As Boolean
        Public SkipMovie As Boolean

#Region "Processor"
        Sub ProcessActions(ByVal Trigger As String, ByVal ParamArray Args() As Object)
            ProcessActions2(Trigger, Args)
        End Sub

        Sub ProcessActions2(ByVal Trigger As String, ByVal Args() As Object)
            If Triggers Is Nothing Then Exit Sub
            If Triggers.ContainsKey(Trigger) Then
                If (Trigger.StartsWith("thit")) Then
                    'Dim x = 5
                End If
                Try
                    Game.Drawing.RelativeToCam = False
                    Game.Drawing.IgnoreOffsets = True
                    ScriptDLL.CallMethod(Trigger, Args)
                Catch ex As Exception
                    Dim errMsg As String = String.Format(GetString("actionProc_Error"), Trigger)
                    If Not ex.InnerException Is Nothing Then errMsg &= vbCrLf & vbCrLf & GetString("actionProc_ErrorMessage") & " " & ex.InnerException.Message
                    If Client.ShowError(GetString("actionProc_ErrorType"), GetString("actionProc_Description"), errMsg, True, True) = DialogResult.Ignore Then
                        Triggers.Remove(Trigger) 'Ignore all
                    End If
                End Try
            End If
        End Sub
#End Region

        Public ChangedLevel As Boolean

#Region "Presets"
        Class ExecuteTrigger
            Inherits MarshalByRefObject
            Implements IExecuteTrigger
            Sub Always() Implements IExecuteTrigger.Always
                ActionProcessor.ProcessActions("aalw")
            End Sub
            Sub CounterValueChanged(ByVal CounterName As String) Implements IExecuteTrigger.CounterValueChanged
                ActionProcessor.ProcessActions("cval" & GetCounter(CounterName), New CurrentCounter)
            End Sub
            Sub CounterValueChanged(ByVal CounterIndex As Integer) Implements IExecuteTrigger.CounterValueChanged
                ActionProcessor.ProcessActions("cval" & CounterIndex, New CurrentCounter)
            End Sub
            Sub TimerTick(ByVal TimerName As String) Implements IExecuteTrigger.TimerTick
                ActionProcessor.ProcessActions("itic" & GetTimer(TimerName), New CurrentTimer)
            End Sub
            Sub TimerTick(ByVal TimerIndex As Integer) Implements IExecuteTrigger.TimerTick
                ActionProcessor.ProcessActions("itic" & TimerIndex, New CurrentTimer)
            End Sub
            Sub GroupHit(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHit
                ActionProcessor.ProcessActions("ghit" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHit() Implements IExecuteTrigger.GroupHit
                ActionProcessor.ProcessActions("ghit" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupHitLeft(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHitLeft
                ActionProcessor.ProcessActions("glef" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHitLeft() Implements IExecuteTrigger.GroupHitLeft
                ActionProcessor.ProcessActions("glef" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupHitRight(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHitRight
                ActionProcessor.ProcessActions("grig" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHitRight() Implements IExecuteTrigger.GroupHitRight
                ActionProcessor.ProcessActions("grig" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupHitTop(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHitTop
                ActionProcessor.ProcessActions("gtop" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHitTop() Implements IExecuteTrigger.GroupHitTop
                ActionProcessor.ProcessActions("gtop" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupHitBottom(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHitBottom
                ActionProcessor.ProcessActions("gbot" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHitBottom() Implements IExecuteTrigger.GroupHitBottom
                ActionProcessor.ProcessActions("gbot" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupExclusivelyOnTop(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupExclusivelyOnTop
                ActionProcessor.ProcessActions("gexc" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupExclusivelyOnTop() Implements IExecuteTrigger.GroupExclusivelyOnTop
                ActionProcessor.ProcessActions("gexc" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupCollect(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupCollect
                ActionProcessor.ProcessActions("gcol" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupCollect() Implements IExecuteTrigger.GroupCollect
                ActionProcessor.ProcessActions("gcol" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupShot(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupShot
                ActionProcessor.ProcessActions("gsho" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupShot() Implements IExecuteTrigger.GroupShot
                ActionProcessor.ProcessActions("gsho" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupDestroyed(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupDestroyed
                ActionProcessor.ProcessActions("gdes" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupDestroyed() Implements IExecuteTrigger.GroupDestroyed
                ActionProcessor.ProcessActions("gdes" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupChangeDirections(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupChangeDirections
                ActionProcessor.ProcessActions("gcha" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupChangeDirections() Implements IExecuteTrigger.GroupChangeDirections
                ActionProcessor.ProcessActions("gcha" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupChangeDirectionsFwd(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupChangeDirectionsFwd
                ActionProcessor.ProcessActions("gctf" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupChangeDirectionsFwd() Implements IExecuteTrigger.GroupChangeDirectionsFwd
                ActionProcessor.ProcessActions("gctb" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupChangeDirectionsBkwd(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupChangeDirectionsBkwd
                ActionProcessor.ProcessActions("gctb" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupChangeDirectionsBkwd() Implements IExecuteTrigger.GroupChangeDirectionsBkwd
                ActionProcessor.ProcessActions("gctb" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupHover(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupHover
                ActionProcessor.ProcessActions("ghov" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupHover() Implements IExecuteTrigger.GroupHover
                ActionProcessor.ProcessActions("ghov" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub GroupClick(ByVal Level As Integer, ByVal GroupName As String) Implements IExecuteTrigger.GroupClick
                ActionProcessor.ProcessActions("gcli" & Format(Level, "00000") & GroupName, New CurrentGroup)
            End Sub
            Sub GroupClick() Implements IExecuteTrigger.GroupClick
                ActionProcessor.ProcessActions("gcli" & Format(Game.CurMapIndex, "00000") & curGroup.Name, curGroup)
            End Sub
            Sub TileHit(ByVal TileName As String) Implements IExecuteTrigger.TileHit
                ActionProcessor.ProcessActions("thit" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHit(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHit
                ActionProcessor.ProcessActions("thit" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHit() Implements IExecuteTrigger.TileHit
                ActionProcessor.ProcessActions("thit" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileHitLeft(ByVal TileName As String) Implements IExecuteTrigger.TileHitLeft
                ActionProcessor.ProcessActions("tlef" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHitLeft(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHitLeft
                ActionProcessor.ProcessActions("tlef" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHitLeft() Implements IExecuteTrigger.TileHitLeft
                ActionProcessor.ProcessActions("tlef" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileHitRight(ByVal TileName As String) Implements IExecuteTrigger.TileHitRight
                ActionProcessor.ProcessActions("trig" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHitRight(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHitRight
                ActionProcessor.ProcessActions("trig" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHitRight() Implements IExecuteTrigger.TileHitRight
                ActionProcessor.ProcessActions("trig" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileHitTop(ByVal TileName As String) Implements IExecuteTrigger.TileHitTop
                ActionProcessor.ProcessActions("ttop" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHitTop(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHitTop
                ActionProcessor.ProcessActions("ttop" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHitTop() Implements IExecuteTrigger.TileHitTop
                ActionProcessor.ProcessActions("ttop" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileHitBottom(ByVal TileName As String) Implements IExecuteTrigger.TileHitBottom
                ActionProcessor.ProcessActions("tbot" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHitBottom(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHitBottom
                ActionProcessor.ProcessActions("tbot" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHitBottom() Implements IExecuteTrigger.TileHitBottom
                ActionProcessor.ProcessActions("tbot" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileExclusivelyOnTop(ByVal TileName As String) Implements IExecuteTrigger.TileExclusivelyOnTop
                ActionProcessor.ProcessActions("texc" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileExclusivelyOnTop(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileExclusivelyOnTop
                ActionProcessor.ProcessActions("texc" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileExclusivelyOnTop() Implements IExecuteTrigger.TileExclusivelyOnTop
                ActionProcessor.ProcessActions("texc" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileCollect(ByVal TileName As String) Implements IExecuteTrigger.TileCollect
                ActionProcessor.ProcessActions("tcol" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileCollect(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileCollect
                ActionProcessor.ProcessActions("tcol" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileCollect() Implements IExecuteTrigger.TileCollect
                ActionProcessor.ProcessActions("tcol" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileShot(ByVal TileName As String) Implements IExecuteTrigger.TileShot
                ActionProcessor.ProcessActions("tsho" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileShot(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileShot
                ActionProcessor.ProcessActions("tsho" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileShot() Implements IExecuteTrigger.TileShot
                ActionProcessor.ProcessActions("tsho" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileDestroyed(ByVal TileName As String) Implements IExecuteTrigger.TileDestroyed
                ActionProcessor.ProcessActions("tdes" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileDestroyed(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileDestroyed
                ActionProcessor.ProcessActions("tdes" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileDestroyed() Implements IExecuteTrigger.TileDestroyed
                ActionProcessor.ProcessActions("tdes" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileChangeDirections(ByVal TileName As String) Implements IExecuteTrigger.TileChangeDirections
                ActionProcessor.ProcessActions("tcha" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileChangeDirections(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileChangeDirections
                ActionProcessor.ProcessActions("tcha" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileChangeDirections() Implements IExecuteTrigger.TileChangeDirections
                ActionProcessor.ProcessActions("tcha" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileChangeDirectionsFwd(ByVal TileName As String) Implements IExecuteTrigger.TileChangeDirectionsFwd
                ActionProcessor.ProcessActions("tctf" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileChangeDirectionsFwd(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileChangeDirectionsFwd
                ActionProcessor.ProcessActions("tctf" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileChangeDirectionsFwd() Implements IExecuteTrigger.TileChangeDirectionsFwd
                ActionProcessor.ProcessActions("tctf" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileChangeDirectionsBkwd(ByVal TileName As String) Implements IExecuteTrigger.TileChangeDirectionsBkwd
                ActionProcessor.ProcessActions("tctb" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileChangeDirectionsBkwd(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileChangeDirectionsBkwd
                ActionProcessor.ProcessActions("tctb" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileChangeDirectionsBkwd() Implements IExecuteTrigger.TileChangeDirectionsBkwd
                ActionProcessor.ProcessActions("tctb" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileHover(ByVal TileName As String) Implements IExecuteTrigger.TileHover
                ActionProcessor.ProcessActions("thov" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileHover(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileHover
                ActionProcessor.ProcessActions("thov" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileHover() Implements IExecuteTrigger.TileHover
                ActionProcessor.ProcessActions("thov" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub TileClick(ByVal TileName As String) Implements IExecuteTrigger.TileClick
                ActionProcessor.ProcessActions("tcli" & GetTile(TileName), New CurrentGroup)
            End Sub
            Sub TileClick(ByVal TileIndex As Integer) Implements IExecuteTrigger.TileClick
                ActionProcessor.ProcessActions("tcli" & TileIndex, New CurrentGroup)
            End Sub
            Sub TileClick() Implements IExecuteTrigger.TileClick
                ActionProcessor.ProcessActions("tcli" & CurTile.GetTile.tile, curGroup)
            End Sub
            Sub LocationEnter(ByVal Level As Integer, ByVal LocationName As String) Implements IExecuteTrigger.LocationEnter
                ActionProcessor.ProcessActions("lent" & Format(Level, "00000") & LocationName)
            End Sub
            Sub LocationExit(ByVal Level As Integer, ByVal LocationName As String) Implements IExecuteTrigger.LocationExit
                ActionProcessor.ProcessActions("lexi" & Format(Level, "00000") & LocationName)
            End Sub
            Sub LocationInside(ByVal Level As Integer, ByVal LocationName As String) Implements IExecuteTrigger.LocationInside
                ActionProcessor.ProcessActions("lins" & Format(Level, "00000") & LocationName)
            End Sub
            Sub KeyboardPressKey(ByVal KeyCode As Integer) Implements IExecuteTrigger.KeyboardPressKey
                ActionProcessor.ProcessActions("kpre" & KeyCode)
            End Sub
            Sub KeyboardReleaseKey(ByVal KeyCode As Integer) Implements IExecuteTrigger.KeyboardReleaseKey
                ActionProcessor.ProcessActions("krel" & KeyCode)
            End Sub
            Sub KeyboardHoldKey(ByVal KeyCode As Integer) Implements IExecuteTrigger.KeyboardHoldKey
                ActionProcessor.ProcessActions("khol" & KeyCode)
            End Sub
            Sub MouseLeftButtonPress() Implements IExecuteTrigger.MouseLeftButtonPress
                ActionProcessor.ProcessActions("mlpr")
            End Sub
            Sub MouseLeftButtonRelease() Implements IExecuteTrigger.MouseLeftButtonRelease
                ActionProcessor.ProcessActions("mlre")
            End Sub
            Sub MouseLeftButtonHold() Implements IExecuteTrigger.MouseLeftButtonHold
                ActionProcessor.ProcessActions("mlho")
            End Sub
            Sub MouseRightButtonPress() Implements IExecuteTrigger.MouseRightButtonPress
                ActionProcessor.ProcessActions("mrpr")
            End Sub
            Sub MouseRightButtonRelease() Implements IExecuteTrigger.MouseRightButtonRelease
                ActionProcessor.ProcessActions("mrre")
            End Sub
            Sub MouseRightButtonHold() Implements IExecuteTrigger.MouseRightButtonHold
                ActionProcessor.ProcessActions("mrho")
            End Sub
            Sub MouseMiddleButtonPress() Implements IExecuteTrigger.MouseMiddleButtonPress
                ActionProcessor.ProcessActions("mmpr")
            End Sub
            Sub MouseMiddleButtonRelease() Implements IExecuteTrigger.MouseMiddleButtonRelease
                ActionProcessor.ProcessActions("mmre")
            End Sub
            Sub MouseMiddleButtonHold() Implements IExecuteTrigger.MouseMiddleButtonHold
                ActionProcessor.ProcessActions("mmho")
            End Sub
            Sub MouseMove() Implements IExecuteTrigger.MouseMove
                ActionProcessor.ProcessActions("mmov")
            End Sub
            Sub GeneralBeginGame() Implements IExecuteTrigger.GeneralBeginGame
                ActionProcessor.ProcessActions("nbgm")
            End Sub
            Sub GeneralBeginLevel() Implements IExecuteTrigger.GeneralBeginLevel
                ActionProcessor.ProcessActions("nblv")
            End Sub
            Sub GeneralBeginLevel(ByVal Level As Integer) Implements IExecuteTrigger.GeneralBeginLevel
                ActionProcessor.ProcessActions("nblv" & Format(Level, "00000") & "_")
            End Sub
            Sub CharJump() Implements IExecuteTrigger.CharJump
                ActionProcessor.ProcessActions("hjum")
            End Sub
            Sub CharHitHeadWhileJumping() Implements IExecuteTrigger.CharHitHeadWhileJumping
                ActionProcessor.ProcessActions("hstj")
            End Sub
            Sub CharFall() Implements IExecuteTrigger.CharFall
                ActionProcessor.ProcessActions("hfal")
            End Sub
            Sub CharLand() Implements IExecuteTrigger.CharLand
                ActionProcessor.ProcessActions("hlan")
            End Sub

            Private Function GetTile(ByVal TileName As String) As Integer
                For i As Integer = 1 To Game.tileset.NumTiles
                    If Game.tileset.tiles(i).name = TileName Then Return i
                Next
            End Function
        End Class

        Class PresetActions
            Inherits MarshalByRefObject
            Implements IGame
            Sub Jump(ByVal Length As Single, ByVal MinLength As Single, ByVal ScaleSpeed As Single) Implements IGame.Jump
                Character.Jump(Length, MinLength, ScaleSpeed)
            End Sub
            Sub StopJumping() Implements IGame.StopJumping
                Character.JumpStop()
            End Sub
            Sub ModifyCounter(ByVal Counter As String, ByVal Value As Double) Implements IGame.ModifyCounter
                Game.actions.Counters(_GetCounter(Counter)).Modify(Value)
            End Sub
            Sub ModifyHealth(ByVal Value As Double) Implements IGame.ModifyHealth
                If Invincible Then Exit Sub
                If Character.Blinking And Value < 0 Then Exit Sub
                Game.actions.Counters(3).Modify(Value)
            End Sub
            Sub ModifyLevel(ByVal Value As Integer) Implements IGame.ModifyLevel
                Game.CurMapIndex += Value
                Character.Wait = True
                Character.WaitStart = 0
                If Game.CurMapIndex > Game.numMaps Then
                    Game.CurMapIndex = Game.numMaps
                    Win()
                Else
                    If LevelCompleteWindow(Game.CurMapIndex) = 0 Then
                        MessageBox.Show(String.Format(GetString("windows_LevelCompletedLabelText"), Game.CurMap.MapName), Game.GameProperties.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Game.CurWinIndex = LevelCompleteWindow(Game.CurMapIndex)
                    End If
                    Loader.LoadLevel(Game.CurMapIndex)
                End If
                For i As Integer = 0 To 255
                    Keys(i) = False
                Next
                ChangedLevel = True
            End Sub
            Sub ModifyLives(ByVal Value As Integer) Implements IGame.ModifyLives
                If Invincible Then Exit Sub
                Game.actions.Counters(2).Modify(Value, False)

                'Set up a die animation now if needed,
                'before the character's location is changed.
                Dim DieAnimation As Animation
                If Value < 0 Then
                    'Setup a die animation
                    If Game.tileset.tiles(CharTex).Anim(3).Interval > 0 Then
                        DieAnimation = New Animation
                        DieAnimation.Init(Character.rawX, Character.rawY, CharTex, Game.tileset.tiles(CharTex).Anim(3).StartFrame, 3, Character.LastFrame)

                        'Key = -1 denotes character is dying
                        DieAnimation.Key = -1

                        'Wait for die animation
                        Character.Wait = True
                    End If
                End If

                'The following is now done with actions:
                'If Game.actions.Counters(2).Value < 0 Then
                '    Lose()
                'End If

                'Perform counter actions
                Game.actions.Counters(2).RaiseModifiedEvent()

                If Value < 0 Then
                    'Do not start counting time for camera movement
                    '(such as from IGame.MoveToCheckpoint which
                    'might be called in Counters(2).RaiseModifiedEvent);
                    '1 denotes die animation is playing
                    Character.WaitStart = 1

                    'Show die animation
                    ReDim Preserve Renderer.Anim(UBound(Renderer.Anim) + 1)
                    Renderer.Anim(UBound(Renderer.Anim)) = DieAnimation
                End If
            End Sub
            Sub ModifyScore(ByVal Value As Double) Implements IGame.ModifyScore
                Game.actions.Counters(1).Modify(Value)
            End Sub
            Sub MoveCharacter(ByVal Direction As String, ByVal Speed As Single, Optional ByVal Walking As Boolean = True) Implements IGame.MoveCharacter
                Select Case Direction
                    Case "Left"
                        Character.WalkMove(-Speed * Game.tileW * TimeElapsed, 0, Walking)
                    Case "Right"
                        Character.WalkMove(Speed * Game.tileW * TimeElapsed, 0, Walking)
                    Case "Up"
                        Character.WalkMove(0, -Speed * Game.tileH * TimeElapsed, Walking)
                    Case "Down"
                        Character.WalkMove(0, Speed * Game.tileH * TimeElapsed, Walking)
                    Case "Current Direction"
                        Direction = Character.CurDirection
                        If Direction = "" Then Exit Sub
                        MoveCharacter(Direction, Speed, Walking)
                End Select
                Character.CurDirection = Direction
            End Sub
            Sub MoveTile(ByVal Group As String, ByVal Direction As String, ByVal Distance As Integer, ByVal Time As Single, Optional ByVal MoveBack As Boolean = True) Implements IGame.MoveTile
                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Exit Sub
                    If CurTile.GetTile.Group = "" Then
                        MoveATile(CurTile.Index, CurTile.Layer, Direction, Distance, Time, MoveBack)
                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group Then
                                MoveATile(i, n, Direction, Distance, Time, MoveBack)
                            End If
                        Next
                    Next
                End If
            End Sub
            Private Sub MoveATile(ByVal i As Integer, ByVal n As Integer, ByVal Direction As String, ByVal Distance As Integer, ByVal Time As Single, Optional ByVal MoveBack As Boolean = True)
                Dim tmp As psMapTile
                tmp = Game.maps(Game.CurMapIndex).Cells1D2(i, n)
                Try
                    If tmp.Path.Pts(1).Length < 0 Then Exit Sub
                Catch
                End Try

                'Find x & y coordinates of tile
                Dim tmpX As Integer, tmpY As Integer
                With Game.CurMap.Conv1DTo2D(i)
                    tmpX = (.X - 1 + 0.5) * Game.tileW 'the + 0.5 is the
                    tmpY = (.Y - 1 + 0.5) * Game.tileH 'center of the tile
                End With

                'Find the end pt.
                Dim endX As Integer, endY As Integer
                Select Case Direction
                    Case "Left"
                        endX = tmpX - Distance * Game.tileW
                        endY = tmpY
                    Case "Right"
                        endX = tmpX + Distance * Game.tileW
                        endY = tmpY
                    Case "Up"
                        endX = tmpX
                        endY = tmpY - Distance * Game.tileH
                    Case "Down"
                        endX = tmpX
                        endY = tmpY + Distance * Game.tileH
                End Select

                'Make a new, simple path
                Dim NewPath As New psPath
                With NewPath
                    'It takes double the time to go roundtrip,
                    'but we are only going one way, so multiply by 2
                    .Exists = True
                    .Speed = Time * 2
                    .Enclosed = False
                    .Start = 0

                    'Make 2 points
                    ReDim .Pts(1)

                    'Setup first point
                    With .Pts(0)
                        .Init()
                        .XPoint(0) = tmpX : .XPoint(1) = tmpX
                        .YPoint(0) = tmpY : .YPoint(1) = tmpY
                        .XPoint(2) = endX : .XPoint(3) = endX
                        .YPoint(2) = endY : .YPoint(3) = endY
                        .Length = Distance
                    End With

                    'Setup second point
                    With .Pts(1)
                        .Init()
                        .XPoint(0) = endX : .XPoint(1) = endX
                        .YPoint(0) = endY : .YPoint(1) = endY

                        'This is used as a tag to say that
                        'when the tile reaches the end of the
                        'path, do not move again, and, if the
                        'user chooses, move back
                        If MoveBack Then
                            .Length = -1
                        Else
                            .Length = -2
                        End If
                    End With
                End With

                tmp.Path = NewPath
                tmp.UpdatedPath(i, n)
                NewPath = Nothing

                Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmp
                tmp = Nothing

                'Make it a path tile
                Dim bAlreadyAPathTiles As Boolean
                For x As Integer = 0 To PathTiles.Count - 1
                    If PathTiles(x).Index = i And PathTiles(x).Layer = n Then
                        bAlreadyAPathTiles = True
                        Exit For
                    End If
                Next
                If bAlreadyAPathTiles = False Then
                    PathTiles.Add(New TilePtr(i, n))
                End If
            End Sub
            Sub PauseGame() Implements IGame.PauseGame
                Game.CurWinIndex = PauseWindow
                Paused = True
                PauseStart = Timer
            End Sub
            Sub PlayMusic(ByVal Filename As String, ByVal Volume As Byte) Implements IGame.PlayMusic
                Game.Audio.PlayMusic(Filename, Volume)
            End Sub
            Sub PlaySound(ByVal Filename As String, ByVal Volume As Byte, ByVal Pan As Short, ByVal Frequency As Byte, Optional ByVal StopOtherSounds As Boolean = False) Implements IGame.PlaySound
                Game.Audio.PlaySound(Filename, Volume, Pan, Frequency)
            End Sub
            Dim Won As Boolean, Lost As Boolean
            Sub QuitGame() Implements IGame.QuitGame
                StartedNewGame = False
                StoppedAtLevel = Game.CurMap.MapName
                Game.CurMapIndex = StartAtLevel
                Game.CurWinIndex = MenuWindow
                ChangedLevel = True
                If Won = False And Lost = False Then Client.AddHighScore()
                Won = False
                Lost = False
            End Sub
            Sub SetCounter(ByVal Counter As String, ByVal Value As Double) Implements IGame.SetCounter
                Game.actions.Counters(_GetCounter(Counter)).Value = Value
            End Sub
            Sub SetGravity(ByVal GravityExists As Boolean, ByVal ScaleSpeed As Single) Implements IGame.SetGravity
                Character.AffectedByGravity = GravityExists
                Character.GravitySpeed = ScaleSpeed
            End Sub
            Sub SetHealth(ByVal Value As Double) Implements IGame.SetHealth
                If Invincible Then Exit Sub
                Game.actions.Counters(3).Value = Value
            End Sub
            Sub SetLevel(ByVal Value As Integer) Implements IGame.SetLevel
                ModifyLevel(Value - Game.CurMapIndex)
            End Sub
            Sub SetLives(ByVal Value As Integer) Implements IGame.SetLives
                If Invincible Then Exit Sub
                Game.actions.Counters(2).Value = Value
            End Sub
            Sub SetPosition(ByVal X As Integer, ByVal Y As Integer) Implements IGame.SetPosition
                For i As Integer = 0 To 255
                    Keys(i) = False
                Next
                Character.Wait = True
                Character.SetPosition(X, Y)
            End Sub
            Sub SetScore(ByVal Value As Double) Implements IGame.SetScore
                Game.actions.Counters(1).Value = Value
            End Sub
            Sub SetTileIndex(ByVal Group As String, Optional ByVal TileName As String = "", Optional ByVal Frame As Integer = -1, Optional ByVal Animation As Integer = -1, Optional ByVal HitPoints As Integer = -1, Optional ByVal ModifyHitpoints As Integer = 0) Implements IGame.SetTileIndex
                Dim TileIndex As Integer = 0
                If TileName = "" Then
                    TileIndex = -1
                Else
                    For i As Integer = 1 To Game.tileset.NumTiles
                        If Game.tileset.tiles(i).name = TileName Then
                            TileIndex = i
                            Exit For
                        End If
                    Next
                End If
                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Exit Sub
                    If CurTile.GetTile.Group = "" Then
                        SetTileIndexForTile(CurTile.Index, CurTile.Layer, TileIndex, Frame, Animation, HitPoints, ModifyHitpoints)
                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group Then
                                SetTileIndexForTile(i, n, TileIndex, Frame, Animation, HitPoints, ModifyHitpoints)
                            End If
                        Next
                    Next
                End If
            End Sub
            Private Sub SetTileIndexForTile(ByVal i As Integer, ByVal n As Integer, ByVal TileIndex As Integer, ByVal Frame As Integer, ByVal Animation As Integer, ByVal HP As Integer, ByVal ModifyHP As Integer)
                Dim tmp As psMapTile
                tmp = Game.maps(Game.CurMapIndex).Cells1D2(i, n)
                If TileIndex > -1 Then tmp.tile = TileIndex
                If Animation > -1 Then
                    If Animation <> tmp.AnimIndex Then
                        tmp.Frame = Game.tileset.tiles(tmp.tile).Anim(Animation).StartFrame
                        tmp.SetAnimStart(Timer)
                        tmp.AnimIndex = Animation
                    End If
                End If

                If (HP >= 0) Then tmp.HitPoints = HP

                If (ModifyHP + tmp.HitPoints < 0) Then
                    tmp.HitPoints = 0
                Else
                    tmp.HitPoints += ModifyHP
                End If

                'Invoke shoot triggers
                If ModifyHP < 0 And Game.tileset.tiles(tmp.tile).HitPoints > 0 Then
                    CurTile = New TilePtr(i, n)
                    SetCurGroup(tmp.Group, CurTile.X, CurTile.Y, CurTile.Width, CurTile.Height, CurTile.GetTile.HitPoints, CurTile.GetTile.Frame, CurTile.GetTile.AnimIndex, CurTile.GetTile.GetTile.name)
                    ActionProcessor.ProcessActions("tsho" & tmp.tile, curGroup)
                    If tmp.Group <> "" Then
                        ActionProcessor.ProcessActions("gsho" & LevelText & tmp.Group, curGroup)
                    End If
                End If

                If Frame > -1 Then tmp.Frame = Frame
                Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmp

                'Check to see if tile is "dead"
                If tmp.HitPoints = 0 And Game.tileset.tiles(tmp.tile).HitPoints > 0 Then
                    CType(Game.PresetActions, PresetActions).kill_Tile(i, n)
                End If

                Character.UpdatedMap()
            End Sub
            Sub Hurt(Optional ByVal ImmunityLength As Single = 4, Optional ByVal VisualEffect As String = "Blink", Optional ByVal EffectCycleLength As Single = 0.25) Implements IGame.Hurt
                Character.Hurt(ImmunityLength, VisualEffect, EffectCycleLength)
            End Sub
            Sub StopAllSounds() Implements IGame.StopAllSounds
                Game.Audio.StopSounds()
            End Sub
            Sub SetCheckpoint() Implements IGame.SetCheckpoint
                SetCheckpoint(Round(Character.x \ Game.tileW) + 1, Round(Character.y \ Game.tileH) + 1)
            End Sub
            Sub SetCheckpoint(ByVal X As Integer, ByVal Y As Integer) Implements IGame.SetCheckpoint
                Character.SetCheckpoint(X, Y)
            End Sub
            Sub MoveToCheckpoint() Implements IGame.MoveToCheckpoint
                For i As Integer = 0 To 255
                    Keys(i) = False
                Next
                Character.MoveToCheckpoint()
            End Sub
            Property CharacterX() As Integer Implements IGame.CharacterX
                Get
                    Return Character.x
                End Get
                Set(ByVal Value As Integer)
                    Character.x = Value
                End Set
            End Property
            Property CharacterY() As Integer Implements IGame.CharacterY
                Get
                    Return Character.y
                End Get
                Set(ByVal Value As Integer)
                    Character.y = Value
                End Set
            End Property
            Sub Win() Implements IGame.Win
                Won = True
                QuitGame()
                If WinWindow = 0 Then
                    MessageBox.Show(GetString("windows_WinLabelText"), Game.GameProperties.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Game.CurWinIndex = WinWindow
                End If
            End Sub
            Sub Lose() Implements IGame.Lose
                Lost = True
                QuitGame()
                If LoseWindow = 0 Then
                    MessageBox.Show(GetString("windows_LoseLabelText"), Game.GameProperties.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Game.CurWinIndex = LoseWindow
                End If
            End Sub
            Sub ShowWindow(ByVal WindowName As String) Implements IGame.ShowWindow
                For i As Integer = 1 To UBound(Game.windows.Windows)
                    If Game.windows.Windows(i).Name = WindowName Then
                        Game.CurWinIndex = i
                        Exit Sub
                    End If
                Next
            End Sub
            Sub DropCurrentTile(ByVal WaitLength As Single, ByVal DropScaleSpeed As Single, Optional ByVal Disappear As Boolean = True) Implements IGame.DropCurrentTile
                For i As Integer = 0 To DropTiles.Count - 1
                    If DropTiles(i).Ptr.Index = CurTile.Index AndAlso _
                    DropTiles(i).Ptr.Layer = CurTile.Layer Then
                        Exit Sub
                    End If
                Next
                Dim dt As New DropTile()
                dt.WaitLength = WaitLength
                dt.Ptr = CurTile
                dt.WaitStart = Timer
                dt.Disappear = Disappear
                dt.DropSpeed = DropScaleSpeed
                dt.Drop = True
                DropTiles.Add(dt)
            End Sub
            Sub SetTileFrame(ByVal Group As String, ByVal Frame As Integer) Implements IGame.SetTileFrame
                SetTileIndex(Group, "", Frame)
            End Sub
            Sub DisintegrateCurrentTile(ByVal WaitLength As Single) Implements IGame.DisintegrateCurrentTile
                For i As Integer = 0 To DropTiles.Count - 1
                    If DropTiles(i).Ptr.Index = CurTile.Index AndAlso _
                    DropTiles(i).Ptr.Layer = CurTile.Layer Then
                        Exit Sub
                    End If
                Next
                Dim dt As New DropTile()
                dt.WaitLength = WaitLength
                dt.Ptr = CurTile
                dt.WaitStart = Timer
                dt.Drop = False
                DropTiles.Add(dt)
            End Sub
            Sub SetClimbingState(ByVal Climbing As Boolean) Implements IGame.SetClimbingState
                Character.Climbing = Climbing
            End Sub
            Function GravityExists() As Boolean Implements IGame.GravityExists
                Return Character.AffectedByGravity
            End Function
            Sub Shoot(ByVal FromTile As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal Accuracy As Integer = 100, Optional ByVal MaxDistance As Double = 1000, Optional ByVal OnlyIfVisible As Boolean = False, Optional ByVal HitEverything As Boolean = False, Optional ByVal Firepower As Integer = 1) Implements IGame.Shoot
                Dim FromIndex As Integer = TileName2Index(FromTile)
                Dim BulletFrame As Integer
                Dim BulletIndex As Integer = TileName2Index(BulletTile, BulletFrame)

                'Search for all tiles with the specified index
                For n As Byte = 1 To 3
                    For i As Integer = 1 To Game.CurMap.MapSize1D
                        If Game.CurMap.Cells1D(i, n) = FromIndex And Game.CurMap.Cells1D2(i, n).Invisible = False Then
                            ShootFromTile(i, n, BulletIndex, BulletFrame, Direction, Speed, Accuracy, MaxDistance, OnlyIfVisible, HitEverything, Firepower)
                        End If
                    Next
                Next
            End Sub
            Sub ShootFromGroup(ByVal Group As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal Accuracy As Integer = 100, Optional ByVal MaxDistance As Double = 1000, Optional ByVal OnlyIfVisible As Boolean = False, Optional ByVal HitEverything As Boolean = False, Optional ByVal Firepower As Integer = 1) Implements IGame.ShootFromGroup
                Dim BulletFrame As Integer
                Dim BulletIndex As Integer = TileName2Index(BulletTile, BulletFrame)
                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Exit Sub
                    If CurTile.GetTile.Group = "" Then
                        ShootFromTile(CurTile.Index, CurTile.Layer, BulletIndex, BulletFrame, Direction, Speed, Accuracy, MaxDistance, OnlyIfVisible, HitEverything, Firepower)
                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group And Game.CurMap.Cells1D2(i, n).Invisible = False Then
                                ShootFromTile(i, n, BulletIndex, BulletFrame, Direction, Speed, Accuracy, MaxDistance, OnlyIfVisible, HitEverything, Firepower)
                            End If
                        Next
                    Next
                End If
            End Sub
            Private Sub ShootFromTile(ByVal index As Integer, ByVal layer As Integer, ByVal BulletIndex As Integer, ByVal BulletFrame As Integer, ByVal Direction As String, ByVal Speed As Single, ByVal Accuracy As Integer, ByVal MaxDistance As Integer, ByVal OnlyIfVisible As Boolean, ByVal HitEverything As Boolean, ByVal Firepower As Integer)
                Dim tptr As New TilePtr(index, layer)
                If OnlyIfVisible Then
                    If Not Game.Math.Collide_BoxBox(tptr.X, tptr.Y, tptr.Width, tptr.Height, Game.cam.X, Game.cam.Y, Game.cam.w, Game.cam.h) Then Exit Sub
                End If

                'Get the pixel coordinates
                Dim X, Y, SourceW, SourceH As Integer
                Dim tmpCell As psMapTile = Game.CurMap.Cells1D2(index, layer)
                With Game.CurMap.Conv1DTo2D(index)
                    X = tptr.X + (tptr.Width - Game.tileset.tiles(BulletIndex).sectionw) / 2
                    Y = tptr.Y + (tptr.Height - Game.tileset.tiles(BulletIndex).sectionh) / 2
                End With
                SourceW = Game.tileset.tiles(tmpCell.tile).sectionw
                SourceH = Game.tileset.tiles(tmpCell.tile).sectionh

                'Get the direction and speed
                Dim DirX, DirY As Single
                Dim ShootUp, ShootLeft, ShootRight, ShootDown As Boolean
                Select Case Direction
                    Case "Left"
                        ShootLeft = True
                    Case "Right"
                        ShootRight = True
                    Case "Up"
                        ShootUp = True
                    Case "Down"
                        ShootDown = True
                    Case "Up Left"
                        ShootLeft = True
                        ShootUp = True
                    Case "Up Right"
                        ShootRight = True
                        ShootUp = True
                    Case "Down Left"
                        ShootLeft = True
                        ShootDown = True
                    Case "Down Right"
                        ShootRight = True
                        ShootDown = True
                    Case Else '"Towards Character"
                        'Get direction
                        DirX = (Character.x + Character.Width / 2) - (X + Game.tileset.tiles(BulletIndex).sectionw / 2)
                        DirY = (Character.y + Character.Height / 2) - (Y + Game.tileset.tiles(BulletIndex).sectionh / 2)
                        'If tmpCell.Behavior = psTile.TileBehavior.Solid Then 'Or tmpCell.Behavior = psTile.TileBehavior.Ledge Then
                        '    If DirX < 0 Then
                        '        X -= Game.tileset.tiles(BulletIndex).sectionw
                        '    ElseIf DirX > 0 Then
                        '        X += SourceW
                        '    End If
                        '    If DirY < 0 Then
                        '        Y -= Game.tileset.tiles(BulletIndex).sectionh
                        '    ElseIf DirY > 0 Then
                        '        Y += SourceH
                        '    End If
                        '    Dim tmpDirX As Single, tmpDirY As Single
                        '    tmpDirX = (Character.x + Character.Width / 2) - (X + Game.tileset.tiles(BulletIndex).sectionw / 2)
                        '    tmpDirY = (Character.y + Character.Height / 2) - (Y + Game.tileset.tiles(BulletIndex).sectionh / 2)
                        '    If Sign(DirX) = -Sign(tmpDirX) Then
                        '        DirX = 0
                        '    Else
                        '        DirX = tmpDirX
                        '    End If
                        '    If Sign(DirY) = -Sign(tmpDirY) Then
                        '        DirY = 0
                        '    Else
                        '        DirY = tmpDirY
                        '    End If
                        '    If DirX = 0 And DirY = 0 Then Exit Sub
                        'End If

                        'Get speed
                        Dim DirX2 As Single = DirX
                        DirX = ((1 / (Abs(DirX) + Abs(DirY))) * DirX) * Speed
                        DirY = ((1 / (Abs(DirX2) + Abs(DirY))) * DirY) * Speed
                End Select

                'Shoot up/left/right/down/diagonals
                If ShootLeft Then
                    DirX = -1 * Speed
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Or tmpCell.Behavior = psTile.TileBehavior.Ledge Then X -= Game.tileset.tiles(BulletIndex).sectionw
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Then X -= Game.tileset.tiles(BulletIndex).sectionw
                ElseIf ShootRight Then
                    DirX = 1 * Speed
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Or tmpCell.Behavior = psTile.TileBehavior.Ledge Then X += SourceW
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Then X += SourceW
                End If
                If ShootUp Then
                    DirY = -1 * Speed
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Or tmpCell.Behavior = psTile.TileBehavior.Ledge Then Y -= Game.tileset.tiles(BulletIndex).sectionh
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Then Y -= Game.tileset.tiles(BulletIndex).sectionh
                ElseIf ShootDown Then
                    DirY = 1 * Speed
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Or tmpCell.Behavior = psTile.TileBehavior.Ledge Then Y += SourceH
                    'If tmpCell.Behavior = psTile.TileBehavior.Solid Then Y += SourceH
                End If

                'Accuracy - uses the random number generator
                Dim DirMagnitude As Single
                If Accuracy <> 100 Then
                    DirMagnitude = Game.Math.Dist(0, 0, DirX, DirY)
                    Dim Diffusion As Single = 1.007 ^ (100 - Accuracy) - 1
                    Randomize()

                    'Normalize the direction and diffuse it
                    DirX = DirX / DirMagnitude + (Rnd(1) * Diffusion - Diffusion / 2)
                    DirY = DirY / DirMagnitude + (Rnd(1) * Diffusion - Diffusion / 2)
                End If

                'Normalize the direction again and multiply by speed
                DirMagnitude = Game.Math.Dist(0, 0, DirX, DirY)
                DirX *= Speed / DirMagnitude
                DirY *= Speed / DirMagnitude

                'Add entry
                Dim bt As New BulletTile()
                bt.Layer = 1
                bt.Tile = New psMapTile
                bt.Tile.tile = BulletIndex
                bt.Tile.Frame = BulletFrame
                bt.X = X
                bt.Y = Y
                bt.StartX = bt.X
                bt.StartY = bt.Y
                bt.DirX = DirX
                bt.DirY = DirY
                bt.MaxDistance = MaxDistance * Game.tileW
                bt.Source = New TilePtr(index, layer)
                bt.HitEverything = HitEverything
                bt.Firepower = Firepower
                BulletTiles.Add(bt)
            End Sub
            Private Function TileName2Index(ByVal Name As String, Optional ByRef Frame As Integer = 0) As Integer
                If Name.EndsWith("|") Then
                    Frame = Name.Substring(Name.IndexOf("|")).Trim("|")
                    Name = Name.Substring(0, Name.IndexOf("|"))
                End If
                For i As Integer = 1 To Game.tileset.NumTiles
                    If Game.tileset.tiles(i).name = Name Then
                        Return i
                    End If
                Next
            End Function

            Private Function _GetCounter(ByVal Name As String) As Integer
                Dim i As Integer
                For i = 1 To UBound(Game.actions.Counters)
                    If Game.actions.Counters(i).Name = Name Then
                        Return i
                    End If
                Next
            End Function

            Function GetHealth() As Double Implements IGame.GetHealth
                Return Game.actions.Counters(3).Value
            End Function
            Function GetLevel() As Integer Implements IGame.GetLevel
                Return Game.CurMapIndex
            End Function
            Function GetLives() As Integer Implements IGame.GetLives
                Return Game.actions.Counters(2).Value
            End Function
            Function GetScore() As Double Implements IGame.GetScore
                Return Game.actions.Counters(1).Value
            End Function
            Function GetCounter(ByVal Counter As String) As Double Implements IGame.GetCounter
                Return Game.actions.Counters(Me._GetCounter(Counter)).Value
            End Function

            ReadOnly Property MouseX() As Integer Implements IGame.MouseX
                Get
                    Return Game.p.PointToClient(Control.MousePosition).X
                End Get
            End Property

            ReadOnly Property MouseY() As Integer Implements IGame.MouseY
                Get
                    Return Game.p.PointToClient(Control.MousePosition).Y
                End Get
            End Property

            ReadOnly Property MouseLButton() As Boolean Implements IGame.MouseLButton
                Get
                    Return (Control.MouseButtons And MouseButtons.Left)
                End Get
            End Property

            ReadOnly Property MouseRButton() As Boolean Implements IGame.MouseRButton
                Get
                    Return (Control.MouseButtons And MouseButtons.Right)
                End Get
            End Property

            ReadOnly Property MouseMButton() As Boolean Implements IGame.MouseMButton
                Get
                    Return (Control.MouseButtons And MouseButtons.Middle)
                End Get
            End Property

            ReadOnly Property CharFacingRight() As Boolean Implements IGame.CharFacingRight
                Get
                    Return Character.FacingRight
                End Get
            End Property

            ReadOnly Property CharJumping() As Boolean Implements IGame.CharJumping
                Get
                    Return Character.FacingRight
                End Get
            End Property

            ReadOnly Property CharFalling() As Boolean Implements IGame.CharFalling
                Get
                    Return Character.FacingRight
                End Get
            End Property

            Function ConvPixelsToTilesX(ByVal Pixels As Integer) As Double Implements IGame.ConvPixelsToTilesX
                Return (Pixels / Game.tileW) + 1
            End Function

            Function ConvTilesToPixelsX(ByVal Tiles As Double) As Integer Implements IGame.ConvTilesToPixelsX
                Return (Tiles - 1) * Game.tileW
            End Function

            Function ConvPixelsToTilesY(ByVal Pixels As Integer) As Double Implements IGame.ConvPixelsToTilesY
                Return (Pixels / Game.tileH) + 1
            End Function

            Function ConvTilesToPixelsY(ByVal Tiles As Double) As Integer Implements IGame.ConvTilesToPixelsY
                Return (Tiles - 1) * Game.tileH
            End Function

            Sub ShootFromPoint(ByVal BulletLeftEdge_Pixels As Integer, ByVal BulletTopEdge_Pixels As Integer, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal MapLayer As Byte = 2) Implements IGame.ShootFromPoint
                Dim BulletIndex As Integer = TileName2Index(BulletTile)

                'Get the direction and speed
                Dim DirX, DirY As Single
                Select Case Direction
                    Case "Left"
                        DirX = -1 * Speed
                    Case "Right"
                        DirX = 1 * Speed
                    Case "Up"
                        DirY = -1 * Speed
                    Case "Down"
                        DirY = 1 * Speed
                    Case "Up Left"
                        DirX = -1 / System.Math.Sqrt(2) * Speed
                        DirY = -1 / System.Math.Sqrt(2) * Speed
                    Case "Up Right"
                        DirX = 1 / System.Math.Sqrt(2) * Speed
                        DirY = -1 / System.Math.Sqrt(2) * Speed
                    Case "Down Left"
                        DirX = -1 / System.Math.Sqrt(2) * Speed
                        DirY = 1 / System.Math.Sqrt(2) * Speed
                    Case "Down Right"
                        DirX = 1 / System.Math.Sqrt(2) * Speed
                        DirY = 1 / System.Math.Sqrt(2) * Speed
                    Case Else '"Towards Character"
                        'Get direction
                        DirX = (Character.x + Character.Width / 2) - ((BulletLeftEdge_Pixels + Game.tileset.tileSecW(BulletTile) * 0.5) + Game.tileset.tiles(BulletIndex).sectionw / 2)
                        DirY = (Character.y + Character.Height / 2) - ((BulletTopEdge_Pixels + Game.tileset.tileSecH(BulletTile) * 0.5) + Game.tileset.tiles(BulletIndex).sectionh / 2)

                        'Get speed
                        Dim DirX2 As Single = DirX
                        DirX = ((1 / (Abs(DirX) + Abs(DirY))) * DirX) * Speed
                        DirY = ((1 / (Abs(DirX2) + Abs(DirY))) * DirY) * Speed
                End Select

                'Add entry
                Dim bt As New BulletTile()
                bt.Layer = 1
                bt.Tile = New psMapTile
                bt.Tile.tile = BulletIndex
                bt.X = BulletLeftEdge_Pixels
                bt.Y = BulletTopEdge_Pixels
                bt.StartX = bt.X
                bt.StartY = bt.Y
                bt.DirX = DirX
                bt.DirY = DirY
                BulletTiles.Add(bt)
            End Sub

            ReadOnly Property CharacterW() As Integer Implements IGame.CharacterW
                Get
                    Return Character.Width
                End Get
            End Property

            ReadOnly Property CharacterH() As Integer Implements IGame.CharacterH
                Get
                    Return Character.Height
                End Get
            End Property

            Sub SetTileAnimation(ByVal Group As String, ByVal AnimationIndex As Integer) Implements IGame.SetTileAnimation
                SetTileIndex(Group, , , AnimationIndex)
            End Sub

            Sub SetTileAnimation(ByVal Group As String, ByVal AnimationName As String) Implements IGame.SetTileAnimation
                Dim AnimationIndex As Integer
                Select Case AnimationName
                    Case "Normal" : AnimationIndex = 0
                    Case "Disappear" : AnimationIndex = 1
                    Case Else
                        If AnimationName.StartsWith("Custom ") Then
                            AnimationIndex = AnimationName.Substring(7) + 1
                        End If
                End Select
                SetTileIndex(Group, , , AnimationIndex)
            End Sub

            ReadOnly Property CharAffectedByGravity() As Boolean Implements IGame.CharAffectedByGravity
                Get
                    Return Character.AffectedByGravity
                End Get
            End Property

            ReadOnly Property GetWindow(ByVal WindowName As String) As psUI.psWindows.psWindow Implements IGame.GetWindow
                Get
                    For i As Integer = 1 To UBound(Game.windows.Windows)
                        If Game.windows.Windows(i).Name = WindowName Then
                            Return Game.windows.Windows(i)
                        End If
                    Next
                    Return Nothing
                End Get
            End Property

            ReadOnly Property GetControl(ByVal WindowName As String, ByVal ControlText As String) As psUI.psControl Implements IGame.GetControl
                Get
                    For i As Integer = 1 To UBound(Game.windows.Windows)
                        If Game.windows.Windows(i).Name = WindowName Then
                            For j As Integer = 1 To Game.windows.Windows(i).NumCtrls
                                If Game.windows.Windows(i).Controls(j).Text = ControlText Then
                                    Return Game.windows.Windows(i).Controls(j)
                                End If
                            Next
                        End If
                    Next
                    Return Nothing
                End Get
            End Property

            ReadOnly Property Camera() As PlatformStudio.psGame.psCamera Implements IGame.Camera
                Get
                    Return Game.cam
                End Get
            End Property

            ReadOnly Property Math() As PlatformStudio.psGame.psMath Implements IGame.Math
                Get
                    Return Game.Math
                End Get
            End Property

            ReadOnly Property Properties() As PlatformStudio.psGame.psGameProperties Implements IGame.Properties
                Get
                    Return Game.GameProperties
                End Get
            End Property

            ReadOnly Property Drawing() As PlatformStudio.psDraw Implements IGame.Drawing
                Get
                    Return Game.Drawing
                End Get
            End Property

            Function GetLevelName() As String Implements IGame.GetLevelName
                Return Game.CurMap.MapName
            End Function

            Sub StartTimer(ByVal TimerName As String) Implements IGame.StartTimer
                Game.actions.Timers(GetTimer(TimerName)).Enabled = True
                Game.actions.Timers(GetTimer(TimerName)).StartTime = 0
            End Sub

            Sub StopTimer(ByVal TimerName As String) Implements IGame.StopTimer
                Game.actions.Timers(GetTimer(TimerName)).Enabled = False
            End Sub

            Private _executetrigger As IExecuteTrigger = New ExecuteTrigger
            Function ExecuteTrigger() As IExecuteTrigger Implements IGame.ExecuteTrigger
                Return _executetrigger
            End Function

            Sub ExecuteTriggerString(ByVal ActionCode As String) Implements IGame.ExecuteTriggerString
                Try
                    Select Case ActionCode.Chars(0)
                        Case "t", "g"
                            ActionProcessor.ProcessActions(ActionCode, curGroup)
                        Case "c"
                            ActionProcessor.ProcessActions(ActionCode, curCounter)
                        Case "i"
                            ActionProcessor.ProcessActions(ActionCode, curTimer)
                        Case Else
                            ActionProcessor.ProcessActions(ActionCode)
                    End Select
                Catch 'Invalid action code
                    Exit Sub
                End Try
            End Sub

            Public Sub KillTile(ByVal Group As String) Implements IGame.KillTile
                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Exit Sub
                    If CurTile.GetTile.Group = "" Then
                        kill_Tile(CurTile.Index, CurTile.Layer)
                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group Then
                                kill_Tile(i, n)
                            End If
                        Next
                    Next
                End If
            End Sub

            Public Sub KillCurrentTile() Implements PlatformStudio.IGame.KillCurrentTile
                kill_Tile(CurTile.Index, CurTile.Layer)
            End Sub

            Friend Sub kill_Tile(ByVal index As Integer, ByVal n As Integer)
                Dim Ptr As New TilePtr(index, n)
                Dim tmpTile As Integer, tmpGroup As String
                With Ptr
                    tmpTile = .GetTile.tile
                    tmpGroup = .GetTile.Group

                    'Disappear animation
                    If Game.tileset.tiles(.GetTile.tile).Anim(1).Interval > 0 Then
                        ReDim Preserve Anim(UBound(Anim) + 1)
                        Anim(UBound(Anim)).Init(.X, .Y, .GetTile.tile, Game.tileset.tiles(.GetTile.tile).Anim(1).StartFrame, 1, .GetTile.Frame)
                    End If

                    'Delete entry from PathTiles if one exists
                    For i As Integer = 0 To PathTiles.Count - 1
                        If i >= PathTiles.Count Then Exit For
                        If PathTiles(i).Index = .Index And PathTiles(i).Layer = .Layer Then
                            PathTiles.RemoveAt(i)
                            i -= 1
                        End If
                    Next

                    'Permanently reset the tile
                    .GetTile = New psMapTile
                End With
                SetCurGroup("(Destroyed)", 0, 0, 0, 0, 0, 0, 0, "")
                ActionProcessor.ProcessActions("tdes" & tmpTile, curGroup)
                ActionProcessor.ProcessActions("gdes" & LevelText & tmpGroup, curGroup)
            End Sub

            Private WithEvents video As Microsoft.DirectX.AudioVideoPlayback.Video

            Sub PlayMovie(ByVal Filename As String, Optional ByVal Volume As Integer = 100, Optional ByVal PressKeyToSkip As Boolean = True, Optional ByVal x As Integer = 0, Optional ByVal y As Integer = 0, Optional ByVal w As Integer = 0, Optional ByVal h As Integer = 0, Optional ByVal ClearBackground As Boolean = True) Implements IGame.PlayMovie
                QuickPause()

                'Create a new video
                video = New Microsoft.DirectX.AudioVideoPlayback.Video(Filename)
                video.Audio.Volume = (100 - Volume) * -100

                'Disable menus
                f.MenuItem1.Enabled = False
                f.MenuItem2.Enabled = False

                'Set play movie and skip movie flags
                PlayingMovie = True
                SkipMovie = False
                ClickToSkipMovie = PressKeyToSkip

                'Pause the game
                Dim tmpPaused As Boolean = Paused
                Paused = True

                'Set the owner to the movie picturebox
                video.Owner = f.PictureBox1

                'Clear the scene
                Game.Drawing.Clear()
                If ClearBackground = False Then Renderer.DrawWindow(Game.CurWinIndex)
                Game.Drawing.RenderToScreen()

                'Set up movie rectangle
                If w = 0 Then w = Game.cam.w
                If h = 0 Then h = Game.cam.h
                f.PictureBox1.Location = New Point(x, y)
                f.PictureBox1.Size = New Size(w, h)

                'Play the movie
                Game.Audio.PauseMusic()
                video.Play()
                video.CurrentPosition = 0
                f.PictureBox1.Size = New Size(w, h)

                'Show the movie picturebox
                f.PictureBox1.Visible = True

                'Wait until the movie finishes playing
                Do
                    Application.DoEvents()
                Loop Until video.CurrentPosition >= video.Duration Or SkipMovie

                'Reset the movie and pause flags
                Game.Audio.ResumeMusic()
                PlayingMovie = False
                Paused = tmpPaused

                'Enable the menus
                f.MenuItem1.Enabled = True
                f.MenuItem2.Enabled = True

                'Destroy the movie
                video.Stop()
                video.Dispose()
                video = Nothing
                f.PictureBox1.Size = New Size(w, h)

                'Hide the movie picturebox
                f.PictureBox1.Visible = False

                QuickResume()
            End Sub

            Function GetTileIndex(ByVal x As Integer, ByVal y As Integer) As Integer Implements IGame.GetTileIndex
                Return Game.CurMap.Cells(x, y, 1)
            End Function

            Function GetTileName(ByVal x As Integer, ByVal y As Integer) As Integer Implements IGame.GetTileName
                Return Game.tileset.tiles(Game.CurMap.Cells(x, y, 1)).name
            End Function

            Private Function GetGroup(ByVal Group As String) As ArrayList
                Dim tiles As New ArrayList
                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Return tiles
                    If CurTile.GetTile.Group = "" Then
                        tiles.Add(CurTile)
                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group Then
                                tiles.Add(New TilePtr(i, n))
                            End If
                        Next
                    Next
                End If
                Return tiles
            End Function

            Property AutoUpdateCamera() As Boolean Implements IGame.AutoUpdateCamera
                Get
                    Return Renderer.AutoUpdateCamera
                End Get
                Set(ByVal Value As Boolean)
                    Renderer.AutoUpdateCamera = Value
                End Set
            End Property

            ReadOnly Property FPS() As Double Implements IGame.FPS
                Get
                    Return 1 / Renderer.TimeElapsed
                End Get
            End Property

            ReadOnly Property TimeElapsed() As Double Implements IGame.TimeElapsed
                Get
                    Return Renderer.TimeElapsed
                End Get
            End Property

            Private _compatibility As New Compatibility
            ReadOnly Property Compatibility() As ICompatibility Implements IGame.Compatibility
                Get
                    Return _compatibility
                End Get
            End Property

            Public Sub ShootAnythingFromGroup(ByVal Group As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Firepower As Byte, ByVal Range As Integer, ByVal Speed As Double, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.ShootAnythingFromGroup
                'Get bullet tile
                Dim BulletIndex As Integer = TileName2Index(BulletTile)

                If Group = "(Current Group)" Then
                    If IsNothing(CurTile) Then Exit Sub
                    If CurTile.GetTile.Group = "" Then

                        'Shoot
                        ShootEnemiesFromPoint( _
                            CurTile.X + CurTile.Width / 2 + OffsetX - Game.tileset.tileSecW(BulletIndex) / 2, _
                            CurTile.Y + CurTile.Height / 2 + OffsetY - Game.tileset.tileSecH(BulletIndex) / 2, _
                            BulletIndex, Direction, Firepower, Range, Speed, 0, OffsetX, OffsetY, True)

                    Else
                        Group = CurTile.GetTile.Group
                        GoTo SearchForGroup
                    End If
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group And Game.CurMap.Cells1D2(i, n).Invisible = False Then

                                'Shoot
                                Dim tp As New TilePtr(i, n)
                                ShootEnemiesFromPoint( _
                                    tp.X + tp.Width / 2 + OffsetX - Game.tileset.tileSecW(BulletIndex) / 2, _
                                    tp.Y + tp.Height / 2 + OffsetY - Game.tileset.tileSecH(BulletIndex) / 2, _
                                    BulletIndex, Direction, Firepower, Range, Speed, 0, OffsetX, OffsetY, True)

                            End If
                        Next
                    Next
                End If
            End Sub

            Function ShootFromCharacter(ByVal BulletTile As String, ByVal Direction As String, ByVal Firepower As Byte, ByVal Range As Integer, ByVal Speed As Double, ByVal Delay As Double, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) As Boolean Implements PlatformStudio.IGame.ShootFromCharacter
                'Get bullet tile
                Dim BulletIndex As Integer = TileName2Index(BulletTile)

                'Get position
                Dim posX, posY As Double
                posX = Character.x + Character.Width / 2 + OffsetX - Game.tileset.tileSecW(BulletIndex) / 2
                posY = Character.y + Character.Height / 2 + OffsetY - Game.tileset.tileSecH(BulletIndex) / 2

                'Shoot
                Return ShootEnemiesFromPoint(posX, posY, BulletIndex, Direction, Firepower, Range, Speed, Delay, OffsetX, OffsetY)
            End Function

            Function ShootEnemiesFromPoint(ByVal posX As Integer, ByVal posY As Integer, ByVal BulletIndex As Integer, ByVal Direction As String, ByVal Firepower As Byte, ByVal Range As Integer, ByVal Speed As Double, ByVal Delay As Double, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0, Optional ByVal HitAnything As Boolean = False) As Boolean
                'Fire rate
                If Timer - Character.ShootStart < Delay Then Return False

                'Get direction
                Dim dx, dy As Double
                Select Case Direction
                    Case "Left" : dx = -1 : dy = 0
                    Case "Right" : dx = 1 : dy = 0
                    Case "Up" : dx = 0 : dy = -1
                    Case "Down" : dx = 0 : dy = 1
                    Case "Up Left" : dx = -1 : dy = -1
                    Case "Up Right" : dx = 1 : dy = -1
                    Case "Down Left" : dx = -1 : dy = 1
                    Case "Down Right" : dx = 1 : dy = 1
                    Case "Current Direction"
                        dx = IIf(Character.FacingRight, 1, -1)
                        dy = 0
                    Case "Towards Cursor"
                        Dim p As New Point _
                            (posX + Game.tileset.tileSecW(BulletIndex) / 2 - Game.cam.X + GameCtl.X, _
                             posY + Game.tileset.tileSecH(BulletIndex) / 2 - Game.cam.Y + GameCtl.Y)
                        dx = MouseX - p.X
                        dy = MouseY - p.Y
                    Case Else 'Angle
                        If Not Character.FacingRight Then
                            Direction = 180 - Direction
                        End If
                        dx = System.Math.Cos(Direction)
                        dy = System.Math.Sin(Direction)
                End Select

                'Normalize direction and multiply by speed
                If dx = 0 And dy = 0 Then Exit Function
                Dim magnitude As Double = Game.Math.Dist(0, 0, dx, dy)
                dx = dx / magnitude * Speed
                dy = dy / magnitude * Speed

                'Create a new bullet
                Dim bt As New BulletTile()
                bt.Layer = 1
                bt.Tile = New psMapTile
                bt.Tile.tile = BulletIndex
                bt.X = posX
                bt.Y = posY
                bt.StartX = bt.X
                bt.StartY = bt.Y
                bt.DirX = dx
                bt.DirY = dy
                bt.Firepower = Firepower
                bt.MaxDistance = Range * Game.tileW
                If HitAnything Then
                    bt.HitEverything = True
                Else
                    bt.FromCharacter = True
                End If
                BulletTiles.Add(bt)

                If Not HitAnything Then
                    'Set start shoot time
                    Character.ShootStart = Timer

                    'Flip character if needed
                    If (Character.FacingRight And dx / Speed < -0.07) Or (Not Character.FacingRight And dx / Speed > 0.07) Then
                        Character.FacingRight = Not Character.FacingRight
                    End If
                End If

                'Was able to shoot
                Return True
            End Function

            Sub DrawHealthBarForCurrentTile(ByVal BackColor As System.Drawing.Color, ByVal BarColor As System.Drawing.Color, ByVal BorderColor As System.Drawing.Color, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.DrawHealthBarForCurrentTile
                DrawHealthBar(curGroup.CurTileX, curGroup.CurTileY, curGroup.CurTileW, curGroup.CurTileH, curGroup.CurTileHP, Game.tileset.tiles(CurTile.GetTile.tile).HitPoints, BackColor, BarColor, BorderColor, Thickness, OffsetX, OffsetY)
            End Sub

            Private Sub DrawHealthBar(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal hp As Integer, ByVal maxHP As Integer, ByVal BackColor As System.Drawing.Color, ByVal BarColor As System.Drawing.Color, ByVal BorderColor As System.Drawing.Color, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
                Dim tmp As Boolean = Game.Drawing.RelativeToCam
                Game.Drawing.RelativeToCam = True
                Game.Drawing.DrawFilledBox(OffsetX + x + 1, OffsetY + y - Thickness - 2 + 1, w - 1, Thickness - 1, BackColor)
                Game.Drawing.DrawFilledBox(OffsetX + x + 1, OffsetY + y - Thickness - 2 + 1, (w - 1) * (hp / System.Math.Max(maxHP, 1)), Thickness - 1, BarColor)
                Game.Drawing.DrawBox(OffsetX + x, OffsetY + y - Thickness - 2, w, Thickness, BorderColor)
                Game.Drawing.RelativeToCam = tmp
            End Sub

            Sub DrawHealthBarForCurrentTile(ByVal BackColor As Integer, ByVal BarColor As Integer, ByVal BorderColor As Integer, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.DrawHealthBarForCurrentTile
                DrawHealthBarForCurrentTile(Color.FromArgb(BackColor), Color.FromArgb(BarColor), Color.FromArgb(BorderColor), Thickness, OffsetX, OffsetY)
            End Sub

            Sub DrawHealthBarForTile(ByVal Group As String, ByVal BackColor As System.Drawing.Color, ByVal BarColor As System.Drawing.Color, ByVal BorderColor As System.Drawing.Color, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.DrawHealthBarForTile
                If Group = "(Current Group)" Then
                    DrawHealthBarForCurrentTile(BackColor, BarColor, BorderColor, Thickness, OffsetX, OffsetY)
                Else
SearchForGroup:
                    For n As Byte = 1 To 3
                        For i As Integer = 1 To Game.CurMap.MapSize1D
                            If Game.CurMap.Cells1D2(i, n).Group = Group And Game.CurMap.Cells1D2(i, n).Invisible = False Then
                                Dim tp As New TilePtr(i, n)
                                DrawHealthBar(tp.X, tp.Y, tp.Width, tp.Height, tp.GetTile().HitPoints, Game.tileset.tiles(tp.GetTile().tile).HitPoints, BackColor, BarColor, BorderColor, Thickness, OffsetX, OffsetY)
                            End If
                        Next
                    Next
                End If
            End Sub

            Sub DrawHealthBarForTile(ByVal Group As String, ByVal BackColor As Integer, ByVal BarColor As Integer, ByVal BorderColor As Integer, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.DrawHealthBarForTile
                DrawHealthBarForTile(Group, Color.FromArgb(BackColor), Color.FromArgb(BarColor), Color.FromArgb(BorderColor), Thickness, OffsetX, OffsetY)
            End Sub

            Public Sub DrawAnimationAtCurrentTile(ByVal AnimationSourceTile As String, ByVal AnimIndex As Integer, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) Implements PlatformStudio.IGame.DrawAnimationAtCurrentTile
                'Create animation
                ReDim Preserve Anim(UBound(Anim) + 1)
                Anim(UBound(Anim)).Init(CurTile.X + OffsetX, CurTile.Y + OffsetY, AnimationSourceTile, Game.tileset.tiles(CurTile.GetTile.tile).Anim(AnimIndex).StartFrame, AnimIndex, CurTile.GetTile.Frame)
            End Sub

            Public Sub Scroll(ByVal Direction As String, ByVal Speed As Double) Implements PlatformStudio.IGame.Scroll
                Select Case Direction
                    Case "Left"
                        Game.cam.X -= Speed * Game.tileW * TimeElapsed
                    Case "Right"
                        Game.cam.X += Speed * Game.tileW * TimeElapsed
                    Case "Up"
                        Game.cam.Y -= Speed * Game.tileH * TimeElapsed
                    Case "Down"
                        Game.cam.Y += Speed * Game.tileH * TimeElapsed
                End Select
            End Sub

            Public Sub MoveCameraToDefaultPosition(ByVal OffsetX As Integer, ByVal OffsetY As Integer) Implements PlatformStudio.IGame.MoveCameraToDefaultPosition
                Renderer.MoveCameraToDefaultPosition = True
                Renderer.mctdpX = OffsetX
                Renderer.mctdpY = OffsetY
                Renderer.tmpAutoUpdate = False
            End Sub

            Public Sub EnsureCharacterIsVisible() Implements PlatformStudio.IGame.EnsureCharacterIsVisible
                If FirstFrame Then
                    FirstFrame = False
                    Exit Sub
                End If
                If Character.x < Game.cam.X Then Character.x = Game.cam.X
                If Character.x + Character.Width > Game.cam.X + Game.cam.w Then Character.x = Game.cam.X + Game.cam.w - Character.Width
                If Character.y < Game.cam.Y Then Character.y = Game.cam.Y
                If Character.y + Character.Height > Game.cam.Y + Game.cam.h Then Character.y = Game.cam.Y + Game.cam.h - Character.Height
            End Sub
            Public Sub ShowWindow(ByVal WindowIndex As Integer) Implements IGame.ShowWindow
                Game.CurWinIndex = WindowIndex
            End Sub
            Sub ShowMessageBox(ByVal title As String, ByVal message As String, ByVal icon As String) Implements IGame.ShowMessageBox
                Dim iconValue As MessageBoxIcon
                Select Case icon.Trim.ToLower
                    Case "error", "critical", "stop", "hand"
                        iconValue = MessageBoxIcon.Error
                    Case "warn", "warning", "exclaim", "exclamation"
                        iconValue = MessageBoxIcon.Exclamation
                    Case "asterisk", "inform", "information"
                        iconValue = MessageBoxIcon.Information
                    Case "question", "confirm", "ask"
                        iconValue = MessageBoxIcon.Question
                    Case Else
                        iconValue = MessageBoxIcon.None
                End Select
                QuickPause()
                MessageBox.Show(message, title, MessageBoxButtons.OK, iconValue)
                QuickResume()
            End Sub
            Function Confirm(ByVal title As String, ByVal message As String) As Boolean Implements IGame.Confirm
                QuickPause()
                Dim tmp As Boolean = (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
                QuickResume()
                Return tmp
            End Function
            Sub OpenFile(ByVal filename As String) Implements IGame.OpenFile
                Process.Start(GetRelativeFile(filename))
            End Sub
            Sub OpenURL(ByVal url As String) Implements IGame.OpenURL
                Process.Start(url)
            End Sub
            Sub ExitProgram() Implements IGame.ExitProgram
                f.RequestClose()
            End Sub
            Sub ClearHighscores() Implements IGame.ClearHighscores
                Client.ClearHighscores()
            End Sub
            Sub SetTileAtLocation(ByVal xtiles As Integer, ByVal ytiles As Integer, Optional ByVal newTileName As String = Nothing, Optional ByVal newFrame As Integer = -1, Optional ByVal newAnimationIndex As Integer = -1, Optional ByVal newGroup As String = Nothing) Implements IGame.SetTileAtLocation
                SetTileAtLocation(xtiles, ytiles, 2, newTileName, newFrame, newAnimationIndex, newGroup)
            End Sub
            Sub SetTileAtLocation(ByVal xtiles As Integer, ByVal ytiles As Integer, ByVal layer As Integer, Optional ByVal newTileName As String = Nothing, Optional ByVal newFrame As Integer = -1, Optional ByVal newAnimationIndex As Integer = -1, Optional ByVal newGroup As String = Nothing) Implements IGame.SetTileAtLocation
                Dim tmpCell As psMapTile = Game.CurMap.Cells2(xtiles, ytiles, layer)
                With tmpCell
                    If newAnimationIndex > -1 Then
                        .AnimIndex = newAnimationIndex
                    End If
                    If newFrame > -1 Then
                        .Frame = newFrame
                    End If
                    If Not newTileName Is Nothing Then
                        .tile = Drawing.Tex.IndexOfKey(newTileName)
                    End If
                    If Not newGroup Is Nothing Then
                        .Group = newGroup
                    End If
                End With
                Game.maps(Game.CurMapIndex).Cells2(xtiles, ytiles, layer) = tmpCell
                Character.UpdatedMap()
            End Sub
            Sub SetCharacterAnimation(ByVal animIndex As Integer, ByVal stopped As Boolean) Implements IGame.SetCharacterAnimation
                Character.UseCustomAnimation = True
                Character.CustomAnimation = animIndex
                Character.CustomAnimationStopped = stopped
            End Sub
            Sub SetCharacterAnimationToDefault() Implements IGame.SetCharacterAnimationToDefault
                Character.UseCustomAnimation = False
            End Sub
            ReadOnly Property CharCurrentAnim() As Integer Implements IGame.CharCurrentAnim
                Get
                    Return Character.CurrentAnimIndex
                End Get
            End Property
            ReadOnly Property UsingCustomAnimation() As Boolean Implements IGame.UsingCustomAnimation
                Get
                    Return Character.UseCustomAnimation
                End Get
            End Property
            ReadOnly Property CharAnimStopped() As Boolean Implements IGame.CharAnimStopped
                Get
                    Return Character.AnimStopped
                End Get
            End Property

            Dim SaveFileVersion As Integer = 1
            Sub Save(Optional ByVal state As String = "") Implements IGame.Save
                Dim tmpWindow As Integer = Game.CurWinIndex
                PauseGame()
                Dim filename As String = "C:\Users\Andrew First\Desktop\saved.psg"
                f.dlgSave.Filter = "Saved Game Files|*.savedgame"
                If f.dlgSave.ShowDialog() = DialogResult.Cancel Then
                    Me.ShowWindow(tmpWindow)
                    Return
                End If
                filename = f.dlgSave.FileName
                Try
                    psFileHandler.theStream = IO.File.Open(filename, IO.FileMode.OpenOrCreate)
                    Dim writer As New IO.BinaryWriter(psFileHandler.theStream)
                    psFileHandler.bWriter = writer
                    writer.Write(SaveFileVersion)
                    writer.Write(Game.GameProperties.Name)
                    writer.Write(Game.GameProperties.Version)
                    writer.Write(Game.GameProperties.Company)
                    writer.Write(state)
                    writer.Write(PauseStart)
                    psFileHandler.Write(Game.actions.Counters)
                    psFileHandler.Write(Game.actions.Timers)
                    writer.Write(Game.cam.X)
                    writer.Write(Game.cam.y)
                    writer.Write(Game.cam.CustomWidth)
                    writer.Write(Game.cam.CustomHeight)
                    writer.Write(Game.CurMapIndex)
                    writer.Write(modCharacter.Character.AffectedByGravity)
                    psFileHandler.Write(modCharacter.Character.Checkpoint)
                    writer.Write(modCharacter.Character.Climbing)
                    psFileHandler.FilePutString(modCharacter.Character.CurDirection)
                    writer.Write(modCharacter.Character.CurrentlyClimbing)
                    writer.Write(modCharacter.Character.CustomAnimation)
                    writer.Write(modCharacter.Character.CustomAnimationStopped)
                    writer.Write(modCharacter.Character.FacingRight)
                    writer.Write(modCharacter.Character.Falling)
                    writer.Write(modCharacter.Character.FallStart)
                    writer.Write(modCharacter.Character.GravitySpeed)
                    writer.Write(modCharacter.Character.initialHeight)
                    writer.Write(modCharacter.Character.jumpHeight)
                    writer.Write(modCharacter.Character.jumpHeight1)
                    writer.Write(modCharacter.Character.Jumping)
                    writer.Write(modCharacter.Character.JumpStart)
                    writer.Write(modCharacter.Character.jumpTime)
                    writer.Write(modCharacter.Character.minJumpHeight)
                    psFileHandler.Write(modCharacter.Character.loc)
                    writer.Write(modCharacter.Character.oldY)
                    writer.Write(modCharacter.Character.rawX)
                    writer.Write(modCharacter.Character.rawY)
                    writer.Write(modCharacter.Character.rX)
                    writer.Write(modCharacter.Character.rY)
                    writer.Write(modCharacter.Character.ShootStart)
                    psFileHandler.FilePutString(modCharacter.Character.str5DigitMapNum)
                    writer.Write(modCharacter.Character.t_gt_1)
                    writer.Write(modCharacter.Character.UseCustomAnimation)
                    writer.Write(modCharacter.Character.WaitCamX)
                    writer.Write(modCharacter.Character.WaitCamY)
                    writer.Write(modCharacter.Character.WaitStart)
                    writer.Write(modCharacter.Character.Walking)
                    writer.Write(modCharacter.Character.WasClimbing)
                    psFileHandler.Write(modCharacter.Character.TPtr2)
                    psFileHandler.Write(modCharacter.Character.tptrDown)
                    psFileHandler.Write(modCharacter.Character.tptrLeft)
                    psFileHandler.Write(modCharacter.Character.tptrRight)
                    psFileHandler.Write(modCharacter.Character.tptrUp)
                    psFileHandler.Write(modCharacter.BulletTiles)
                    psFileHandler.Write(modCharacter.DropTiles)
                    psFileHandler.Write(PathTiles)
                    psFileHandler.Write(Game.maps)
                    For i As Integer = 1 To Game.numMaps
                        Game.maps(i).Save()
                    Next
                    For m As Integer = 1 To UBound(Game.maps)
                        For n As Byte = 1 To 3
                            For i As Integer = 1 To Game.maps(m).MapSize1D
                                Dim cell As psMapTile = Game.maps(m).Cells1D2(i, n)
                                writer.Write(cell.GetAnimStart())
                                writer.Write(cell.AnimIndex)
                                writer.Write(cell.HitPoints)
                                writer.Write(cell.Invisible)
                                writer.Write(cell.PathX)
                                writer.Write(cell.PathY)
                            Next
                        Next
                    Next

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show( _
                        String.Format(GetString("error_SaveGame"), filename) & vbCrLf & vbCrLf & ex.Message, _
                        "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
                Finally
                    psFileHandler.theStream.Close()
                    Me.ShowWindow(tmpWindow)
                End Try

            End Sub
            Function Load() As String Implements IGame.Load
                Dim tmpWindow As Integer = Game.CurWinIndex
                PauseGame()
                Dim filename As String = "C:\Users\Andrew First\Desktop\saved.psg"
                f.dlgOpen.Filter = "Saved Game Files|*.savedgame"
                If f.dlgOpen.ShowDialog() = DialogResult.Cancel Then
                    Me.ShowWindow(tmpWindow)
                    Return Nothing
                End If
                filename = f.dlgOpen.FileName
                Dim state As String = ""
                Try
                    psFileHandler.theStream = IO.File.Open(filename, IO.FileMode.Open)
                    Dim reader As New IO.BinaryReader(psFileHandler.theStream)
                    psFileHandler.bReader = reader
                    Dim version As Integer = reader.ReadInt32()
                    If version <> SaveFileVersion Then
                        Throw New Exception("Wrong version.")
                    End If
                    If reader.ReadString() <> Game.GameProperties.Name Then
                        Throw New Exception("This saved game is for a different game.")
                    End If
                    If reader.ReadString() <> Game.GameProperties.Version Then
                        Throw New Exception("This saved game is for a different version of the game.")
                    End If
                    If reader.ReadString() <> Game.GameProperties.Company Then
                        Throw New Exception("This saved game is for a different game.")
                    End If
                    state = reader.ReadString()
                    PauseStart = reader.ReadSingle()
                    psFileHandler.Read(Game.actions.Counters)
                    psFileHandler.Read(Game.actions.Timers)
                    Game.cam.X = reader.ReadSingle()
                    Game.cam.Y = reader.ReadSingle()
                    Game.cam.CustomWidth = reader.ReadInt32()
                    Game.cam.CustomHeight = reader.ReadInt32()
                    Game.CurMapIndex = reader.ReadInt32()
                    modCharacter.Character.AffectedByGravity = reader.ReadBoolean()
                    psFileHandler.Read(modCharacter.Character.Checkpoint)
                    modCharacter.Character.Climbing = reader.ReadBoolean()
                    psFileHandler.FileGetString(modCharacter.Character.CurDirection)
                    modCharacter.Character.CurrentlyClimbing = reader.ReadBoolean()
                    modCharacter.Character.CustomAnimation = reader.ReadInt32()
                    modCharacter.Character.CustomAnimationStopped = reader.ReadBoolean()
                    modCharacter.Character.FacingRight = reader.ReadBoolean()
                    modCharacter.Character.Falling = reader.ReadBoolean()
                    modCharacter.Character.Falling = False
                    modCharacter.Character.FallStart = reader.ReadDouble()
                    modCharacter.Character.GravitySpeed = reader.ReadSingle()
                    modCharacter.Character.initialHeight = reader.ReadDouble()
                    modCharacter.Character.jumpHeight = reader.ReadDouble()
                    modCharacter.Character.jumpHeight1 = reader.ReadDouble()
                    modCharacter.Character.Jumping = reader.ReadBoolean()
                    modCharacter.Character.Jumping = False
                    modCharacter.Character.JumpStart = reader.ReadDouble()
                    modCharacter.Character.jumpTime = reader.ReadDouble()
                    modCharacter.Character.minJumpHeight = reader.ReadDouble()
                    psFileHandler.Read(modCharacter.Character.loc)
                    modCharacter.Character.oldY = reader.ReadDouble()
                    modCharacter.Character.rawX = reader.ReadDouble()
                    modCharacter.Character.rawY = reader.ReadDouble()
                    modCharacter.Character.rX = reader.ReadDouble()
                    modCharacter.Character.rY = reader.ReadDouble()
                    modCharacter.Character.ShootStart = reader.ReadSingle()
                    psFileHandler.FileGetString(modCharacter.Character.str5DigitMapNum)
                    modCharacter.Character.t_gt_1 = reader.ReadBoolean()
                    modCharacter.Character.UseCustomAnimation = reader.ReadBoolean()
                    modCharacter.Character.WaitCamX = reader.ReadInt32()
                    modCharacter.Character.WaitCamY = reader.ReadInt32()
                    modCharacter.Character.WaitStart = reader.ReadSingle()
                    modCharacter.Character.Walking = reader.ReadBoolean()
                    modCharacter.Character.WasClimbing = reader.ReadBoolean()
                    psFileHandler.Read(modCharacter.Character.TPtr2)
                    psFileHandler.Read(modCharacter.Character.tptrDown)
                    psFileHandler.Read(modCharacter.Character.tptrLeft)
                    psFileHandler.Read(modCharacter.Character.tptrRight)
                    psFileHandler.Read(modCharacter.Character.tptrUp)
                    psFileHandler.Read(modCharacter.BulletTiles)
                    psFileHandler.Read(modCharacter.DropTiles)
                    psFileHandler.Read(PathTiles)
                    ActionProcessor.ChangedLevel = True
                    psFileHandler.Read(Game.maps)
                    For i As Integer = 1 To Game.numMaps
                        Game.maps(i).Load()
                    Next
                    For m As Integer = 1 To UBound(Game.maps)
                        For n As Byte = 1 To 3
                            For i As Integer = 1 To Game.maps(m).MapSize1D
                                Dim cell As psMapTile = Game.maps(m).Cells1D2(i, n)
                                cell.SetAnimStart(reader.ReadSingle())
                                cell.AnimIndex = reader.ReadByte()
                                cell.HitPoints = reader.ReadByte()
                                cell.Invisible = reader.ReadBoolean()
                                cell.PathX = reader.ReadSingle()
                                cell.PathY = reader.ReadSingle()
                                Game.maps(m).Cells1D2(i, n) = cell
                            Next
                        Next
                    Next
                    modCharacter.Character.OnResume()

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show( _
                        String.Format(GetString("error_LoadGame"), filename) & vbCrLf & vbCrLf & ex.Message, _
                        "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
                Finally
                    psFileHandler.theStream.Close()
                    Me.ShowWindow(tmpWindow)
                End Try
                Return state
            End Function
        End Class

        Class Compatibility
            Inherits MarshalByRefObject
            Implements ICompatibility

            Public Sub Jump(ByVal Length As Single, ByVal MinLength As Single, ByVal ScaleSpeed As Single) Implements PlatformStudio.ICompatibility.Jump
                Game.PresetActions.Jump( _
                    Length * 4 / 0.6, _
                    MinLength * 2 / 0.25, _
                    0.5 / ScaleSpeed)
            End Sub
        End Class

        Public NewPresetActions As PresetActions
#End Region

    End Module
End Namespace