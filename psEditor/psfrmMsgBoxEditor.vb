Public Class psfrmMsgBoxEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("msgBoxEd_TitleLabel")
        Me.Label2.Text = GetString("msgBoxEd_MessageLabel")
        Me.Label3.Text = GetString("msgBoxEd_IconLabel")
        Me.Button2.Text = GetString("cancelButton")
        Me.Button1.Text = GetString("okButton")
        Me.Button3.Text = GetString("msgBoxEd_PreviewButton")
        Me.Text = GetString("msgBoxEd_Title")
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
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmMsgBoxEditor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0

        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(64, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 2

        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(64, 40)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(216, 80)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 4

        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {GetString("noValueCapital"), GetString("msgBoxEd_Icon_Information"), GetString("msgBoxEd_Icon_Question"), GetString("msgBoxEd_Icon_Exclamation"), GetString("msgBoxEd_Icon_Error")})
        Me.ComboBox1.Location = New System.Drawing.Point(64, 128)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(256, 128)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(128, 160)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 7

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(208, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 8

        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(48, 160)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 6

        '
        'psfrmMsgBoxEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 192)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Button2, Me.Button1, Me.PictureBox1, Me.ComboBox1, Me.Label3, Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmMsgBoxEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.ResumeLayout(False)

    End Sub

#End Region

    Overloads Function ShowDialog(ByRef Param1 As String, ByRef Param2 As String, ByRef Param3 As Integer) As DialogResult
        TextBox1.Text = Param1
        TextBox2.Text = Param2
        ComboBox1.SelectedIndex = Param3

        Dim dr As DialogResult
        dr = ShowDialog()
        If dr = DialogResult.OK Then
            Param1 = TextBox1.Text
            Param2 = TextBox2.Text
            Param3 = ComboBox1.SelectedIndex
        End If

        Return dr
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                PictureBox1.Image = Nothing
            Case 1
                PictureBox1.Image = SystemIcons.Information.ToBitmap
            Case 2
                PictureBox1.Image = SystemIcons.Question.ToBitmap
            Case 3
                PictureBox1.Image = SystemIcons.Exclamation.ToBitmap
            Case 4
                PictureBox1.Image = SystemIcons.Error.ToBitmap
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Select Case ComboBox1.SelectedIndex
            Case 0
                MessageBox.Show(TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.None)
            Case 1
                MessageBox.Show(TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case 2
                MessageBox.Show(TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
            Case 3
                MessageBox.Show(TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case 4
                MessageBox.Show(TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub
End Class
