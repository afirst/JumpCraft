Imports PlatformStudio

Public Class psfrmNewLevelDialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.TextBox1.Text = String.Format(GetString1("defaultLevelName"), 1)
        Me.Label1.Text = GetString("newLevel_LevelNameLabel")
        Me.Label2.Text = GetString("resizeLevelDialog_HeightLabel")
        Me.Label3.Text = GetString("resizeLevelDialog_WidthLabel")
        Me.Button2.Text = GetString("cancelButton")
        Me.Button1.Text = GetString("okButton")
        Me.Text = GetString("newLevelIconTooltip")
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
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TextBox1.Location = New System.Drawing.Point(80, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 20)
        Me.TextBox1.TabIndex = 1
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(80, 72)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown2.TabIndex = 5
        Me.NumericUpDown2.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(80, 40)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {64, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 4

        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 2

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(56, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 6

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(136, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 7

        '
        'psfrmNewLevelDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(218, 136)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1, Me.NumericUpDown2, Me.NumericUpDown1, Me.Label2, Me.Label3, Me.TextBox1, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmNewLevelDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub NumericUpDown1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NumericUpDown1.Validating
        If IsNumeric(NumericUpDown1.Text) = False Then
            NumericUpDown1.Text = Game.CurMapWidth
        ElseIf NumericUpDown1.Text < NumericUpDown1.Minimum Then
            NumericUpDown1.Text = NumericUpDown1.Minimum
        ElseIf NumericUpDown1.Text > NumericUpDown1.Maximum Then
            NumericUpDown1.Text = NumericUpDown1.Maximum
        ElseIf NumericUpDown1.Text <> Int(NumericUpDown1.Text) Then
            NumericUpDown1.Text = Int(NumericUpDown1.Text)
        End If
    End Sub

    Private Sub NumericUpDown2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NumericUpDown2.Validating
        If IsNumeric(NumericUpDown2.Text) = False Then
            NumericUpDown2.Text = Game.CurMapHeight
        ElseIf NumericUpDown2.Text < NumericUpDown2.Minimum Then
            NumericUpDown2.Text = NumericUpDown2.Minimum
        ElseIf NumericUpDown2.Text > NumericUpDown2.Maximum Then
            NumericUpDown2.Text = NumericUpDown2.Maximum
        ElseIf NumericUpDown2.Text <> Int(NumericUpDown2.Text) Then
            NumericUpDown2.Text = Int(NumericUpDown2.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Editor.psedit.Deselect()
        UndoRedo.UpdateUndo(GetString("newLevelIconTooltip"), UndoRedo.UndoType.AllLevels)
        Dim tmpLayer As Integer
        tmpLayer = psMap.CurLayer
        Game.AddMap(TextBox1.Text, NumericUpDown1.Text, NumericUpDown2.Text)
        Game.maps(Game.maps.GetUpperBound(0)).Background = Game.maps(Game.maps.GetUpperBound(0) - 1).Background
        Game.CurMapIndex = Game.numMaps
        psMap.CurLayer = tmpLayer
        Editor.LevelSel_Refresh()
        Editor.LevelSel_SelectLast()
        Editor.psedit.DoResize()
    End Sub
End Class