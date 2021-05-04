Public Class frmImportTileset
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("importTileset_Instructions")
        Me.chkC.Text = GetString("importTileset_ImportCounterActionsCheckbox")
        Me.Button1.Text = GetString("okButton")
        Me.Button2.Text = GetString("cancelButton")
        Me.chkT.Text = GetString("importTileset_ImportTimerActionsCheckbox")
        Me.chkG.Text = GetString("importTileset_ImportGroupActionsCheckbox")
        Me.chkA.Text = GetString("importTileset_ImportGeneralActionsCheckbox")
        Me.chkO.Text = GetString("importTileset_ImportOtherActionsCheckbox")
        Me.GroupBox1.Text = GetString("importTileset_AdvancedFrame")
        Me.replace.Text = GetString("importTileset_ReplaceTilesCheckbox")
        Me.Text = GetString("importTileset_Title")
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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkC As System.Windows.Forms.CheckBox
    Friend WithEvents chkT As System.Windows.Forms.CheckBox
    Friend WithEvents chkG As System.Windows.Forms.CheckBox
    Friend WithEvents chkA As System.Windows.Forms.CheckBox
    Friend WithEvents chkO As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents replace As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.chkC = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.chkT = New System.Windows.Forms.CheckBox
        Me.chkG = New System.Windows.Forms.CheckBox
        Me.chkA = New System.Windows.Forms.CheckBox
        Me.chkO = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.replace = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 32)
        Me.Label1.TabIndex = 0

        '
        'ListBox1
        '
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(8, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(224, 160)
        Me.ListBox1.TabIndex = 1
        '
        'chkC
        '
        Me.chkC.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkC.Location = New System.Drawing.Point(8, 32)
        Me.chkC.Name = "chkC"
        Me.chkC.Size = New System.Drawing.Size(192, 16)
        Me.chkC.TabIndex = 1

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(120, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 23)
        Me.Button1.TabIndex = 5

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(48, 344)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 4

        '
        'chkT
        '
        Me.chkT.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkT.Location = New System.Drawing.Point(8, 48)
        Me.chkT.Name = "chkT"
        Me.chkT.Size = New System.Drawing.Size(192, 16)
        Me.chkT.TabIndex = 2

        '
        'chkG
        '
        Me.chkG.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkG.Location = New System.Drawing.Point(8, 64)
        Me.chkG.Name = "chkG"
        Me.chkG.Size = New System.Drawing.Size(192, 16)
        Me.chkG.TabIndex = 3

        '
        'chkA
        '
        Me.chkA.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkA.Location = New System.Drawing.Point(8, 16)
        Me.chkA.Name = "chkA"
        Me.chkA.Size = New System.Drawing.Size(192, 16)
        Me.chkA.TabIndex = 0

        '
        'chkO
        '
        Me.chkO.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.chkO.Location = New System.Drawing.Point(8, 80)
        Me.chkO.Name = "chkO"
        Me.chkO.Size = New System.Drawing.Size(192, 16)
        Me.chkO.TabIndex = 4

        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkC)
        Me.GroupBox1.Controls.Add(Me.chkG)
        Me.GroupBox1.Controls.Add(Me.chkA)
        Me.GroupBox1.Controls.Add(Me.chkO)
        Me.GroupBox1.Controls.Add(Me.chkT)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 104)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False

        '
        'replace
        '
        Me.replace.Checked = True
        Me.replace.CheckState = System.Windows.Forms.CheckState.Checked
        Me.replace.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.replace.Location = New System.Drawing.Point(8, 208)
        Me.replace.Name = "replace"
        Me.replace.Size = New System.Drawing.Size(168, 16)
        Me.replace.TabIndex = 2

        '
        'frmImportTileset
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(242, 376)
        Me.Controls.Add(Me.replace)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportTileset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Overloads Sub ShowDialog(ByVal t As psTileset)
        For i As Integer = 1 To t.NumTiles
            ListBox1.Items.Add(t.tiles(i).name)
            ListBox1.SetSelected(i - 1, True)
        Next
        For i As Integer = 0 To ListBox1.Items.Count - 1
            ListBox1.SetSelected(i, True)
        Next
        ShowDialog()
    End Sub
End Class
