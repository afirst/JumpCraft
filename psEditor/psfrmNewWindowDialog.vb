Imports PlatformStudio

Public Class psfrmNewWindowDialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("cancelButton")
        Me.Button1.Text = GetString("okButton")
        Me.Label1.Text = GetString("newWindow_WindowNameLabel")
        Me.TextBox1.Text = GetString("newWindow_WindowLabel")
        Me.Text = GetString("newWindow_Title")
        Me.TextBox1.Items.AddRange(New Object() {GetString1("windows_HelpWindow"), GetString1("windows_AboutWindow"), GetString1("windows_HighScoresWindow"), GetString1("windows_PauseWindow"), GetString1("windows_WinWindow"), GetString1("windows_LoseWindow"), GetString1("windows_LevelCompletedWindow")})
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(64, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 4

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(144, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 5

        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 0

        '
        'TextBox1
        '

        Me.TextBox1.Location = New System.Drawing.Point(88, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 21)
        Me.TextBox1.TabIndex = 6

        '
        'psfrmNewWindowDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(226, 72)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmNewWindowDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim RenameWindow As Boolean

    Function ShowRenameWindow(ByRef Name As String) As String
        RenameWindow = True
        Text = GetString("renameWindowIconTooltip")
        TextBox1.Text = Name
        Dim dr As DialogResult = ShowDialog()
        If dr = DialogResult.OK Then
            UndoRedo.UpdateUndo(GetString("renameWindowIconTooltip"), UndoRedo.UndoType.Windows)
            Return TextBox1.Text
        Else
            Return Name
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not RenameWindow Then
            UndoRedo.UpdateUndo(GetString("newWindowIconTooltip"), UndoRedo.UndoType.Windows)
            With Game.AddWindow
                .Name = TextBox1.Text
                .Background = Game.windows.Windows(Game.windows.Windows.GetUpperBound(0) - 1).Background
            End With
            Game.CurWinIndex = Game.numWindows
            Editor.WinSel_Refresh()
            Editor.WinSel_SelectLast()
            Editor.winedit.DoResize()
        End If
    End Sub

    Private Sub psfrmNewWindowDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To Game.numMaps
            TextBox1.Items.Add(String.Format(GetString1("windows_LevelXCompletedWindow"), Game.maps(i).MapName))
        Next
    End Sub
End Class
