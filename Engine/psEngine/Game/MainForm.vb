Imports PlatformStudio

Namespace GamePlayer
    Public MustInherit Class MainForm

        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.MenuItem1.Text = GetString("gameMenu")
            Me.MenuItem3.Text = GetString("gameNewGameMenu")
            Me.MenuItem13.Text = GetString("gamePauseMenu")
            Me.MenuItem15.Text = GetString("gameEndGameMenu")
            Me.MenuItem6.Text = GetString("gameHighScoresMenu")
            Me.MenuItem5.Text = GetString("gameQuitMenu")
            Me.MenuItem2.Text = GetString("helpMenu")
            Me.MenuItem7.Text = GetString("helpShowHelpMenu")
            Me.MenuItem10.Text = GetString("helpWebsiteMenu")
            Me.MenuItem11.Text = GetString("helpSupportMenu")
            Me.MenuItem9.Text = GetString("helpAboutMenu")
            Me.Text = GetString("gameTesterTitle")
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
        Public WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
        Public WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
        Public WithEvents p As System.Windows.Forms.PictureBox
        Public WithEvents picimage As System.Windows.Forms.PictureBox
        Public WithEvents MainMenu1 As System.Windows.Forms.MainMenu
        Public WithEvents MenuItem1 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem2 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem3 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem4 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem5 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem6 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem7 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem8 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem9 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem10 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem11 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem12 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem13 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem14 As System.Windows.Forms.MenuItem
        Public WithEvents MenuItem15 As System.Windows.Forms.MenuItem
        Public WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
            Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
            Me.dlgSave = New System.Windows.Forms.SaveFileDialog
            Me.p = New System.Windows.Forms.PictureBox
            Me.picimage = New System.Windows.Forms.PictureBox
            Me.MainMenu1 = New System.Windows.Forms.MainMenu
            Me.MenuItem1 = New System.Windows.Forms.MenuItem
            Me.MenuItem3 = New System.Windows.Forms.MenuItem
            Me.MenuItem13 = New System.Windows.Forms.MenuItem
            Me.MenuItem15 = New System.Windows.Forms.MenuItem
            Me.MenuItem14 = New System.Windows.Forms.MenuItem
            Me.MenuItem6 = New System.Windows.Forms.MenuItem
            Me.MenuItem4 = New System.Windows.Forms.MenuItem
            Me.MenuItem5 = New System.Windows.Forms.MenuItem
            Me.MenuItem2 = New System.Windows.Forms.MenuItem
            Me.MenuItem7 = New System.Windows.Forms.MenuItem
            Me.MenuItem8 = New System.Windows.Forms.MenuItem
            Me.MenuItem10 = New System.Windows.Forms.MenuItem
            Me.MenuItem11 = New System.Windows.Forms.MenuItem
            Me.MenuItem12 = New System.Windows.Forms.MenuItem
            Me.MenuItem9 = New System.Windows.Forms.MenuItem
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.SuspendLayout()
            '
            'p
            '
            Me.p.BackColor = System.Drawing.Color.Black
            Me.p.Dock = System.Windows.Forms.DockStyle.Fill
            Me.p.Location = New System.Drawing.Point(0, 0)
            Me.p.Name = "p"
            Me.p.Size = New System.Drawing.Size(370, 320)
            Me.p.TabIndex = 0
            Me.p.TabStop = False
            '
            'picimage
            '
            Me.picimage.Location = New System.Drawing.Point(16, 192)
            Me.picimage.Name = "picimage"
            Me.picimage.Size = New System.Drawing.Size(200, 80)
            Me.picimage.TabIndex = 1
            Me.picimage.TabStop = False
            Me.picimage.Visible = False
            '
            'MainMenu1
            '
            Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 0
            Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem13, Me.MenuItem15, Me.MenuItem14, Me.MenuItem6, Me.MenuItem4, Me.MenuItem5})

            Me.MenuItem1.Visible = False
            '
            'MenuItem3
            '
            Me.MenuItem3.Index = 0
            Me.MenuItem3.Shortcut = System.Windows.Forms.Shortcut.F2

            '
            'MenuItem13
            '
            Me.MenuItem13.Index = 1
            Me.MenuItem13.Shortcut = System.Windows.Forms.Shortcut.F3

            '
            'MenuItem15
            '
            Me.MenuItem15.Index = 2

            '
            'MenuItem14
            '
            Me.MenuItem14.Index = 3
            Me.MenuItem14.Text = "-"
            '
            'MenuItem6
            '
            Me.MenuItem6.Index = 4

            '
            'MenuItem4
            '
            Me.MenuItem4.Index = 5
            Me.MenuItem4.Text = "-"
            '
            'MenuItem5
            '
            Me.MenuItem5.Index = 6
            Me.MenuItem5.Shortcut = System.Windows.Forms.Shortcut.AltF4

            '
            'MenuItem2
            '
            Me.MenuItem2.Index = 1
            Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem8, Me.MenuItem10, Me.MenuItem11, Me.MenuItem12, Me.MenuItem9})

            Me.MenuItem2.Visible = False
            '
            'MenuItem7
            '
            Me.MenuItem7.Index = 0
            Me.MenuItem7.Shortcut = System.Windows.Forms.Shortcut.F1

            '
            'MenuItem8
            '
            Me.MenuItem8.Index = 1
            Me.MenuItem8.Text = "-"
            '
            'MenuItem10
            '
            Me.MenuItem10.Index = 2

            '
            'MenuItem11
            '
            Me.MenuItem11.Index = 3

            '
            'MenuItem12
            '
            Me.MenuItem12.Index = 4
            Me.MenuItem12.Text = "-"
            '
            'MenuItem9
            '
            Me.MenuItem9.Index = 5

            '
            'PictureBox1
            '
            Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(370, 320)
            Me.PictureBox1.TabIndex = 3
            Me.PictureBox1.TabStop = False
            Me.PictureBox1.Visible = False
            '
            'frmMain
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Black
            Me.ClientSize = New System.Drawing.Size(370, 320)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.picimage)
            Me.Controls.Add(Me.p)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Menu = Me.MainMenu1
            Me.MinimizeBox = False
            Me.Name = "frmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

            Me.ResumeLayout(False)

        End Sub

#End Region

        Public InRenderLoop As Boolean
        Public RequestedClose As Boolean

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            Loader.Load()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If Renderer.Rendered = False Then Exit Sub
            If Game.Drawing.StoreBackbuffer() = False Then Exit Sub
            Game.Drawing.Clear()
            Game.Drawing.DrawSprite("Backbuffer", 0, 0)
            Game.Drawing.RenderToScreen()
            'Renderer.Render()
        End Sub

        Private Sub frmTest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            If PlayingMovie AndAlso ClickToSkipMovie Then
                If Keys(e.KeyCode) Then Exit Sub
                SkipMovie = True
                Exit Sub
            ElseIf Paused Then
                Game.CurWinIndex = GameWindow
                Exit Sub
            End If
            If Paused Or Game.CurWinIndex <> GameWindow Or DrawingTransition Then Exit Sub
            If Keys(e.KeyCode) = False Then
                Keys(e.KeyCode) = True
                ActionProcessor.ProcessActions("kpre" & e.KeyCode)
            End If
        End Sub

        Private Sub frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
            If PlayingMovie Then
                Keys(e.KeyCode) = False
                Exit Sub
            End If
            If Paused Or Game.CurWinIndex <> GameWindow Or DrawingTransition Then Exit Sub
            If Keys(e.KeyCode) = True Then
                Keys(e.KeyCode) = False
                ActionProcessor.ProcessActions("krel" & e.KeyCode)
            End If
        End Sub

        Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
            If Not (StartedNewGame = False) Then
                Exit Sub
            Else
                Game.CurWinIndex = GameWindow
            End If
        End Sub

        Private Sub MenuItem1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem1.Popup, MenuItem2.Popup
            If HelpWindow = 0 And HelpFile = "" Then
                MenuItem7.Visible = False
                MenuItem8.Visible = False
            End If
            If AboutWindow = 0 Then
                MenuItem9.Visible = False
                MenuItem12.Visible = False
            End If
            MenuItem3.Enabled = (StartedNewGame = False)
            MenuItem7.Enabled = (StartedNewGame = False)
            MenuItem9.Enabled = (StartedNewGame = False)
            If PauseWindow = 0 Then MenuItem13.Visible = False
            MenuItem13.Enabled = (StartedNewGame And DrawingTransition = False)
            If Not Paused Then
                MenuItem13.Text = GetString("gamePauseMenu")
            Else
                MenuItem13.Text = GetString("gameResumeMenu")
            End If
            MenuItem15.Enabled = (Game.CurWinIndex = GameWindow)
            If hsWindow = 0 Then
                MenuItem6.Visible = False
                MenuItem4.Visible = False
            End If
            MenuItem6.Enabled = (StartedNewGame = False)
        End Sub

        Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
            If PauseWindow = 0 Then Exit Sub
            If Not (StartedNewGame And DrawingTransition = False) Then Exit Sub
            If Not Paused Then
                Game.PresetActions.PauseGame()
            Else
                Game.CurWinIndex = GameWindow
            End If
        End Sub

        Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
            If Not (Game.CurWinIndex = GameWindow) Then Exit Sub
            Game.PresetActions.QuitGame()
        End Sub

        Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
            If Not (StartedNewGame = False) Then Exit Sub
            If hsWindow = 0 Then Exit Sub
            Game.CurWinIndex = hsWindow
        End Sub

        Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
            Close()
        End Sub

        Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
            If Game.GameProperties.Website <> "" Then
                Process.Start(Game.GameProperties.Website)
            End If
        End Sub

        Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
            If Game.GameProperties.Support <> "" Then
                Process.Start("mailto:" & Game.GameProperties.Support)
            End If
        End Sub

        Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
            If AboutWindow = 0 Then Exit Sub
            Game.CurWinIndex = AboutWindow
        End Sub

        Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
            If HelpWindow = 0 And HelpFile = "" Then Exit Sub
            If Not (StartedNewGame = False) Then Exit Sub
            If HelpFile = "" Then
                Game.CurWinIndex = HelpWindow
            Else
                Process.Start(GetRelativeFile(HelpFile))
            End If
        End Sub

        Private Sub frmMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            If PlayingMovie AndAlso ClickToSkipMovie Then
                SkipMovie = True
            End If
        End Sub

        Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
            If PlayingMovie AndAlso ClickToSkipMovie Then
                SkipMovie = True
            End If
        End Sub

        MustOverride Sub DoClose()

        Overridable Sub RequestClose()
            DoClose()
        End Sub

        Private Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
            DoClose()
        End Sub

        Private Sub frmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            If Paused Or Game.CurWinIndex <> GameWindow Or DrawingTransition Then Exit Sub
            If e.Button = MouseButtons.Left Then
                ActionProcessor.ProcessActions("mlpr")
            ElseIf e.Button = MouseButtons.Right Then
                ActionProcessor.ProcessActions("mrpr")
            ElseIf e.Button = MouseButtons.Middle Then
                ActionProcessor.ProcessActions("mmpr")
            End If
            If e.Button = MouseButtons.Left Then
                MLButton = True
                ClickGroup = True
            ElseIf e.Button = MouseButtons.Right Then
                MRButton = True
            ElseIf e.Button = MouseButtons.Middle Then
                MMButton = True
            End If
        End Sub

        Private Sub frmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
            If Paused Or Game.CurWinIndex <> GameWindow Or DrawingTransition Then Exit Sub
            If e.Button = MouseButtons.Left Then
                ActionProcessor.ProcessActions("mlre")
            ElseIf e.Button = MouseButtons.Right Then
                ActionProcessor.ProcessActions("mrre")
            ElseIf e.Button = MouseButtons.Middle Then
                ActionProcessor.ProcessActions("mmre")
            End If
            If e.Button = MouseButtons.Left Then
                MLButton = False
            ElseIf e.Button = MouseButtons.Right Then
                MRButton = False
            ElseIf e.Button = MouseButtons.Middle Then
                MMButton = False
            End If
        End Sub

        Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
            If Paused Or Game.CurWinIndex <> GameWindow Or DrawingTransition Then Exit Sub
            ActionProcessor.ProcessActions("mmov")
        End Sub

        Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            Renderer.PauseRendering = False
        End Sub

        Private Sub frmMain_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate, MyBase.Leave, MyBase.LostFocus
            If Not Game.GameProperties.Windowed Then
                Renderer.PauseRendering = True
            End If
            If PauseWindow > 0 AndAlso Game.CurWinIndex = GameWindow Then
                Game.PresetActions.PauseGame()
            End If
            For i As Integer = 0 To 255
                Keys(i) = False
            Next
        End Sub
    End Class
End Namespace