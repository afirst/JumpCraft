Imports PlatformStudio

Public Class psProperties
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label10.Text = GetString("props_FrameLabel")
        Me.Button1.Text = GetString("props_PathEditButton")
        Me.Label12.Text = GetString("props_PathLabel")
        Me.Label11.Text = GetString("props_TileLabel")
        Me.Label5.Text = GetString("props_SizeLabel")
        Me.Label2.Text = GetString("props_LocationLabel")
        Me.Label1.Text = GetString("props_GroupLabel")
        Me.Label8.Text = GetString("props_CheckpointLabel")
        Me.Label16.Text = GetString("props_SizeLabel")
        Me.Label18.Text = GetString("props_LocationLabel")
        Me.Label19.Text = GetString("props_NameLabel")
        Me.GroupBox1.Text = GetString("props_ViewFrame")
        Me.Label3.Text = GetString("props_PrecisionLabel")
        Me.CheckBox3.Text = GetString("props_ShowPointsCheckbox")
        Me.CheckBox2.Text = GetString("props_ShowGuidesCheckbox")
        Me.GroupBox3.Text = GetString("props_PreviewFrame")
        Me.Label6.Text = GetString("props_ProgressLabel")
        Me.CheckBox4.Text = GetString("props_LoopCheckbox")
        Me.Button4.Text = GetString("props_PreviewButton")
        Me.GroupBox2.Text = GetString("props_PathOptionsFrame")
        Me.Label7.Text = GetString("props_SpeedLabel")
        Me.Label4.Text = GetString("secondsUnit")
        Me.Button3.Text = GetString("cancelButton")
        Me.Button2.Text = GetString("okButton")
        Panel1.BackColor = UIPlus.DefaultColorScheme.getInstance.MenuBack
        Panel2.BackColor = Panel1.BackColor
        Panel3.BackColor = Panel1.BackColor
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboTiles As psTileCombo
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents lblLSize As System.Windows.Forms.Label
    Friend WithEvents lblLLoc As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents progress As System.Windows.Forms.ProgressBar
    Public WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Public WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Public WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents txtGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFrame As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboFrame = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtGroup = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblSize = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblLoc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTiles = New psTileCombo
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblLSize = New System.Windows.Forms.Label
        Me.lblLLoc = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.progress = New System.Windows.Forms.ProgressBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.cboFrame)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtGroup)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lblSize)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblLoc)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboTiles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 328)
        Me.Panel1.TabIndex = 20
        '
        'cboFrame
        '
        Me.cboFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFrame.Location = New System.Drawing.Point(64, 80)
        Me.cboFrame.Name = "cboFrame"
        Me.cboFrame.Size = New System.Drawing.Size(88, 21)
        Me.cboFrame.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 15

        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(64, 104)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(88, 21)
        Me.txtGroup.Sorted = True
        Me.txtGroup.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(80, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 20)
        Me.Button1.TabIndex = 13

        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 16)
        Me.Label12.TabIndex = 11

        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 10

        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSize
        '
        Me.lblSize.BackColor = System.Drawing.Color.Transparent
        Me.lblSize.Location = New System.Drawing.Point(64, 32)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(80, 16)
        Me.lblSize.TabIndex = 5
        Me.lblSize.Text = "0, 0"
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4

        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoc
        '
        Me.lblLoc.BackColor = System.Drawing.Color.Transparent
        Me.lblLoc.Location = New System.Drawing.Point(64, 8)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(80, 16)
        Me.lblLoc.TabIndex = 3
        Me.lblLoc.Text = "0, 0"
        Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 2

        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0

        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTiles
        '
        Me.cboTiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiles.ItemHeight = 12
        Me.cboTiles.Location = New System.Drawing.Point(64, 56)
        Me.cboTiles.MaxDropDownItems = 12
        Me.cboTiles.Name = "cboTiles"
        Me.cboTiles.Size = New System.Drawing.Size(88, 18)
        Me.cboTiles.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.Controls.Add(Me.ComboBox1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblLSize)
        Me.Panel2.Controls.Add(Me.lblLLoc)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtName)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(160, 328)
        Me.Panel2.TabIndex = 21
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"(None)", "Top-Left", "Top-Right", "Bottom-Left", "Bottom-Right"})
        Me.ComboBox1.Location = New System.Drawing.Point(72, 80)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(80, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(8, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 12

        '
        'lblLSize
        '
        Me.lblLSize.BackColor = System.Drawing.Color.Transparent
        Me.lblLSize.Location = New System.Drawing.Point(64, 32)
        Me.lblLSize.Name = "lblLSize"
        Me.lblLSize.Size = New System.Drawing.Size(80, 16)
        Me.lblLSize.TabIndex = 11
        Me.lblLSize.Text = "0, 0"
        Me.lblLSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLLoc
        '
        Me.lblLLoc.BackColor = System.Drawing.Color.Transparent
        Me.lblLLoc.Location = New System.Drawing.Point(64, 8)
        Me.lblLLoc.Name = "lblLLoc"
        Me.lblLLoc.Size = New System.Drawing.Size(80, 16)
        Me.lblLLoc.TabIndex = 10
        Me.lblLLoc.Text = "0, 0"
        Me.lblLLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 4

        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 16)
        Me.Label18.TabIndex = 2

        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(64, 56)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(88, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 16)
        Me.Label19.TabIndex = 0

        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(160, 328)
        Me.Panel3.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TrackBar1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 96)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False

        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(64, 56)
        Me.TrackBar1.Maximum = 6
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(72, 32)
        Me.TrackBar1.TabIndex = 3
        Me.TrackBar1.Value = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 2

        '
        'CheckBox3
        '
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox3.Location = New System.Drawing.Point(8, 40)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox3.TabIndex = 1

        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox2.Location = New System.Drawing.Point(8, 16)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox2.TabIndex = 0

        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.progress)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CheckBox4)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox3.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 72)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False

        '
        'progress
        '
        Me.progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.progress.Location = New System.Drawing.Point(56, 48)
        Me.progress.Maximum = 1000
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(80, 16)
        Me.progress.TabIndex = 21
        Me.progress.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 20

        '
        'CheckBox4
        '
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox4.Location = New System.Drawing.Point(80, 16)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(56, 24)
        Me.CheckBox4.TabIndex = 19

        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button4.Location = New System.Drawing.Point(8, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(64, 24)
        Me.Button4.TabIndex = 18

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(8, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 72)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False

        '
        'CheckBox1
        '
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox1.Location = New System.Drawing.Point(8, 16)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Enclosed"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 4

        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(56, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "3"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(120, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 16

        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(72, 272)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 14

        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(8, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 24)
        Me.Button2.TabIndex = 13

        '
        'psProperties
        '
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Enabled = False
        Me.Name = "psProperties"
        Me.Size = New System.Drawing.Size(160, 328)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim NoUpdate As Boolean

    Overloads Sub Refresh()
        If Editor.psedit.PathEdit.Editing Then
            TrackBar1.Height = 30
            Panel3.Visible = True
            Panel1.Visible = False
            Panel2.Visible = False
            Me.Size = New Size(160, 328)
            Exit Sub
        End If
        With Editor.psedit
            If Game.OnLocationLayer Then
                Panel2.Visible = True
                Panel1.Visible = False
                Panel3.Visible = False
                If .sellocs.GetUpperBound(0) = 1 Then
                    Enabled = True
                    lblLLoc.Text = .sellocs(1).loc.X & ", " & .sellocs(1).loc.Y
                    lblLSize.Text = Math.Round(.sellocs(1).loc.Width / Game.tileW, 2) & ", " & Math.Round(.sellocs(1).loc.Height / Game.tileH, 2)
                    txtName.Text = .sellocs(1).loc.Name
                    ComboBox1.SelectedIndex = .sellocs(1).loc.ChkPos
                Else
                    Enabled = False
                End If
            Else
                Panel1.Visible = True
                Panel2.Visible = False
                Panel3.Visible = False
                If .seltiles.GetUpperBound(0) = 1 Then
                    Enabled = True
                    lblLoc.Text = .seltiles(1).x & ", " & .seltiles(1).y
                    lblSize.Text = Math.Round(.seltiles(1).w / Game.tileW, 2) & ", " & Math.Round(.seltiles(1).h / Game.tileH, 2)
                    NoUpdate = True
                    cboTiles.SelectedIndex = .seltiles(1).tile.tile - 1

                    cboFrame.Items.Clear()
                    If Not (.seltiles(1).tile.GetTile.Anim(0).Interval > 0 Or _
                        (.seltiles(1).tile.GetTile.width = .seltiles(1).tile.w And .seltiles(1).tile.GetTile.height = .seltiles(1).tile.h)) Then
                        For i As Integer = 1 To (.seltiles(1).tile.GetTile.width \ .seltiles(1).tile.w) * (.seltiles(1).tile.GetTile.height \ .seltiles(1).tile.h)
                            cboFrame.Items.Add(i)
                        Next
                        cboFrame.SelectedIndex = .seltiles(1).tile.Frame - 1
                        cboFrame.Enabled = True
                    Else
                        cboFrame.Enabled = False
                    End If

                    NoUpdate = False
                    txtGroup.Text = .seltiles(1).tile.Group
                Else
                    Enabled = False
                End If
            End If
        End With
    End Sub

    Dim Changing As Boolean

    Private Sub txtGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
        If Changing Then Exit Sub

        Changing = True
        With Editor.psedit
            'Make sure the text contains only letters,
            'numbers, and underscores (_)
            Dim tmp As Integer = txtGroup.SelectionStart
            txtGroup.Text = Replace(txtGroup.Text, " ", "")
            For i As Integer = 0 To txtGroup.Text.Length - 1
                If i > txtGroup.Text.Length - 1 Then Exit For
                If Char.IsLetterOrDigit(txtGroup.Text.Chars(i)) = False And txtGroup.Text.Chars(i) <> "_" Then
                    If i + 1 >= txtGroup.Text.Length Then
                        txtGroup.Text = txtGroup.Text.Substring(0, i)
                    Else
                        txtGroup.Text = txtGroup.Text.Substring(0, i) & txtGroup.Text.Substring(i + 1)
                    End If
                    i -= 1
                End If
            Next
            If tmp > txtGroup.Text.Length Then
                txtGroup.SelectionStart = txtGroup.Text.Length
            Else
                txtGroup.SelectionStart = tmp
            End If

            If .seltiles.GetUpperBound(0) = 1 Then
                .DeleteUnusedGroupActions()
                .seltiles(1).tile.Group = txtGroup.Text
            End If
        End With
        Changing = False
    End Sub

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Editor.psproperties = Me
    End Sub

    Private Sub txtName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Enter
        UndoRedo.UpdateUndo(GetString("undoActionChangeLocationName"), UndoRedo.UndoType.Locations, Game.CurMapIndex)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        With Editor.psedit
            If .sellocs.GetUpperBound(0) = 1 Then
                'Change actions
                Dim i As Integer
                With Game.actions
                    For i = 1 To UBound(.Actions)
                        If .Actions(i).Trigger.Chars(0) = "l" AndAlso .Actions(i).Trigger.Substring(4, 5) = Game.CurMapIndex AndAlso .Actions(i).Trigger.Substring(9) = Editor.psedit.sellocs(1).loc.Name Then
                            .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & Format(Game.CurMapIndex, "00000") & txtName.Text
                        End If
                    Next
                End With

                .sellocs(1).loc.Name = txtName.Text
            End If
        End With
    End Sub

    Private Sub cboTiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTiles.SelectedIndexChanged
        If NoUpdate Then Exit Sub
        If Editor.psedit.PathEdit.Editing Then Exit Sub
        With Editor.psedit
            If .seltiles.GetUpperBound(0) = 1 Then
                If cboTiles.SelectedIndex >= 0 And cboTiles.SelectedIndex <= Game.tileset.NumTiles - 1 Then
                    If .seltiles(1).tile.tile <> cboTiles.SelectedIndex + 1 Then
                        UndoRedo.UpdateUndo(GetString("undoActionChangeTileIndex"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
                    End If
                    .seltiles(1).tile.Frame = 0
                    .seltiles(1).tile.tile = cboTiles.SelectedIndex + 1
                    Refresh()
                End If
            End If
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Editor.psedit
            If .seltiles.GetUpperBound(0) = 1 Then
                With Editor.psedit.PathEdit
                    .Init(Editor.psproperties.progress, Editor.psedit.p, Editor.psproperties.Button4, TextBox1, CheckBox1)
                End With
                Refresh()
            End If
        End With
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Options.pPrecision = TrackBar1.Value
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.SetPrecision(TrackBar1.Value)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Options.pShowGuides = CheckBox2.Checked
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.ShowGuides = CheckBox2.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Options.pShowPoints = CheckBox3.Checked
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.ShowPoints = CheckBox3.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.Enclose = CheckBox1.Checked
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        ConvertToNumber(TextBox1, 0.01, 600, 3, 2)
        Editor.psedit.PathEdit.SpeedS = TextBox1.Text
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TextBox1_Validating(sender, Nothing)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.Preview()
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.LoopPreview = CheckBox4.Checked
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.Done(False)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        If Editor.psedit.PathEdit Is Nothing Then Exit Sub
        Editor.psedit.PathEdit.Done(True)
    End Sub

    Private Sub txtGroup_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtGroup.MouseDown
        With Editor.psedit
            If .seltiles.GetUpperBound(0) = 1 Then
                If Options.gWarnWhenDelActions Then
                    If .LastTileInGroup Then
                        If MessageBox.Show(GetString("deleteActionConfirmationMessage"), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Button1.Select()
                            Exit Sub
                        End If
                    End If
                End If
                UndoRedo.UpdateUndo(GetString("undoActionChangeTileGroup"), UndoRedo.UndoType.Level, Game.CurMapIndex, psMap.CurLayer)
            End If
        End With
    End Sub

    Private Sub txtGroup_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroup.DropDown
        UpdateGroupList()
    End Sub

    Private Sub txtGroup_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroup.Enter
        UpdateGroupList()
    End Sub

    Sub UpdateGroupList()
        txtGroup.Items.Clear()
        Dim tmpGroups() As String = ListGroups(Game.CurMapIndex)
        For i As Integer = 1 To UBound(tmpGroups)
            txtGroup.Items.Add(tmpGroups(i))
        Next
        For i As Integer = 1 To UBound(Editor.psedit.seltiles)
            With Editor.psedit.seltiles(i).tile
                If .Group <> "" Then
                    For j As Integer = 1 To UBound(tmpGroups)
                        If .Group = tmpGroups(j) Then GoTo NextI
                    Next
                    txtGroup.Items.Add(.Group)
                End If
            End With
NextI:
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        With Editor.psedit
            If .sellocs.GetUpperBound(0) = 1 Then
                UndoRedo.UpdateUndo(String.Format(GetString("undoActionSetCheckpoint"), .sellocs(1).loc.Name), UndoRedo.UndoType.Locations, Game.CurMapIndex)
                .sellocs(1).loc.ChkPos = ComboBox1.SelectedIndex
            End If
        End With
    End Sub

    Private Sub cboFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFrame.SelectedIndexChanged
        If NoUpdate Then Exit Sub
        If Editor.psedit.PathEdit.Editing Then Exit Sub
        UndoRedo.UpdateUndo(GetString("undoActionChangeTileFrame"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
        Editor.psedit.seltiles(1).tile.Frame = cboFrame.SelectedIndex + 1
    End Sub
End Class