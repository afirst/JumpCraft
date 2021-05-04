Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Public Class psfrmResize
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("resizeLevelDialog_WidthLabel")
        Me.Label2.Text = GetString("resizeLevelDialog_HeightLabel")
        Me.Button1.Text = GetString("okButton")
        Me.Button2.Text = GetString("cancelButton")
        Me.Button3.Text = GetString("resizeLevelDialog_RevertButton")
        Me.GroupBox1.Text = GetString("resizeLevelDialog_ResizeFrame")
        Me.GroupBox2.Text = GetString("resizeLevelDialog_TranslateFrame")
        Me.Label5.Text = GetString("resizeLevelDialog_ActionWarningLabel")
        Me.Label3.Text = GetString("resizeLevelDialog_VerticallyLabel")
        Me.Label4.Text = GetString("resizeLevelDialog_HorizontallyLabel")
        Me.Text = GetString("resizeLevelDialog_Title")
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.NumericUpDown1 = New System.Windows.Forms.TextBox
        Me.NumericUpDown2 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0

        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2

        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(168, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 4

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(88, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 3

        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(8, 200)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 2

        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(80, 24)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(40, 20)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.Text = "8"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(80, 56)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(40, 20)
        Me.NumericUpDown2.TabIndex = 1
        Me.NumericUpDown2.Text = "8"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(8, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 88)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False

        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(128, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 64)
        Me.Label5.TabIndex = 9

        Me.Label5.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2

        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 0

        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(80, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(40, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "0"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(80, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(40, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "0"
        '
        'psfrmResize
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(250, 232)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmResize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        NumericUpDown1.Text = Game.CurMapWidth
        NumericUpDown2.Text = Game.CurMapHeight
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Text = Game.CurMapWidth
        NumericUpDown2.Text = Game.CurMapHeight
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If NumericUpDown1.Text * NumericUpDown2.Text > 250000 Then
            MessageBox.Show(GetString("resizeLevelDialog_LevelTooBigErrorMessage"), GetString("resizeLevelDialog_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.None
            Return
        End If

        UndoRedo.UpdateUndo(GetString("undoActionResizeLevel"), UndoRedo.UndoType.Level, Game.CurMapIndex)
        Dim x As Integer = CInt(TextBox1.Text)
        Dim y As Integer = CInt(TextBox2.Text)
        If x <> 0 Or y <> 0 Then
            Dim minX, maxX, stepX, minY, maxY, stepY As Integer
            If x <= 0 Then
                minX = 1 : maxX = Game.CurMapWidth : stepX = 1
            Else
                minX = Game.CurMapWidth : maxX = 1 : stepX = -1
            End If
            If y <= 0 Then
                minY = 1 : maxY = Game.CurMapHeight : stepY = 1
            Else
                minY = Game.CurMapHeight : maxY = 1 : stepY = -1
            End If

            'Update level
            For n As Integer = 0 To 3
                For i As Integer = minX To maxX Step stepX
                    For j As Integer = minY To maxY Step stepY
                        If Game.CurMap.Cells(i, j, n) > 0 Then

                            'Update tile
                            Dim toX As Integer = i + x
                            Dim toY As Integer = j + y
                            If toX >= 1 AndAlso toY >= 1 AndAlso toX <= Game.CurMapWidth AndAlso toY <= Game.CurMapHeight Then
                                Game.maps(Game.CurMapIndex).Cells2(toX, toY, n) = Game.maps(Game.CurMapIndex).Cells2(i, j, n)

                                'Update path
                                If Game.maps(Game.CurMapIndex).Cells2(toX, toY, n).Path.Exists Then
                                    Dim c As psMapTile = Game.maps(Game.CurMapIndex).Cells2(toX, toY, n)
                                    For p As Integer = 0 To c.Path.Pts.Length - 1
                                        For q As Integer = 0 To 3
                                            c.Path.Pts(p).XPoint(q) += x * Game.tileW
                                            c.Path.Pts(p).YPoint(q) += y * Game.tileH
                                        Next
                                    Next
                                    Game.maps(Game.CurMapIndex).Cells2(toX, toY, n) = c
                                End If

                            End If
                            Game.maps(Game.CurMapIndex).Cells2(i, j, n) = New psMapTile

                        End If
                    Next
                Next
            Next

            'Update locations
            For i As Integer = 1 To UBound(Game.CurMap.loc.Locations)
                With Game.CurMap.loc.Locations(i)
                    .X += x * Game.tileW
                    .Y += y * Game.tileH
                    If .X + .Width <= 0 Then
                        .X = 0
                        .Width = Game.tileW
                    End If
                    If .Y + .Height <= 0 Then
                        .Y = 0
                        .Height = Game.tileH
                    End If
                    If .X >= Game.CurMapWidth * Game.tileW Then
                        .X = Game.CurMapWidth * Game.tileW - Game.tileW
                        .Width = Game.tileW
                    End If
                    If .Y >= Game.CurMapHeight * Game.tileH Then
                        .Y = Game.CurMapHeight * Game.tileH - Game.tileH
                        .Height = Game.tileH
                    End If
                End With
            Next

        End If
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        Game.maps(Game.CurMapIndex).ResizeMap(NumericUpDown1.Text, NumericUpDown2.Text)
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.DoResize()
    End Sub

    Private Sub NumericUpDown1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NumericUpDown1.Validating
        ConvertToNumber(NumericUpDown1, 1, 1024, Game.CurMapWidth)
    End Sub

    Private Sub NumericUpDown2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NumericUpDown2.Validating
        ConvertToNumber(NumericUpDown2, 1, 1024, Game.CurMapHeight)
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ConvertToNumber(TextBox1, -100000, 100000, 0)
        Label5.Visible = (TextBox1.Text <> 0 Or TextBox2.Text <> 0)
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, -100000, 100000, 0)
        Label5.Visible = (TextBox1.Text <> 0 Or TextBox2.Text <> 0)
    End Sub
End Class
