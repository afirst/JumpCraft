Imports PlatformStudio
Imports PlatformStudio.GamePlayer

Public Class frmMain
    Inherits GamePlayer.MainForm

#Region " Windows Form Designer generated code "

    Private WithEvents mnuPerf As New MenuItem(GetString("gameTester_PoorPerformanceMenu"))

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = GetString("gameTester_Title")
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque, True)

        mnuPerf.Visible = False
        Me.MainMenu1.MenuItems.Add(mnuPerf)
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.SuspendLayout()
        Me.ResumeLayout(False)
    End Sub

#End Region

    Dim WithEvents tmr As New Timer

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        'If Not Game.GameProperties.Windowed Then Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        MyBase.OnLoad(e)
        If RequestedClose Then
            DoClose()
            Return
        End If
        swatch2.Start()
        RenderingWindow = True
        tmr.Interval = 150
        tmr.Enabled = True
    End Sub

    Dim isClosing As Boolean

    Overrides Sub DoClose()
        tmr.Enabled = False
        If tmp Or isClosing Then Return
        isClosing = True

        fGame.Select()

        Try
            GamePlayer.Game.Drawing.device.SetDialogBoxesEnabled(False)
        Catch
        End Try
        Dispose()

        Client.End()
    End Sub

    Overrides Sub RequestClose()
        RequestedClose = True
        tmr.Enabled = False
    End Sub

    Dim swatch As New Stopwatch("Frame")
    Dim tmp As Boolean
    Dim frameTimes As New ArrayList
    Dim perfVisTime As Single
    Const logFrames As Integer = 20

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If RequestedClose Then Return

        If Not Focused Then
            MyBase.OnPaint(e)
            Return
        End If

        If tmp Then Return
        tmp = True

        doNotMeasureFrame = False

        swatch.Start("Frame")
        If Not PauseRendering Then
            If f.Visible Then
                If Game.Drawing.device.CheckCooperativeLevel = False Then
                    Game.Drawing.Re_Init(Game.p)
                Else
                    Try
                        Render()
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
        Rendered = True

        If (swatch.ElapsedTime() < 1.0 / 60.0) Then
            Threading.Thread.Sleep(CInt(Math.Max(0, 1000.0 / 60.0 - 1000 * swatch.ElapsedTime())))
        End If
        elapsed = swatch.Done()

        Invalidate()

        tmp = False

        'Debugging
        If frameTimes.Count >= logFrames Then
            frameTimes.RemoveAt(0)
        End If
        If Not doNotMeasureFrame Then frameTimes.Add(elapsed)
        Dim totalTime As Double
        For i As Integer = 0 To frameTimes.Count - 1
            totalTime += frameTimes(i)
        Next
        If MenuItem1.Visible AndAlso Game.CurWinIndex = GameWindow AndAlso (frameTimes.Count = logFrames AndAlso totalTime / frameTimes.Count >= 0.04) Then
            perfVisTime = Timer
            'If Not mnuPerf.Visible Then mnuPerf.Visible = True
        ElseIf mnuPerf.Visible AndAlso Timer - perfVisTime >= 3 Then
            'mnuPerf.Visible = False
        End If
    End Sub

    Dim doNotMeasureFrame As Boolean
    Sub ClearFrameTimes()
        doNotMeasureFrame = True
        frameTimes.Clear()
    End Sub

    Private Sub mnuPerf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPerf.Click
        Help.ShowHelp(Me, HelpCHM, HelpNavigator.Topic, "files\gameperf.htm")
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        Invalidate()
    End Sub
End Class