Public Class psfrmMediaFiles
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lstSounds As System.Windows.Forms.ListBox
    Friend WithEvents lstMusic As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lstSounds = New System.Windows.Forms.ListBox
        Me.lstMusic = New System.Windows.Forms.ListBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(280, 248)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstSounds)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(272, 222)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sounds"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstMusic)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(272, 222)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Music"
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(272, 222)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Images"
        '
        'lstSounds
        '
        Me.lstSounds.HorizontalScrollbar = True
        Me.lstSounds.Location = New System.Drawing.Point(8, 8)
        Me.lstSounds.Name = "lstSounds"
        Me.lstSounds.Size = New System.Drawing.Size(256, 173)
        Me.lstSounds.TabIndex = 0
        '
        'lstMusic
        '
        Me.lstMusic.HorizontalScrollbar = True
        Me.lstMusic.Location = New System.Drawing.Point(8, 8)
        Me.lstMusic.Name = "lstMusic"
        Me.lstMusic.Size = New System.Drawing.Size(256, 173)
        Me.lstMusic.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Location = New System.Drawing.Point(20, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 208)
        Me.Panel1.TabIndex = 1
        '
        'ListBox1
        '
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(256, 168)
        Me.ListBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Add"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(134, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Remove"
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(216, 264)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "&OK"
        '
        'Button6
        '
        Me.Button6.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button6.Location = New System.Drawing.Point(136, 264)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "&Cancel"
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "Sound Files|*.wav"
        Me.dlgOpen.Title = "Select a File"
        '
        'psfrmMediaFiles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(298, 296)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmMediaFiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Media Files"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                dlgOpen.Filter = "Sound Files (*.wav)|*.wav"
            Case 1
                dlgOpen.Filter = "Music (*.mid, *.mp3)|*.mid;*.mp3"
            Case 2
                dlgOpen.Filter = "All Images (*.bmp, *.gif, *.jpg, *.png)|*.bmp;*.jpg;*.gif;*.png|Bitmaps (*.bmp)|*.bmp|GIF's (*.gif)|*.gif|JPEG's (*.jpg)|*.jpg|PNG's (*.png)|*.png"
        End Select
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        For i As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i) = dlgOpen.FileName Then
                ListBox1.SelectedIndex = i
                Exit Sub
            End If
        Next
        ListBox1.Items.Add(dlgOpen.FileName)
        With Game.MediaFiles
            Select Case TabControl1.SelectedIndex
                Case 0
                    ReDim Preserve .Sounds(UBound(.Sounds) + 1)
                    .Sounds(UBound(.Sounds)) = dlgOpen.FileName
                Case 1
                    ReDim Preserve .Music(UBound(.Music) + 1)
                    .Music(UBound(.Music)) = dlgOpen.FileName
                Case 2
                    ReDim Preserve .Images(UBound(.Images) + 1)
                    .Images(UBound(.Images)) = dlgOpen.FileName
            End Select
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        Dim tmpArray() As String
        With Game.MediaFiles
            Select Case TabControl1.SelectedIndex
                Case 0 : tmpArray = .Sounds
                Case 1 : tmpArray = .Music
                Case 2 : tmpArray = .Images
            End Select
        End With
        For i As Integer = ListBox1.SelectedIndex + 1 To UBound(tmpArray) - 1
            tmpArray(i) = tmpArray(i + 1)
        Next
        ReDim Preserve tmpArray(UBound(tmpArray) - 1)
        With Game.MediaFiles
            Select Case TabControl1.SelectedIndex
                Case 0 : .Sounds = tmpArray
                Case 1 : .Music = tmpArray
                Case 2 : .Images = tmpArray
            End Select
        End With
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        RefreshList()
    End Sub

    Sub RefreshList()
        Dim tmpArray() As String
        With Game.MediaFiles
            Select Case TabControl1.SelectedIndex
                Case 0 : tmpArray = .Sounds
                Case 1 : tmpArray = .Music
                Case 2 : tmpArray = .Images
            End Select
        End With
        ListBox1.Items.Clear()
        For i As Integer = 1 To UBound(tmpArray)
            ListBox1.Items.Add(tmpArray(i))
        Next
    End Sub

    Private Sub psfrmMediaFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub
End Class
