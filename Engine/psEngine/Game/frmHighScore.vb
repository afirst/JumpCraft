Namespace GamePlayer
    Public Class frmHighScore
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.Label1.Text = GetString("highScores_Congrats")
            Me.Label2.Text = GetString("highScores_EnterName")
            Me.Button1.Text = GetString("okButton")
            Me.Text = GetString("highScores_Title")
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
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.Button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(272, 16)
            Me.Label1.TabIndex = 0

            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(8, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(264, 16)
            Me.Label2.TabIndex = 1

            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(8, 40)
            Me.TextBox1.MaxLength = 32
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(272, 20)
            Me.TextBox1.TabIndex = 2
            Me.TextBox1.Text = "TextBox1"
            '
            'Button1
            '
            Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
            Me.Button1.Location = New System.Drawing.Point(114, 72)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(64, 24)
            Me.Button1.TabIndex = 3

            '
            'frmHighScore
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 104)
            Me.ControlBox = False
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmHighScore"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub

#End Region

        Overloads Sub ShowDialog(ByRef txt As String)
            TextBox1.Text = txt
            If ShowDialog() = DialogResult.OK Then txt = TextBox1.Text
        End Sub

        Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
            If e.KeyChar = Chr(13) Then
                e.Handled = True
                DialogResult = DialogResult.OK
            End If
        End Sub

        Private Sub frmHighScore_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Game.GameProperties.Windowed Then TopMost = False
        End Sub
    End Class
End Namespace