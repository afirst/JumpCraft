Public Class psfrmFileNotFound
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label3.Text = GetString("fileNotFound_Label")
        Me.Label4.Text = GetString("fileNotFound_Title")
        Me.Button1.Text = GetString("okButton")
        Me.GroupBox1.Text = GetString("fileNotFound_WhatToDoFrame")
        Me.RadioButton3.Text = GetString("fileNotFound_RetryOption")
        Me.RadioButton2.Text = GetString("fileNotFound_IgnoreOption")
        Me.RadioButton1.Text = GetString("fileNotFound_SpecifyNewFileOption")
        Me.GroupBox2.Text = GetString("fileNotFound_FutureErrorsFrame")
        Me.RadioButton6.Text = GetString("fileNotFound_ShowThisDialogOption")
        Me.RadioButton5.Text = GetString("fileNotFound_IgnoreOption")
        Me.Label6.Text = GetString("fileNotFound_With")
        Me.RadioButton4.Text = GetString("fileNotFound_ReplaceOption")
        Me.dlgOpen.Filter = GetString("allFileFilter")
        Me.dlgOpen.Title = GetString("selectAFileDialogTitle")
        Me.RadioButton7.Text = GetString("fileNotFound_CancelLoadingOption")
        Me.Text = GetString("fileNotFound_Title")
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmFileNotFound))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(-16, -16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 64)
        Me.Panel1.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(40, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(360, 16)
        Me.Label3.TabIndex = 1

        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 0

        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(168, 320)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 14

        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(48, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(352, 40)
        Me.Label1.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton7)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(48, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 112)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False

        '
        'RadioButton3
        '
        Me.RadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(8, 64)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(152, 16)
        Me.RadioButton3.TabIndex = 28

        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(320, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 20)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "..."
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(24, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(296, 20)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = ""
        '
        'RadioButton2
        '
        Me.RadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(8, 88)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(152, 16)
        Me.RadioButton2.TabIndex = 25

        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(152, 16)
        Me.RadioButton1.TabIndex = 24
        Me.RadioButton1.TabStop = True

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(48, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 88)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False

        '
        'RadioButton6
        '
        Me.RadioButton6.Checked = True
        Me.RadioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton6.Location = New System.Drawing.Point(8, 64)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(136, 16)
        Me.RadioButton6.TabIndex = 36
        Me.RadioButton6.TabStop = True

        '
        'RadioButton5
        '
        Me.RadioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(8, 64)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(136, 16)
        Me.RadioButton5.TabIndex = 35

        Me.RadioButton5.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(72, 40)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(248, 20)
        Me.TextBox3.TabIndex = 34
        Me.TextBox3.Text = ""
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 33

        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(72, 16)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(248, 20)
        Me.TextBox2.TabIndex = 32
        Me.TextBox2.Text = ""
        '
        'RadioButton4
        '
        Me.RadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(8, 16)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(136, 16)
        Me.RadioButton4.TabIndex = 31

        '
        'dlgOpen
        '


        '
        'RadioButton7
        '
        Me.RadioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.RadioButton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton7.Location = New System.Drawing.Point(8, 88)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(152, 16)
        Me.RadioButton7.TabIndex = 29

        '
        'psfrmFileNotFound
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 352)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmFileNotFound"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Overloads Function ShowDialog(ByRef Filename As String) As DialogResult
        FileNotFoundCancel = False
        FileNotFoundTries += 1
        Select Case FileNotFoundAction
            Case modFileNotFound.FileNotFoundActionEnum.Ignore
                Return DialogResult.Ignore
            Case modFileNotFound.FileNotFoundActionEnum.Replace
                Filename = Filename.Replace(FileNotFoundSearch, FileNotFoundReplace)
                If FileNotFoundTries = 1 Then
                    Return DialogResult.OK
                Else
                    RadioButton4.Checked = True
                End If
        End Select
        Label1.Text = String.Format(GetString("fileNotFound_Message"), Filename)
        TextBox1.Text = Filename
        TextBox2.Text = FileNotFoundSearch
        TextBox3.Text = FileNotFoundReplace
        ShowDialog()
        If RadioButton3.Checked Then
            DialogResult = DialogResult.OK
        ElseIf RadioButton2.Checked Then
            DialogResult = DialogResult.Ignore
        ElseIf RadioButton7.Checked Then
            DialogResult = DialogResult.Cancel
            FileNotFoundCancel = True
        Else
            DialogResult = DialogResult.OK
            Filename = TextBox1.Text
        End If
        If RadioButton4.Checked Then
            FileNotFoundAction = modFileNotFound.FileNotFoundActionEnum.Replace
            FileNotFoundSearch = TextBox2.Text
            FileNotFoundReplace = TextBox3.Text
        ElseIf RadioButton5.Checked Then
            FileNotFoundAction = modFileNotFound.FileNotFoundActionEnum.Ignore
        Else
            FileNotFoundAction = modFileNotFound.FileNotFoundActionEnum.None
        End If
        Return DialogResult
    End Function

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Enabled = RadioButton1.Checked
        Button2.Enabled = RadioButton1.Checked
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        TextBox2.Enabled = RadioButton4.Checked
        TextBox3.Enabled = RadioButton4.Checked
        Label6.Enabled = RadioButton4.Checked
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dlgOpen.FileName = TextBox1.Text
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        TextBox1.Text = dlgOpen.FileName
    End Sub
End Class

Public Module modFileNotFound
    Enum FileNotFoundActionEnum
        None = 0
        Ignore
        Replace
    End Enum

    Public FileNotFoundAction As FileNotFoundActionEnum
    Public FileNotFoundSearch As String
    Public FileNotFoundReplace As String
    Public FileNotFoundTries As Integer
    Public FileNotFoundCancel As Boolean
End Module