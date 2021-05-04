Imports PlatformStudio

Public Class psfrmBackgroundEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.GroupBox1.Text = GetString("backgroundEd_BackStyle")
        Me.RadioButton5.Text = GetString("backgroundEd_PictureOption")
        Me.RadioButton4.Text = GetString("backgroundEd_GradientOption")
        Me.RadioButton3.Text = GetString("backgroundEd_SolidOption")
        Me.Label5.Text = GetString("backgroundEd_FileLabel")
        Me.Label11.Text = GetString("colorEd_OpacityLabel")
        Me.Label9.Text = GetString("colorEd_OpacityLabel")
        Me.RadioButton2.Text = GetString("backgroundEd_VerticalOption")
        Me.RadioButton1.Text = GetString("backgroundEd_HorizontalOption")
        Me.Label4.Text = GetString("backgroundEd_StyleLabel")
        Me.Label3.Text = GetString("backgroundEd_Color2Label")
        Me.Label2.Text = GetString("backgroundEd_Color1Label")
        Me.Label6.Text = GetString("colorEd_OpacityLabel")
        Me.Label1.Text = GetString("colorEd_ColorLabel")
        Me.Button5.Text = GetString("cancelButton")
        Me.Button6.Text = GetString("okButton")
        Me.GroupBox5.Text = GetString("animEd_PreviewFrame")
        Me.Text = GetString("backgroundEd_Title")
        Me.dlgOpen.Filter = GetString("imageFileFilter")
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents picPrev As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOpac1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOpac2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOpac3 As System.Windows.Forms.TextBox
    Friend WithEvents picTrans As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmBackgroundEditor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtOpac3 = New System.Windows.Forms.TextBox()
        Me.txtOpac2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtOpac1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.picPrev = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.picTrans = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioButton5, Me.RadioButton4, Me.RadioButton3, Me.GroupBox4, Me.GroupBox3, Me.GroupBox2})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 328)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False

        '
        'RadioButton5
        '
        Me.RadioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(16, 264)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(64, 16)
        Me.RadioButton5.TabIndex = 5

        '
        'RadioButton4
        '
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(16, 96)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(72, 16)
        Me.RadioButton4.TabIndex = 3

        '
        'RadioButton3
        '
        Me.RadioButton3.Checked = True
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(16, 16)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True

        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.TextBox1, Me.Label5})
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox4.Location = New System.Drawing.Point(8, 264)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(184, 56)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(144, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 16)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "..."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(64, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 0

        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOpac3, Me.txtOpac2, Me.Label10, Me.Label11, Me.Label8, Me.Label9, Me.RadioButton2, Me.RadioButton1, Me.Label4, Me.Button3, Me.PictureBox3, Me.Label3, Me.Button2, Me.PictureBox2, Me.Label2})
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(184, 160)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'txtOpac3
        '
        Me.txtOpac3.Location = New System.Drawing.Point(64, 93)
        Me.txtOpac3.Name = "txtOpac3"
        Me.txtOpac3.Size = New System.Drawing.Size(40, 20)
        Me.txtOpac3.TabIndex = 27
        Me.txtOpac3.Text = "0"
        '
        'txtOpac2
        '
        Me.txtOpac2.Location = New System.Drawing.Point(64, 45)
        Me.txtOpac2.Name = "txtOpac2"
        Me.txtOpac2.Size = New System.Drawing.Size(40, 20)
        Me.txtOpac2.TabIndex = 26
        Me.txtOpac2.Text = "0"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(104, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 16)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "%"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 23

        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(104, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "%"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 20

        '
        'RadioButton2
        '
        Me.RadioButton2.Checked = True
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(56, 136)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(96, 16)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.TabStop = True

        '
        'RadioButton1
        '
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(56, 120)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(96, 16)
        Me.RadioButton1.TabIndex = 5

        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 4

        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(144, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 16)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "..."
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Location = New System.Drawing.Point(64, 72)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(80, 16)
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 2

        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(144, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 16)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "..."
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(64, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(80, 16)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 0

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOpac1, Me.Label7, Me.Label6, Me.Button1, Me.PictureBox1, Me.Label1})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 72)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtOpac1
        '
        Me.txtOpac1.Location = New System.Drawing.Point(64, 48)
        Me.txtOpac1.Name = "txtOpac1"
        Me.txtOpac1.Size = New System.Drawing.Size(40, 20)
        Me.txtOpac1.TabIndex = 6
        Me.txtOpac1.Text = "0"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(104, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "%"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 3

        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(144, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 16)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(64, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 16)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 0

        '
        'Button5
        '
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button5.Location = New System.Drawing.Point(352, 344)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 2

        '
        'Button6
        '
        Me.Button6.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button6.Location = New System.Drawing.Point(432, 344)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 3

        '
        'picPrev
        '
        Me.picPrev.Location = New System.Drawing.Point(8, 16)
        Me.picPrev.Name = "picPrev"
        Me.picPrev.Size = New System.Drawing.Size(272, 304)
        Me.picPrev.TabIndex = 17
        Me.picPrev.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.picPrev})
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(216, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(288, 328)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False

        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = ""
        Me.dlgOpen.Multiselect = True
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        '
        'picTrans
        '
        Me.picTrans.Image = CType(resources.GetObject("picTrans.Image"), System.Drawing.Bitmap)
        Me.picTrans.Location = New System.Drawing.Point(80, 344)
        Me.picTrans.Name = "picTrans"
        Me.picTrans.Size = New System.Drawing.Size(16, 16)
        Me.picTrans.TabIndex = 4
        Me.picTrans.TabStop = False
        Me.picTrans.Visible = False
        '
        'psfrmBackgroundEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(514, 376)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.picTrans, Me.GroupBox5, Me.Button5, Me.Button6, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmBackgroundEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim curBack As psUI.psBackground
    Dim DoNotPreview As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dlgColor.Color = PictureBox1.BackColor
        If dlgColor.ShowDialog = DialogResult.Cancel Then Exit Sub
        PictureBox1.BackColor = dlgColor.Color
        If txtOpac1.Text = 0 Then txtOpac1.Text = 100
        curBack.Color1 = Color.FromArgb(txtOpac1.Text * 255 / 100, dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)
        UpdatePreview()
    End Sub

    Private Sub txtOpac1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOpac1.Validating
        ConvertToNumber(txtOpac1, 0, 100, 100)
        curBack.Color1 = Color.FromArgb(txtOpac1.Text * 255 / 100, PictureBox1.BackColor.R, PictureBox1.BackColor.G, PictureBox1.BackColor.B)
        UpdatePreview()
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        curBack.Type = psUI.psBackground.BackgroundType.Solid
        UpdatePreview()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        GroupBox4.Enabled = False
        curBack.Type = psUI.psBackground.BackgroundType.Gradient
        UpdatePreview()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox4.Enabled = True
        curBack.Type = psUI.psBackground.BackgroundType.Picture
        curBack.imgFilename = TextBox1.Text
        UpdatePreview()
    End Sub

    Overloads Function ShowDialog(ByVal Background As psUI.psBackground) As psUI.psBackground
        DoNotLoadImages = True
        curBack = Background.Clone
        DoNotLoadImages = False
        DoNotPreview = True
        With curBack
            PictureBox1.BackColor = Color.FromArgb(.Color1.R, .Color1.G, .Color1.B)
            txtOpac1.Text = Math.Round(.Color1.A * 100 / 255)
            PictureBox2.BackColor = Color.FromArgb(.Color1.R, .Color1.G, .Color1.B)
            txtOpac2.Text = Math.Round(.Color1.A * 100 / 255)
            PictureBox3.BackColor = Color.FromArgb(.Color2.R, .Color2.G, .Color2.B)
            txtOpac3.Text = Math.Round(.Color2.A * 100 / 255)
            TextBox1.Text = .imgFilename
            If .Horizontal Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            If .Type = psUI.psBackground.BackgroundType.Solid Then
                RadioButton3.Checked = True
            ElseIf .Type = psUI.psBackground.BackgroundType.Gradient Then
                RadioButton4.Checked = True
            ElseIf .Type = psUI.psBackground.BackgroundType.Picture Then
                RadioButton5.Checked = True
            End If
            .imgFilename = .imgFilename
        End With
        DoNotPreview = False
        UpdatePreview()
        ShowDialog()
        Return curBack
    End Function

    Overloads Function ShowDialog(ByVal Background As psUI.psBackground, ByRef PasteTo As psUI.psBackground) As DialogResult
        PasteTo = ShowDialog(Background)
        Return DialogResult
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dlgColor.Color = PictureBox2.BackColor
        If dlgColor.ShowDialog = DialogResult.Cancel Then Exit Sub
        PictureBox2.BackColor = dlgColor.Color
        If txtOpac2.Text = 0 Then txtOpac2.Text = 100
        curBack.Color1 = Color.FromArgb(txtOpac2.Text * 255 / 100, dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)
        UpdatePreview()
    End Sub

    Private Sub txtOpac2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOpac2.Validating
        ConvertToNumber(txtOpac2, 0, 100, 100)
        curBack.Color1 = Color.FromArgb(txtOpac2.Text * 255 / 100, PictureBox2.BackColor.R, PictureBox2.BackColor.G, PictureBox2.BackColor.B)
        UpdatePreview()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dlgColor.Color = PictureBox3.BackColor
        If dlgColor.ShowDialog = DialogResult.Cancel Then Exit Sub
        PictureBox3.BackColor = dlgColor.Color
        If txtOpac3.Text = 0 Then txtOpac3.Text = 100
        curBack.Color2 = Color.FromArgb(txtOpac3.Text * 255 / 100, dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)
        UpdatePreview()
    End Sub

    Private Sub txtOpac3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOpac3.Validating
        ConvertToNumber(txtOpac3, 0, 100, 100)
        curBack.Color2 = Color.FromArgb(txtOpac3.Text * 255 / 100, PictureBox3.BackColor.R, PictureBox3.BackColor.G, PictureBox3.BackColor.B)
        UpdatePreview()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dlgOpen.FileName = TextBox1.Text
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        TextBox1.Text = dlgOpen.FileName
        curBack.imgFilename = dlgOpen.FileName
        UpdatePreview()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        curBack.Horizontal = True
        UpdatePreview()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        curBack.Horizontal = False
        UpdatePreview()
    End Sub

    Sub UpdatePreview()
        If DoNotPreview = False Then curBack.MakePreview(picPrev, picTrans)
    End Sub
End Class
