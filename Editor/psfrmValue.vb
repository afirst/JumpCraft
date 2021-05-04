Imports PlatformStudio

Public Class psfrmValue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.dlgOpen.Filter = GetString("soundFileFilter")
        Me.dlgOpen.Title = GetString("selectAFileDialogTitle")
        Me.lblFrame.Text = GetString("editValue_FrameLabel")
        Me.TabPage1.Text = GetString("editValue_ValueTab")
        Me.TabPage2.Text = GetString("editValue_ExpressionTab")
        Me.MenuItem1.Text = GetString("editUndoMenu")
        Me.MenuItem2.Text = GetString("editRedoMenu")
        Me.MenuItem4.Text = GetString("editCutMenu")
        Me.MenuItem5.Text = GetString("editCopyMenu")
        Me.MenuItem6.Text = GetString("editPasteMenu")
        Me.MenuItem7.Text = GetString("editDeleteMenu")
        Me.MenuItem9.Text = GetString("editSelectAllMenu")
        Me.Text = GetString("enterValue_Title")
        UiPlusMenu1.Initialize(Me, ContextMenu1)
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cboValue As System.Windows.Forms.ComboBox
    Friend WithEvents cboIconValue As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtSound As System.Windows.Forms.TextBox
    Friend WithEvents btnSound As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblFrame As System.Windows.Forms.Label
    Friend WithEvents txtFrame As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CodeEditor1 As PlatformStudio.CodeEditor
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lstMembers As UIPlus.FloatControl
    Friend WithEvents lst_members As System.Windows.Forms.ListBox
    Friend WithEvents lblParam As UIPlus.FloatControl
    Friend WithEvents lbl_param As System.Windows.Forms.Label
    Friend WithEvents iml1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents UiPlusMenu1 As UIPlus.UIPlusMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmValue))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.cboValue = New System.Windows.Forms.ComboBox
        Me.cboIconValue = New System.Windows.Forms.ComboBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtSound = New System.Windows.Forms.TextBox
        Me.btnSound = New System.Windows.Forms.Button
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.lblFrame = New System.Windows.Forms.Label
        Me.txtFrame = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lstMembers = New UIPlus.FloatControl
        Me.lst_members = New System.Windows.Forms.ListBox
        Me.lblParam = New UIPlus.FloatControl
        Me.lbl_param = New System.Windows.Forms.Label
        Me.CodeEditor1 = New PlatformStudio.CodeEditor
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UiPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.lstMembers.SuspendLayout()
        Me.lblParam.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        Me.TextBox1.Visible = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(176, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 2

        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(96, 80)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 1

        '
        'cboValue
        '
        Me.cboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValue.Location = New System.Drawing.Point(8, 8)
        Me.cboValue.Name = "cboValue"
        Me.cboValue.Size = New System.Drawing.Size(216, 21)
        Me.cboValue.TabIndex = 4
        Me.cboValue.Visible = False
        '
        'cboIconValue
        '
        Me.cboIconValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboIconValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIconValue.IntegralHeight = False
        Me.cboIconValue.ItemHeight = 13
        Me.cboIconValue.Location = New System.Drawing.Point(8, 8)
        Me.cboIconValue.MaxDropDownItems = 12
        Me.cboIconValue.Name = "cboIconValue"
        Me.cboIconValue.Size = New System.Drawing.Size(144, 19)
        Me.cboIconValue.TabIndex = 0
        Me.cboIconValue.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(12, 12)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtSound
        '
        Me.txtSound.Location = New System.Drawing.Point(8, 8)
        Me.txtSound.Name = "txtSound"
        Me.txtSound.ReadOnly = True
        Me.txtSound.Size = New System.Drawing.Size(192, 20)
        Me.txtSound.TabIndex = 6
        Me.txtSound.Text = ""
        Me.txtSound.Visible = False
        '
        'btnSound
        '
        Me.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnSound.Location = New System.Drawing.Point(200, 8)
        Me.btnSound.Name = "btnSound"
        Me.btnSound.Size = New System.Drawing.Size(24, 20)
        Me.btnSound.TabIndex = 7
        Me.btnSound.Text = "..."
        Me.btnSound.Visible = False
        '
        'dlgOpen
        '


        '
        'lblFrame
        '
        Me.lblFrame.Location = New System.Drawing.Point(152, 8)
        Me.lblFrame.Name = "lblFrame"
        Me.lblFrame.Size = New System.Drawing.Size(48, 16)
        Me.lblFrame.TabIndex = 1

        Me.lblFrame.Visible = False
        '
        'txtFrame
        '
        Me.txtFrame.Location = New System.Drawing.Point(192, 8)
        Me.txtFrame.Name = "txtFrame"
        Me.txtFrame.Size = New System.Drawing.Size(32, 20)
        Me.txtFrame.TabIndex = 2
        Me.txtFrame.Text = "0"
        Me.txtFrame.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(240, 60)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtFrame)
        Me.TabPage1.Controls.Add(Me.lblFrame)
        Me.TabPage1.Controls.Add(Me.cboIconValue)
        Me.TabPage1.Controls.Add(Me.cboValue)
        Me.TabPage1.Controls.Add(Me.btnSound)
        Me.TabPage1.Controls.Add(Me.txtSound)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(232, 34)
        Me.TabPage1.TabIndex = 0

        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstMembers)
        Me.TabPage2.Controls.Add(Me.lblParam)
        Me.TabPage2.Controls.Add(Me.CodeEditor1)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(232, 34)
        Me.TabPage2.TabIndex = 1

        '
        'lstMembers
        '
        Me.lstMembers.Controls.Add(Me.lst_members)
        Me.lstMembers.Location = New System.Drawing.Point(112, 24)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(174, 167)
        Me.lstMembers.TabIndex = 12
        Me.lstMembers.Visible = False
        '
        'lst_members
        '
        Me.lst_members.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_members.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lst_members.IntegralHeight = False
        Me.lst_members.ItemHeight = 16
        Me.lst_members.Location = New System.Drawing.Point(0, 0)
        Me.lst_members.Name = "lst_members"
        Me.lst_members.ScrollAlwaysVisible = True
        Me.lst_members.Size = New System.Drawing.Size(174, 167)
        Me.lst_members.Sorted = True
        Me.lst_members.TabIndex = 8
        '
        'lblParam
        '
        Me.lblParam.Controls.Add(Me.lbl_param)
        Me.lblParam.Location = New System.Drawing.Point(24, 16)
        Me.lblParam.Name = "lblParam"
        Me.lblParam.Size = New System.Drawing.Size(264, 16)
        Me.lblParam.TabIndex = 11
        Me.lblParam.Visible = False
        '
        'lbl_param
        '
        Me.lbl_param.BackColor = System.Drawing.SystemColors.Info
        Me.lbl_param.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_param.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_param.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.lbl_param.Location = New System.Drawing.Point(0, 0)
        Me.lbl_param.Name = "lbl_param"
        Me.lbl_param.Size = New System.Drawing.Size(264, 16)
        Me.lbl_param.TabIndex = 7
        '
        'CodeEditor1
        '
        Me.CodeEditor1.AcceptsTab = True
        Me.CodeEditor1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CodeEditor1.ContextMenu = Me.ContextMenu1
        Me.CodeEditor1.DoColorCode = True
        Me.CodeEditor1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeEditor1.Location = New System.Drawing.Point(9, 9)
        Me.CodeEditor1.Multiline = False
        Me.CodeEditor1.Name = "CodeEditor1"
        Me.CodeEditor1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.CodeEditor1.Size = New System.Drawing.Size(214, 18)
        Me.CodeEditor1.TabIndex = 0
        Me.CodeEditor1.Text = ""
        Me.CodeEditor1.WordWrap = False
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0

        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1

        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3

        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4

        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5

        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 6

        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 7
        Me.MenuItem8.Text = "-"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 8

        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(8, 8)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(216, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "TextBox2"
        '
        'iml1
        '
        Me.iml1.ImageSize = New System.Drawing.Size(16, 16)
        Me.iml1.ImageStream = CType(resources.GetObject("iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml1.TransparentColor = System.Drawing.Color.White
        '
        'UiPlusMenu1
        '
        Me.UiPlusMenu1.CustomColorScheme = Nothing
        '
        'psfrmValue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(258, 112)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.lstMembers.ResumeLayout(False)
        Me.lblParam.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim CurParam As psActions.psActionBehavior.psActionParameter
    Dim OldValue As String
    Dim intel As Intellisense

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, CodeEditor1.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            ValidateText()
            DialogResult = DialogResult.OK
        ElseIf e.KeyChar = Chr(27) Then
            e.Handled = True
            DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ValidateText()
    End Sub

    Sub ValidateText()
        Select Case CurParam.ValueType
            Case psActions.psValueType.Number
                If IsNumeric(OldValue) = False Then OldValue = 0
                ConvertToNumber(TextBox1, CurParam.MinValue, CurParam.MaxValue, OldValue, CurParam.DecimalPlaces)
        End Select
    End Sub

    Private Enum InputType
        EnterValue = 0
        SelectValue
        IconValue
        Sound
        Music
        Image
        Movie
        AnyFile
    End Enum

    Overloads Function ShowDialog(ByRef param As String, ByVal ParamDat As psActions.psActionBehavior.psActionParameter) As DialogResult
        CurParam = ParamDat
        OldValue = param

        intel = New Intellisense(lstMembers, lblParam, lst_members, iml1, CodeEditor1, lbl_param)
        intel.ObjArray = psfrmScriptEditor.DefaultObjectArray

        Text = String.Format(GetString("enterValue_DescriptiveTitle"), ParamDat.Name)

        If param Is Nothing Then param = ""

        Dim i As Integer
        Dim InputType As InputType
        Dim Script As Boolean
        If param.StartsWith("<SCRIPT>") Then Script = True
        Select Case CurParam.ValueType
            Case psActions.psValueType.Number, psActions.psValueType.Text
                TextBox1.Visible = True
                If Not Script Then
                    TextBox1.Text = param
                    TextBox1.Select(0, Len(TextBox1.Text))
                End If
                InputType = InputType.EnterValue
            Case psActions.psValueType.Graphic
                With cboIconValue
                    .Visible = True
                    For i = 1 To Game.tileset.NumTiles
                        ImageList1.Images.Add(Game.Drawing.Tex(Game.tileset.tiles(i).name).preview) 'Editor.pstileselect.iml.Images(i - 1))
                        .Items.Add(Game.tileset.tiles(i).name)
                        cboIconValue_MeasureItem(Nothing, New MeasureItemEventArgs(cboIconValue.CreateGraphics, i - 1))
                    Next
                    If Not Script Then
                        If param Is Nothing Then param = ""
                        If param.EndsWith("|") Then
                            .Text = param.Substring(0, param.IndexOf("|"))
                            txtFrame.Text = param.Substring(param.IndexOf("|")).Trim("|")
                        Else
                            .Text = param
                            txtFrame.Text = ""
                        End If
                        .Text = param
                        .Select()
                    End If
                    If ParamDat.Name.ToLower = "bullet tile" Then
                        lblFrame.Visible = True
                        txtFrame.Visible = True
                        cboIconValue.Width = 144
                    Else
                        lblFrame.Visible = False
                        txtFrame.Visible = False
                        cboIconValue.Width = 208
                        txtFrame.Text = ""
                    End If
                End With
                InputType = InputType.IconValue
            Case psActions.psValueType.Sound, psActions.psValueType.Music, psActions.psValueType.Image, psActions.psValueType.Movie, psActions.psValueType.File
                With txtSound
                    .Visible = True
                    If Not Script Then .Text = param
                End With
                With btnSound
                    .Visible = True
                    .Select()
                End With
                Select Case CurParam.ValueType
                    Case psActions.psValueType.Sound
                        dlgOpen.Filter = GetString("soundFileFilter")
                        InputType = InputType.Sound
                    Case psActions.psValueType.Music
                        dlgOpen.Filter = GetString("musicFileFilter")
                        InputType = InputType.Music
                    Case psActions.psValueType.Image
                        dlgOpen.Filter = GetString("imageFileFilter")
                        InputType = InputType.Image
                    Case psActions.psValueType.Movie
                        dlgOpen.Filter = GetString("movieFileFilter")
                        InputType = InputType.Movie
                    Case psActions.psValueType.File
                        dlgOpen.Filter = GetString("mixedFileFilter")
                        InputType = InputType.AnyFile
                End Select
            Case Else
                With cboValue
                    .Visible = True
                    Select Case CurParam.ValueType
                        Case psActions.psValueType.Direction
                            Dim items() As String = {"Left", "Right", "Up", "Down"}
                            .Items.AddRange(items)
                        Case psActions.psValueType.Direction2
                            Dim items() As String = {"Left", "Right", "Up", "Down", "Current Direction"}
                            .Items.AddRange(items)
                        Case psActions.psValueType.YesNo
                            Dim items() As String = {"Yes", "No"}
                            .Items.AddRange(items)
                        Case psActions.psValueType.Choices
                            Dim items() As String = Split(CurParam.Description, System.Environment.NewLine)
                            .Items.AddRange(items)
                        Case psActions.psValueType.TileGroup
                            Dim items() As String
                            Dim tmp() As String
                            ReDim items(0)
                            Dim j As Integer
                            items(0) = "(Current Group)"
                            For i = 1 To Game.numMaps
                                tmp = ListGroups(i)
                                ReDim Preserve items(UBound(items) + UBound(tmp))
                                For j = 1 To UBound(tmp)
                                    items(UBound(items) - UBound(tmp) + j) = tmp(j)
                                Next
                            Next
                            .Items.AddRange(items)
                        Case psActions.psValueType.Counter
                            Dim items() As String
                            ReDim items(UBound(Game.actions.Counters) - 1)
                            For i = 1 To UBound(Game.actions.Counters)
                                items(i - 1) = Game.actions.Counters(i).Name
                            Next
                            .Items.AddRange(items)
                        Case psActions.psValueType.Timer
                            Dim items() As String
                            ReDim items(UBound(Game.actions.Timers) - 1)
                            For i = 1 To UBound(Game.actions.Timers)
                                items(i - 1) = Game.actions.Timers(i).Name
                            Next
                            .Items.AddRange(items)
                    End Select
                    If Not Script Then
                        .Text = param
                        .Select()
                    End If
                End With
                InputType = InputType.SelectValue
        End Select

        'Sciprts
        If param.StartsWith("<SCRIPT>") Then
            TabControl1.SelectedIndex = 1
            CodeEditor1.Text = param.Substring(8)
            CodeEditor1.Select()
        End If

        Dim dr As DialogResult
        dr = ShowDialog()

        If dr = DialogResult.OK Then
            If TabControl1.SelectedIndex = 1 Then
                'Script
                param = "<SCRIPT>" & CodeEditor1.Text
            Else
                If InputType = InputType.EnterValue Then
                    param = TextBox1.Text
                ElseIf InputType = InputType.SelectValue Then
                    param = cboValue.Text
                ElseIf InputType = InputType.IconValue Then
                    If txtFrame.Text = "" Then
                        param = cboIconValue.Text
                    Else
                        param = cboIconValue.Text & "|" & txtFrame.Text & "|"
                    End If
                ElseIf InputType = InputType.Sound Then
                    param = txtSound.Text
                ElseIf InputType = InputType.Music Then
                    param = txtSound.Text
                ElseIf InputType = InputType.Image Then
                    param = txtSound.Text
                ElseIf InputType = InputType.Movie Then
                    param = txtSound.Text
                ElseIf InputType = InputType.AnyFile Then
                    param = txtSound.Text
                End If
            End If
        End If
        Return dr
    End Function

    Private Sub cboIconValue_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles cboIconValue.MeasureItem
        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable and it always fires before the DrawItem event.

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return

        'The string that will appear in the current item and that I will use to measure when determining the height and width variable.
        Dim str As String = cboIconValue.Items(e.Index)
        'The string stripped of the newline character
        Dim strOneLine As String = Join(Split(str, Environment.NewLine), "")
        ' The image that will appear in the current item and that I will use to measure when determining the height variable.
        Dim img As Image = ImageList1.Images(e.Index)

        'for the item height, use the maximum of the image height or the string height and add 10%.
        Dim hgt As Single = Math.Max(img.Height, e.Graphics.MeasureString(str, Me.cboIconValue.Font).Height) * 1.1
        e.ItemHeight = hgt

        'if I'm using dropdownstyle = dropdownlist, I want the text area at the top of the combobox to be tall enough for the image and text together, so I set the combo box itemheight property to the hgt value. When I use Simple or DropDown with OwnerDrawVariable, I want the text area at the top of the combobox to shrink back to a height that accommodates one line of text.
        If Me.cboIconValue.DropDownStyle = ComboBoxStyle.DropDownList Then
            Me.cboIconValue.ItemHeight = hgt
        Else
            Me.cboIconValue.ItemHeight = e.Graphics.MeasureString(strOneLine, Me.cboIconValue.Font).Height * 1.1
        End If

        'in our example, the width of the combo box item does not need to be calculated because the width of the combo box is suuficient for all of the items we're working with
        e.ItemWidth = Me.cboIconValue.Width
    End Sub

    Private Sub cboIconValue_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboIconValue.DrawItem
        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable or OwnerDrawFixed

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return
        'a string variable to hold the text that I will draw
        Dim str As String = cboIconValue.Items(e.Index)
        ' a graphic variable to minimize my typing :)
        Dim g As Graphics = e.Graphics
        'a couple of brush objects I'll need for filling rectangles
        Dim bBlue As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
        Dim bWhite As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Window))
        Dim bBlack As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.WindowText))

        'Adjust the value of Combobox.itemheight if the drawmode is ownerdrawfixed because the Measureitem event won't fire for that mode! This is necessary because the drawmode in this sample can be changed at runtime.
        Dim hgt As Single
        Dim img As Image = ImageList1.Images(e.Index)
        If Me.cboIconValue.DrawMode = DrawMode.OwnerDrawFixed Then
            hgt = Math.Max(img.Height, e.Graphics.MeasureString(str, Me.cboIconValue.Font).Height) * 1.1
            Me.cboIconValue.ItemHeight = hgt
        End If

        'Determine if I'm highlighting the current combo box item because 
        'I want the selected item to look different from those that are not selected.
        Dim bHighlightItem As Boolean = Me.ShouldIHighlight(e.State)

        If bHighlightItem = True Then
            'fill the background of the item
            g.FillRectangle(bBlue, e.Bounds)
            'draw the image from the image list control, offset it by 5 pixels and makes sure it's centered vertically
            Dim myImage As Image = CType(ImageList1.Images(e.Index), Image)
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            'draw the text, position it so that it starts 5 pixels to the right of the image
            g.DrawString(str, Me.cboIconValue.Font, bWhite, e.Bounds.Left + myimage.Width + 5, e.Bounds.Top)
        Else
            'this block does the same thing as above but uses different colors to represent the different state.
            g.FillRectangle(bWhite, e.Bounds)
            Dim myImage As Image = CType(ImageList1.Images(e.Index), Image)
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            g.DrawString(str, Me.cboIconValue.Font, bBlack, e.Bounds.Left + myimage.Width + 5, e.Bounds.Top)
        End If
        'Dispose of my brushes
        bBlue.Dispose()
        bWhite.Dispose()
        bBlue = Nothing
        bWhite = Nothing
    End Sub

    Private Function ShouldIHighlight(ByVal State As DrawItemState) As Boolean
        'Note: The following IF statement is more complicated than what you would use in an actual project. This is necessary because I am testing for the dropdownstyle of the combobox during runtime. In a real project you probably would not let the user change that value at runtime.
        ' To accomplish this, I also have to check the OS version (because each generates different drawitemstate values). I will check for Win2K or XP.
        If (cboIconValue.DropDownStyle = ComboBoxStyle.Simple And State = (DrawItemState.Selected Or DrawItemState.NoFocusRect Or DrawItemState.NoAccelerator)) _
        Or (cboIconValue.DropDownStyle = ComboBoxStyle.DropDown And State = (DrawItemState.Selected Or DrawItemState.NoFocusRect Or DrawItemState.NoAccelerator)) _
        Or (cboIconValue.DropDownStyle = ComboBoxStyle.DropDownList And State = (DrawItemState.Selected Or DrawItemState.Focus Or DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect)) _
        Or (cboIconValue.DropDownStyle = ComboBoxStyle.Simple And State = DrawItemState.Selected) Then

            Return True
        End If

    End Function

    Private Sub btnSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSound.Click
        dlgOpen.FileName = txtSound.Text
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        txtSound.Text = dlgOpen.FileName
    End Sub

    Private Sub txtFrame_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFrame.Validating
        ConvertToNumber(txtFrame, 1, 1000, 0)
        If txtFrame.Text = 0 Then txtFrame.Text = ""
    End Sub

    Private Sub Form_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        Try
            intel.RepositionMembersList()
            intel.RepositionParamsList()
        Catch
        End Try
    End Sub

    Private Sub psfrmValue_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        lstMembers.Visible = False
        lblParam.Visible = False
    End Sub

    Private Sub Undo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        CodeEditor1.Undo()
    End Sub

    Private Sub Redo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        CodeEditor1.Redo()
    End Sub

    Private Sub Cut(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        CodeEditor1.Cut()
    End Sub

    Private Sub Copy(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        CodeEditor1.Copy()
    End Sub

    Private Sub Paste(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        CodeEditor1.Paste(DataFormats.GetFormat(DataFormats.Text))
    End Sub

    Private Sub Delete(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        If CodeEditor1.SelectedText <> "" Then
            CodeEditor1.SelectedText = ""
        Else
            If CodeEditor1.SelectionStart < CodeEditor1.TextLength Then
                CodeEditor1.SelectionLength = 1
                CodeEditor1.SelectedText = ""
            End If
        End If
    End Sub

    Private Sub SelectAll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        CodeEditor1.SelectAll()
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        MenuItem1.Text = String.Format(GetString("editUndoMenuLong"), CodeEditor1.UndoActionName)
        MenuItem1.Enabled = CodeEditor1.CanUndo
        MenuItem2.Text = String.Format(GetString("editRedoMenuLong"), CodeEditor1.RedoActionName)
        MenuItem2.Enabled = CodeEditor1.CanRedo
        MenuItem4.Enabled = CodeEditor1.SelectedText <> ""
        MenuItem5.Enabled = CodeEditor1.SelectedText <> ""
        MenuItem6.Enabled = CodeEditor1.CanPaste(DataFormats.GetFormat(DataFormats.Text))
    End Sub
End Class
