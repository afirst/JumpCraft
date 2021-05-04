#Region "Action Data"
<Serializable()> _
Public Structure psActionData
    Dim tb() As psActions.psTriggerBehavior
    Dim ab() As psActions.psActionBehavior

    Friend Sub Init()
        ReDim tb(0)
        ReDim ab(0)
    End Sub

    Function Clone() As psActionData
        Dim tmp As psActionData
        With tmp
            .tb = tb.Clone
            .ab = ab.Clone
        End With
        Return tmp
    End Function
End Structure
#End Region

<Serializable()> _
Public Structure psActions
    Dim Dat As psActionData

#Region "Icon Keys and Enums"
    Enum psValueType
        Number = 0
        Text = 1
        Direction = 2
        Direction2 = 3
        Script = 4
        TileGroup = 5
        YesNo = 6
        Sound = 7
        Music = 8
        Graphic = 9
        Counter = 10
        Timer = 11
        Color = 12
        Choices = 13
        Image = 14
        Movie = 15
        File = 16
    End Enum

    Shared TrigIconKeys() As String
    Shared ActIconKeys() As String
    Shared ParamIconKeys() As String

    Sub IconKeysInit()
        SetTrigIconKeys("(None)", "Always", "Counter", "Timer", _
            "Location", "Tiles", "Groups", "Collect", "Hit Top", _
            "Hit Left", "Hit Right", "Hit Bottom", _
            "Exclusively on Top", "Hit", "Keyboard", "Mouse")
        SetActIconKeys("(None)", "Jump", "Counter", "Health", _
            "Level", "Lives", "Score", "Char Move", "Tile Move", _
            "Quit", "Pause", ".NET Script", "Sound", "Music", "Gravity", _
            "Set Tile Index", "Box", "Line", "Point", "Text", _
            "Properties", "Code Block", "Code Block End", "Code Block Item", _
            "Variable", "Hurt", "Timer", "Checkpoint", "Window", _
            "Win", "Lose", "Drop Tile", "Shoot", "Disintegrate", "Kill", _
            "Movie", "ShootFromChar", "HealthBar", "Animation", _
            "Character", "CharVisible", "Message Box", "Confirm", "Open File", _
            "Open URL", "Clear Highscores")
        SetParamIconKeys("(None)", "Height", "Time", "Text", "Number", _
            "Direction", "Distance", "X Coordinate", "Y Coordinate", _
            "Group", "Yes/No", "Sound", "Music", "Tile Index", "Color", _
            "Choices", "Movie", "File")
    End Sub

    Private Sub SetTrigIconKeys(ByVal ParamArray str() As String)
        TrigIconKeys = str.Clone
    End Sub

    Private Sub SetActIconKeys(ByVal ParamArray str() As String)
        ActIconKeys = str.Clone
    End Sub

    Private Sub SetParamIconKeys(ByVal ParamArray str() As String)
        ParamIconKeys = str.Clone
    End Sub
#End Region

#Region "Initialize"
    Sub Init(Optional ByVal ClearActions As Boolean = True)
        IconKeysInit()
        Dat.Init()
        If ClearActions Then
            ReDim Actions(0)
            ReDim Timers(0)
            ReDim Counters(3)
            Counters(1).Name = "Score"
            Counters(2).Name = "Lives"
            Counters(3).Name = "Health"
        End If
    End Sub

    Sub SetDefGlobals()
        Globals = GetString("globalsCodeComment") & vbCrLf & _
                  "Public Game As PlatformStudio.IGame" '& vbCrLf & _
    End Sub

    Sub SetDefaults()
        SetDefGlobals()
        'vbCrLf & _
        '"'These are some variables that will assist you in" & vbCrLf & _
        '"'accessing current properties and parameters for the" & vbCrLf & _
        '"'trigger you are currently working in." & vbCrLf & _
        '"'All of these variables are set by the game player." & vbCrLf & _
        '"Public curCounter As PlatformStudio.CurrentCounter" & vbCrLf & _
        '"Public curTimer As PlatformStudio.CurrentTimer" & vbCrLf & _
        '"Public curGroup As PlatformStudio.CurrentGroup"
        ReDim Actions(0)
        ReDim Timers(0)
        ReDim Counters(3)
        Counters(1).Name = GetString("counters_Score")
        Counters(2).Name = GetString("counters_Lives")
        Counters(3).Name = GetString("counters_Health")
        AddAction("cval" & 2, "If Current Counter Decreased")
        AddAction("cval" & 2, "Move to Checkpoint")
        AddAction("cval" & 2, "End If")
        AddAction("cval" & 2, "If Current Counter Value...", "<", "0")
        AddAction("cval" & 2, "Lose")
        AddAction("cval" & 2, "End If")
        AddAction("cval" & 3, "If Current Counter Value...", "<=", "0")
        AddAction("cval" & 3, "Modify Lives", "-1")
        AddAction("cval" & 3, "Set Health", "3")
        AddAction("cval" & 3, "Else")
        AddAction("cval" & 3, "If Current Counter Decreased")
        AddAction("cval" & 3, "Hurt")
        AddAction("cval" & 3, "End If")
        AddAction("cval" & 3, "End If")
        SetDefaults2()
        Counters(2).Value = 2
        Counters(3).Value = 3
    End Sub

    Friend Sub SetDefaults2()
        AddAction("aalw", "Set Gravity", "Yes", "1")
        AddAction("aalw", "Set Climbing State", "No")
        AddAction("khol" & Keys.Left, "Move Character", "Left", "4", "Yes")
        AddAction("khol" & Keys.Right, "Move Character", "Right", "4", "Yes")
        AddAction("khol" & Keys.Up, "If Gravity Exists")
        AddAction("khol" & Keys.Up, "Jump")
        AddAction("khol" & Keys.Up, "Else")
        AddAction("khol" & Keys.Up, "Move Character", "Up", "2", "No")
        AddAction("khol" & Keys.Up, "End If")
        AddAction("krel" & Keys.Up, "Stop Jumping")
        AddAction("khol" & Keys.Down, "If Gravity Exists")
        AddAction("khol" & Keys.Down, "Else")
        AddAction("khol" & Keys.Down, "Move Character", "Down", "2", "No")
        AddAction("khol" & Keys.Down, "End If")
        AddAction("kpre" & Keys.P, "Pause Game")
        AddAction("kpre" & Keys.X, "Modify Lives", "-1")
        AddAction("kpre" & Keys.Escape, "Quit Game")
    End Sub

    Sub AddAction(ByVal Trigger As String, ByVal Action As String, ByVal ParamArray Params() As String)
        Dim i As Integer
        For i = 1 To UBound(Game.actions.Dat.ab)
            If Game.actions.Dat.ab(i).Name = Action Then
                AddAction(Trigger, i, Params)
                Exit Sub
            End If
        Next
    End Sub

    Sub AddAction(ByVal Trigger As String, ByVal ActIndex As Integer, ByVal ParamArray Params() As String)
        ReDim Preserve Actions(UBound(Actions) + 1)
        With Actions(UBound(Actions))
            .Trigger = Trigger
            .Action.Type = ActIndex
            If Params Is Nothing OrElse Params.Length = 0 Then
                ReDim .Action.param(UBound(.Action.Behavior.params))
                Dim i As Integer
                For i = 1 To UBound(.Action.param)
                    .Action.param(i) = .Action.Behavior.params(i).DefaultValue
                Next
            Else
                ReDim .Action.param(UBound(Params) + 1)
                Dim i As Integer
                For i = 0 To UBound(Params)
                    .Action.param(i + 1) = Params(i)
                Next
            End If
        End With
    End Sub
#End Region

#Region "Trigger Behavior"
    <Serializable()> _
    Structure psTriggerBehavior
        Dim Name As String
        Dim Description As String
        Dim Icon As Integer
    End Structure
#End Region

#Region "Action Behavior"
    <Serializable()> _
    Structure psActionBehavior
        <Serializable()> _
        Structure psActionParameter
            Dim Name As String
            Dim Description As String
            Dim Icon As Integer
            Dim _ValueType As Byte
            Dim MinValue As Single
            Dim MaxValue As Single
            Dim DecimalPlaces As Byte
            Dim DefaultValue As String
            Dim Units As String
            Property ValueType() As psValueType
                Get
                    Return _ValueType
                End Get
                Set(ByVal Value As psValueType)
                    _ValueType = Value
                End Set
            End Property

            Function Clone() As psActionParameter
                Dim tmp As psActionParameter
                With tmp
                    .DecimalPlaces = DecimalPlaces
                    .DefaultValue = DefaultValue
                    .Description = Description
                    .Icon = Icon
                    .MaxValue = MaxValue
                    .MinValue = MinValue
                    .Name = Name
                    .Units = Units
                    ._ValueType = _ValueType
                End With
                Return tmp
            End Function
        End Structure
        Dim Name As String
        Dim Description As String
        Dim Icon As Integer
        Dim params() As psActionParameter
        Dim Code As String

        Function Clone() As psActionBehavior
            Dim tmp As psActionBehavior, i As Integer
            With tmp
                .Code = Code
                .Description = Description
                .Icon = Icon
                .Name = Name
                ReDim .params(UBound(params))
                For i = 1 To UBound(params)
                    .params(i) = params(i).Clone
                Next
            End With
            Return tmp
        End Function
    End Structure
#End Region

#Region "Timers and Counters"
    <Serializable()> _
    Structure psTimer
        Dim Name As String
        Dim Interval As Single
        Dim Enabled As Boolean
        Dim StartTime As Single

        Function Clone() As psTimer
            Dim tmp As psTimer
            With tmp
                .Name = Name
                .Interval = Interval
                .Enabled = Enabled
            End With
            Return tmp
        End Function
    End Structure

    <Serializable()> _
    Structure psCounter
        Dim Name As String
        Dim _Value As Double

        Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal Value_ As Double)
                _Value = Value_
                With curCounter
                    ._Name = Name
                    ._Increased = False
                    ._Decreased = False
                    ._ChangedBy = 0
                End With
                Game._CounterChanged(GetCounter(Name))
            End Set
        End Property

        Sub Modify(ByVal Value_ As Double, Optional ByVal ModifyEvent As Boolean = True)
            Dim OldValue As Double = _Value
            _Value += Value_
            With curCounter
                ._Name = Name
                ._Increased = (_Value - OldValue > 0)
                ._Decreased = (_Value - OldValue < 0)
                ._ChangedBy = (_Value - OldValue)
            End With
            If ModifyEvent Then Game._CounterChanged(GetCounter(Name))
        End Sub

        Sub RaiseModifiedEvent()
            Game._CounterChanged(GetCounter(Name))
        End Sub

        Friend Sub SetValueWithoutEvents(ByVal Value_ As Double)
            _Value = Value_
        End Sub

        Function Clone() As psCounter
            Dim tmp As psCounter
            With tmp
                .Name = Name
                .SetValueWithoutEvents(Value)
            End With
            Return tmp
        End Function
    End Structure

    Dim Timers() As psTimer
    Dim Counters() As psCounter
#End Region

#Region "Cloning"
    Function Clone() As psActions
        Dim tmp As psActions, i As Integer
        With tmp
            .Dat = Dat.Clone
            ReDim .Actions(UBound(Actions))
            For i = 1 To UBound(Actions)
                .Actions(i) = Actions(i).Clone
            Next
            ReDim .Counters(UBound(Counters))
            For i = 1 To UBound(Counters)
                .Counters(i) = Counters(i).Clone
            Next
            ReDim .Timers(UBound(Timers))
            For i = 1 To UBound(Timers)
                .Timers(i) = Timers(i).Clone
            Next
            .Globals = Globals
        End With
        Return tmp
    End Function
#End Region

#Region "Action Data"
    <Serializable()> _
    Structure psAction
        'Structure psTrigger
        'Private Type As Integer
        'Dim param As String
        'ReadOnly Property Behavior() As psTriggerBehavior
        '    Get
        '        Return psActions.Dat.tb(Type)
        '    End Get
        'End Property
        'End Structure
        Dim Trigger As String

        <Serializable()> _
        Structure psAction2
            Dim Type As Integer
            Dim param() As String

            Function Clone() As psAction2
                Dim tmp As psAction2
                With tmp
                    .Type = Type
                    .param = param.Clone
                End With
                Return tmp
            End Function

            ReadOnly Property Behavior() As psActionBehavior
                Get
                    Return Game.actions.Dat.ab(Type)
                End Get
            End Property
        End Structure
        Dim Action As psAction2

        Function Clone() As psAction
            Dim tmp As psAction
            With tmp
                .Trigger = Trigger
                .Action = Action.Clone
            End With
            Return tmp
        End Function
    End Structure

    Dim Actions() As psAction
    Public Globals As String
#End Region

    Function getClassHeader() As String
        psUI.psControl.rebuildControlNames()
        Dim result As New System.Text.StringBuilder
        For Each str As String In psUI.psControl.ControlNames.Keys
            result.Append("Public " & str & " As psUI.psControl" & vbCrLf)
        Next
        Return result.ToString
    End Function

    Function getClassHeaderLines() As Integer
        Return psUI.psControl.ControlNames.Count + 1
    End Function

    Sub ValidateActions()
        For i As Integer = 1 To UBound(Actions)
            If Actions(i).Action.param IsNot Nothing Then
                Dim behavior As psActionBehavior = Actions(i).Action.Behavior
                Dim numParams As Integer = Actions(i).Action.param.Length
                If numParams <> behavior.params.Length Then
                    ReDim Preserve Actions(i).Action.param(UBound(behavior.params))
                    For j As Integer = numParams To UBound(Actions(i).Action.param)
                        Actions(i).Action.param(j) = behavior.params(j).DefaultValue
                    Next
                End If
            End If
        Next
    End Sub

End Structure

#Region "Current Objects"

Public Class CurrentCounter
    Inherits MarshalByRefObject

    Friend _Name As String
    Friend _Increased As Boolean
    Friend _Decreased As Boolean
    Friend _ChangedBy As Double
    ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
    Property Value() As Double
        Get
            Return Game.actions.Counters(GetCounter(_Name)).Value
        End Get
        Set(ByVal Value As Double)
            Game.actions.Counters(GetCounter(_Name)).SetValueWithoutEvents(Value)
        End Set
    End Property
    ReadOnly Property Increased() As Boolean
        Get
            Return _Increased
        End Get
    End Property
    ReadOnly Property Decreased() As Boolean
        Get
            Return _Decreased
        End Get
    End Property
    ReadOnly Property ChangedBy() As Double
        Get
            Return _ChangedBy
        End Get
    End Property
End Class

Public Class CurrentTimer
    Inherits MarshalByRefObject

    Friend _Name As String
    ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
    Property Interval() As Integer
        Get
            Return Game.actions.Timers(GetTimer(_Name)).Interval
        End Get
        Set(ByVal Value As Integer)
            Game.actions.Timers(GetTimer(_Name)).Interval = Value
        End Set
    End Property
    Property Enabled() As Boolean
        Get
            Return Game.actions.Timers(GetTimer(_Name)).Enabled
        End Get
        Set(ByVal Value As Boolean)
            Game.actions.Timers(GetTimer(_Name)).Enabled = Value
        End Set
    End Property
End Class

Public Class CurrentGroup
    Inherits MarshalByRefObject

    Friend _Name As String
    Friend _CurTileX As Integer
    Friend _CurTileY As Integer
    Friend _CurTileW As Integer
    Friend _CurTileH As Integer
    Friend _CurTileHP As Integer
    Friend _CurTileFrame As Integer
    Friend _CurTileAnimIndex As Integer
    Friend _CurTileName As String
    ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
    ReadOnly Property CurTileX() As Integer
        Get
            Return _CurTileX
        End Get
    End Property
    ReadOnly Property CurTileY() As Integer
        Get
            Return _CurTileY
        End Get
    End Property
    ReadOnly Property CurTileW() As Integer
        Get
            Return _CurTileW
        End Get
    End Property
    ReadOnly Property CurTileH() As Integer
        Get
            Return _CurTileH
        End Get
    End Property
    ReadOnly Property CurTileHP() As Integer
        Get
            Return _CurTileHP
        End Get
    End Property
    ReadOnly Property CurTileVisible() As Boolean
        Get
            Return Game.Math.Collide_BoxBox(CurTileX, CurTileY, CurTileW, CurTileH, Game.cam.X, Game.cam.Y, Game.cam.w, Game.cam.h)
        End Get
    End Property
    ReadOnly Property CurTileFrame() As Integer
        Get
            Return _CurTileFrame
        End Get
    End Property
    ReadOnly Property CurTileAnimIndex() As Integer
        Get
            Return _CurTileAnimIndex
        End Get
    End Property
    ReadOnly Property CurTileName() As String
        Get
            Return _CurTileName
        End Get
    End Property
End Class

Public Module psmodCurrentObjects
    Public curCounter As New CurrentCounter
    Public curTimer As New CurrentTimer
    Public curGroup As New CurrentGroup
End Module

#End Region

Public Interface IExecuteTrigger
    Sub Always()
    Sub CounterValueChanged(ByVal CounterName As String)
    Sub CounterValueChanged(ByVal CounterIndex As Integer)
    Sub TimerTick(ByVal TimerName As String)
    Sub TimerTick(ByVal TimerIndex As Integer)
    Sub GroupHit(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHit()
    Sub GroupHitLeft(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHitLeft()
    Sub GroupHitRight(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHitRight()
    Sub GroupHitTop(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHitTop()
    Sub GroupHitBottom(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHitBottom()
    Sub GroupExclusivelyOnTop(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupExclusivelyOnTop()
    Sub GroupCollect(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupCollect()
    Sub GroupShot(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupShot()
    Sub GroupDestroyed(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupDestroyed()
    Sub GroupChangeDirections(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupChangeDirections()
    Sub GroupChangeDirectionsFwd(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupChangeDirectionsFwd()
    Sub GroupChangeDirectionsBkwd(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupChangeDirectionsBkwd()
    Sub GroupHover(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupHover()
    Sub GroupClick(ByVal Level As Integer, ByVal GroupName As String)
    Sub GroupClick()
    Sub TileHit(ByVal TileName As String)
    Sub TileHit(ByVal TileIndex As Integer)
    Sub TileHit()
    Sub TileHitLeft(ByVal TileName As String)
    Sub TileHitLeft(ByVal TileIndex As Integer)
    Sub TileHitLeft()
    Sub TileHitRight(ByVal TileName As String)
    Sub TileHitRight(ByVal TileIndex As Integer)
    Sub TileHitRight()
    Sub TileHitTop(ByVal TileName As String)
    Sub TileHitTop(ByVal TileIndex As Integer)
    Sub TileHitTop()
    Sub TileHitBottom(ByVal TileName As String)
    Sub TileHitBottom(ByVal TileIndex As Integer)
    Sub TileHitBottom()
    Sub TileExclusivelyOnTop(ByVal TileName As String)
    Sub TileExclusivelyOnTop(ByVal TileIndex As Integer)
    Sub TileExclusivelyOnTop()
    Sub TileCollect(ByVal TileName As String)
    Sub TileCollect(ByVal TileIndex As Integer)
    Sub TileCollect()
    Sub TileShot(ByVal TileName As String)
    Sub TileShot(ByVal TileIndex As Integer)
    Sub TileShot()
    Sub TileDestroyed(ByVal TileName As String)
    Sub TileDestroyed(ByVal TileIndex As Integer)
    Sub TileDestroyed()
    Sub TileChangeDirections(ByVal TileName As String)
    Sub TileChangeDirections(ByVal TileIndex As Integer)
    Sub TileChangeDirections()
    Sub TileChangeDirectionsFwd(ByVal TileName As String)
    Sub TileChangeDirectionsFwd(ByVal TileIndex As Integer)
    Sub TileChangeDirectionsFwd()
    Sub TileChangeDirectionsBkwd(ByVal TileName As String)
    Sub TileChangeDirectionsBkwd(ByVal TileIndex As Integer)
    Sub TileChangeDirectionsBkwd()
    Sub TileHover(ByVal TileName As String)
    Sub TileHover(ByVal TileIndex As Integer)
    Sub TileHover()
    Sub TileClick(ByVal TileName As String)
    Sub TileClick(ByVal TileIndex As Integer)
    Sub TileClick()
    Sub LocationEnter(ByVal Level As Integer, ByVal LocationName As String)
    Sub LocationExit(ByVal Level As Integer, ByVal LocationName As String)
    Sub LocationInside(ByVal Level As Integer, ByVal LocationName As String)
    Sub KeyboardPressKey(ByVal KeyCode As Integer)
    Sub KeyboardReleaseKey(ByVal KeyCode As Integer)
    Sub KeyboardHoldKey(ByVal KeyCode As Integer)
    Sub MouseLeftButtonPress()
    Sub MouseLeftButtonRelease()
    Sub MouseLeftButtonHold()
    Sub MouseRightButtonPress()
    Sub MouseRightButtonRelease()
    Sub MouseRightButtonHold()
    Sub MouseMiddleButtonPress()
    Sub MouseMiddleButtonRelease()
    Sub MouseMiddleButtonHold()
    Sub MouseMove()
    Sub GeneralBeginGame()
    Sub GeneralBeginLevel()
    Sub GeneralBeginLevel(ByVal Level As Integer)
    Sub CharJump()
    Sub CharHitHeadWhileJumping()
    Sub CharFall()
    Sub CharLand()
End Interface

Public Interface IGame
    Sub Jump(ByVal Height As Single, ByVal MinHeight As Single, ByVal Time As Single)
    Sub StopJumping()
    Sub ModifyCounter(ByVal Counter As String, ByVal Value As Double)
    Sub ModifyHealth(ByVal Value As Double)
    Sub ModifyLevel(ByVal Value As Integer)
    Sub ModifyLives(ByVal Value As Integer)
    Sub ModifyScore(ByVal Value As Double)
    Sub MoveCharacter(ByVal Direction As String, ByVal Speed As Single, Optional ByVal Walking As Boolean = True)
    Sub MoveTile(ByVal Group As String, ByVal Direction As String, ByVal Distance As Integer, ByVal Time As Single, Optional ByVal MoveBack As Boolean = True)
    Sub PauseGame()
    Sub PlayMusic(ByVal Filename As String, ByVal Volume As Byte)
    Sub PlaySound(ByVal Filename As String, ByVal Volume As Byte, ByVal Pan As Short, ByVal Frequency As Byte, Optional ByVal StopOtherSounds As Boolean = False)
    Sub QuitGame()
    Sub SetCounter(ByVal Counter As String, ByVal Value As Double)
    Sub SetGravity(ByVal GravityExists As Boolean, ByVal ScaleSpeed As Single)
    Sub SetHealth(ByVal Value As Double)
    Sub SetLevel(ByVal Value As Integer)
    Sub SetLives(ByVal Value As Integer)
    Sub SetPosition(ByVal X As Integer, ByVal Y As Integer)
    Sub SetScore(ByVal Value As Double)
    Sub SetTileIndex(ByVal Group As String, Optional ByVal TileName As String = "", Optional ByVal Frame As Integer = -1, Optional ByVal AnimationIndex As Integer = -1, Optional ByVal HitPoints As Integer = -1, Optional ByVal ModifyHitpoints As Integer = 0)
    Sub Hurt(Optional ByVal ImmunityLength As Single = 4, Optional ByVal VisualEffect As String = "Blink", Optional ByVal EffectCycleLength As Single = 0.25)
    Sub StopAllSounds()
    Sub SetCheckpoint()
    Sub SetCheckpoint(ByVal X As Integer, ByVal Y As Integer)
    Sub MoveToCheckpoint()
    Property CharacterX() As Integer
    Property CharacterY() As Integer
    Sub Win()
    Sub Lose()
    Sub ShowWindow(ByVal WindowName As String)
    Sub ShowWindow(ByVal WindowIndex As Integer)
    Sub DropCurrentTile(ByVal WaitLength As Single, ByVal DropScaleSpeed As Single, Optional ByVal Disappear As Boolean = True)
    Sub SetTileFrame(ByVal Group As String, ByVal Frame As Integer)
    Sub DisintegrateCurrentTile(ByVal WaitLength As Single)
    Sub SetClimbingState(ByVal Climbing As Boolean)
    Function GravityExists() As Boolean
    Sub Shoot(ByVal FromTile As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal Accuracy As Integer = 100, Optional ByVal MaxDistance As Double = 1000, Optional ByVal OnlyIfVisible As Boolean = False, Optional ByVal HitEverything As Boolean = False, Optional ByVal Firepower As Integer = 1)
    Sub ShootFromGroup(ByVal Group As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal Accuracy As Integer = 100, Optional ByVal MaxDistance As Double = 1000, Optional ByVal OnlyIfVisible As Boolean = False, Optional ByVal HitEverything As Boolean = False, Optional ByVal Firepower As Integer = 1)
    Function GetHealth() As Double
    Function GetLevel() As Integer
    Function GetLives() As Integer
    Function GetScore() As Double
    Function GetCounter(ByVal Counter As String) As Double
    ReadOnly Property MouseX() As Integer
    ReadOnly Property MouseY() As Integer
    ReadOnly Property MouseLButton() As Boolean
    ReadOnly Property MouseRButton() As Boolean
    ReadOnly Property MouseMButton() As Boolean
    ReadOnly Property CharFacingRight() As Boolean
    ReadOnly Property CharJumping() As Boolean
    ReadOnly Property CharFalling() As Boolean
    Sub ShootFromPoint(ByVal BulletLeftEdge_Pixels As Integer, ByVal BulletTopEdge_Pixels As Integer, ByVal BulletTile As String, ByVal Direction As String, ByVal Speed As Single, Optional ByVal MapLayer As Byte = 2)
    ReadOnly Property CharacterW() As Integer
    ReadOnly Property CharacterH() As Integer
    Function ConvPixelsToTilesX(ByVal Pixels As Integer) As Double
    Function ConvTilesToPixelsX(ByVal Tiles As Double) As Integer
    Function ConvPixelsToTilesY(ByVal Pixels As Integer) As Double
    Function ConvTilesToPixelsY(ByVal Tiles As Double) As Integer
    Sub SetTileAnimation(ByVal Group As String, ByVal AnimationIndex As Integer)
    Sub SetTileAnimation(ByVal Group As String, ByVal AnimationName As String)
    ReadOnly Property CharAffectedByGravity() As Boolean
    ReadOnly Property GetWindow(ByVal WindowName As String) As psUI.psWindows.psWindow
    ReadOnly Property GetControl(ByVal WindowName As String, ByVal ControlText As String) As psUI.psControl
    ReadOnly Property Camera() As psGame.psCamera
    ReadOnly Property Math() As psGame.psMath
    ReadOnly Property Properties() As psGame.psGameProperties
    ReadOnly Property Drawing() As psDraw
    Function GetLevelName() As String
    Sub StartTimer(ByVal TimerName As String)
    Sub StopTimer(ByVal TimerName As String)
    Function ExecuteTrigger() As IExecuteTrigger
    Sub ExecuteTriggerString(ByVal ActionCode As String)
    Sub KillCurrentTile()
    Sub KillTile(ByVal Group As String)
    Sub PlayMovie(ByVal Filename As String, Optional ByVal Volume As Integer = 100, Optional ByVal PressKeyToSkip As Boolean = True, Optional ByVal x As Integer = 0, Optional ByVal y As Integer = 0, Optional ByVal w As Integer = 0, Optional ByVal h As Integer = 0, Optional ByVal ClearBackground As Boolean = True)
    Function GetTileIndex(ByVal x As Integer, ByVal y As Integer) As Integer
    Function GetTileName(ByVal x As Integer, ByVal y As Integer) As Integer
    Property AutoUpdateCamera() As Boolean
    ReadOnly Property FPS() As Double
    ReadOnly Property TimeElapsed() As Double
    ReadOnly Property Compatibility() As ICompatibility
    Function ShootFromCharacter(ByVal BulletTile As String, ByVal Direction As String, ByVal Firepower As Byte, ByVal Range As Integer, ByVal Speed As Double, ByVal Delay As Double, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0) As Boolean
    Sub DrawHealthBarForCurrentTile(ByVal BackColor As Color, ByVal BarColor As Color, ByVal BorderColor As Color, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub DrawHealthBarForCurrentTile(ByVal BackColor As Integer, ByVal BarColor As Integer, ByVal BorderColor As Integer, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub DrawHealthBarForTile(ByVal Group As String, ByVal BackColor As Color, ByVal BarColor As Color, ByVal BorderColor As Color, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub DrawHealthBarForTile(ByVal Group As String, ByVal BackColor As Integer, ByVal BarColor As Integer, ByVal BorderColor As Integer, Optional ByVal Thickness As Integer = 6, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub ShootAnythingFromGroup(ByVal Group As String, ByVal BulletTile As String, ByVal Direction As String, ByVal Firepower As Byte, ByVal Range As Integer, ByVal Speed As Double, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub DrawAnimationAtCurrentTile(ByVal AnimationSourceTile As String, ByVal AnimIndex As Integer, Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
    Sub Scroll(ByVal Direction As String, ByVal Speed As Double)
    Sub MoveCameraToDefaultPosition(ByVal OffsetX As Integer, ByVal OffsetY As Integer)
    Sub EnsureCharacterIsVisible()
    Sub ShowMessageBox(ByVal title As String, ByVal message As String, ByVal icon As String)
    Function Confirm(ByVal title As String, ByVal message As String) As Boolean
    Sub OpenFile(ByVal filename As String)
    Sub OpenURL(ByVal url As String)
    Sub ExitProgram()
    Sub ClearHighscores()
    Sub SetTileAtLocation(ByVal xtiles As Integer, ByVal ytiles As Integer, Optional ByVal newTileName As String = Nothing, Optional ByVal newFrame As Integer = -1, Optional ByVal newAnimationIndex As Integer = -1, Optional ByVal newGroup As String = Nothing)
    Sub SetTileAtLocation(ByVal xtiles As Integer, ByVal ytiles As Integer, ByVal layer As Integer, Optional ByVal newTileName As String = Nothing, Optional ByVal newFrame As Integer = -1, Optional ByVal newAnimationIndex As Integer = -1, Optional ByVal newGroup As String = Nothing)
    Sub SetCharacterAnimation(ByVal animIndex As Integer, ByVal stopped As Boolean)
    Sub SetCharacterAnimationToDefault()
    ReadOnly Property CharCurrentAnim() As Integer
    ReadOnly Property UsingCustomAnimation() As Boolean
    ReadOnly Property CharAnimStopped() As Boolean
    Sub Save(Optional ByVal state As String = "")
    Function Load() As String
End Interface