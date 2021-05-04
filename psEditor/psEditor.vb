Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Public Class psEditor
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents vs As System.Windows.Forms.VScrollBar
    Public WithEvents hs As System.Windows.Forms.HScrollBar
    Public WithEvents p As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.p = New System.Windows.Forms.PictureBox
        Me.vs = New System.Windows.Forms.VScrollBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.hs = New System.Windows.Forms.HScrollBar
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p
        '
        Me.p.BackColor = System.Drawing.Color.Black
        Me.p.Dock = System.Windows.Forms.DockStyle.Fill
        Me.p.Location = New System.Drawing.Point(0, 0)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(328, 304)
        Me.p.TabIndex = 0
        Me.p.TabStop = False
        '
        'vs
        '
        Me.vs.Dock = System.Windows.Forms.DockStyle.Right
        Me.vs.Enabled = False
        Me.vs.LargeChange = 32
        Me.vs.Location = New System.Drawing.Point(328, 0)
        Me.vs.Name = "vs"
        Me.vs.Size = New System.Drawing.Size(16, 304)
        Me.vs.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.hs)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 304)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(344, 16)
        Me.Panel1.TabIndex = 3
        '
        'hs
        '
        Me.hs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hs.Enabled = False
        Me.hs.Location = New System.Drawing.Point(0, 0)
        Me.hs.Name = "hs"
        Me.hs.Size = New System.Drawing.Size(328, 16)
        Me.hs.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(328, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'psEditor
        '
        Me.Controls.Add(Me.p)
        Me.Controls.Add(Me.vs)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "psEditor"
        Me.Size = New System.Drawing.Size(344, 320)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Dim ar As New psAutoRedraw()

    'Events
    Event RightClick()
    Event PathEditorRightClick()
    Event EditFunctionsChanged()
    Shadows Event DoubleClick()

    'Mouse vars
    Friend MouseOut As Boolean
    Friend mx As Integer, my As Integer
    Friend sx As Integer, sy As Integer
    Friend MDown As Boolean

    'Sel vars
    Public Shared sel As Rectangle
    Public Shared selecting As Boolean

    Public Grid As Boolean

    Public Shared CurTile As Integer

    Private bOverTile As Boolean

    Private oldcam As psGame.psCamera
    Private panning As Boolean

    Dim Locked As Boolean

    Public PathEdit As New psPathEditor

    Public DoNotRenderInRenderLoop As Boolean

    Structure seltile
        Dim x As Integer, y As Integer
        Dim tile As psMapTile
        ReadOnly Property w() As Integer
            Get
                Return Game.tileset.tileSecW(tile.tile)
            End Get
        End Property
        ReadOnly Property h() As Integer
            Get
                Return Game.tileset.tileSecH(tile.tile)
            End Get
        End Property
    End Structure
    Public seltiles() As seltile
    Private origseltiles() As seltile
    Private clip_board() As seltile

    Structure selloc
        Dim loc As psLocation
    End Structure
    Public sellocs() As selloc
    Private origsellocs() As selloc
    Private clip_board_locs() As selloc
    Private locmove As psMoveSize

    Dim start As Single, frames As Integer, fps As Single
    Dim began As Boolean

    Dim _active As Boolean
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal Value As Boolean)
            _active = Value
            Timer1.Enabled = _active
        End Set
    End Property

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Editor.psedit = Me 'Register control
        ReDim seltiles(0)
        ReDim origseltiles(0)
        ReDim sellocs(0)
        ReDim origsellocs(0)
        Grid = True
        MouseOut = True
        locmove = New psMoveSize()
    End Sub

    Sub Begin()
        Timer1.Enabled = True
        began = True
    End Sub

    ReadOnly Property hwnd() As Integer
        Get
            hwnd = p.Handle.ToInt32
        End Get
    End Property

    ReadOnly Property Graphics() As System.Drawing.Graphics
        Get
            Graphics = p.CreateGraphics
        End Get
    End Property

    Sub LockUpdate()
        Locked = True
    End Sub

    Sub UnlockUpdate()
        Locked = False
    End Sub

    Dim framestart As Double
    Overloads Sub Refresh()
        'Do not draw if we have no game object yet
        If Game Is Nothing Then Exit Sub

        'Do not draw if we are in the window editor
        If _active = False Then Exit Sub

        'Static variables
        Static tmpCanCopy As Boolean, tmpCanPaste As Boolean, tmpCanSelectAll As Boolean
        Static DidThis As Boolean

        'Do not draw if the control is locked from being drawn
        If Locked Then Exit Sub

        'Do not draw if it will cause errors
        If Game.tileW = 0 Or Game.tileH = 0 Then Exit Sub

        With Game.Drawing
            Try
                If .InvalidDevice OrElse Game.Drawing.device.CheckCooperativeLevel = False Then
                    Try
                        Game.Drawing.Re_Init(p)
                    Catch
                    End Try
                End If
            Catch
                Game.Drawing.Re_Init(p)
            End Try

            'Update the FPS
            Dim elapsed As Double = Microsoft.VisualBasic.Timer - framestart
            framestart = Microsoft.VisualBasic.Timer
            If (elapsed < 1.0 / 60.0) Then
                Threading.Thread.Sleep(CInt(1000.0 / 60.0 - 1000 * elapsed))
            End If
            If start = 0 Then start = Microsoft.VisualBasic.Timer
            frames = frames + 1
            If Microsoft.VisualBasic.Timer - start >= 1 Then
                start = Microsoft.VisualBasic.Timer
                fps = frames
                frames = 0
            End If

            'Begin drawing
            .Clear()
            .RelativeToCam = True

            'Draw the background, the grid, and the current map
            If PathEdit.Editing Then
                Game.Draw(False)
            Else
                Game.Draw(Grid)
            End If

            'Draw the location layer
            Game.maps(Game.CurMapIndex).loc.Draw()

            'Draw "out of bounds" area
            DrawOutOfBounds()

            'Draw selection
            DrawSelection()

            'Draw the path editor
            If PathEdit.Editing Then
                PathEdit.DrawBezier()
            End If

            'Draw the FPS
            If Options.mShowFramerate Then
                Game.Drawing.RelativeToCam = False
                Game.Drawing.DrawText(fps & " " & GetString("fpsUnit"), 2, 2, Color.White)
            End If

            'Done
            .RenderToScreen()

        End With

        'Events
        If DidThis = False Then
            RaiseEvent EditFunctionsChanged()
            DidThis = True
            tmpCanCopy = CanCopy()
            tmpCanPaste = CanPaste()
            tmpCanSelectAll = CanSelectAll()
        ElseIf CanCopy() <> tmpCanCopy Or _
        CanPaste() <> tmpCanPaste Or _
        CanSelectAll() <> tmpCanSelectAll Then
            tmpCanCopy = CanCopy()
            tmpCanPaste = CanPaste()
            tmpCanSelectAll = CanSelectAll()
            RaiseEvent EditFunctionsChanged()
        End If
    End Sub

    Sub SetTileset()

    End Sub

    Friend Sub DoResize()
        Dim mw As Integer, mh As Integer 'Map size in pixels
        mw = Game.CurMapWidth * Game.tileW
        mh = Game.CurMapHeight * Game.tileH
        If p.Width < mw Then
            hs.LargeChange = Game.tileW * 4
            hs.SmallChange = Game.tileW
            hs.Maximum = mw - p.Width + hs.LargeChange
            hs.Enabled = True
        Else
            hs.Enabled = False
            hs.Value = 0
        End If
        hsscroll()
        If p.Height < mh Then
            vs.LargeChange = Game.tileH * 4
            vs.SmallChange = Game.tileH
            vs.Maximum = mh - p.Height + vs.LargeChange
            vs.Enabled = True
        Else
            vs.Enabled = False
            vs.Value = 0
        End If
        vsscroll()
        '        Refresh()
    End Sub

    Private Sub psEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'p.Size = New Size(Width, Height)
        If Game Is Nothing Then Exit Sub
        If Not (Game.Drawing Is Nothing) Then
            DoResize()
            '            Refresh()
        End If
    End Sub

    ReadOnly Property HoverTile(Optional ByVal Location As Boolean = False) As Point
        Get
            If MouseOut Then
                Return New Point(0, 0)
            Else
                Dim pt As Point, i As Integer
                If Game.OnLocationLayer And Location Then

                    pt = MouseToPixel()

                    For i = 1 To Game.maps(Game.CurMapIndex).loc.NumLocations
                        With Game.maps(Game.CurMapIndex).loc.Locations(i).Rectangle
                            If Game.Math.Collide_PtBox(pt.X, pt.Y, .X, .Y, .Width, .Height) Then
                                Return New Point(i, 0)
                            End If
                        End With
                    Next

                Else

                    If Game.tileW = 0 Or Game.tileH = 0 Then Exit Property

                    pt = MouseToTile()

                    'Hover tile must be valid
                    If pt.X < 1 Or _
                        pt.Y < 1 Or _
                        pt.X > Game.CurMapWidth Or _
                        pt.Y > Game.CurMapHeight Then
                        Return New Point(0, 0)
                    Else
                        Return pt
                    End If
                End If

            End If
        End Get
    End Property

    Private Function MouseToTile() As Point
        'Convert the mouse coordinates to tile coordinates
        Return New Point( _
            Int(((mx - Game.cam.X) + _
                (Game.cam.X * Game.ScrollSpeed)) _
                / Game.tileW) + 1, _
            Int(((my - Game.cam.Y) + _
                (Game.cam.Y * Game.ScrollSpeed)) _
                / Game.tileH) + 1)
    End Function

    Private Function MouseToPixel() As Point
        'Convert the mouse coordinates to tile coordinates
        Return New Point( _
            ((mx - Game.cam.X) + _
                (Game.cam.X * Game.ScrollSpeed)), _
            ((my - Game.cam.Y) + _
                (Game.cam.Y * Game.ScrollSpeed)))
    End Function

    Sub DrawSelection()
        If PathEdit.Editing Then Exit Sub

        Dim i As Integer, j As Integer, R As Rectangle
        With Game.Drawing

            .AffectedByScrollSpeed = True
            .RelativeToCam = True

            Select Case Editor.pstools.Value
                Case 0 'Draw
                    If Game.OnLocationLayer = False Then
                        If HoverTile.X > 0 AndAlso CurTile <= Game.tileset.NumTiles Then
                            For i = 0 To Editor.pstileselect.DisplaySelWidth - 1
                                For j = 0 To Editor.pstileselect.DisplaySelHeight - 1
                                    .DrawFilledBox((HoverTile.X + i - 1) * Game.tileW, (HoverTile.Y + j - 1) * Game.tileH, Game.tileset.tileSecW(CurTile), Game.tileset.tileSecH(CurTile), Color.FromArgb(128, 0, 255, 0))
                                    .DrawBox((HoverTile.X + i - 1) * Game.tileW, (HoverTile.Y + j - 1) * Game.tileH, Game.tileset.tileSecW(CurTile), Game.tileset.tileSecH(CurTile), Color.White)
                                    .DrawBox((HoverTile.X + i - 1) * Game.tileW + 1, (HoverTile.Y + j - 1) * Game.tileH + 1, Game.tileset.tileSecW(CurTile) - 2, Game.tileset.tileSecH(CurTile) - 2, Color.Black)
                                Next
                            Next
                        End If
                    End If
                Case 1 'Erase
                    If Game.OnLocationLayer = False Then
                        If HoverTile.X > 0 Then
                            If Game.CurMapCell(HoverTile.X, HoverTile.Y) > 0 Then
                                Dim tmpSize As Size = New Size _
                                    (Game.tileset.tileSecW(Game.CurMapCell(HoverTile.X, HoverTile.Y)), _
                                     Game.tileset.tileSecH(Game.CurMapCell(HoverTile.X, HoverTile.Y)))
                                .DrawFilledBox((HoverTile.X - 1) * Game.tileW, (HoverTile.Y - 1) * Game.tileH, tmpSize.Width, tmpSize.Height, Color.FromArgb(128, 0, 0, 0))
                                .DrawBox((HoverTile.X - 1) * Game.tileW, (HoverTile.Y - 1) * Game.tileH, tmpSize.Width, tmpSize.Height, Color.Red)
                                .DrawBox((HoverTile.X - 1) * Game.tileW + 1, (HoverTile.Y - 1) * Game.tileH + 1, tmpSize.Width - 2, tmpSize.Height - 2, Color.DarkRed)
                            End If
                        End If
                    Else
                        Dim tmpLoc As psLocation _
                            = Game.maps(Game.CurMapIndex).loc.Locations(HoverTile(True).X)
                        If HoverTile(True).X > 0 Then
                            .DrawFilledBox(tmpLoc.Rectangle.X, tmpLoc.Rectangle.Y, tmpLoc.Rectangle.Width + 1, tmpLoc.Rectangle.Height + 1, Color.FromArgb(128, 0, 0, 0))
                            .DrawBox((tmpLoc.Rectangle.X), (tmpLoc.Rectangle.Y), tmpLoc.Rectangle.Width, tmpLoc.Rectangle.Height, Color.Red)
                            .DrawBox((tmpLoc.Rectangle.X + 1), (tmpLoc.Rectangle.Y + 1), tmpLoc.Rectangle.Width - 2, tmpLoc.Rectangle.Height - 2, Color.DarkRed)
                        End If
                    End If
                Case 2 'Select
                    If selecting Then
                        .DrawFilledBox(sel.X, sel.Y, sel.Width, sel.Height, Color.FromArgb(128, 64, 64, 255))
                        .DrawBox(sel.X, sel.Y, sel.Width, sel.Height, Color.FromArgb(192, 128, 128, 255))
                        .DrawBox(sel.X - 1, sel.Y - 1, sel.Width + 2, sel.Height + 2, Color.FromArgb(192, 128, 128, 255))
                    End If
                    If Game.OnLocationLayer = False Then
                        If seltiles Is Nothing Then Exit Sub
                        For i = 1 To UBound(seltiles)
                            R = New Rectangle( _
                                (seltiles(i).x - 1) * Game.tileW, _
                                (seltiles(i).y - 1) * Game.tileH, _
                                Game.tileset.tileSecW(seltiles(i).tile.tile), _
                                Game.tileset.tileSecH(seltiles(i).tile.tile))

                            '.DrawSprite(game.tileset.tiles(seltiles(i).tile).name, R.X, R.Y, R.Width, R.Height)
                            Game.CurMap.DrawTile(seltiles(i).x, seltiles(i).y, psMap.CurLayer, seltiles(i).tile, True)
                            .DrawFilledBox(R.X, R.Y, R.Width, R.Height, Color.FromArgb(128, 64, 64, 255))
                            .DrawBox(R.X, R.Y, R.Width, R.Height, Color.FromArgb(192, 128, 128, 255))
                            .DrawBox(R.X - 1, R.Y - 1, R.Width + 2, R.Height + 2, Color.FromArgb(192, 128, 128, 255))
                        Next
                    Else
                        If sellocs Is Nothing Then Exit Sub
                        For i = 1 To UBound(sellocs)
                            Game.maps(Game.CurMapIndex).loc.DrawLocation( _
                                sellocs(i).loc, _
                                Color.FromArgb(128, 255, 128, 0), _
                                Color.FromArgb(128, 255, 255, 0), _
                                Color.FromArgb(192, 255, 128, 0))
                        Next

                        'Draw handles
                        If UBound(sellocs) = 1 Then
                            With sellocs(1).loc
                                locmove.Sync(.X, .Y, .Width, .Height)
                            End With
                            locmove.Draw()
                        End If
                    End If
            End Select

            .AffectedByScrollSpeed = False

        End With
    End Sub

    Sub DrawOutOfBounds()
        With Game.Drawing
            'Dim Color1 As Color = UIPlus.ColorOp.Blend(SystemColors.Control, SystemColors.ControlLightLight, 0.4) 
            'Dim Color2 As Color = UIPlus.ColorOp.Blend(SystemColors.ControlDark, SystemColors.ControlLight, 0.87) 
            Dim Color1 As Color = Color.FromArgb(255, 0, 0, 64)
            Dim Color2 As Color = Color.FromArgb(255, 64, 0, 0)
            .DrawFilledBox(0, Game.tileH * Game.CurMapHeight, Game.tileW * Game.CurMapWidth, 10000, Color2, Color1, Color1, Color2)
            .DrawFilledBox(Game.tileW * Game.CurMapWidth, 0, 10000, Game.tileH * Game.CurMapHeight, Color2, Color2, Color1, Color1)
            .DrawFilledBox(Game.tileW * Game.CurMapWidth, Game.tileH * Game.CurMapHeight, 10000, 10000, Color1)
        End With
    End Sub

    Private Sub p_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p.MouseLeave
        If PathEdit.Editing Then Exit Sub
        If Locked Then Exit Sub

        MouseOut = True
        '        Refresh()
        ClearStatusBar()
    End Sub

    Sub ClearStatusBar()
        If Not (Editor.psstatus Is Nothing) Then
            Editor.psstatus.PanelText(1) = GetString("main_XLabel")
            Editor.psstatus.PanelText(2) = GetString("main_YLabel")
            If Game.OnLocationLayer Then
                Editor.psstatus.PanelText(3) = GetString("main_LocationLabel")
            Else
                Editor.psstatus.PanelText(3) = GetString("main_TileLabel")
            End If
        End If
    End Sub

    Private Sub p_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p.MouseEnter
        If PathEdit.Editing Then Exit Sub
        If Locked Then Exit Sub
        MouseOut = False
    End Sub

    Private Sub p_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseMove
        If Game Is Nothing Then Exit Sub
        If Game.Initialized = False Then Exit Sub
        If PathEdit.Editing Then Exit Sub
        If Locked Then Exit Sub

        If panning = False Then
            mx = e.X + Game.cam.X
            my = e.Y + Game.cam.Y
        Else
            mx = e.X
            my = e.Y
        End If

        'Update status bar
        If Not (Editor.psstatus Is Nothing) Then
            Dim tilX As Integer, tilY As Integer
            tilX = Int(mx / (Game.tileW / Game.ScrollSpeed)) + 1
            tilY = Int(my / (Game.tileH / Game.ScrollSpeed)) + 1
            If tilX > 0 And tilY > 0 And tilX <= Game.CurMapWidth And tilY <= Game.CurMapHeight Then
                Editor.psstatus.PanelText(1) = GetString("main_XLabel") & " " & tilX
                Editor.psstatus.PanelText(2) = GetString("main_YLabel") & " " & tilY
                If Game.OnLocationLayer Then
                    Editor.psstatus.PanelText(3) = GetString("main_LocationLabel") & " " & IIf(HoverTile(True).X = 0, GetString("noValueCapital"), Game.maps(Game.CurMapIndex).loc.Locations(HoverTile(True).X).Name)
                Else
                    If Game.CurMapCell(tilX, tilY) = 0 Then
                        Editor.psstatus.PanelText(3) = GetString("main_TileLabel") & " " & GetString("noValueCapital")
                    Else
                        Editor.psstatus.PanelText(3) = GetString("main_TileLabel") & " " & Game.tileset.tileName(Game.CurMapCell(tilX, tilY))
                    End If
                End If
            Else
                Editor.psstatus.PanelText(1) = GetString("main_XLabel")
                Editor.psstatus.PanelText(2) = GetString("main_YLabel")
                If Game.OnLocationLayer Then
                    Editor.psstatus.PanelText(3) = GetString("main_LocationLabel")
                Else
                    Editor.psstatus.PanelText(3) = GetString("main_TileLabel")
                End If
            End If
        End If

        'MouseMove code
        Dim i As Integer
        If e.Button = 0 Then
            bOverTile = False
            Select Case Editor.pstools.Value
                Case 2 'Select
                    If Game.OnLocationLayer Then
                        For i = 1 To UBound(sellocs)
                            With sellocs(i)
                                If Game.Math.Collide_PtBox( _
                                    mxScrollSpeed, myScrollSpeed, .loc.Rectangle.X, .loc.Rectangle.Y, .loc.Rectangle.Width, .loc.Rectangle.Height) Then
                                    bOverTile = True
                                End If
                            End With
                        Next
                    Else
                        For i = 1 To UBound(seltiles)
                            With seltiles(i)
                                If Game.Math.Collide_PtBox( _
                                    mxScrollSpeed, myScrollSpeed, (.x - 1) * Game.tileW, (.y - 1) * Game.tileH, Game.tileset.tileSecW(.tile.tile), Game.tileset.tileSecH(.tile.tile)) Then
                                    bOverTile = True
                                End If
                            End With
                        Next
                    End If
                    If bOverTile Then
                        p.Cursor = Cursors.SizeAll
                    Else
                        If locmove.Enabled Then
                            p.Cursor = locmove.CurCursor
                        Else
                            p.Cursor = Cursors.Default
                        End If
                    End If
            End Select
        End If

        'MouseDrag
        If MDown Then
            Select Case Editor.pstools.Value
                Case 0 'Draw
                    If Game.OnLocationLayer Then
                        Dim mx2 As Integer = mx, my2 As Integer = my
                        SnapToTile(mx2, my2)
                        With Game.maps(Game.CurMapIndex).loc.Locations(Game.maps(Game.CurMapIndex).loc.NumLocations)
                            MakeValidRectangle(.Rectangle, sx, sy, mx2, my2)
                        End With
                    Else
                        For i = HoverTile.X To Math.Min(HoverTile.X + Editor.pstileselect.DisplaySelWidth - 1, Game.CurMapWidth)
                            For j As Integer = HoverTile.Y To Math.Min(HoverTile.Y + Editor.pstileselect.DisplaySelHeight - 1, Game.CurMapHeight)
                                Dim tmpTile As New psMapTile
                                With tmpTile
                                    .tile = CurTile
                                    If Game.tileset.tiles(.tile).Anim(0).Interval = 0 Then .Stopped = True
                                    If .Stopped Then
                                        If Editor.pstileselect.Random Then
                                            .Frame = Editor.pstileselect.GetRandomFrame
                                        Else
                                            .Frame = Editor.pstileselect.SelSubIndex + (i - HoverTile.X) + (j - HoverTile.Y) * (Game.tileset.tiles(.tile).width \ Game.tileset.tiles(.tile).sectionw)
                                        End If
                                    End If
                                End With
                                Game.CurMapCell2(i, j) = tmpTile.Clone
                            Next
                        Next
                    End If
                Case 1 'Erase
                    If Game.OnLocationLayer Then
                        If HoverTile(True).X > 0 Then
                            'Game.maps(Game.CurMapIndex).loc.RemoveLocation(HoverTile(True).X)
                            ReDim sellocs(1)
                            sellocs(1).loc = Game.maps(Game.CurMapIndex).loc.Locations(HoverTile(True).X)
                            Game.maps(Game.CurMapIndex).loc.RemoveLocation(HoverTile(True).X)
                            Delete()
                            Deselect()
                        End If
                    Else
                        If HoverTile.X = 0 Then Exit Select
                        If Game.CurMapCell2(HoverTile.X, HoverTile.Y).tile > 0 Then
                            ReDim seltiles(1)
                            seltiles(1).tile = Game.CurMapCell2(HoverTile.X, HoverTile.Y)
                            Game.CurMapCell2(HoverTile.X, HoverTile.Y) = New psMapTile
                            Delete()
                            Deselect()
                        End If
                    End If
                Case 2 'Select
                    If bOverTile And selecting = False Then
                        'Drag selected items
                        If Game.OnLocationLayer Then
                            For i = 1 To UBound(sellocs)
                                With sellocs(i).loc
                                    .X = origsellocs(i).loc.Rectangle.X + Math.Round((mx - sx) / Game.tileW) * Game.tileW
                                    .Y = origsellocs(i).loc.Rectangle.Y + Math.Round((my - sy) / Game.tileH) * Game.tileH
                                End With
                            Next
                            If locmove.Enabled Then locmove.SetRect(sellocs(1).loc.Rectangle)
                        Else
                            For i = 1 To UBound(seltiles)
                                With seltiles(i)
                                    .x = origseltiles(i).x + Int((mx - sx) / Game.tileW)
                                    .y = origseltiles(i).y + Int((my - sy) / Game.tileH)

                                    'Move path
                                    If .tile.Path.Exists Then
                                        Dim j As Integer, k As Integer
                                        For j = 0 To UBound(.tile.Path.Pts)
                                            For k = 0 To 3
                                                .tile.Path.Pts(j).XPoint(k) = origseltiles(i).tile.Path.Pts(j).XPoint(k) + Int((mx - sx) / Game.tileW) * Game.tileW
                                                .tile.Path.Pts(j).YPoint(k) = origseltiles(i).tile.Path.Pts(j).YPoint(k) + Int((my - sy) / Game.tileH) * Game.tileH
                                            Next
                                        Next
                                    End If
                                End With
                            Next
                        End If

                        'Update properties
                        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
                    Else
                        'Selection box
                        MakeValidRectangle(sel, sx, sy, mx, my)
                    End If
                Case 3 'Pan
                    With Game.cam
                        .X = oldcam.X + (sx - mx)
                        .Y = oldcam.Y + (sy - my)
                        If .X < 0 Then .X = 0
                        If .X > hs.Maximum Then .X = hs.Maximum
                        If .Y < 0 Then .Y = 0
                        If .Y > vs.Maximum Then .Y = vs.Maximum
                        hs.Value = .X
                        vs.Value = .Y
                    End With
            End Select
        End If

        Refresh()
    End Sub

    ReadOnly Property mxScrollSpeed() As Integer
        Get
            Return mx - Game.cam.X + Game.cam.X * Game.ScrollSpeed
        End Get
    End Property

    ReadOnly Property myScrollSpeed() As Integer
        Get
            Return my - Game.cam.Y + Game.cam.Y * Game.ScrollSpeed
        End Get
    End Property

    Private Sub SnapToTile(ByRef x As Integer, ByRef y As Integer)
        x = Math.Round(x / Game.tileW) * Game.tileW
        y = Math.Round(y / Game.tileH) * Game.tileH
        If x < 0 Then x = 0
        If y < 0 Then y = 0
        If x > Game.CurMapWidth * Game.tileW Then x = Game.CurMapWidth * Game.tileW
        If y > Game.CurMapHeight * Game.tileH Then y = Game.CurMapHeight * Game.tileH
    End Sub

    Private Sub p_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseDown
        If Locked Then Exit Sub
        If Editor.pstools Is Nothing Then Exit Sub

        p.Focus()

        psFileHandler.MadeChanges = True

        If e.Button = MouseButtons.Right Then RaiseEvent RightClick() : Exit Sub

        If PathEdit.Editing Then Exit Sub

        If e.Button <> MouseButtons.Left Then Exit Sub
        MDown = True

        Dim i As Integer

        'MouseDown code
        If Editor.pstools.Value = 3 Then
            panning = True
            oldcam = Game.cam
            sx = e.X
            sy = e.Y
            Exit Sub
        End If
        sx = e.X + Game.cam.X
        sy = e.Y + Game.cam.Y
        panning = False
        Select Case Editor.pstools.Value
            Case 0 'Draw
                If Editor.pstileselect.Value = 0 Then Editor.pstools.Value = 1 : GoTo Eraser
                UndoRedo.UpdateUndo(GetString("undoActionDraw"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
                If Game.OnLocationLayer Then
                    SnapToTile(sx, sy)
                    Game.maps(Game.CurMapIndex).loc.AddLocation(New psLocation(New Rectangle(sx, sy, 0, 0), "Location" & (Game.maps(Game.CurMapIndex).loc.NumLocations + 1)))
                End If
            Case 1 'Erase
Eraser:
                If Game.OnLocationLayer = False Then
                    UndoRedo.UpdateUndo(GetString("undoActionErase"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
                End If
            Case 2 'Select
                If (bOverTile = False And locmove.CurCursor Is Cursors.Default) Or ShiftDown = True Then
                    If ShiftDown = False Then Deselect()
                    selecting = True
                    sel = New Rectangle(sx, sy, 0, 0)
                Else
                    UndoRedo.UpdateUndo(GetString("undoActionTransformSelection"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
                    If Game.OnLocationLayer Then
                        origsellocs = sellocs.Clone
                    Else
                        origseltiles = seltiles.Clone
                        For i = 1 To UBound(seltiles)
                            origseltiles(i).tile = seltiles(i).tile.Clone
                        Next
                    End If
                End If
        End Select

        p_MouseMove(sender, e)
    End Sub

    ReadOnly Property ShiftDown() As Boolean
        Get
            Return (Control.ModifierKeys And Keys.Shift) <> 0
        End Get
    End Property

    Private Sub p_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseUp
        If PathEdit.Editing Then Exit Sub
        If Locked Then Exit Sub
        If Editor.pstools Is Nothing Then Exit Sub

        If Not MDown Then Exit Sub
        MDown = False

        'MouseUp code
        Dim i As Integer, j As Integer
        panning = False
        Select Case Editor.pstools.Value
            Case 0 'Draw
                If Game.OnLocationLayer Then
                    If Game.maps(Game.CurMapIndex).loc.Locations(Game.maps(Game.CurMapIndex).loc.NumLocations).Rectangle.Width = 0 And Game.maps(Game.CurMapIndex).loc.Locations(Game.maps(Game.CurMapIndex).loc.NumLocations).Rectangle.Height = 0 Then
                        Game.maps(Game.CurMapIndex).loc.RemoveLocation(Game.maps(Game.CurMapIndex).loc.NumLocations)
                    End If
                End If
            Case 2 'Select
                If selecting Then
                    selecting = False
                    If Game.OnLocationLayer Then
                        'If the user holds down shift,
                        'do not clear the selection
                        If ShiftDown = False Then Deselect()

                        'Deselect when holding shift
                        'and clicking on a selected location
                        If ShiftDown And sel.Width = 0 And sel.Height = 0 Then
                            Dim k As Integer, l As Integer
                            For k = 1 To UBound(sellocs)
                                If Game.Math.Collide_BoxBox(sel, sellocs(k).loc.Rectangle) Then
                                    Game.maps(Game.CurMapIndex).loc.AddLocation(sellocs(k).loc)
                                    For l = k To UBound(sellocs) - 1
                                        sellocs(l) = sellocs(l + 1)
                                    Next
                                    ReDim Preserve sellocs(UBound(sellocs) - 1)
                                    GoTo DoneSelLoc
                                End If
                            Next
                        End If

                        'Otherwise, add to the selection
                        For i = Game.maps(Game.CurMapIndex).loc.NumLocations To 1 Step -1
                            If Game.Math.Collide_BoxBox( _
                            sel, Game.maps(Game.CurMapIndex).loc.Locations(i).Rectangle) Then
                                ReDim Preserve sellocs(UBound(sellocs) + 1)
                                sellocs(UBound(sellocs)).loc = Game.maps(Game.CurMapIndex).loc.Locations(i)
                                Game.maps(Game.CurMapIndex).loc.RemoveLocation(i)
                                If sel.Width = 0 And sel.Height = 0 Then Exit For
                            End If
                        Next

                        'Enable the resize handles if there is only
                        'one location currently selected
DoneSelLoc:
                        If UBound(sellocs) = 1 Then
                            locmove.SetRect(sellocs(1).loc.Rectangle)
                            locmove.Enable()
                        Else
                            locmove.Disable()
                        End If
                    Else

                        'Store the current selection rectangle
                        Dim tsel As Rectangle
                        tsel = sel

                        'Convert the selection to tile coordinates 
                        sel.Width = Int((sel.X + sel.Width) / Game.tileW) + 1
                        sel.Height = Int((sel.Y + sel.Height) / Game.tileH) + 1
                        sel.X = Int(sel.X / Game.tileW) + 1
                        sel.Y = Int(sel.Y / Game.tileH) + 1

                        'Stay in bounds 
                        If sel.X < 1 Then sel.X = 1
                        If sel.Y < 1 Then sel.Y = 1
                        If sel.Width > Game.CurMapWidth - 1 Then sel.Width = Game.CurMapWidth
                        If sel.Height > Game.CurMapHeight - 1 Then sel.Height = Game.CurMapHeight

                        'If the user holds down shift,
                        'do not clear the selection
                        If ShiftDown = False Then Deselect()

                        For i = sel.X To sel.Width
                            For j = sel.Y To sel.Height

                                'Deselect when holding shift and
                                'clicking on a selected tile
                                If ShiftDown And tsel.Width = 0 And tsel.Height = 0 Then
                                    Dim k As Integer, l As Integer
                                    For k = 1 To UBound(seltiles)
                                        If Game.Math.Collide_PtBox(i, j, seltiles(k).x, seltiles(k).y, seltiles(k).w \ Game.tileW - 1, seltiles(k).h \ Game.tileH - 1) Then
                                            Game.CurMapCell2(seltiles(k).x, seltiles(k).y) = seltiles(k).tile
                                            For l = k To UBound(seltiles) - 1
                                                seltiles(l) = seltiles(l + 1)
                                            Next
                                            ReDim Preserve seltiles(UBound(seltiles) - 1)
                                            Exit Select
                                        End If
                                    Next
                                End If

                                'Otherwise, add to the selection
                                If Game.CurMapCell(i, j) > 0 Then
                                    ReDim Preserve seltiles(UBound(seltiles) + 1)
                                    seltiles(UBound(seltiles)).tile = Game.CurMapCell2(i, j)
                                    seltiles(UBound(seltiles)).x = i
                                    seltiles(UBound(seltiles)).y = j
                                    Game.CurMapCell2(i, j) = New psMapTile
                                End If

                            Next
                        Next

                    End If
                End If
        End Select
        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Private Sub hs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hs.Scroll
        hsscroll()
        '        Refresh()
    End Sub

    Private Sub hsscroll()
        Game.cam.X = hs.Value
        Editor.psedit.Refresh()
    End Sub

    Private Sub vs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vs.Scroll
        vsscroll()
        '        Refresh()
    End Sub

    Private Sub vsscroll()
        Game.cam.Y = vs.Value
        Editor.psedit.Refresh()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        While (Created)
            System.Windows.Forms.Application.DoEvents()
            If Created = False Then Exit While
            If Game.Drawing IsNot Nothing AndAlso Not DoNotRenderInRenderLoop Then
                Refresh()
            Else
                Threading.Thread.Sleep(CInt(1000.0 / 60.0))
            End If
        End While
        'If (game.Drawing Is Nothing) = False Then
        '    Refresh()
        'End If
    End Sub

    Sub Deselect()
        Deselect(False)
    End Sub

    Sub Deselect(ByVal KeepSel As Boolean)
        If Locked Then Exit Sub

        If KeepSel = False AndAlso (locmove Is Nothing) = False Then locmove.Disable()
        If seltiles Is Nothing Then Exit Sub
        Dim i As Integer
        If Game.OnLocationLayer Then
            For i = 1 To UBound(sellocs)
                If Game.Math.Collide_BoxBox( _
                sellocs(i).loc.Rectangle, New Rectangle(0, 0, Game.CurMapWidth * Game.tileW, Game.CurMapHeight * Game.tileH)) Then
                    Game.maps(Game.CurMapIndex).loc.AddLocation(sellocs(i).loc)
                End If
            Next
            If KeepSel = False Then
                ReDim sellocs(0)
                ReDim origsellocs(0)

                'Update properties
                If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
            End If
        Else
            For i = 1 To UBound(seltiles)
                With seltiles(i)
                    If .x >= 1 And .y >= 1 And .x <= Game.CurMapWidth And .y <= Game.CurMapHeight Then
                        Game.CurMapCell2(.x, .y) = .tile
                    End If
                End With
            Next
            If KeepSel = False Then
                ReDim seltiles(0)
                ReDim origseltiles(0)

                'Update properties
                If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
            End If
        End If
    End Sub

    Sub Delete()
        If Locked Then Exit Sub

        Dim i, j, k As Integer
        Dim tmpGroups As String() = ListGroups(Game.CurMapIndex)

        'Make sure user wants to delete
        If Options.gWarnWhenDelActions = False Then GoTo DoneChecking
        If Game.OnLocationLayer Then
            'Search for location actions
            With Game.actions
                For j = 1 To UBound(sellocs)
                    For i = 1 To UBound(.Actions)
                        If .Actions(i).Trigger.Chars(0) = "l" AndAlso .Actions(i).Trigger.Substring(4, 5) = Game.CurMapIndex AndAlso .Actions(i).Trigger.Substring(9) = sellocs(j).loc.Name Then
                            If MessageBox.Show(GetString("deleteActionConfirmationMessage"), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Exit Sub
                            Else
                                GoTo DoneChecking
                            End If
                        End If
                    Next
                Next
            End With
        Else
            If LastTileInGroup() Then
                If MessageBox.Show(GetString("deleteActionConfirmationMessage"), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If
DoneChecking:

        locmove.Disable()

        If Game.OnLocationLayer Then
            UndoRedo.UpdateUndo(GetString("undoActionDelete"), UndoRedo.UndoType.Locations, Game.CurMapIndex)
            'Delete location actions
            With Game.actions
                For j = 1 To UBound(sellocs)
                    For i = 1 To UBound(.Actions)
                        If i > UBound(.Actions) Then Exit For
                        If .Actions(i).Trigger.Chars(0) = "l" AndAlso .Actions(i).Trigger.Substring(4, 5) = Game.CurMapIndex AndAlso .Actions(i).Trigger.Substring(9) = sellocs(j).loc.Name Then
                            For k = i To UBound(.Actions) - 1
                                .Actions(k) = .Actions(k + 1)
                            Next
                            ReDim Preserve .Actions(UBound(.Actions) - 1)
                            i = i - 1
                        End If
                    Next
                Next
            End With
        Else
            UndoRedo.UpdateUndo(GetString("undoActionDelete"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
            DeleteUnusedGroupActions()
        End If

        ReDim seltiles(0)
        ReDim origseltiles(0)
        ReDim sellocs(0)
        ReDim origsellocs(0)

        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Function LastTileInGroup() As Boolean
        'Search for group actions
        Dim j, k As Integer
        Dim tmpGroups As String() = ListGroups(Game.CurMapIndex)
        With Game.actions
            For j = 1 To UBound(seltiles)
                If seltiles(j).tile.Group <> "" Then
                    For k = 1 To UBound(tmpGroups)
                        If tmpGroups(k) = seltiles(j).tile.Group Then GoTo NextJ
                    Next
                    For k = 1 To UBound(.Actions)
                        If .Actions(k).Trigger.Chars(0) = "g" AndAlso .Actions(k).Trigger.Substring(4, 5) = Game.CurMapIndex AndAlso .Actions(k).Trigger.Substring(9) = seltiles(j).tile.Group Then
                            Return True
                        End If
                    Next
                End If
NextJ:
            Next
        End With
        Return False
    End Function

    Sub DeleteUnusedGroupActions()
        'Delete group actions
        Dim j As Integer, k As Integer, l As Integer
        Dim tmpGroups As String() = ListGroups(Game.CurMapIndex)
        With Game.actions
            For j = 1 To UBound(seltiles)
                If seltiles(j).tile.Group <> "" Then
                    For k = 1 To UBound(tmpGroups)
                        If tmpGroups(k) = seltiles(j).tile.Group Then GoTo NextJ2
                    Next
                    For k = 1 To UBound(.Actions)
                        If k > UBound(.Actions) Then Exit For
                        If .Actions(k).Trigger.Chars(0) = "g" AndAlso .Actions(k).Trigger.Substring(4, 5) = Game.CurMapIndex AndAlso .Actions(k).Trigger.Substring(9) = seltiles(j).tile.Group Then
                            For l = k To UBound(.Actions) - 1
                                .Actions(l) = .Actions(l + 1).Clone
                            Next
                            ReDim Preserve .Actions(UBound(.Actions) - 1)
                            k -= 1
                        End If
                    Next
                End If
NextJ2:
            Next
        End With
    End Sub

    Sub Copy()
        If Locked Then Exit Sub

        If Game.OnLocationLayer Then
            clip_board_locs = sellocs.Clone
        Else
            clip_board = seltiles.Clone
            Dim i As Integer
            For i = 1 To UBound(seltiles)
                clip_board(i).tile = seltiles(i).tile.Clone
            Next
        End If
    End Sub

    Sub Cut()
        Copy()
        Delete()
    End Sub

    Sub Paste()
        If Locked Then Exit Sub

        psFileHandler.MadeChanges = True

        Editor.pstools.Value = 2
        Deselect()
        selecting = False
        If Game.OnLocationLayer Then
            sellocs = clip_board_locs.Clone
            If UBound(sellocs) = 1 Then
                locmove.SetRect(sellocs(1).loc.Rectangle)
                locmove.Enable()
            End If
        Else
            seltiles = clip_board.Clone
            Dim i As Integer
            For i = 1 To UBound(seltiles)
                seltiles(i).tile = clip_board(i).tile.Clone
            Next
        End If

        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Sub SelectAll()
        If Locked Then Exit Sub

        psFileHandler.MadeChanges = True

        Editor.pstools.Value = 2
        Deselect()
        selecting = False

        Dim i As Integer, j As Integer

        If Game.OnLocationLayer Then
            ReDim sellocs(Game.maps(Game.CurMapIndex).loc.NumLocations)
            For i = 1 To UBound(sellocs)
                sellocs(i).loc = Game.maps(Game.CurMapIndex).loc.Locations(i)
            Next
            ReDim Game.maps(Game.CurMapIndex).loc.Locations(0)
            If UBound(sellocs) = 1 Then
                locmove.SetRect(sellocs(1).loc.Rectangle)
                locmove.Enable()
            End If
        Else
            ReDim seltiles(0)
            For i = 1 To Game.CurMapWidth
                For j = 1 To Game.CurMapHeight
                    If Game.CurMapCell(i, j) > 0 Then
                        ReDim Preserve seltiles(UBound(seltiles) + 1)
                        seltiles(UBound(seltiles)).tile = Game.CurMapCell2(i, j)
                        seltiles(UBound(seltiles)).x = i
                        seltiles(UBound(seltiles)).y = j
                        Game.CurMapCell(i, j) = 0
                    End If
                Next
            Next
        End If

        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    ReadOnly Property NumSelItems() As Integer
        Get
            If Game.OnLocationLayer Then
                Return UBound(sellocs)
            Else
                Return UBound(seltiles)
            End If
        End Get
    End Property

    Function CanCopy() As Boolean
        If PathEdit.Editing Then
            Return False
        Else
            Return (Editor.pstools.Value = 2 And _
                    selecting = False And _
                    NumSelItems > 0)
        End If
    End Function

    Function CanCut() As Boolean
        Return CanCopy()
    End Function

    Function CanDelete() As Boolean
        Return CanCopy()
    End Function

    Function CanPaste() As Boolean
        If PathEdit.Editing Then
            Return False
        Else
            If Game.OnLocationLayer Then
                Return Not (clip_board_locs Is Nothing)
            Else
                Return Not (clip_board Is Nothing)
            End If
        End If
    End Function

    Function CanDeselect() As Boolean
        Return CanCopy()
    End Function

    Private Sub p_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles p.Paint
        If (began) Then Refresh()
    End Sub

    Sub Undo()
        psFileHandler.MadeChanges = True
        If PathEdit.Editing Then
            PathEdit.Undo()
        Else
            UndoRedo.DoUndo()
        End If
    End Sub

    Sub Redo()
        psFileHandler.MadeChanges = True
        If PathEdit.Editing Then
            PathEdit.Redo()
        Else
            UndoRedo.DoRedo()
        End If
    End Sub

    Function CanUndo() As Boolean
        If PathEdit.Editing Then
            Return PathEdit.CanUndo
        Else
            Return UndoRedo.CanUndo
        End If
    End Function

    Function CanRedo() As Boolean
        If PathEdit.Editing Then
            Return PathEdit.CanRedo
        Else
            Return UndoRedo.CanRedo
        End If
    End Function

    Function CanSelectAll() As Boolean
        Return (Not PathEdit.Editing)
    End Function

    Friend Sub UndoRedoTextChanged()
        RaiseEvent EditFunctionsChanged()
    End Sub

    ReadOnly Property UndoText() As String
        Get
            If PathEdit.Editing Then
                If PathEdit.UndoStr Is Nothing OrElse PathEdit.CanUndo() = False Then Return ""
                Return PathEdit.UndoStr(PathEdit.CurUndo - 1)
            Else
                If UndoRedo.UndoStr Is Nothing OrElse CanUndo() = False Then Return ""
                Try
                    Return UndoRedo.UndoStr(UndoRedo.CurUndo - 1)
                Catch
                    UndoRedo.CanUndo = False
                    Return ""
                End Try
            End If
        End Get
    End Property

    ReadOnly Property RedoText() As String
        Get
            If PathEdit.Editing Then
                If PathEdit.UndoStr Is Nothing OrElse PathEdit.CanRedo() = False Then Return ""
                Return PathEdit.UndoStr(PathEdit.CurUndo)
            Else
                If UndoRedo.UndoStr Is Nothing OrElse CanRedo() = False Then Return ""
                Return UndoRedo.UndoStr(UndoRedo.CurUndo)
            End If
        End Get
    End Property

    Friend Sub Raise_PathEditorRightClick()
        RaiseEvent PathEditorRightClick()
    End Sub

    Function PromptToSavePath() As DialogResult
        If Editor.psedit.PathEdit.Editing Then
            Select Case MessageBox.Show(GetString("main_SaveChangesToPathMessage0"), "JumpCraft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Editor.psedit.PathEdit.Done(False)
                    Return DialogResult.Yes
                Case DialogResult.No
                    Editor.psedit.PathEdit.Done(True)
                    Return DialogResult.No
                Case DialogResult.Cancel
                    Return DialogResult.Cancel
            End Select
        End If
    End Function

    Private Sub p_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p.DoubleClick
        RaiseEvent DoubleClick()
    End Sub

    Private Sub p_MouseWheel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseWheel
        Dim newValue As Integer = vs.Value - Math.Sign(e.Delta) * Game.tileH
        If newValue < vs.Minimum Then newValue = vs.Minimum
        If newValue > vs.Maximum Then newValue = vs.Maximum
        vs.Value = newValue
        vs_Scroll(Nothing, Nothing)
    End Sub
End Class