'Layer system:
'-------------
'There are 6 different layers drawn in this order:
'   NAME        SCROLL SPDEED   BEHAVIOR
'   Back        0%              Static background image/color
'   Parallax    50% (can vary)  Bkgrnd that can scroll (clouds, etc.)
'   Background  100%            Normal layer
'   Foreground  100%            Normal layer
'   Front       100%            Normal layer
'   Location    100%            Stores locations that use actions
'Map.CurLayer refer to layers EXCLUDING the BACK layer
'   0=Parallax
'   1=Background
'   2=Foreground
'   3=Front
'   4=Locations
'game.LayerVisible and psLayerSelector checkboxes
'refer to layers INCLUDING the BACK layer
'   0=Back
'   1=Parallax
'   2=Background
'   3=Foreground
'   4=Front
'   5=Locations
'Therefore, when converting between (A) CurLayer and either (B)
'LayerVisible or psLayerSelector's checkbox numbering system,
'you must:
'   A->B: Add 1
'   B->A: Subtract 1

Imports System.Drawing.Drawing2D
Imports UIPlus
Imports PlatformStudio

Public Class psLayerSelector
    Inherits System.Windows.Forms.UserControl
    Dim Changing As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.l0.Text = GetString("layer_Backdrop")
        Me.l5.Text = GetString("layer_Location")
        Me.Label3.Text = GetString("layer")
        Me.Label2.Text = GetString("visible")
        Me.Label1.Text = GetString("active")
        Me.l1.Text = GetString("layer_Parallax")
        Me.l2.Text = GetString("layer_Background")
        Me.l3.Text = GetString("layer_Foreground")
        Me.l4.Text = GetString("layer_Front")
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents v0 As System.Windows.Forms.CheckBox
    Public WithEvents a0 As System.Windows.Forms.CheckBox
    Friend WithEvents l0 As System.Windows.Forms.Label
    Friend WithEvents v5 As System.Windows.Forms.CheckBox
    Friend WithEvents a5 As System.Windows.Forms.CheckBox
    Friend WithEvents l5 As System.Windows.Forms.Label
    Friend WithEvents v4 As System.Windows.Forms.CheckBox
    Friend WithEvents v3 As System.Windows.Forms.CheckBox
    Friend WithEvents v2 As System.Windows.Forms.CheckBox
    Friend WithEvents v1 As System.Windows.Forms.CheckBox
    Friend WithEvents a4 As System.Windows.Forms.CheckBox
    Friend WithEvents a3 As System.Windows.Forms.CheckBox
    Friend WithEvents a2 As System.Windows.Forms.CheckBox
    Friend WithEvents a1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents l2 As System.Windows.Forms.Label
    Friend WithEvents l3 As System.Windows.Forms.Label
    Friend WithEvents l4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.v0 = New System.Windows.Forms.CheckBox
        Me.a0 = New System.Windows.Forms.CheckBox
        Me.l0 = New System.Windows.Forms.Label
        Me.v5 = New System.Windows.Forms.CheckBox
        Me.a5 = New System.Windows.Forms.CheckBox
        Me.l5 = New System.Windows.Forms.Label
        Me.v4 = New System.Windows.Forms.CheckBox
        Me.v3 = New System.Windows.Forms.CheckBox
        Me.v2 = New System.Windows.Forms.CheckBox
        Me.v1 = New System.Windows.Forms.CheckBox
        Me.a4 = New System.Windows.Forms.CheckBox
        Me.a3 = New System.Windows.Forms.CheckBox
        Me.a2 = New System.Windows.Forms.CheckBox
        Me.a1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.l1 = New System.Windows.Forms.Label
        Me.l2 = New System.Windows.Forms.Label
        Me.l3 = New System.Windows.Forms.Label
        Me.l4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'v0
        '
        Me.v0.Checked = True
        Me.v0.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v0.Location = New System.Drawing.Point(54, 34)
        Me.v0.Name = "v0"
        Me.v0.Size = New System.Drawing.Size(13, 13)
        Me.v0.TabIndex = 40
        '
        'a0
        '
        Me.a0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a0.Location = New System.Drawing.Point(14, 34)
        Me.a0.Name = "a0"
        Me.a0.Size = New System.Drawing.Size(13, 13)
        Me.a0.TabIndex = 39
        '
        'l0
        '
        Me.l0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l0.BackColor = System.Drawing.Color.Transparent
        Me.l0.Location = New System.Drawing.Point(6, 32)
        Me.l0.Name = "l0"
        Me.l0.Size = New System.Drawing.Size(140, 17)
        Me.l0.TabIndex = 41
        Me.l0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'v5
        '
        Me.v5.Checked = True
        Me.v5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v5.Location = New System.Drawing.Point(54, 154)
        Me.v5.Name = "v5"
        Me.v5.Size = New System.Drawing.Size(13, 13)
        Me.v5.TabIndex = 37
        '
        'a5
        '
        Me.a5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a5.Location = New System.Drawing.Point(14, 154)
        Me.a5.Name = "a5"
        Me.a5.Size = New System.Drawing.Size(13, 13)
        Me.a5.TabIndex = 36
        '
        'l5
        '
        Me.l5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l5.BackColor = System.Drawing.Color.Transparent
        Me.l5.Location = New System.Drawing.Point(6, 152)
        Me.l5.Name = "l5"
        Me.l5.Size = New System.Drawing.Size(140, 17)
        Me.l5.TabIndex = 38
        Me.l5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'v4
        '
        Me.v4.Checked = True
        Me.v4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v4.Location = New System.Drawing.Point(54, 130)
        Me.v4.Name = "v4"
        Me.v4.Size = New System.Drawing.Size(13, 13)
        Me.v4.TabIndex = 31
        '
        'v3
        '
        Me.v3.Checked = True
        Me.v3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v3.Location = New System.Drawing.Point(54, 106)
        Me.v3.Name = "v3"
        Me.v3.Size = New System.Drawing.Size(13, 13)
        Me.v3.TabIndex = 30
        '
        'v2
        '
        Me.v2.Checked = True
        Me.v2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v2.Location = New System.Drawing.Point(54, 82)
        Me.v2.Name = "v2"
        Me.v2.Size = New System.Drawing.Size(13, 13)
        Me.v2.TabIndex = 29
        '
        'v1
        '
        Me.v1.Checked = True
        Me.v1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.v1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.v1.Location = New System.Drawing.Point(54, 58)
        Me.v1.Name = "v1"
        Me.v1.Size = New System.Drawing.Size(13, 13)
        Me.v1.TabIndex = 28
        '
        'a4
        '
        Me.a4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a4.Location = New System.Drawing.Point(14, 130)
        Me.a4.Name = "a4"
        Me.a4.Size = New System.Drawing.Size(13, 13)
        Me.a4.TabIndex = 27
        '
        'a3
        '
        Me.a3.Checked = True
        Me.a3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.a3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a3.Location = New System.Drawing.Point(14, 106)
        Me.a3.Name = "a3"
        Me.a3.Size = New System.Drawing.Size(13, 13)
        Me.a3.TabIndex = 26
        '
        'a2
        '
        Me.a2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a2.Location = New System.Drawing.Point(14, 82)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(13, 13)
        Me.a2.TabIndex = 25
        '
        'a1
        '
        Me.a1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.a1.Location = New System.Drawing.Point(14, 58)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(13, 13)
        Me.a1.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(90, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l1
        '
        Me.l1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l1.BackColor = System.Drawing.Color.Transparent
        Me.l1.Location = New System.Drawing.Point(6, 56)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(140, 17)
        Me.l1.TabIndex = 32
        Me.l1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'l2
        '
        Me.l2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l2.BackColor = System.Drawing.Color.Transparent
        Me.l2.Location = New System.Drawing.Point(6, 80)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(140, 17)
        Me.l2.TabIndex = 33
        Me.l2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'l3
        '
        Me.l3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l3.BackColor = System.Drawing.Color.Transparent
        Me.l3.Location = New System.Drawing.Point(6, 104)
        Me.l3.Name = "l3"
        Me.l3.Size = New System.Drawing.Size(140, 17)
        Me.l3.TabIndex = 34
        Me.l3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'l4
        '
        Me.l4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l4.BackColor = System.Drawing.Color.Transparent
        Me.l4.Location = New System.Drawing.Point(8, 128)
        Me.l4.Name = "l4"
        Me.l4.Size = New System.Drawing.Size(140, 17)
        Me.l4.TabIndex = 35
        Me.l4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'psLayerSelector
        '
        Me.Controls.Add(Me.v0)
        Me.Controls.Add(Me.a0)
        Me.Controls.Add(Me.l0)
        Me.Controls.Add(Me.v5)
        Me.Controls.Add(Me.a5)
        Me.Controls.Add(Me.l5)
        Me.Controls.Add(Me.v4)
        Me.Controls.Add(Me.v3)
        Me.Controls.Add(Me.v2)
        Me.Controls.Add(Me.v1)
        Me.Controls.Add(Me.a4)
        Me.Controls.Add(Me.a3)
        Me.Controls.Add(Me.a2)
        Me.Controls.Add(Me.a1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.l2)
        Me.Controls.Add(Me.l3)
        Me.Controls.Add(Me.l4)
        Me.Name = "psLayerSelector"
        Me.Size = New System.Drawing.Size(160, 200)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Editor.pslayersel = Me
    End Sub

    Private Sub psLayerSelector_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'Size = New Size(160, 200)
    End Sub

    Private Sub a1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a1.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Changing Then Exit Sub
        Changing = True
        a1.Checked = True
        a2.Checked = False
        a3.Checked = False
        a4.Checked = False
        a5.Checked = False
        v1.Checked = True
        Changing = False
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        psMap.CurLayer = 0
        UpdateProperties()
    End Sub

    Sub UpdateProperties()
        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Private Sub a2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Changing Then Exit Sub
        Changing = True
        a1.Checked = False
        a2.Checked = True
        a3.Checked = False
        a4.Checked = False
        a5.Checked = False
        v2.Checked = True
        Changing = False
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        psMap.CurLayer = 1
        UpdateProperties()
    End Sub

    Private Sub a3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a3.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Changing Then Exit Sub
        Changing = True
        a1.Checked = False
        a2.Checked = False
        a3.Checked = True
        a4.Checked = False
        a5.Checked = False
        v3.Checked = True
        Changing = False
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        psMap.CurLayer = 2
        UpdateProperties()
    End Sub

    Private Sub a4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a4.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Changing Then Exit Sub
        Changing = True
        a1.Checked = False
        a2.Checked = False
        a3.Checked = False
        a4.Checked = True
        a5.Checked = False
        v4.Checked = True
        Changing = False
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        psMap.CurLayer = 3
        UpdateProperties()
    End Sub

    Private Sub a5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a5.CheckedChanged
        If Game Is Nothing Then Exit Sub
        If Changing Then Exit Sub
        Changing = True
        a1.Checked = False
        a2.Checked = False
        a3.Checked = False
        a4.Checked = False
        a5.Checked = True
        v5.Checked = True
        Changing = False
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        psMap.CurLayer = 4
        UpdateProperties()
    End Sub

    Private Sub v1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v1.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(1) = v1.Checked
        If Changing Then Exit Sub
        Changing = True
        If a1.Checked And v1.Checked = False Then
            a1.Checked = False
            v3.Checked = True
            a3.Checked = True
        End If
        Changing = False
    End Sub

    Private Sub v2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v2.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(2) = v2.Checked
        If Changing Then Exit Sub
        Changing = True
        If a2.Checked And v2.Checked = False Then
            a2.Checked = False
            v3.Checked = True
            a3.Checked = True
        End If
        Changing = False
    End Sub

    Private Sub v3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v3.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(3) = v3.Checked
        If Changing Then Exit Sub
        Changing = True
        If a3.Checked And v3.Checked = False Then
            a3.Checked = False
            v2.Checked = True
            a2.Checked = True
        End If
        Changing = False
    End Sub

    Private Sub v4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v4.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(4) = v4.Checked
        If Changing Then Exit Sub
        Changing = True
        If a4.Checked And v4.Checked = False Then
            a4.Checked = False
            v3.Checked = True
            a3.Checked = True
        End If
        Changing = False
    End Sub

    Private Sub v5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v5.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(5) = v5.Checked
        If Changing Then Exit Sub
        Changing = True
        If a5.Checked And v5.Checked = False Then
            a5.Checked = False
            v3.Checked = True
            a3.Checked = True
        End If
        Changing = False
    End Sub

    Private Sub lbl_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l0.MouseEnter, l1.MouseEnter, l2.MouseEnter, l3.MouseEnter, l4.MouseEnter, l5.MouseEnter
        SetActive(sender)
    End Sub

    Private Sub lbl_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l0.MouseLeave, l1.MouseLeave, l2.MouseLeave, l3.MouseLeave, l4.MouseLeave, l5.MouseLeave
        SetInactive(sender)
    End Sub

    Private Sub lbl_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l0.MouseDown, l1.MouseDown, l2.MouseDown, l3.MouseDown, l4.MouseDown, l5.MouseDown
        SetPressed(sender)
    End Sub

    Private Sub lbl_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles l0.MouseUp, l1.MouseUp, l2.MouseUp, l3.MouseUp, l4.MouseUp, l5.MouseUp
        If sender.tag <> "" Then
            lbl_MouseEnter(sender, e)
        End If
    End Sub

    Private Sub a0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a0.CheckedChanged
        psFileHandler.MadeChanges = True
        If a0.Checked Then
            Dim f As New psfrmBackgroundEditor
            Dim OldLayer As Integer
            OldLayer = psMap.CurLayer
            UndoRedo.UpdateUndo(GetString("undoActionEditBackground"), UndoRedo.UndoType.Level, Game.CurMapIndex)
            f.ShowDialog(Game.CurMap.Background, Game.maps(Game.CurMapIndex).Background)
            Game.maps(Game.CurMapIndex).Background.imgFilename = Game.maps(Game.CurMapIndex).Background.imgFilename
            f = Nothing
            Changing = True
            a0.Checked = False
            Changing = False
            Select Case OldLayer
                Case 0 : a1.Checked = True
                Case 1 : a2.Checked = True
                Case 2 : a3.Checked = True
                Case 3 : a4.Checked = True
                Case 4 : a5.Checked = True
            End Select
            SetInactive(l0)
        End If
    End Sub

    Private Sub v0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v0.CheckedChanged
        If Game Is Nothing Then Exit Sub
        Game.LayerVisible(0) = v0.Checked
    End Sub

    Private Sub l0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l0.Click
        a0.Checked = True
    End Sub

    Private Sub l1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l1.Click
        a1.Checked = True
    End Sub

    Private Sub l2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l2.Click
        a2.Checked = True
    End Sub

    Private Sub l3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l3.Click
        a3.Checked = True
    End Sub

    Private Sub l4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l4.Click
        a4.Checked = True
    End Sub

    Private Sub l5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l5.Click
        a5.Checked = True
    End Sub

    Sub SetCurLayer(ByVal Value As Integer)
        psMap.CurLayer = Value
        Select Case Value + 1
            Case 0 : a0.Checked = True
            Case 1 : a1.Checked = True
            Case 2 : a2.Checked = True
            Case 3 : a3.Checked = True
            Case 4 : a4.Checked = True
            Case 5 : a5.Checked = True
        End Select
    End Sub

    Private Sub CtlMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Me.Focus()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'Background
        With e.Graphics
            Dim b As New LinearGradientBrush( _
                New Rectangle(0, 0, Width, Height), _
                ColorOp.Blend(SystemColors.Control, SystemColors.ControlLightLight, 0.35), _
                ColorOp.Blend(SystemColors.Control, SystemColors.ControlDark, 0.12), _
                LinearGradientMode.Horizontal)
            .FillRectangle(b, New Rectangle(0, 0, Width, Height))
            b.Dispose()
        End With
    End Sub

    Sub SetActive(ByVal lbl As Label)
        'lbl.BackColor = Color.FromKnownColor(KnownColor.InactiveCaptionText)
        lbl.Tag = "Over"
        DrawLabel(lbl, UIPlus.DefaultColorScheme.getInstance.ToolbarSel1, UIPlus.DefaultColorScheme.getInstance.SelBorder)
    End Sub

    Sub SetInactive(ByVal lbl As Label)
        lbl.Tag = ""
        lbl.Refresh()
        lbl.BackColor = Color.Transparent
    End Sub

    Sub SetPressed(ByVal lbl As Label)
        'lbl.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption)
        lbl.Tag = "Pressed"
        DrawLabel(lbl, UIPlus.DefaultColorScheme.getInstance.ToolbarPressed1, UIPlus.DefaultColorScheme.getInstance.ToolbarPressedBorder)
    End Sub

    Private Sub DrawLabel(ByVal lbl As Label, ByVal fill As Color, ByVal line As Color)
        Dim b As New SolidBrush(fill)
        Dim p As New Pen(line)
        lbl.CreateGraphics.FillRectangle(b, New Rectangle(0, 0, lbl.Width, lbl.Height))
        lbl.CreateGraphics.DrawRectangle(p, New Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1))
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Far
        sf.LineAlignment = StringAlignment.Center
        lbl.CreateGraphics.DrawString(lbl.Text, lbl.Font, SystemBrushes.ControlText, New RectangleF(0, 0, lbl.Width, lbl.Height), sf)
        sf.Dispose()
        p.Dispose()
        b.Dispose()
    End Sub
End Class