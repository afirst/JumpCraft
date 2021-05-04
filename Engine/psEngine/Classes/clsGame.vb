Imports PlatformStudio.psMap.psLayer

#Region "Map"
<Serializable()> _
Public Structure psMap

#Region "Layer"
    <Serializable()> _
    Public Structure psLayer
        Implements System.Runtime.Serialization.ISerializable

#Region "MapTile"
        <Serializable()> _
        Public Structure psMapTile
            Dim tile As Short
            Dim Frame As Short
            Dim Stopped As Boolean
            <NonSerialized()> Private _AnimStart As Single
            <NonSerialized()> Private _AnimIndex As Byte
            Dim Group As String
            Dim Path As psPath

            <NonSerialized()> Private _HitPoints As Byte
            Property HitPoints() As Byte
                Get
                    Return _HitPoints
                End Get
                Set(ByVal Value As Byte)
                    _HitPoints = Value
                End Set
            End Property

            <NonSerialized()> Private _Invisible As Boolean
            Property Invisible() As Boolean
                Get
                    Return _Invisible
                End Get
                Set(ByVal Value As Boolean)
                    _Invisible = Value
                End Set
            End Property

            <NonSerialized()> Private _pathX As Single, _pathY As Single

            Sub UpdatedPath(ByVal index As Integer, ByVal layer As Integer)
                GetOffset(index, layer, Me, _pathX, _pathY)
            End Sub

            Property PathX() As Single
                Get
                    Return _pathX
                End Get
                Set(ByVal Value As Single)
                    _pathX = Value
                End Set
            End Property

            Property PathY() As Single
                Get
                    Return _pathY
                End Get
                Set(ByVal Value As Single)
                    _pathY = Value
                End Set
            End Property

            Property AnimIndex() As Byte
                Get
                    Return _AnimIndex
                End Get
                Set(ByVal Value As Byte)
                    _AnimIndex = Value
                End Set
            End Property

            ReadOnly Property GetTile() As psTile
                Get
                    Return Game.tileset.tiles(tile)
                End Get
            End Property

            Sub SetAnimStart(ByVal StartTime As Single)
                _AnimStart = StartTime
            End Sub

            Function GetAnimStart() As Single
                Return _AnimStart
            End Function

            Sub Clear()
                tile = 0
                _AnimStart = 0
                Frame = 0
                AnimIndex = 0
                Erase Path.Pts
                Path.Speed = 3
                Path.Enclosed = False
                Path.Exists = False
            End Sub

            ReadOnly Property TileName() As String
                Get
                    Return Game.tileset.tiles(tile).name
                End Get
            End Property

            Function Clone() As psMapTile
                Dim tmp As psMapTile
                With tmp
                    .tile = tile
                    ._AnimStart = _AnimStart
                    .Frame = Frame
                    .Stopped = Stopped
                    .Group = Group
                    .Path = Path.Clone
                    .AnimIndex = AnimIndex
                    ._HitPoints = _HitPoints
                End With
                Return tmp
            End Function

            ReadOnly Property w() As Integer
                Get
                    Return Game.tileset.tiles(tile).sectionw
                End Get
            End Property

            ReadOnly Property h() As Integer
                Get
                    Return Game.tileset.tiles(tile).sectionh
                End Get
            End Property

            ReadOnly Property Behavior() As psTile.TileBehavior
                Get
                    Return Game.tileset.tiles(tile).behavior
                End Get
            End Property

            Sub UpdateFrame()
                psMod1.UpdateFrame(Game.tileset.tiles(Me.tile), Me.AnimIndex, Me._AnimStart, Me.Frame, Me.Stopped)
            End Sub
        End Structure
#End Region

        Dim obj() As psMapTile

        Function Clone() As psLayer
            Dim newLayer As New psLayer
            If Not obj Is Nothing Then
                newLayer.obj = obj.Clone
            End If
            Return newLayer
        End Function

        Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
            With info
                If obj Is Nothing Then
                    .AddValue("count", 0)
                    Return
                End If
                .AddValue("count", obj.Length - 1)
                For i As Integer = 1 To obj.Length - 1
                    .AddValue(CStr(i), obj(i).tile)
                    If obj(i).tile > 0 Then
                        .AddValue(CStr(i) & "f", obj(i).Frame)
                        .AddValue(CStr(i) & "s", obj(i).Stopped)
                        Dim bln As Boolean = ((Not obj(i).Group Is Nothing) AndAlso obj(i).Group <> "") OrElse obj(i).Path.Exists
                        .AddValue(CStr(i) & "b", CByte(IIf(bln, 1, 0)))
                        If bln Then
                            .AddValue(CStr(i) & "g", obj(i).Group)
                            .AddValue(CStr(i) & "p", obj(i).Path)
                        End If
                    End If
                Next
            End With
        End Sub

        Private Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            With info
                If psFileUpdater.curVersion < 2.2 Then
                    obj = .GetValue("obj", GetType(psMapTile()))
                Else
                    ReDim obj(.GetInt32("count"))
                    For i As Integer = 1 To UBound(obj)
                        obj(i).tile = .GetInt16(CStr(i))
                        If obj(i).tile > 0 Then
                            obj(i).Frame = .GetInt16(CStr(i) & "f")
                            obj(i).Stopped = .GetBoolean(CStr(i) & "s")
                            Dim b As Byte = .GetByte(CStr(i) & "b")
                            If b = 1 Then
                                obj(i).Group = .GetString(CStr(i) & "g")
                                obj(i).Path = .GetValue(CStr(i) & "p", GetType(psPath))
                            Else
                                obj(i).Group = ""
                            End If
                        End If
                    Next
                End If
            End With
        End Sub
    End Structure
#End Region

    Private obj() As psLayer
    Private mapw As Integer, maph As Integer
    Dim MapName As String
    Shared CurLayer As Integer
    Public Background As psUI.psBackground
    <NonSerialized()> Private Cloning As Boolean
    Dim loc As psLocationLayer
    Dim Music As String, Volume As Integer

    Property Layer(ByVal index As Integer) As psLayer
        Get
            Return obj(index)
        End Get
        Set(ByVal Value As psLayer)
            obj(index) = Value
        End Set
    End Property

    Function Clone() As psMap
        Dim tmp As New psMap
        Dim i As Integer, j As Integer

        ReDim tmp.obj(4)
        For i = 0 To 3
            tmp.obj(i) = New psLayer
        Next
        tmp.Background = New psUI.psBackground

        tmp.Cloning = True
        tmp.ResizeMap(mapw, maph)
        tmp.Cloning = False
        tmp.Background = Background.Clone

        For i = 0 To 3
            For j = 1 To obj(i).obj.GetUpperBound(0)
                tmp.obj(i).obj(j) = obj(i).obj(j).Clone
                'tmp.obj(i).obj(j).tile = obj(i).obj(j).tile
                'tmp.obj(i).obj(j).Group = obj(i).obj(j).Group
                'tmp.obj(i).obj(j).Path = obj(i).obj(j).Path.Clone
            Next
        Next
        tmp.MapName = MapName
        tmp.Music = Music
        tmp.Volume = Volume

        tmp.loc = loc.Clone
        Return tmp
    End Function

    Friend Sub Save()
        Background.Save()
        loc.Save()
    End Sub

    Friend Sub Load()
        If psFileHandler.OldFileType Then
            mapw = psFileHandler.bReader.ReadInt32
            maph = psFileHandler.bReader.ReadInt32
            ReDim obj(3)
            For i As Integer = 0 To 3
                psFileHandler.Read(obj(i))
            Next
        End If
        Background.Load()
        loc.Load()
        ResetTempLayer()
    End Sub

    Sub Init()
        ReDim obj(4)
        Dim i As Integer
        For i = 0 To 3
            obj(i) = New psLayer
        Next
        ResetTempLayer()
        CurLayer = 2
        Background = New psUI.psBackground
        loc.Init()
    End Sub

    Private _TempEntry() As Boolean

    Sub ResetTempLayer(Optional ByVal Max As Integer = 0)
        ReDim Preserve obj(4)
        ReDim obj(4).obj(Max)
        ReDim _TempEntry(Max)
    End Sub

    Sub AddToTemp(ByVal Tile As psMapTile, ByVal Index As Integer)
        obj(4).obj(Index) = Tile
        _TempEntry(Index) = True
    End Sub

    ReadOnly Property TempEntry(ByVal Index As Integer) As Boolean
        Get
            Return _TempEntry(Index)
        End Get
    End Property

    ReadOnly Property LastTempTile() As Integer
        Get
            Return UBound(obj(4).obj)
        End Get
    End Property

    ReadOnly Property MapWidth() As Integer
        Get
            Return mapw
        End Get
    End Property

    ReadOnly Property MapHeight() As Integer
        Get
            Return maph
        End Get
    End Property

    Property Cells(ByVal x As Integer, ByVal y As Integer, Optional ByVal Layer As Integer = -1) As Integer
        Get
            If Layer = -1 Then Layer = CurLayer
            Return obj(Layer).obj(mapw * (y - 1) + x).tile
        End Get
        Set(ByVal Value As Integer)
            If Layer = -1 Then Layer = CurLayer
            If x < 1 OrElse x > Game.CurMapWidth OrElse _
                y < 1 OrElse y > Game.CurMapHeight Then Return
            obj(Layer).obj(mapw * (y - 1) + x).tile = Value
        End Set
    End Property

    Property Cells2(ByVal x As Integer, ByVal y As Integer, Optional ByVal Layer As Integer = -1) As psMapTile
        Get
            If Layer = -1 Then Layer = CurLayer
            Return obj(Layer).obj(mapw * (y - 1) + x)
        End Get
        Set(ByVal Value As psMapTile)
            If Layer = -1 Then Layer = CurLayer
            If x < 1 OrElse x > Game.CurMapWidth OrElse _
                y < 1 OrElse y > Game.CurMapHeight Then Return
            obj(Layer).obj(mapw * (y - 1) + x) = Value
        End Set
    End Property

    Property Cells1D(ByVal i As Integer, Optional ByVal Layer As Integer = -1) As Short
        Get
            If Layer = -1 Then Layer = CurLayer
            Return obj(Layer).obj(i).tile
        End Get
        Set(ByVal Value As Short)
            If Layer = -1 Then Layer = CurLayer
            If i < 1 OrElse i > obj(Layer).obj.GetUpperBound(0) Then Return
            obj(Layer).obj(i).tile = Value
        End Set
    End Property

    Property Cells1D2(ByVal i As Integer, Optional ByVal Layer As Integer = -1) As psMapTile
        Get
            If Layer = -1 Then Layer = CurLayer
            Return obj(Layer).obj(i)
        End Get
        Set(ByVal Value As psMapTile)
            If Layer = -1 Then Layer = CurLayer
            If i < 1 OrElse i > obj(Layer).obj.GetUpperBound(0) Then Return
            obj(Layer).obj(i) = Value
        End Set
    End Property

    Function Get1DIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        If x < 1 OrElse x > Game.CurMapWidth OrElse _
            y = 0 OrElse y > Game.CurMapHeight Then Return 0
        Return mapw * (y - 1) + x
    End Function

    Sub ClearMap()
        ReDim obj(UBound(obj))
    End Sub

    Sub ClearMap(ByVal newX As Integer, ByVal newY As Integer)
        ReDim obj(newX * newY)
    End Sub

    Sub ResizeMap(ByVal x As Integer, ByVal y As Integer)
        Dim obj2() As psMapTile
        Dim mw As Integer, mh As Integer
        Dim n As Integer
        For n = 0 To 3
            mw = min(x, mapw)
            mh = min(y, maph)
            ReDim obj2(x * y)
            Dim i As Integer, j As Integer
            For i = 1 To x * y
                obj2(i) = New psMapTile
            Next
            For i = 1 To mw
                For j = 1 To mh
                    obj2((j - 1) * x + i) = obj(n).obj((j - 1) * mapw + i)
                Next
            Next
            obj(n).obj = obj2
        Next
        mapw = x
        maph = y
    End Sub

    Function Conv1DTo2D(ByVal i As Integer) As Point
        Return New Point(Mod2(i, mapw), _
            (i - (Mod2(i, mapw))) / mapw + 1)
    End Function

    Private Function min(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        If n1 < n2 Then
            Return n1
        Else
            Return n2
        End If
    End Function

    ReadOnly Property MapSize1D() As Integer
        Get
            Return obj(0).obj.GetUpperBound(0)
        End Get
    End Property

    Delegate Sub AfterDrawLayer(ByVal CurLayer As Integer)
    Sub Draw(Optional ByVal Grid As Boolean = False, Optional ByVal AfterDrawLayer As AfterDrawLayer = Nothing)
        If Game.tileW = 0 Or Game.tileH = 0 Then Exit Sub

        'Counters
        Dim i As Integer, j As Integer, n As Integer

        'Normal coordinates
        Dim x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer

        '"Changed" coordinates - used for parallax (50% scrolling)
        Dim cx1 As Single, cx2 As Integer
        Dim cy1 As Single, cy2 As Integer

        'Normal and changed pixel coordinates
        Dim x1_2 As Integer, cx1_2 As Integer
        Dim y1_2 As Integer, cy1_2 As Integer

        x1 = Game.cam.X
        y1 = Game.cam.Y
        x2 = x1 + Game.cam.w
        y2 = y1 + Game.cam.h
        x1 = x1 \ Game.tileW + 1
        y1 = y1 \ Game.tileH + 1
        x2 = x2 \ Game.tileW + 2
        y2 = y2 \ Game.tileH + 2
        x1_2 = Game.cam.X
        y1_2 = Game.cam.Y
        If x2 > Game.CurMap.MapWidth Then x2 = Game.CurMap.MapWidth
        If y2 > Game.CurMap.MapHeight Then y2 = Game.CurMap.MapHeight

        Game.Drawing.RelativeToCam = False

        'Draw the background
        If Game.LayerVisible(psGame.psLayerNames.Back) Then
            Background.Draw(0, 0, Game.cam.w, Game.cam.h)
        End If

        'Draw grid
        If Grid Then
            Game.DrawGrid()
        End If

        Game.Drawing.RelativeToCam = True
        Game.Drawing.AffectedByScrollSpeed = False

        'Draw the map
        With Game.Drawing
            For n = 0 To 3
                If n = 0 Then 'Parallax (50% scrolling)
                    cx1 = Int(x1 * Game.ScrollSpeed(n))
                    cx1_2 = Game.cam.X * Game.ScrollSpeed(n)
                    If cx1 = 0 Then cx1 = 1
                    cx2 = cx1 + (x2 - x1)
                    If cx2 > MapWidth Then cx2 = MapWidth
                    cy1 = Int(y1 * Game.ScrollSpeed(n))
                    cy1_2 = Game.cam.Y * Game.ScrollSpeed(n)
                    If cy1 = 0 Then cy1 = 1
                    cy2 = cy1 + (y2 - y1)
                    If cy2 > MapHeight Then cy2 = MapHeight
                ElseIf n = 1 Then 'Normal (100% scrolling)
                    cx1 = x1 : cx2 = x2
                    cx1_2 = Game.cam.X
                    cy1 = y1 : cy2 = y2
                    cy1_2 = Game.cam.Y
                End If
                If Game.LayerVisible(n + 1) Then
                    For i = AtLeast1(cx1 - Game.tileset.MaxTileW2 \ Game.tileW) To cx2 ' cx1 To cx2
                        For j = AtLeast1(cy1 - Game.tileset.MaxTileH2 \ Game.tileH) To cy2 'y1 To y2
                            With Cells2(i, j, n)
                                If Not (Not Game.InEditor And .Behavior = psTile.TileBehavior.Character) Then 'Do not draw the character in the game
                                    If i + .w \ Game.tileW >= cx1 _
                                    And j + .h \ Game.tileH >= cy1 Then
                                        Dim CurCell As psMapTile
                                        Dim curIndex As Integer
                                        curIndex = Get1DIndex(i, j)
                                        CurCell = obj(n).obj(curIndex)
                                        DrawTile(i, j, n, CurCell, False, cx1_2, x1_2, cy1_2, y1_2)
                                        obj(n).obj(curIndex) = CurCell
                                    End If
                                End If
                            End With
                        Next
                    Next
                End If
                If Not (AfterDrawLayer Is Nothing) Then
                    AfterDrawLayer.Invoke(n)
                End If
            Next
        End With
    End Sub

    Private Function AtLeast1(ByVal value As Integer) As Integer
        If value < 1 Then
            Return 1
        Else
            Return value
        End If
    End Function

    Private tmpPath As psPath
    Sub DrawTile(ByVal i As Single, ByVal j As Single, ByVal n As Integer, ByRef Tile As psMapTile, Optional ByVal Individual As Boolean = False, Optional ByVal cx1_2 As Integer = 0, Optional ByVal x1_2 As Integer = 0, Optional ByVal cy1_2 As Integer = 0, Optional ByVal y1_2 As Integer = 0, Optional ByVal Transformed As Boolean = True, Optional ByVal Color_ As Integer = &HFFFFFFFF, Optional ByVal MovedLeft As Boolean = False)
        If Tile.tile = 0 Then Exit Sub

        If Tile.Invisible Then Exit Sub
        If (n > 0) And (Game.InEditor = False And Tile.Path.Exists And Individual = False) Then Exit Sub

        '.DrawImage(game.tileset.tiles(Cells(i, j, n)).name, (i - 1) * game.tileW - cx1_2 + x1_2, (j - 1) * game.tileH)

        If Tile.Path.Exists And Game.ScrollSpeed(n) <> 1 Then
            tmpPath = Tile.Path.Clone
            For z As Integer = 0 To UBound(Tile.Path.Pts)
                For zz As Byte = 0 To 3
                    Tile.Path.Pts(z).XPoint(zz) = (Tile.Path.Pts(z).XPoint(zz) + Game.cam.X) - (Game.cam.X * Game.ScrollSpeed(n))
                    Tile.Path.Pts(z).YPoint(zz) = (Tile.Path.Pts(z).YPoint(zz) + Game.cam.Y) - (Game.cam.Y * Game.ScrollSpeed(n))
                Next
            Next
        End If

        'Draw individual tile
        If Individual Then
            'Normal coordinates
            Dim x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer

            '"Changed" coordinates - used for parallax (50% scrolling)
            Dim cx1 As Single, cx2 As Integer
            Dim cy1 As Single, cy2 As Integer

            x1 = Game.cam.X
            y1 = Game.cam.Y
            x2 = x1 + Game.cam.w
            y2 = y1 + Game.cam.h
            x1 = x1 \ Game.tileW + 1
            y1 = y1 \ Game.tileH + 1
            x2 = x2 \ Game.tileW + 2
            y2 = y2 \ Game.tileH + 2
            x1_2 = Game.cam.X
            y1_2 = Game.cam.Y
            If x2 > Game.CurMap.MapWidth Then x2 = Game.CurMap.MapWidth
            If y2 > Game.CurMap.MapHeight Then y2 = Game.CurMap.MapHeight

            If n = 0 Then 'Parallax (50% scrolling)
                cx1 = Int(x1 * Game.ScrollSpeed(n))
                cx1_2 = Game.cam.X * Game.ScrollSpeed(n)
                If cx1 = 0 Then cx1 = 1
                cx2 = cx1 + (x2 - x1)
                If cx2 > MapWidth Then cx2 = MapWidth
                cy1 = Int(y1 * Game.ScrollSpeed(n))
                cy1_2 = Game.cam.Y * Game.ScrollSpeed(n)
                If cy1 = 0 Then cy1 = 1
                cy2 = cy1 + (y2 - y1)
                If cy2 > MapHeight Then cy2 = MapHeight
            Else 'Normal (100% scrolling)
                cx1 = x1 : cx2 = x2
                cx1_2 = Game.cam.X
                cy1 = y1 : cy2 = y2
                cy1_2 = Game.cam.Y
            End If
        End If

        Dim tmpFrame As Integer, tmpStartTime As Single

        Dim TileX As Integer, TileY As Integer
        TileX = (i - 1) * Game.tileW - cx1_2 + x1_2
        TileY = (j - 1) * Game.tileH - cy1_2 + y1_2
        Dim TileXOrig As Integer = TileX
        Dim TileYOrig As Integer = TileY

        'Get the current position on the path
        If Transformed Then
            'Game.InEditor = False

            'If (Tile.PathX = 0 And Tile.PathY = 0) Then
            'If Game.InEditor Or (Tile.PathX = 0 And Tile.PathY = 0) Then
            If Game.InEditor Or n = 0 Then
                GetOffset(Game.CurMap.Get1DIndex(i, j), n, Tile, TileX, TileY)
                Tile.PathX = TileX
                Tile.PathY = TileY

                If Game.tileset.tiles(Tile.tile).Anim(0).Interval > 0 Then
                    Dim tmpOldX As Single, tmpOldY As Single
                    Dim tmpNewX As Single, tmpNewY As Single
                    Dim tmpTile2 As psMapTile = Tile
                    GetOffset(Game.CurMap.Get1DIndex(i, j), n, tmpTile2, tmpNewX, tmpNewY)
                    tmpTile2.Path.Start += 0.1
                    GetOffset(Game.CurMap.Get1DIndex(i, j), n, tmpTile2, tmpOldX, tmpOldY)
                    tmpTile2 = Nothing
                    If tmpNewX < tmpOldX Then
                        MovedLeft = True
                    Else
                        MovedLeft = False
                    End If
                End If

            End If
            'Else
            'TileX = Tile.PathX
            'TileY = Tile.PathY
            'End If

            'Game.InEditor = True
        Else
            Tile.PathX = 0
            Tile.PathY = 0
        End If

        With Game.Drawing
            If Tile.tile > 0 AndAlso Tile.tile <= Game.tileset.NumTiles Then
                tmpFrame = Tile.Frame
                With Game.tileset.tiles(Tile.tile).Anim(0)
                    If tmpFrame = 0 Then tmpFrame = Int(Rnd(1) * (Math.Abs(.StopFrame - .StartFrame) + 1)) + IIf(.StopFrame < .StartFrame, .StopFrame, .StartFrame)
                End With
                tmpStartTime = Tile.GetAnimStart
                .RelativeToCam = True
                .AffectedByScrollSpeed = False

                Dim tmpSgn As Short = IIf(MovedLeft AndAlso Tile.Path.Exists AndAlso Game.tileset.tiles(Tile.tile).Anim(0).Interval > 0, -1, 1)
                Dim FlipOffsetX As Short = IIf(tmpSgn = -1, Game.tileset.tileSecW(Tile.tile), 0)

                'Draw path preview and guides in map editor
                If Game.InEditor AndAlso (Tile.Path.Exists And Transformed) Then
                    'Draw original tile "ghost"
                    .DrawSprite( _
                        Game.tileset.tiles(Tile.tile).name, _
                        CurRect(Game.tileset.tiles(Tile.tile), Tile.AnimIndex, tmpStartTime, tmpFrame, Tile.Stopped), _
                        TileXOrig + FlipOffsetX, _
                        TileYOrig, _
                        tmpSgn * Game.tileset.tileSecW(Tile.tile), _
                        Game.tileset.tileSecH(Tile.tile), _
                        0, _
                        Color.FromArgb(128, 255, 255, 255))

                    'Connect the ghost to the transformed
                    .DrawLine(TileXOrig + Tile.w * 0.5 + 1, _
                        TileYOrig + Tile.h * 0.5 + 1, _
                        TileX + Tile.w * 0.5 + 1, _
                        TileY + Tile.h * 0.5 + 1, _
                        Color.FromArgb(128, 0, 0, 0))
                    .DrawLine(TileXOrig + Tile.w * 0.5, _
                        TileYOrig + Tile.h * 0.5, _
                        TileX + Tile.w * 0.5, _
                        TileY + Tile.h * 0.5, _
                        Color.FromArgb(128, 64, 64, 255))

                    'Draw path
                    If Options.mDrawTilePaths Then
                        For i = 0 To UBound(Tile.Path.Pts)
                            PathHelper.DrawSingleBezier(Tile.Path.Pts, Tile.Path.Enclosed, i, (i = UBound(Tile.Path.Pts)), 0.125, False, False, Color.FromArgb(192, 255, 0, 0))
                        Next
                    End If
                End If

                'Draw transformed tile
                .DrawSprite( _
                    Game.tileset.tiles(Tile.tile).name, _
                    CurRect(Game.tileset.tiles(Tile.tile), Tile.AnimIndex, tmpStartTime, tmpFrame, Tile.Stopped), _
                    TileX + FlipOffsetX, _
                    TileY, _
                    tmpSgn * Game.tileset.tileSecW(Tile.tile), _
                    Game.tileset.tileSecH(Tile.tile), _
                    0, _
                    Color.FromArgb(Color_))

                'Draw group name in map editor
                If Game.InEditor AndAlso Tile.Group <> "" Then
                    .DrawText("internal|SmFont", _
                        Tile.Group, _
                        New Rectangle(TileX + 1, _
                        TileY + 1, _
                        Game.tileset.tileSecW(Tile.tile), _
                        Game.tileset.tileSecH(Tile.tile)), _
                        Color.Black)
                    .DrawText("internal|SmFont", _
                        Tile.Group, _
                        New Rectangle(TileX, _
                        TileY, _
                        Game.tileset.tileSecW(Tile.tile), _
                        Game.tileset.tileSecH(Tile.tile)), _
                        Color.White)
                End If
                .AffectedByScrollSpeed = True

                'Update tile
                Tile.Frame = tmpFrame
                Tile.SetAnimStart(tmpStartTime)
            End If
        End With

        If Tile.Path.Exists And Game.ScrollSpeed(n) <> 1 Then
            Tile.Path.Pts = tmpPath.Pts.Clone
        End If
    End Sub
End Structure
#End Region

#Region "Location"
<Serializable()> _
Public Structure psLocation
    <NonSerialized()> Private r As Rectangle
    <NonSerialized()> Private _ChkPos As Byte
    Dim Name As String

    Enum CheckPosition
        None = 0
        TopLeft
        TopRight
        BottomLeft
        BottomRight
    End Enum

    Property ChkPos() As CheckPosition
        Get
            Return _ChkPos
        End Get
        Set(ByVal Value As CheckPosition)
            _ChkPos = Value
        End Set
    End Property

    Function Clone() As psLocation
        Dim tmp As psLocation
        With tmp
            .Name = Name
            .r = r
            ._ChkPos = _ChkPos
        End With
        Return tmp
    End Function

    Sub New(ByVal l_Rectangle As Rectangle, ByVal l_Name As String)
        Rectangle = l_Rectangle
        Name = l_Name
    End Sub

    Property Rectangle() As Rectangle
        Get
            Return r
        End Get
        Set(ByVal Value As Rectangle)
            r = Value
        End Set
    End Property

    Friend Sub Save()
        psFileHandler.bWriter.Write(r.X)
        psFileHandler.bWriter.Write(r.Y)
        psFileHandler.bWriter.Write(r.Width)
        psFileHandler.bWriter.Write(r.Height)
        psFileHandler.bWriter.Write(_ChkPos)
    End Sub

    Friend Sub Load()
        r.X = psFileHandler.bReader.ReadInt32
        r.Y = psFileHandler.bReader.ReadInt32
        r.Width = psFileHandler.bReader.ReadInt32
        r.Height = psFileHandler.bReader.ReadInt32
        _ChkPos = psFileHandler.bReader.ReadByte
    End Sub

    Property X() As Integer
        Get
            Return r.X
        End Get
        Set(ByVal Value As Integer)
            r.X = Value
        End Set
    End Property

    Property Y() As Integer
        Get
            Return r.Y
        End Get
        Set(ByVal Value As Integer)
            r.Y = Value
        End Set
    End Property

    Property Width() As Integer
        Get
            Return r.Width
        End Get
        Set(ByVal Value As Integer)
            r.Width = Value
        End Set
    End Property

    Property Height() As Integer
        Get
            Return r.Height
        End Get
        Set(ByVal Value As Integer)
            r.Height = Value
        End Set
    End Property
End Structure
#End Region

#Region "Location Layer"
<Serializable()> _
Public Structure psLocationLayer
    Dim Locations() As psLocation

    Function Clone() As psLocationLayer
        Dim tmp As psLocationLayer, i As Integer
        With tmp
            ReDim .Locations(UBound(Locations))
            For i = 1 To UBound(Locations)
                .Locations(i) = Locations(i).Clone
            Next
        End With
        Return tmp
    End Function

    Friend Sub Save()
        Dim i As Integer
        For i = 1 To UBound(Locations)
            Locations(i).Save()
        Next
    End Sub

    Friend Sub Load()
        Dim i As Integer
        For i = 1 To UBound(Locations)
            Locations(i).Load()
        Next
    End Sub

    Sub AddLocation(ByVal Location As psLocation)
        ReDim Preserve Locations(UBound(Locations) + 1)
        Locations(UBound(Locations)) = Location
    End Sub

    Sub RemoveLocation(ByVal index As Integer)
        Dim i As Integer
        For i = index To UBound(Locations) - 1
            Locations(i) = Locations(i + 1)
        Next
        ReDim Preserve Locations(UBound(Locations) - 1)
    End Sub

    ReadOnly Property NumLocations() As Integer
        Get
            Return UBound(Locations)
        End Get
    End Property

    Sub Init()
        ReDim Locations(0)
    End Sub

    Sub Draw()
        If Game.LayerVisible(psGame.psLayerNames.Location) = False Then Exit Sub
        Dim i As Integer
        With Game.Drawing
            .RelativeToCam = True
            For i = 1 To NumLocations
                DrawLocation(Locations(i))
            Next
        End With
    End Sub

    Sub DrawLocation(ByVal loc As psLocation)
        DrawLocation(loc, Color.FromArgb(64, 0, 128, 255), Color.FromArgb(64, 0, 255, 128), Color.FromArgb(96, 0, 0, 255))
    End Sub

    Sub DrawLocation(ByVal loc As psLocation, ByVal Color1 As Color, ByVal Color2 As Color, ByVal Border As Color)
        'Find the character tile index
        Dim CharTile As Integer
        For i As Integer = 1 To Game.tileset.NumTiles
            If Game.tileset.tiles(i).behavior = psTile.TileBehavior.Character Then
                CharTile = i
                Exit For
            End If
        Next
        If Game.tileset.NumTiles > 0 And CharTile = 0 Then CharTile = 1

        With Game.Drawing
            .AffectedByScrollSpeed = False
            .DrawFilledBox(loc.Rectangle.X, loc.Rectangle.Y, loc.Rectangle.Width, loc.Rectangle.Height, Color1, Color2, Color1, Color2)
            .DrawText(loc.Name, New Rectangle(loc.Rectangle.X + 1, loc.Rectangle.Y + 1, loc.Rectangle.Width, loc.Rectangle.Height), Color.Black)
            .DrawText(loc.Name, loc.Rectangle, Color.White)
            .DrawBox(loc.Rectangle.X, loc.Rectangle.Y, loc.Rectangle.Width, loc.Rectangle.Height, Border)

            'Draw the checkpoint
            If loc.ChkPos > psLocation.CheckPosition.None Then
                If CharTile > 0 Then
                    .DrawSprite(Game.tileset.tiles(CharTile).name, CurRect(Game.tileset.tiles(CharTile), 1), ChkX(loc, CharTile), ChkY(loc, CharTile), Game.tileset.tiles(CharTile).sectionw, Game.tileset.tiles(CharTile).sectionh, 0, Color.FromArgb(128, 255, 255, 255))
                End If
                .DrawBox(ChkX(loc, CharTile) + 1, ChkY(loc, CharTile) + 1, Game.tileset.tiles(CharTile).sectionw, Game.tileset.tiles(CharTile).sectionh, Color.FromArgb(128, 0, 0, 0))
                .DrawBox(ChkX(loc, CharTile), ChkY(loc, CharTile), Game.tileset.tiles(CharTile).sectionw, Game.tileset.tiles(CharTile).sectionh, Color.FromArgb(128, 255, 255, 255))
            End If

            .AffectedByScrollSpeed = True
        End With
    End Sub

    ReadOnly Property ChkX(ByVal loc As psLocation, ByVal CharTile As Integer) As Integer
        Get
            Select Case loc.ChkPos
                Case psLocation.CheckPosition.TopLeft
                    Return loc.X
                Case psLocation.CheckPosition.TopRight
                    Return loc.X + loc.Width - Game.tileset.tiles(CharTile).sectionw
                Case psLocation.CheckPosition.BottomLeft
                    Return loc.X
                Case psLocation.CheckPosition.BottomRight
                    Return loc.X + loc.Width - Game.tileset.tiles(CharTile).sectionw
            End Select
        End Get
    End Property

    ReadOnly Property ChkY(ByVal loc As psLocation, ByVal CharTile As Integer) As Integer
        Get
            Select Case loc.ChkPos
                Case psLocation.CheckPosition.TopLeft
                    Return loc.Y
                Case psLocation.CheckPosition.TopRight
                    Return loc.Y
                Case psLocation.CheckPosition.BottomLeft
                    Return loc.Y + loc.Height - Game.tileset.tiles(CharTile).sectionh
                Case psLocation.CheckPosition.BottomRight
                    Return loc.Y + loc.Height - Game.tileset.tiles(CharTile).sectionh
            End Select
        End Get
    End Property
End Structure
#End Region

#Region "Tileset"
Public Enum BoundaryShape
    Rectangle
    Circle
    Triangle1
    Triangle2
    Triangle3
    Triangle4
End Enum

Public Enum BoundaryType
    [Default]
    Rectangular
    OneCustom
    Custom
End Enum

<Serializable()> _
Public Structure psBoundaryShape
    Dim r As Rectangle
    Dim s As BoundaryShape

    Sub New(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal shapeType As BoundaryShape)
        r = New Rectangle(x1, y1, x2 - x1, y2 - y1)
        s = shapeType
    End Sub
End Structure

<Serializable()> _
Public Structure psTileBoundaries
    Dim Style As BoundaryType
    Dim shapes()() As psBoundaryShape
    Dim FillPoint As Point
End Structure

<Serializable()> _
Public Structure psTile
    Enum TileBehavior
        Solid = 0
        Background = 1
        Collectable = 2
        Ledge = 3
        Character = 4
        NoGravity = 5
    End Enum

    Dim filename As String, name As String
    Dim width As Integer, height As Integer
    Dim colorkey As Integer
    Dim sectionw As Integer, sectionh As Integer
    Dim intBehavior As Integer
    Private hp As Byte 'hitpoints
    <NonSerialized()> Dim Boundaries As psTileBoundaries

    ReadOnly Property SuggestedWidth() As Integer
        Get
            Return Game.Drawing.Tex(name).bmp.Width
        End Get
    End Property

    ReadOnly Property SuggestedHeight() As Integer
        Get
            Return Game.Drawing.Tex(name).bmp.Height
        End Get
    End Property

    ReadOnly Property ScaleX() As Single
        Get
            Return width / SuggestedWidth
        End Get
    End Property

    ReadOnly Property ScaleY() As Single
        Get
            Return height / SuggestedHeight
        End Get
    End Property

    'Animation properties
    <Serializable()> _
    Structure psTileAnimation
        Dim StartFrame As Integer, StopFrame As Integer
        Dim Interval As Single, AnimInterval As Single

        ReadOnly Property AnimLength() As Single
            Get
                Return Interval * (StopFrame - StartFrame + 1)
            End Get
        End Property
    End Structure
    Dim Anim() As psTileAnimation

    Property behavior() As TileBehavior
        Get
            Return intBehavior
        End Get
        Set(ByVal Value As TileBehavior)
            intBehavior = Value
        End Set
    End Property

    Sub New(ByVal filename_ As String, ByVal name_ As String)
        filename = filename_
        name = name_
        ReDim Anim(5)
        Dim i As Integer
        For i = 0 To 5
            Anim(i) = New psTileAnimation
            With Anim(i)
                .StartFrame = 1
                .StopFrame = 1
                .Interval = 0
                .AnimInterval = 0
            End With
        Next
    End Sub

    Property HitPoints() As Byte
        Get
            Return hp
        End Get
        Set(ByVal Value As Byte)
            hp = Value
        End Set
    End Property
End Structure

<Serializable()> _
Public Structure psTileset
    Dim tiles() As psTile

    Sub Load()
        'Load the new images
        'If Not Game.InEditor Then
        'Game.Drawing.AutoGetBits = True
        'End If
        Dim i As Integer, j As Integer
        For i = 1 To NumTiles
            With tiles(i)
LookAgain:
                For j = 1 To i - 1
                    If tiles(j).name = tiles(i).name Then
                        tiles(i).name = tiles(i).name & "_2"
                        GoTo LookAgain
                    End If
                Next
                Try
                    Game.Drawing.img_Remove(.name)
                Catch
                End Try
                Game.Drawing.img_Add( _
                    .filename, .name, Color.FromArgb(.colorkey), .width, .height, .sectionw, .sectionh)
                If FileNotFoundCancel Then Exit Sub
            End With
        Next
        tiles(0) = New psTile
        'Game.Drawing.AutoGetBits = False
    End Sub

    Sub LoadData()
        For i As Integer = 1 To NumTiles
            psFileHandler.Read(tiles(i).Boundaries)
        Next
    End Sub

    Sub SaveData()
        For i As Integer = 1 To NumTiles
            psFileHandler.Write(tiles(i).Boundaries)
        Next
    End Sub

    Sub AddTile(ByVal tile As psTile)
        ReDim Preserve tiles(UBound(tiles) + 1)
        tiles(UBound(tiles)) = tile
        Game.Drawing.img_Add(tile.filename, tile.name, Color.FromArgb(tile.colorkey), tile.width, tile.height, tile.sectionw, tile.sectionh)
        With tiles(UBound(tiles))
            If .width = 0 Then .width = Game.Drawing.img_Width(Game.Drawing.img_UBound)
            If .height = 0 Then .height = Game.Drawing.img_Height(Game.Drawing.img_UBound)
            If .colorkey = 0 Then .colorkey = Game.Drawing.img_ColorKey(Game.Drawing.img_UBound).ToArgb
            If .sectionw = 0 Then .sectionw = Game.Drawing.img_SectionW(Game.Drawing.img_UBound)
            If .sectionh = 0 Then .sectionh = Game.Drawing.img_SectionH(Game.Drawing.img_UBound)
            .name = tile.name
            .filename = tile.filename
        End With
    End Sub

    Property tileWidth(ByVal index As Integer) As Integer
        Get
            Return tiles(index).width
        End Get
        Set(ByVal Value As Integer)
            tiles(index).width = Value
            Game.Drawing.img_Width(tiles(index).name) = Value
        End Set
    End Property

    Property tileHeight(ByVal index As Integer) As Integer
        Get
            Return tiles(index).height
        End Get
        Set(ByVal Value As Integer)
            tiles(index).height = Value
            Game.Drawing.img_Height(tiles(index).name) = Value
        End Set
    End Property

    Property tileSecW(ByVal index As Integer) As Integer
        Get
            Return tiles(index).sectionw
        End Get
        Set(ByVal Value As Integer)
            tiles(index).sectionw = Value
            Game.Drawing.img_SectionW(tiles(index).name) = Value
        End Set
    End Property

    Property tileSecH(ByVal index As Integer) As Integer
        Get
            Return tiles(index).sectionh
        End Get
        Set(ByVal Value As Integer)
            tiles(index).sectionh = Value
            Game.Drawing.img_SectionH(tiles(index).name) = Value
        End Set
    End Property

    ReadOnly Property MaxTileW() As Integer
        Get
            Dim i As Integer, val As Integer
            For i = 1 To UBound(tiles)
                If tiles(i).sectionw > val And tiles(i).behavior <> psTile.TileBehavior.Background Then val = tiles(i).sectionw
            Next
            Return val
        End Get
    End Property

    ReadOnly Property MaxTileH() As Integer
        Get
            Dim i As Integer, val As Integer
            For i = 1 To UBound(tiles)
                If tiles(i).sectionh > val And tiles(i).behavior <> psTile.TileBehavior.Background Then val = tiles(i).sectionh
            Next
            Return val
        End Get
    End Property

    ReadOnly Property MaxTileW2() As Integer
        Get
            Dim i As Integer, val As Integer
            For i = 1 To UBound(tiles)
                If tiles(i).sectionw > val Then val = tiles(i).sectionw
            Next
            Return val
        End Get
    End Property

    ReadOnly Property MaxTileH2() As Integer
        Get
            Dim i As Integer, val As Integer
            For i = 1 To UBound(tiles)
                If tiles(i).sectionh > val Then val = tiles(i).sectionh
            Next
            Return val
        End Get
    End Property

    Property tileColorKey(ByVal index As Integer) As Integer
        Get
            Return tiles(index).colorkey
        End Get
        Set(ByVal Value As Integer)
            tiles(index).colorkey = Value
            Game.Drawing.img_ColorKey(tiles(index).name) = Color.FromArgb(Value)
        End Set
    End Property

    Property tileFile(ByVal index As Integer) As String
        Get
            Return tiles(index).filename
        End Get
        Set(ByVal Value As String)
            tiles(index).filename = Value
            Game.Drawing.img_Remove(tiles(index).name)
            Game.Drawing.img_Add(tiles(index).filename, tiles(index).name, Color.FromArgb(tiles(index).colorkey), tiles(index).width, tiles(index).height, tiles(index).sectionw, tiles(index).sectionh)
        End Set
    End Property

    Property tileName(ByVal index As Integer) As String
        Get
            Return tiles(index).name
        End Get
        Set(ByVal Value As String)
            Game.Drawing.img_Key(tiles(index).name) = Value
            tiles(index).name = Value
        End Set
    End Property

    ReadOnly Property tilePreview(ByVal index As Integer) As Bitmap
        Get
            Return Game.Drawing.Tex(tileName(index)).preview
        End Get
    End Property

    ReadOnly Property tileBitmap(ByVal index As Integer) As Bitmap
        Get
            Return Game.Drawing.Tex(tileName(index)).bmp
        End Get
    End Property

    Property tileBehavior(ByVal index As Integer) As psTile.TileBehavior
        Get
            Return tiles(index).behavior
        End Get
        Set(ByVal Value As psTile.TileBehavior)
            tiles(index).behavior = Value
        End Set
    End Property

    Sub RemoveTile(ByVal index As Integer)
        Dim i As Integer
        Game.Drawing.img_Remove(tiles(index).name)
        For i = index To UBound(tiles) - 1
            tiles(i) = tiles(i + 1)
        Next
        ReDim Preserve tiles(UBound(tiles) - 1)
    End Sub

    Sub MoveTile(ByVal index As Integer, ByVal direction As Integer)
        If index + direction < 0 Then direction = -index
        If index + direction > UBound(tiles) Then direction = UBound(tiles) - index

        Dim tmp As psTile
        tmp = tiles(index + direction)
        tiles(index + direction) = tiles(index)
        tiles(index) = tmp
    End Sub

    ReadOnly Property NumTiles() As Integer
        Get
            Return UBound(tiles)
        End Get
    End Property
End Structure
#End Region

'---------

#Region "Game"

Public Class psGame

#Region "Camera"
    <Serializable()> _
    Structure psCamera
        Private _x As Single, _y As Single
        Private _CustomWidth As Integer, _CustomHeight As Integer

        Property X() As Single
            Get
                Return _x
            End Get
            Set(ByVal Value As Single)
                _x = Value
            End Set
        End Property

        Property Y() As Single
            Get
                Return _y
            End Get
            Set(ByVal Value As Single)
                _y = Value
            End Set
        End Property

        Property CustomWidth() As Integer
            Get
                Return _CustomWidth
            End Get
            Set(ByVal Value As Integer)
                _CustomWidth = Value
            End Set
        End Property

        Property CustomHeight() As Integer
            Get
                Return _CustomHeight
            End Get
            Set(ByVal Value As Integer)
                _CustomHeight = Value
            End Set
        End Property

        ReadOnly Property w() As Integer
            Get
                If CustomWidth = 0 Then
                    Return Game.p.Width
                Else
                    Return CustomWidth
                End If
            End Get
        End Property

        ReadOnly Property h() As Integer
            Get
                If CustomHeight = 0 Then
                    Return Game.p.Height
                Else
                    Return CustomHeight
                End If
            End Get
        End Property
    End Structure
#End Region

#Region "Math"
    Structure psMath
        Dim Tag As String

        ReadOnly Property Pi() As Double
            Get
                Return 3.14159265358979
            End Get
        End Property

        Function Collide_PtBox(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal w2 As Integer, ByVal h2 As Integer) As Boolean
            Return (x1 >= x2 AndAlso _
                    x1 <= x2 + w2 AndAlso _
                    y1 >= y2 AndAlso _
                    y1 <= y2 + h2)
        End Function

        Function Collide_PtBox(ByVal x As Integer, ByVal y As Integer, ByVal b As Rectangle) As Boolean
            Return (x >= b.Left AndAlso _
                    x <= b.Right AndAlso _
                    y >= b.Top AndAlso _
                    y <= b.Bottom)
        End Function

        Function Collide_BoxBox(ByVal x1 As Integer, ByVal y1 As Integer, ByVal w1 As Integer, ByVal h1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal w2 As Integer, ByVal h2 As Integer) As Boolean
            Return (x1 <= x2 + w2 AndAlso _
                    y1 <= y2 + h2 AndAlso _
                    x1 + w1 >= x2 AndAlso _
                    y1 + h1 >= y2)
        End Function

        Function Collide_BoxBox(ByVal b1 As Rectangle, ByVal b2 As Rectangle) As Boolean
            Return (b1.X <= b2.X + b2.Width AndAlso _
                    b1.Y <= b2.Y + b2.Height AndAlso _
                    b1.X + b1.Width >= b2.X AndAlso _
                    b1.Y + b1.Height >= b2.Y)
        End Function

        Function Collide_PointTexture(ByVal X As Integer, ByVal Y As Integer, ByVal Key As String, ByRef tile As PlatformStudio.psTile, ByVal Frame As Integer) As Boolean
            X /= Game.Drawing.Tex(Key).ScaleX
            Y /= Game.Drawing.Tex(Key).ScaleY
            If X < 0 OrElse X > Game.Drawing.Tex(Key).sectionw - 1 OrElse _
                Y < 0 OrElse Y > Game.Drawing.Tex(Key).sectionh - 1 Then Return False
            Dim MaxFrame As Integer = Game.Drawing.Tex(Key).width / Game.Drawing.Tex(Key).sectionw * Game.Drawing.Tex(Key).height / Game.Drawing.Tex(Key).sectionh
            If Frame = 0 Or Frame > MaxFrame Then Frame = 1
            With ScaleRect(CurRect(tile, Frame), 1 / Game.Drawing.Tex(Key).ScaleX, 1 / Game.Drawing.Tex(Key).ScaleY)
                X += .X
                Y += .Y
            End With
            Return (Game.Drawing.Tex(Key).Bits(X, Y, 0) > 0)
        End Function

        Function Collide_BoxTexture(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, ByVal Key As String, ByRef tile As PlatformStudio.psTile, ByVal Frame As Integer) As Boolean
            Dim x1, x2, y1, y2 As Integer
            x1 = System.Math.Max(0, X)
            x2 = System.Math.Min(Game.Drawing.Tex(Key).sectionw, X + W)
            y1 = System.Math.Max(0, Y)
            y2 = System.Math.Min(Game.Drawing.Tex(Key).sectionh, Y + H)
            For i As Integer = x1 To x2
                For j As Integer = y1 To y2
                    If Collide_PointTexture(i, j, Key, tile, Frame) Then Return True
                Next
            Next
        End Function

        Function Dist(ByVal X1 As Single, ByVal Y1 As Single, ByVal X2 As Single, ByVal Y2 As Single) As Single
            Return System.Math.Sqrt((X2 - X1) ^ 2 + (Y2 - Y1) ^ 2)
        End Function
    End Structure
#End Region

#Region "Game Properties"
    <Serializable()> _
    Public Structure psGameProperties
        Dim Name As String
        Dim Icon As String
        Dim Version As String
        Dim Credits As String
        Dim Company As String
        Dim Website As String
        Dim Support As String
        Dim fLicenseAgrmt As String
        Dim fReleaseNotes As String
        Dim fReadme As String
        Dim fOtherFiles() As String
        Dim ResWidth As Integer, ResHeight As Integer
        Dim Windowed As Boolean
        Dim WindowTitle As String
        Dim Menus As Boolean
        Dim mnuSupport As Boolean
        Dim mnuWebsite As Boolean
        Dim mnuAbout As Boolean
        Dim NoPixelPerfect As Boolean

        Sub CreateDefaults()
            Name = GetString("defaultGameName")
            Icon = GetString("defaultValue")
            Version = "1.0"
            Credits = GetString("defaultCredits")
            Company = GetString("defaultCompany")
            Website = GetString("defaultWebsite")
            Support = GetString("defaultSupportEmail")
            fLicenseAgrmt = GetString("noValue")
            fReleaseNotes = GetString("noValue")
            fReadme = GetString("noValue")
            ReDim fOtherFiles(0)
            ResWidth = 450
            ResHeight = 300
            Windowed = True
            WindowTitle = GetString("defaultGameWithVersion")
            Menus = True
            mnuSupport = True
            mnuWebsite = True
            mnuAbout = True
            NoPixelPerfect = False
        End Sub
    End Structure

    Public GameProperties As psGameProperties
#End Region

#Region "File Header"
    <Serializable()> _
    Private Structure psFileHeader
        Dim str1 As String

        Sub Init()
            str1 = psFileUpdater.HEADER_TEXT
        End Sub

        Overloads Function Equals(ByVal Header As psFileHeader) As Boolean
            Return (Me.str1 = Header.str1)
        End Function
    End Structure
#End Region

    Enum psLayerNames
        Back = 0
        Parallax = 1
        Background = 2
        Foreground = 3
        Front = 4
        Location = 5
    End Enum

    Event ClickControl(ByRef ctrl As psUI.psControl, ByVal Index As Integer)
    Event CounterChanged(ByVal CounterIndex As Integer)
    Event DisappearTile(ByVal index As Integer, ByVal layer As Integer)
    Event LoadedGameProperties()
    Event BeginLoadingGame()
    Event RequestReInitInEditor()
    Event BeginInit()
    Event EndInit()
    Event ChangedTileSize()
    Event ChangedCurrentMap()
    Event ChangedStatus(ByVal NewStatus As String)
    Event RequestStatus(ByVal Status As String())

    Public Initialized As Boolean

    Public cam As psCamera
    Public Math As psMath
    Public hwnd As Integer

    'Data
    Public maps() As psMap
    Private chars() As psChar 'unused
    Public tileset As psTileset
    Public actions As psActions
    Public windows As psUI.psWindows

    Public PresetActions As IGame

    Public p As Control

    Private Drawing_ As psDraw
    Private Audio_ As psAudio
    Private cur_map As Integer
    Private tile_W As Integer, tile_H As Integer, tile_ColorKey As Integer

    Friend Code As String 'source code for actions dll
    Public Filename As String

    Public WithEvents video As Microsoft.DirectX.AudioVideoPlayback.Video
    Public videotex As Microsoft.DirectX.Direct3D.Texture
    Public videoMissedFrames As Integer
    Public videoFile As String

    Public Delegate Function ReachedMax() As Boolean
    Public ReachedMaxLevels As ReachedMax
    Public ReachedMaxWindows As ReachedMax
    Public ReachedMaxTile As ReachedMax

    Private _InEditor As Boolean
    Private LayerVis() As Boolean
    Private Header As psFileHeader

    Public Root As String = Application.StartupPath & "\"
    Public TempRoot As String = IO.Path.GetTempPath()

    Public Sub New()
        SetAsCurrentGame()
    End Sub

    Property InEditor() As Boolean
        Get
            Return _InEditor
        End Get
        Set(ByVal Value As Boolean)
            _InEditor = Value
        End Set
    End Property

    Function CloneMaps() As psMap()
        Dim tmp() As psMap, i As Integer
        ReDim tmp(UBound(maps))
        For i = 1 To UBound(maps)
            tmp(i) = maps(i).Clone
        Next
        Return tmp
    End Function

    Friend Function Save() As Boolean
        Dim i As Integer
        Try
            'Save file header
            psFileHandler.Write(Header)

            psFileHandler.Write(filerepl)

            'Save all public variables
            psFileHandler.Write(GameProperties)
            psFileHandler.bWriter.Write(tile_W)
            psFileHandler.bWriter.Write(tile_H)
            psFileHandler.bWriter.Write(tile_ColorKey)
            psFileHandler.Write(maps)
            psFileHandler.Write(tileset)
            psFileHandler.Write(actions)
            windows.Save()

            'Save all private variables
            For i = 1 To numMaps
                maps(i).Save()
            Next

            'Save data found in newer versions only
            psFileHandler.bWriter.Write(tile_W)
            psFileHandler.bWriter.Write(tile_H)
            psFileHandler.bWriter.Write(tile_ColorKey)
            Game.tileset.SaveData()

            Return True
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show( _
                GetString("error_SaveFile") & _
                vbCrLf & vbCrLf & ex.Message, _
                "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Friend Function Load() As Boolean
        'Load file header
        Header.Init()
        Dim tmpHeader As psFileHeader
        Dim FileUpdater As New psFileUpdater
        psFileHandler.Read(tmpHeader)

        'Check for a valid file format
        Dim x As psFileUpdater.ValidFileEnum = FileUpdater.IsValidFile(tmpHeader.str1)
        If x = psFileUpdater.ValidFileEnum.Invalid Then
            Dim msg As String
            If tmpHeader.str1 Like "PSG#*.#*" Then
                msg = GetString("error_NewerFile")
            End If
            LoadError(msg)
            Return False
        ElseIf x = psFileUpdater.ValidFileEnum.RefuseUpdate Then
            Return False
        End If

        Dim i As Integer

        If psFileHandler.OldFileType Then
            i = psFileHandler.bReader.ReadInt32
            ReDim filerepl(i)
            For i = 1 To UBound(filerepl)
                psFileHandler.Read(filerepl(i))
            Next
        Else
            psFileHandler.Read(filerepl)
        End If

        RaiseEvent BeginLoadingGame()

        Dim OldLayer As Integer
        If InEditor Then OldLayer = psMap.CurLayer
        Try
            If InEditor Then
                Drawing.img_Clear()
                Drawing.fonts_Clear()
            End If

            'Load all public variables
            psFileHandler.Read(GameProperties)

            RaiseEvent LoadedGameProperties()

            If InEditor = False Then
                Init(hwnd, p, 5938195395831283597)
            End If
            LoadInternalFonts()

            'Load tileset and level data
            tile_W = psFileHandler.bReader.ReadInt32
            tile_H = psFileHandler.bReader.ReadInt32
            tile_ColorKey = psFileHandler.bReader.ReadInt32

            'Read levels
            If psFileHandler.OldFileType Then
                i = psFileHandler.bReader.ReadInt32
                ReDim maps(i)
                For i = 1 To UBound(maps)
                    psFileHandler.Read(maps(i))
                Next
            Else
                psFileHandler.Read(maps)
            End If

            'Read chars (deprecated)
            If psFileHandler.OldFileType Then
                i = psFileHandler.bReader.ReadInt32
                ReDim chars(i)
                For i = 1 To UBound(chars)
                    psFileHandler.Read(chars(i))
                Next
            End If

            'Read tileset
            psFileHandler.Read(tileset)

            'Load actions
            psFileHandler.Read(actions)
            actions.IconKeysInit()
            If Not DefaultActData.ab Is Nothing Then
                actions.Dat = DefaultActData.Clone
            End If
            actions.ValidateActions()

            'Load windows
            windows.MakeInactive()
            windows = New psUI.psWindows
            windows.Load()
            If FileNotFoundCancel Then Exit Function

            'Load all private variables and images/fonts
            For i = 1 To numMaps
                maps(i).Load()
                If FileNotFoundCancel Then Exit Function
            Next
            If InEditor Then
                psMap.CurLayer = OldLayer
            Else
                psMap.CurLayer = 2
            End If

            'Load tileset
            tileset.Load()

            'Update file
            FileUpdater.UpdateFile(tmpHeader.str1)

            Return True
        Catch ex As Exception
            'LoadError(ex.Message & vbCrLf & "Method: " & ex.TargetSite.Name & vbCrLf & "Call stack: " & ex.StackTrace)
            LoadError(ex.Message)
            If InEditor Then
                RaiseEvent RequestReInitInEditor()
            Else
                Init(hwnd, p, 5938195395831283597)
            End If
            Return False
        End Try
    End Function

    Private Sub LoadInternalFonts()
        Game.Drawing.fonts_Add("internal|SmFont", New System.Drawing.Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular))
    End Sub

    Private Sub LoadError(Optional ByVal ErrMsg As String = "")
        System.Windows.Forms.MessageBox.Show( _
            String.Format(GetString("error_InvalidFile") & _
            IIf(ErrMsg <> "", String.Format(GetString("error_InvalidFileErrorMessage"), ErrMsg), ""), AssemblyVersion), _
            "JumpCraft " & AssemblyVersion, MessageBoxButtons.OK, _
            MessageBoxIcon.Error)
        FileClose(1)
    End Sub

    Property LayerVisible(ByVal LayerName As psLayerNames) As Boolean
        Get
            If LayerVis Is Nothing Then Exit Property
            Return LayerVis(LayerName)
        End Get
        Set(ByVal Value As Boolean)
            If LayerVis Is Nothing Then Exit Property
            LayerVis(LayerName) = Value
        End Set
    End Property

    ReadOnly Property numMaps() As Integer
        Get
            Return UBound(maps)
        End Get
    End Property

    ReadOnly Property numWindows() As Integer
        Get
            Return UBound(windows.Windows)
        End Get
    End Property

    Property tileW() As Integer
        Get
            Return tile_W
        End Get
        Set(ByVal Value As Integer)
            tile_W = Value
            RaiseEvent ChangedTileSize()
        End Set
    End Property

    Property tileH() As Integer
        Get
            Return tile_H
        End Get
        Set(ByVal Value As Integer)
            tile_H = Value
            RaiseEvent ChangedTileSize()
        End Set
    End Property

    Property tileColorKey() As Integer
        Get
            Return tile_ColorKey
        End Get
        Set(ByVal Value As Integer)
            tile_ColorKey = Value
        End Set
    End Property

    Property CurMapIndex() As Integer
        Get
            Return cur_map
        End Get
        Set(ByVal Value As Integer)
            RaiseEvent ChangedCurrentMap()
            cur_map = Value
        End Set
    End Property

    Property CurMap() As psMap
        Get
            Return maps(cur_map)
        End Get
        Set(ByVal Value As psMap)
            RaiseEvent ChangedCurrentMap()
            maps(cur_map) = Value
        End Set
    End Property

    Property CurMapCell(ByVal x As Integer, ByVal y As Integer) As Integer
        Get
            Return maps(cur_map).Cells(x, y)
        End Get
        Set(ByVal Value As Integer)
            maps(CurMapIndex).Cells(x, y) = Value
        End Set
    End Property

    Property CurMapCell2(ByVal x As Integer, ByVal y As Integer) As psMapTile
        Get
            Return maps(cur_map).Cells2(x, y)
        End Get
        Set(ByVal Value As psMapTile)
            maps(CurMapIndex).Cells2(x, y) = Value
        End Set
    End Property

    ReadOnly Property CurMapWidth() As Integer
        Get
            Return maps(cur_map).MapWidth
        End Get
    End Property

    ReadOnly Property CurMapHeight() As Integer
        Get
            Return maps(cur_map).MapHeight
        End Get
    End Property

    Property CurWinIndex() As Integer
        Get
            Return windows.CurWinIndex
        End Get
        Set(ByVal Value As Integer)
            windows.CurWinIndex = Value
        End Set
    End Property

    ReadOnly Property CurWindow() As psUI.psWindows.psWindow
        Get
            Return windows.Windows(CurWinIndex)
        End Get
    End Property

    Property Drawing() As psDraw
        Get
            Return Drawing_
        End Get
        Set(ByVal Value As psDraw)
            Drawing_ = Value
        End Set
    End Property

    Property Audio() As psAudio
        Get
            Return Audio_
        End Get
        Set(ByVal Value As psAudio)
            Audio_ = Value
        End Set
    End Property

    Function Init(ByVal hwnd_ As Integer, ByRef pic As Control, ByVal Flags As Long) As Boolean
        
        If Flags <> 5938195395831283597 Then
            Dim s As Single = Timer
            Do
            Loop Until Timer - s >= 2
            Throw New Exception(GetString("error_InitFailed"))
            Return False
        End If

        RaiseEvent BeginInit()

        Header.Init()
        If Game.InEditor Then
            GameProperties.CreateDefaults()
        End If
        If Compiled = False Then ReDim filerepl(0)

        ReDim maps(0)
        ReDim chars(0)
        ReDim tileset.tiles(0)

        hwnd = hwnd_
        p = pic

        cam = New psCamera
        If Not (Drawing_ Is Nothing) Then
            Drawing_.img_Clear()
            Drawing_.fonts_Clear()
        End If
        Drawing_ = New psDraw
        If Not DataOnly Then
            If InEditor Then
                If Drawing_.Init(pic) = False Then Return False
            Else
                If Drawing_.Init(pic, Game.GameProperties.Windowed, Game.GameProperties.ResWidth, Game.GameProperties.ResHeight) = False Then Return False
            End If
        End If
        Audio_ = New psAudio
        If Not DataOnly Then
            Audio_.Init()
        End If
        Math = New psMath

        'Defaults        
        CurMapIndex = 1
        AddMap()
        tileW = 32
        tileH = 32

        'Init actions
        actions.Init()
        If Game.InEditor Then
            Try
                FileClose(1)
                FileOpen(1, Root & "actiondata.dat", OpenMode.Binary)
                FileGet(1, actions.Dat)
                FileClose(1)
                DefaultNumActions = actions.Dat.ab.GetUpperBound(0)
                DefaultActData = actions.Dat.Clone
            Catch ex As Exception
            End Try
            actions.SetDefaults()
        End If

        'Init windows
        psUI.psControl.ControlNames.Clear()
        Dim ww As Integer = 450, wh As Integer = 300 'window w/h
        windows = New psUI.psWindows
        windows.Width = ww
        windows.Height = wh
        windows.Init()

        If Game.InEditor Then
            'Automatically load a tileset
            If Options.gDefaultGame Then
                Dim fh As New psFileHandler
                fh.LoadTileset(Root & "deftileset.pst")
                fh = Nothing
            End If
        End If

        'Create default window layout
        If Game.InEditor Then
            windows.CreateFromPreset()
        End If

        psFileHandler.MadeChanges = False

        'Make all layers visible
        If LayerVis Is Nothing Then
            ReDim LayerVis(5)
            Dim i As Integer
            For i = 0 To 5
                LayerVisible(i) = True
            Next
        End If

        LoadInternalFonts()

        Initialized = True
        RaiseEvent EndInit()
        Return True
    End Function

    Sub AddMap(Optional ByVal Name As String = "(Default)", Optional ByVal Width As Integer = 64, Optional ByVal Height As Integer = 32)
        If maps Is Nothing Then
            ReDim maps(0)
            maps(0) = New psMap
            maps(0).Init()
        End If
        ReDim Preserve maps(UBound(maps) + 1)
        maps(UBound(maps)) = New psMap
        With maps(UBound(maps))
            .Init()
            If Name <> "" And Name <> "(Default)" Then
                .MapName = Name
            Else
                .MapName = String.Format(GetString("defaultLevelName"), UBound(maps))
            End If
            .ResizeMap(Width, Height)
        End With
        If cur_map = 0 Then cur_map = 1
    End Sub

    Function AddWindow() As psUI.psWindows.psWindow
        Return windows.NewWindow()
    End Function

    Sub AddWindow(ByVal window As psUI.psWindows.psWindow)
        ReDim Preserve windows.Windows(UBound(windows.Windows) + 1)
        windows.Windows(UBound(windows.Windows)) = window.Clone
    End Sub

    Sub RemoveWindow(ByVal Index As Integer)
        windows.RemoveWindow(Index)
    End Sub

    Sub AddMap(ByVal NewMap As psMap)
        If maps Is Nothing Then ReDim maps(0)
        ReDim Preserve maps(UBound(maps) + 1)
        maps(UBound(maps)) = NewMap
        If cur_map = 0 Then cur_map = 1
    End Sub

    Sub RemoveMap(ByVal MapIndex As Integer)
        Dim i As Integer
        For i = MapIndex To UBound(maps) - 1
            maps(i) = maps(i + 1)
        Next
        ReDim Preserve maps(UBound(maps) - 1)
    End Sub

    Sub Draw(Optional ByVal Grid As Boolean = False)
        Dim bRelative As Boolean
        bRelative = Drawing.RelativeToCam
        Drawing.RelativeToCam = True
        maps(CurMapIndex).Draw(Grid)
        Drawing.RelativeToCam = bRelative
    End Sub

    ReadOnly Property ScrollSpeed() As Single
        Get
            Return ScrollSpeed(psMap.CurLayer)
        End Get
    End Property

    ReadOnly Property ScrollSpeed(ByVal Layer As Integer) As Single
        Get
            Select Case Layer
                Case 0 'Parallax (50%)
                    Return 0.5
                Case 1 To 4 'Normal (100%)
                    Return 1
            End Select
        End Get
    End Property

    Public Sub DrawGrid(Optional ByVal OffsetX As Integer = 0, Optional ByVal OffsetY As Integer = 0)
        If tileW = 0 Or tileH = 0 Then Exit Sub
        If Options.mShowGrid = False Then Exit Sub

        Dim i As Integer
        Dim camModX As Integer, camModY As Integer
        Dim camW As Integer, camH As Integer

        camModX = (-cam.X * ScrollSpeed) Mod tileW - OffsetX
        camModY = (-cam.Y * ScrollSpeed) Mod tileH - OffsetY
        camW = cam.w + tileW * (OffsetX \ tileW + 1)
        camH = cam.h + tileH * (OffsetY \ tileW + 1)

        Drawing.RelativeToCam = False

        Dim X(), Y() As Integer, Colors() As Color
        ReDim X(0), Y(0), Colors(0)
        If Options.mGridLines Then
            For i = camModX To camModX + camW Step tileW
                ReDim Preserve X(UBound(X) + 4), Y(UBound(Y) + 4), Colors(UBound(Colors) + 4)
                X(UBound(X) - 3) = i
                Y(UBound(Y) - 3) = camModY
                Colors(UBound(Colors) - 3) = Color.FromArgb(64, 255, 255, 255)
                X(UBound(X) - 2) = i
                Y(UBound(Y) - 2) = camModY + camH
                Colors(UBound(Colors) - 2) = Colors(UBound(Colors) - 3)

                X(UBound(X) - 1) = i + 1
                Y(UBound(Y) - 1) = camModY
                Colors(UBound(Colors) - 1) = Color.FromArgb(64, 0, 0, 0)
                X(UBound(X)) = i + 1
                Y(UBound(Y)) = camModY + camH
                Colors(UBound(Colors)) = Colors(UBound(Colors) - 1)
            Next
            Drawing.DrawLineList(X, Y, Colors)

            ReDim X(0), Y(0), Colors(0)
            For i = camModY To camModY + camH Step tileH
                ReDim Preserve X(UBound(X) + 4), Y(UBound(Y) + 4), Colors(UBound(Colors) + 4)
                X(UBound(X) - 3) = camModX
                Y(UBound(Y) - 3) = i
                Colors(UBound(Colors) - 3) = Color.FromArgb(64, 255, 255, 255)
                X(UBound(X) - 2) = camModX + camW
                Y(UBound(Y) - 2) = i
                Colors(UBound(Colors) - 2) = Colors(UBound(Colors) - 3)

                X(UBound(X) - 1) = camModX
                Y(UBound(Y) - 1) = i + 1
                Colors(UBound(Colors) - 1) = Color.FromArgb(64, 0, 0, 0)
                X(UBound(X)) = camModX + camW
                Y(UBound(Y)) = i + 1
                Colors(UBound(Colors)) = Colors(UBound(Colors) - 1)
            Next
            Drawing.DrawLineList(X, Y, Colors)
        Else
            ReDim X((camW \ tileW + 1) * (camH \ tileH + 1) * 2), Y(UBound(X)), Colors(UBound(X))
            Dim cnt As Integer = 0
            For i = camModX To camModX + camW Step tileW
                For j As Integer = camModY To camModY + camH Step tileH
                    cnt += 1
                    X(cnt) = i
                    Y(cnt) = j
                    Colors(cnt) = Color.FromArgb(192, 255, 255, 255)
                    cnt += 1
                    X(cnt) = i + 1
                    Y(cnt) = j + 1
                    Colors(cnt) = Color.FromArgb(192, 0, 0, 0)
                Next
            Next
            Drawing.DrawPointList(X, Y, Colors)
        End If

        Drawing.RelativeToCam = True
    End Sub

    Public ReadOnly Property OnLocationLayer() As Boolean
        Get
            Return (psMap.CurLayer = 4)
        End Get
    End Property

    Sub SetAsCurrentGame()
        Game = Me
    End Sub

    Property Status() As String
        Get
            Dim statusArr() As String = {""}
            RaiseEvent RequestStatus(statusArr)
            Return statusArr(0)
        End Get
        Set(ByVal Value As String)
            RaiseEvent ChangedStatus(Value)
        End Set
    End Property

    Sub set_CurrentTimer(ByVal Name As String)
        curTimer._Name = Name
    End Sub

    Friend Sub ClickedControl(ByRef ctrl As psUI.psControl, ByVal Index As Integer)
        RaiseEvent ClickControl(ctrl, Index)
    End Sub

    Friend Sub _CounterChanged(ByVal CounterIndex As Integer)
        RaiseEvent CounterChanged(CounterIndex)
    End Sub

    Friend Sub _DisappearTile(ByVal i As Integer, ByVal n As Integer)
        RaiseEvent DisappearTile(i, n)
    End Sub

    Private Sub video_TextureReadyToRender(ByVal sender As Object, ByVal e As Microsoft.DirectX.AudioVideoPlayback.TextureRenderEventArgs) Handles video.TextureReadyToRender
        If Not (Game.videotex Is Nothing) Then Game.videotex.Dispose()
        Game.videotex = Nothing
        Game.videotex = New Microsoft.DirectX.Direct3D.Texture(Game.Drawing.device, 1024, 512, 0, Microsoft.DirectX.Direct3D.Usage.RenderTarget, Game.Drawing.device.DisplayMode.Format, Microsoft.DirectX.Direct3D.Pool.Default)
        Try
            Game.Drawing.device.StretchRectangle(e.Texture.GetSurfaceLevel(0), New Rectangle(0, 0, 640, 480), videotex.GetSurfaceLevel(0), New Rectangle(0, 0, 640, 480), Microsoft.DirectX.Direct3D.TextureFilter.None)
        Catch
        End Try
    End Sub
End Class
#End Region

#Region "UI"

Namespace psUI

#Region "Background"
    <Serializable()> _
    Public Structure psBackground

        Dim Tag As String

        Enum BackgroundType
            Solid
            Gradient
            Picture
            Gradient4
        End Enum

        Function Clone() As psBackground
            Dim tmp As New psBackground
            With tmp
                .Type = Type
                .Color1 = Color1
                .Color2 = Color2
                .TransparentColor = TransparentColor
                .Horizontal = Horizontal
                .imgFilename = imgFilename
                .ID = ID 'If DoNotLoadImages Then 
            End With
            Return tmp
        End Function

        <NonSerialized()> Private Color1_, Color2_, Color3_, Color4_ As Integer
        Property Color1() As Color
            Get
                Return Color.FromArgb(Color1_)
            End Get
            Set(ByVal Value As Color)
                Color1_ = Value.ToArgb
            End Set
        End Property
        Property Color2() As Color
            Get
                Return Color.FromArgb(Color2_)
            End Get
            Set(ByVal Value As Color)
                Color2_ = Value.ToArgb
            End Set
        End Property
        Property Color4() As Color
            Get
                Return Color.FromArgb(Color4_)
            End Get
            Set(ByVal Value As Color)
                Color4_ = Value.ToArgb
            End Set
        End Property
        Property Color3() As Color
            Get
                Return Color.FromArgb(Color3_)
            End Get
            Set(ByVal Value As Color)
                Color3_ = Value.ToArgb
            End Set
        End Property
        ReadOnly Property ColorTL() As Color
            Get
                Return Color1
            End Get
        End Property
        ReadOnly Property ColorTR() As Color
            Get
                If Type = BackgroundType.Solid Or (Type = BackgroundType.Gradient And Not Horizontal) Then
                    Return Color1
                Else
                    Return Color2
                End If
            End Get
        End Property
        ReadOnly Property ColorBR() As Color
            Get
                If Type = BackgroundType.Solid Then
                    Return Color1
                ElseIf Type = BackgroundType.Gradient Then
                    Return Color2
                ElseIf Type = BackgroundType.Gradient4 Then
                    Return Color3
                End If
            End Get
        End Property
        ReadOnly Property ColorBL() As Color
            Get
                If Type = BackgroundType.Solid Or (Type = BackgroundType.Gradient And Horizontal) Then
                    Return Color1
                ElseIf (Type = BackgroundType.Gradient And Not Horizontal) Then
                    Return Color2
                ElseIf Type = BackgroundType.Gradient4 Then
                    Return Color4
                End If
            End Get
        End Property

        <NonSerialized()> Private TransparentColor_ As Integer
        Property TransparentColor() As Color
            Get
                Return Color.FromArgb(TransparentColor_)
            End Get
            Set(ByVal Value As Color)
                TransparentColor_ = Value.ToArgb
                If Type = BackgroundType.Picture And imgFilename <> "" Then
                    Game.Drawing.img_ColorKey(ID) = Value
                End If
            End Set
        End Property

        <NonSerialized()> Private _Horizontal As Boolean
        <NonSerialized()> Private strImage As String
        <NonSerialized()> Private bkType As Integer
        <NonSerialized()> Friend ID As String
        <NonSerialized()> Private tImg As Bitmap

        Property Horizontal() As Boolean
            Get
                Return _Horizontal
            End Get
            Set(ByVal Value As Boolean)
                _Horizontal = Value
            End Set
        End Property

        Friend Sub Save()
            psFileHandler.bWriter.Write(Color1_)
            psFileHandler.bWriter.Write(Color2_)
            psFileHandler.bWriter.Write(TransparentColor_)
            psFileHandler.bWriter.Write(Horizontal)
            psFileHandler.FilePutString(strImage)
            psFileHandler.bWriter.Write(bkType)
        End Sub

        Friend Sub Load()
            Color1_ = psFileHandler.bReader.ReadInt32
            Color2_ = psFileHandler.bReader.ReadInt32
            TransparentColor_ = psFileHandler.bReader.ReadInt32
            Horizontal = psFileHandler.ReadBoolean
            psFileHandler.FileGetString(strImage)
            bkType = psFileHandler.bReader.ReadInt32
            If Type = BackgroundType.Picture Then
                imgFilename = imgFilename
            End If
        End Sub

        Property imgFilename() As String
            Get
                Return strImage
            End Get
            Set(ByVal Value As String)
                strImage = Value
                'UnloadImage()
                ID = Value '"back|" & Microsoft.VisualBasic.Timer
                Try
                    If Not String.IsNullOrEmpty(Value) Then
                        Game.Drawing.img_Add(Value, ID, TransparentColor)
                        If FileNotFoundCancel Then Exit Property
                        tImg = Game.Drawing.Tex(ID).bmp
                        strImage = Value
                    End If
                Catch
                    ID = ""
                End Try
            End Set
        End Property

        Property Type() As BackgroundType
            Get
                Return bkType
            End Get
            Set(ByVal Value As BackgroundType)
                bkType = Value
            End Set
        End Property

        Sub UnloadImage()
            If ID <> "" Then Game.Drawing.img_Remove(ID)
            tImg = Nothing
            ID = ""
        End Sub

        Sub MakePreview(ByVal p As PictureBox, Optional ByVal pTrans As PictureBox = Nothing)

            'AutoRedraw
            Dim oImage As Image, xg1 As Graphics
            oImage = New Bitmap(p.Width, p.Height)
            xg1 = Graphics.FromImage(oImage)
            p.Image = oImage

            'Draw the preview
            Draw(xg1, 0, 0, p.Width, p.Height, pTrans)

        End Sub

        'Draw using DirectX
        Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
            With Game.Drawing
                Select Case Type
                    Case BackgroundType.Solid
                        .DrawFilledBox(x, y, w, h, Color1)
                    Case BackgroundType.Gradient
                        If Horizontal Then
                            .DrawFilledBox(x, y, w, h, Color1, Color2, Color2, Color1)
                        Else
                            .DrawFilledBox(x, y, w, h, Color1, Color1, Color2, Color2)
                        End If
                    Case BackgroundType.Gradient4
                        .DrawFilledBox(x, y, w, h, Color1, Color2, Color3, Color4)
                    Case BackgroundType.Picture
                        If ID <> "" Then
                            If TransparentColor_ = 0 Then
                                .DrawImage(ID, x, y, w, h)
                            Else
                                .DrawSprite(ID, x, y, w, h)
                            End If
                        End If
                End Select
            End With
        End Sub

        'Draw using GDI+
        Sub Draw(ByVal Graphics As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, Optional ByVal pTrans As PictureBox = Nothing, Optional ByVal inPropGrid As Boolean = False)
            With Graphics
                If Not (pTrans Is Nothing) AndAlso Not (pTrans.Image Is Nothing) Then
                    If inPropGrid Then
                        .DrawImage(pTrans.Image, x, y, w, h)
                    Else
                        Dim i As Integer, j As Integer
                        For i = 0 To w \ 16
                            For j = 0 To h \ 16
                                .DrawImage(pTrans.Image, New Point(i * 16, j * 16))
                            Next
                        Next
                    End If
                End If
                Select Case Type
                    Case BackgroundType.Solid
                        .FillRectangle(New Pen(Color1).Brush, New Rectangle(x, y, w, h))
                    Case BackgroundType.Gradient

                        'Create a gradient brush
                        Dim Direction As System.Drawing.Drawing2D.LinearGradientMode
                        If Horizontal Then
                            Direction = Drawing.Drawing2D.LinearGradientMode.Horizontal
                        Else
                            Direction = Drawing.Drawing2D.LinearGradientMode.Vertical
                        End If
                        Dim b As New Drawing2D.LinearGradientBrush( _
                                 New Rectangle(x, y, w, h), Color1, Color2, Direction)

                        'Draw the gradient
                        .FillRectangle(b, x, y, w, h)

                    Case BackgroundType.Gradient4

                        'Create brush
                        Dim p As New Drawing2D.GraphicsPath
                        p.AddRectangle(New Rectangle(x, y, w, h))
                        'Dim b As New Drawing2D.PathGradientBrush(New Point() {New Point(x, y), New Point(x + w, y + h)})
                        Dim b As New Drawing2D.PathGradientBrush(p)
                        b.CenterColor = Color.FromArgb( _
                            (CInt(Color1.A) + Color2.A + Color3.A + Color4.A) \ 4, _
                            (CInt(Color1.R) + Color2.R + Color3.R + Color4.R) \ 4, _
                            (CInt(Color1.G) + Color2.G + Color3.G + Color4.G) \ 4, _
                            (CInt(Color1.B) + Color2.B + Color3.B + Color4.B) \ 4)
                        b.SurroundColors = New Color() { _
                            Color1, Color2, Color3, Color4}

                        'Draw gradient
                        .FillRectangle(b, x, y, w, h)

                    Case BackgroundType.Picture
                        If tImg Is Nothing Then Exit Sub
                        Graphics.DrawImage(tImg, x, y, w, h)
                End Select
            End With
        End Sub

        Shared Function NewHGradientBackground(ByVal bkColor1 As Color, ByVal bkColor2 As Color) As psBackground
            Dim tmpBack As New psBackground
            With tmpBack
                .Type = BackgroundType.Gradient
                .Horizontal = True
                .Color1 = bkColor1
                .Color2 = bkColor2
            End With
            Return tmpBack
        End Function

        Shared Function NewVGradientBackground(ByVal bkColor1 As Color, ByVal bkColor2 As Color) As psBackground
            Dim tmpBack As New psBackground
            With tmpBack
                .Type = BackgroundType.Gradient
                .Horizontal = False
                .Color1 = bkColor1
                .Color2 = bkColor2
            End With
            Return tmpBack
        End Function

        Shared Function NewSolidBackground(ByVal bkColor As Color) As psBackground
            Dim tmpBack As New psBackground
            With tmpBack
                .Type = BackgroundType.Solid
                .Color1 = bkColor
                .Color2 = bkColor
            End With
            Return tmpBack
        End Function

        Overrides Function ToString() As String
            Return Type.ToString
        End Function
    End Structure
#End Region

End Namespace

#End Region

'---------

#Region "old stuff"

#Region "Objects"
<Serializable()> _
Public Structure psObject
    Dim x As Single, y As Single
    Dim dx As Single, dy As Single, speed As Single, dist As Single
    Dim solid As Boolean, type As Integer
End Structure

<Serializable()> _
Public Structure psChar
    Dim obj As psObject
    Dim state As Integer
    Dim health As Integer, lives As Integer
End Structure
#End Region

#End Region