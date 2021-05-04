Public Class frmSplash
    Inherits System.Windows.Forms.Form

    Private Const CS_DROPSHADOW As Integer = &H20000

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "JumpCraft " & PlatformStudio.AssemblyVersion
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
    Friend WithEvents p As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.p = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'p
        '
        Me.p.Dock = System.Windows.Forms.DockStyle.Fill
        Me.p.Location = New System.Drawing.Point(0, 0)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(467, 215)
        Me.p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p.TabIndex = 0
        Me.p.TabStop = False
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(467, 215)
        Me.Controls.Add(Me.p)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p.Image = New Bitmap(Game.Root & MyEdition.SplashFile)
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            If Environment.OSVersion.Version.Major < 5.1 Then Return MyBase.CreateParams
            Try
                Dim pCPsParams As CreateParams = MyBase.CreateParams
                With pCPsParams
                    .ClassStyle = CS_DROPSHADOW
                End With
                Return (pCPsParams)
            Catch
                Return MyBase.CreateParams
            End Try
        End Get
    End Property
End Class