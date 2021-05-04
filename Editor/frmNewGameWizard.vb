Imports PlatformStudio

Public Class frmNewGameWizard
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.chkBlank.Text = GetString("newGameWizard_NewBlankGameCheck")
        Me.Label7.Text = GetString("newGameWizard_InstructionText")
        Me.Label6.Text = GetString("newGameWizard_WizardInfo")
        Me.Label5.Text = GetString("newGameWizard_WelcomeText")
        Me.btnNext.Text = GetString("newGameWizard_NextButton")
        Me.GroupBox3.Text = GetString("gameProperties_ResolutionFrame")
        Me.RadioButton4.Text = GetString("gameProperties_WindowedOption")
        Me.dlgOpen.Title = GetString("selectAFileDialogTitle")
        Me.btnCancel.Text = GetString("cancelButton")
        Me.btnBack.Text = GetString("newGameWizard_BackButton")
        Me.h2.Text = GetString("newGameWizard_GameInformationSubheading")
        Me.h1.Text = GetString("newGameWizard_GameInformationHeading")
        Me.Label11.Text = GetString("newGameWizard_GameInformationNote")
        Me.TextBox6.Text = GetString1("defaultSupportEmail")
        Me.TextBox5.Text = GetString1("defaultWebsite")
        Me.TextBox4.Text = GetString1("defaultCompany")
        Me.TextBox3.Text = GetString1("defaultCredits")
        Me.Label12.Text = GetString("gameProperties_EmailLabel")
        Me.Label13.Text = GetString("gameProperties_WebsiteLabel")
        Me.Label14.Text = GetString("gameProperties_CompanyLabel")
        Me.Label15.Text = GetString("gameProperties_CreditsLabel")
        Me.TextBox1.Text = GetString1("defaultGameName")
        Me.Label10.Text = GetString("gameProperties_NameOfGameLabel")
        Me.Label8.Text = GetString("newGameWizard_FinishText")
        Me.Label9.Text = GetString("newGameWizard_FinishedText")
        Me.Label22.Text = GetString("newGameWizard_DefaultBackgroundLabel")
        Me.Label19.Text = GetString("tilesUnit")
        Me.Label17.Text = GetString("newGameWizard_DefaultLevelSizeLabel")
        Me.Button2.Text = GetString("newGameWizard_RemoveLevelButton")
        Me.Button1.Text = GetString("newGameWizard_AddLevelButton")
        Me.Label16.Text = GetString("newGameWizard_SelectedLevelNameLabel")
        Me.Label21.Text = GetString("newGameWizard_LevelNameLabel")
        Me.Label27.Text = GetString("newGameWizard_ColorSchemeLabel")
        Me.Label28.Text = GetString("newGameWizard_DefaultBackgroundLabel")
        Me.Label26.Text = GetString("newGameWizard_DefaultMenuButtonLabel")
        Me.Label25.Text = GetString("newGameWizard_MenuLabelLabel")
        Me.Label20.Text = GetString("newGameWizard_DefaultGameButtonLabel")
        Me.grpAOpt.Text = GetString("newGameWizard_WindowOptionsFrame")
        Me.chkSptBtn.Text = GetString("newGameWizard_SupportButtonCheckbox")
        Me.chkWebBtn.Text = GetString("newGameWizard_WebsiteButtonCheckbox")
        Me.btnHTxt.Text = GetString("newGameWizard_EditHelpTextButton")
        Me.optHFile.Text = GetString("newGameWizard_ExternalHelpFileOption")
        Me.optHWin.Text = GetString("newGameWizard_HelpWindowOption")
        Me.Label31.Text = GetString("newGameWizard_HelpStyleLabel")
        Me.optAWin.Text = GetString("newGameWizard_AboutWindowOption")
        Me.optAMsg.Text = GetString("newGameWizard_AboutMessageDialogOption")
        Me.Label32.Text = GetString("newGameWizard_AboutStyleLabel")
        Me.GroupBox4.Text = GetString("gameProperties_WindowPropertiesFrame")
        Me.CheckBox4.Text = GetString("gameProperties_IncludeWebsiteCheckbox")
        Me.CheckBox3.Text = GetString("gameProperties_IncludeAboutCheckbox")
        Me.CheckBox2.Text = GetString("gameProperties_IncludeSupportCheckbox")
        Me.CheckBox1.Text = GetString("gameProperties_MenusCheckbox")
        Me.TextBox12.Text = GetString1("defaultGameWithVersion")
        Me.Label23.Text = GetString("gameProperties_WindowTitleLabel")
        Me.dlgOpen.Filter = GetString("helpFileFilter")
        Me.Text = GetString("newGameWizard_Title")
        Me.cboBackgrnd.Items.AddRange(New Object() {GetString("newGameWizard_Background_Day"), GetString("newGameWizard_Background_Night"), GetString("newGameWizard_Background_Gloomy"), GetString("newGameWizard_Background_Black"), GetString("newGameWizard_Background_Custom")})
        Me.cboColorScheme.Items.AddRange(New Object() {GetString("newGameWizard_Colors_Blue"), GetString("newGameWizard_Colors_Green"), GetString("newGameWizard_Colors_Orange"), GetString("newGameWizard_Colors_DarkGray"), GetString("newGameWizard_Colors_LightGray"), GetString("newGameWizard_Colors_Purple"), GetString("newGameWizard_Colors_Red"), GetString("newGameWizard_Colors_Earth"), GetString("newGameWizard_Colors_Aqua"), GetString("newGameWizard_Colors_BlackWhite"), GetString("newGameWizard_Colors_BlackBlue"), GetString("newGameWizard_Colors_BlackOrange"), GetString("newGameWizard_Colors_BlackYellow"), GetString("newGameWizard_Colors_BlackGreen"), GetString("newGameWizard_Colors_WhiteBlack"), GetString("newGameWizard_Colors_WhiteBlue"), GetString("newGameWizard_Colors_WhiteGreen"), GetString("newGameWizard_Colors_WhiteOrange"), GetString("newGameWizard_Colors_WhiteRed"), GetString("newGameWizard_Colors_WhiteMagenta")})
        DynamicReadOnly.SetValue("ButtonWrapper.Action", True)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pTop As System.Windows.Forms.Panel
    Friend WithEvents h1 As System.Windows.Forms.Label
    Friend WithEvents h2 As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Public WithEvents p2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents pLast As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents p3 As System.Windows.Forms.Panel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboBackgrnd As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents picTrans As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboColorScheme As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkSptBtn As System.Windows.Forms.CheckBox
    Friend WithEvents chkWebBtn As System.Windows.Forms.CheckBox
    Friend WithEvents btnHTxt As System.Windows.Forms.Button
    Friend WithEvents optHWin As System.Windows.Forms.RadioButton
    Friend WithEvents optAWin As System.Windows.Forms.RadioButton
    Friend WithEvents optAMsg As System.Windows.Forms.RadioButton
    Friend WithEvents btnHFile As System.Windows.Forms.Button
    Friend WithEvents txtHFile As System.Windows.Forms.TextBox
    Friend WithEvents optHFile As System.Windows.Forms.RadioButton
    Public WithEvents p5 As System.Windows.Forms.Panel
    Public WithEvents p6 As System.Windows.Forms.Panel
    Public WithEvents p4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents chkBlank As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents grpAOpt As System.Windows.Forms.GroupBox
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ctlprop As psControlProperties
    Friend WithEvents sel As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNewGameWizard))
        Me.p1 = New System.Windows.Forms.Panel
        Me.chkBlank = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.pTop = New System.Windows.Forms.Panel
        Me.h2 = New System.Windows.Forms.Label
        Me.h1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.p2 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pLast = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.p3 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cboBackgrnd = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.picTrans = New System.Windows.Forms.PictureBox
        Me.p5 = New System.Windows.Forms.Panel
        Me.RadioButton8 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.Button3 = New System.Windows.Forms.Button
        Me.ctlprop = New psControlProperties
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.cboColorScheme = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.sel = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.p6 = New System.Windows.Forms.Panel
        Me.grpAOpt = New System.Windows.Forms.GroupBox
        Me.chkSptBtn = New System.Windows.Forms.CheckBox
        Me.chkWebBtn = New System.Windows.Forms.CheckBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnHTxt = New System.Windows.Forms.Button
        Me.btnHFile = New System.Windows.Forms.Button
        Me.txtHFile = New System.Windows.Forms.TextBox
        Me.optHFile = New System.Windows.Forms.RadioButton
        Me.optHWin = New System.Windows.Forms.RadioButton
        Me.Label31 = New System.Windows.Forms.Label
        Me.optAWin = New System.Windows.Forms.RadioButton
        Me.optAMsg = New System.Windows.Forms.RadioButton
        Me.Label32 = New System.Windows.Forms.Label
        Me.p4 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.p1.SuspendLayout()
        Me.pTop.SuspendLayout()
        Me.p2.SuspendLayout()
        Me.pLast.SuspendLayout()
        Me.p3.SuspendLayout()
        Me.p5.SuspendLayout()
        Me.p6.SuspendLayout()
        Me.grpAOpt.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.p4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.SystemColors.Window
        Me.p1.Controls.Add(Me.chkBlank)
        Me.p1.Controls.Add(Me.Label7)
        Me.p1.Controls.Add(Me.Label6)
        Me.p1.Controls.Add(Me.Label5)
        Me.p1.Location = New System.Drawing.Point(0, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(594, 362)
        Me.p1.TabIndex = 1
        '
        'chkBlank
        '
        Me.chkBlank.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkBlank.Location = New System.Drawing.Point(211, 332)
        Me.chkBlank.Name = "chkBlank"
        Me.chkBlank.Size = New System.Drawing.Size(346, 19)
        Me.chkBlank.TabIndex = 4


        '
        'Label7
        '
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label7.Location = New System.Drawing.Point(211, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(365, 65)
        Me.Label7.TabIndex = 3
        
        '
        'Label6
        '
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label6.Location = New System.Drawing.Point(211, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(365, 111)
        Me.Label6.TabIndex = 2

        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(211, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(375, 56)
        Me.Label5.TabIndex = 1

        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(0, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(594, 1)
        Me.Label1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(0, 363)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(594, 2)
        Me.Label2.TabIndex = 3
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnNext.Location = New System.Drawing.Point(384, 375)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(89, 27)
        Me.btnNext.TabIndex = 4

        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnCancel.Location = New System.Drawing.Point(490, 375)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 27)
        Me.btnCancel.TabIndex = 5
        


        '
        'btnBack
        '
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnBack.Location = New System.Drawing.Point(290, 375)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(89, 27)
        Me.btnBack.TabIndex = 6

        Me.btnBack.Visible = False
        '
        'pTop
        '
        Me.pTop.BackColor = System.Drawing.SystemColors.Window
        Me.pTop.Controls.Add(Me.h2)
        Me.pTop.Controls.Add(Me.h1)
        Me.pTop.Controls.Add(Me.PictureBox2)
        Me.pTop.Controls.Add(Me.Label3)
        Me.pTop.Controls.Add(Me.Label4)
        Me.pTop.Location = New System.Drawing.Point(0, 0)
        Me.pTop.Name = "pTop"
        Me.pTop.Size = New System.Drawing.Size(594, 69)
        Me.pTop.TabIndex = 7
        Me.pTop.Visible = False
        '
        'h2
        '
        Me.h2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.h2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.h2.Location = New System.Drawing.Point(34, 35)
        Me.h2.Name = "h2"
        Me.h2.Size = New System.Drawing.Size(475, 18)
        Me.h2.TabIndex = 8

        '
        'h1
        '
        Me.h1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.h1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.h1.Location = New System.Drawing.Point(14, 14)
        Me.h1.Name = "h1"
        Me.h1.Size = New System.Drawing.Size(495, 14)
        Me.h1.TabIndex = 7

        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(538, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(57, 65)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(0, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(594, 1)
        Me.Label3.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label4.Location = New System.Drawing.Point(0, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(594, 1)
        Me.Label4.TabIndex = 4
        '
        'p2
        '
        Me.p2.Controls.Add(Me.Label11)
        Me.p2.Controls.Add(Me.TextBox6)
        Me.p2.Controls.Add(Me.TextBox5)
        Me.p2.Controls.Add(Me.TextBox4)
        Me.p2.Controls.Add(Me.TextBox3)
        Me.p2.Controls.Add(Me.Label12)
        Me.p2.Controls.Add(Me.Label13)
        Me.p2.Controls.Add(Me.Label14)
        Me.p2.Controls.Add(Me.Label15)
        Me.p2.Controls.Add(Me.TextBox1)
        Me.p2.Controls.Add(Me.Label10)
        Me.p2.Location = New System.Drawing.Point(0, 69)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(595, 294)
        Me.p2.TabIndex = 8
        Me.p2.Visible = False
        '
        'Label11
        '
        Me.Label11.Enabled = False
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(29, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(518, 32)
        Me.Label11.TabIndex = 20

        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(154, 222)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(355, 22)
        Me.TextBox6.TabIndex = 19

        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(154, 185)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(355, 22)
        Me.TextBox5.TabIndex = 17

        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(154, 148)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(355, 22)
        Me.TextBox4.TabIndex = 15

        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(154, 46)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(355, 88)
        Me.TextBox3.TabIndex = 13

        Me.TextBox3.WordWrap = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(29, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 18)
        Me.Label12.TabIndex = 18

        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(29, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(173, 18)
        Me.Label13.TabIndex = 16

        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(29, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(173, 18)
        Me.Label14.TabIndex = 14

        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(29, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 19)
        Me.Label15.TabIndex = 12

        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(154, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(355, 22)
        Me.TextBox1.TabIndex = 1

        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(29, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(182, 19)
        Me.Label10.TabIndex = 0

        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(197, 362)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'pLast
        '
        Me.pLast.BackColor = System.Drawing.SystemColors.Window
        Me.pLast.Controls.Add(Me.Label8)
        Me.pLast.Controls.Add(Me.Label9)
        Me.pLast.Location = New System.Drawing.Point(0, 0)
        Me.pLast.Name = "pLast"
        Me.pLast.Size = New System.Drawing.Size(594, 362)
        Me.pLast.TabIndex = 10
        Me.pLast.Visible = False
        '
        'Label8
        '
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label8.Location = New System.Drawing.Point(211, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(365, 64)
        Me.Label8.TabIndex = 3

        '
        'Label9
        '
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label9.Location = New System.Drawing.Point(211, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(365, 102)
        Me.Label9.TabIndex = 2

        '
        'p3
        '
        Me.p3.Controls.Add(Me.PictureBox3)
        Me.p3.Controls.Add(Me.cboBackgrnd)
        Me.p3.Controls.Add(Me.Label22)
        Me.p3.Controls.Add(Me.Label19)
        Me.p3.Controls.Add(Me.TextBox8)
        Me.p3.Controls.Add(Me.Label18)
        Me.p3.Controls.Add(Me.TextBox7)
        Me.p3.Controls.Add(Me.Label17)
        Me.p3.Controls.Add(Me.Button4)
        Me.p3.Controls.Add(Me.Button5)
        Me.p3.Controls.Add(Me.Button2)
        Me.p3.Controls.Add(Me.Button1)
        Me.p3.Controls.Add(Me.TextBox2)
        Me.p3.Controls.Add(Me.Label16)
        Me.p3.Controls.Add(Me.ListBox1)
        Me.p3.Controls.Add(Me.Label21)
        Me.p3.Location = New System.Drawing.Point(0, 69)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(595, 294)
        Me.p3.TabIndex = 11
        Me.p3.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(336, 240)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 24)
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        '
        'cboBackgrnd
        '
        Me.cboBackgrnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackgrnd.Location = New System.Drawing.Point(154, 240)
        Me.cboBackgrnd.Name = "cboBackgrnd"
        Me.cboBackgrnd.Size = New System.Drawing.Size(182, 24)
        Me.cboBackgrnd.TabIndex = 34
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(29, 240)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 18)
        Me.Label22.TabIndex = 33

        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(264, 203)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 19)
        Me.Label19.TabIndex = 31

        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(212, 203)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(48, 22)
        Me.TextBox8.TabIndex = 30
        Me.TextBox8.Text = "32"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(202, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(19, 19)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "x"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(154, 203)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(48, 22)
        Me.TextBox7.TabIndex = 28
        Me.TextBox7.Text = "64"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(29, 203)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 19)
        Me.Label17.TabIndex = 27

        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(346, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(38, 37)
        Me.Button4.TabIndex = 25
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(346, 55)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(38, 37)
        Me.Button5.TabIndex = 26
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(250, 129)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 28)
        Me.Button2.TabIndex = 24

        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(154, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 28)
        Me.Button1.TabIndex = 23

        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(154, 166)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(182, 22)
        Me.TextBox2.TabIndex = 22
        Me.TextBox2.Text = ""
        '
        'Label16
        '
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(29, 166)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 19)
        Me.Label16.TabIndex = 21

        '
        'ListBox1
        '
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Items.AddRange(New Object() {"Level 1"})
        Me.ListBox1.Location = New System.Drawing.Point(154, 9)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(182, 111)
        Me.ListBox1.TabIndex = 20
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(29, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(182, 19)
        Me.Label21.TabIndex = 0

        '
        'picTrans
        '
        Me.picTrans.Image = CType(resources.GetObject("picTrans.Image"), System.Drawing.Image)
        Me.picTrans.Location = New System.Drawing.Point(250, 378)
        Me.picTrans.Name = "picTrans"
        Me.picTrans.Size = New System.Drawing.Size(19, 19)
        Me.picTrans.TabIndex = 12
        Me.picTrans.TabStop = False
        Me.picTrans.Visible = False
        '
        'p5
        '
        Me.p5.Controls.Add(Me.RadioButton8)
        Me.p5.Controls.Add(Me.RadioButton7)
        Me.p5.Controls.Add(Me.RadioButton6)
        Me.p5.Controls.Add(Me.Button3)
        Me.p5.Controls.Add(Me.ctlprop)
        Me.p5.Controls.Add(Me.PictureBox7)
        Me.p5.Controls.Add(Me.PictureBox6)
        Me.p5.Controls.Add(Me.PictureBox5)
        Me.p5.Controls.Add(Me.PictureBox4)
        Me.p5.Controls.Add(Me.cboColorScheme)
        Me.p5.Controls.Add(Me.Label27)
        Me.p5.Controls.Add(Me.sel)
        Me.p5.Controls.Add(Me.Label28)
        Me.p5.Controls.Add(Me.Label26)
        Me.p5.Controls.Add(Me.Label25)
        Me.p5.Controls.Add(Me.Label20)
        Me.p5.Location = New System.Drawing.Point(0, 69)
        Me.p5.Name = "p5"
        Me.p5.Size = New System.Drawing.Size(595, 294)
        Me.p5.TabIndex = 13
        Me.p5.Visible = False
        '
        'RadioButton8
        '
        Me.RadioButton8.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton8.Location = New System.Drawing.Point(259, 157)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(16, 15)
        Me.RadioButton8.TabIndex = 63
        Me.RadioButton8.Text = "RadioButton8"
        '
        'RadioButton7
        '
        Me.RadioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton7.Location = New System.Drawing.Point(259, 120)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(16, 15)
        Me.RadioButton7.TabIndex = 62
        Me.RadioButton7.Text = "RadioButton7"
        '
        'RadioButton6
        '
        Me.RadioButton6.Checked = True
        Me.RadioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton6.Location = New System.Drawing.Point(259, 83)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(16, 15)
        Me.RadioButton6.TabIndex = 61
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "RadioButton6"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(250, 46)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 19)
        Me.Button3.TabIndex = 60
        Me.Button3.Text = "..."
        '
        'ctlprop
        '
        Me.ctlprop.Location = New System.Drawing.Point(346, 9)
        Me.ctlprop.Name = "ctlprop"
        Me.ctlprop.Size = New System.Drawing.Size(230, 277)
        Me.ctlprop.TabIndex = 58
        '
        'PictureBox7
        '
        Me.PictureBox7.Location = New System.Drawing.Point(163, 46)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(87, 28)
        Me.PictureBox7.TabIndex = 53
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Location = New System.Drawing.Point(163, 157)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(87, 28)
        Me.PictureBox6.TabIndex = 51
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Location = New System.Drawing.Point(163, 120)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(87, 28)
        Me.PictureBox5.TabIndex = 50
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(163, 83)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(87, 28)
        Me.PictureBox4.TabIndex = 49
        Me.PictureBox4.TabStop = False
        '
        'cboColorScheme
        '
        Me.cboColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorScheme.Location = New System.Drawing.Point(163, 9)
        Me.cboColorScheme.Name = "cboColorScheme"
        Me.cboColorScheme.Size = New System.Drawing.Size(173, 24)
        Me.cboColorScheme.TabIndex = 36
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(29, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(182, 19)
        Me.Label27.TabIndex = 0

        '
        'sel
        '
        Me.sel.BackColor = System.Drawing.SystemColors.Highlight
        Me.sel.Location = New System.Drawing.Point(161, 81)
        Me.sel.Name = "sel"
        Me.sel.Size = New System.Drawing.Size(91, 32)
        Me.sel.TabIndex = 59
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(29, 46)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(144, 19)
        Me.Label28.TabIndex = 52

        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(29, 83)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(144, 19)
        Me.Label26.TabIndex = 21

        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(29, 120)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(125, 18)
        Me.Label25.TabIndex = 27

        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(29, 157)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(134, 18)
        Me.Label20.TabIndex = 33

        '
        'p6
        '
        Me.p6.Controls.Add(Me.grpAOpt)
        Me.p6.Controls.Add(Me.Panel3)
        Me.p6.Controls.Add(Me.Label31)
        Me.p6.Controls.Add(Me.optAWin)
        Me.p6.Controls.Add(Me.optAMsg)
        Me.p6.Controls.Add(Me.Label32)
        Me.p6.Location = New System.Drawing.Point(0, 69)
        Me.p6.Name = "p6"
        Me.p6.Size = New System.Drawing.Size(595, 294)
        Me.p6.TabIndex = 14
        Me.p6.Visible = False
        '
        'grpAOpt
        '
        Me.grpAOpt.Controls.Add(Me.chkSptBtn)
        Me.grpAOpt.Controls.Add(Me.chkWebBtn)
        Me.grpAOpt.Enabled = False
        Me.grpAOpt.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.grpAOpt.Location = New System.Drawing.Point(182, 65)
        Me.grpAOpt.Name = "grpAOpt"
        Me.grpAOpt.Size = New System.Drawing.Size(144, 73)
        Me.grpAOpt.TabIndex = 49
        Me.grpAOpt.TabStop = False

        '
        'chkSptBtn
        '
        Me.chkSptBtn.Checked = True
        Me.chkSptBtn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkSptBtn.Location = New System.Drawing.Point(10, 46)
        Me.chkSptBtn.Name = "chkSptBtn"
        Me.chkSptBtn.Size = New System.Drawing.Size(124, 19)
        Me.chkSptBtn.TabIndex = 48

        '
        'chkWebBtn
        '
        Me.chkWebBtn.Checked = True
        Me.chkWebBtn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWebBtn.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkWebBtn.Location = New System.Drawing.Point(10, 18)
        Me.chkWebBtn.Name = "chkWebBtn"
        Me.chkWebBtn.Size = New System.Drawing.Size(124, 19)
        Me.chkWebBtn.TabIndex = 47

        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnHTxt)
        Me.Panel3.Controls.Add(Me.btnHFile)
        Me.Panel3.Controls.Add(Me.txtHFile)
        Me.Panel3.Controls.Add(Me.optHFile)
        Me.Panel3.Controls.Add(Me.optHWin)
        Me.Panel3.Location = New System.Drawing.Point(154, 148)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(422, 120)
        Me.Panel3.TabIndex = 45
        '
        'btnHTxt
        '
        Me.btnHTxt.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnHTxt.Location = New System.Drawing.Point(29, 28)
        Me.btnHTxt.Name = "btnHTxt"
        Me.btnHTxt.Size = New System.Drawing.Size(105, 23)
        Me.btnHTxt.TabIndex = 48

        '
        'btnHFile
        '
        Me.btnHFile.Enabled = False
        Me.btnHFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnHFile.Location = New System.Drawing.Point(288, 92)
        Me.btnHFile.Name = "btnHFile"
        Me.btnHFile.Size = New System.Drawing.Size(31, 23)
        Me.btnHFile.TabIndex = 46
        Me.btnHFile.Text = "..."
        '
        'txtHFile
        '
        Me.txtHFile.Enabled = False
        Me.txtHFile.Location = New System.Drawing.Point(29, 92)
        Me.txtHFile.Name = "txtHFile"
        Me.txtHFile.ReadOnly = True
        Me.txtHFile.Size = New System.Drawing.Size(259, 22)
        Me.txtHFile.TabIndex = 45
        Me.txtHFile.Text = ""
        '
        'optHFile
        '
        Me.optHFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optHFile.Location = New System.Drawing.Point(0, 65)
        Me.optHFile.Name = "optHFile"
        Me.optHFile.Size = New System.Drawing.Size(154, 18)
        Me.optHFile.TabIndex = 44

        '
        'optHWin
        '
        Me.optHWin.Checked = True
        Me.optHWin.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optHWin.Location = New System.Drawing.Point(0, 0)
        Me.optHWin.Name = "optHWin"
        Me.optHWin.Size = New System.Drawing.Size(154, 18)
        Me.optHWin.TabIndex = 43
        Me.optHWin.TabStop = True

        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(29, 148)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(134, 18)
        Me.Label31.TabIndex = 40

        '
        'optAWin
        '
        Me.optAWin.Checked = True
        Me.optAWin.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optAWin.Location = New System.Drawing.Point(154, 37)
        Me.optAWin.Name = "optAWin"
        Me.optAWin.Size = New System.Drawing.Size(153, 18)
        Me.optAWin.TabIndex = 39
        Me.optAWin.TabStop = True

        '
        'optAMsg
        '
        Me.optAMsg.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optAMsg.Location = New System.Drawing.Point(154, 9)
        Me.optAMsg.Name = "optAMsg"
        Me.optAMsg.Size = New System.Drawing.Size(153, 19)
        Me.optAMsg.TabIndex = 38

        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(29, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(134, 19)
        Me.Label32.TabIndex = 37

        '
        'p4
        '
        Me.p4.Controls.Add(Me.GroupBox4)
        Me.p4.Controls.Add(Me.GroupBox3)
        Me.p4.Location = New System.Drawing.Point(0, 69)
        Me.p4.Name = "p4"
        Me.p4.Size = New System.Drawing.Size(595, 294)
        Me.p4.TabIndex = 15
        Me.p4.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox4)
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.Controls.Add(Me.CheckBox2)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.TextBox12)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox4.Location = New System.Drawing.Point(38, 138)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(432, 148)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False

        '
        'CheckBox4
        '
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox4.Location = New System.Drawing.Point(29, 102)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(173, 18)
        Me.CheckBox4.TabIndex = 4

        '
        'CheckBox3
        '
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox3.Location = New System.Drawing.Point(29, 120)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(173, 18)
        Me.CheckBox3.TabIndex = 5

        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox2.Location = New System.Drawing.Point(29, 83)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(173, 19)
        Me.CheckBox2.TabIndex = 3

        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox1.Location = New System.Drawing.Point(10, 65)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(163, 18)
        Me.CheckBox1.TabIndex = 2

        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(106, 28)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(268, 22)
        Me.TextBox12.TabIndex = 1

        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(10, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(134, 18)
        Me.Label23.TabIndex = 0

        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton5)
        Me.GroupBox3.Controls.Add(Me.TextBox11)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.TextBox10)
        Me.GroupBox3.Controls.Add(Me.RadioButton4)
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox3.Location = New System.Drawing.Point(38, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 120)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
       
        '
        'RadioButton5
        '
        Me.RadioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton5.Location = New System.Drawing.Point(10, 18)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(134, 19)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.Text = "320x240"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(182, 92)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(39, 22)
        Me.TextBox11.TabIndex = 6
        Me.TextBox11.Text = "300"
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(163, 92)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 19)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "x"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(115, 92)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(39, 22)
        Me.TextBox10.TabIndex = 4
        Me.TextBox10.Text = "450"
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton4.Location = New System.Drawing.Point(10, 92)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(134, 19)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
      
        '
        'RadioButton3
        '
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton3.Location = New System.Drawing.Point(10, 74)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(134, 18)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "1024x768"
        '
        'RadioButton2
        '
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton2.Location = New System.Drawing.Point(10, 55)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(134, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "800x600"
        '
        'RadioButton1
        '
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton1.Location = New System.Drawing.Point(10, 37)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(134, 18)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "640x480"
        '
        'dlgOpen
        '

      
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 40
        '
        'frmNewGameWizard
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(594, 413)
        Me.Controls.Add(Me.pTop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.picTrans)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.pLast)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.p5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.p4)
        Me.Controls.Add(Me.p6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewGameWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.p1.ResumeLayout(False)
        Me.pTop.ResumeLayout(False)
        Me.p2.ResumeLayout(False)
        Me.pLast.ResumeLayout(False)
        Me.p3.ResumeLayout(False)
        Me.p5.ResumeLayout(False)
        Me.p6.ResumeLayout(False)
        Me.grpAOpt.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.p4.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Frame As Integer = 1
    Const LastFrame As Integer = 6
    Dim TitleText() As String = {GetString("newGameWizard_GameInformationHeading"), _
        GetString("newGameWizard_LevelInformationHeading"), _
        GetString("newGameWizard_WindowOptionsHeading"), _
        GetString("newGameWizard_UIHeading"), _
        GetString("newGameWizard_HelpAboutHeading")}
    Dim SubtitleText() As String = {GetString("newGameWizard_GameInformationSubheading"), _
        GetString("newGameWizard_LevelInformationSubheading"), _
        GetString("newGameWizard_WindowOptionsSubheading"), _
        GetString("newGameWizard_UISubheading"), _
        GetString("newGameWizard_HelpAboutSubheading")}
    Dim NoUpdate As Boolean
    Dim DefBackgrnd As New psUI.psBackground
    Dim WDefBack As New psUI.psBackground
    Dim WDefMenuBtn As New psUI.psControl.psButton
    Dim WDefMenuLbl As New psUI.psControl.psLabel
    Dim WDefGameBtn As New psUI.psControl.psButton
    Dim HelpText As String = GetString1("defaultHelpText")
    Dim WindowScheme As Boolean

    Function ShowWindowScheme() As DialogResult
        WindowScheme = True

        'Transform into the Window Scheme Wizard
        chkBlank.Visible = False
        Label5.Text = GetString("windowSchemeWizard_Welcome")
        Label6.Text = GetString("windowSchemeWizard_Description")
        Label7.Top += 24
        Label9.Text = GetString("windowSchemeWizard_Finished")
        Label8.Text = GetString("windowSchemeWizard_Finish")
        Me.Text = GetString("windowSchemeWizard_Title")

        'Update fields
        With Game.GameProperties
            If Not .Windowed Then
                Select Case Game.windows.Width
                    Case 320 : RadioButton4.Checked = True
                    Case 640 : RadioButton1.Checked = True
                    Case 800 : RadioButton2.Checked = True
                    Case 1024 : RadioButton3.Checked = True
                End Select
            Else
                RadioButton4.Checked = True
            End If
            TextBox10.Text = .ResWidth
            TextBox11.Text = .ResHeight
            TextBox12.Text = .WindowTitle
            CheckBox1.Checked = .Menus
            CheckBox2.Checked = .mnuSupport
            CheckBox4.Checked = .mnuWebsite
            CheckBox3.Checked = .mnuAbout
        End With

        Dim dr As DialogResult
        dr = ShowDialog()
        Return dr
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Frame += 1
        If chkBlank.Checked And Frame = 2 Then Frame = LastFrame + 1
        If WindowScheme And Frame = 2 Then Frame = 4
        UpdateFrame()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Frame -= 1
        If chkBlank.Checked Then Frame = 1
        If WindowScheme And Frame = 3 Then Frame = 1
        UpdateFrame()
    End Sub

    Sub UpdateFrame()
        If Frame > LastFrame + 1 Then
            DialogResult = DialogResult.OK
            Finish()
            Exit Sub
        End If

        'Show or hide the back button and the top panel
        If Frame = 1 Then
            btnBack.Visible = False
            pTop.Visible = False
            PictureBox1.Visible = True
        Else
            btnBack.Visible = True
            pTop.Visible = (Frame < LastFrame + 1)
            PictureBox1.Visible = (Frame = LastFrame + 1)
        End If

        'Show the current panel
        Dim tmpPanel As Panel
        If Frame = LastFrame + 1 Then
            pLast.Visible = True
        Else
            pLast.Visible = False
            tmpPanel = CallByName(Me, "p" & Frame, CallType.Get)
            If pTop.Visible Then
                tmpPanel.Location = New Point(0, 60)
                h1.Text = TitleText(Frame - 2)
                h2.Text = SubtitleText(Frame - 2)
            End If
            tmpPanel.Visible = True
        End If

        'Hide the other panels
        For i As Integer = 1 To LastFrame
            If i <> Frame Then
                tmpPanel = CallByName(Me, "p" & i, CallType.Get)
                tmpPanel.Visible = False
            End If
        Next

        'Update the "Next" button
        If Frame = LastFrame + 1 Then
            btnNext.Text = GetString("newGameWizard_FinishButton")
        Else
            btnNext.Text = GetString("newGameWizard_NextButton")
        End If
    End Sub

    Sub Finish()
        'Create a new game
        If Not WindowScheme Then
            'Ask to save
            If psFileHandler.MadeChanges Then
                Select Case MessageBox.Show(GetString("main_SaveChangesBeforeClosingFileMessage"), "JumpCraft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        fGame.Save(True)
                    Case DialogResult.Cancel
                        DialogResult = DialogResult.None
                        Exit Sub
                End Select
            End If

            fGame.mnuNew_Click(Me, Nothing)
            If chkBlank.Checked Then Exit Sub
        Else
            UndoRedo.UpdateUndo(GetString("undoActionWindowSchemeWizard"), UndoRedo.UndoType.Windows)
        End If

        With Game
            'Update window scheme
            With .GameProperties
                If Not WindowScheme Then
                    .Name = TextBox1.Text
                    .Credits = TextBox3.Text
                    .Company = TextBox4.Text
                    .Website = TextBox5.Text
                    .Support = TextBox6.Text
                End If
                .Windowed = False
                Select Case True
                    Case RadioButton5.Checked
                        .ResWidth = 320 : .ResHeight = 240
                    Case RadioButton1.Checked
                        .ResWidth = 640 : .ResHeight = 480
                    Case RadioButton2.Checked
                        .ResWidth = 800 : .ResHeight = 600
                    Case RadioButton3.Checked
                        .ResWidth = 1024 : .ResHeight = 768
                    Case RadioButton4.Checked
                        .ResWidth = TextBox10.Text
                        .ResHeight = TextBox11.Text
                        .Windowed = True
                End Select
                Game.windows.Width = .ResWidth
                Game.windows.Height = .ResHeight
                .WindowTitle = TextBox12.Text
                .Menus = CheckBox1.Checked
                .mnuSupport = CheckBox2.Checked
                .mnuWebsite = CheckBox4.Checked
                .mnuAbout = CheckBox3.Checked
            End With
            While UBound(Game.windows.Windows) > 0
                Game.RemoveWindow(1)
            End While
            Game.windows.CreateFromPreset(WDefBack, WDefMenuBtn, WDefMenuLbl, WDefGameBtn, optAWin.Checked, optHFile.Checked, chkWebBtn.Checked, chkSptBtn.Checked, HelpText)

            'Create levels
            If Not WindowScheme Then
                ReDim .maps(0)
                If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
                For i As Integer = 0 To ListBox1.Items.Count - 1
                    .AddMap(ListBox1.Items(i), TextBox7.Text, TextBox8.Text)
                    .maps(i + 1).Background = DefBackgrnd.Clone
                Next
                If optHFile.Checked Then HelpText = txtHFile.Text
                Editor.psedit.DoResize()
                Editor.pslevelsel.Refresh()
            End If
        End With
    End Sub

    Private Sub frmNewGameWizard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BringToFront()
        cboBackgrnd.SelectedIndex = 0
        DefBackgrnd.MakePreview(PictureBox3, picTrans)
        cboColorScheme.SelectedIndex = 0
        PictureBox4_Click(PictureBox4, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Add(String.Format(GetString1("defaultLevelName"), ListBox1.Items.Count + 1))
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If NoUpdate Then Exit Sub
        Button4.Enabled = (ListBox1.SelectedIndex > 0)
        Button5.Enabled = (ListBox1.SelectedIndex < ListBox1.Items.Count - 1 And ListBox1.SelectedIndex > -1)
        Button2.Enabled = (ListBox1.SelectedIndex > -1)
        TextBox2.Enabled = (ListBox1.SelectedIndex > -1)
        Label16.Enabled = TextBox2.Enabled
        TextBox2.Text = IIf(TextBox2.Enabled, ListBox1.SelectedItem, "")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim tmpSel As Integer = ListBox1.SelectedIndex
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        If ListBox1.Items.Count = 0 Then
            Button1_Click(sender, Nothing)
        ElseIf tmpSel > ListBox1.SelectedIndex Then
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1
        Else
            ListBox1.SelectedIndex = tmpSel
        End If
    End Sub

    Private Sub TextBox7_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox7.Validating
        ConvertToNumber(TextBox7, 8, 512, 64)
    End Sub

    Private Sub TextBox8_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox8.Validating
        ConvertToNumber(TextBox8, 8, 256, 32)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        NoUpdate = True
        ListBox1.Items(ListBox1.SelectedIndex) = TextBox2.Text
        NoUpdate = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ListBox1.SelectedIndex <= 0 Then Exit Sub
        MoveLevelItem(-1)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ListBox1.SelectedIndex = -1 Or ListBox1.SelectedIndex >= ListBox1.Items.Count - 1 Then Exit Sub
        MoveLevelItem(1)
    End Sub

    Sub MoveLevelItem(ByVal Amount As Integer)
        NoUpdate = True
        Dim tmpStr As String = ListBox1.SelectedItem
        Dim tmpSel As Integer = ListBox1.SelectedIndex
        ListBox1.Items(ListBox1.SelectedIndex) = ListBox1.Items(ListBox1.SelectedIndex + Amount)
        ListBox1.Items(ListBox1.SelectedIndex + Amount) = tmpStr
        NoUpdate = False
        ListBox1.SelectedIndex = tmpSel + Amount
    End Sub

    Private Sub cboBackgrnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBackgrnd.SelectedIndexChanged
        Select Case cboBackgrnd.SelectedItem
            Case GetString("newGameWizard_Background_Day")
                DefBackgrnd = psUI.psBackground.NewVGradientBackground(Color.FromArgb(216, 216, 255), Color.FromArgb(156, 156, 255))
            Case GetString("newGameWizard_Background_Night")
                DefBackgrnd = psUI.psBackground.NewVGradientBackground(Color.DarkBlue, Color.Black)
            Case GetString("newGameWizard_Background_Gloomy")
                DefBackgrnd = psUI.psBackground.NewVGradientBackground(Color.LightGray, Color.DarkGray)
            Case GetString("newGameWizard_Background_Black")
                DefBackgrnd = psUI.psBackground.NewSolidBackground(Color.Black)
            Case GetString("newGameWizard_Background_Custom")
                Dim f As New psfrmBackgroundEditor
                DefBackgrnd = f.ShowDialog(DefBackgrnd)
                f.Dispose()
        End Select
        DefBackgrnd.MakePreview(PictureBox3, picTrans)
    End Sub

    Private Sub optAWin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAWin.CheckedChanged
        grpAOpt.Enabled = optAWin.Checked
    End Sub

    Private Sub optHWin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHWin.CheckedChanged
        btnHTxt.Enabled = optHWin.Checked
    End Sub

    Private Sub optHFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHFile.CheckedChanged
        txtHFile.Enabled = optHFile.Checked
        btnHFile.Enabled = optHFile.Checked
    End Sub

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
        Label24.Enabled = RadioButton4.Checked
        TextBox11.Enabled = RadioButton4.Checked
    End Sub

    Private Sub TextBox10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating
        ConvertToNumber(TextBox10, 200, 1024, 640)
    End Sub

    Private Sub TextBox11_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox11.Validating
        ConvertToNumber(TextBox11, 200, 768, 480)
    End Sub

    Private Sub cboColorScheme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColorScheme.SelectedIndexChanged
        WDefBack = Game.windows.GetDefaultBack
        WDefMenuBtn = Game.windows.GetDefaultMenuBtn
        WDefMenuLbl = Game.windows.GetDefaultMenuLbl
        WDefGameBtn = Game.windows.GetDefaultGameBtn
        WDefGameBtn.Text = GetString("newGameWizard_MockGameButtonText")
        WDefMenuBtn.Text = GetString("newGameWizard_MockMenuButtonText")
        WDefMenuLbl.Text = GetString("newGameWizard_MockMenuLabelText")
        Select Case cboColorScheme.Text
            Case GetString("newGameWizard_Colors_Blue")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.LightBlue, Color.DarkBlue)
                SetBtnColors(WDefMenuBtn, Channel.R, Channel.R, Channel.G)
                SetBtnColors(WDefGameBtn, Channel.R, Channel.R, Channel.G)
                WDefMenuLbl.ForeColor = Color.FromArgb(255, 0, 0, 64)
            Case GetString("newGameWizard_Colors_Green")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.LightGreen, Color.DarkGreen)
                WDefMenuLbl.ForeColor = Color.FromArgb(255, 0, 64, 0)
            Case GetString("newGameWizard_Colors_Orange")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 224, 192), Color.DarkOrange)
                SetBtnColors(WDefMenuBtn, Channel.G, 1, Channel.G, 0.88, Channel.R, 1)
                SetBtnColors(WDefGameBtn, Channel.G, 1, Channel.G, 0.88, Channel.R, 1)
                WDefMenuLbl.ForeColor = Color.Black
            Case GetString("newGameWizard_Colors_DarkGray")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(128, 128, 128), Color.FromArgb(32, 32, 32))
                SetBtnColors(WDefMenuBtn, Channel.G, Channel.G, Channel.G)
                SetBtnColors(WDefGameBtn, Channel.G, Channel.G, Channel.G)
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_LightGray")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(224, 224, 224), Color.FromArgb(160, 160, 160))
                SetBtnColors(WDefMenuBtn, Channel.G, Channel.G, Channel.G)
                SetBtnColors(WDefGameBtn, Channel.G, Channel.G, Channel.G)
                WDefMenuLbl.ForeColor = Color.Black
            Case GetString("newGameWizard_Colors_Purple")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.Magenta, Color.Purple)
                SetBtnColors(WDefMenuBtn, Channel.G * 0.88, Channel.R * 0.88, Channel.G * 0.88)
                SetBtnColors(WDefGameBtn, Channel.G * 0.75, Channel.R * 0.75, Channel.G * 0.75)
                WDefMenuLbl.ForeColor = Color.FromArgb(255, 64, 0, 64)
            Case GetString("newGameWizard_Colors_Red")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 255, 128, 128), Color.DarkRed)
                SetBtnColors(WDefMenuBtn, Channel.G, Channel.R, Channel.R)
                SetBtnColors(WDefGameBtn, Channel.G, Channel.R, Channel.R)
                WDefMenuLbl.ForeColor = Color.FromArgb(255, 64, 0, 0)
            Case GetString("newGameWizard_Colors_Earth")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.DarkGreen, Color.FromArgb(255, 128, 64, 0))
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_Aqua")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 0, 224, 128), Color.FromArgb(255, 0, 128, 224))
                SetBtnColors(WDefMenuBtn, Channel.R * 0.88, Channel.G * 0.88, Channel.G * 0.88)
                SetBtnColors(WDefGameBtn, Channel.R * 0.75, Channel.G * 0.75, Channel.G * 0.75)
                WDefMenuLbl.ForeColor = Color.FromArgb(255, 0, 64, 64)
            Case GetString("newGameWizard_Colors_BlackWhite")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.Black, Color.White)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Black, Color.Black, Color.White, Color.White, Color.White)
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_BlackBlue")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 128, 128, 255), Color.Black)
                SetBtnColors(WDefMenuBtn, Color.FromArgb(255, 128, 128, 255), Color.Black, Color.FromArgb(255, 192, 192, 255), Color.DarkBlue, Color.Blue, Color.White)
                WDefMenuBtn.Border3D = False
                WDefMenuBtn.BorderColor = Color.Blue
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 128, 128, 255), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 192, 192, 255), Color.FromArgb(128, 0, 0, 128), Color.FromArgb(128, 0, 0, 255), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.Border3D = False
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 255)
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_BlackOrange")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 255, 192, 128), Color.Black)
                SetBtnColors(WDefMenuBtn, Color.FromArgb(255, 255, 192, 128), Color.Black, Color.FromArgb(255, 255, 224, 192), Color.FromArgb(255, 128, 64, 0), Color.FromArgb(255, 255, 128, 0), Color.White)
                WDefMenuBtn.Border3D = False
                WDefMenuBtn.BorderColor = Color.FromArgb(255, 255, 128, 0)
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 192, 128), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 255, 224, 192), Color.FromArgb(128, 128, 64, 0), Color.FromArgb(128, 255, 128, 0), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.Border3D = False
                WDefGameBtn.BorderColor = Color.FromArgb(128, 255, 128, 0)
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_BlackYellow")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 255, 255, 128), Color.Black)
                SetBtnColors(WDefMenuBtn, Color.FromArgb(255, 255, 255, 128), Color.Black, Color.FromArgb(255, 255, 255, 192), Color.FromArgb(255, 128, 128, 0), Color.Yellow, Color.White)
                WDefMenuBtn.Border3D = False
                WDefMenuBtn.BorderColor = Color.Yellow
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 128), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 255, 255, 192), Color.FromArgb(128, 128, 128, 0), Color.FromArgb(128, 255, 255, 0), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.Border3D = False
                WDefGameBtn.BorderColor = Color.FromArgb(128, 255, 255, 0)
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_BlackGreen")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.FromArgb(255, 128, 255, 128), Color.Black)
                SetBtnColors(WDefMenuBtn, Color.FromArgb(255, 128, 255, 128), Color.Black, Color.FromArgb(255, 192, 255, 192), Color.DarkGreen, Color.Green, Color.White)
                WDefMenuBtn.Border3D = False
                WDefMenuBtn.BorderColor = Color.Green
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 128, 255, 128), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 192, 255, 192), Color.FromArgb(128, 0, 128, 0), Color.FromArgb(128, 0, 255, 0), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.Border3D = False
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 255, 0)
                WDefMenuLbl.ForeColor = Color.White
            Case GetString("newGameWizard_Colors_WhiteBlack")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Black)
                SetBtnColors(WDefMenuBtn, Color.Black, Color.White, Color.White, Color.Black, Color.Black, Color.Black)
                WDefMenuBtn.ForeColor = Color.White
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 0, 0, 0))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
            Case GetString("newGameWizard_Colors_WhiteBlue")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Blue)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Blue, Color.White, Color.FromArgb(255, 128, 128, 255), Color.FromArgb(255, 128, 128, 255), Color.White)
                WDefMenuBtn.ForeColor = Color.Black
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 0, 0, 255), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 128, 128, 255), Color.FromArgb(128, 128, 128, 255), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
                WDefMenuBtn.BorderColor = Color.Black
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 0)
            Case GetString("newGameWizard_Colors_WhiteGreen")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Green)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Green, Color.White, Color.FromArgb(255, 128, 255, 128), Color.FromArgb(255, 128, 255, 128), Color.White)
                WDefMenuBtn.ForeColor = Color.Black
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 0, 255, 0), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 128, 255, 128), Color.FromArgb(128, 128, 255, 128), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
                WDefMenuBtn.BorderColor = Color.Black
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 0)
            Case GetString("newGameWizard_Colors_WhiteOrange")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Orange)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Orange, Color.White, Color.FromArgb(255, 255, 192, 128), Color.FromArgb(255, 255, 192, 128), Color.White)
                WDefMenuBtn.ForeColor = Color.Black
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 128, 0), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 192, 128), Color.FromArgb(128, 255, 192, 128), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
                WDefMenuBtn.BorderColor = Color.Black
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 0)
            Case GetString("newGameWizard_Colors_WhiteRed")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Red)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Red, Color.White, Color.FromArgb(255, 255, 128, 128), Color.FromArgb(255, 255, 128, 128), Color.White)
                WDefMenuBtn.ForeColor = Color.Black
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 0, 0), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 128, 128), Color.FromArgb(128, 255, 128, 128), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
                WDefMenuBtn.BorderColor = Color.Black
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 0)
            Case GetString("newGameWizard_Colors_WhiteMagenta")
                WDefBack = psUI.psBackground.NewVGradientBackground(Color.White, Color.Magenta)
                SetBtnColors(WDefMenuBtn, Color.White, Color.Magenta, Color.White, Color.FromArgb(255, 255, 128, 255), Color.FromArgb(255, 255, 128, 255), Color.White)
                WDefMenuBtn.ForeColor = Color.Black
                WDefMenuBtn.Border3D = False
                SetBtnColors(WDefGameBtn, Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 0, 255), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 255, 128, 255), Color.FromArgb(128, 255, 128, 255), Color.FromArgb(128, 255, 255, 255))
                WDefGameBtn.ForeColor = Color.White
                WDefGameBtn.Border3D = False
                WDefMenuLbl.ForeColor = Color.Black
                WDefMenuBtn.BorderColor = Color.Black
                WDefGameBtn.BorderColor = Color.FromArgb(128, 0, 0, 0)
        End Select
        WDefBack.MakePreview(PictureBox7, picTrans)
        WDefMenuBtn.DrawPreview(PictureBox4, picTrans)
        WDefMenuLbl.DrawPreview(PictureBox5, picTrans)
        WDefGameBtn.DrawPreview(PictureBox6, picTrans)
        If RadioButton6.Checked Then
            PictureBox4_Click(PictureBox4, Nothing)
        ElseIf RadioButton7.Checked Then
            PictureBox5_Click(PictureBox4, Nothing)
        ElseIf RadioButton8.Checked Then
            PictureBox6_Click(PictureBox4, Nothing)
        End If
    End Sub

    Enum Channel As Byte
        R = 0
        G
        B
    End Enum
    Sub SetBtnColors(ByVal btn As psUI.psControl.psButton, ByVal RChannel As Channel, ByVal GChannel As Channel, ByVal BChannel As Channel)
        With btn
            Dim Over As psUI.psBackground = .Over
            Dim Down As psUI.psBackground = .Down

            GetColorFromChannels(Over.Color2, RChannel, 1, GChannel, 1, BChannel, 1)
            GetColorFromChannels(Down.Color1, RChannel, 1, GChannel, 1, BChannel, 1)
            GetColorFromChannels(Down.Color2, RChannel, 1, GChannel, 1, BChannel, 1)

            .Over = Over
            .Down = Down
        End With
    End Sub

    Sub SetBtnColors(ByVal btn As psUI.psControl.psButton, ByVal RChannel As Channel, ByVal RScale As Single, ByVal GChannel As Channel, ByVal GScale As Single, ByVal BChannel As Channel, ByVal BScale As Single)
        With btn
            Dim Over As psUI.psBackground = .Over
            Dim Down As psUI.psBackground = .Down

            GetColorFromChannels(Over.Color2, RChannel, RScale, GChannel, GScale, BChannel, BScale)
            GetColorFromChannels(Down.Color1, RChannel, RScale, GChannel, GScale, BChannel, BScale)
            GetColorFromChannels(Down.Color2, RChannel, RScale, GChannel, GScale, BChannel, BScale)

            .Over = Over
            .Down = Down
        End With
    End Sub

    Sub GetColorFromChannels(ByRef Color As Color, ByVal RChannel As Channel, ByVal RScale As Single, ByVal GChannel As Channel, ByVal GScale As Single, ByVal BChannel As Channel, ByVal BScale As Single)
        Color = Color.FromArgb(Color.A, _
                               GetChannelFromChannel(Color, RChannel, RScale), _
                               GetChannelFromChannel(Color, GChannel, GScale), _
                               GetChannelFromChannel(Color, BChannel, BScale))
    End Sub

    Function GetChannelFromChannel(ByVal Color As Color, ByVal Channel As Channel, ByVal Scale As Single) As Byte
        Select Case Channel
            Case Channel.R : Return Color.R * Scale
            Case Channel.G : Return Color.G * Scale
            Case Channel.B : Return Color.B * Scale
        End Select
    End Function

    Sub SetBtnColors(ByVal btn As psUI.psControl.psButton, ByVal back1 As Color, ByVal back2 As Color, ByVal over1 As Color, ByVal over2 As Color, ByVal down1 As Color, ByVal down2 As Color)
        With btn
            Dim Background As psUI.psBackground = .Background
            Dim Over As psUI.psBackground = .Over
            Dim Down As psUI.psBackground = .Down

            Background.Color1 = back1
            Background.Color2 = back2
            Over.Color1 = over1
            Over.Color2 = over2
            Down.Color1 = down1
            Down.Color2 = down2

            .Background = Background
            .Over = Over
            .Down = Down
        End With
    End Sub

    Sub SetBtnColors(ByVal btn As psUI.psControl.psButton, ByVal over1 As Color, ByVal over2 As Color, ByVal down1 As Color, ByVal down2 As Color)
        With btn
            Dim Over As psUI.psBackground = .Over
            Dim Down As psUI.psBackground = .Down

            Over.Color1 = over1
            Over.Color2 = over2
            Down.Color1 = down1
            Down.Color2 = down2

            .Over = Over
            .Down = Down
        End With
    End Sub

    Private Sub btnHTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHTxt.Click
        Dim f As New frmEditText
        f.ShowDialog(HelpText)
        f.Dispose()
    End Sub

    Private Sub btnHFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHFile.Click
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        txtHFile.Text = dlgOpen.FileName
    End Sub

    'Mouse down/up events
    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        WDefMenuBtn.setMouseDown(True, True)
    End Sub
    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        WDefMenuBtn.setMouseDown(False, True)
    End Sub
    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        WDefGameBtn.setMouseDown(True, True)
    End Sub
    Private Sub PictureBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        WDefGameBtn.setMouseDown(False, True)
    End Sub

    'Update buttons
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Frame = 5 Then
            'Mouse over
            Dim pt As Point
            pt = PictureBox4.PointToClient(Control.MousePosition)
            WDefMenuBtn.setMouseInside(pt.X >= 0 And pt.Y >= 0 And pt.X <= PictureBox6.Width And pt.Y <= PictureBox6.Height, True)
            pt = PictureBox6.PointToClient(Control.MousePosition)
            WDefGameBtn.setMouseInside(pt.X >= 0 And pt.Y >= 0 And pt.X <= PictureBox6.Width And pt.Y <= PictureBox6.Height, True)

            'Update previews
            WDefMenuBtn.DrawPreview(PictureBox4, picTrans)
            WDefGameBtn.DrawPreview(PictureBox6, picTrans)
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click, RadioButton6.CheckedChanged
        sel.Location = New Point(PictureBox4.Left - 2, PictureBox4.Top - 2)
        ctlprop.prop.SelectedObject = New PropDispNameWrapper(New ButtonWrapper(WDefMenuBtn))
        If sender Is RadioButton6 Then Return
        If Not RadioButton6.Checked Then RadioButton6.Checked = True
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click, RadioButton7.CheckedChanged
        sel.Location = New Point(PictureBox5.Left - 2, PictureBox5.Top - 2)
        ctlprop.prop.SelectedObject = New PropDispNameWrapper(New LabelWrapper(WDefMenuLbl))
        If sender Is RadioButton7 Then Return
        If Not RadioButton7.Checked Then RadioButton7.Checked = True
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click, RadioButton8.CheckedChanged
        sel.Location = New Point(PictureBox6.Left - 2, PictureBox6.Top - 2)
        ctlprop.prop.SelectedObject = New PropDispNameWrapper(New ButtonWrapper(WDefGameBtn))
        If sender Is RadioButton8 Then Return
        If Not RadioButton8.Checked Then RadioButton8.Checked = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'default background
        Dim f As New psfrmBackgroundEditor
        WDefBack = f.ShowDialog(WDefBack)
        f.Dispose()
        WDefBack.MakePreview(PictureBox7, picTrans)
    End Sub

    Private Sub ctlprop_PropertyValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles ctlprop.PropertyValueChanged
        Dim o As psUI.psControl = ctlprop.prop.SelectedObject.Unwrap().Unwrap()
        If o Is WDefMenuBtn Then
            WDefMenuBtn.DrawPreview(PictureBox4, picTrans)
        ElseIf o Is WDefMenuLbl Then
            WDefMenuLbl.DrawPreview(PictureBox5, picTrans)
        ElseIf o Is WDefGameBtn Then
            WDefGameBtn.DrawPreview(PictureBox6, picTrans)
        End If
    End Sub

    Private Sub frmNewGameWizard_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        DynamicReadOnly.SetValue("ButtonWrapper.Action", False)
    End Sub
End Class