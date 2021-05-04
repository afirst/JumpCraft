Public Class frmBackgroundMusic
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.Button5 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
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
        Me.TextBox1.Location = New System.Drawing.Point(64, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(184, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(248, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 20)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(272, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "x"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(64, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(40, 20)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "100"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "%"
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button3.Location = New System.Drawing.Point(224, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.Location = New System.Drawing.Point(144, 72)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 24)
        Me.Button4.TabIndex = 7
        '
        'dlgOpen
        '
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(64, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 9
        '
        'Timer1
        '
        '
        'frmBackgroundMusic
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(306, 104)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackgroundMusic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim Window As Boolean
    Dim Custom As Boolean
    Dim m As Music

    Sub ShowWindowDialog()
        Window = True
        ShowDialog()
    End Sub

    Overloads Sub ShowDialog(ByVal music As Music)
        Custom = True
        m = music
        ShowDialog()
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, 0, 100, 100)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dlgOpen.FileName = TextBox1.Text
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        If TextBox1.Text = "" And TextBox2.Text = 0 Then TextBox2.Text = 100
        TextBox1.Text = dlgOpen.FileName
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Button5.Text = GetString("backgroundMusic_PreviewButton") Then
            Button5.Text = GetString("backgroundMusic_StopButton")
            Game.Audio.PlayMusicNow(TextBox1.Text, TextBox2.Text)
            Timer1.Enabled = True
        Else
            Button5.Text = GetString("backgroundMusic_PreviewButton")
            Game.Audio.StopMusic()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub frmBackgroundMusic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = GetString("backgroundMusic_MusicFileLabel")
        Me.Label2.Text = GetString("backgroundMusic_VolumeLabel")
        Me.Button3.Text = GetString("okButton")
        Me.Button4.Text = GetString("cancelButton")
        Me.dlgOpen.Filter = GetString("musicFileFilter")
        Me.dlgOpen.Title = GetString("selectAFileDialogTitle")
        Me.Button5.Text = GetString("backgroundMusic_PreviewButton")
        Me.Text = GetString("backgroundMusic_Title")
        If Custom Then
            TextBox1.Text = m.File
            TextBox2.Text = m.Volume
        ElseIf Window Then
            TextBox1.Text = Game.CurWindow.Music
            TextBox2.Text = Game.CurWindow.Volume
        Else
            TextBox1.Text = Game.maps(Game.CurMapIndex).Music
            TextBox2.Text = Game.maps(Game.CurMapIndex).Volume
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Timer1.Enabled = False
        If Custom Then
            m.File = TextBox1.Text
            m.Volume = TextBox2.Text
        ElseIf Window Then
            UndoRedo.UpdateUndo(GetString("undoActionSetBackgroundMusic"), UndoRedo.UndoType.Windows)
            Game.CurWindow.Music = TextBox1.Text
            Game.CurWindow.Volume = TextBox2.Text
        Else
            UndoRedo.UpdateUndo(GetString("undoActionSetBackgroundMusic"), UndoRedo.UndoType.Level, Game.CurMapIndex)
            Game.maps(Game.CurMapIndex).Music = TextBox1.Text
            Game.maps(Game.CurMapIndex).Volume = TextBox2.Text
        End If
    End Sub

    Private Sub frmBackgroundMusic_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Game.Audio.StopMusic()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Game.Audio.UpdateMusic()
    End Sub
End Class

Public Class Music
    Public File As String
    Public Volume As Integer

    Sub New(ByVal aFile As String, ByVal aVolume As Integer)
        File = aFile
        Volume = aVolume
    End Sub

    Overrides Function ToString() As String
        If File = "" Then
            Return GetString1("noValue")
        Else
            Return IO.Path.GetFileName(File)
        End If
    End Function

    Function Clone() As Music
        Return New Music(File, Volume)
    End Function
End Class