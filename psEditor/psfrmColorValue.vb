Imports PlatformStudio

Public Class psfrmColorValue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.Label3.Text = GetString("colorEd_OpacityLabel")
        Me.Label2.Text = GetString("colorEd_ColorLabel")
        Me.Text = GetString("colorEd_Title")
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dlgColor = New System.Windows.Forms.ColorDialog
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(152, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2

        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(72, 88)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1

        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.TextBox1, Me.Label3, Me.Button1, Me.PictureBox1, Me.Label2})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Value for ""Parameter"":"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "%"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(56, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(56, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "100"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 2

        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(176, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(56, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 20)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 0

        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        '
        'psfrmColorValue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(234, 118)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.Button2, Me.Button3})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmColorValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim CurParam As psActions.psActionBehavior.psActionParameter
    Dim OldValue As String

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TextBox1_Validating(Nothing, Nothing)
            DialogResult = DialogResult.OK
        End If
    End Sub

    Overloads Function ShowDialog(ByRef param As String, ByVal ParamDat As psActions.psActionBehavior.psActionParameter) As DialogResult
        CurParam = ParamDat
        OldValue = param

        GroupBox1.Text = String.Format(GetString("colorEd_Heading"), ParamDat.Name)

        Dim tmpColor As Color
        Try
            tmpColor = Color.FromName(param)
            If tmpColor.ToArgb = 0 Then tmpColor = Color.FromArgb(Convert.ToInt32(param, 16))
        Catch
            tmpColor = Color.Black
        End Try

        TextBox1.Visible = True
        TextBox1.Text = Math.Round(tmpColor.A * 100 / 255)
        PictureBox1.BackColor = Color.FromArgb(tmpColor.R, tmpColor.G, tmpColor.B)

        Dim dr As DialogResult
        dr = ShowDialog()

        If dr = DialogResult.OK Then
            Dim tmpColor2 As Color = Color.FromArgb(TextBox1.Text * 255 / 100, PictureBox1.BackColor.R, PictureBox1.BackColor.G, PictureBox1.BackColor.B)
            Dim tmpKnownColor As KnownColor
            Dim KnownColors() As KnownColor = System.Enum.GetValues(GetType(KnownColor))
            For Each tmpKnownColor In KnownColors
                With Color.FromKnownColor(tmpKnownColor)
                    If Not (.Name.StartsWith("Active") Or _
                    .Name.StartsWith("App") Or _
                    .Name.StartsWith("Control") Or _
                    .Name.StartsWith("Desktop") Or _
                    .Name.StartsWith("GrayText") Or _
                    .Name.StartsWith("Highlight") Or _
                    .Name.StartsWith("HotTrack") Or _
                    .Name.StartsWith("Inactive") Or _
                    .Name.StartsWith("Info") Or _
                    .Name.StartsWith("Menu") Or _
                    .Name.StartsWith("Scrollbar") Or _
                    .Name.StartsWith("Window")) Then
                        If tmpColor2.ToArgb = .ToArgb Then
                            param = .Name
                            GoTo Done
                        End If
                    End If
                End With
            Next
            param = Hex(tmpColor2.ToArgb)
        End If
Done:
        Return dr
    End Function

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ConvertToNumber(TextBox1, 0, 100, 100)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dlgColor.Color = PictureBox1.BackColor
        If dlgColor.ShowDialog = DialogResult.Cancel Then Exit Sub
        PictureBox1.BackColor = dlgColor.Color
    End Sub
End Class
