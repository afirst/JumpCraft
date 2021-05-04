Imports PlatformStudio

Public Class psfrmActionData
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.txtActDesc.Items.AddRange(New Object() {"Game", "Counters", "Camera", "Character", "Map", "Drawing", "Scripting", "Misc."})
        Me.TabPage2.Text = GetString("actionDataEd_ActionsTab")
        Me.btnActRemove.Text = GetString("gameProperties_RemoveFileButton")
        Me.btnActAdd.Text = GetString("gameProperties_AddFileButton")
        Me.GroupBox2.Text = GetString("propertiesPanelTitle")
        Me.txtActParam.Text = GetString("editMenu")
        Me.Label8.Text = GetString("editAction_ParametersLabel")
        Me.Label7.Text = GetString("actionDataEd_CodeLabel")
        Me.Label4.Text = GetString("parameterEd_IconLabel")
        Me.Label5.Text = GetString("actionDataEd_CategoryLabel")
        Me.Label6.Text = GetString("parameterEd_NameLabel")
        Me.btnTrigRemove.Text = GetString("gameProperties_RemoveFileButton")
        Me.btnTrigAdd.Text = GetString("gameProperties_AddFileButton")
        Me.GroupBox1.Text = GetString("propertiesPanelTitle")
        Me.Label3.Text = GetString("gameProperties_IconLabel")
        Me.Label2.Text = GetString("actionDataEd_DescriptionLabel")
        Me.Label1.Text = GetString("timers_TimerNameLabel")
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.Button1.Text = GetString("tileset_SetAsDefaultButton")
        Me.lblNotice.Text = GetString("actionDataEd_TriggersReadOnly")
        Me.Button5.Text = GetString("actionDataEd_ImportDefaults")
        Me.Text = GetString("actionDataEd_Title")
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnActRemove As System.Windows.Forms.Button
    Friend WithEvents btnActAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtActIcon As System.Windows.Forms.ComboBox
    Friend WithEvents txtActName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lstActList As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtActCode As System.Windows.Forms.TextBox
    Friend WithEvents txtActParam As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnActMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnActMoveDown As System.Windows.Forms.Button
    Friend WithEvents lblNotice As System.Windows.Forms.Label
    Friend WithEvents btnTrigMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnTrigMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnTrigRemove As System.Windows.Forms.Button
    Friend WithEvents btnTrigAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtTrigIcon As System.Windows.Forms.ComboBox
    Friend WithEvents txtTrigDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtTrigName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstTrigList As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtActDesc As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(psfrmActionData))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnActMoveUp = New System.Windows.Forms.Button
        Me.btnActMoveDown = New System.Windows.Forms.Button
        Me.btnActRemove = New System.Windows.Forms.Button
        Me.btnActAdd = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtActDesc = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtActParam = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtActCode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtActIcon = New System.Windows.Forms.ComboBox
        Me.txtActName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lstActList = New System.Windows.Forms.ListBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnTrigMoveUp = New System.Windows.Forms.Button
        Me.btnTrigMoveDown = New System.Windows.Forms.Button
        Me.btnTrigRemove = New System.Windows.Forms.Button
        Me.btnTrigAdd = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.txtTrigIcon = New System.Windows.Forms.ComboBox
        Me.txtTrigDesc = New System.Windows.Forms.TextBox
        Me.txtTrigName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstTrigList = New System.Windows.Forms.ListBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblNotice = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button5 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(464, 256)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnActMoveUp)
        Me.TabPage2.Controls.Add(Me.btnActMoveDown)
        Me.TabPage2.Controls.Add(Me.btnActRemove)
        Me.TabPage2.Controls.Add(Me.btnActAdd)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.lstActList)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(456, 230)
        Me.TabPage2.TabIndex = 1

        '
        'btnActMoveUp
        '
        Me.btnActMoveUp.Enabled = False
        Me.btnActMoveUp.Image = CType(resources.GetObject("btnActMoveUp.Image"), System.Drawing.Image)
        Me.btnActMoveUp.Location = New System.Drawing.Point(168, 8)
        Me.btnActMoveUp.Name = "btnActMoveUp"
        Me.btnActMoveUp.Size = New System.Drawing.Size(32, 32)
        Me.btnActMoveUp.TabIndex = 3
        '
        'btnActMoveDown
        '
        Me.btnActMoveDown.Enabled = False
        Me.btnActMoveDown.Image = CType(resources.GetObject("btnActMoveDown.Image"), System.Drawing.Image)
        Me.btnActMoveDown.Location = New System.Drawing.Point(168, 48)
        Me.btnActMoveDown.Name = "btnActMoveDown"
        Me.btnActMoveDown.Size = New System.Drawing.Size(32, 32)
        Me.btnActMoveDown.TabIndex = 4
        '
        'btnActRemove
        '
        Me.btnActRemove.Enabled = False
        Me.btnActRemove.Location = New System.Drawing.Point(88, 200)
        Me.btnActRemove.Name = "btnActRemove"
        Me.btnActRemove.Size = New System.Drawing.Size(72, 24)
        Me.btnActRemove.TabIndex = 2

        '
        'btnActAdd
        '
        Me.btnActAdd.Location = New System.Drawing.Point(8, 200)
        Me.btnActAdd.Name = "btnActAdd"
        Me.btnActAdd.Size = New System.Drawing.Size(72, 24)
        Me.btnActAdd.TabIndex = 1

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtActDesc)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.txtActParam)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtActCode)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtActIcon)
        Me.GroupBox2.Controls.Add(Me.txtActName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(208, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 216)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False

        '
        'txtActDesc
        '
        Me.txtActDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtActDesc.Location = New System.Drawing.Point(88, 40)
        Me.txtActDesc.Name = "txtActDesc"
        Me.txtActDesc.Size = New System.Drawing.Size(144, 21)
        Me.txtActDesc.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(208, 152)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'txtActParam
        '
        Me.txtActParam.Location = New System.Drawing.Point(88, 184)
        Me.txtActParam.Name = "txtActParam"
        Me.txtActParam.Size = New System.Drawing.Size(72, 24)
        Me.txtActParam.TabIndex = 9

        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 8

        '
        'txtActCode
        '
        Me.txtActCode.Location = New System.Drawing.Point(88, 64)
        Me.txtActCode.Multiline = True
        Me.txtActCode.Name = "txtActCode"
        Me.txtActCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtActCode.Size = New System.Drawing.Size(144, 80)
        Me.txtActCode.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 4

        '
        'txtActIcon
        '
        Me.txtActIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtActIcon.DropDownWidth = 96
        Me.txtActIcon.Location = New System.Drawing.Point(88, 152)
        Me.txtActIcon.Name = "txtActIcon"
        Me.txtActIcon.Size = New System.Drawing.Size(112, 21)
        Me.txtActIcon.TabIndex = 7
        '
        'txtActName
        '
        Me.txtActName.Location = New System.Drawing.Point(88, 16)
        Me.txtActName.Name = "txtActName"
        Me.txtActName.Size = New System.Drawing.Size(144, 20)
        Me.txtActName.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 6

        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 2

        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 0

        '
        'lstActList
        '
        Me.lstActList.Location = New System.Drawing.Point(8, 8)
        Me.lstActList.Name = "lstActList"
        Me.lstActList.Size = New System.Drawing.Size(152, 186)
        Me.lstActList.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.ImageIndex = 0
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(168, 88)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 32)
        Me.Button4.TabIndex = 9
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'btnTrigMoveUp
        '
        Me.btnTrigMoveUp.Enabled = False
        Me.btnTrigMoveUp.Image = CType(resources.GetObject("btnTrigMoveUp.Image"), System.Drawing.Image)
        Me.btnTrigMoveUp.Location = New System.Drawing.Point(160, 0)
        Me.btnTrigMoveUp.Name = "btnTrigMoveUp"
        Me.btnTrigMoveUp.Size = New System.Drawing.Size(32, 32)
        Me.btnTrigMoveUp.TabIndex = 15
        '
        'btnTrigMoveDown
        '
        Me.btnTrigMoveDown.Enabled = False
        Me.btnTrigMoveDown.Image = CType(resources.GetObject("btnTrigMoveDown.Image"), System.Drawing.Image)
        Me.btnTrigMoveDown.Location = New System.Drawing.Point(160, 40)
        Me.btnTrigMoveDown.Name = "btnTrigMoveDown"
        Me.btnTrigMoveDown.Size = New System.Drawing.Size(32, 32)
        Me.btnTrigMoveDown.TabIndex = 16
        '
        'btnTrigRemove
        '
        Me.btnTrigRemove.Enabled = False
        Me.btnTrigRemove.Location = New System.Drawing.Point(80, 192)
        Me.btnTrigRemove.Name = "btnTrigRemove"
        Me.btnTrigRemove.Size = New System.Drawing.Size(72, 24)
        Me.btnTrigRemove.TabIndex = 14

        '
        'btnTrigAdd
        '
        Me.btnTrigAdd.Location = New System.Drawing.Point(0, 192)
        Me.btnTrigAdd.Name = "btnTrigAdd"
        Me.btnTrigAdd.Size = New System.Drawing.Size(72, 24)
        Me.btnTrigAdd.TabIndex = 13

        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.txtTrigIcon)
        Me.GroupBox1.Controls.Add(Me.txtTrigDesc)
        Me.GroupBox1.Controls.Add(Me.txtTrigName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(200, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 217)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False

        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.Location = New System.Drawing.Point(208, 104)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'txtTrigIcon
        '
        Me.txtTrigIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtTrigIcon.DropDownWidth = 96
        Me.txtTrigIcon.Location = New System.Drawing.Point(88, 104)
        Me.txtTrigIcon.Name = "txtTrigIcon"
        Me.txtTrigIcon.Size = New System.Drawing.Size(112, 21)
        Me.txtTrigIcon.TabIndex = 5
        '
        'txtTrigDesc
        '
        Me.txtTrigDesc.Location = New System.Drawing.Point(88, 40)
        Me.txtTrigDesc.Multiline = True
        Me.txtTrigDesc.Name = "txtTrigDesc"
        Me.txtTrigDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTrigDesc.Size = New System.Drawing.Size(144, 56)
        Me.txtTrigDesc.TabIndex = 3
        '
        'txtTrigName
        '
        Me.txtTrigName.Location = New System.Drawing.Point(88, 16)
        Me.txtTrigName.Name = "txtTrigName"
        Me.txtTrigName.Size = New System.Drawing.Size(144, 20)
        Me.txtTrigName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 4

        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 2

        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0

        '
        'lstTrigList
        '
        Me.lstTrigList.Location = New System.Drawing.Point(0, 0)
        Me.lstTrigList.Name = "lstTrigList"
        Me.lstTrigList.Size = New System.Drawing.Size(152, 186)
        Me.lstTrigList.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(400, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 3

        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(94, 192)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(304, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 2

        '
        'lblNotice
        '
        Me.lblNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotice.Location = New System.Drawing.Point(8, 272)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(56, 40)
        Me.lblNotice.TabIndex = 4

        Me.lblNotice.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstTrigList)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnTrigAdd)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.btnTrigRemove)
        Me.Panel1.Controls.Add(Me.btnTrigMoveDown)
        Me.Panel1.Controls.Add(Me.btnTrigMoveUp)
        Me.Panel1.Location = New System.Drawing.Point(24, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(440, 216)
        Me.Panel1.TabIndex = 5
        Me.Panel1.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(196, 272)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 24)
        Me.Button5.TabIndex = 6

        '
        'psfrmActionData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(482, 304)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblNotice)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmActionData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const MustSetDefaults As Boolean = True

    Dim DoNotValidate As Boolean
    Dim CurAct As Integer, CurTrig As Integer
    Dim DoNotValidate2 As Boolean
    Dim DoNotValidate3 As Boolean
    Dim tmpAct As psActions

    Const CanEditTriggers As Boolean = False

    Private Sub psfrmActionData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Game.actions.IconKeysInit()
        Dim i As Integer
        tmpAct = Game.actions.Clone
        txtTrigIcon.Items.Clear()
        For i = 0 To UBound(psActions.TrigIconKeys)
            txtTrigIcon.Items.Add(psActions.TrigIconKeys(i))
        Next
        txtActIcon.Items.Clear()
        For i = 0 To UBound(psActions.ActIconKeys)
            txtActIcon.Items.Add(psActions.ActIconKeys(i))
        Next
        With Game.actions.Dat
            lstTrigList.Items.Clear()
            For i = 1 To UBound(.tb)
                lstTrigList.Items.Add(.tb(i).Name)
            Next
            lstActList.Items.Clear()
            For i = 1 To UBound(.ab)
                lstActList.Items.Add(.ab(i).Name)
            Next
        End With
        If lstTrigList.Items.Count > 0 Then
            If CanEditTriggers Then
                btnTrigRemove.Enabled = True
                GroupBox1.Enabled = True
            Else
                btnTrigAdd.Enabled = False
            End If
            lstTrigList.SelectedIndex = 0
        End If
        If lstActList.Items.Count > 0 Then
            GroupBox2.Enabled = True
            btnActRemove.Enabled = True
            lstActList.SelectedIndex = 0
        End If

        'Make sure we can make this the default
        CompareWithDefault()
    End Sub

    Sub CompareWithDefault()
        If MustSetDefaults Then
            Button1.Enabled = True
            Exit Sub
        End If

        'Make sure we can make this the default
        Dim i As Integer, j As Integer
        With Game.actions.Dat
            If UBound(.ab) < UBound(DefaultActData.ab) Then
                Button1.Enabled = False
                Exit Sub
            End If
            For i = 1 To UBound(.ab)
                If .ab(i).Code <> DefaultActData.ab(i).Code Or _
                .ab(i).Name <> DefaultActData.ab(i).Name Or _
                UBound(.ab(i).params) <> UBound(DefaultActData.ab(i).params) Then
                    Button1.Enabled = False
                    Exit Sub
                Else
                    With .ab(i)
                        For j = 1 To UBound(.params)
                            If .params(j).ValueType <> DefaultActData.ab(i).params(j).ValueType Or _
                            .params(j).Name <> DefaultActData.ab(i).params(j).Name Or _
                            .params(j).MinValue <> DefaultActData.ab(i).params(j).MinValue Or _
                            .params(j).MaxValue <> DefaultActData.ab(i).params(j).MaxValue Or _
                            .params(j).DecimalPlaces <> DefaultActData.ab(i).params(j).DecimalPlaces Then
                                Button1.Enabled = False
                                Exit Sub
                            End If
                        Next
                    End With
                End If
            Next
        End With
        Button1.Enabled = True
    End Sub

    Private Sub txtActParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActParam.Click
        Dim f As New psfrmParamEdit
        f.SelAct = CurAct
        f.ShowDialog()
        f.Dispose()
        f = Nothing
        CompareWithDefault()
    End Sub

    Private Sub btnTrigAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrigAdd.Click
        ValidateTrigger()
        lstTrigList.Items.Add("Trigger " & lstTrigList.Items.Count + 1)
        With Game.actions.Dat
            ReDim Preserve .tb(UBound(.tb) + 1)
            .tb(UBound(.tb)).Name = lstTrigList.Items(lstTrigList.Items.Count - 1)
            .tb(UBound(.tb)).Icon = 0
        End With
        DoNotValidate3 = True
        lstTrigList.SelectedIndex = lstTrigList.Items.Count - 1
        DoNotValidate3 = False
        btnTrigRemove.Enabled = True
        GroupBox1.Enabled = True
        CurTrig = lstTrigList.SelectedIndex + 1
    End Sub

    Private Sub btnTrigRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrigRemove.Click
        With Game.actions.Dat
            Dim i As Integer
            For i = lstTrigList.SelectedIndex + 1 To UBound(.tb) - 1
                .tb(i) = .tb(i + 1)
            Next
            ReDim Preserve .tb(UBound(.tb) - 1)
        End With

        DoNotValidate3 = True
        Dim tmp As Integer
        tmp = lstTrigList.SelectedIndex
        lstTrigList.Items.RemoveAt(lstTrigList.SelectedIndex)
        If lstTrigList.Items.Count = 0 Then
        ElseIf tmp > lstTrigList.Items.Count - 1 Then
            lstTrigList.SelectedIndex = lstTrigList.Items.Count - 1
        Else
            lstTrigList.SelectedIndex = tmp
        End If
        DoNotValidate3 = False

        If lstTrigList.Items.Count = 0 Then
            btnTrigRemove.Enabled = False
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub btnActAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActAdd.Click
        ValidateAction()
        lstActList.Items.Add("Action " & lstActList.Items.Count + 1)
        With Game.actions.Dat
            ReDim Preserve .ab(UBound(.ab) + 1)
            .ab(UBound(.ab)).Name = lstActList.Items(lstActList.Items.Count - 1)
            .ab(UBound(.ab)).Description = GetString("actionCategory_Misc")
            .ab(UBound(.ab)).Icon = 0
            ReDim .ab(UBound(.ab)).params(0)
        End With
        DoNotValidate3 = True
        lstActList.SelectedIndex = lstActList.Items.Count - 1
        DoNotValidate3 = False
        btnActRemove.Enabled = True
        GroupBox2.Enabled = True
        CurAct = lstActList.SelectedIndex + 1
    End Sub

    Private Sub btnActRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActRemove.Click
        'Make sure...
        Dim i As Integer, j As Integer
        For i = 1 To UBound(Game.actions.Actions)
            If Game.actions.Actions(i).Action.Type = CurAct Then
                If MessageBox.Show(GetString("deleteActionConfirmationMessage"), GetString("actionDataEd_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                Else
                    Exit For
                End If
            End If
        Next

        'Update actions
        For i = 1 To UBound(Game.actions.Actions)
            If i > UBound(Game.actions.Actions) Then Exit For
            If Game.actions.Actions(i).Action.Type = CurAct Then
                For j = i To UBound(Game.actions.Actions) - 1
                    Game.actions.Actions(j) = Game.actions.Actions(j + 1).Clone
                Next
                ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) - 1)
                i -= 1
            ElseIf Game.actions.Actions(i).Action.Type > CurAct Then
                Game.actions.Actions(i).Action.Type -= 1
            End If
        Next

        With Game.actions.Dat
            For i = lstActList.SelectedIndex + 1 To UBound(.ab) - 1
                .ab(i) = .ab(i + 1)
            Next
            ReDim Preserve .ab(UBound(.ab) - 1)
        End With

        DoNotValidate3 = True
        Dim tmp As Integer
        tmp = lstActList.SelectedIndex
        lstActList.Items.RemoveAt(lstActList.SelectedIndex)
        If lstActList.Items.Count = 0 Then
        ElseIf tmp > lstActList.Items.Count - 1 Then
            lstActList.SelectedIndex = lstActList.Items.Count - 1
        Else
            lstActList.SelectedIndex = tmp
        End If
        DoNotValidate3 = False

        If lstActList.Items.Count = 0 Then
            btnActRemove.Enabled = False
            GroupBox2.Enabled = False
        End If

        CompareWithDefault()
    End Sub

    Private Sub lstTrigList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTrigList.SelectedIndexChanged
        If DoNotValidate2 Then Exit Sub
        If DoNotValidate Then Exit Sub
        If DoNotValidate3 = False Then
            ValidateTrigger()
        End If
        CurTrig = lstTrigList.SelectedIndex + 1
        With Game.actions.Dat.tb(lstTrigList.SelectedIndex + 1)
            txtTrigName.Text = .Name
            txtTrigDesc.Text = .Description
            txtTrigIcon.Text = psActions.TrigIconKeys(.Icon)
        End With
        If CanEditTriggers Then
            btnTrigMoveUp.Enabled = True
            btnTrigMoveDown.Enabled = True
        End If
        If lstTrigList.SelectedIndex = 0 Then btnTrigMoveUp.Enabled = False
        If lstTrigList.SelectedIndex = lstTrigList.Items.Count - 1 Then btnTrigMoveDown.Enabled = False
    End Sub

    Private Sub txtTrigIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrigIcon.SelectedIndexChanged
        PictureBox2.Image = fActionEdit.iml.Images(txtTrigIcon.SelectedIndex)
    End Sub

    Private Sub txtActIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActIcon.SelectedIndexChanged
        PictureBox1.Image = fActionEdit.iml2.Images(txtActIcon.SelectedIndex)
    End Sub

    Private Sub lstActList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstActList.SelectedIndexChanged
        If DoNotValidate2 = True Then Exit Sub
        If DoNotValidate Then Exit Sub
        If DoNotValidate3 = False Then
            ValidateAction()
        End If
        CurAct = lstActList.SelectedIndex + 1
        With Game.actions.Dat.ab(lstActList.SelectedIndex + 1)
            txtActName.Text = .Name
            txtActDesc.Text = .Description
            txtActCode.Text = .Code
            txtActIcon.Text = psActions.ActIconKeys(.Icon)
        End With
        btnActMoveUp.Enabled = (lstActList.SelectedIndex > -1)
        btnActMoveDown.Enabled = (lstActList.SelectedIndex > -1)
        If lstActList.SelectedIndex = 0 Then btnActMoveUp.Enabled = False
        If lstActList.SelectedIndex = lstActList.Items.Count - 1 Then btnActMoveDown.Enabled = False
    End Sub

    Sub ValidateTrigger()
        If DoNotValidate Then Exit Sub
        If CurTrig = 0 Then Exit Sub
        DoNotValidate = True
        lstTrigList.Items(CurTrig - 1) = txtTrigName.Text
        With Game.actions.Dat.tb(CurTrig)
            .Name = txtTrigName.Text
            .Description = txtTrigDesc.Text
            If txtTrigIcon.SelectedIndex = -1 Then txtTrigIcon.SelectedIndex = 0
            .Icon = txtTrigIcon.SelectedIndex
        End With
        DoNotValidate = False
    End Sub

    Sub ValidateAction()
        If DoNotValidate Then Exit Sub
        If CurAct = 0 Then Exit Sub
        DoNotValidate = True
        lstActList.Items(CurAct - 1) = txtActName.Text
        With Game.actions.Dat.ab(CurAct)
            .Name = txtActName.Text
            .Description = txtActDesc.Text
            .Code = txtActCode.Text
            If txtActIcon.SelectedIndex = -1 Then txtActIcon.SelectedIndex = 0
            .Icon = txtActIcon.SelectedIndex
        End With
        DoNotValidate = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ValidateTrigger()
        ValidateAction()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ValidateTrigger()
        ValidateAction()

        CompareWithDefault()
        If Button1.Enabled = False Then Exit Sub

        If MessageBox.Show(GetString("actionDataEd_SetDefaultConfirmation"), GetString("actionDataEd_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            DialogResult = DialogResult.None
            Exit Sub
        End If

        'Save as default
        FileClose(1)
        FileOpen(1, Game.Root & "actiondata.dat", OpenMode.Binary)
        FilePut(1, Game.actions.Dat)
        FileClose(1)
        DefaultActData = Game.actions.Dat.Clone
    End Sub

    Private Sub btnTrigMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrigMoveUp.Click
        MoveTrig(-1)
    End Sub

    Private Sub btnTrigMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrigMoveDown.Click
        MoveTrig(1)
    End Sub

    Sub MoveTrig(ByVal Amount As Integer)
        DoNotValidate = True
        DoNotValidate2 = True

        Dim tmpS As String
        tmpS = lstTrigList.Items(lstTrigList.SelectedIndex)
        lstTrigList.Items(lstTrigList.SelectedIndex) = lstTrigList.Items(lstTrigList.SelectedIndex + Amount)
        lstTrigList.Items(lstTrigList.SelectedIndex + Amount) = tmpS

        Dim tmpTB As psActions.psTriggerBehavior
        tmpTB = Game.actions.Dat.tb(CurTrig)
        Game.actions.Dat.tb(CurTrig) = Game.actions.Dat.tb(CurTrig + Amount)
        Game.actions.Dat.tb(CurTrig + Amount) = tmpTB

        DoNotValidate = False
        DoNotValidate2 = False

        CurTrig = CurTrig + Amount
        lstTrigList.SelectedIndex = lstTrigList.SelectedIndex + Amount
    End Sub

    Private Sub btnActMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActMoveUp.Click
        MoveAct(-1)
    End Sub

    Private Sub btnActMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActMoveDown.Click
        MoveAct(1)
    End Sub

    Sub MoveAct(ByVal Amount As Integer)
        'Move the actions in the current game

        DoNotValidate = True
        DoNotValidate2 = True

        'Update actions
        Dim i As Integer
        For i = 1 To UBound(Game.actions.Actions)
            With Game.actions.Actions(i).Action
                If .Type = CurAct Then
                    .Type = CurAct + Amount
                ElseIf .Type = CurAct + Amount Then
                    .Type = CurAct
                End If
            End With
        Next

        Dim tmpS As String
        tmpS = lstActList.Items(lstActList.SelectedIndex)
        lstActList.Items(lstActList.SelectedIndex) = lstActList.Items(lstActList.SelectedIndex + Amount)
        lstActList.Items(lstActList.SelectedIndex + Amount) = tmpS

        Dim tmpAB As psActions.psActionBehavior
        tmpAB = Game.actions.Dat.ab(CurAct)
        Game.actions.Dat.ab(CurAct) = Game.actions.Dat.ab(CurAct + Amount)
        Game.actions.Dat.ab(CurAct + Amount) = tmpAB

        DoNotValidate = False
        DoNotValidate2 = False

        CurAct = CurAct + Amount
        lstActList.SelectedIndex = lstActList.SelectedIndex + Amount

        CompareWithDefault()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If CanEditTriggers = False Then
            If TabControl1.SelectedIndex = 1 Then
                lblNotice.Visible = True
            Else
                lblNotice.Visible = False
            End If
        End If
    End Sub

    Private Sub psfrmActionData_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DialogResult = DialogResult.Cancel Then
            Game.actions = tmpAct.Clone
        End If
    End Sub

    Private Sub txtActCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActCode.TextChanged
        If CurAct = 0 Then Exit Sub
        Game.actions.Dat.ab(CurAct).Code = txtActCode.Text
        CompareWithDefault()
    End Sub

    Private Sub txtActName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActName.TextChanged
        If CurAct = 0 Then Exit Sub
        Game.actions.Dat.ab(CurAct).Name = txtActName.Text
        CompareWithDefault()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If lstActList.SelectedIndices.Count = 0 Then Exit Sub
        Dim tmpAct As psActions.psActionBehavior
        tmpAct = Game.actions.Dat.ab(CurAct).Clone
        btnActAdd_Click(Nothing, Nothing)
        Game.actions.Dat.ab(UBound(Game.actions.Dat.ab)) = tmpAct
        DoNotValidate3 = True
        lstActList_SelectedIndexChanged(Nothing, Nothing)
        DoNotValidate3 = False
        DoNotValidate = True
        lstActList.Items(lstActList.Items.Count - 1) = tmpAct.Name
        DoNotValidate = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Game.actions = tmpAct.Clone
        Game.actions.Dat = DefaultActData.Clone
        psfrmActionData_Load(Nothing, Nothing)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class