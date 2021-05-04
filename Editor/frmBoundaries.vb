Imports System.ComponentModel
Imports PlatformStudio

Public Class frmBoundaries
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents hs As System.Windows.Forms.HScrollBar
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents vs As System.Windows.Forms.VScrollBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pic As DoubleBufferedPictureBox
    Friend WithEvents prop As System.Windows.Forms.PropertyGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoundaries))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.vs = New System.Windows.Forms.VScrollBar
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.hs = New System.Windows.Forms.HScrollBar
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.pic = New DoubleBufferedPictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.prop = New System.Windows.Forms.PropertyGrid
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 16)
        Me.Label1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.vs)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pic)
        Me.Panel1.Location = New System.Drawing.Point(12, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(272, 272)
        Me.Panel1.TabIndex = 1
        '
        'vs
        '
        Me.vs.Dock = System.Windows.Forms.DockStyle.Right
        Me.vs.Enabled = False
        Me.vs.LargeChange = 1
        Me.vs.Location = New System.Drawing.Point(256, 0)
        Me.vs.Name = "vs"
        Me.vs.Size = New System.Drawing.Size(16, 256)
        Me.vs.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.hs)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(272, 16)
        Me.Panel2.TabIndex = 3
        '
        'hs
        '
        Me.hs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hs.Enabled = False
        Me.hs.LargeChange = 1
        Me.hs.Location = New System.Drawing.Point(0, 0)
        Me.hs.Name = "hs"
        Me.hs.Size = New System.Drawing.Size(256, 16)
        Me.hs.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Location = New System.Drawing.Point(256, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'pic
        '
        Me.pic.BackColor = System.Drawing.SystemColors.Window
        Me.pic.Location = New System.Drawing.Point(0, 0)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(256, 256)
        Me.pic.TabIndex = 2
        Me.pic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(416, 304)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 23)
        Me.Button1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(344, 304)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 2
        '
        'prop
        '
        Me.prop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prop.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.prop.Location = New System.Drawing.Point(296, 24)
        Me.prop.Name = "prop"
        Me.prop.Size = New System.Drawing.Size(184, 272)
        Me.prop.TabIndex = 3
        Me.prop.ToolbarVisible = False
        '
        'frmBoundaries
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 334)
        Me.Controls.Add(Me.prop)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBoundaries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "General Instance Variables"
    Private curTile As psTile
    Private bmp As Bitmap
    Private numFrames As Integer
    Private options As BoundaryOptions
#End Region

#Region "Loading"
    Dim WithEvents ms As New psMoveSize(True)

    Private Function getCurTile() As psTile
        Return curTile
    End Function

    Private Sub frmBoundaries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = GetString("boundaries_SelectedTileLabel")
        Me.Button1.Text = GetString("okButton")
        Me.Button2.Text = GetString("cancelButton")
        Me.Text = GetString("boundaries_Title")
        PropGridEx.setColumnWidth(prop, 0.55)
        frmBoundaries_Resize(Nothing, Nothing)
    End Sub

    Overloads Function ShowDialog(ByRef tile As psTile) As DialogResult
        curTile = tile
        If Not curTile.Boundaries.shapes Is Nothing Then
            curTile.Boundaries.shapes = tile.Boundaries.shapes.Clone
            For i As Integer = 1 To curTile.Boundaries.shapes.Length - 1
                curTile.Boundaries.shapes(i) = tile.Boundaries.shapes(i).Clone
            Next
        End If

        bmp = Game.Drawing.Tex(curTile.name).bmp

        'Setup frame choices
        numFrames = (tile.width \ tile.sectionw) * _
              (tile.height \ tile.sectionh)
        ConverterVariables.maxFrame = numFrames
        If curTile.Boundaries.shapes Is Nothing Then
            RedimShapes(numFrames, 0)
        End If

        'Set up PropertyGrid
        options = New BoundaryOptions(Me)
        options.Type = curTile.Boundaries.Style
        prop.SelectedObject = New PropDispNameWrapper(options)

        'Setup MoveSize
        ms.SetPictureBox(pic)
        ms.MapEditorCoordinates = False
        ms.GridX = options.getZoom
        ms.GridY = options.getZoom

        'Show the dialog
        pic.Invalidate()
        Dim dr As DialogResult
        dr = ShowDialog()
        If dr = DialogResult.OK Then
            curTile.Boundaries.Style = options.Type
            tile = curTile
        End If
        Return dr
    End Function
#End Region

#Region "Drawing"
    Private Sub pic_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pic.Paint
        With e.Graphics
            .Clear(pic.BackColor)
            .InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            .CompositingMode = Drawing2D.CompositingMode.SourceCopy

            For i As Integer = 0 To (options.getZoom + 0.5) \ 2 Step Math.Max((options.getZoom + 0.5) \ 2, 1)
                For j As Integer = 0 To (options.getZoom + 0.5) \ 2 Step Math.Max((options.getZoom + 0.5) \ 2, 1)
                    .DrawImage(bmp, New Rectangle(i, j, curTile.sectionw * options.getZoom, curTile.sectionh * options.getZoom), ScaleRect(CurRect(curTile, options.curFrame), 1 / curTile.ScaleX, 1 / curTile.ScaleY), System.Drawing.GraphicsUnit.Pixel)
                Next
            Next

            .CompositingMode = Drawing2D.CompositingMode.SourceOver

            'Draw points
            If MDown Then
                If pt1.X <> pt2.X Or pt1.Y <> pt2.Y Then
                    DrawShape(e.Graphics, CreateShape(pt1.X, pt1.Y, pt2.X, pt2.Y))
                End If
            End If

            For i As Integer = 1 To UBound(curTile.Boundaries.shapes(curFrame))
                If options.Tool = BoundaryOptions.Tools.Erase AndAlso i = mouseShape Then
                    DrawShape(e.Graphics, curTile.Boundaries.shapes(curFrame)(i), True)
                Else
                    DrawShape(e.Graphics, curTile.Boundaries.shapes(curFrame)(i))
                End If
            Next

            If ms.Enabled Then
                ms.Draw(e.Graphics)
            End If
        End With
    End Sub

    Private Sub DrawShape(ByVal g As Graphics, ByVal s As psBoundaryShape, Optional ByVal eraseMouseOver As Boolean = False)
        Dim b As New SolidBrush(Color.FromArgb(128, 0, 0, 255))
        Dim p As New Pen(Color.FromArgb(128, 255, 192, 128))
        If eraseMouseOver Then
            b.Color = Color.FromArgb(128, 0, 0, 0)
            p.Color = Color.FromArgb(128, 192, 192, 192)
        End If
        s.r.X *= options.getZoom
        s.r.Y *= options.getZoom
        s.r.Width *= options.getZoom
        s.r.Height *= options.getZoom
        Select Case s.s
            Case BoundaryShape.Rectangle
                g.FillRectangle(b, s.r)
                g.DrawRectangle(p, s.r)
            Case BoundaryShape.Circle
                g.FillEllipse(b, s.r)
                g.DrawEllipse(p, s.r)
            Case BoundaryShape.Triangle1
                Dim pts() As Point = New Point() _
                    {New Point(s.r.X, s.r.Y), New Point(s.r.X, s.r.Bottom), New Point(s.r.Right, s.r.Bottom)}
                g.FillPolygon(b, pts)
                g.DrawPolygon(p, pts)
            Case BoundaryShape.Triangle2
                Dim pts() As Point = New Point() _
                    {New Point(s.r.Right, s.r.Y), New Point(s.r.Right, s.r.Bottom), New Point(s.r.X, s.r.Bottom)}
                g.FillPolygon(b, pts)
                g.DrawPolygon(p, pts)
            Case BoundaryShape.Triangle3
                Dim pts() As Point = New Point() _
                    {New Point(s.r.X, s.r.Y), New Point(s.r.Right, s.r.Y), New Point(s.r.Right, s.r.Bottom)}
                g.FillPolygon(b, pts)
                g.DrawPolygon(p, pts)
            Case BoundaryShape.Triangle4
                Dim pts() As Point = New Point() _
                    {New Point(s.r.Right, s.r.Y), New Point(s.r.X, s.r.Y), New Point(s.r.X, s.r.Bottom)}
                g.FillPolygon(b, pts)
                g.DrawPolygon(p, pts)
        End Select
        b.Dispose()
        p.Dispose()
    End Sub
#End Region

#Region "Properties"
    Class BoundaryOptions
        Private fbound As frmBoundaries

        Sub New(ByVal f As frmBoundaries)
            fbound = f
        End Sub

        Private _zoom As String = GetString("boundaries_AutoZoomSetting")

        <Category("View"), _
         Description("The zoom for the current view as a percent of the default size."), _
         TypeConverter(GetType(ZoomConverter))> _
        Property Zoom() As String
            Get
                Return _zoom
            End Get
            Set(ByVal Value As String)
                _zoom = Value
                fbound.ms.GridX = getZoom()
                fbound.ms.GridY = getZoom()
                If fbound.MSel Then fbound.SetMSRect()
                fbound.frmBoundaries_Resize(Nothing, Nothing)
            End Set
        End Property

        Function getZoom() As Double
            If _zoom = GetString("boundaries_AutoZoomSetting") Then
                Dim wscale As Double = fbound.pic.Width / fbound.getCurTile.sectionw
                Dim hscale As Double = fbound.pic.Height / fbound.getCurTile.sectionh
                Return Math.Min(wscale, hscale)
            Else
                Return CDbl(_zoom.Trim("%")) / 100
            End If
        End Function

        Private _gridSpacing As Integer = Game.tileW \ 2

        <Category("View"), _
         Description("The size of the grid in pixels."), _
         DisplayName("Grid spacing")> _
        Property GridSpacing() As Integer
            Get
                Return _gridSpacing
            End Get
            Set(ByVal Value As Integer)
                If Value < 1 Or Value > 256 Then Throw New ArgumentException
                _gridSpacing = Value
            End Set
        End Property

        Private _curFrame As Integer = 1

        <Category("View"), _
         Description("The current frame to view."), _
         DisplayName("Current frame"), _
         TypeConverter(GetType(FrameConverter))> _
        Property curFrame() As String
            Get
                Return _curFrame
            End Get
            Set(ByVal Value As String)
                If Value < 0 Or Value > fbound.numFrames Then Throw New ArgumentException
                _curFrame = Value
                fbound.Deselect()
                fbound.pic.Invalidate()
            End Set
        End Property

        Private _type As BoundaryType

        <Category("Boundary Options"), _
         Description("Type of boundary for the current tile."), _
         DisplayName("Boundary type")> _
        Property Type() As BoundaryType
            Get
                Return _type
            End Get
            Set(ByVal Value As BoundaryType)
                Dim oldValue As BoundaryType = _type
                _type = Value
                If _type = BoundaryType.Custom Then
                    If fbound.getCurTile.Anim(0).Interval > 0 Then
                        _type = BoundaryType.OneCustom
                        MessageBox.Show(GetString("boundaries_AnimatedTileErrorMessage"), GetString("boundaries_Title"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                Select Case _type
                    Case BoundaryType.Default
                        fbound.RedimShapes(fbound.numFrames, 0)
                    Case BoundaryType.Rectangular
                        fbound.RedimShapes(fbound.numFrames, 0)
                        fbound.AddShape(New psBoundaryShape(0, 0, fbound.getCurTile.sectionw, fbound.getCurTile.sectionh, BoundaryShape.Rectangle))
                    Case BoundaryType.OneCustom
                        fbound.RedimPreserveShapes(1, 0)
                End Select
                If _type = BoundaryType.Custom Or Type = BoundaryType.OneCustom Then
                    If oldValue = BoundaryType.Rectangular Then
                        fbound.RedimShapes(fbound.numFrames, 0)
                    Else
                        fbound.RedimPreserveShapes(fbound.numFrames, 0)
                    End If
                End If
                DynamicReadOnly.SetValue("Tools", _
                    Type = BoundaryType.Default Or Type = BoundaryType.Rectangular)
                fbound.prop.Refresh()
                fbound.mouseShape = 0
                fbound.Deselect()
                fbound.pic.Invalidate()
            End Set
        End Property

        Enum Tools
            Rectangle
            Circle
            Triangle1
            Triangle2
            Triangle3
            Triangle4
            [Erase]
        End Enum
        Private _tool As Tools

        <Category("Editor"), _
         Description("Current tool. Can only be set if Type is OneCustom or Custom."), _
         DynamicReadOnly("Tools")> _
        Property Tool() As Tools
            Get
                Return _tool
            End Get
            Set(ByVal Value As Tools)
                _tool = Value
                fbound.Deselect()
                fbound.pic.Invalidate()
            End Set
        End Property
    End Class

    Class ZoomConverter
        Inherits ChoicesConverter

        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
            Return New StandardValuesCollection( _
                New String() {GetString("boundaries_AutoZoomSetting"), "100%", "200%", "400%", "800%", "1600%"})
        End Function
    End Class
#End Region

#Region "Resize and Scroll"
    Private Sub frmBoundaries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If options Is Nothing Then Return
        If options.Zoom = GetString("boundaries_AutoZoomSetting") Then
            Dim targetW As Integer = Panel1.Width - vs.Width
            Dim targetH As Integer = Panel1.Height - hs.Height
            If curTile.sectionw / curTile.sectionh > targetW / targetH Then
                pic.Size = New Size(targetW, _
                                    targetW * curTile.sectionh / curTile.sectionw)
            Else
                pic.Size = New Size(targetH * curTile.sectionw / curTile.sectionh, _
                                    targetH)
            End If
            hs.Maximum = 0
            vs.Maximum = 0
            hs.Enabled = False
            vs.Enabled = False
            ms.GridX = options.getZoom
            ms.GridY = options.getZoom
            If MSel Then SetMSRect()
        Else
            pic.Width = curTile.sectionw * options.getZoom
            pic.Height = curTile.sectionh * options.getZoom
            Dim clipW As Integer = pic.Width - Panel1.Width + vs.Width
            Dim clipH As Integer = pic.Height - Panel1.Height + hs.Height
            If clipW > 0 Then
                hs.Maximum = Math.Ceiling(clipW / 16.0)
                hs.Enabled = True
            Else
                hs.Maximum = 0
                hs.Enabled = False
            End If
            If clipH > 0 Then
                vs.Maximum = Math.Ceiling(clipH / 16.0)
                vs.Enabled = True
            Else
                hs.Maximum = 0
                vs.Enabled = False
            End If
        End If
        hs_Scroll(Nothing, Nothing)
        vs_Scroll(Nothing, Nothing)
        pic.Invalidate()
    End Sub

    Private Sub hs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hs.Scroll
        pic.Left = -hs.Value * 16
    End Sub

    Private Sub vs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vs.Scroll
        pic.Top = -vs.Value * 16
    End Sub
#End Region

#Region "Mouse"
    Dim MDown As Boolean
    Dim MSel As Boolean
    Dim MSelDown As Boolean
    Dim pt1, pt2 As Point
    Dim mouse As Point
    Dim mouseShape As Integer

    Private Sub pic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic.MouseDown
        If options.Type = BoundaryType.Default Or options.Type = BoundaryType.Rectangular Then Return
        If MSel AndAlso ms.CollideWithHandle > -1 Then Return
        mouseShape = GetCollisionShape(e.X \ options.getZoom, e.Y \ options.getZoom)
        If options.Tool < BoundaryOptions.Tools.Erase Then
            If mouseShape > 0 Then
                MSel = True
                MSelDown = True
                pt1 = New Point(e.X \ options.getZoom, e.Y \ options.getZoom)
                SetMSRect()
                ms.Enable()
                pic.Invalidate()
            Else
                MDown = True
                Deselect()
                pt1 = ScalePoint(New Point(e.X, e.Y))
                pt2 = pt1
                pic.Invalidate()
            End If
        Else
            Deselect()
            If mouseShape > 0 Then
                RemoveShape(mouseShape)
                mouseShape = 0
                pic.Invalidate()
            End If
        End If
    End Sub

    Private Sub pic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic.MouseMove
        If Not MSel Then
            If Not pic.Cursor.Equals(Cursors.Default) Then pic.Cursor = Cursors.Default
        End If
        If options.Type = BoundaryType.Default Or options.Type = BoundaryType.Rectangular Then Return
        mouse = ScalePoint(New Point(e.X, e.Y))
        If options.Tool = BoundaryOptions.Tools.Erase Then
            mouseShape = GetCollisionShape(e.X \ options.getZoom, e.Y \ options.getZoom)
            pic.Invalidate()
        ElseIf MDown Then
            pt2 = mouse
            pic.Invalidate()
        ElseIf MSel Then
            If Not ms.isDraggingHandle Then
                If Not MSelDown Then
                    If Not ms.CurCursor Is Cursors.Default Then
                        pic.Cursor = ms.CurCursor
                    ElseIf GetCollisionShape(e.X \ options.getZoom, e.Y \ options.getZoom) > 0 Then
                        pic.Cursor = Cursors.SizeAll
                    Else
                        pic.Cursor = ms.CurCursor
                    End If
                Else
                    With curTile.Boundaries.shapes(curFrame)(mouseShape)
                        .r.X += (e.X \ options.getZoom - pt1.X)
                        .r.Y += (e.Y \ options.getZoom - pt1.Y)
                        While .r.X + .r.Width <= 0
                            .r.X += 1
                        End While
                        While .r.Y + .r.Height <= 0
                            .r.Y += 1
                        End While
                        While .r.X >= curTile.sectionw
                            .r.X -= 1
                        End While
                        While .r.Y >= curTile.sectionh
                            .r.Y -= 1
                        End While
                    End With
                    pt1 = New Point(e.X \ options.getZoom, e.Y \ options.getZoom)
                    SetMSRect()
                End If
            End If
            pic.Invalidate()
        End If
    End Sub

    Private Sub pic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic.MouseUp
        If MDown Then
            MDown = False
            If pt1.X <> pt2.X Or pt1.Y <> pt2.Y Then
                AddShape(CreateShape(pt1.X, pt1.Y, pt2.X, pt2.Y))
            End If
            pic.Invalidate()
        ElseIf MSel Then
            MSelDown = False
        End If
    End Sub

    Private Sub pic_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic.MouseLeave
        If Not MSel Then
            mouseShape = 0
            pic.Invalidate()
        End If
    End Sub

    Private Sub frmBoundaries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MSel Then
                RemoveShape(mouseShape)
                Deselect()
                pic.Cursor = Cursors.Default
                pic.Invalidate()
            End If
        End If
    End Sub

    Private Sub ms_Resize() Handles ms.Resize
        ms.Sync(curTile.Boundaries.shapes(curFrame)(mouseShape).r)
        With curTile.Boundaries.shapes(curFrame)(mouseShape).r
            .X /= options.getZoom
            .Y /= options.getZoom
            .Width /= options.getZoom
            .Height /= options.getZoom
        End With
        pic.Invalidate()
    End Sub

    Private Function ScalePoint(ByVal pt As Point) As Point
        pt.X /= options.getZoom
        pt.Y /= options.getZoom
        pt.X = ((pt.X + options.GridSpacing \ 2) \ options.GridSpacing) * options.GridSpacing
        pt.Y = ((pt.Y + options.GridSpacing \ 2) \ options.GridSpacing) * options.GridSpacing
        Return pt
    End Function

    Sub Deselect()
        If MSel Then
            MSel = False
            ms.Disable()
        End If
    End Sub

    Sub SetMSRect()
        Dim tmpR As Rectangle = curTile.Boundaries.shapes(curFrame)(mouseShape).r
        tmpR.X *= options.getZoom
        tmpR.Y *= options.getZoom
        tmpR.Width *= options.getZoom
        tmpR.Height *= options.getZoom
        ms.SetRect(tmpR)
    End Sub
#End Region

#Region "Math & Helper Functions"
    Private Sub AddShape(ByVal s As psBoundaryShape)
        ReDim Preserve curTile.Boundaries.shapes(curFrame)(UBound(curTile.Boundaries.shapes(curFrame)) + 1)
        curTile.Boundaries.shapes(curFrame)(UBound(curTile.Boundaries.shapes(curFrame))) = s
    End Sub

    Private Sub RemoveShape(ByVal index As Integer)
        For i As Integer = index To UBound(curTile.Boundaries.shapes(curFrame)) - 1
            curTile.Boundaries.shapes(curFrame)(i) = curTile.Boundaries.shapes(curFrame)(i + 1)
        Next
        ReDim Preserve curTile.Boundaries.shapes(curFrame)(UBound(curTile.Boundaries.shapes(curFrame)) - 1)
    End Sub

    Private Function GetCollisionShape(ByVal x As Integer, ByVal y As Integer) As Integer
        For i As Integer = 1 To UBound(curTile.Boundaries.shapes(curFrame))
            With curTile.Boundaries
                Dim r As Rectangle = .shapes(curFrame)(i).r
                If Game.Math.Collide_PtBox(x, y, r.X, r.Y, r.Width - 1, r.Height - 1) Then
                    Return i
                End If
            End With
        Next
        Return 0
    End Function

    Private Function CreateShape(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As psBoundaryShape
        Dim nx1, ny1, nx2, ny2 As Integer
        If x1 > x2 Then
            nx1 = x2
            nx2 = x1
        Else
            nx1 = x1
            nx2 = x2
        End If
        If y1 > y2 Then
            ny1 = y2
            ny2 = y1
        Else
            ny1 = y1
            ny2 = y2
        End If
        Return New psBoundaryShape(nx1, ny1, nx2, ny2, options.Tool)
    End Function

    Private ReadOnly Property curFrame() As Integer
        Get
            If options.Type = BoundaryType.Custom Then
                Return options.curFrame
            Else
                Return 1
            End If
        End Get
    End Property

    Sub RedimShapes(ByVal d1 As Integer, ByVal d2 As Integer)
        ReDim curTile.Boundaries.shapes(d1)
        For i As Integer = 1 To d1
            ReDim curTile.Boundaries.shapes(i)(d2)
        Next
    End Sub

    Sub RedimPreserveShapes(ByVal d1 As Integer, ByVal d2 As Integer)
        ReDim Preserve curTile.Boundaries.shapes(d1)
        For i As Integer = 1 To d1
            If curTile.Boundaries.shapes(i) Is Nothing Then
                ReDim Preserve curTile.Boundaries.shapes(i)(d2)
            End If
        Next
    End Sub
#End Region

End Class