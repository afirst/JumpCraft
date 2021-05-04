Public Class psTileSelector
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        BackColor = UIPlus.DefaultColorScheme.getInstance.MenuBack
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
    Public WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Public WithEvents list As System.Windows.Forms.ListView
    Public WithEvents iml2 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psTileSelector))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.list = New System.Windows.Forms.ListView
        Me.Label1 = New System.Windows.Forms.Label
        Me.iml2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml.ImageSize = New System.Drawing.Size(32, 32)
        Me.iml.TransparentColor = System.Drawing.Color.Black
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 120
        '
        'list
        '
        Me.list.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.FullRowSelect = True
        Me.list.HideSelection = False
        Me.list.LargeImageList = Me.iml
        Me.list.Location = New System.Drawing.Point(0, 20)
        Me.list.MultiSelect = False
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(168, 196)
        Me.list.SmallImageList = Me.iml
        Me.list.StateImageList = Me.iml
        Me.list.TabIndex = 4
        Me.list.View = System.Windows.Forms.View.SmallIcon
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tiles"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'iml2
        '
        Me.iml2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml2.ImageSize = New System.Drawing.Size(32, 32)
        Me.iml2.ImageStream = CType(resources.GetObject("iml2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml2.TransparentColor = System.Drawing.Color.White
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 216)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(168, 120)
        Me.Panel1.TabIndex = 10
        Me.Panel1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(168, 120)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'psTileSelector
        '
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "psTileSelector"
        Me.Size = New System.Drawing.Size(168, 336)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oImage As Image, xg1 As Graphics
    Dim NoResizePreview As Boolean
    Public SelSubIndex As Integer = 1
    Public SelWidth As Integer = 1
    Public SelHeight As Integer = 1
    Dim Hover As Point = New Point(-1000000, -1000000)

    Sub UpdateList()
        If Not (Game.psedit.PathEdit Is Nothing) Then
            If Game.psedit.PathEdit.Editing Then
                Label1.Text = "Toolbox"
                list.SmallImageList = iml2
                With list.Items
                    .Clear()
                    .Add("Edit Points").ImageIndex = 0
                    .Add("Rectangle").ImageIndex = 1
                    .Add("Rounded Rectangle").ImageIndex = 2
                    .Add("Ellipse").ImageIndex = 3
                    .Add("Figure 8").ImageIndex = 4
                    .Add("Clover Leaf").ImageIndex = 5
                    .Add("Clear").ImageIndex = 6
                End With
                Panel1.Visible = False
                Exit Sub
            Else
                Panel1.Visible = True
            End If
        End If

        Label1.Text = "Tiles"
        list.SmallImageList = iml

        Dim i As Integer, tmp As Integer

        'Store current item
        tmp = Value

        'Clear list and images
        list.Items.Clear()
        iml.Images.Clear()

        'Reload
        UpdateImages()
        list.Visible = False
        For i = 1 To Game.tileset.NumTiles
            'iml.Images.Add(New Bitmap(game.tileset.tiles(i).filename))
            list.Items.Add(Game.tileset.tiles(i).name, list.Items.Count)
        Next
        list.Visible = True

        'Reselect current item, or the first item
        If tmp >= 0 And tmp <= list.Items.Count - 1 Then
            list.Items(tmp).Selected = True
        Else
            If list.Items.Count > 0 Then list.Items(0).Selected = True
        End If
        list.Select()

        If Not (Game.psproperties Is Nothing) Then Game.psproperties.cboTiles.Refresh()
    End Sub

    Sub UpdateImages()
        Dim i As Integer
        With iml
            .Images.Clear()
            For i = 1 To Game.tileset.NumTiles
                .Images.Add(Game.tileset.tilePreview(i))
            Next
        End With
    End Sub

    Property Value() As Integer
        Get
            Try
                Value = list.SelectedIndices(0) + 1
            Catch
                Value = 0
            End Try
        End Get
        Set(ByVal Value As Integer)
            If Value > list.Items.Count - 1 Then Exit Property
            list.Items(Value).Selected = True
        End Set
    End Property

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Game.pstileselect = Me 'Register control
        Panel1_Resize(Nothing, Nothing)
    End Sub

    Private Sub list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.SelectedIndexChanged
        If Not (Game.psedit.PathEdit Is Nothing) Then
            If Game.psedit.PathEdit.Editing Then
                If list.SelectedIndices.Count = 0 Then
                ElseIf list.SelectedIndices(0) = 6 Then
                    Game.psedit.PathEdit.Clear()
                    Game.psedit.Refresh()
                    list.Items(0).Selected = True
                Else
                    Game.psedit.PathEdit.ClickedPreset(list.SelectedIndices(0))
                End If
                Exit Sub
            End If
        End If

        Game.psedit.Deselect()
        psEditor.CurTile = Value
        If list.SelectedIndices.Count = 0 Then
            Game.pstools.Value = 1
            Panel1.Visible = False
        Else
            Game.pstools.Value = 0
            SelSubIndex = 1
            SelWidth = 1
            SelHeight = 1
            With Game.tileset.tiles(list.SelectedIndices(0) + 1)
                If .Anim(0).Interval > 0 Or _
                (.width = .sectionw And .height = .sectionh) Then
                    Panel1.Visible = False
                ElseIf Not NoResizePreview Then
                    NoResizePreview = True
                    If Panel1.Width < 32 Then Panel1.Width = 32
                    With Game.tileset.tileBitmap(list.SelectedIndices(0) + 1)
                        PictureBox1.Width = Math.Min(.Width, Panel1.Width)
                    End With
                    Dim tmpHeight As Integer = PictureBox1.Width * Game.tileset.tileBitmap(list.SelectedIndices(0) + 1).Height \ Game.tileset.tileBitmap(list.SelectedIndices(0) + 1).Width
                    Dim MaxHeight As Integer = (Height - Label1.Height) * 0.5
                    If tmpHeight > MaxHeight Then tmpHeight = MaxHeight
                    Panel1.Height = tmpHeight
                    PictureBox1.Height = tmpHeight
                    Panel1.Visible = True
                    NoResizePreview = False

                    'AutoRedraw
                    oImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    xg1 = Graphics.FromImage(oImage)
                    PictureBox1.Image = oImage
                End If
            End With
            RefreshPreview()
        End If
    End Sub

    Dim NoPaint As Boolean
    Sub RefreshPreview()
        If NoPaint Then Exit Sub
        If xg1 Is Nothing Then Exit Sub
        If Not (Game.psedit.PathEdit Is Nothing) Then
            If Game.psedit.PathEdit.Editing Then
                Exit Sub
            End If
        End If
        xg1.Clear(PictureBox1.BackColor)
        If Value = 0 Then
            PictureBox1.Refresh()
            Panel1.Visible = False
            Exit Sub
        End If
        If Game.pstools.Value = 1 Then
            PictureBox1.Refresh()
            Panel1.Visible = False
            Exit Sub
        End If
        xg1.DrawImage(Game.tileset.tileBitmap(list.SelectedIndices(0) + 1), New Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height))
        Dim tmpRect As Rectangle = CurRect(Game.tileset.tiles(list.SelectedIndices(0) + 1), SelSubIndex)
        tmpRect.X *= (PictureBox1.Width / Game.tileset.tiles(list.SelectedIndices(0) + 1).width)
        tmpRect.Y *= (PictureBox1.Height / Game.tileset.tiles(list.SelectedIndices(0) + 1).height)
        tmpRect.Width = CellW * SelWidth
        tmpRect.Height = CellH * SelHeight
        xg1.FillRectangle(New Pen(Color.FromArgb(64, 0, 0, 255)).Brush, tmpRect)
        xg1.DrawRectangle(New Pen(Color.FromArgb(128, 255, 192, 128)), tmpRect)
        xg1.FillRectangle(New Pen(Color.FromArgb(64, 0, 0, 255)).Brush, New Rectangle(Hover.X, Hover.Y, CellW, CellH))
        xg1.DrawRectangle(New Pen(Color.FromArgb(64, 255, 192, 128)), New Rectangle(Hover.X, Hover.Y, CellW, CellH))
        PictureBox1.Refresh()
    End Sub

    Private Sub list_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.Click
        list_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub Panel1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Resize
        If Game Is Nothing Then Exit Sub
        Timer1.Enabled = True
    End Sub

    Function GetCellFromXY(ByVal x As Integer, ByVal y As Integer)
        Dim CellsX As Integer, CellX As Integer, CellY As Integer
        With Game.tileset.tiles(list.SelectedIndices(0) + 1)
            CellsX = .width / .sectionw
            CellX = Int(x / CellW) + 1
            CellY = Int(y / CellH) + 1
            Return (CellY - 1) * CellsX + CellX
        End With
    End Function

    ReadOnly Property CellW() As Single
        Get
            With Game.tileset.tiles(list.SelectedIndices(0) + 1)
                Return PictureBox1.Width / (.width / .sectionw)
            End With
        End Get
    End Property

    ReadOnly Property CellH() As Single
        Get
            With Game.tileset.tiles(list.SelectedIndices(0) + 1)
                Return PictureBox1.Height / (.height / .sectionh)
            End With
        End Get
    End Property

    Dim SelPt As Point

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Try
            SelSubIndex = GetCellFromXY(e.X, e.Y)
            SelPt = New Point(Int(e.X / CellW) * CellW, _
                              Int(e.Y / CellH) * CellH)
            SelWidth = 1
            SelHeight = 1
            RefreshPreview()
        Catch
            SelSubIndex = 1
            SelWidth = 1
            SelHeight = 1
        End Try
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Try
            Hover = New Point(Int(e.X / CellW) * CellW, _
                              Int(e.Y / CellH) * CellH)

            'Select multiple tiles
            If e.Button = MouseButtons.Left Then
                SelWidth = (Hover.X - SelPt.X) \ CellW + 1
                SelHeight = (Hover.Y - SelPt.Y) \ CellH + 1
                If SelWidth < 1 Then SelWidth = 1
                If SelHeight < 1 Then SelHeight = 1
                If SelPt.X + SelWidth * CellW > PictureBox1.Width Then SelWidth = (PictureBox1.Width - SelPt.X) \ CellW
                If SelPt.Y + SelHeight * CellH > PictureBox1.Height Then SelHeight = (PictureBox1.Height - SelPt.Y) \ CellH
            End If

            RefreshPreview()
        Catch
        End Try
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Hover = New Point(-1000000, -1000000)
        RefreshPreview()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        'AutoRedraw
        oImage = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        xg1 = Graphics.FromImage(oImage)
        PictureBox1.Image = oImage

        If NoResizePreview = False Then
            list_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Public Property TitleBarVisible() As Boolean
        Get
            Return Label1.Visible
        End Get
        Set(ByVal Value As Boolean)
            Label1.Visible = Value
        End Set
    End Property
End Class