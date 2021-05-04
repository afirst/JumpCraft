Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports UIPlus
Imports PlatformStudio

Public Class psTileSelector
    Inherits System.Windows.Forms.Panel

    Event SelectedIndexChanged()
    Event DraggedItem(ByVal item As Integer)
    Event DrawIcon(ByVal e As PaintEventArgs, ByVal item As Integer, ByVal rect As Rectangle)

#Region "Components"
    Friend WithEvents vs As System.Windows.Forms.VScrollBar
    Friend WithEvents subtiles As DoubleBufferedPictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tb As UIPlusToolbar
    Friend WithEvents tbpanel As Panel
    Private components As System.ComponentModel.IContainer

    Sub New()
        InitializeComponent()

        Me.vs = New System.Windows.Forms.VScrollBar
        Me.subtiles = New DoubleBufferedPictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tb = New UIPlusToolbar
        Me.tbpanel = New Panel
        '
        'vs
        '
        Me.vs.Dock = System.Windows.Forms.DockStyle.Right
        Me.vs.Location = New System.Drawing.Point(17, 17)
        Me.vs.Name = "vs"
        Me.vs.TabIndex = 0
        '
        'tb
        '
        Me.tb.ImageList = iml2
        Me.tb.Buttons.Add(New ToolBarButton)
        Me.tb.Buttons(0).ImageIndex = 0
        Me.tb.Buttons(0).ToolTipText = GetString("tileSelector_RandomTooltip")
        Me.tb.Buttons(0).Style = ToolBarButtonStyle.ToggleButton
        Me.tb.CustomColorScheme = New TransparentToolbarColorScheme
        Me.tb.Style = MenuStyles.Custom
        '
        'tbpanel
        '
        Me.tbpanel.BackColor = colors.ToolbarCheck1
        Me.tbpanel.Width = 32
        Me.tbpanel.Height = 32
        Me.tbpanel.Dock = DockStyle.None
        Me.tbpanel.Controls.Add(tb)
        Me.tbpanel.Visible = False
        '
        'subtiles
        '
        Me.subtiles.BackColor = colors.ToolbarCheck1
        Me.subtiles.Location = New System.Drawing.Point(79, 17)
        Me.subtiles.Name = "subtiles"
        Me.subtiles.TabIndex = 0
        Me.subtiles.TabStop = False
        Me.subtiles.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1

        Me.Controls.Add(vs)
        Me.Controls.Add(subtiles)
        Me.Controls.Add(tbpanel)

        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Class TransparentToolbarColorScheme
        Inherits DefaultColorScheme

        Public Overrides ReadOnly Property Toolbar1() As System.Drawing.Color
            Get
                Return ToolbarCheck1
            End Get
        End Property

        Public Overrides ReadOnly Property Toolbar2() As System.Drawing.Color
            Get
                Return ToolbarCheck1
            End Get
        End Property
    End Class

    Sub setSubtilesVisible(ByVal value As Boolean)
        subtiles.Visible = value
        tbpanel.Visible = value
    End Sub

    ReadOnly Property Random() As Boolean
        Get
            Return tb.Buttons(0).Pushed
        End Get
    End Property

    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents iml2 As System.Windows.Forms.ImageList

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psTileSelector))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.iml2 = New System.Windows.Forms.ImageList(Me.components)
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(32, 32)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'iml2
        '
        Me.iml2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml2.ImageSize = New System.Drawing.Size(24, 24)
        Me.iml2.ImageStream = CType(resources.GetObject("iml2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml2.TransparentColor = System.Drawing.Color.White

    End Sub
#End Region

    Friend selIndex As Integer = -1
    Friend hoverIndex As Integer = -1
    Friend pressedIndex As Integer = -1
    Friend contentHeight As Integer
    Friend itemY() As Integer
    Friend trueScrollMax As Integer
    Friend Const SCROLL_SCALE As Integer = 32
    Private curList As CustomList
    Private pathList As New pathList(Me)
    Private defList As CustomList
    Private Initialized As Boolean
    Public CanDragDrop As Boolean
    Public CanMultiselect As Boolean
    Public SelIndices As New ArrayList
    Public DrawCustomIcons As Boolean

    ReadOnly Property Internal() As CustomList
        Get
            Return CurList
        End Get
    End Property

    Enum SelectorType
        Other
        Tile
        Control
        Action
        Tile2
    End Enum

    Sub Init(ByVal type As SelectorType)
        If Game Is Nothing Then Exit Sub

        'Register control
        If type = SelectorType.Tile Then
            If Editor.pstileselect Is Nothing Then
                Editor.pstileselect = Me
            End If
            defList = New TileList(Me)
        ElseIf type = SelectorType.Control Then
            Editor.winctrls = Me
            defList = New ControlList(Me)
        ElseIf type = SelectorType.Action Then
            defList = New ActionList(Me)
        ElseIf type = SelectorType.Tile2 Then
            defList = New TileList2(Me)
        End If

        Initialized = True

        UpdateList()
    End Sub

    Sub UpdateList()
        If editingPath Then
            curList = pathList
        Else
            curList = defList
        End If
        If Not Game Is Nothing AndAlso Not Game.tileset.tiles Is Nothing Then
            If UBound(Game.tileset.tiles) = 0 Then
                SelIndices.Clear()
                Value = -1
                If Editor.pstools.buttons(0).enabled Then Editor.pstools.buttons(0).enabled = False
                If Editor.pstools.buttons(1).enabled Then Editor.pstools.buttons(1).enabled = False
            Else
                SelIndices.Clear() : SelIndices.Add(1 + curList.valueOffset)
                Value = SelIndices(SelIndices.Count - 1)
                If Not Editor.pstools.buttons(0).enabled Then Editor.pstools.buttons(0).enabled = True
                If Not Editor.pstools.buttons(1).enabled Then Editor.pstools.buttons(1).enabled = True
            End If
        End If
        OnResize(EventArgs.Empty)
        If Not Game Is Nothing AndAlso Not Game.tileset.tiles Is Nothing Then
            If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.cboTiles.Refresh()
        End If
    End Sub

    Private Sub updateMeasurements()
        contentHeight = curList.getContentHeight
    End Sub

    Public BackColor1 As Color = ColorOp.Blend(SystemColors.Control, SystemColors.ControlLightLight, 0.35)
    Public BackColor2 As Color = ColorOp.Blend(SystemColors.Control, SystemColors.ControlDark, 0.12)
    Public Border As Boolean = False

    Protected Overrides Sub onPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If w <= 3 Or h <= 3 Then Return
            If curList Is Nothing Then Return

            If Not CanMultiselect Then
                SelIndices.Clear()
                SelIndices.Add(Value - curList.valueOffset)
            End If

            With e.Graphics
                Dim b As Brush
                Dim p As Pen
                Dim r As Rectangle = New Rectangle(0, 0, w, h) 'e.ClipRectangle

                'Background
                b = New LinearGradientBrush( _
                    New Rectangle(0, 0, w, h), _
                    BackColor1, _
                    BackColor2, _
                    LinearGradientMode.Horizontal)
                .FillRectangle(b, r)
                b.Dispose()

                'If Game Is Nothing OrElse Game.tileset.tiles Is Nothing Then Return

                'Draw contents of list
                If Not itemY Is Nothing Then
                    curList.Draw(e)
                End If

                'Drag
                If dragging Then
                    p = New Pen(Color.Black)
                    Dim tmpY As Integer = insertLine - scrollValue
                    .DrawLine(p, 0, tmpY, w, tmpY)
                    .DrawLine(p, 0, tmpY + 1, w, tmpY + 1)
                    .DrawLine(p, 0, tmpY - 2, 0, tmpY + 3)
                    .DrawLine(p, w - 1, tmpY - 2, w - 1, tmpY + 3)
                    .DrawLine(p, 1, tmpY - 1, 1, tmpY + 2)
                    .DrawLine(p, w - 2, tmpY - 1, w - 2, tmpY + 2)
                    p.Dispose()
                End If
            End With

            MyBase.OnPaint(e)
        Catch
        End Try
    End Sub

    Protected Friend Overridable Sub OnDrawIcon(ByVal e As PaintEventArgs, ByVal item As Integer, ByVal rect As Rectangle)
        RaiseEvent DrawIcon(e, item, rect)
    End Sub

#Region "Helper Functions"
    Friend ReadOnly Property w() As Integer
        Get
            Return Width - vs.Width
        End Get
    End Property
    Friend ReadOnly Property h() As Integer
        Get
            Return Height
        End Get
    End Property
    Friend ReadOnly Property colors() As IColorScheme
        Get
            Return DefaultColorScheme.getInstance
        End Get
    End Property
    Private ReadOnly Property editingPath() As Boolean
        Get
            If Editor.psedit Is Nothing OrElse Editor.psedit.PathEdit Is Nothing Then Return False
            Return Editor.psedit.PathEdit.Editing
        End Get
    End Property
#End Region

#Region "Scrolling"
    Private Sub vs_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vs.Scroll
        Focus()
        Invalidate()
    End Sub

    Sub DoOnResize()
        OnResize(EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        If Not Initialized Then Exit Sub
        If Game Is Nothing OrElse Game.tileset.tiles Is Nothing Then Exit Sub
        vs.Height = Height
        updateMeasurements()
        trueScrollMax = Math.Max(contentHeight - h + 1, 0)
        vs.Maximum = Math.Ceiling(trueScrollMax / SCROLL_SCALE)
        vs.Enabled = (vs.Maximum > 0)
        vs.SmallChange = 1
        vs.LargeChange = 1
        curList.updateSubtiles()
        Invalidate()
    End Sub

    Friend ReadOnly Property scrollValue() As Integer
        Get
            If vs.Value * SCROLL_SCALE > trueScrollMax Then
                Return trueScrollMax
            Else
                Return vs.Value * SCROLL_SCALE
            End If
        End Get
    End Property

    Friend ReadOnly Property itemH(ByVal index As Integer) As Integer
        Get
            If index = UBound(itemY) Then
                Return contentHeight - itemY(index) - 1
            Else
                Return itemY(index + 1) - itemY(index) - 1
            End If
        End Get
    End Property
#End Region

#Region "Mouse"
    Dim sx, sy As Integer, mdown, dragging As Boolean
    Dim dragItem As Integer, insertLine As Integer

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Game Is Nothing Then Exit Sub
        Dim temp As Integer = pointToIndex(e.X, e.Y + scrollValue)
        If temp = selIndex AndAlso SelIndices.Count = 1 Then temp = -1
        If temp <> hoverIndex Then
            hoverIndex = temp
            Invalidate()
        End If

        'Dragging
        If CanDragDrop And mdown Then
            If Not dragging AndAlso Math.Abs(e.X - sx) >= 5 Or Math.Abs(e.Y - sy) >= 5 Then
                dragging = True
                If pressedIndex > -1 Then
                    SelIndices.Clear() : SelIndices.Add(pressedIndex + curList.valueOffset)
                    Value = SelIndices(SelIndices.Count - 1)
                ElseIf selIndex = -1 Then
                    dragging = False
                End If
            End If
            If dragging Then
                pressedIndex = -1
                hoverIndex = -1
                Dim tmpY As Integer = e.Y + scrollValue
                insertLine = contentHeight
                For dragItem = 1 To UBound(itemY)
                    If tmpY < itemY(dragItem) + itemH(dragItem) \ 2 Then
                        insertLine = itemY(dragItem)
                        Exit For
                    End If
                Next
                Invalidate()
            End If
        End If

    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Game Is Nothing Then Exit Sub
        If e.Button <> MouseButtons.Left Then Exit Sub
        Dim temp As Integer = pointToIndex(e.X, e.Y + scrollValue)
        If temp <> pressedIndex Then
            pressedIndex = -1
        ElseIf pressedIndex > -1 Then
            Dim tmpValue As Integer = pressedIndex

            'Multiselect
            If CanMultiselect Then
                If (ModifierKeys And Keys.Shift) AndAlso Value > 0 Then
                    'Add range
                    For i As Integer = Math.Min(Value, tmpValue) To Math.Max(Value, tmpValue)
                        For j As Integer = 0 To SelIndices.Count - 1
                            If SelIndices(j) = i Then
                                GoTo ContinueForI
                            End If
                        Next
                        SelIndices.Add(i)
ContinueForI:       Next
                ElseIf ModifierKeys And Keys.Control Then
                    'Toggle value
                    Dim removed As Boolean
                    For i As Integer = 0 To SelIndices.Count - 1
                        If SelIndices(i) = tmpValue Then
                            SelIndices.RemoveAt(i)
                            If SelIndices.Count = 0 Then
                                tmpValue = 1
                                SelIndices.Add(tmpValue)
                            End If
                            removed = True
                            Exit For
                        End If
                    Next
                    If Not removed Then SelIndices.Add(tmpValue)
                Else
                    'Select only one item
                    SelIndices.Clear()
                    SelIndices.Add(tmpValue)
                End If
            Else
                'Select only one item
                SelIndices.Clear()
                SelIndices.Add(tmpValue)
            End If

            'Set value
            Value = tmpValue + curList.valueOffset

            pressedIndex = -1
        End If

        'Dragging
        mdown = False
        If dragging Then
            dragging = False
            RaiseEvent DraggedItem(dragItem + curList.valueOffset)
        End If

        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        If Game Is Nothing Then Exit Sub
        hoverIndex = -1
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Game Is Nothing Then Exit Sub
        If e.Button <> MouseButtons.Left Then Exit Sub
        Focus()
        pressedIndex = hoverIndex
        Invalidate()
        If CanDragDrop Then
            sx = e.X
            sy = e.Y
            mdown = True
            dragging = False
        End If
    End Sub

    Function pointToIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        If itemY Is Nothing Then Return -1
        For i As Integer = 1 To UBound(itemY)
            If y >= itemY(i) AndAlso x >= 0 AndAlso x <= w AndAlso y <= itemY(i) + itemH(i) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Game Is Nothing Then Exit Sub
        Dim newValue As Integer = vs.Value - Math.Sign(e.Delta)
        If newValue < 0 Then
            vs.Value = 0
        ElseIf newValue > vs.Maximum Then
            vs.Value = vs.Maximum
        Else
            vs.Value = newValue
        End If
        Invalidate()
    End Sub

    Sub setImageList(ByVal new_iml As ImageList)
        iml.Dispose()
        iml = new_iml
    End Sub

#End Region

#Region "Subtiles"
    Dim NoResizePreview As Boolean
    Public SelSubIndex As Integer = 1
    Public SelWidth As Integer = 1
    Public SelHeight As Integer = 1
    Dim Hover As Point = New Point(-1000000, -1000000)
    Dim SelPt As Point

    Function GetCellFromXY(ByVal x As Integer, ByVal y As Integer) As Integer
        Dim CellsX As Integer, CellX As Integer, CellY As Integer
        With Game.tileset.tiles(selIndex)
            CellsX = .width / .sectionw
            CellX = Int(x / CellW) + 1
            CellY = Int(y / CellH) + 1
            Return (CellY - 1) * CellsX + CellX
        End With
    End Function

    ReadOnly Property CellW() As Single
        Get
            With Game.tileset.tiles(selIndex)
                Return subtiles.Width / (.width / .sectionw)
            End With
        End Get
    End Property

    ReadOnly Property CellH() As Single
        Get
            With Game.tileset.tiles(selIndex)
                Return subtiles.Height / (.height / .sectionh)
            End With
        End Get
    End Property

    ReadOnly Property DisplaySelWidth() As Integer
        Get
            If Random Then
                Return 1
            Else
                Return SelWidth
            End If
        End Get
    End Property

    ReadOnly Property DisplaySelHeight() As Integer
        Get
            If Random Then
                Return 1
            Else
                Return SelHeight
            End If
        End Get
    End Property

    Function GetRandomFrame() As Integer
        Randomize()
        Dim i As Integer = Int(Rnd(1) * SelWidth)
        Dim j As Integer = Int(Rnd(1) * SelHeight)
        Return SelSubIndex + i + j * Game.tileset.tiles(psEditor.CurTile).width \ Game.tileset.tiles(psEditor.CurTile).sectionw
    End Function

    Private Sub subtiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles subtiles.MouseDown
        Try
            SelSubIndex = GetCellFromXY(e.X, e.Y)
            SelPt = New Point(Int(e.X / CellW) * CellW, _
                              Int(e.Y / CellH) * CellH)
            SelWidth = 1
            SelHeight = 1
            subtiles.Invalidate()
        Catch
            SelSubIndex = 1
            SelWidth = 1
            SelHeight = 1
        End Try
        psEditor.CurTile = Value
        Editor.pstools.Value = psTools.Tools.Draw
    End Sub

    Private Sub subtiles_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles subtiles.MouseMove
        Try
            Hover = New Point(Int(e.X / CellW) * CellW, _
                              Int(e.Y / CellH) * CellH)

            'Select multiple tiles
            If e.Button = MouseButtons.Left Then
                SelWidth = (Hover.X - SelPt.X) \ CellW + 1
                SelHeight = (Hover.Y - SelPt.Y) \ CellH + 1
                If SelWidth < 1 Then SelWidth = 1
                If SelHeight < 1 Then SelHeight = 1
                If SelPt.X + SelWidth * CellW > subtiles.Width Then SelWidth = (subtiles.Width - SelPt.X) \ CellW
                If SelPt.Y + SelHeight * CellH > subtiles.Height Then SelHeight = (subtiles.Height - SelPt.Y) \ CellH
            End If

            subtiles.Invalidate()
        Catch
        End Try
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles subtiles.MouseLeave
        Hover = New Point(-1000000, -1000000)
        subtiles.Invalidate()
    End Sub

    Friend Sub ResizeSubtiles()
        NoResizePreview = True
        Dim s As Size = subtilesSize()
        subtiles.Width = s.Width
        subtiles.Height = s.Height
        setSubtilesVisible(subtilesVisible())
        tb.Visible = subtiles.Visible
        NoResizePreview = False
    End Sub

    Friend Function subtilesSize() As Size
        If Not subtilesVisible() Then Return New Size(0, 0)
        Dim tmpW, tmpH As Integer
        tmpW = Game.tileset.tileBitmap(selIndex).Width
        tmpW = Math.Min(w - 2, tmpW)
        tmpW = Math.Max(tmpW, 32)
        Dim tmpHeight As Integer = tmpW * Game.tileset.tileBitmap(selIndex).Height \ Game.tileset.tileBitmap(selIndex).Width
        Dim MaxHeight As Integer = h \ 2
        If tmpHeight > MaxHeight Then tmpHeight = MaxHeight
        tmpH = tmpHeight
        Return New Size(tmpW, tmpH)
    End Function

    Friend Function subtilesVisible() As Boolean
        If Game Is Nothing OrElse Game.tileset.tiles Is Nothing Then Return False
        If selIndex = -1 Then Return False
        With Game.tileset.tiles(selIndex)
            If .Anim(0).Interval > 0 Or _
            (.width = .sectionw And .height = .sectionh) Then
                Return False
            Else
                Return True
            End If
        End With
    End Function

    Private Sub subtiles_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles subtiles.Paint
        Try
            If Game Is Nothing OrElse Game.tileset.tiles Is Nothing Then Exit Sub
            If Not (Editor.psedit.PathEdit Is Nothing) Then
                If Editor.psedit.PathEdit.Editing Then
                    Exit Sub
                End If
            End If
            With e.Graphics
                .Clear(subtiles.BackColor)
                .DrawImage(Game.tileset.tileBitmap(selIndex), New Rectangle(0, 0, subtiles.Width, subtiles.Height))
                Dim tmpRect As Rectangle = CurRect(Game.tileset.tiles(selIndex), SelSubIndex)
                tmpRect.X *= (subtiles.Width / Game.tileset.tiles(selIndex).width)
                tmpRect.Y *= (subtiles.Height / Game.tileset.tiles(selIndex).height)
                tmpRect.Width = CellW * SelWidth
                tmpRect.Height = CellH * SelHeight
                .FillRectangle(New Pen(Color.FromArgb(128, 64, 64, 255)).Brush, tmpRect)
                .DrawRectangle(New Pen(Color.FromArgb(192, 128, 128, 255)), tmpRect)
                .DrawRectangle(New Pen(Color.FromArgb(192, 128, 128, 255)), New Rectangle(tmpRect.X - 1, tmpRect.Y - 1, tmpRect.Width + 2, tmpRect.Height + 2))
                .FillRectangle(New Pen(Color.FromArgb(64, 0, 0, 255)).Brush, New Rectangle(Hover.X, Hover.Y, CellW, CellH))
                .DrawRectangle(New Pen(Color.FromArgb(192, 128, 128, 255)), New Rectangle(Hover.X, Hover.Y, CellW, CellH))
                .DrawRectangle(New Pen(Color.FromArgb(192, 128, 128, 255)), New Rectangle(Hover.X - 1, Hover.Y - 1, CellW + 2, CellH + 2))
            End With
        Catch
        End Try
    End Sub
#End Region

    <System.ComponentModel.Browsable(False)> _
    Property Value() As Integer
        Get
            If curList Is Nothing Then Return 0
            Return selIndex + curList.valueOffset
        End Get
        Set(ByVal Value As Integer)
            If Not Initialized Then Exit Property
            If Value > -1 Then
                Value -= curList.valueOffset
            End If
            selIndex = Value
            SelSubIndex = 1
            SelWidth = 1
            SelHeight = 1
            If Game Is Nothing OrElse Game.tileset.tiles Is Nothing Then Exit Property
            OnResize(EventArgs.Empty)
            ensureSelVisible()
            Invalidate()
            subtiles.Invalidate()
            curList.onSelect()
            RaiseEvent SelectedIndexChanged()
        End Set
    End Property

    Sub SelectSingleItem(ByVal index As Integer)
        SelIndices.Clear()
        SelIndices.Add(index)
        Value = index + curList.valueOffset
    End Sub

    'Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = Keys.Up Then
    '        If Value > 0 Then
    '            Value -= 1
    '            While itemY(Value) < scrollValue
    '                vs.Value -= 1
    '            End While
    '        End If
    '    ElseIf Asc(e.KeyChar) = Keys.Down Then
    '        If Value < Game.tileset.NumTiles Then
    '            Value += 1
    '            While itemY(Value) + itemH(Value) > scrollValue + h
    '                vs.Value += 1
    '            End While
    '        End If
    '    ElseIf Asc(e.KeyChar) = Keys.Home Then
    '        vs.Value = 0
    '        Value = 1
    '    ElseIf Asc(e.KeyChar) = Keys.End Then
    '        vs.Value = vs.Maximum
    '        Value = Game.tileset.NumTiles
    '    End If
    'End Sub

    Private Sub ensureSelVisible()
        If selIndex < 1 Then Return
        If selIndex > UBound(itemY) Then Return
        While itemY(selIndex) < scrollValue
            vs.Value -= 1
        End While
        While itemY(selIndex) + itemH(selIndex) > scrollValue + h
            vs.Value += 1
        End While
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Game Is Nothing Then Exit Sub
        Dim tmp As Integer = Value - curList.valueOffset
        Select Case e.KeyCode
            Case Keys.Up
                If tmp > 1 Then tmp -= 1
            Case Keys.Down
                If tmp < UBound(itemY) Then tmp += 1
            Case Keys.Home
                tmp = 1
            Case Keys.End
                tmp = UBound(itemY)
        End Select
        If tmp <> Value - curList.valueOffset Then
            SelIndices.Clear()
            SelIndices.Add(tmp + curList.valueOffset)
            Value = SelIndices(SelIndices.Count - 1)
        End If
    End Sub
End Class

#Region "CustomList"
Public MustInherit Class CustomList
    Protected ts As psTileSelector
    Sub New(ByVal tsel As psTileSelector)
        ts = tsel
    End Sub

#Region "Helper Functions"
    Sub setSubtilesVisible(ByVal value As Boolean)
        ts.setSubtilesVisible(value)
    End Sub

    Protected Property selIndex() As Integer
        Get
            Return ts.selIndex
        End Get
        Set(ByVal Value As Integer)
            ts.selIndex = Value
        End Set
    End Property

    Protected ReadOnly Property w() As Integer
        Get
            Return ts.w
        End Get
    End Property

    Protected ReadOnly Property h() As Integer
        Get
            Return ts.h
        End Get
    End Property

    Protected ReadOnly Property colors() As IColorScheme
        Get
            Return ts.colors
        End Get
    End Property

    Protected ReadOnly Property font() As font
        Get
            Return ts.Font
        End Get
    End Property

    Protected Property hoverIndex() As Integer
        Get
            Return ts.hoverIndex
        End Get
        Set(ByVal Value As Integer)
            ts.hoverIndex = Value
        End Set
    End Property

    Protected Property pressedIndex() As Integer
        Get
            Return ts.pressedIndex
        End Get
        Set(ByVal Value As Integer)
            ts.pressedIndex = Value
        End Set
    End Property

    Protected ReadOnly Property subtiles() As PictureBox
        Get
            Return ts.subtiles
        End Get
    End Property

    Protected Property itemY() As Integer()
        Get
            Return ts.itemY
        End Get
        Set(ByVal Value As Integer())
            ts.itemY = Value
        End Set
    End Property

    Protected ReadOnly Property itemH(ByVal index As Integer) As Integer
        Get
            Return ts.itemH(index)
        End Get
    End Property

    Protected ReadOnly Property scrollValue() As Integer
        Get
            Return ts.scrollValue
        End Get
    End Property

    Protected ReadOnly Property iml() As ImageList
        Get
            Return ts.iml
        End Get
    End Property

    Protected ReadOnly Property subtilesSize() As Size
        Get
            Return ts.subtilesSize
        End Get
    End Property
#End Region

    Public MustOverride Sub Draw(ByVal e As PaintEventArgs)
    Public MustOverride Function getContentHeight() As Integer
    Public MustOverride Sub updateSubtiles()
    Public MustOverride Sub onSelect()

    Public Overridable ReadOnly Property valueOffset() As Integer
        Get
            Return 0
        End Get
    End Property

    Protected Overridable ReadOnly Property iconSize() As Integer
        Get
            Return 32
        End Get
    End Property

    Protected Overridable ReadOnly Property defItemHeight() As Integer
        Get
            Return 32
        End Get
    End Property

    Protected Sub DrawItem(ByVal e As PaintEventArgs, ByVal i As Integer, ByVal name As String, ByVal itemRect As Rectangle, ByVal img As Image, Optional ByVal BackColor As Integer = 0, Optional ByVal ForeColor As Integer = 0, Optional ByVal Font As Font = Nothing)
        If Font Is Nothing Then Font = Me.font
        If ForeColor = 0 Then ForeColor = SystemColors.ControlText.ToArgb

        Dim b As Brush = Nothing
        Dim p As Pen = Nothing
        With e.Graphics
            If itemRect.Y > h Then Return

            Dim state As Byte = 0 '0-normal,1-checked,2-hover,3-pressed
            Dim selected As Boolean = ts.SelIndices.Contains(i)

            If selected Then
                state += 1
                subtiles.Left = (w - subtiles.Width) \ 2
                subtiles.Top = itemRect.Y + 32 + 1
                ts.tbpanel.Left = w - ts.tbpanel.Width - 1
                ts.tbpanel.Top = itemRect.Y + 1
            End If
            If hoverIndex = i Then state = 2
            If pressedIndex = i Then state = 3

            'Get rects
            Dim iconRect As New Rectangle(itemRect.X + 1, itemRect.Y + (defItemHeight - iconSize) \ 2 + 1, iconSize, iconSize)
            Dim backRect As Rectangle
            backRect = itemRect

            'Draw hover
            If state > 0 Then
                Select Case state
                    Case 1
                        b = New LinearGradientBrush(itemRect, colors.ToolbarCheck1, colors.ToolbarCheck2, LinearGradientMode.Vertical)
                        p = New Pen(colors.SelBorder)
                    Case 2
                        b = New LinearGradientBrush(itemRect, colors.ToolbarSel1, colors.ToolbarSel2, LinearGradientMode.Vertical)
                        p = New Pen(colors.SelBorder)
                    Case 3
                        b = New LinearGradientBrush(itemRect, colors.ToolbarPressed1, colors.ToolbarPressed2, LinearGradientMode.Vertical)
                        p = New Pen(colors.ToolbarPressedBorder)
                End Select
                .FillRectangle(b, backRect)
                .DrawRectangle(p, backRect)
                b.Dispose()
            End If
            If BackColor > 0 Then
                b = New SolidBrush(Color.FromArgb(BackColor))
                .FillRectangle(b, New Rectangle(backRect.X, backRect.Y, backRect.Width + 1, backRect.Height + 1))
                b.Dispose()
            End If

            Try
                'Draw icons
                If ts.DrawCustomIcons Then
                    ts.OnDrawIcon(e, i, iconRect)
                Else
                    Dim imgAttr As New Imaging.ImageAttributes
                    If state = 0 Then
                        imgAttr.SetColorMatrix(New Imaging.ColorMatrix(New Single()() _
                        {New Single() {0.65, 0.15, 0.15, 0, 0}, _
                         New Single() {0.295, 0.795, 0.295, 0, 0}, _
                         New Single() {0.055, 0.055, 0.555, 0, 0}, _
                         New Single() {0, 0, 0, 0.8, 0}, _
                         New Single() {0, 0, 0, 0, 1}}))
                    End If
                    .DrawImage(img, iconRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttr)
                    imgAttr.Dispose()
                End If
            Catch
            End Try

            'Icon border
            If selected Then
                .DrawRectangle(p, New Rectangle(iconRect.X, iconRect.Y, iconRect.Width - 1, iconRect.Height - 1))
            End If
            If state > 0 Then p.Dispose()

            'Draw labels
            b = New SolidBrush(Color.FromArgb(ForeColor))
            Dim sf As New StringFormat
            sf.LineAlignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisCharacter
            sf.FormatFlags = StringFormatFlags.NoWrap
            .DrawString(name, Font, b, New RectangleF(itemRect.X + iconSize + 4, itemRect.Y + 1, w - (iconSize + 6), defItemHeight - 1), sf)
            sf.Dispose()
            b.Dispose()
        End With
    End Sub
End Class
#End Region

#Region "TileList"
Public Class TileList
    Inherits CustomList

    Event ChangedSelPos(ByVal rect As Rectangle)

    Sub New(ByVal tsel As psTileSelector)
        MyBase.New(tsel)
    End Sub

    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'In Level Editor
        Dim start As Integer
        For i As Integer = 1 To UBound(itemY)
            If itemY(i) >= 0 Then
                start = i
                Exit For
            End If
        Next
        If start > 0 Then
            For i As Integer = start To UBound(itemY)
                Dim name As String = Game.tileset.tiles(i).name
                Dim itemRect As Rectangle = New Rectangle(0, itemY(i) - scrollValue, w - 1, itemH(i))
                DrawItem(e, i, name, itemRect, Game.Drawing.Tex(name).preview)
                If selIndex = i Then RaiseEvent ChangedSelPos(itemRect)
            Next
        End If
    End Sub

    Public Overrides Function getContentHeight() As Integer
        Dim temp As Integer = 0

        ReDim itemY(UBound(Game.tileset.tiles))
        For i As Integer = 1 To UBound(Game.tileset.tiles)
            itemY(i) = temp
            temp += (32 + 2)
            If selIndex = i Then
                temp += subtilesSize.Height
            End If
        Next

        Return temp
    End Function

    Public Overrides Sub UpdateSubtiles()
        ts.ResizeSubtiles()
        setSubtilesVisible(ts.subtilesVisible())
        subtiles.Invalidate()
    End Sub

    Public Overrides Sub onSelect()
        psEditor.CurTile = ts.Value
        If ts.Value = -1 Then
            psEditor.CurTile = 0
            Editor.pstools.Value = psTools.Tools.Select
        Else
            Editor.pstools.Value = psTools.Tools.Draw
        End If
    End Sub
End Class
#End Region

#Region "TileList2"
Public Class TileList2
    Inherits TileList

    Sub New(ByVal tsel As psTileSelector)
        MyBase.New(tsel)
    End Sub

    Public Overrides Function getContentHeight() As Integer
        Dim temp As Integer = 0

        ReDim itemY(UBound(Game.tileset.tiles))
        For i As Integer = 1 To UBound(Game.tileset.tiles)
            itemY(i) = temp
            temp += (32 + 2)
        Next

        Return temp
    End Function

    Public Overrides Sub UpdateSubtiles()
        setSubtilesVisible(False)
    End Sub

    Public Overrides Sub onSelect()
        '
    End Sub
End Class
#End Region

#Region "PathList"
Public Class PathList
    Inherits CustomList

    Private labels() As String = _
        {"", GetString("tileSelector_Path_EditPoints"), GetString("tileSelector_Path_Rectangle"), GetString("tileSelector_Path_RoundedRectangle"), _
        GetString("tileSelector_Path_Ellipse"), GetString("tileSelector_Path_Figure8"), GetString("tileSelector_Path_Cloverleaf"), GetString("tileSelector_Path_Erase")}

    Sub New(ByVal tsel As psTileSelector)
        MyBase.New(tsel)
    End Sub

    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For i As Integer = 1 To UBound(labels)
            DrawItem(e, i, labels(i), New Rectangle(0, (i - 1) * 33 - scrollvalue, w - 1, 32), iml.Images(i - 1))
        Next
    End Sub

    Public Overrides Function getContentHeight() As Integer
        ReDim itemY(UBound(labels))
        For i As Integer = 1 To UBound(itemy)
            itemY(i) = (i - 1) * 33
        Next
        Return UBound(itemy) * 33
    End Function

    Public Overrides Sub UpdateSubtiles()
        setSubtilesVisible(False)
    End Sub

    Public Overrides Sub onSelect()
        If selindex = 7 Then
            Editor.psedit.PathEdit.Clear()
            Editor.psedit.Refresh()
            ts.Value = 1
        ElseIf selindex > -1 Then
            Editor.psedit.PathEdit.ClickedPreset(selindex - 1)
        End If
    End Sub
End Class
#End Region

#Region "ControlList"
Public Class ControlList
    Inherits CustomList

    Private labels() As String = _
        {"", GetString("tileSelector_Controls_Pointer"), GetString("tileSelector_Controls_Button"), GetString("tileSelector_Controls_Label"), GetString("tileSelector_Controls_Image"), GetString("tileSelector_Controls_GameArea"), _
        GetString("tileSelector_Controls_TextCounter"), GetString("tileSelector_Controls_ImageTextCounter"), GetString("tileSelector_Controls_ImageCounter"), _
        GetString("tileSelector_Controls_HighScoresArea"), GetString("tileSelector_Controls_Movie")}

    Sub New(ByVal tsel As psTileSelector)
        MyBase.New(tsel)
    End Sub

    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For i As Integer = 1 To UBound(labels)
            DrawItem(e, i, labels(i), New Rectangle(0, (i - 1) * (defItemHeight + 1) - scrollvalue, w - 1, (defItemHeight)), iml.Images(i - 1))
        Next
    End Sub

    Public Overrides Function getContentHeight() As Integer
        ReDim itemY(UBound(labels))
        For i As Integer = 1 To UBound(itemy)
            itemY(i) = (i - 1) * (defItemHeight + 1)
        Next
        Return UBound(itemy) * (defItemHeight + 1)
    End Function

    Public Overrides Sub UpdateSubtiles()
        setSubtilesVisible(False)
    End Sub

    Public Overrides Sub onSelect()
        If Game Is Nothing Then Exit Sub
        If Editor.winedit Is Nothing Then Exit Sub
        If Editor.winedit.NumSelCtrls = 0 Then Exit Sub
        Editor.winedit.Deselect()
    End Sub

    Public Overrides ReadOnly Property valueOffset() As Integer
        Get
            Return -1
        End Get
    End Property

    Protected Overrides ReadOnly Property iconSize() As Integer
        Get
            Return 20
        End Get
    End Property

    Protected Overrides ReadOnly Property defItemHeight() As Integer
        Get
            Return 24
        End Get
    End Property
End Class
#End Region

#Region "ActionList"
Public Class ActionList
    Inherits CustomList

    Event Updated()

#Region "CustomListItem"
    Class CustomListItem
        Private al As ActionList
        Private _Text As String
        Private _Indent As Integer
        Private _ImageIndex As Integer = -1
        Private _ForeColor As Color = SystemColors.ControlText
        Private _Font As Font = Nothing
        Private _BackColor As Color
        Public Tag As String

        ReadOnly Property BackColor() As Color
            Get
                Return _BackColor
            End Get
        End Property

        Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal Value As String)
                _Text = Value
                al.EventRefresh()
            End Set
        End Property

        Property Indent() As Integer
            Get
                Return _Indent
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    Value = 0
                    _BackColor = Color.FromArgb(64, 128, 0, 0)
                Else
                    _BackColor = Color.Transparent
                End If
                _Indent = Value
                al.Refresh()
            End Set
        End Property

        Property ImageIndex() As Integer
            Get
                Return _ImageIndex
            End Get
            Set(ByVal Value As Integer)
                _ImageIndex = Value
                al.EventRefresh()
            End Set
        End Property

        Property ForeColor() As Color
            Get
                Return _ForeColor
            End Get
            Set(ByVal Value As Color)
                _ForeColor = Value
                al.Refresh()
            End Set
        End Property

        Property Font() As Font
            Get
                Return _Font
            End Get
            Set(ByVal Value As Font)
                _Font = Value
                al.Refresh()
            End Set
        End Property

        Sub New(ByVal al As ActionList, ByVal text As String)
            Me.al = al
            Me.Text = text
        End Sub
    End Class

    Class CustomListItemCollection
        Inherits ArrayList

        Overloads Sub Add(ByVal item As CustomListItem)
            MyBase.Add(item)
        End Sub

        Default Shadows Property Item(ByVal index As Integer) As CustomListItem
            Get
                If index < 0 OrElse index > Count - 1 Then Return Nothing
                Return MyBase.Item(index)
            End Get
            Set(ByVal Value As CustomListItem)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class
#End Region

    Private Const indentWidth As Integer = 32
    Private _items As New CustomListItemCollection

    Default Property Item(ByVal index As Integer) As CustomListItem
        Get
            Return _items(index)
        End Get
        Set(ByVal Value As CustomListItem)
            _items(index) = Value
            EventRefresh()
        End Set
    End Property

    Sub Clear()
        _items = New CustomListItemCollection
        EventRefresh()
    End Sub

    Function Add(ByVal text As String) As CustomListItem
        Dim tmp As CustomListItem = New CustomListItem(Me, text)
        _items.Add(tmp)
        EventRefresh()
        Return tmp
    End Function

    Sub Add(ByVal item As CustomListItem)
        _items.Add(item)
        EventRefresh()
    End Sub

    Sub RemoveAt(ByVal index As Integer)
        _items.RemoveAt(index)
        EventRefresh()
    End Sub

    Private Sub EventRefresh()
        RaiseEvent Updated()
        Refresh()
    End Sub

    Sub Refresh()
        ts.DoOnResize()
    End Sub

    ReadOnly Property Count() As Integer
        Get
            Return _items.Count
        End Get
    End Property

    Sub New(ByVal tsel As psTileSelector)
        MyBase.New(tsel)
    End Sub

    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For i As Integer = 0 To _items.Count - 1
            DrawItem(e, i + 1, _items(i).Text, New Rectangle(_items(i).Indent * indentWidth, (i) * (defItemHeight + 1) - scrollvalue, w - _items(i).Indent * indentWidth - 1, (defItemHeight)), iml.Images(_items(i).ImageIndex), _items(i).BackColor.ToArgb, _items(i).ForeColor.ToArgb, _items(i).Font)
        Next
    End Sub

    Public Overrides Function getContentHeight() As Integer
        ReDim itemY(_items.Count)
        For i As Integer = 1 To UBound(itemy)
            itemY(i) = (i - 1) * (defItemHeight + 1)
        Next
        Return UBound(itemy) * (defItemHeight + 1)
    End Function

    Public Overrides Sub UpdateSubtiles()
        setSubtilesVisible(False)
    End Sub

    Public Overrides Sub onSelect()
        '
    End Sub

    Public Overrides ReadOnly Property valueOffset() As Integer
        Get
            Return -1
        End Get
    End Property

    Protected Overrides ReadOnly Property iconSize() As Integer
        Get
            Return 24
        End Get
    End Property

    Protected Overrides ReadOnly Property defItemHeight() As Integer
        Get
            Return 27
        End Get
    End Property
End Class
#End Region

#Region "DoubleBufferedPictureBox"
Public Class DoubleBufferedPictureBox
    Inherits PictureBox

    Sub New()
        MyBase.New()
        setstyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub
End Class
#End Region