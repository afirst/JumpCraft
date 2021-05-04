Namespace GamePlayer
    Public Class frmError
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.Button1.Text = GetString("error_IgnoreButton")
            Me.Button2.Text = GetString("error_QuitButton")
            Me.Button4.Text = GetString("error_IgnoreAllButton")
            Me.Text = GetString("gameTesterTitle")
            Me.Label2.Text = GetString("error_Message") & " "
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
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmError))
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.Button1 = New System.Windows.Forms.Button
            Me.Button2 = New System.Windows.Forms.Button
            Me.Button4 = New System.Windows.Forms.Button
            Me.Label3 = New System.Windows.Forms.TextBox
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Me.PictureBox1.Location = New System.Drawing.Point(8, 56)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.SystemColors.Window
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(-16, -16)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(376, 64)
            Me.Panel1.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(40, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(256, 16)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = GetString("error_Message") & " "
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(24, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "ERROR_TYPE"
            '
            'Button1
            '
            Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Retry
            Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
            Me.Button1.Location = New System.Drawing.Point(30, 176)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(72, 24)
            Me.Button1.TabIndex = 4

            '
            'Button2
            '
            Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Abort
            Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
            Me.Button2.Location = New System.Drawing.Point(190, 176)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(72, 24)
            Me.Button2.TabIndex = 5

            '
            'Button4
            '
            Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Ignore
            Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
            Me.Button4.Location = New System.Drawing.Point(110, 176)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(72, 24)
            Me.Button4.TabIndex = 7

            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.SystemColors.Control
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.Label3.Location = New System.Drawing.Point(48, 56)
            Me.Label3.Multiline = True
            Me.Label3.Name = "Label3"
            Me.Label3.ReadOnly = True
            Me.Label3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.Label3.Size = New System.Drawing.Size(232, 112)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "TextBox1"
            '
            'frmError
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 208)
            Me.ControlBox = False
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Button4)
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PictureBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmError"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Overloads Function ShowDialog(ByVal ErrorType As String, ByVal OccuredWhile As String, ByVal ErrorText As String, Optional ByVal CanIgnore As Boolean = False, Optional ByVal CanIgnoreAll As Boolean = True) As DialogResult
            Label1.Text = ErrorType
            Label2.Text &= OccuredWhile
            Label3.Text = ErrorText
            Button1.Enabled = CanIgnore
            Button4.Enabled = CanIgnore And CanIgnoreAll
            Return ShowDialog()
        End Function

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            f.RequestClose()
        End Sub

        Private Sub frmError_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Game.GameProperties.Windowed = False Then TopMost = True
        End Sub
    End Class
End Namespace