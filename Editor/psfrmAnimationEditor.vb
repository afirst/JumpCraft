Imports PlatformStudio

Public Class psfrmAnimationEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("animEd_AnimationsLabel")
        Me.GroupBox1.Text = GetString("animEd_PropertiesFrame")
        Me.Label5.Text = GetString("animEd_IntervalLabel")
        Me.Label8.Text = GetString("animEd_EffectLabel")
        Me.Label7.Text = GetString("animEd_StopFrameLabel")
        Me.Label2.Text = GetString("animEd_StartFrameLabel")
        Me.Label6.Text = GetString("secondsUnit")
        Me.Label4.Text = GetString("secondsUnit")
        Me.Label3.Text = GetString("animEd_FrameIntervalLabel")
        Me.btnCancel.Text = GetString("cancelButton")
        Me.btnOK.Text = GetString("okButton")
        Me.GroupBox2.Text = GetString("animEd_PreviewFrame")
        Me.Text = GetString("animEd_Title")
        Me.ComboBox1.Items.AddRange(New Object() {GetString("noValueCapital"), GetString("anim_Fade"), GetString("anim_Flatten"), GetString("anim_Fall"), GetString("anim_Blink1"), GetString("anim_Blink2"), GetString("anim_Blink3")})
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
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents cboAnim As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAnimInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboStartFrame As System.Windows.Forms.ComboBox
    Friend WithEvents cboStopFrame As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tmrRender As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmAnimationEditor))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboAnim = New System.Windows.Forms.ComboBox
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboStopFrame = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboStartFrame = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAnimInterval = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.picPreview = New System.Windows.Forms.PictureBox
        Me.tmrRender = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 19)
        Me.Label1.TabIndex = 0

        '
        'cboAnim
        '
        Me.cboAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnim.Location = New System.Drawing.Point(86, 9)
        Me.cboAnim.Name = "cboAnim"
        Me.cboAnim.Size = New System.Drawing.Size(296, 24)
        Me.cboAnim.TabIndex = 1
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(16, 16)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboStopFrame)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboStartFrame)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtAnimInterval)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtInterval)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(10, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 176)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False

        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label5.Location = New System.Drawing.Point(10, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 19)
        Me.Label5.TabIndex = 7

        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Location = New System.Drawing.Point(125, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(105, 24)
        Me.ComboBox1.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 18)
        Me.Label8.TabIndex = 10

        '
        'cboStopFrame
        '
        Me.cboStopFrame.Location = New System.Drawing.Point(125, 83)
        Me.cboStopFrame.Name = "cboStopFrame"
        Me.cboStopFrame.Size = New System.Drawing.Size(57, 24)
        Me.cboStopFrame.TabIndex = 3
        Me.cboStopFrame.Text = "1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 19)
        Me.Label7.TabIndex = 2

        '
        'cboStartFrame
        '
        Me.cboStartFrame.Location = New System.Drawing.Point(125, 55)
        Me.cboStartFrame.Name = "cboStartFrame"
        Me.cboStartFrame.Size = New System.Drawing.Size(57, 24)
        Me.cboStartFrame.TabIndex = 1
        Me.cboStartFrame.Text = "1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 19)
        Me.Label2.TabIndex = 0

        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(202, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(9, 19)
        Me.Label6.TabIndex = 9

        '
        'txtAnimInterval
        '
        Me.txtAnimInterval.Location = New System.Drawing.Point(125, 138)
        Me.txtAnimInterval.Name = "txtAnimInterval"
        Me.txtAnimInterval.Size = New System.Drawing.Size(77, 22)
        Me.txtAnimInterval.TabIndex = 8
        Me.txtAnimInterval.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(202, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(9, 18)
        Me.Label4.TabIndex = 6

        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(125, 111)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(77, 22)
        Me.txtInterval.TabIndex = 5
        Me.txtInterval.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 18)
        Me.Label3.TabIndex = 4

        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnCancel.Location = New System.Drawing.Point(250, 231)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 27)
        Me.btnCancel.TabIndex = 5

        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnOK.Location = New System.Drawing.Point(346, 231)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 27)
        Me.btnOK.TabIndex = 6

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picPreview)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(259, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 176)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False

        '
        'picPreview
        '
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPreview.Location = New System.Drawing.Point(10, 18)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(153, 148)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPreview.TabIndex = 9
        Me.picPreview.TabStop = False
        '
        'tmrRender
        '
        Me.tmrRender.Enabled = True
        Me.tmrRender.Interval = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(382, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "+"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(407, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 24)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "-"
        '
        'psfrmAnimationEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(444, 267)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboAnim)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmAnimationEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim curTile As psTile
    Dim bmp As Bitmap

    Public Shared Function getAnimationNames(ByVal tile As psTile) As ArrayList
        Dim res As New ArrayList
        With res
            Select Case tile.behavior
                Case psTile.TileBehavior.Background
                    .Add("0 " & GetString("anim_Normal"))
                    .Add("1 " & GetString("anim_Disappear"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                    '.Add("Custom 3")
                    '.Add("Custom 4")
                Case psTile.TileBehavior.Character
                    .Add("0 " & GetString("anim_WalkRight"))
                    .Add("1 " & GetString("anim_WalkLeft"))
                    .Add("2 " & GetString("anim_Climb"))
                    .Add("3 " & GetString("anim_Die"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                Case psTile.TileBehavior.Collectable
                    .Add("0 " & GetString("anim_Normal"))
                    .Add("1 " & GetString("anim_Disappear"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                    '.Add("Custom 3")
                    '.Add("Custom 4")
                Case psTile.TileBehavior.Ledge
                    .Add("0 " & GetString("anim_Normal"))
                    .Add("1 " & GetString("anim_Disappear"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                    '.Add("Custom 3")
                    '.Add("Custom 4")
                Case psTile.TileBehavior.Solid
                    .Add("0 " & GetString("anim_Normal"))
                    .Add("1 " & GetString("anim_Disappear"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                    '.Add("Custom 3")
                    '.Add("Custom 4")
                Case psTile.TileBehavior.NoGravity
                    .Add("0 " & GetString("anim_Normal"))
                    .Add("1 " & GetString("anim_Disappear"))
                    '.Add("Custom 1")
                    '.Add("Custom 2")
                    '.Add("Custom 3")
                    '.Add("Custom 4")
            End Select
            Dim tmp As Integer = .Count
            For i As Integer = tmp To UBound(tile.Anim)
                .Add(i & " " & GetString("anim_Custom"))
            Next
        End With
        Return res
    End Function

    Overloads Function ShowDialog(ByRef tile As psTile) As DialogResult
        curTile = tile
        curTile.Anim = tile.Anim.Clone

        bmp = Game.Drawing.Tex(curTile.name).bmp

        'Setup animation choices
        With cboAnim.Items
            .Clear()
            .AddRange(getAnimationNames(tile).ToArray)
        End With

        'Setup frame choices
        Dim max As Integer, ItemArray() As Object
        max = (tile.width \ tile.sectionw) * _
              (tile.height \ tile.sectionh)
        ReDim ItemArray(max - 1)
        For i As Integer = 1 To max
            ItemArray(i - 1) = i
        Next
        cboStartFrame.Items.AddRange(ItemArray)
        cboStopFrame.Items.AddRange(ItemArray)

        'Fill the fields
        cboAnim.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        ComboBox1.Enabled = False

        'Show the dialog
        Render()
        Dim dr As DialogResult
        dr = ShowDialog()
        If dr = DialogResult.OK Then tile = curTile
        Return dr
    End Function

    Private Sub cboStartFrame_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboStartFrame.Validating
        StartFrameValidate()
    End Sub

    Sub StartFrameValidate()
        ConvertToNumber(cboStartFrame, 1, cboStartFrame.Items.Count, curTile.Anim(cboAnim.SelectedIndex).StartFrame)
        curTile.Anim(cboAnim.SelectedIndex).StartFrame = cboStartFrame.SelectedItem
    End Sub

    Private Sub cboStopFrame_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboStopFrame.Validating
        StopFrameValidate()
    End Sub

    Sub StopFrameValidate()
        ConvertToNumber(cboStopFrame, 1, cboStopFrame.Items.Count, curTile.Anim(cboAnim.SelectedIndex).StopFrame)
        curTile.Anim(cboAnim.SelectedIndex).StopFrame = cboStopFrame.SelectedItem
    End Sub

    Private Sub txtInterval_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInterval.Validating
        ConvertToNumber(txtInterval, 0, 600, curTile.Anim(cboAnim.SelectedIndex).Interval, 2)
        curTile.Anim(cboAnim.SelectedIndex).Interval = txtInterval.Text
    End Sub

    Private Sub txtAnimInterval_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAnimInterval.Validating
        ConvertToNumber(txtAnimInterval, 0, 1000000, curTile.Anim(cboAnim.SelectedIndex).AnimInterval, 2)
        curTile.Anim(cboAnim.SelectedIndex).AnimInterval = txtAnimInterval.Text
    End Sub

    Private Sub cboAnim_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnim.SelectedIndexChanged
        cboStartFrame.Text = curTile.Anim(cboAnim.SelectedIndex).StartFrame
        cboStopFrame.Text = curTile.Anim(cboAnim.SelectedIndex).StopFrame
        txtInterval.Text = CSng(Math.Round(curTile.Anim(cboAnim.SelectedIndex).Interval, 2%))
        txtAnimInterval.Text = CSng(Math.Round(curTile.Anim(cboAnim.SelectedIndex).AnimInterval, 2%))
        ComboBox1.Enabled = (cboAnim.Text = GetString("anim_Disappear") Or cboAnim.Text = GetString("anim_Die"))
        If ComboBox1.Enabled Then
            If curTile.Anim(cboAnim.SelectedIndex).StartFrame < 0 Then
                ComboBox1.SelectedIndex = -curTile.Anim(cboAnim.SelectedIndex).StartFrame
            Else
                ComboBox1.SelectedIndex = 0
            End If
        Else
            ComboBox1.SelectedIndex = 0
        End If
        UpdateStartStopEnabled()
        Button2.Enabled = cboAnim.SelectedItem.ToString().EndsWith(GetString("anim_Custom"))
    End Sub

    Private Sub UpdateStartStopEnabled()
        Label2.Enabled = (ComboBox1.SelectedIndex = 0)
        Label7.Enabled = (ComboBox1.SelectedIndex = 0)
        cboStartFrame.Enabled = (ComboBox1.SelectedIndex = 0)
        cboStopFrame.Enabled = (ComboBox1.SelectedIndex = 0)
        If ComboBox1.SelectedIndex = 0 Then
            Label3.Text = GetString("animEd_FrameIntervalLabel")
            Label5.Visible = True
            Label6.Visible = True
            txtAnimInterval.Visible = True
        Else
            Label3.Text = GetString("animEd_AnimationLengthLabel")
            Label5.Visible = False
            Label6.Visible = False
            txtAnimInterval.Visible = False
        End If
    End Sub

    Dim StartTime As Single, Frame As Integer

    'AutoRedraw
    Dim oImage As Image
    Dim xg1 As Graphics

    Sub Render()
        Static DidThis As Boolean

        If DidThis = False Then
            DidThis = True
            oImage = New Bitmap(picPreview.Width, picPreview.Height)
            xg1 = Graphics.FromImage(oImage)
            picPreview.Image = oImage
        End If

        With xg1
            .Clear(Color.FromArgb(0))

            If ComboBox1.SelectedIndex = 0 Then
                'Normal animation
                If curTile.Anim(cboAnim.SelectedIndex).Interval = 0 Then Frame = cboStartFrame.Text
                .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), ScaleRect(CurRect(curTile, cboAnim.SelectedIndex, StartTime, Frame, False), 1 / curTile.ScaleX, 1 / curTile.ScaleY), System.Drawing.GraphicsUnit.Pixel)
            Else
                'Effect (fade, flatten, fall, etc.)
                Dim Time As Single = (Timer - StartTime) / curTile.Anim(cboAnim.SelectedIndex).Interval
                If Time > 1 Then
                    StartTime = Timer
                    Time = 0
                ElseIf Time < 0 Then
                    Time = 0
                End If
                Dim src As Rectangle = ScaleRect(CurRect(curTile, 1), 1 / curTile.ScaleX, 1 / curTile.ScaleY)
                Select Case ComboBox1.SelectedIndex
                    Case 1 'AnimationEffect.Fade
                        .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), src, System.Drawing.GraphicsUnit.Pixel)
                        .FillRectangle(New Pen(Color.FromArgb(Time * 255, picPreview.BackColor.R, picPreview.BackColor.G, picPreview.BackColor.B)).Brush, New Rectangle(0, 0, picPreview.Width, picPreview.Height))
                    Case 2 'AnimationEffect.Flatten
                        .DrawImage(bmp, New Rectangle(0, Time * picPreview.Height, picPreview.Width, picPreview.Height - Time * 128), src, System.Drawing.GraphicsUnit.Pixel)
                    Case 3 'AnimationEffect.Fall
                        .DrawImage(bmp, New Rectangle(0, Time * picPreview.Height, picPreview.Width, picPreview.Height), src, System.Drawing.GraphicsUnit.Pixel)
                    Case 4 'AnimationEffect.BlinkOnce
                        If Int(Time * 2) Mod 2 = 1 Then
                            .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), src, System.Drawing.GraphicsUnit.Pixel)
                        End If
                    Case 5 'AnimationEffect.BlinkTwice
                        If Int(Time * 4) Mod 2 = 1 Then
                            .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), src, System.Drawing.GraphicsUnit.Pixel)
                        End If
                    Case 6 'AnimationEffect.BlinkThrice
                        If Int(Time * 6) Mod 2 = 1 Then
                            .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), src, System.Drawing.GraphicsUnit.Pixel)
                        End If
                End Select
            End If

        End With

        picPreview.Refresh()
    End Sub

    Private Sub tmrRender_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRender.Tick
        Render()
    End Sub

    Private Sub cboStartFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStartFrame.SelectedIndexChanged
        StartFrameValidate()
    End Sub

    Private Sub cboStopFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStopFrame.SelectedIndexChanged
        StopFrameValidate()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdateStartStopEnabled()
        curTile.Anim(cboAnim.SelectedIndex).StartFrame = -ComboBox1.SelectedIndex
        If curTile.Anim(cboAnim.SelectedIndex).StartFrame = 0 Then curTile.Anim(cboAnim.SelectedIndex).StartFrame = 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReDim Preserve curTile.Anim(UBound(curTile.Anim) + 1)
        With curTile.Anim(UBound(curTile.Anim))
            .StartFrame = 1
            .StopFrame = 1
            .Interval = 0
            .AnimInterval = 0
        End With
        cboAnim.Items.Add(cboAnim.Items.Count & " " & GetString("anim_Custom"))
        cboAnim.SelectedIndex = cboAnim.Items.Count - 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cboAnim.SelectedItem.ToString().EndsWith(GetString("anim_Custom")) Then
            For i As Integer = cboAnim.SelectedIndex To UBound(curTile.Anim) - 1
                curTile.Anim(i) = curTile.Anim(i + 1)
            Next
            ReDim Preserve curTile.Anim(UBound(curTile.Anim) - 1)
            cboAnim.Items.RemoveAt(cboAnim.SelectedIndex)
            cboAnim.SelectedIndex = 0
        End If
    End Sub
End Class
