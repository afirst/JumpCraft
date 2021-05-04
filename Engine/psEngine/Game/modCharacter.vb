Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer
Imports System.Collections.Generic

Namespace GamePlayer
    Public Module modCharacter
        Public CurTile As TilePtr

#Region "Drop Tiles"
        <Serializable()> _
        Class DropTile
            Public Ptr As TilePtr
            Public WaitStart As Single
            Public WaitLength As Single
            Public StartedFalling As Boolean
            Public FallStart As Single
            Public Falling As Boolean
            Public Drop As Boolean
            Public Disappear As Boolean
            Public Y As Single
            Public DropSpeed As Single
            Public AnimIndex As Integer
            Public AnimKey As Single
            Public DirX As Single, DirY As Single
        End Class

        Public DropTiles As New List(Of DropTile)

        Sub UpdateDropTiles()
            Dim DeleteDropTile As Boolean
            For i As Integer = 0 To DropTiles.Count - 1
                If i >= DropTiles.Count Then Exit For
                DeleteDropTile = False
                With DropTiles(i)
                    If Timer - .WaitStart >= .WaitLength Then
                        If .Drop = False Then
                            DeleteDropTile = DisappearTile1(i)
                        Else
                            Dim tmpX As Integer, tmpY As Single

                            Dim tmp As psMapTile = .Ptr.GetTile
                            Dim tmpPath As psPath = tmp.Path

                            'Get the current position
                            tmpX = DropTiles(i).Ptr.X
                            If DropTiles(i).StartedFalling Then
                                tmpY = DropTiles(i).Y
                            Else
                                tmpY = DropTiles(i).Ptr.Y
                                DropTiles(i).StartedFalling = True
                            End If

                            'Updates the current position
                            If .Falling = False Then
                                .Falling = True
                                .FallStart = Timer
                            End If
                            Dim TotalY As Double = (.DropSpeed * 3 * Game.tileH * TimeElapsed * (2 * (Timer - (.FallStart - 1))))
                            For j As Integer = 1 To Math.Ceiling(TotalY)
                                If j > TotalY Then
                                    tmpY += (Math.Ceiling(TotalY) - TotalY)
                                Else
                                    tmpY += 1
                                End If
                                If IsTileColliding(.Ptr, tmpX, tmpY, .Ptr.Width, .Ptr.Height, True) Then
                                    tmpY = Math.Round(tmpY)
                                    While IsTileColliding(.Ptr, tmpX, tmpY, .Ptr.Width, .Ptr.Height, True)
                                        tmpY -= 1
                                    End While
                                    .Falling = False
                                    Exit For
                                End If
                            Next
                            .Y = tmpY

                            'Sets the current position
                            With tmpPath
                                .Exists = True
                                .Speed = 0
                                ReDim .Pts(1)
                                .Pts(0).Init()
                                .Pts(1).Init()
                                For j As Byte = 0 To 3
                                    .Pts(0).XPoint(j) = tmpX + DropTiles(i).Ptr.Width * 0.5
                                    .Pts(0).YPoint(j) = tmpY + DropTiles(i).Ptr.Height * 0.5
                                    .Pts(0).Length = 1
                                Next
                                .Pts(1) = .Pts(0).Clone
                            End With

                            tmp.Path = tmpPath
                            tmp.UpdatedPath(.Ptr.Index, .Ptr.Layer)
                            .Ptr.GetTile = tmp

                            'Make it a path tile
                            Dim bAlreadyAPathTiles As Boolean
                            For x As Integer = 0 To PathTiles.Count - 1
                                If PathTiles(x).Index = .Ptr.Index And PathTiles(x).Layer = .Ptr.Layer Then
                                    bAlreadyAPathTiles = True
                                    Exit For
                                End If
                            Next
                            If bAlreadyAPathTiles = False Then
                                PathTiles.Add(New TilePtr(.Ptr.Index, .Ptr.Layer))
                            End If

                            If .Falling = False And .Disappear Then
                                DeleteDropTile = DisappearTile1(i)
                            End If
                        End If
                    End If
                End With
                If DeleteDropTile Then
                    DropTiles.RemoveAt(i)
                    i -= 1
                End If
            Next
        End Sub

        Function IsTileColliding(ByVal Ptr As TilePtr, ByVal tmpX As Integer, ByVal tmpY As Integer, ByVal tmpWidth As Integer, ByVal tmpHeight As Integer, ByVal OnlyForeground As Boolean) As Boolean
            Return IsTileColliding(Ptr.GetTile, tmpX, tmpY, tmpWidth, tmpHeight, True, OnlyForeground, Ptr)
        End Function

        Public CollisionTile As TilePtr
        Function IsTileColliding(ByVal Tile As psMapTile, ByVal tmpX As Integer, ByVal tmpY As Integer, ByVal tmpWidth As Integer, ByVal tmpHeight As Integer, ByVal CheckCharTile As Boolean, ByVal OnlyForeground As Boolean, ByVal ParamArray Exclude() As TilePtr) As Boolean
            tmpWidth -= 1
            tmpHeight -= 1

            'Stay in bounds of map
            If tmpX < 0 Or tmpY < 0 Or tmpX + tmpWidth > Game.CurMapWidth * Game.tileW Or tmpY + tmpHeight > Game.CurMapHeight * Game.tileH Then
                CollisionTile = TilePtr.Empty
                Return True
            End If

            'Get surrounding tiles
            Dim tiles As New List(Of TilePtr)
            Dim minK As Integer = 1
            Dim maxK As Integer = 3
            If OnlyForeground Then minK = 2 : maxK = 2
            For i As Integer = (tmpX \ Game.tileW - Game.tileset.MaxTileW \ Game.tileW) - 1 To Math.Ceiling(tmpX / Game.tileW) + Math.Ceiling(tmpWidth / Game.tileW) + 1
                For j As Integer = (tmpY \ Game.tileH - Game.tileset.MaxTileH \ Game.tileH) To Math.Ceiling(tmpY / Game.tileH) + Math.Ceiling(tmpHeight / Game.tileH) + 1
                    If i > 0 And j > 0 And i <= Game.CurMapWidth And j <= Game.CurMapHeight Then
                        For k As Integer = minK To maxK
                            With Game.CurMap.Cells2(i, j, k)
                                If .tile > 0 Then
                                    If .Behavior = psTile.TileBehavior.Solid Or .Behavior = psTile.TileBehavior.Ledge Then
                                        tiles.Add(New TilePtr(Game.CurMap.Get1DIndex(i, j), k))
                                    End If
                                End If
                            End With
                        Next
                    End If
                Next
            Next
            For i As Integer = 0 To PathTiles.Count - 1
                If PathTiles(i).GetTile.tile > 0 AndAlso PathTiles(i).GetTile.Path.Exists AndAlso (PathTiles(i).GetTile.Behavior = psTile.TileBehavior.Solid Or PathTiles(i).GetTile.Behavior = psTile.TileBehavior.Ledge) Then
                    tiles.Add(PathTiles(i))
                End If
            Next

            'Check collision
            Dim tmpY2 As Integer, tmpHeight2 As Integer
            For i As Integer = 0 To tiles.Count - 1
                Dim isExcluded As Boolean = False
                For j As Integer = 0 To Exclude.Length - 1
                    If Exclude(j) IsNot Nothing Then
                        If tiles(i).Index = Exclude(j).Index AndAlso tiles(i).Layer = Exclude(j).Layer Then
                            isExcluded = True
                        End If
                    End If
                Next
                If Not isExcluded Then
                    If tiles(i).GetTile.tile > 0 AndAlso Not tiles(i).GetTile.Invisible Then

                        'Only look at the bottom part of the tile
                        'if we are looking at a ledge
                        'If TPtr(i).GetTile.Behavior = psTile.TileBehavior.Ledge Then
                        '    tmpY2 = tmpY + tmpHeight - 1
                        '    tmpHeight2 = 1
                        'Else
                        tmpY2 = tmpY
                        tmpHeight2 = tmpHeight
                        'End If

                        'Collision
                        If Util.Collision(tmpX, tmpY2, tmpWidth, tmpHeight2, tiles(i)) Then
                            CollisionTile = tiles(i)
                            Return True
                        End If

                    End If
                End If
            Next

            'Check char tile
            If CheckCharTile Then
                If Game.Math.Collide_BoxBox(New Rectangle(tmpX, tmpY, tmpWidth, tmpHeight), Character.GetRect) Then
                    CollisionTile = TilePtr.Empty
                    Return True
                End If
            End If
        End Function

        'Returns if the tile was deleted or not
        Function DisappearTile1(ByVal i As Integer) As Boolean
            With DropTiles(i)
                If .AnimIndex > 0 Then
                    'Do not delete the tile until
                    'the disappear animation is done
                    For x As Integer = 1 To UBound(Anim)
                        If Anim(x).Key = .AnimKey Then
                            Return False
                        End If
                    Next
                    DisappearTile2(i)
                    Return True
                Else
                    'Disappear animation
                    If Game.tileset.tiles(.Ptr.GetTile.tile).Anim(1).Interval > 0 Then
                        ReDim Preserve Anim(UBound(Anim) + 1)
                        Anim(UBound(Anim)).Init(.Ptr.X, .Ptr.Y, .Ptr.GetTile.tile, Game.tileset.tiles(.Ptr.GetTile.tile).Anim(1).StartFrame, 1, .Ptr.GetTile.Frame)
                        .AnimIndex = UBound(Anim)
                        .AnimKey = Rnd(1)
                        Anim(UBound(Anim)).Key = .AnimKey
                        Dim tmp As psMapTile = .Ptr.GetTile
                        tmp.Invisible = True
                        .Ptr.GetTile = tmp
                    Else
                        'No disappear animation = delete tile immediately
                        DisappearTile2(i)
                        Return True
                    End If
                End If
            End With
            Return False
        End Function

        Sub DisappearTile2(ByVal i As Integer)
            With DropTiles(i)
                'Move the tile away from any possible view
                'so it appears to have disappeared
                Dim tmp As psMapTile = .Ptr.GetTile
                Dim tmpPath As psPath = tmp.Path
                With tmpPath
                    .Exists = True
                    .Speed = 0
                    ReDim .Pts(1)
                    .Pts(0).Init()
                    .Pts(1).Init()
                    For j As Byte = 0 To 3
                        .Pts(0).XPoint(j) = -10000000
                        .Pts(0).YPoint(j) = 10000000
                        .Pts(0).Length = 1
                    Next
                    .Pts(1) = .Pts(0).Clone
                    .Pts(1).Length = -5
                End With
                tmp.Path = tmpPath
                tmp.UpdatedPath(.Ptr.Index, .Ptr.Layer)
                DropTiles(i).Ptr.GetTile = tmp
            End With
        End Sub
#End Region

#Region "Bullet Tiles"
        <Serializable()> _
        Class BulletTile
            Public Tile As psMapTile
            Public Layer As Byte
            Public X, Y, StartX, StartY As Single
            Public DirX, DirY As Single

            'Is the character shooting or is an enemy shooting?
            Public FromCharacter As Boolean
            Public HitEverything As Boolean
            Public Firepower As Byte

            Public MaxDistance As Integer

            Public Source As TilePtr

            Public ReadOnly Property Width() As Integer
                Get
                    Return Game.tileset.tiles(Tile.tile).sectionw
                End Get
            End Property

            Public ReadOnly Property Height() As Integer
                Get
                    Return Game.tileset.tiles(Tile.tile).sectionh
                End Get
            End Property
        End Class
        Public BulletTiles As New List(Of BulletTile)

        Sub UpdateBulletTiles()
            For i As Integer = 0 To BulletTiles.Count - 1
                'Move the tile
                BulletTiles(i).X += TimeElapsed * Game.tileW * BulletTiles(i).DirX
                BulletTiles(i).Y += TimeElapsed * Game.tileH * BulletTiles(i).DirY
            Next
        End Sub

        Sub CheckBulletTilesForCollision()
            Dim tmpI As Integer = -1
            For i As Integer = 0 To BulletTiles.Count - 1
                tmpI += 1
                If i >= BulletTiles.Count Then Exit For
                With BulletTiles(i)
                    'Check for collision
                    If .MaxDistance > 0 AndAlso Game.Math.Dist(.StartX, .StartY, .X, .Y) > .MaxDistance Then GoTo DeleteBullet
                    If .Tile.tile = 0 OrElse (Game.CurMap.TempEntry(tmpI) And Game.CurMap.Cells1D(tmpI, 4) = 0) OrElse IsTileColliding(.Tile, .X, .Y, .Width, .Height, True, False, .Source) Then
                        'Collision occured

                        If (.FromCharacter Or .HitEverything) AndAlso CollisionTile.Layer > 0 Then
                            If Game.tileset.tiles(CollisionTile.GetTile.tile).HitPoints > 0 Then
                                'Reduce hitpoints
                                Dim tmpTile As psMapTile = CollisionTile.GetTile
                                tmpTile.HitPoints = Math.Max(0, CInt(tmpTile.HitPoints) - .Firepower)

                                'Invoke shoot triggers
                                CurTile = CollisionTile
                                SetCurGroup(tmpTile.Group, CurTile.X, CurTile.Y, CurTile.Width, CurTile.Height, CurTile.GetTile.HitPoints, CurTile.GetTile.Frame, CurTile.GetTile.AnimIndex, CurTile.GetTile.GetTile.name)
                                ActionProcessor.ProcessActions("tsho" & tmpTile.tile, curGroup)
                                If tmpTile.Group <> "" Then
                                    ActionProcessor.ProcessActions("gsho" & LevelText & tmpTile.Group, curGroup)
                                End If

                                'Check to see if tile is "dead"
                                If tmpTile.HitPoints = 0 Then
                                    CType(Game.PresetActions, PresetActions).kill_Tile(CollisionTile.Index, CollisionTile.Layer)

                                    'Delete the tmpTile
                                    tmpTile = New psMapTile
                                End If

                                'Update the map
                                CollisionTile.GetTile = tmpTile
                            End If
                        ElseIf (.FromCharacter Or .HitEverything) AndAlso CollisionTile.Layer < 0 Then
                            'Out of bounds: delete the bullet
                        ElseIf .FromCharacter Then
                            'Collide with character: do nothing
                            GoTo [Continue]
                        End If

DeleteBullet:

                        'Disappear
                        If .Tile.tile > 0 AndAlso Game.tileset.tiles(.Tile.tile).Anim(1).Interval > 0 Then
                            ReDim Preserve Anim(UBound(Anim) + 1)
                            Anim(UBound(Anim)).Init(.X, .Y, .Tile.tile, Game.tileset.tiles(.Tile.tile).Anim(1).StartFrame, 1, .Tile.Frame)
                        End If

                        'Delete the bullet tile
                        BulletTiles.RemoveAt(i)
                        i -= 1
                    End If
                End With
[Continue]:
            Next
        End Sub
#End Region

#Region "Tile Pointer"
        <Serializable()> _
        Class TilePtr
            Public Shared Empty As TilePtr = New TilePtr(0, 0)

            Private _index As Integer, _layer As Integer
            Private i, j As Integer

            Public OldX As Single, OldY As Single
            Public Flip As Boolean
            Public BackTracking, DirChanged As Boolean

            Sub New(ByVal index As Integer, ByVal layer As Integer)
                Me.Index = index
                Me.Layer = layer
            End Sub

            Public Property Index() As Integer
                Get
                    Return _index
                End Get
                Private Set(ByVal Value As Integer)
                    _index = Value
                    With Game.CurMap.Conv1DTo2D(Value)
                        i = .X
                        j = .Y
                    End With
                End Set
            End Property

            Public Property Layer() As Integer
                Get
                    Return _layer
                End Get
                Private Set(ByVal Value As Integer)
                    _layer = Value
                End Set
            End Property

            Public Property GetTile() As psMapTile
                Get
                    Return Game.CurMap.Cells1D2(Index, Layer)
                End Get
                Set(ByVal Value As psMapTile)
                    Game.maps(Game.CurMapIndex).Cells1D2(Index, Layer) = Value
                End Set
            End Property

            Public ReadOnly Property X() As Integer
                Get
                    If GetTile.Path.Exists Then
                        Return GetTile.PathX
                    Else
                        Return (i - 1) * Game.tileW
                    End If
                End Get
            End Property

            Public ReadOnly Property Y() As Integer
                Get
                    If GetTile.Path.Exists Then
                        Return GetTile.PathY
                    Else
                        Return (j - 1) * Game.tileH
                    End If
                End Get
            End Property

            Public ReadOnly Property Width() As Integer
                Get
                    Return GetTile.w
                End Get
            End Property

            Public ReadOnly Property Height() As Integer
                Get
                    Return GetTile.h
                End Get
            End Property

            Public ReadOnly Property Rectangle() As Rectangle
                Get
                    Return New Rectangle(X, Y, Width, Height)
                End Get
            End Property

            Public Overrides Function Equals(ByVal obj As Object) As Boolean
                Dim tp As TilePtr = obj
                Return Index = tp.Index AndAlso Layer = tp.Layer
            End Function

            Public Overrides Function GetHashCode() As Integer
                Return Index.GetHashCode() Xor Layer.GetHashCode()
            End Function
        End Class
#End Region

        Structure psCharacter

#Region "Character Tile Pointer and Initialization"
            Private _CharTile As psMapTile
            Private _layer As Integer, _tile As Integer

            ReadOnly Property Layer() As Integer
                Get
                    Return _layer
                End Get
            End Property

            ReadOnly Property Tile() As Integer
                Get
                    Return _tile
                End Get
            End Property

            ReadOnly Property CharTile() As psMapTile
                Get
                    Return _CharTile
                End Get
            End Property

            Sub SetMapTileLocation(ByVal layer_ As Integer, ByVal tile_ As Integer)
                _layer = layer_
                _tile = tile_
                _CharTile = Game.CurMap.Cells1D2(Tile, Layer)
                If _CharTile.tile = 0 Then _CharTile.tile = CharTex
                With Game.CurMap.Conv1DTo2D(Tile)
                    rawX = (.X - 1) * Game.tileW
                    rawY = (.Y - 1) * Game.tileH
                    SetCheckpoint(.X, .Y)
                End With
                TSolid = GetSurroundingSolidTiles(PtrType.Solid)
                TNoLedge = GetSurroundingSolidTiles(PtrType.NoLedges)
                TCollect = GetSurroundingSolidTiles(PtrType.Collectable)
                TSolidWithoutNoGravity = GetSurroundingSolidTiles(PtrType.SolidWithoutNoGravity)
                _CharTile.Frame = Game.tileset.tiles(_CharTile.tile).Anim(_CharTile.AnimIndex).StartFrame
                ReDim loc(UBound(Game.CurMap.loc.Locations))
                DropTiles.Clear()
                BulletTiles.Clear()
                GravitySpeed = 1
                str5DigitMapNum = Format(Game.CurMapIndex, "00000")
                Blinking = False
                Wait = False
                ReDim PushedBy(0)
                ReDim PushDir(0)
            End Sub
#End Region

#Region "Location and Size"
            Public Shared CharBounds() As Rectangle
            Public rawX As Double, rawY As Double

            ReadOnly Property rawWidth() As Integer
                Get
                    Return CharTile.w
                End Get
            End Property

            ReadOnly Property rawHeight() As Integer
                Get
                    Return CharTile.h
                End Get
            End Property

            Function GetRect() As Rectangle
                Return New Rectangle(x, y, Width, Height)
            End Function

            ReadOnly Property CurBounds() As Rectangle
                Get
                    If CharTile.Frame >= CharBounds.Length Then
                        Return CharBounds(1)
                    End If
                    Return CharBounds(CharTile.Frame)
                End Get
            End Property

            Property x() As Double
                Get
                    Return rawX + CurBounds.X
                End Get
                Set(ByVal Value As Double)
                    rawX = Value - CurBounds.X
                End Set
            End Property

            Property y() As Double
                Get
                    Return rawY + CurBounds.Y
                End Get
                Set(ByVal Value As Double)
                    rawY = Value - CurBounds.Y
                End Set
            End Property

            ReadOnly Property Width() As Integer
                Get
                    Return CurBounds.Width
                End Get
            End Property

            ReadOnly Property Height() As Integer
                Get
                    Return CurBounds.Height
                End Get
            End Property

            Dim Checkpoint As Point
            Sub SetCheckpoint(ByVal _x As Integer, ByVal _y As Integer)
                Checkpoint = New Point(_x, _y)
            End Sub

            Sub MoveToCheckpoint()
                ResetFallenTiles()
                rawX = (Checkpoint.X - 1) * Game.tileW
                rawY = (Checkpoint.Y - 1) * Game.tileH
                CurDirection = ""
                Wait = True
            End Sub
#End Region

#Region "Movement"
            Public CurDirection As String
            Public Walking As Boolean
            Public FacingRight As Boolean
            Public AffectedByGravity As Boolean
            Public GravitySpeed As Single
            Public WasClimbing As Boolean
            Public CurrentlyClimbing As Boolean
            Public ShootStart As Single

            Private _Climbing As Boolean
            Property Climbing() As Boolean
                Get
                    Return _Climbing
                End Get
                Set(ByVal Value As Boolean)
                    _Climbing = Value
                End Set
            End Property

            Dim CantWalk As Boolean, NetWalk As Integer
            Sub WalkMove(ByVal _x As Double, ByVal _y As Double, Optional ByVal Walk As Boolean = True)
                ' If Math.Round(NetWalk + _x) = 0 And _x <> 0 Then Exit Sub
                If _x = 0 AndAlso _y = 0 Then Exit Sub
                NetWalk += _x
                x += _x
                y += _y

                'Determine character state
                Dim OldFacing As Boolean = FacingRight
                If NetWalk > 0 Then
                    If Not FacingRight Then
                        FacingRight = True
                        CharTile.UpdateFrame()
                    End If
                    If Walk Then Walking = True
                ElseIf NetWalk < 0 Then
                    If FacingRight Then
                        FacingRight = False
                        CharTile.UpdateFrame()
                    End If
                    If Walk Then Walking = True
                    'If _x = 0 then do nothing because we are not
                    'moving horizontally
                End If
                If CantWalk Then Walking = False

                'Walk as much as we can
                If _x <> 0 Then
                    Dim c As Integer
                    Dim StartY As Double = y
                    Dim i As Integer
                    While IsColliding(PtrType.NoLedges)

                        'See if we go up steps or ramps
                        If AffectedByGravity And ((Not Falling) And (Not Jumping) And Walking) Then
                            For i = 1 To Game.tileH * 0.5
                                y = Math.Round(StartY) - i
                                If Not IsColliding(PtrType.NoLedges) Then
                                    Walking = False
                                    CantWalk = True
                                    Exit While
                                End If
                            Next
                            y = StartY
                        End If

                        'Make x an integer so there won't be rounding problems,
                        'and move in the opposite direction 1px at a time until
                        'we are not hitting anything.  However, if we changed directions,
                        'this could cause the player to shift in the opposite direction,
                        'since it uses a different animation, so the "opposite direction"
                        'is really the same direction we are moving in that case.
                        x = Math.Round(x) - Math.Sign(_x) ' * IIf(OldFacing = Not FacingRight, -1, 1)
                        Walking = False
                        CantWalk = True
                        c += 1
                        If c >= Math.Ceiling(Math.Abs(_x)) Then Exit While
                    End While
                    WasClimbing = False
                End If

                'Move vertically as much as we can
                If _y <> 0 Then
                    CurrentlyClimbing = True
                    Dim c As Integer
                    While IsColliding(PtrType.NoLedges)
                        y = Math.Round(y) - Math.Sign(_y)
                        CurrentlyClimbing = False
                        c += 1
                        If c >= Math.Ceiling(Math.Abs(_y)) Then Exit While
                    End While
                    WasClimbing = True
                End If
            End Sub

            Sub SetPosition(ByVal _x As Integer, ByVal _y As Integer)
                rawX = (_x - 1) * Game.tileW
                rawY = (_y - 1) * Game.tileH
            End Sub

            Dim Falling As Boolean, FallStart As Double
            Dim oldY As Double

            Sub Fall()
                Dim tmpT As Double = -1

                'Do not fall if there is no gravity
                If Not AffectedByGravity Then
                    'FallStart = Timer
                    Falling = False
                    Exit Sub
                End If

                If Not Falling And Not Jumping Then
                    'Check to see if we can fall
CheckFalling:
                    y += 1
                    If Not IsColliding(psCharacter.PtrType.Solid) Then
                        BeginFall(tmpT)
                        ActionProcessor.ProcessActions("rfal")
                    End If
                    y -= 1
                End If
                If Not Falling And Not Jumping Then Exit Sub

                'Make t between 0 and 1
                tmpT = -1
                Dim t As Double = (Timer - JumpStart) '/ jumpTime
                If t < 0 Then t = 0

                'Make sure we reach the maximum height
                If t > 1 And Not t_gt_1 Then
                    't = 1
                    t_gt_1 = True
                    ActionProcessor.ProcessActions("rfal")
                End If

                'If Jumping AndAlso t > jumpTime1 Then
                '    Jumping = False
                '    GoTo CheckFalling
                'End If

                Dim newY As Double = getCurJumpY(t)

                'Check if the player wants to stop jumping after
                'the minimum height has been reached
                If Jumping AndAlso initialHeight - newY >= jumpHeight1 Then
                    Jumping = False
                    'tmpT = t
                    tmpT = -1
                    GoTo CheckFalling
                End If

                'Calculate the change in Y that needs to occur
                Dim deltaY As Double = newY - oldY
                oldY = newY
                If deltaY = 0 Then Exit Sub

                'If we are jumping, do not collide with ledges
                Dim ptrType As PtrType
                If Math.Sign(deltaY) = -1 Then
                    ptrType = ptrType.NoLedges
                ElseIf Math.Sign(deltaY) = 1 Then
                    ptrType = ptrType.Solid
                End If

                'Step through each pixel change
                Dim max As Integer = Math.Ceiling(Math.Abs(deltaY))
                For i As Integer = 1 To max

                    'Calculate the pixel change value (usually 1 or -1,
                    'unless it is the last change, which will be a decimal)
                    Dim yChange As Double
                    If i = max Then
                        yChange = Math.Sign(deltaY) * (Math.Abs(deltaY) - Int(Math.Abs(deltaY)))
                    Else
                        yChange = Math.Sign(deltaY)
                    End If

                    'Probe for collision
                    y += yChange
                    If IsColliding(ptrType) Then
                        y = Math.Round(y)
                        Dim j As Integer
                        While IsColliding(ptrType)
                            y -= Math.Sign(deltaY)
                            j += 1
                            If j > Math.Ceiling(Math.Abs(yChange)) Then Exit While
                        End While
                        If Jumping Then
                            Jumping = False
                            ActionProcessor.ProcessActions("rstj")
                            GoTo CheckFalling
                        Else
                            Falling = False
                            ActionProcessor.ProcessActions("rlan")
                        End If
                        Exit For
                    End If
                Next


                Exit Sub

                '            ''Make sure we can fall
                '            'For i = 1 To UBound(R)
                '            '    If Game.Math.Collide_BoxBox(New Rectangle(x, y + 1, Width, Height), R(i)) Then
                '            '        Falling = False
                '            '        Exit Sub
                '            '    End If
                '            'Next

                '            If Jumping Then
                '                'If Timer - JumpStart >= JumpLength1 Then
                '                '    Jumping = False
                '                '    GoTo Falling
                '                'End If

                '                'Jump as much as we can
                '                'y -= 1250 * JumpSpeed * TimeElapsed * (((JumpLength * 0.7 / 0.6) - (Timer - JumpStart)) ^ 2) 'Game.tileH / ((Timer - JumpStart + 1) ^ 2) / JumpSpeed / 8
                '                'y -=(1250*jumpspeed*TimeElapsed)*                                           (timer-jumpstart)^2 +
                '                JumpLength = 1
                '                Dim t As Double = Timer - JumpStart
                '                t = t / JumpLength
                '                'y = 16 * t ^ 2 - JumpSpeed * 100 * t + initialHeight
                '                y = 32 * (t * 4 * JumpSpeed) ^ 2 - 128 * (t * 4 * JumpSpeed) + initialHeight


                '                While IsColliding(ptrType.NoLedges)
                '                    y = Math.Round(y) + 1
                '                    Jumping = False
                '                    Falling = True
                '                    FallStart = Timer
                '                End While
                '            Else
                'Falling:

                '                'If we are not falling, we are falling now
                '                If Not Falling Then
                '                    Falling = True
                '                    FallStart = Timer
                '                End If

                '                'Fall as much as we can
                '                Dim TotalY As Double = (GravitySpeed * 4 * Game.tileH * TimeElapsed * (2 * (Timer - (FallStart - 1))))
                '                Dim i As Integer
                '                Dim StartY As Single = y
                '                For i = 1 To Math.Ceiling(TotalY)
                '                    If i > TotalY Then
                '                        y += (Math.Ceiling(TotalY) - TotalY)
                '                    Else
                '                        y += 1
                '                    End If
                '                    If IsColliding(ptrType.Solid) Then
                '                        y = Math.Round(y)
                '                        While IsColliding(ptrType.Solid)
                '                            y -= 1
                '                            If y < StartY Then
                '                                y = StartY
                '                                Exit While
                '                            End If
                '                        End While
                '                        Falling = False
                '                        Exit For
                '                    End If
                '                Next
                '            End If
            End Sub

            Function getCurJumpY(ByVal t As Double) As Double
                'Equation for jumping and falling
                '--------------------------------
                'y = (h/4)(4t/l)^2-h(4t/l)+i
                'where h = jump height (in pixels), t = current time (in seconds),
                '      l = jumpTime (in seconds),   i = initial height
                '--------------------------------
                'Return jumpHeight / 4 * (t * 4 / jumpTime) ^ 2 _
                '- jumpHeight * (t * 4 / jumpTime) _
                '+ initialHeight
                Return initialHeight - 2 * jumpHeight / (jumpTime / 2) * t + jumpHeight / (jumpTime / 2) / (jumpTime / 2) * t * t
            End Function

            'Dim Jumping As Boolean, JumpStart As Double
            'Dim JumpLength As Single, JumpSpeed As Single
            'Dim JumpMinLength As Single, JumpLength1 As Single
            'Dim initialHeight As Double

            'Sub Jump(ByVal Length As Single, ByVal MinLength As Single, ByVal ScaleSpeed As Single)
            '    If Jumping Or Falling Then Exit Sub
            '    If Not AffectedByGravity Then
            '        Dim ptr() As TilePtr = Probe(0, 0)
            '        For i As Integer = 1 To UBound(ptr)
            '            If ptr(i).GetTile.Behavior = psTile.TileBehavior.NoGravity Then Exit Sub
            '        Next
            '    End If
            '    JumpStart = Timer
            '    Jumping = True
            '    JumpLength = Length
            '    JumpLength1 = Length
            '    JumpMinLength = MinLength
            '    JumpSpeed = ScaleSpeed
            '    initialHeight = y
            '    oldY = initialHeight
            'End Sub

            Dim Jumping As Boolean, JumpStart As Double
            Dim jumpTime As Double, jumpHeight As Double, initialHeight As Double
            'Dim jumpTime1 As Double, minJumpTime As Double
            Dim minJumpHeight, jumpHeight1 As Double
            Dim t_gt_1 As Boolean

            Sub Jump(ByVal Height As Single, ByVal MinHeight As Single, ByVal Time As Single)
                If Jumping Or Falling Then Exit Sub
                If Not AffectedByGravity Then
                    Dim ptr() As TilePtr = Probe(0, 0)
                    For i As Integer = 1 To UBound(ptr)
                        If ptr(i).GetTile.Behavior = psTile.TileBehavior.NoGravity Then Exit Sub
                    Next
                End If

                jumpTime = Time * 2
                'jumpTime1 = jumpTime
                'minJumpTime = (0.5 / 2)
                jumpHeight = Height * Game.tileH * 1.05
                jumpHeight1 = jumpHeight
                minJumpHeight = MinHeight * Game.tileH
                initialHeight = y
                t_gt_1 = False
                oldY = y

                ActionProcessor.ProcessActions("rjum")

                'Ready to jump
                Jumping = True
                JumpStart = Timer
            End Sub

            Sub JumpStop()
                jumpHeight1 = minJumpHeight
            End Sub

            Sub BeginFall(Optional ByVal t As Double = -1)
                If t = -1 Then
                    JumpStart = Timer - 2
                    'JumpStart = Timer - 1 - (1 - t)
                    jumpTime = 2
                    jumpHeight = Game.tileH * 4 * GravitySpeed
                    initialHeight = y
                End If
                oldY = getCurJumpY(Timer - JumpStart) 'initialHeight - jumpHeight
                Falling = True
                t_gt_1 = True
            End Sub
#End Region

#Region "Interaction with Moving Tiles"
            Dim PushedBy() As TilePtr
            Dim PushDir() As Point

            Private Sub AddToPushedBy(ByVal Tile As TilePtr, ByVal xdir As Integer, ByVal ydir As Integer)
                For i As Integer = 1 To UBound(PushedBy)
                    If PushedBy(i).Layer = Tile.Layer And PushedBy(i).Index = Tile.Index Then
                        Exit Sub
                    End If
                Next
                ReDim Preserve PushedBy(UBound(PushedBy) + 1)
                PushedBy(UBound(PushedBy)) = Tile
                ReDim Preserve PushDir(UBound(PushDir) + 1)
                PushDir(UBound(PushDir)) = New Point(xdir, ydir)
            End Sub

            Sub UpdateMovingTiles()
                ReDim PushedBy(0)
                ReDim PushDir(0)

                'Ride
                Dim Rode As Boolean
                For i As Integer = 0 To PathTiles.Count - 1
                    If PathTiles(i).GetTile.tile > 0 Then

                        'Store the updated tile
                        Dim tmpTile As psMapTile
                        tmpTile = PathTiles(i).GetTile
                        Dim tmpOffsetX, tmpOffsetY As Single
                        GetOffset(PathTiles(i).Index, PathTiles(i).Layer, tmpTile, tmpOffsetX, tmpOffsetY)

                        'Invoke 'change direction' triggers
                        If Not tmpTile.Path.Enclosed Then
                            Dim tmpBacktrack As Boolean = Timer - tmpTile.Path.Start >= tmpTile.Path.Speed / 2
                            If PathTiles(i).BackTracking <> tmpBacktrack Then
                                PathTiles(i).DirChanged = True
                            End If
                            PathTiles(i).BackTracking = tmpBacktrack
                        End If

                        'Determine whether the tile should be flipped
                        If Game.tileset.tiles(PathTiles(i).GetTile.tile).Anim(0).Interval > 0 Then
                            Dim tmpOldX As Single, tmpOldY As Single
                            Dim tmpTile2 As psMapTile = tmpTile
                            tmpTile2.Path.Start += 0.1
                            GetOffset(PathTiles(i).Index, PathTiles(i).Layer, tmpTile2, tmpOldX, tmpOldY)
                            tmpTile2 = Nothing
                            If tmpOffsetX < tmpOldX Then
                                'If PathTiles(i).Flip = False And i = 1 Then MsgBox("")
                                PathTiles(i).Flip = True
                            ElseIf tmpOffsetX > tmpOldX Then
                                'If PathTiles(i).Flip And i = 1 Then MsgBox("")
                                PathTiles(i).Flip = False
                            End If
                        End If
                        tmpTile.PathX = tmpOffsetX
                        tmpTile.PathY = tmpOffsetY

                        If PathTiles(i).Layer = 2 AndAlso tmpTile.tile > 0 AndAlso tmpTile.Path.Exists AndAlso (Game.tileset.tiles(tmpTile.tile).behavior = psTile.TileBehavior.Solid Or Game.tileset.tiles(tmpTile.tile).behavior = psTile.TileBehavior.Ledge) Then
                            Dim MoveX As Single = tmpTile.PathX - PathTiles(i).OldX
                            Dim MoveY As Single = tmpTile.PathY - PathTiles(i).OldY
                            Dim tmp As Single
                            If Rode = False AndAlso OnTile(PathTiles(i), 0, 1) Then
                                Rode = True

                                'Move y
                                'For j As Integer = 1 To Math.Ceiling(Math.Abs(MoveY))
                                '    If j > Int(Math.Abs(MoveY)) Then
                                '        tmp = Math.Sign(MoveY) * (Math.Abs(MoveY) - Int(Math.Abs(MoveY)))
                                '    Else
                                '        tmp = Math.Sign(MoveY)
                                '    End If
                                '    y += tmp
                                '    If IsColliding(PtrType.NoLedges, PathTiles(i).Index, PathTiles(i).Layer) Then
                                '        y -= Math.Sign(MoveY)

                                '        'Halt tile movement until it has
                                '        'a clear path
                                '        Dim tmpPath As psPath = tmpTile.Path
                                '        tmpPath.Start += TimeElapsed
                                '        tmpTile.Path = tmpPath
                                '        tmpTile.PathX = PathTiles(i).OldX
                                '        tmpTile.PathY = PathTiles(i).OldY
                                '        PathTiles(i).GetTile = tmpTile

                                '        GoTo DoneMove
                                '    ElseIf MoveY > 0 And IsColliding(PtrType.Solid, PathTiles(i).Index, PathTiles(i).Layer) Then
                                '        y -= Math.Sign(MoveY)
                                '        Exit For
                                '    End If
                                'Next

                                If MoveY <> 0 Then
                                    y = Math.Round(tmpTile.PathY) - Height
                                    Dim j As Integer
                                    While IsColliding(PtrType.SolidWithoutNoGravity, PathTiles(i).Index, PathTiles(i).Layer)
                                        y -= Math.Sign(MoveY)
                                        j += 1
                                        If j > Math.Ceiling(Math.Abs(MoveY)) Then
                                            j = 0
                                            While IsColliding(PtrType.SolidWithoutNoGravity, PathTiles(i).Index, PathTiles(i).Layer)
                                                y += Math.Sign(MoveY)
                                                j += 1
                                                If j > Math.Ceiling(Math.Abs(MoveY)) Then
                                                    Exit While
                                                End If
                                            End While
                                            Exit While
                                        End If
                                    End While
                                End If

                                'Move x
                                For j As Integer = 1 To Math.Ceiling(Math.Abs(MoveX))
                                    If j > Int(Math.Abs(MoveX)) Then
                                        tmp = Math.Sign(MoveX) * (Math.Abs(MoveX) - Int(Math.Abs(MoveX)))
                                    Else
                                        tmp = Math.Sign(MoveX)
                                    End If
                                    x += tmp
                                    If IsColliding(PtrType.NoLedges, PathTiles(i).Index, PathTiles(i).Layer) Then
                                        x -= Math.Sign(MoveX)
                                        Exit For
                                    End If
                                Next

DoneMove:
                            ElseIf OnTile(PathTiles(i), -MoveX + 1, 0) And MoveX < 0 Then
                                'Push left
                                'x = Math.Round(x)
                                AddToPushedBy(PathTiles(i), 1, 0)
                                While OnTile(PathTiles(i), -MoveX + 1, 0)
                                    x -= 1
                                    If IsColliding(PtrType.NoLedges) Then
                                        x += 1
                                        Dim tmpPath As psPath = tmpTile.Path
                                        tmpPath.Start += TimeElapsed
                                        tmpTile.Path = tmpPath
                                        tmpTile.PathX = PathTiles(i).OldX
                                        tmpTile.PathY = PathTiles(i).OldY
                                        PathTiles(i).GetTile = tmpTile
                                        Exit While
                                    End If
                                End While
                            ElseIf OnTile(PathTiles(i), -MoveX - 1, 0) And MoveX > 0 Then
                                'Push right
                                'x = Math.Round(x)
                                AddToPushedBy(PathTiles(i), -1, 0)
                                While OnTile(PathTiles(i), -MoveX - 1, 0)
                                    x += 1
                                    If IsColliding(PtrType.NoLedges) Then
                                        x -= 1
                                        Dim tmpPath As psPath = tmpTile.Path
                                        tmpPath.Start += TimeElapsed
                                        tmpTile.Path = tmpPath
                                        tmpTile.PathX = PathTiles(i).OldX
                                        tmpTile.PathY = PathTiles(i).OldY
                                        PathTiles(i).GetTile = tmpTile
                                        Exit While
                                    End If
                                End While
                            ElseIf OnTile(PathTiles(i), 0, -MoveY - 1) And MoveY > 0 Then
                                'Push down
                                'y = Math.Round(y)
                                AddToPushedBy(PathTiles(i), 0, -1)
                                While OnTile(PathTiles(i), 0, -MoveY - 1)
                                    y += 1
                                    If IsColliding(PtrType.Solid) Then
                                        y -= 1
                                        Dim tmpPath As psPath = tmpTile.Path
                                        tmpPath.Start += TimeElapsed
                                        tmpTile.Path = tmpPath
                                        tmpTile.PathX = PathTiles(i).OldX
                                        tmpTile.PathY = PathTiles(i).OldY
                                        PathTiles(i).GetTile = tmpTile
                                        Exit While
                                    End If
                                End While
                            ElseIf OnTile(PathTiles(i), 0, -MoveY + 1) And MoveY < 0 Then
                                'Push up
                                'y = Math.Round(y)
                                AddToPushedBy(PathTiles(i), 0, 1)
                                While OnTile(PathTiles(i), 0, -MoveY + 1)
                                    y -= 1
                                    If IsColliding(PtrType.NoLedges) Then
                                        y += 1
                                        Dim tmpPath As psPath = tmpTile.Path
                                        tmpPath.Start += TimeElapsed
                                        tmpTile.Path = tmpPath
                                        tmpTile.PathX = PathTiles(i).OldX
                                        tmpTile.PathY = PathTiles(i).OldY
                                        PathTiles(i).GetTile = tmpTile
                                        Exit While
                                    End If
                                End While
                            Else
                                'THIS DOES MORE DAMAGE THAN WHAT IT'S WORTH! :)
                                ''One final collision check
                                'PathTiles(i).GetTile = tmpTile
                                'While IsColliding(PtrType.NoLedges)
                                '    If MoveX <> 0 Then x += Math.Sign(MoveX)
                                'End While
                            End If
                        End If
                        PathTiles(i).OldX = tmpTile.PathX
                        PathTiles(i).OldY = tmpTile.PathY
                        PathTiles(i).GetTile = tmpTile
                    End If
                Next

                For i As Integer = 0 To PathTiles.Count - 1
                    If i >= PathTiles.Count Then Exit Sub

                    'Direction changed actions
                    If PathTiles(i).DirChanged Then
                        Dim tmpNumPathTiles As Integer = PathTiles.Count - 1

                        Dim tmpTile As psMapTile
                        tmpTile = PathTiles(i).GetTile

                        PathTiles(i).DirChanged = False
                        CurTile = PathTiles(i)
                        SetCurGroup(tmpTile.TileName, PathTiles(i).X, PathTiles(i).Y, PathTiles(i).Width, PathTiles(i).Height, tmpTile.HitPoints, tmpTile.Frame, tmpTile.AnimIndex, tmpTile.GetTile.name)
                        ActionProcessor.ProcessActions("tcha" & tmpTile.tile, curGroup)
                        ActionProcessor.ProcessActions("gcha" & LevelText & tmpTile.Group, curGroup)
                        If PathTiles(i).BackTracking Then
                            ActionProcessor.ProcessActions("tctb" & tmpTile.tile, curGroup)
                            ActionProcessor.ProcessActions("gctb" & LevelText & tmpTile.Group, curGroup)
                        Else
                            ActionProcessor.ProcessActions("tctf" & tmpTile.tile, curGroup)
                            ActionProcessor.ProcessActions("gctf" & LevelText & tmpTile.Group, curGroup)
                        End If

                        If PathTiles.Count <= tmpNumPathTiles Then
                            'Deleted current tile in one of the actions
                            i -= 1
                        End If
                    End If
                Next
            End Sub

            Private Function OnTile(ByVal Ptr As TilePtr, ByVal ProbeX As Single, ByVal ProbeY As Single) As Boolean
                'If the probe amount is this large,
                'it's because it is the beginning
                'of the game
                If Math.Abs(ProbeX) > Game.tileW And Ptr.OldX = 0 Then Return False
                If Math.Abs(ProbeY) > Game.tileH And Ptr.OldY = 0 Then Return False

                Dim tmpX As Single = x
                Dim tmpY As Single = y
                If ProbeX <> 0 Then x = Int(x + ProbeX)
                If ProbeY <> 0 Then y = Int(y + ProbeY)

                'Perform the collision tests
                Dim bCollision As Boolean
                With Ptr.GetTile
                    'Collision
                    If Util.Collision(x, y, Width, Height, Ptr) Then
                        bCollision = True
                    End If
                End With

                x = tmpX
                y = tmpY

                Return bCollision
            End Function
#End Region

#Region "Collision"
            Private TSolid() As TilePtr
            Private TNoLedge() As TilePtr
            Private TCollect() As TilePtr
            Private TSolidWithoutNoGravity() As TilePtr
            Enum PtrType
                Solid = 0
                NoLedges = 1
                Collectable = 2
                SolidWithoutNoGravity = 3
            End Enum
            Dim rX As Double, rY As Double

            Function GetSurroundingSolidTiles(ByVal Type As PtrType) As TilePtr()
                Dim tiles As New List(Of TilePtr)
                tiles.Add(TilePtr.Empty)
                Dim i As Integer, j As Integer, n As Integer
                Dim MinLayer, MaxLayer As Byte
                If Type = PtrType.Collectable Then
                    MinLayer = 1
                    MaxLayer = 3
                Else
                    MinLayer = 2
                    MaxLayer = 2
                End If
                For n = MinLayer To MaxLayer
                    For i = (x \ Game.tileW - Game.tileset.MaxTileW \ Game.tileW) - 1 To Math.Ceiling(x / Game.tileW) + Math.Ceiling(Width / Game.tileW) + 1
                        For j = (y \ Game.tileH - Game.tileset.MaxTileH \ Game.tileH) - 1 To Math.Ceiling(y / Game.tileH) + Math.Ceiling(Height / Game.tileH) + 1
                            If i > 0 And j > 0 And i <= Game.CurMapWidth And j <= Game.CurMapHeight Then
                                With Game.CurMap.Cells2(i, j, n)
                                    If .tile > 0 Then
                                        If (Type = PtrType.Solid And (.Behavior = psTile.TileBehavior.Solid Or .Behavior = psTile.TileBehavior.Ledge Or .Behavior = psTile.TileBehavior.NoGravity)) Or _
                                           (Type = PtrType.NoLedges And .Behavior = psTile.TileBehavior.Solid) Or _
                                           (Type = PtrType.Collectable And .Behavior = psTile.TileBehavior.Collectable) Or _
                                           (Type = PtrType.SolidWithoutNoGravity And (.Behavior = psTile.TileBehavior.Solid Or .Behavior = psTile.TileBehavior.Ledge)) Then
                                            tiles.Add(New TilePtr(Game.CurMap.Get1DIndex(i, j), n))
                                        End If
                                    End If
                                End With
                            End If
                        Next
                    Next
                Next
                If Not (PathTiles Is Nothing) Then
                    For i = 0 To PathTiles.Count - 1
                        If PathTiles(i).Layer >= MinLayer AndAlso PathTiles(i).Layer <= MaxLayer AndAlso PathTiles(i).GetTile.tile > 0 Then
                            With PathTiles(i).GetTile
                                If (Type = PtrType.Solid And (.Behavior = psTile.TileBehavior.Solid Or .Behavior = psTile.TileBehavior.Ledge Or .Behavior = psTile.TileBehavior.NoGravity)) Or _
                                   (Type = PtrType.NoLedges And .Behavior = psTile.TileBehavior.Solid) Or _
                                   (Type = PtrType.Collectable And .Behavior = psTile.TileBehavior.Collectable) Or _
                                   (Type = PtrType.SolidWithoutNoGravity And (.Behavior = psTile.TileBehavior.Solid Or .Behavior = psTile.TileBehavior.Ledge)) Then
                                    tiles.Add(New TilePtr(PathTiles(i).Index, 2))
                                End If
                            End With
                        End If
                    Next
                End If
                Return tiles.ToArray()
            End Function

            Sub UpdatedMap()
                rX = -1000000
                rY = -1000000
            End Sub

            Sub UpdateSurroundingTiles()
                'Update surrounding tiles only when needed
                If Math.Abs(x - rX) >= Game.tileW * 0.5 Or _
                   Math.Abs(y - rY) >= Game.tileH * 0.5 Then
                    TSolid = GetSurroundingSolidTiles(PtrType.Solid)
                    TNoLedge = GetSurroundingSolidTiles(PtrType.NoLedges)
                    TCollect = GetSurroundingSolidTiles(PtrType.Collectable)
                    TSolidWithoutNoGravity = GetSurroundingSolidTiles(PtrType.SolidWithoutNoGravity)
                    rX = x
                    rY = y
                End If
            End Sub

            Function IsColliding(ByVal PtrType As PtrType, Optional ByVal IgnoreIndex As Integer = 0, Optional ByVal IgnoreLayer As Integer = 0) As Boolean
                UpdateSurroundingTiles()

                'Get the group of tiles that was specified
                Dim T() As TilePtr = Nothing
                Select Case PtrType
                    Case PtrType.Solid
                        T = TSolid
                    Case PtrType.NoLedges
                        T = TNoLedge
                    Case PtrType.Collectable
                        T = TCollect
                    Case PtrType.SolidWithoutNoGravity
                        T = TSolidWithoutNoGravity
                End Select

                'Perform the collision tests
                For i As Integer = 1 To UBound(T)
                    If IsCollision(T(i).GetTile, T(i).Rectangle, T(i).Index, T(i).Layer, IgnoreIndex, IgnoreLayer) Then Return True
                Next

                'Test bullets
                For Each bulletTile As BulletTile In BulletTiles
                    If Not bulletTile.FromCharacter Then
                        If IsCollision(bulletTile.Tile, _
                        New Rectangle(bulletTile.X, bulletTile.Y, _
                            bulletTile.Width, bulletTile.Height)) Then
                            Return True
                        End If
                    End If
                Next

                'No collision occured
                Return False
            End Function

            Private Function IsCollision(ByVal Tile As psMapTile, ByVal Rect As Rectangle, Optional ByVal Index_ As Integer = 0, Optional ByVal Layer_ As Integer = 0, Optional ByVal IgnoreIndex As Integer = 0, Optional ByVal IgnoreLayer As Integer = 0) As Boolean
                Dim tmpY As Integer, tmpHeight As Integer
                If Tile.tile > 0 AndAlso (Index_ <> IgnoreIndex Or Layer_ <> IgnoreLayer) Then

                    'Only look at the bottom part of the tile
                    'if we are looking at a ledge
                    If Tile.GetTile.behavior = psTile.TileBehavior.Ledge Then
                        tmpY = y + Height - 1
                        tmpHeight = 1
                    Else
                        tmpY = y
                        tmpHeight = Height
                    End If

                    'Collision
                    Return Util.Collision(x, tmpY, Width, tmpHeight, Tile, Rect)

                End If
            End Function

            Function GetCollidedTiles(ByVal PtrType As PtrType, Optional ByVal AutoAddPushTiles As Boolean = True, Optional ByVal PushFromX As Integer = 0, Optional ByVal PushFromY As Integer = 0) As TilePtr()
                'Get the group of tiles that was specified
                Dim T() As TilePtr = Nothing
                Select Case PtrType
                    Case PtrType.Solid
                        T = TSolid
                    Case PtrType.NoLedges
                        T = TNoLedge
                    Case PtrType.Collectable
                        T = TCollect
                    Case PtrType.SolidWithoutNoGravity
                        T = TSolidWithoutNoGravity
                End Select

                'Perform the collision tests
                Dim tiles As New List(Of TilePtr)
                tiles.Add(TilePtr.Empty)
                For i As Integer = 1 To UBound(T)
                    GetCollidedTile(T(i).GetTile, tiles, T(i).Rectangle, False, T(i).Layer, T(i).Index)
                    'If T(i).GetTile.tile > 0 Then

                    '    'Only look at the bottom part of the tile
                    '    'if we are looking at a ledge
                    '    If T(i).GetTile.Behavior = psTile.TileBehavior.Ledge Then
                    '        tmpY = y + Height - 1
                    '        tmpHeight = 1
                    '    Else
                    '        tmpY = y
                    '        tmpHeight = Height
                    '    End If

                    '    '1. Bounding-box collision
                    '    If Game.Math.Collide_BoxBox(New Rectangle(x, tmpY, Width, tmpHeight), T(i).Rectangle) Then
                    '        ''2. Pixel-perfect collision
                    '        If Game.GameProperties.NoPixelPerfect OrElse Game.Math.Collide_BoxTexture(x - T(i).X, tmpY - T(i).Y, Width, tmpHeight, T(i).GetTile.TileName, Game.tileset.tiles(T(i).GetTile.tile), T(i).GetTile.Frame) Then
                    '            ReDim Preserve TPtr(UBound(TPtr) + 1)
                    '            TPtr(UBound(TPtr)) = T(i)
                    '        End If
                    '    End If
                    'End If
                Next

                'Add the bullet tiles that are hitting the character,
                'because they are not stored within the map structure
                For i As Integer = 0 To BulletTiles.Count - 1
                    If Not BulletTiles(i).FromCharacter Then
                        GetCollidedTile(BulletTiles(i).Tile, tiles, New Rectangle(BulletTiles(i).X, BulletTiles(i).Y, BulletTiles(i).Width, BulletTiles(i).Height), True, , i)
                    End If
                Next

                'Add tiles that we know are pushing the character,
                'in case the collision routine didn't pick them up
                If AutoAddPushTiles Then
                    If PtrType = PtrType.Solid Or PtrType = PtrType.SolidWithoutNoGravity Then
                        For i As Integer = 1 To UBound(PushedBy)
                            If PushFromX = PushDir(i).X And PushFromY = PushDir(i).Y Then
                                For Each tile As TilePtr In tiles
                                    If tile.Layer = PushedBy(i).Layer And tile.Index = PushedBy(i).Index Then
                                        GoTo NextI
                                    End If
                                Next
                                tiles.Add(PushedBy(i))
                            End If
NextI:
                        Next
                    End If
                End If

                Return tiles.ToArray()
            End Function

            Private Sub GetCollidedTile(ByVal Tile As psMapTile, ByVal tiles As List(Of TilePtr), ByVal Rect As Rectangle, Optional ByVal CreatePtr As Boolean = False, Optional ByVal Layer_ As Integer = 0, Optional ByVal Index_ As Integer = 0)
                Dim tmpY As Integer, tmpHeight As Integer
                If Tile.tile > 0 Then

                    'Only look at the bottom part of the tile
                    'if we are looking at a ledge
                    If Tile.Behavior = psTile.TileBehavior.Ledge Then
                        tmpY = y + Height - 1
                        tmpHeight = 1
                    Else
                        tmpY = y
                        tmpHeight = Height
                    End If

                    'Collision
                    If Util.Collision(x, tmpY, Width, tmpHeight, Tile, Rect) Then
                        If CreatePtr Then
                            Game.maps(Game.CurMapIndex).AddToTemp(Tile, Index_)
                            tiles.Add(New TilePtr(Index_, 4))
                        Else
                            tiles.Add(New TilePtr(Index_, Layer_))
                        End If
                    End If
                End If
            End Sub
#End Region

#Region "Update and Draw"
            Public UseCustomAnimation As Boolean
            Public CustomAnimation As Integer
            Public CustomAnimationStopped As Boolean
            ReadOnly Property CurrentAnimIndex() As Integer
                Get
                    Return _CharTile.AnimIndex
                End Get
            End Property
            ReadOnly Property AnimStopped() As Boolean
                Get
                    Return _CharTile.Stopped
                End Get
            End Property

            Sub Update()
                UpdateSurroundingTiles()

                'Update moving tiles
                UpdateMovingTiles()

                'Update dropping tiles and bullet tiles
                UpdateDropTiles()
                UpdateBulletTiles()

                'Gravity
                Fall()

                'Process "Always" action                    
                ActionProcessor.ProcessActions("aalw")
                If ChangedLevel Then Exit Sub

                'Process "Timer" actions
                ProcessTimerActions()
                If ChangedLevel Then Exit Sub

                'Process actions
                ProcessCharacterActions()
                If ChangedLevel Then Exit Sub

                'Check to see if any bullets hit anything
                CheckBulletTilesForCollision()

                'Stay in the boundaries of the level
                If x < 0 Then x = 0 : Walking = False
                If x > Game.tileW * Game.CurMapWidth - Width Then x = Game.tileW * Game.CurMapWidth - Width : Walking = False
                If y < 0 Then y = 0 : Jumping = False : Falling = True : BeginFall() 'Falling = True : FallStart = Timer
                If y > Game.tileH * Game.CurMapHeight - Height Then y = Game.tileH * Game.CurMapHeight - Height : Falling = False

                'Update the animation
                If Jumping Then Walking = False
                If Falling Then Walking = False
                If UseCustomAnimation Then
                    _CharTile.AnimIndex = CustomAnimation
                    _CharTile.Stopped = CustomAnimationStopped
                ElseIf Climbing And WasClimbing Then
                    _CharTile.AnimIndex = 2
                    _CharTile.Stopped = (Not CurrentlyClimbing)
                ElseIf FacingRight Then
                    _CharTile.AnimIndex = 0
                    _CharTile.Stopped = (Not Walking)
                Else
                    _CharTile.AnimIndex = 1
                    _CharTile.Stopped = (Not Walking)
                End If

                'Update the frame and make sure we are not colliding
                'with anything when we do that
                Dim OldFrame As Integer = _CharTile.Frame
                Dim tmpNotFalling As Boolean

                'See if we can fall right now
                y += 1
                If IsColliding(PtrType.Solid) Then tmpNotFalling = True
                y -= 1

                'Update the frame
                _CharTile.UpdateFrame()

                'If we are colliding with something,
                'revert back to the old frame
                If IsColliding(PtrType.NoLedges) Then _CharTile.Frame = OldFrame

                'Also do it if we can now fall, but before, we could not
                y += 1
                If Not IsColliding(PtrType.Solid) And tmpNotFalling Then _CharTile.Frame = OldFrame
                y -= 1

                'Dim cnt As Integer
                'Dim dblStartX As Double, intStartX As Integer
                'dblStartX = x
                'intStartX = Math.Round(x)
                'While IsColliding(PtrType.Solid)
                '    cnt += 1
                '    x = intStartX + cnt
                '    If IsColliding(PtrType.Solid) Then
                '        x = intStartX - cnt
                '    Else
                '        Exit While
                '    End If
                'End While

                UpdateBlink()
                If Climbing = False Then WasClimbing = False
                CurrentlyClimbing = False
            End Sub

            Sub UpdateBlink()
                'Handle blinking
                tmpColor = &HFFFFFFFF
                If Blinking Then
                    If Timer - BlinkStart > BlinkLength Then
                        Blinking = False
                    Else
                        If Timer - BlinkCycleStart > BlinkCycle Then
                            BlinkCycleStart = Timer
                        End If
                        If BlinkType = psCharBlinkType.Blink Then
                            If Timer - BlinkCycleStart > BlinkCycle * 0.5 Then
                                tmpColor = Color.FromArgb(0, 255, 255, 255).ToArgb
                            Else
                                tmpColor = Color.FromArgb(255, 255, 255, 255).ToArgb
                            End If
                        ElseIf BlinkType = psCharBlinkType.Fade Then
                            If Timer - BlinkCycleStart > BlinkCycle * 0.5 Then
                                tmpColor = Color.FromArgb((Timer - BlinkCycleStart - BlinkCycle * 0.5) / (BlinkCycle * 0.5) * 128 + 64, 255, 255, 255).ToArgb
                            Else
                                tmpColor = Color.FromArgb(255 - ((Timer - BlinkCycleStart) / (BlinkCycle * 0.5) * 128 + 64), 255, 255, 255).ToArgb
                            End If
                        End If
                    End If
                End If
            End Sub

            Private tmpColor As Integer
            Sub Draw()
                If Me.Wait AndAlso Renderer.FoundDieAnim Then Exit Sub

                Game.Drawing.OffsetX += rawX
                Game.Drawing.OffsetY += rawY
                DoNotUpdateAnim = True

                Game.CurMap.DrawTile(1, 1, Layer, _CharTile, True, , , , , , tmpColor)
                DoNotUpdateAnim = False
                Game.Drawing.OffsetX -= rawX
                Game.Drawing.OffsetY -= rawY

                Walking = False
                CantWalk = False
                NetWalk = 0
            End Sub

            ReadOnly Property LastFrame() As Integer
                Get
                    Return _CharTile.Frame
                End Get
            End Property

            Enum psCharBlinkType As Byte
                Blink = 0
                Fade
            End Enum
            Dim BlinkStart As Single, BlinkLength As Single
            Dim BlinkCycle As Single, BlinkCycleStart As Single
            Dim BlinkType As psCharBlinkType
            Dim Blinking As Boolean
            Sub Hurt(Optional ByVal ImmunityLength As Single = 4, Optional ByVal VisualEffect As String = "Blink", Optional ByVal EffectCycleLength As Single = 0.5)
                If Blinking Then Exit Sub
                Select Case VisualEffect
                    Case "Blink"
                        BlinkType = psCharBlinkType.Blink
                    Case "Fade"
                        BlinkType = psCharBlinkType.Fade
                End Select
                BlinkStart = Timer
                BlinkLength = ImmunityLength
                BlinkCycle = EffectCycleLength
                BlinkCycleStart = BlinkStart
                Blinking = True
            End Sub

            Sub OnResume()
                FallStart += (Timer - PauseStart)
                JumpStart += (Timer - PauseStart)
                ShootStart += (Timer - PauseStart)
                For n As Byte = 1 To 3
                    For i As Integer = 1 To Game.CurMap.MapSize1D
                        If Game.maps(Game.CurMapIndex).Cells1D2(i, n).Path.Exists Then
                            Dim tmp As psMapTile
                            tmp = Game.maps(Game.CurMapIndex).Cells1D2(i, n)
                            Dim tmpPath As psPath = tmp.Path
                            tmpPath.Start += (Timer - PauseStart)
                            tmp.Path = tmpPath
                            Game.maps(Game.CurMapIndex).Cells1D2(i, n) = tmp
                        End If
                    Next
                Next
                For i As Short = 1 To UBound(Game.actions.Timers)
                    Game.actions.Timers(i).StartTime += (Timer - PauseStart)
                Next
                For i As Short = 0 To 255
                    Keys(i) = False
                Next
            End Sub
#End Region

#Region "Actions"
            Private _Wait As Boolean
            Public WaitStart As Single
            Public WaitCamX As Integer, WaitCamY As Integer
            Public Property Wait() As Boolean
                Get
                    Return _Wait
                End Get
                Set(ByVal Value As Boolean)
                    If Value = True Then
                        WaitStart = Timer
                        WaitCamX = Game.cam.X
                        WaitCamY = Game.cam.Y
                        CamMoveScale = 0
                    End If
                    _Wait = Value
                End Set
            End Property

            Dim loc() As Boolean
            Dim str5DigitMapNum As String
            Sub ProcessCharacterActions()

                Dim i As Integer
                Game.maps(Game.CurMapIndex).ResetTempLayer(BulletTiles.Count - 1)

                'Locations
                For i = 1 To UBound(Game.CurMap.loc.Locations)
                    With Game.CurMap.loc.Locations(i)
                        If Game.Math.Collide_BoxBox(Me.GetRect, New Rectangle(.Rectangle.X, .Rectangle.Y, .Rectangle.Width - 1, .Rectangle.Height - 1)) Then

                            'Enter
                            If Not loc(i) Then
                                If .ChkPos > psLocation.CheckPosition.None Then
                                    Game.PresetActions.SetCheckpoint((Game.CurMap.loc.ChkX(Game.CurMap.loc.Locations(i), CharTile.tile) \ Game.tileW) + 1, (Game.CurMap.loc.ChkY(Game.CurMap.loc.Locations(i), CharTile.tile) \ Game.tileH) + 1)
                                End If
                                loc(i) = True
                                ActionProcessor.ProcessActions("lent" & str5DigitMapNum & .Name)
                                If ChangedLevel Then Exit Sub
                            End If

                            'Inside
                            ActionProcessor.ProcessActions("lins" & str5DigitMapNum & .Name)
                            If ChangedLevel Then Exit Sub

                        Else

                            'Exit
                            If loc(i) Then
                                loc(i) = False
                                ActionProcessor.ProcessActions("lexi" & str5DigitMapNum & .Name)
                                If ChangedLevel Then Exit Sub
                            End If

                        End If
                    End With
                Next

                'Probe for collisions
                tptrLeft = Probe(1, 0)
                tptrRight = Probe(-1, 0)
                tptrUp = Probe(0, 1)
                tptrDown = Probe(0, -1)

                'Tiles - Hit
                Dim TPtr() As TilePtr = GetCollidedTiles(PtrType.Collectable)
                ReDim HitTiles(0)
                TPtr2 = GetCollidedTiles(PtrType.SolidWithoutNoGravity, False)
                ProcessTileHitActions(tptrLeft, "tlef") 'left
                If ChangedLevel Then Exit Sub
                ProcessTileHitActions(tptrDown, "tbot") 'bottom
                If ChangedLevel Then Exit Sub
                ProcessTileHitActions(tptrRight, "trig") 'right
                If ChangedLevel Then Exit Sub
                ProcessTileHitActions(tptrUp, "ttop") 'top
                If ChangedLevel Then Exit Sub

                'Groups - Hit
                ReDim GroupTriggers(0)
                For i = 0 To UBound(tptrLeft)
                    With tptrLeft(i).GetTile
                        If .Group <> "" Then
                            ProcessGroupHitActions(tptrLeft(i), tptrLeft, "glef" & LevelText & .Group) 'left
                            If ChangedLevel Then Exit Sub
                        End If
                    End With
                Next
                For i = 0 To UBound(tptrDown)
                    With tptrDown(i).GetTile
                        If .Group <> "" Then
                            ProcessGroupHitActions(tptrDown(i), tptrDown, "gbot" & LevelText & .Group) 'bottom
                            If ChangedLevel Then Exit Sub
                        End If
                    End With
                Next
                For i = 0 To UBound(tptrRight)
                    With tptrRight(i).GetTile
                        If .Group <> "" Then
                            ProcessGroupHitActions(tptrRight(i), tptrRight, "grig" & LevelText & .Group) 'right
                            If ChangedLevel Then Exit Sub
                        End If
                    End With
                Next
                For i = 0 To UBound(tptrUp)
                    With tptrUp(i).GetTile
                        If .Group <> "" Then
                            ProcessGroupHitActions(tptrUp(i), tptrUp, "gtop" & LevelText & .Group) 'top
                            If ChangedLevel Then Exit Sub
                        End If
                    End With
                Next

                'Collect
                ReDim GroupTriggers(0)
                Dim tmpTile As psMapTile
                For i = 0 To UBound(TPtr)
                    'Set the current group and
                    'store the tile for temporary use
                    SetCurGroup(TPtr(i).GetTile.Group, TPtr(i).X, TPtr(i).Y, TPtr(i).Width, TPtr(i).Height, TPtr(i).GetTile.HitPoints, TPtr(i).GetTile.Frame, TPtr(i).GetTile.AnimIndex, TPtr(i).GetTile.GetTile.name)
                    tmpTile = TPtr(i).GetTile.Clone

                    'Delete the tile
                    Dim tmpX As Integer = TPtr(i).X
                    Dim tmpY As Integer = TPtr(i).Y
                    Game.maps(Game.CurMapIndex).Cells1D2(TPtr(i).Index, TPtr(i).Layer) = New psMapTile

                    With tmpTile
                        'Make a new disappear animation
                        If .tile > 0 Then
                            With Game.tileset.tiles(.tile).Anim(1)
                                If .Interval > 0 And TPtr(i).Layer < 4 Then
                                    ReDim Preserve Anim(UBound(Anim) + 1)
                                    Anim(UBound(Anim)).Init(tmpX, tmpY, tmpTile.tile, .StartFrame, 1, tmpTile.Frame)
                                End If
                            End With
                        End If

                        'Groups - Collect
                        If .Group <> "" Then
                            For j As Integer = 1 To UBound(GroupTriggers)
                                If GroupTriggers(j) = "gcol" & LevelText & .Group Then GoTo DoneGroupCollect
                            Next
                            ActionProcessor.ProcessActions("gcol" & LevelText & .Group, curGroup)
                            If ChangedLevel Then Exit Sub
                            ReDim Preserve GroupTriggers(UBound(GroupTriggers) + 1)
                            GroupTriggers(UBound(GroupTriggers)) = "gcol" & LevelText & .Group
                        End If
DoneGroupCollect:

                        'Tiles - Collect
                        ActionProcessor.ProcessActions("tcol" & .tile, curGroup)
                        If ChangedLevel Then Exit Sub

                    End With
                Next

                ReDim PushedBy(0)
                ReDim PushDir(0)
            End Sub

            Dim HitTiles() As Integer
            Dim TPtr2() As TilePtr
            Dim GroupTriggers() As String
            Dim tptrLeft(), tptrRight(), tptrUp(), tptrDown() As TilePtr

            Function Probe(ByVal ProbeX As Integer, ByVal ProbeY As Integer) As TilePtr()
                x += ProbeX
                y += ProbeY
                Dim tmpPtr() As TilePtr
                tmpPtr = GetCollidedTiles(PtrType.Solid, , -ProbeX, -ProbeY)
                x -= ProbeX
                y -= ProbeY
                Return tmpPtr
            End Function

            Sub ProcessTileHitActions(ByVal TPtr() As TilePtr, ByVal ActionName As String)
                Dim i As Integer, j As Integer
                Dim AlreadyHit As Boolean
                For i = 0 To UBound(TPtr)

                    For j = 0 To UBound(TPtr2)
                        If TPtr(i).Layer = TPtr2(j).Layer And TPtr(i).Index = TPtr2(j).Index Then GoTo NextI
                    Next

                    'Check to see if we hit this tile yet
                    AlreadyHit = False
                    For j = 1 To UBound(HitTiles)
                        If HitTiles(j) = TPtr(i).GetTile.tile Then
                            AlreadyHit = True
                            Exit For
                        End If
                    Next

                    CurTile = TPtr(i)
                    SetCurGroup(CurTile.GetTile.Group, CurTile.X, CurTile.Y, CurTile.Width, CurTile.Height, CurTile.GetTile.HitPoints, CurTile.GetTile.Frame, CurTile.GetTile.AnimIndex, CurTile.GetTile.GetTile.name)

                    'Hit
                    If Not AlreadyHit Then
                        ReDim Preserve HitTiles(UBound(HitTiles) + 1)
                        HitTiles(UBound(HitTiles)) = TPtr(i).GetTile.tile

                        'Hit
                        ActionProcessor.ProcessActions("thit" & TPtr(i).GetTile.tile, curGroup)
                        If ChangedLevel Then Exit Sub

                        'Hit specified direction
                        ActionProcessor.ProcessActions(ActionName & TPtr(i).GetTile.tile, curGroup)
                        If ChangedLevel Then Exit Sub

                        If UBound(TPtr) = 1 And ActionName = "ttop" Then
                            'Exclusively on top
                            ActionProcessor.ProcessActions("texc" & TPtr(i).GetTile.tile, curGroup)
                            If ChangedLevel Then Exit Sub
                        End If
                    End If

NextI:
                Next
            End Sub

            Function ProcessGroupHitActions(ByVal Ptr As TilePtr, ByVal TPtr() As TilePtr, ByVal ActionName As String) As Boolean
                CurTile = Ptr
                SetCurGroup(CurTile.GetTile.Group, CurTile.X, CurTile.Y, CurTile.Width, CurTile.Height, CurTile.GetTile.HitPoints, CurTile.GetTile.Frame, CurTile.GetTile.AnimIndex, CurTile.GetTile.GetTile.name)

                Dim Group As String = Ptr.GetTile.Group

                'Hit
                For j As Integer = 1 To UBound(GroupTriggers)
                    If GroupTriggers(j) = "ghit" & LevelText & Group Then GoTo DoneHit
                Next
                ActionProcessor.ProcessActions("ghit" & LevelText & Group, curGroup)
                If ChangedLevel Then Exit Function
                ReDim Preserve GroupTriggers(UBound(GroupTriggers) + 1)
                GroupTriggers(UBound(GroupTriggers)) = "ghit" & LevelText & Group
DoneHit:

                'Hit specified direction
                For j As Integer = 1 To UBound(GroupTriggers)
                    If GroupTriggers(j) = ActionName Then GoTo DoneHitDir
                Next
                ActionProcessor.ProcessActions(ActionName, curGroup)
                If ChangedLevel Then Exit Function
                ReDim Preserve GroupTriggers(UBound(GroupTriggers) + 1)
                GroupTriggers(UBound(GroupTriggers)) = ActionName
DoneHitDir:

                'Exclusively on top
                If UBound(TPtr2) = 1 And ActionName = "gtop" & LevelText & Group Then
                    For j As Integer = 1 To UBound(GroupTriggers)
                        If GroupTriggers(j) = "gexc" & LevelText & Group Then GoTo DoneExcTop
                    Next
                    ActionProcessor.ProcessActions("gexc" & LevelText & Group, curGroup)
                    If ChangedLevel Then Exit Function
                    ReDim Preserve GroupTriggers(UBound(GroupTriggers) + 1)
                    GroupTriggers(UBound(GroupTriggers)) = "gexc" & LevelText & Group
                End If
DoneExcTop:

            End Function
#End Region

        End Structure

        Public Character As New psCharacter
    End Module
End Namespace