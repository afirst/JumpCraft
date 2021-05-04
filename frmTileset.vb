Public Class frmTileset
    Inherits System.Windows.Forms.Form

    Dim NoUpdate As Boolean

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
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents list As System.Windows.Forms.ListView
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents picColor As System.Windows.Forms.PictureBox
    Friend WithEvents cboBehavior As System.Windows.Forms.ComboBox
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSecW As System.Windows.Forms.ComboBox
    Friend WithEvents cboSecH As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTileset))
        Me.list = New System.Windows.Forms.ListView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSecH = New System.Windows.Forms.ComboBox()
        Me.cboSecW = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboBehavior = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.picColor = New System.Windows.Forms.PictureBox()
        Me.txtWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'list
        '
        Me.list.FullRowSelect = True
        Me.list.HideSelection = False
        Me.list.Location = New System.Drawing.Point(8, 24)
        Me.list.MultiSelect = False
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(168, 288)
        Me.list.SmallImageList = Me.iml
        Me.list.TabIndex = 0
        Me.list.View = System.Windows.Forms.View.SmallIcon
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(32, 32)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Images"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(232, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Properties"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSecH, Me.cboSecW, Me.Label10, Me.Label9, Me.picPreview, Me.Label8, Me.cboBehavior, Me.Label7, Me.picColor, Me.txtWidth, Me.Label5, Me.Button1, Me.Label4, Me.txtName, Me.Label3, Me.txtHeight, Me.Label6})
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(232, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 326)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cboSecH
        '
        Me.cboSecH.DisplayMember = "1"
        Me.cboSecH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSecH.Items.AddRange(New Object() {"Background", "Character", "Collectable", "Solid"})
        Me.cboSecH.Location = New System.Drawing.Point(64, 144)
        Me.cboSecH.Name = "cboSecH"
        Me.cboSecH.Size = New System.Drawing.Size(48, 21)
        Me.cboSecH.TabIndex = 19
        '
        'cboSecW
        '
        Me.cboSecW.DisplayMember = "1"
        Me.cboSecW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSecW.Items.AddRange(New Object() {"Background", "Character", "Collectable", "Solid"})
        Me.cboSecW.Location = New System.Drawing.Point(64, 112)
        Me.cboSecW.Name = "cboSecW"
        Me.cboSecW.Size = New System.Drawing.Size(48, 21)
        Me.cboSecW.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Section H:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Section W:"
        '
        'picPreview
        '
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Location = New System.Drawing.Point(64, 240)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(96, 72)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPreview.TabIndex = 15
        Me.picPreview.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Preview"
        '
        'cboBehavior
        '
        Me.cboBehavior.DisplayMember = "1"
        Me.cboBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBehavior.Items.AddRange(New Object() {"Background", "Character", "Collectable", "Solid"})
        Me.cboBehavior.Location = New System.Drawing.Point(64, 208)
        Me.cboBehavior.Name = "cboBehavior"
        Me.cboBehavior.Size = New System.Drawing.Size(96, 21)
        Me.cboBehavior.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Behavior"
        '
        'picColor
        '
        Me.picColor.BackColor = System.Drawing.SystemColors.Control
        Me.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picColor.Location = New System.Drawing.Point(64, 176)
        Me.picColor.Name = "picColor"
        Me.picColor.Size = New System.Drawing.Size(72, 16)
        Me.picColor.TabIndex = 11
        Me.picColor.TabStop = False
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(64, 48)
        Me.txtWidth.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(48, 20)
        Me.txtWidth.TabIndex = 8
        Me.txtWidth.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Width:"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(136, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 16)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "..."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Color key:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(64, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(96, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name:"
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(64, 80)
        Me.txtHeight.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.txtHeight.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(48, 20)
        Me.txtHeight.TabIndex = 10
        Me.txtHeight.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Height:"
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(344, 416)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "&OK"
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(264, 416)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "&Cancel"
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Bitmap)
        Me.Button4.Location = New System.Drawing.Point(184, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 32)
        Me.Button4.TabIndex = 6
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Bitmap)
        Me.Button5.Location = New System.Drawing.Point(184, 64)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 32)
        Me.Button5.TabIndex = 7
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(8, 320)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 24)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "&Add"
        '
        'Button7
        '
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(96, 320)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 24)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "&Remove"
        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = "untitled1"
        Me.dlgOpen.Filter = "All Images|*.bmp;*.jpg;*.gif;*.png|Bitmaps|*.bmp|GIF's|*.gif|JPG's|*.jpg|PNG's|*." & _
        "png"
        Me.dlgOpen.Multiselect = True
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.Label12, Me.TextBox1, Me.Label11})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 352)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tileset Properties"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Overall tile width:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(104, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(56, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "32"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(240, 24)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(56, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "32"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(192, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "height:"
        '
        'frmTileset
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 448)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.Label2, Me.Button7, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.GroupBox1, Me.Label1, Me.list})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTileset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tileset Editor"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        'Drawing.LoadImage(dlgOpen.FileName, "Image" & list.Items.Count + 1)
        Dim i As Integer
        For i = 0 To UBound(dlgOpen.FileNames)
            Game.tileset.AddTile(New psTile(dlgOpen.FileNames(i), "Image" & list.Items.Count + 1))
            iml.Images.Add(Game.Drawing.img(Game.Drawing.imgCount).bmp)
            list.Items.Add("Image" & list.Items.Count + 1, list.Items.Count)
        Next
        list.Items(list.Items.Count - 1).Selected = True
        list.Items(list.SelectedIndices(0)).EnsureVisible()
        list.Select()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Game.tileset.RemoveTile(list.SelectedItems(0).Index + 1)
        Dim tmp As Integer
        tmp = list.SelectedIndices(0)
        list.Items.Remove(list.SelectedItems(0))
        If tmp > list.Items.Count - 1 Then tmp = list.Items.Count - 1
        If tmp >= 0 Then
            list.Items(tmp).Selected = True
        End If
    End Sub

    Private Sub list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.SelectedIndexChanged
        If list.SelectedIndices.Count = 0 Then
            Button7.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            GroupBox1.Enabled = False
            picPreview.Image = Nothing
            picColor.BackColor = Color.FromKnownColor(KnownColor.Control)
            Exit Sub
        End If
        Button7.Enabled = True
        Button4.Enabled = (list.SelectedIndices.Item(0) > 0)
        Button5.Enabled = (list.SelectedIndices.Item(0) < list.Items.Count - 1)

        Dim curTile As psTile
        curTile = Game.tileset.tiles(list.SelectedIndices.Item(0) + 1)

        'Initialize fields
        picPreview.Image = New Bitmap(curTile.filename) ' iml.Images(list.Items(list.SelectedIndices(0)).ImageIndex)
        txtName.Text = curTile.name
        NoUpdate = True
        txtWidth.Text = curTile.width
        txtHeight.Text = curTile.height
        NoUpdate = False
        picColor.BackColor = Color.FromArgb(curTile.colorkey)
        cboBehavior.SelectedIndex = curTile.behavior
        RecalcSectorDimensions()

        GroupBox1.Enabled = True
    End Sub

    Sub RecalcSectorDimensions()
        Dim curTile As psTile
        curTile = Game.tileset.tiles(list.SelectedIndices.Item(0) + 1)

        Dim i As Integer, tmpSel As Integer
        cboSecW.Items.Clear()
        cboSecH.Items.Clear()
        tmpSel = -1
        For i = 8 To curTile.width
            If curTile.width / i = curTile.width \ i Then
                cboSecW.Items.Add(i)
                If i = curTile.sectionw Then tmpSel = cboSecW.Items.Count - 1
            End If
        Next
        If tmpSel = -1 Then
            cboSecW.Select(cboSecW.Items.Count - 1, 1)
            Game.tileset.tileSecW(list.SelectedIndices.Item(0) + 1) = Game.tileset.tileWidth(list.SelectedIndices.Item(0) + 1)
        Else
            cboSecW.SelectedIndex = tmpSel
        End If
        tmpSel = -1
        For i = 8 To curTile.height
            If curTile.height / i = curTile.height \ i Then
                cboSecH.Items.Add(i)
                If i = curTile.sectionh Then tmpSel = cboSecH.Items.Count - 1
            End If
        Next
        If tmpSel = -1 Then
            cboSecH.Select(cboSecH.Items.Count - 1, 1)
            Game.tileset.tileSecH(list.SelectedIndices.Item(0) + 1) = Game.tileset.tileHeight(list.SelectedIndices.Item(0) + 1)
        Else
            cboSecH.SelectedIndex = tmpSel
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If list.SelectedIndices.Count = 0 Then Exit Sub
        dlgColor.Color = picColor.BackColor
        If dlgColor.ShowDialog = DialogResult.Cancel Then Exit Sub
        picColor.BackColor = dlgColor.Color
        With Game.tileset
            .tileColorKey(list.SelectedIndices.Item(0) + 1) = picColor.BackColor.ToArgb
        End With
        list.Select()
    End Sub

    Private Sub frmTileset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 1 To Game.tileset.NumTiles
            iml.Images.Add(Game.Drawing.img(Game.Drawing.imgIndex(Game.tileset.tiles(i).name)).bmp)
            list.Items.Add(Game.tileset.tiles(i).name, list.Items.Count)
        Next
        If list.Items.Count > 0 Then list.Items(0).Selected = True
        list.Select()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tileName(list.SelectedIndices.Item(0) + 1) = txtName.Text
        End With
        list.Items(list.SelectedIndices.Item(0)).Text = txtName.Text
    End Sub

    Private Sub txtWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWidth.ValueChanged
        If NoUpdate Then Exit Sub
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tileWidth(list.SelectedIndices.Item(0) + 1) = txtWidth.Text
        End With
        RecalcSectorDimensions()
    End Sub

    Private Sub txtHeight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeight.ValueChanged
        If NoUpdate Then Exit Sub
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tileHeight(list.SelectedIndices.Item(0) + 1) = txtHeight.Text
        End With
        RecalcSectorDimensions()
    End Sub

    Private Sub txtWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWidth.TextChanged
        txtWidth_ValueChanged(sender, e)
    End Sub

    Private Sub txtHeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWidth.TextChanged
        txtHeight_ValueChanged(sender, e)
    End Sub

    Private Sub cboSecW_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecW.SelectedIndexChanged
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tileSecW(list.SelectedIndices.Item(0) + 1) = cboSecW.Text
        End With
        list.Select()
    End Sub

    Private Sub cboSecH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecH.SelectedIndexChanged
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tileSecH(list.SelectedIndices.Item(0) + 1) = cboSecH.Text
        End With
        list.Select()
    End Sub

    Private Sub cboBehavior_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBehavior.SelectedIndexChanged
        If list.SelectedIndices.Count = 0 Then Exit Sub
        With Game.tileset
            .tiles(list.SelectedIndices.Item(0) + 1).behavior = cboBehavior.SelectedIndex
        End With
        list.Select()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MoveTile(-1)
    End Sub

    Sub MoveTile(ByVal Direction As Integer)
        Dim tmpstr As String, tmpint As Integer
        tmpstr = list.Items(list.SelectedIndices(0)).Text
        tmpint = list.Items(list.SelectedIndices(0)).ImageIndex
        list.Items(list.SelectedIndices(0)).Text = list.Items(list.SelectedIndices(0) + Direction).Text
        list.Items(list.SelectedIndices(0)).ImageIndex = list.Items(list.SelectedIndices(0) + Direction).ImageIndex
        list.Items(list.SelectedIndices(0) + Direction).Text = tmpstr
        list.Items(list.SelectedIndices(0) + Direction).ImageIndex = tmpint
        Game.tileset.MoveTile(list.SelectedIndices(0) + 1, Direction)
        list.Items(list.SelectedIndices(0) + Direction).Selected = True
        list.Items(list.SelectedIndices(0) + Direction).EnsureVisible()
        list.Select()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MoveTile(1)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ConvertToNumber(TextBox1, 8, 64, Game.tileW)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ConvertToNumber(TextBox2, 8, 64, Game.tileH)
    End Sub
End Class
