Imports PlatformStudio

Public Class psfrmCounters
    Inherits System.Windows.Forms.Form

    Dim ChangingText As Boolean
    Dim tmp As psActions

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.GroupBox1.Text = GetString("propertiesPanelTitle")
        Me.Label2.Text = GetString("counters_StartAtLabel")
        Me.Label1.Text = GetString("timers_TimerNameLabel")
        Me.GroupBox2.Text = GetString("timers_CountersFrame")
        Me.Button2.Text = GetString("gameProperties_RemoveFileButton")
        Me.Button1.Text = GetString("gameProperties_AddFileButton")
        Me.Button5.Text = GetString("okButton")
        Me.Button6.Text = GetString("cancelButton")
        Me.Text = GetString("counters_Title")
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1})
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False

        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(56, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(88, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "0"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2

        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(56, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1, Me.ListBox1})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 176)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False

        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(80, 144)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 24)
        Me.Button2.TabIndex = 2

        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(8, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 24)
        Me.Button1.TabIndex = 1

        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(8, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(136, 121)
        Me.ListBox1.TabIndex = 0
        '
        'Button5
        '
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button5.Location = New System.Drawing.Point(88, 272)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 3

        '
        'Button6
        '
        Me.Button6.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button6.Location = New System.Drawing.Point(8, 272)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 2

        '
        'psfrmCounters
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(170, 304)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.Button6, Me.GroupBox2, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmCounters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReDim Preserve tmp.Counters(UBound(tmp.Counters) + 1)
        tmp.Counters(UBound(tmp.Counters)).Name = "Counter " & ListBox1.Items.Count + 1
        tmp.Counters(UBound(tmp.Counters)).Value = 0
        ListBox1.Items.Add(tmp.Counters(UBound(tmp.Counters)).Name)
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex < 0 Then Exit Sub
        Dim i As Integer, j As Integer

        'Make sure we can delete
        If Options.gWarnWhenDelActions Then
            For i = 1 To UBound(tmp.Actions)
                If tmp.Actions(i).Trigger.Chars(0) = "c" AndAlso tmp.Actions(i).Trigger.Substring(4) = ListBox1.SelectedIndex + 1 Then
                    If MessageBox.Show(GetString("deleteActionConfirmationMessage"), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next
        End If

        'Update actions
        For i = 1 To UBound(tmp.Actions)
            If i > UBound(tmp.Actions) Then Exit For
            With tmp.Actions(i)
                If .Trigger.Chars(0) = "c" AndAlso .Trigger.Substring(4) = ListBox1.SelectedIndex + 1 Then
                    For j = i To UBound(tmp.Actions) - 1
                        tmp.Actions(j) = tmp.Actions(j + 1)
                    Next
                    ReDim Preserve tmp.Actions(UBound(tmp.Actions) - 1)
                    i -= 1
                ElseIf .Trigger.Chars(0) = "c" AndAlso .Trigger.Substring(4) > ListBox1.SelectedIndex + 1 Then
                    .Trigger = .Trigger.Substring(0, 4) & (CInt(.Trigger.Substring(4)) - 1)
                End If
            End With
        Next

        'Delete data
        For i = ListBox1.SelectedIndex + 1 To UBound(tmp.Counters) - 1
            tmp.Counters(i) = tmp.Counters(i + 1)
        Next
        ReDim Preserve tmp.Counters(UBound(tmp.Counters) - 1)

        'Update list
        Dim tmpI As Integer = ListBox1.SelectedIndex
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        If ListBox1.Items.Count = 0 Then Exit Sub
        If tmpI > ListBox1.Items.Count - 1 Then
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1
        Else
            ListBox1.SelectedIndex = tmpI
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If tmp.Counters Is Nothing Then Exit Sub
        ChangingText = True
        ListBox1.Items(ListBox1.SelectedIndex) = TextBox1.Text
        tmp.Counters(ListBox1.SelectedIndex + 1).Name = TextBox1.Text
        ChangingText = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ChangingText Then Exit Sub
        GroupBox1.Enabled = (ListBox1.SelectedIndex > -1)
        Button2.Enabled = (ListBox1.SelectedIndex > 2)
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        TextBox1.Enabled = (ListBox1.SelectedIndex > 2)
        Label1.Enabled = (ListBox1.SelectedIndex > 2)
        TextBox1.Text = ListBox1.SelectedItem
        TextBox2.Text = tmp.Counters(ListBox1.SelectedIndex + 1).Value
    End Sub

    Private Sub psfrmCounters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tmp = Game.actions.Clone
        Dim i As Integer
        For i = 1 To UBound(Game.actions.Counters)
            ListBox1.Items.Add(tmp.Counters(i).Name)
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Game.actions = tmp.Clone
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, -1000000000, 1000000000, tmp.Counters(ListBox1.SelectedIndex + 1).Value, 3)
        tmp.Counters(ListBox1.SelectedIndex + 1).Value = TextBox2.Text
    End Sub
End Class
