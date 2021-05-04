Imports PlatformStudio

Public Class psfrmWindowTransition
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.GroupBox1.Text = GetString("windowTransition_TransitionInFrame")
        Me.Label3.Text = GetString("windowTransition_TransitionLabel")
        Me.Label2.Text = GetString("secondsUnit")
        Me.Label1.Text = GetString("windowTransition_DurationLabel")
        Me.GroupBox2.Text = GetString("windowTransition_AutomaticAdvanceFrame")
        Me.Label6.Text = GetString("secondsUnit")
        Me.Label5.Text = GetString("windowTransition_AdvanceAfterLabel")
        Me.Label4.Text = GetString("windowTransition_WindowLabel")
        Me.GroupBox3.Text = GetString("windowTransition_TransitionOutFrame")
        Me.Label7.Text = GetString("windowTransition_TransitionLabel")
        Me.Label8.Text = GetString("secondsUnit")
        Me.Label9.Text = GetString("windowTransition_DurationLabel")
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.Text = GetString("windowTransition_Title")
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False

        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"(None)", "Fade", "Fade Through Black", "Flip Horizontally", "Flip Vertically", "Rotate CCW", "Rotate CW", "Zoom In", "Zoom Out", "Fly Left", "Fly Right", "Fly Up", "Fly Down", "Divide Horizontally", "Divide Vertically", "Divide Both", "Random"})
        Me.ComboBox1.Location = New System.Drawing.Point(64, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 3

        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label2.Location = New System.Drawing.Point(96, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 2

        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(64, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(32, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "1"
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(8, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 72)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False

        '
        'Label6
        '
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label6.Location = New System.Drawing.Point(120, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 8

        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(88, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(32, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "3"
        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 6

        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Items.AddRange(New Object() {"(None)"})
        Me.ComboBox2.Location = New System.Drawing.Point(64, 16)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(128, 21)
        Me.ComboBox2.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 1

        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox3)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox3.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 72)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False

        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Location = New System.Drawing.Point(64, 16)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(128, 21)
        Me.ComboBox3.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 3

        '
        'Label8
        '
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label8.Location = New System.Drawing.Point(96, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 2

        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(64, 40)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(32, 20)
        Me.TextBox3.TabIndex = 1
        Me.TextBox3.Text = "1"
        '
        'Label9
        '
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label9.Location = New System.Drawing.Point(8, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 0

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(208, 248)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 5

        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(128, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 4

        '
        'psfrmWindowTransition
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(290, 280)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmWindowTransition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim inPropGrid As Boolean
    Dim t As Transition

    Overloads Sub ShowDialog(ByVal transition As Transition)
        t = transition
        inPropGrid = True
        MyBase.ShowDialog()
    End Sub

    Private Sub psfrmWindowTransition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To Game.numWindows
            ComboBox2.Items.Add(Game.windows.Windows(i).Name)
        Next
        For i As Integer = 0 To ComboBox1.Items.Count - 1
            ComboBox3.Items.Add(ComboBox1.Items(i))
        Next
        With Game.CurWindow
            If inPropGrid Then
                ComboBox1.SelectedIndex = t.In
                TextBox1.Text = t.InLen
                ComboBox2.SelectedIndex = t.To
                TextBox2.Text = t.TransitionAfter
                ComboBox3.SelectedIndex = t.Out
                TextBox3.Text = t.OutLen
            Else
                ComboBox1.SelectedIndex = .TransitionIn
                TextBox1.Text = .TransitionInLength
                ComboBox2.SelectedIndex = .TransitionTo
                TextBox2.Text = .TransitionAfter
                ComboBox3.SelectedIndex = .TransitionOut
                TextBox3.Text = .TransitionOutLength
            End If
        End With
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ConvertToNumber(TextBox1, 0.1, 10, 1, 2)
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, 0.1, 1000, 1, 2)
    End Sub

    Private Sub TextBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        ConvertToNumber(TextBox3, 0.1, 10, 1, 2)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label1.Enabled = (ComboBox1.SelectedIndex > 0)
        TextBox1.Enabled = (ComboBox1.SelectedIndex > 0)
        Label2.Enabled = (ComboBox1.SelectedIndex > 0)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label5.Enabled = (ComboBox2.SelectedIndex > 0)
        TextBox2.Enabled = (ComboBox2.SelectedIndex > 0)
        Label6.Enabled = (ComboBox2.SelectedIndex > 0)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Label9.Enabled = (ComboBox3.SelectedIndex > 0)
        TextBox3.Enabled = (ComboBox3.SelectedIndex > 0)
        Label8.Enabled = (ComboBox3.SelectedIndex > 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If inPropGrid Then
            t.In = ComboBox1.SelectedIndex
            t.InLen = TextBox1.Text
            t.To = ComboBox2.SelectedIndex
            t.TransitionAfter = TextBox2.Text
            t.Out = ComboBox3.SelectedIndex
            t.OutLen = TextBox3.Text
        Else
            UndoRedo.UpdateUndo(GetString("undoActionEditWindowTransition"), UndoRedo.UndoType.Windows)
            With Game.CurWindow
                .TransitionIn = ComboBox1.SelectedIndex
                .TransitionInLength = TextBox1.Text
                .TransitionTo = ComboBox2.SelectedIndex
                .TransitionAfter = TextBox2.Text
                .TransitionOut = ComboBox3.SelectedIndex
                .TransitionOutLength = TextBox3.Text
            End With
        End If
    End Sub
End Class

Public Class Transition
    Public [In] As psUI.psWindows.psWindow.TransitionType
    Public InLen As Single
    Public [To] As Integer
    Public TransitionAfter As Single
    Public Out As psUI.psWindows.psWindow.TransitionType
    Public OutLen As Single

    Sub New(ByVal _in As psUI.psWindows.psWindow.TransitionType, ByVal _inlen As Single, ByVal _to As Integer, ByVal _transafter As Single, ByVal _out As psUI.psWindows.psWindow.TransitionType, ByVal _outlen As Single)
        [In] = _in
        InLen = _inlen
        [To] = _to
        TransitionAfter = _transafter
        Out = _out
        OutLen = _outlen
    End Sub

    Overrides Function ToString() As String
        Return [In].ToString & ", " & Out.ToString
    End Function

    Function Clone() As Transition
        Return New Transition([In], InLen, [To], TransitionAfter, Out, OutLen)
    End Function
End Class