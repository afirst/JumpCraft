Public Class frmGameProperties
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.TabPage1.Text = GetString("gameProperties_GeneralTab")
        Me.GroupBox6.Text = GetString("gameProperties_OptimizeFrame")
        Me.CheckBox5.Text = GetString("gameProperties_CollisionCheck")
        Me.GroupBox1.Text = GetString("gameProperties_InfoFrame")
        Me.Button12.Text = GetString("gameProperties_ClearFileButton")
        Me.Label14.Text = GetString("gameProperties_IconLabel")
        Me.Label6.Text = GetString("gameProperties_EmailLabel")
        Me.Label5.Text = GetString("gameProperties_WebsiteLabel")
        Me.Label4.Text = GetString("gameProperties_CompanyLabel")
        Me.Label3.Text = GetString("gameProperties_CreditsLabel")
        Me.Label2.Text = GetString("gameProperties_VersionLabel")
        Me.Label1.Text = GetString("gameProperties_NameOfGameLabel")
        Me.TabPage2.Text = GetString("gameProperties_FilesTab")
        Me.GroupBox2.Text = GetString("gameProperties_FilesFrame")
        Me.Button10.Text = GetString("gameProperties_RemoveFileButton")
        Me.Button9.Text = GetString("gameProperties_AddFileButton")
        Me.Label10.Text = GetString("gameProperties_OtherFilesLabel")
        Me.Button7.Text = GetString("gameProperties_ClearFileButton")
        Me.TextBox9.Text = GetString1("noValue")
        Me.Label9.Text = GetString("gameProperties_ReadmeLabel")
        Me.Button5.Text = GetString("gameProperties_ClearFileButton")
        Me.TextBox8.Text = GetString1("noValue")
        Me.Label8.Text = GetString("gameProperties_ReleaseNotesLabel")
        Me.Button4.Text = GetString("gameProperties_ClearFileButton")
        Me.TextBox7.Text = GetString1("noValue")
        Me.Label7.Text = GetString("gameProperties_LicenseAgreementLabel")
        Me.TabPage3.Text = GetString("gameProperties_WindowTab")
        Me.GroupBox4.Text = GetString("gameProperties_WindowPropertiesFrame")
        Me.CheckBox4.Text = GetString("gameProperties_IncludeWebsiteCheckbox")
        Me.CheckBox3.Text = GetString("gameProperties_IncludeAboutCheckbox")
        Me.CheckBox2.Text = GetString("gameProperties_IncludeSupportCheckbox")
        Me.CheckBox1.Text = GetString("gameProperties_MenusCheckbox")
        Me.Label12.Text = GetString("gameProperties_WindowTitleLabel")
        Me.GroupBox3.Text = GetString("gameProperties_ResolutionFrame")
        Me.RadioButton4.Text = GetString("gameProperties_WindowedOption")
        Me.TabPage4.Text = GetString("gameProperties_FileInfoTab")
        Me.GroupBox5.Text = GetString("gameProperties_FileInformationFrame")
        Me.Label29.Text = GetString("gameProperties_TotalLocationsLabel")
        Me.Label27.Text = GetString("gameProperties_TotalControlsLabel")
        Me.Label25.Text = GetString("gameProperties_TotalMapTilesLabel")
        Me.Label23.Text = GetString("gameProperties_TotalWindowsLabel")
        Me.Label21.Text = GetString("gameProperties_TotalTimersLabel")
        Me.Label19.Text = GetString("gameProperties_TotalCountersLabel")
        Me.Label17.Text = GetString("gameProperties_TotalActionsLabel")
        Me.Label15.Text = GetString("gameProperties_TotalTilesLabel")
        Me.Label13.Text = GetString("gameProperties_TotalLevelsLabel")
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.dlgOpen.Title = GetString("selectAFileDialogTitle")
        Me.Text = GetString("gameProperties_Title")
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
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblLevels As System.Windows.Forms.Label
    Friend WithEvents lblTiles As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblActions As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblCounters As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblTimers As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblWindows As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblMapTiles As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblControls As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblLocations As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtIcon As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.txtIcon = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblLocations = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lblControls = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.lblMapTiles = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblWindows = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lblTimers = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblCounters = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblActions = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblTiles = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblLevels = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(344, 352)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(336, 326)
        Me.TabPage1.TabIndex = 0

        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button11)
        Me.GroupBox6.Controls.Add(Me.CheckBox5)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 264)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(320, 56)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
      
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(240, 20)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(32, 24)
        Me.Button11.TabIndex = 1
        Me.Button11.Text = "?"
        '
        'CheckBox5
        '
        Me.CheckBox5.Location = New System.Drawing.Point(16, 24)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(248, 16)
        Me.CheckBox5.TabIndex = 0
        
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.txtIcon)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 256)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False

        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(292, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(250, 72)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(40, 20)
        Me.Button12.TabIndex = 15
        
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(226, 72)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(24, 20)
        Me.Button13.TabIndex = 14
        Me.Button13.Text = "..."
        '
        'txtIcon
        '
        Me.txtIcon.Location = New System.Drawing.Point(96, 72)
        Me.txtIcon.Name = "txtIcon"
        Me.txtIcon.ReadOnly = True
        Me.txtIcon.Size = New System.Drawing.Size(130, 20)
        Me.txtIcon.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 12
        
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(96, 224)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(216, 20)
        Me.TextBox6.TabIndex = 11
        Me.TextBox6.Text = "support@mywebsite.com"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(96, 200)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(216, 20)
        Me.TextBox5.TabIndex = 9
        Me.TextBox5.Text = "http://www.mywebsite.com"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(96, 176)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(216, 20)
        Me.TextBox4.TabIndex = 7
        Me.TextBox4.Text = "MyCompany, Inc."
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(96, 96)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(216, 76)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.Text = "Created by MyName" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Powered by JumpCraft"
        Me.TextBox3.WordWrap = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(96, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(130, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "1.0"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "My Game"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 10

        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 16)
        Me.Label5.TabIndex = 8
        
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 6

        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 4
       
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 2

        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(336, 326)
        Me.TabPage2.TabIndex = 1

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Button7)
        Me.GroupBox2.Controls.Add(Me.Button8)
        Me.GroupBox2.Controls.Add(Me.TextBox9)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TextBox7)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 320)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
    
        '
        'Button10
        '
        Me.Button10.Enabled = False
        Me.Button10.Location = New System.Drawing.Point(216, 288)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(64, 24)
        Me.Button10.TabIndex = 15

        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(144, 288)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(64, 24)
        Me.Button9.TabIndex = 14
        
        '
        'ListBox1
        '
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(112, 120)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(200, 160)
        Me.ListBox1.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 16)
        Me.Label10.TabIndex = 12

        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(272, 88)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(40, 20)
        Me.Button7.TabIndex = 11
   
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(248, 88)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(24, 20)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "..."
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(112, 88)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(136, 20)
        Me.TextBox9.TabIndex = 9

        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 16)
        Me.Label9.TabIndex = 8

        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(272, 56)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 20)
        Me.Button5.TabIndex = 7
        
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(248, 56)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(24, 20)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "..."
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(112, 56)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(136, 20)
        Me.TextBox8.TabIndex = 5

        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 16)
        Me.Label8.TabIndex = 4
    
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(272, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 20)
        Me.Button4.TabIndex = 3

        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(248, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 20)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(112, 24)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(136, 20)
        Me.TextBox7.TabIndex = 1
        
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 16)
        Me.Label7.TabIndex = 0
        
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(336, 326)
        Me.TabPage3.TabIndex = 2
        
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox4)
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.Controls.Add(Me.CheckBox2)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.TextBox12)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 144)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(320, 176)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False

        '
        'CheckBox4
        '
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(24, 96)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(144, 16)
        Me.CheckBox4.TabIndex = 4
      
        '
        'CheckBox3
        '
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(24, 116)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(144, 16)
        Me.CheckBox3.TabIndex = 5

        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(24, 76)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(144, 16)
        Me.CheckBox2.TabIndex = 3
        
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(8, 56)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(136, 16)
        Me.CheckBox1.TabIndex = 2
        
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(88, 24)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(224, 20)
        Me.TextBox12.TabIndex = 1
        Me.TextBox12.Text = "MyGame Version 1.0"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 16)
        Me.Label12.TabIndex = 0
        
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.TextBox11)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TextBox10)
        Me.GroupBox3.Controls.Add(Me.RadioButton4)
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(320, 136)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(8, 24)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.Text = "320x240"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(152, 104)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(32, 20)
        Me.TextBox11.TabIndex = 6
        Me.TextBox11.Text = "480"
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(136, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(8, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "x"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(96, 104)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(32, 20)
        Me.TextBox10.TabIndex = 4
        Me.TextBox10.Text = "640"
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(8, 104)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
    
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(8, 84)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "1024x768"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(8, 64)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "800x600"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(8, 44)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "640x480"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(336, 326)
        Me.TabPage4.TabIndex = 3

        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblLocations)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.lblControls)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.lblMapTiles)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.lblWindows)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.lblTimers)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.lblCounters)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.lblActions)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.lblTiles)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.lblLevels)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(320, 320)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        
        '
        'lblLocations
        '
        Me.lblLocations.Location = New System.Drawing.Point(112, 96)
        Me.lblLocations.Name = "lblLocations"
        Me.lblLocations.Size = New System.Drawing.Size(80, 16)
        Me.lblLocations.TabIndex = 17
        Me.lblLocations.Text = "0"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 96)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(152, 16)
        Me.Label29.TabIndex = 16
        
        '
        'lblControls
        '
        Me.lblControls.Location = New System.Drawing.Point(112, 216)
        Me.lblControls.Name = "lblControls"
        Me.lblControls.Size = New System.Drawing.Size(80, 16)
        Me.lblControls.TabIndex = 15
        Me.lblControls.Text = "0"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 216)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(152, 16)
        Me.Label27.TabIndex = 14
        
        '
        'lblMapTiles
        '
        Me.lblMapTiles.Location = New System.Drawing.Point(112, 72)
        Me.lblMapTiles.Name = "lblMapTiles"
        Me.lblMapTiles.Size = New System.Drawing.Size(80, 16)
        Me.lblMapTiles.TabIndex = 13
        Me.lblMapTiles.Text = "0"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(8, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(152, 16)
        Me.Label25.TabIndex = 12

        '
        'lblWindows
        '
        Me.lblWindows.Location = New System.Drawing.Point(112, 192)
        Me.lblWindows.Name = "lblWindows"
        Me.lblWindows.Size = New System.Drawing.Size(80, 16)
        Me.lblWindows.TabIndex = 11
        Me.lblWindows.Text = "0"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 192)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(152, 16)
        Me.Label23.TabIndex = 10
    
        '
        'lblTimers
        '
        Me.lblTimers.Location = New System.Drawing.Point(112, 168)
        Me.lblTimers.Name = "lblTimers"
        Me.lblTimers.Size = New System.Drawing.Size(80, 16)
        Me.lblTimers.TabIndex = 9
        Me.lblTimers.Text = "0"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 168)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 8

        '
        'lblCounters
        '
        Me.lblCounters.Location = New System.Drawing.Point(112, 144)
        Me.lblCounters.Name = "lblCounters"
        Me.lblCounters.Size = New System.Drawing.Size(80, 16)
        Me.lblCounters.TabIndex = 7
        Me.lblCounters.Text = "0"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 144)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 16)
        Me.Label19.TabIndex = 6
        
        '
        'lblActions
        '
        Me.lblActions.Location = New System.Drawing.Point(112, 120)
        Me.lblActions.Name = "lblActions"
        Me.lblActions.Size = New System.Drawing.Size(80, 16)
        Me.lblActions.TabIndex = 5
        Me.lblActions.Text = "0"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 16)
        Me.Label17.TabIndex = 4
        
        '
        'lblTiles
        '
        Me.lblTiles.Location = New System.Drawing.Point(112, 24)
        Me.lblTiles.Name = "lblTiles"
        Me.lblTiles.Size = New System.Drawing.Size(80, 16)
        Me.lblTiles.TabIndex = 3
        Me.lblTiles.Text = "0"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 16)
        Me.Label15.TabIndex = 2
        
        '
        'lblLevels
        '
        Me.lblLevels.Location = New System.Drawing.Point(112, 48)
        Me.lblLevels.Name = "lblLevels"
        Me.lblLevels.Size = New System.Drawing.Size(80, 16)
        Me.lblLevels.TabIndex = 1
        Me.lblLevels.Text = "0"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 16)
        Me.Label13.TabIndex = 0

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(280, 368)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2
        
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(200, 368)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1
        
        '
        'dlgOpen
        '
        
        '
        'frmGameProperties
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 401)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGameProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox2.Enabled = CheckBox1.Checked
        CheckBox4.Enabled = CheckBox1.Checked
        CheckBox3.Enabled = CheckBox1.Checked
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        CheckBox1.Enabled = RadioButton4.Checked
        CheckBox2.Enabled = RadioButton4.Checked
        CheckBox4.Enabled = RadioButton4.Checked
        CheckBox3.Enabled = RadioButton4.Checked
        TextBox10.Enabled = RadioButton4.Checked
        Label11.Enabled = RadioButton4.Checked
        TextBox11.Enabled = RadioButton4.Checked
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox7.Text = GetString1("noValue")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox8.Text = GetString1("noValue")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox9.Text = GetString1("noValue")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dlgOpen.FileName = TextBox7.Text
        dlgOpen.Filter = GetString("richTextFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        TextBox7.Text = dlgOpen.FileName
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        dlgOpen.FileName = TextBox8.Text
        dlgOpen.Filter = GetString("richTextFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        TextBox8.Text = dlgOpen.FileName
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        dlgOpen.FileName = TextBox9.Text
        dlgOpen.Filter = GetString("richTextFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        TextBox9.Text = dlgOpen.FileName
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        dlgOpen.Filter = GetString("allFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        ListBox1.Items.Add(dlgOpen.FileName)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Button10.Enabled = (ListBox1.SelectedIndex > -1)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
    End Sub

    Private Sub frmGameProperties_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Editor.psedit.Deselect()

        Dim i As Integer
        With Game.GameProperties
            'General
            '
            TextBox1.Text = .Name
            TextBox2.Text = .Version
            txtIcon.Text = .Icon
            If IO.File.Exists(.Icon) Then
                PictureBox1.Image = New Icon(.Icon).ToBitmap
            Else
                PictureBox1.Image = SystemIcons.Application.ToBitmap
            End If
            TextBox3.Text = .Credits
            TextBox4.Text = .Company
            TextBox5.Text = .Website
            TextBox6.Text = .Support
            CheckBox5.Checked = .NoPixelPerfect
            '
            'Files
            '
            TextBox7.Text = .fLicenseAgrmt
            TextBox8.Text = .fReleaseNotes
            TextBox9.Text = .fReadme
            For i = 1 To UBound(.fOtherFiles)
                ListBox1.Items.Add(.fOtherFiles(i))
            Next
            '
            'Window
            '
            If .Windowed Then
                RadioButton4.Checked = True
            Else
                If .ResWidth = 320 Then
                    RadioButton5.Checked = True
                ElseIf .ResWidth = 640 Then
                    RadioButton1.Checked = True
                ElseIf .ResWidth = 800 Then
                    RadioButton2.Checked = True
                Else
                    RadioButton3.Checked = True
                End If
            End If
            TextBox10.Text = .ResWidth
            TextBox11.Text = .ResHeight
            TextBox12.Text = .WindowTitle
            CheckBox1.Checked = .Menus
            CheckBox2.Checked = .mnuSupport
            CheckBox4.Checked = .mnuWebsite
            CheckBox3.Checked = .mnuAbout
        End With
        '
        'File Properties
        '
        lblTiles.Text = Game.tileset.NumTiles
        lblLevels.Text = Game.numMaps
        lblMapTiles.Text = GetNumMapTiles()
        lblLocations.Text = GetNumLocations()
        lblActions.Text = UBound(Game.actions.Actions)
        lblCounters.Text = UBound(Game.actions.Counters)
        lblTimers.Text = UBound(Game.actions.Timers)
        lblWindows.Text = Game.numWindows
        lblControls.Text = GetNumControls()
    End Sub

    Function GetNumMapTiles() As Integer
        Dim i As Integer, j As Integer, k As Integer
        Dim counter As Integer
        For i = 1 To Game.numMaps
            For j = 0 To 3
                For k = 1 To Game.maps(i).MapSize1D
                    If Game.maps(i).Cells1D(k, j) > 0 Then counter += 1
                Next
            Next
        Next
        Return counter
    End Function

    Function GetNumLocations() As Integer
        Dim i As Integer, counter As Integer
        For i = 1 To Game.numMaps
            counter += Game.maps(i).loc.NumLocations
        Next
        Return counter
    End Function

    Function GetNumControls() As Integer
        Dim i As Integer, counter As Integer
        For i = 1 To Game.numWindows
            counter += Game.windows.Windows(i).NumCtrls
        Next
        Return counter
    End Function

    Private Sub TextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating
        ConvertToNumber(TextBox10, 200, 1024, 640)
    End Sub

    Private Sub TextBox11_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox11.Validating
        ConvertToNumber(TextBox11, 200, 768, 480)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        With Game.GameProperties
            'General
            '
            .Name = TextBox1.Text
            .Version = TextBox2.Text
            .Icon = txtIcon.Text
            .Credits = TextBox3.Text
            .Company = TextBox4.Text
            .Website = TextBox5.Text
            .Support = TextBox6.Text
            .NoPixelPerfect = CheckBox5.Checked
            '
            'Files
            '
            .fLicenseAgrmt = TextBox7.Text
            .fReleaseNotes = TextBox8.Text
            .fReadme = TextBox9.Text
            ReDim .fOtherFiles(ListBox1.Items.Count)
            For i = 1 To UBound(.fOtherFiles)
                .fOtherFiles(i) = ListBox1.Items(i - 1)
            Next
            '
            'Window
            '
            Select Case True
                Case RadioButton5.Checked
                    .Windowed = False
                    .ResWidth = 320
                    .ResHeight = 240
                Case RadioButton1.Checked
                    .Windowed = False
                    .ResWidth = 640
                    .ResHeight = 480
                Case RadioButton2.Checked
                    .Windowed = False
                    .ResWidth = 800
                    .ResHeight = 600
                Case RadioButton3.Checked
                    .Windowed = False
                    .ResWidth = 1024
                    .ResHeight = 768
                Case RadioButton4.Checked
                    .Windowed = True
                    .ResWidth = TextBox10.Text
                    .ResHeight = TextBox11.Text
            End Select
            .WindowTitle = TextBox12.Text
            Game.windows.Width = .ResWidth
            Game.windows.Height = .ResHeight
            .Menus = CheckBox1.Checked
            .mnuSupport = CheckBox2.Checked
            .mnuWebsite = CheckBox4.Checked
            .mnuAbout = CheckBox3.Checked
        End With
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim f As New frmHelpCollision
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        dlgOpen.Filter = GetString("iconFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        Try
            PictureBox1.Image = New Icon(dlgOpen.FileName).ToBitmap
            txtIcon.Text = dlgOpen.FileName
        Catch
            MessageBox.Show(GetString("gameProperties_InvalidIconFileMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        txtIcon.Text = GetString1("defaultValue")
        PictureBox1.Image = SystemIcons.Application.ToBitmap
    End Sub
End Class