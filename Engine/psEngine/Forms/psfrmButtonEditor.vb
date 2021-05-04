Public Class psfrmButtonEditor
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents dlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents picTrans As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboRollAnim As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRollLen As System.Windows.Forms.TextBox
    Friend WithEvents txtPressLen As System.Windows.Forms.TextBox
    Friend WithEvents cboPressAnim As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmButtonEditor))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPressLen = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPressAnim = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRollLen = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboRollAnim = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.dlgColor = New System.Windows.Forms.ColorDialog
        Me.dlgFont = New System.Windows.Forms.FontDialog
        Me.picTrans = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Button text:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(104, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(168, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Control1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Background:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(104, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(224, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Edit..."
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(224, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "&Edit..."
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(104, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Rollover:"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(224, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 20)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "&Edit..."
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Location = New System.Drawing.Point(104, 136)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pressed:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foreground"
        '
        'CheckBox3
        '
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox3.Location = New System.Drawing.Point(104, 112)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(104, 16)
        Me.CheckBox3.TabIndex = 8
        Me.CheckBox3.Text = "Shadow"
        '
        'PictureBox4
        '
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox4.Location = New System.Drawing.Point(104, 80)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button8.Location = New System.Drawing.Point(224, 80)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(48, 20)
        Me.Button8.TabIndex = 6
        Me.Button8.Text = "&Edit..."
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Text color:"
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button7.Location = New System.Drawing.Point(224, 48)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(48, 20)
        Me.Button7.TabIndex = 4
        Me.Button7.Text = "&Edit..."
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Location = New System.Drawing.Point(104, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(120, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Font:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPressLen)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cboPressAnim)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtRollLen)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cboRollAnim)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(304, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 224)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Background"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(152, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 23)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "seconds"
        '
        'txtPressLen
        '
        Me.txtPressLen.Location = New System.Drawing.Point(104, 192)
        Me.txtPressLen.Name = "txtPressLen"
        Me.txtPressLen.Size = New System.Drawing.Size(40, 20)
        Me.txtPressLen.TabIndex = 18
        Me.txtPressLen.Text = "0.3"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(40, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Length:"
        '
        'cboPressAnim
        '
        Me.cboPressAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPressAnim.Location = New System.Drawing.Point(104, 164)
        Me.cboPressAnim.Name = "cboPressAnim"
        Me.cboPressAnim.Size = New System.Drawing.Size(121, 21)
        Me.cboPressAnim.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(40, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Animation"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(152, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 23)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "seconds"
        '
        'txtRollLen
        '
        Me.txtRollLen.Location = New System.Drawing.Point(104, 104)
        Me.txtRollLen.Name = "txtRollLen"
        Me.txtRollLen.Size = New System.Drawing.Size(40, 20)
        Me.txtRollLen.TabIndex = 13
        Me.txtRollLen.Text = "0.3"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(40, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Length:"
        '
        'cboRollAnim
        '
        Me.cboRollAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRollAnim.Location = New System.Drawing.Point(104, 76)
        Me.cboRollAnim.Name = "cboRollAnim"
        Me.cboRollAnim.Size = New System.Drawing.Size(121, 21)
        Me.cboRollAnim.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(40, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Animation"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox2)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.PictureBox5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(8, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 112)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Border"
        '
        'CheckBox2
        '
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox2.Location = New System.Drawing.Point(104, 72)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(104, 16)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "3D border"
        '
        'CheckBox1
        '
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox1.Location = New System.Drawing.Point(104, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 16)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Border visible"
        '
        'PictureBox5
        '
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox5.Location = New System.Drawing.Point(104, 16)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox5.TabIndex = 3
        Me.PictureBox5.TabStop = False
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.Location = New System.Drawing.Point(224, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(48, 20)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "&Edit..."
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Border color:"
        '
        'Button5
        '
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button5.Location = New System.Drawing.Point(520, 296)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "&OK"
        '
        'Button6
        '
        Me.Button6.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button6.Location = New System.Drawing.Point(440, 296)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "&Cancel"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.PictureBox6)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Location = New System.Drawing.Point(304, 240)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(288, 48)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Preview"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Black
        Me.PictureBox6.Location = New System.Drawing.Point(108, 16)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(72, 24)
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        '
        'dlgFont
        '
        Me.dlgFont.FontMustExist = True
        '
        'picTrans
        '
        Me.picTrans.Image = CType(resources.GetObject("picTrans.Image"), System.Drawing.Image)
        Me.picTrans.Location = New System.Drawing.Point(384, 304)
        Me.picTrans.Name = "picTrans"
        Me.picTrans.Size = New System.Drawing.Size(16, 16)
        Me.picTrans.TabIndex = 6
        Me.picTrans.TabStop = False
        Me.picTrans.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 40
        '
        'psfrmButtonEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(602, 328)
        Me.Controls.Add(Me.picTrans)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmButtonEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Button Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim tmpCtrl As psUI.psControl.psButton

    Overloads Function ShowDialog(ByRef Control As psUI.psControl) As DialogResult
        tmpCtrl = Control.Clone

        'Set fields
        With tmpCtrl
            TextBox1.Text = .Text
            .Background.MakePreview(PictureBox1, picTrans)
            .Over.MakePreview(PictureBox2, picTrans)
            .Down.MakePreview(PictureBox3, picTrans)
            PictureBox4.BackColor = .ForeColor
            PictureBox5.BackColor = .BorderColor
            TextBox2.Text = FontText
            CheckBox1.Checked = .Border
            CheckBox2.Checked = .Border3D
            CheckBox3.Checked = .Shadow
            cboRollAnim.Items.AddRange(.Effects)
            cboRollAnim.SelectedIndex = .RolloverEffect
            txtRollLen.Text = .RolloverEffectLength
            cboPressAnim.Items.AddRange(.Effects)
            cboPressAnim.SelectedIndex = .PushEffect
            txtPressLen.Text = .PushEffectLength
        End With
        tmpCtrl.DrawPreview(PictureBox6, picTrans)

        Dim dr As DialogResult
        dr = ShowDialog()
        If dr = DialogResult.OK Then
            UpdateUndo("Edit Button", psMod1.UndoType.Windows)
            Control = tmpCtrl
        End If
        Return dr
    End Function

    Private ReadOnly Property FontText() As String
        Get
            With tmpCtrl
                Return .Font.Name & "; " & .Font.Size & " pt; Bold: " & CStr(.Font.Bold) & "; Italic: " & CStr(.Font.Italic) & "; Underline: " & CStr(.Font.Underline) & "; Strikeout: " & CStr(.Font.Strikeout)
            End With
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fBack As New psfrmBackgroundEditor()
        fBack.ShowDialog(tmpCtrl.Background, tmpCtrl.Background)
        tmpCtrl.Background.MakePreview(PictureBox1, picTrans)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fBack As New psfrmBackgroundEditor
        fBack.ShowDialog(tmpCtrl.Over, tmpCtrl.Over)
        tmpCtrl.Over.MakePreview(PictureBox2, picTrans)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fBack As New psfrmBackgroundEditor
        fBack.ShowDialog(tmpCtrl.Down, tmpCtrl.Down)
        tmpCtrl.Down.MakePreview(PictureBox3, picTrans)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dlgColor.Color = tmpCtrl.BorderColor
        If dlgColor.ShowDialog() = DialogResult.OK Then
            tmpCtrl.BorderColor = dlgColor.Color
            PictureBox5.BackColor = dlgColor.Color
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        dlgColor.Color = tmpCtrl.ForeColor
        If dlgColor.ShowDialog() = DialogResult.OK Then
            tmpCtrl.ForeColor = dlgColor.Color
            PictureBox4.BackColor = dlgColor.Color
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        dlgFont.Font = tmpCtrl.Font
        If dlgFont.ShowDialog = DialogResult.OK Then
            tmpCtrl.Font = dlgFont.Font
            TextBox2.Text = FontText
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If tmpCtrl Is Nothing Then Exit Sub
        tmpCtrl.Border = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If tmpCtrl Is Nothing Then Exit Sub
        tmpCtrl.Border3D = CheckBox2.Checked
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If tmpCtrl Is Nothing Then Exit Sub
        tmpCtrl.Text = TextBox1.Text
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        If e.Button = MouseButtons.Left Then tmpCtrl.setMouseDown(True, True)
    End Sub

    Private Sub PictureBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        If e.Button = MouseButtons.Left Then tmpCtrl.setMouseDown(False, True)
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If tmpCtrl Is Nothing Then Exit Sub
        tmpCtrl.Shadow = CheckBox3.Checked
        tmpCtrl.DrawPreview(PictureBox6, picTrans)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If tmpCtrl Is Nothing Then Return
        Dim pt As Point = PictureBox6.PointToClient(PictureBox6.MousePosition)
        tmpCtrl.setMouseInside(pt.X >= 0 And pt.Y >= 0 And pt.X <= PictureBox6.Width And pt.Y <= PictureBox6.Height, True)
        tmpCtrl.DrawPreview(PictureBox6, picTrans)
    End Sub

    Private Sub txtRollLen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRollLen.Validating
        ConvertToNumber(txtRollLen, 0, 5, tmpCtrl.RolloverEffectLength, 2)
        tmpCtrl.RolloverEffectLength = txtRollLen.Text
    End Sub

    Private Sub txtPressLen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPressLen.Validating
        ConvertToNumber(txtPressLen, 0, 5, tmpCtrl.PushEffectLength, 2)
        tmpCtrl.PushEffectLength = txtPressLen.Text
    End Sub

    Private Sub cboRollAnim_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRollAnim.SelectedIndexChanged
        tmpCtrl.RolloverEffect = cboRollAnim.SelectedIndex
    End Sub

    Private Sub cboPressAnim_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPressAnim.SelectedIndexChanged
        tmpCtrl.PushEffect = cboPressAnim.SelectedIndex
    End Sub
End Class