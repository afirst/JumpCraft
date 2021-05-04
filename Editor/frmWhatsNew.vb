Public Class frmWhatsNew
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
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWhatsNew))
        Me.rtb = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'rtb
        '
        Me.rtb.BackColor = System.Drawing.SystemColors.Window
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Location = New System.Drawing.Point(0, 0)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.Size = New System.Drawing.Size(496, 366)
        Me.rtb.TabIndex = 0
        Me.rtb.Text = ""
        '
        'frmWhatsNew
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 366)
        Me.Controls.Add(Me.rtb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWhatsNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "What's New"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmWhatsNew_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim filename As String = Application.StartupPath & "\whatsnew.rtf"
        Try
            rtb.LoadFile(filename)
        Catch
            MessageBox.Show("Cannot load """ & filename & """.  This file may be in use by another application, or does not exist.", "Error Loading File", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End Try
    End Sub
End Class