Public Class frmOptions
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.TabPage4.Text = GetString("options_GeneralTab")
        Me.Label9.Text = GetString("options_DefaultImageEditorLabel")
        Me.Label8.Text = GetString("options_RecentGamesLabel")
        Me.CheckBox23.Text = GetString("options_CheckUpdatesCheckbox")
        Me.CheckBox13.Text = GetString("options_WarnDeleteActionsCheckbox")
        Me.CheckBox4.Text = GetString("options_ShowWelcomeCheckbox")
        Me.CheckBox3.Text = GetString("options_StartMaximizedCheckbox")
        Me.CheckBox2.Text = GetString("options_ShowSplashCheckbox")
        Me.CheckBox1.Text = GetString("options_OpenDefaultGameCheckbox")
        Me.Label1.Text = GetString("options_MaxUndoLabel")
        Me.TabPage1.Text = GetString("options_LevelEditorTab")
        Me.RadioButton2.Text = GetString("options_GridTypePointsOption")
        Me.RadioButton1.Text = GetString("options_GridTypeLinesOption")
        Me.Label6.Text = GetString("options_GridTypeLabel")
        Me.CheckBox24.Text = GetString("options_ShowFramerateCheckbox")
        Me.CheckBox21.Text = GetString("options_ShowPropertiesPanelCheckbox")
        Me.CheckBox20.Text = GetString("options_ShowLevelsPanelCheckbox")
        Me.CheckBox19.Text = GetString("options_DrawTilePathsCheckbox")
        Me.CheckBox9.Text = GetString("options_ShowLayersPanelCheckbox")
        Me.CheckBox8.Text = GetString("options_ShowTileSelectorCheckbox")
        Me.CheckBox7.Text = GetString("options_ShowStatusBarCheckbox")
        Me.CheckBox6.Text = GetString("options_ShowToolbarsCheckbox")
        Me.CheckBox5.Text = GetString("options_ShowGridCheckbox")
        Me.TabPage2.Text = GetString("options_PathEditorTab")
        Me.Label5.Text = GetString("options_PathDrawingPrecisionLabel")
        Me.CheckBox12.Text = GetString("options_TintBackgroundCheckbox")
        Me.CheckBox11.Text = GetString("options_ShowGuidePointsCheckbox")
        Me.CheckBox10.Text = GetString("options_ShowPointsCheckbox")
        Me.TabPage3.Text = GetString("options_WindowEditorTab")
        Me.Label7.Text = GetString("options_GridTypeLabel")
        Me.Label4.Text = GetString("pixelsUnit")
        Me.Label3.Text = GetString("options_GridSpacingLabel")
        Me.CheckBox14.Text = GetString("options_showWindowsPanelCheckbox")
        Me.CheckBox15.Text = GetString("options_ShowControlSelectorCheckbox")
        Me.CheckBox17.Text = GetString("options_ShowToolbarCheckbox")
        Me.Button1.Text = GetString("options_ResetOptionsButton")
        Me.ofd.Filter = GetString("executableFileFilter")
        Me.ofd.Title = GetString("selectAProgramDialogTitle")
        Me.Text = GetString("options_Title")
        Me.RadioButton4.Text = GetString("options_GridTypePointsOption")
        Me.RadioButton3.Text = GetString("options_GridTypeLinesOption")
        Me.CheckBox25.Text = GetString("options_ShowFramerateCheckbox")
        Me.CheckBox22.Text = GetString("options_ShowPropertiesPanelCheckbox")
        Me.CheckBox16.Text = GetString("options_ShowStatusBarCheckbox")
        Me.CheckBox18.Text = GetString("options_ShowGridCheckbox")
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox13 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox14 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox16 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox17 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox18 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBox19 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox20 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox21 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox22 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox23 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox24 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox25 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Button4 = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckBox23 = New System.Windows.Forms.CheckBox
        Me.CheckBox13 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.CheckBox24 = New System.Windows.Forms.CheckBox
        Me.CheckBox21 = New System.Windows.Forms.CheckBox
        Me.CheckBox20 = New System.Windows.Forms.CheckBox
        Me.CheckBox19 = New System.Windows.Forms.CheckBox
        Me.CheckBox9 = New System.Windows.Forms.CheckBox
        Me.CheckBox8 = New System.Windows.Forms.CheckBox
        Me.CheckBox7 = New System.Windows.Forms.CheckBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.CheckBox12 = New System.Windows.Forms.CheckBox
        Me.CheckBox11 = New System.Windows.Forms.CheckBox
        Me.CheckBox10 = New System.Windows.Forms.CheckBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.CheckBox25 = New System.Windows.Forms.CheckBox
        Me.CheckBox22 = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox14 = New System.Windows.Forms.CheckBox
        Me.CheckBox15 = New System.Windows.Forms.CheckBox
        Me.CheckBox16 = New System.Windows.Forms.CheckBox
        Me.CheckBox17 = New System.Windows.Forms.CheckBox
        Me.CheckBox18 = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ofd = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(344, 256)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Controls.Add(Me.TextBox4)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.TextBox3)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.CheckBox23)
        Me.TabPage4.Controls.Add(Me.CheckBox13)
        Me.TabPage4.Controls.Add(Me.CheckBox4)
        Me.TabPage4.Controls.Add(Me.CheckBox3)
        Me.TabPage4.Controls.Add(Me.CheckBox2)
        Me.TabPage4.Controls.Add(Me.CheckBox1)
        Me.TabPage4.Controls.Add(Me.TextBox1)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(336, 230)
        Me.TabPage4.TabIndex = 3

        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(304, 200)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 20)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "..."
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(120, 200)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(184, 20)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.Text = "mspaint"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 10

        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(184, 176)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(40, 20)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "4"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 16)
        Me.Label8.TabIndex = 8

        '
        'CheckBox23
        '
        Me.CheckBox23.Checked = True
        Me.CheckBox23.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox23.Location = New System.Drawing.Point(8, 56)
        Me.CheckBox23.Name = "CheckBox23"
        Me.CheckBox23.Size = New System.Drawing.Size(176, 16)
        Me.CheckBox23.TabIndex = 7

        '
        'CheckBox13
        '
        Me.CheckBox13.Checked = True
        Me.CheckBox13.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox13.Location = New System.Drawing.Point(8, 128)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(304, 16)
        Me.CheckBox13.TabIndex = 4

        '
        'CheckBox4
        '
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(8, 80)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(185, 16)
        Me.CheckBox4.TabIndex = 2

        '
        'CheckBox3
        '
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(8, 32)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(176, 16)
        Me.CheckBox3.TabIndex = 1

        '
        'CheckBox2
        '
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(8, 8)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(176, 16)
        Me.CheckBox2.TabIndex = 0

        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(8, 104)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(304, 16)
        Me.CheckBox1.TabIndex = 3

        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(184, 152)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(40, 20)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = "50"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 5

        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RadioButton2)
        Me.TabPage1.Controls.Add(Me.RadioButton1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.CheckBox24)
        Me.TabPage1.Controls.Add(Me.CheckBox21)
        Me.TabPage1.Controls.Add(Me.CheckBox20)
        Me.TabPage1.Controls.Add(Me.CheckBox19)
        Me.TabPage1.Controls.Add(Me.CheckBox9)
        Me.TabPage1.Controls.Add(Me.CheckBox8)
        Me.TabPage1.Controls.Add(Me.CheckBox7)
        Me.TabPage1.Controls.Add(Me.CheckBox6)
        Me.TabPage1.Controls.Add(Me.CheckBox5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(336, 230)
        Me.TabPage1.TabIndex = 0

        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(232, 8)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton2.TabIndex = 11

        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(176, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.TabStop = True

        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(120, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 9

        '
        'CheckBox24
        '
        Me.CheckBox24.Checked = True
        Me.CheckBox24.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox24.Location = New System.Drawing.Point(8, 200)
        Me.CheckBox24.Name = "CheckBox24"
        Me.CheckBox24.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox24.TabIndex = 8

        '
        'CheckBox21
        '
        Me.CheckBox21.Checked = True
        Me.CheckBox21.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox21.Location = New System.Drawing.Point(8, 152)
        Me.CheckBox21.Name = "CheckBox21"
        Me.CheckBox21.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox21.TabIndex = 7

        '
        'CheckBox20
        '
        Me.CheckBox20.Checked = True
        Me.CheckBox20.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox20.Location = New System.Drawing.Point(8, 128)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox20.TabIndex = 6

        '
        'CheckBox19
        '
        Me.CheckBox19.Checked = True
        Me.CheckBox19.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox19.Location = New System.Drawing.Point(8, 176)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox19.TabIndex = 5

        '
        'CheckBox9
        '
        Me.CheckBox9.Checked = True
        Me.CheckBox9.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox9.Location = New System.Drawing.Point(8, 104)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox9.TabIndex = 4

        '
        'CheckBox8
        '
        Me.CheckBox8.Checked = True
        Me.CheckBox8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox8.Location = New System.Drawing.Point(8, 80)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox8.TabIndex = 3

        '
        'CheckBox7
        '
        Me.CheckBox7.Checked = True
        Me.CheckBox7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox7.Location = New System.Drawing.Point(8, 56)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox7.TabIndex = 2

        '
        'CheckBox6
        '
        Me.CheckBox6.Checked = True
        Me.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox6.Location = New System.Drawing.Point(8, 32)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox6.TabIndex = 1

        '
        'CheckBox5
        '
        Me.CheckBox5.Checked = True
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.Location = New System.Drawing.Point(8, 8)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox5.TabIndex = 0

        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TrackBar1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.CheckBox12)
        Me.TabPage2.Controls.Add(Me.CheckBox11)
        Me.TabPage2.Controls.Add(Me.CheckBox10)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(336, 230)
        Me.TabPage2.TabIndex = 1

        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(64, 80)
        Me.TrackBar1.Maximum = 6
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(72, 45)
        Me.TrackBar1.TabIndex = 6
        Me.TrackBar1.Value = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 5

        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(152, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "%"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(112, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(40, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "50"
        '
        'CheckBox12
        '
        Me.CheckBox12.Checked = True
        Me.CheckBox12.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox12.Location = New System.Drawing.Point(8, 56)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox12.TabIndex = 2

        '
        'CheckBox11
        '
        Me.CheckBox11.Checked = True
        Me.CheckBox11.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox11.Location = New System.Drawing.Point(8, 32)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox11.TabIndex = 1

        '
        'CheckBox10
        '
        Me.CheckBox10.Checked = True
        Me.CheckBox10.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox10.Location = New System.Drawing.Point(8, 8)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox10.TabIndex = 0

        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.RadioButton4)
        Me.TabPage3.Controls.Add(Me.RadioButton3)
        Me.TabPage3.Controls.Add(Me.CheckBox25)
        Me.TabPage3.Controls.Add(Me.CheckBox22)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.ComboBox1)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.CheckBox14)
        Me.TabPage3.Controls.Add(Me.CheckBox15)
        Me.TabPage3.Controls.Add(Me.CheckBox16)
        Me.TabPage3.Controls.Add(Me.CheckBox17)
        Me.TabPage3.Controls.Add(Me.CheckBox18)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(336, 230)
        Me.TabPage3.TabIndex = 2

        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(88, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 15

        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(200, 32)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton4.TabIndex = 14
        Me.RadioButton4.TabStop = True

        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(144, 32)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton3.TabIndex = 13
        
        '
        'CheckBox25
        '
        Me.CheckBox25.Checked = True
        Me.CheckBox25.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox25.Location = New System.Drawing.Point(8, 176)
        Me.CheckBox25.Name = "CheckBox25"
        Me.CheckBox25.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox25.TabIndex = 9
        
        '
        'CheckBox22
        '
        Me.CheckBox22.Checked = True
        Me.CheckBox22.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox22.Location = New System.Drawing.Point(8, 152)
        Me.CheckBox22.Name = "CheckBox22"
        Me.CheckBox22.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox22.TabIndex = 8
        
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(208, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 3

        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "4", "8", "12", "16", "24", "32"})
        Me.ComboBox1.Location = New System.Drawing.Point(144, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(56, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(88, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 1

        '
        'CheckBox14
        '
        Me.CheckBox14.Checked = True
        Me.CheckBox14.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox14.Location = New System.Drawing.Point(8, 128)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox14.TabIndex = 7

        '
        'CheckBox15
        '
        Me.CheckBox15.Checked = True
        Me.CheckBox15.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox15.Location = New System.Drawing.Point(8, 104)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(144, 16)
        Me.CheckBox15.TabIndex = 6

        '
        'CheckBox16
        '
        Me.CheckBox16.Checked = True
        Me.CheckBox16.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox16.Location = New System.Drawing.Point(8, 80)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox16.TabIndex = 5
        
        '
        'CheckBox17
        '
        Me.CheckBox17.Checked = True
        Me.CheckBox17.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox17.Location = New System.Drawing.Point(8, 56)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox17.TabIndex = 4

        '
        'CheckBox18
        '
        Me.CheckBox18.Checked = True
        Me.CheckBox18.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox18.Location = New System.Drawing.Point(8, 8)
        Me.CheckBox18.Name = "CheckBox18"
        Me.CheckBox18.Size = New System.Drawing.Size(112, 16)
        Me.CheckBox18.TabIndex = 0
        
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(280, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2
     
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(200, 272)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1
   
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(120, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 3

        '
        'ofd
        '


        '
        'frmOptions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 304)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With PlatformStudio.Options
            CheckBox2.Checked = .gShowSplash
            CheckBox3.Checked = .gStartMaximized
            CheckBox23.Checked = .gCheckForUpdatesAtStartup
            CheckBox4.Checked = .gShowWelcomeDialog
            CheckBox1.Checked = .gDefaultGame
            CheckBox13.Checked = .gWarnWhenDelActions
            TextBox1.Text = .gUndoLevels
            TextBox3.Text = .gNumMRU
            TextBox4.Text = .gImageEditor

            CheckBox5.Checked = .mShowGrid
            RadioButton1.Checked = .mGridLines
            RadioButton2.Checked = Not .mGridLines
            CheckBox6.Checked = .mShowToolbars
            CheckBox7.Checked = .mShowStatusBar
            CheckBox8.Checked = .mShowTileSelector
            CheckBox9.Checked = .mShowLayersPanel
            CheckBox20.Checked = .mShowLevelsPanel
            CheckBox21.Checked = .mShowPropertiesPanel
            CheckBox19.Checked = .mDrawTilePaths
            CheckBox24.Checked = .mShowFramerate            

            CheckBox10.Checked = .pShowPoints
            CheckBox11.Checked = .pShowGuides
            CheckBox12.Checked = .pTintBackground
            TextBox2.Text = .pTint
            TrackBar1.Value = .pPrecision

            CheckBox18.Checked = .wShowGrid
            ComboBox1.Text = .wGridSpacing
            RadioButton3.Checked = .wGridLines
            RadioButton4.Checked = Not .wGridLines
            CheckBox17.Checked = .wShowToolbar
            CheckBox16.Checked = .wShowStatusBar
            CheckBox15.Checked = .wShowControlSelector
            CheckBox14.Checked = .wShowWindowsPanel
            CheckBox22.Checked = .wShowActionsPanel
            CheckBox25.Checked = .wShowFramerate
        End With
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ConvertToNumber(TextBox1, 3, 500, 100)
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, 0, 100, 50)
    End Sub

    Private Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        ConvertToNumber(TextBox3, 0, 9, 4)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With PlatformStudio.Options
            .gShowSplash = CheckBox2.Checked
            .gStartMaximized = CheckBox3.Checked
            .gCheckForUpdatesAtStartup = CheckBox23.Checked
            .gShowWelcomeDialog = CheckBox4.Checked
            .gDefaultGame = CheckBox1.Checked
            .gWarnWhenDelActions = CheckBox13.Checked
            .gUndoLevels = TextBox1.Text
            .gNumMRU = TextBox3.Text
            .gImageEditor = TextBox4.Text

            .mShowGrid = CheckBox5.Checked
            .mGridLines = RadioButton1.Checked
            .mShowToolbars = CheckBox6.Checked
            .mShowStatusBar = CheckBox7.Checked
            .mShowTileSelector = CheckBox8.Checked
            .mShowLayersPanel = CheckBox9.Checked
            .mShowLevelsPanel = CheckBox20.Checked
            .mShowPropertiesPanel = CheckBox21.Checked
            .mDrawTilePaths = CheckBox19.Checked
            .mShowFramerate = CheckBox24.Checked

            .pShowPoints = CheckBox10.Checked
            .pShowGuides = CheckBox11.Checked
            .pTintBackground = CheckBox12.Checked
            .pTint = TextBox2.Text
            .pPrecision = TrackBar1.Value

            .wShowGrid = CheckBox18.Checked
            .wGridSpacing = ComboBox1.Text
            .wGridLines = RadioButton3.Checked
            .wShowToolbar = CheckBox17.Checked
            .wShowStatusBar = CheckBox16.Checked
            .wShowControlSelector = CheckBox15.Checked
            .wShowWindowsPanel = CheckBox14.Checked
            .wShowActionsPanel = CheckBox22.Checked
            .wShowFramerate = CheckBox25.Checked
        End With
    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        TextBox2.Enabled = CheckBox12.Checked
        Label2.Enabled = CheckBox12.Checked
    End Sub

    Private Sub CheckBox18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox18.CheckedChanged
        Label3.Enabled = CheckBox18.Checked
        Label4.Enabled = CheckBox18.Checked
        ComboBox1.Enabled = CheckBox18.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PlatformStudio.Options.SetDefaults()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ofd.FileName = TextBox4.Text
        If ofd.ShowDialog = DialogResult.Cancel Then Return
        TextBox4.Text = ofd.FileName
    End Sub
End Class
