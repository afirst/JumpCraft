Public Class frmCompileError
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstErr As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents aTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As PlatformStudio.CodeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompileError))
        Me.aTextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstErr = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TextBox1 = New PlatformStudio.CodeEditor
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'aTextBox1
        '
        Me.aTextBox1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aTextBox1.HideSelection = False
        Me.aTextBox1.Location = New System.Drawing.Point(48, 56)
        Me.aTextBox1.Multiline = True
        Me.aTextBox1.Name = "aTextBox1"
        Me.aTextBox1.ReadOnly = True
        Me.aTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.aTextBox1.Size = New System.Drawing.Size(352, 208)
        Me.aTextBox1.TabIndex = 1
        Me.aTextBox1.WordWrap = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 2
        '
        'lstErr
        '
        Me.lstErr.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.lstErr.FullRowSelect = True
        Me.lstErr.GridLines = True
        Me.lstErr.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstErr.HideSelection = False
        Me.lstErr.Location = New System.Drawing.Point(48, 288)
        Me.lstErr.Name = "lstErr"
        Me.lstErr.Size = New System.Drawing.Size(352, 80)
        Me.lstErr.TabIndex = 7
        Me.lstErr.UseCompatibleStateImageBehavior = False
        Me.lstErr.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "!"
        Me.ColumnHeader1.Width = 24
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 264
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(169, 376)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 8
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
        Me.Panel1.TabIndex = 10
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
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Location = New System.Drawing.Point(48, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(352, 208)
        Me.Panel2.TabIndex = 11
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsTab = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.DoColorCode = True
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.TextBox1.Size = New System.Drawing.Size(348, 204)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = ""
        Me.TextBox1.WordWrap = False
        '
        'frmCompileError
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(410, 408)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstErr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.aTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompileError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim tmpCode As String

    Overloads Sub ShowDialog(ByVal Code As String, ByVal err() As System.CodeDom.Compiler.CompilerError)
        tmpCode = Code
        TextBox1.Text = tmpCode

        'List the errors
        Dim i As Integer
        lstErr.Items.Clear()
        For i = 1 To UBound(err)
            lstErr.Items.Add(IIf(err(i).IsWarning, "", "!"))
            With lstErr.Items(lstErr.Items.Count - 1)
                .SubItems.Add(err(i).Line)
                .SubItems.Add(err(i).ErrorText)
            End With
        Next

        'TextBox1.Locked = True
        TextBox1.Select(0, 0)
        TextBox1.ScrollToCaret()
        'TextBox1.Redraw()
        ShowDialog()
    End Sub

    Private Sub lstErr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstErr.SelectedIndexChanged
        'Dim Lines() As String = Split(tmpCode, vbCrLf)
        Dim i As Integer, tmpS As Integer
        Try
            If lstErr.SelectedIndices.Count = 0 Then Exit Sub
            With lstErr.SelectedItems(0)
                For i = 0 To CInt(.SubItems(1).Text) - 2
                    tmpS += TextBox1.Lines(i).Length + 1
                Next
                TextBox1.LockUpdate = True
                TextBox1.Select(tmpS, TextBox1.Lines(.SubItems(1).Text - 1).Length)
                TextBox1.ScrollToCaret()
                TextBox1.Select()
                TextBox1.LockUpdate = False
                TextBox1.Invalidate()
            End With
        Catch
        End Try
    End Sub

    Private Sub frmCompileError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label2.Text = GetString("compileError_ErrorsLabel")
        Me.ColumnHeader4.Text = GetString("compileError_LineColumnHeader")
        Me.ColumnHeader3.Text = GetString("compileError_MessageColumnHeader")
        Me.Button1.Text = GetString("okButton")
        Me.Label3.Text = GetString("compileError_Subheading")
        Me.Label4.Text = GetString("compileError_Title")
        Me.Text = GetString("compileError_Title")
    End Sub
End Class
