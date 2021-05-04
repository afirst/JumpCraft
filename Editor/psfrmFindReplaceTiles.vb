Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Public Class psfrmFindReplaceTiles
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("findRepl_FindWhatLabel")
        Me.Label2.Text = GetString("findRepl_ReplaceWithLabel")
        Me.btnFindNext.Text = GetString("findRepl_FindNextButton")
        Me.btnFindAll.Text = GetString("findRepl_FindAllButton")
        Me.btnReplaceAll.Text = GetString("findRepl_ReplaceAllButton")
        Me.btnReplaceNext.Text = GetString("findRepl_ReplaceNextButton")
        Me.btnCancel.Text = GetString("cancelButton")
        Me.GroupBox1.Text = GetString("findRepl_SearchInFrame")
        Me.optAllLevels.Text = GetString("findRepl_AllLevelsOption")
        Me.optCurLayer.Text = GetString("findRepl_CurrentLayerOption")
        Me.optCurLevel.Text = GetString("findRepl_CurrentLevelOption")
        Me.GroupBox2.Text = GetString("findRepl_SearchForGroupFrame")
        Me.Text = GetString("findRepl_Title")
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents cboReplace As System.Windows.Forms.ComboBox
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents btnFindAll As System.Windows.Forms.Button
    Friend WithEvents btnReplaceAll As System.Windows.Forms.Button
    Friend WithEvents btnReplaceNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents optAllLevels As System.Windows.Forms.RadioButton
    Friend WithEvents optCurLayer As System.Windows.Forms.RadioButton
    Friend WithEvents optCurLevel As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.cboReplace = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnFindNext = New System.Windows.Forms.Button
        Me.btnFindAll = New System.Windows.Forms.Button
        Me.btnReplaceAll = New System.Windows.Forms.Button
        Me.btnReplaceNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optAllLevels = New System.Windows.Forms.RadioButton
        Me.optCurLayer = New System.Windows.Forms.RadioButton
        Me.optCurLevel = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0

        '
        'cboFind
        '
        Me.cboFind.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFind.IntegralHeight = False
        Me.cboFind.ItemHeight = 13
        Me.cboFind.Location = New System.Drawing.Point(80, 8)
        Me.cboFind.MaxDropDownItems = 12
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(208, 19)
        Me.cboFind.TabIndex = 1
        '
        'cboReplace
        '
        Me.cboReplace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboReplace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReplace.IntegralHeight = False
        Me.cboReplace.ItemHeight = 13
        Me.cboReplace.Location = New System.Drawing.Point(80, 32)
        Me.cboReplace.MaxDropDownItems = 12
        Me.cboReplace.Name = "cboReplace"
        Me.cboReplace.Size = New System.Drawing.Size(208, 19)
        Me.cboReplace.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2

        '
        'btnFindNext
        '
        Me.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnFindNext.Location = New System.Drawing.Point(296, 8)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(76, 20)
        Me.btnFindNext.TabIndex = 6

        '
        'btnFindAll
        '
        Me.btnFindAll.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnFindAll.Location = New System.Drawing.Point(296, 32)
        Me.btnFindAll.Name = "btnFindAll"
        Me.btnFindAll.Size = New System.Drawing.Size(76, 20)
        Me.btnFindAll.TabIndex = 7

        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnReplaceAll.Location = New System.Drawing.Point(296, 84)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(76, 20)
        Me.btnReplaceAll.TabIndex = 9

        '
        'btnReplaceNext
        '
        Me.btnReplaceNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnReplaceNext.Location = New System.Drawing.Point(296, 60)
        Me.btnReplaceNext.Name = "btnReplaceNext"
        Me.btnReplaceNext.Size = New System.Drawing.Size(76, 20)
        Me.btnReplaceNext.TabIndex = 8

        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnCancel.Location = New System.Drawing.Point(296, 112)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 20)
        Me.btnCancel.TabIndex = 10

        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.optAllLevels, Me.optCurLayer, Me.optCurLevel})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(148, 76)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False

        '
        'optAllLevels
        '
        Me.optAllLevels.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optAllLevels.Location = New System.Drawing.Point(8, 20)
        Me.optAllLevels.Name = "optAllLevels"
        Me.optAllLevels.Size = New System.Drawing.Size(116, 16)
        Me.optAllLevels.TabIndex = 0

        '
        'optCurLayer
        '
        Me.optCurLayer.Checked = True
        Me.optCurLayer.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optCurLayer.Location = New System.Drawing.Point(8, 52)
        Me.optCurLayer.Name = "optCurLayer"
        Me.optCurLayer.Size = New System.Drawing.Size(116, 16)
        Me.optCurLayer.TabIndex = 2
        Me.optCurLayer.TabStop = True

        '
        'optCurLevel
        '
        Me.optCurLevel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.optCurLevel.Location = New System.Drawing.Point(8, 36)
        Me.optCurLevel.Name = "optCurLevel"
        Me.optCurLevel.Size = New System.Drawing.Size(116, 16)
        Me.optCurLevel.TabIndex = 1

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(160, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(128, 76)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False

        '
        'ListBox1
        '
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Items.AddRange(New Object() {GetString("findRepl_AnyGroup"), GetString("findRepl_NoGroup"), "——————————————————————————————————————", GetString("findRepl_UngroupedTiles")})
        Me.ListBox1.Location = New System.Drawing.Point(4, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox1.Size = New System.Drawing.Size(120, 56)
        Me.ListBox1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(12, 12)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'psfrmFindReplaceTiles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(382, 140)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1, Me.btnCancel, Me.btnReplaceAll, Me.btnReplaceNext, Me.btnFindAll, Me.btnFindNext, Me.cboReplace, Me.Label2, Me.cboFind, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmFindReplaceTiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub psfrmFindReplaceTiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j As Integer
        With cboFind
            .Items.Add(GetString("findRepl_AllTiles"))
            For i = 1 To Game.tileset.NumTiles
                ImageList1.Images.Add(Game.Drawing.Tex(Game.tileset.tiles(i).name).preview) 'Editor.pstileselect.iml.Images(i - 1))
                .Items.Add(Game.tileset.tiles(i).name)
                MeasureItem(cboFind, Nothing, New MeasureItemEventArgs(cboFind.CreateGraphics, i - 1))
            Next
            .SelectedIndex = 0
        End With
        With cboReplace
            .Items.Add(GetString("findRepl_DoNotReplace"))
            For i = 1 To Game.tileset.NumTiles
                .Items.Add(Game.tileset.tiles(i).name)
                MeasureItem(cboReplace, Nothing, New MeasureItemEventArgs(cboReplace.CreateGraphics, i - 1))
            Next
            .SelectedIndex = 0
        End With
        With ListBox1
            Dim AllGroups As New ArrayList
            For i = 1 To Game.numMaps
                Dim tmpGroups() As String = ListGroups(i)
                For j = 1 To UBound(tmpGroups)
                    If Not AllGroups.Contains(tmpGroups(j)) Then
                        AllGroups.Add(tmpGroups(j))
                    End If
                Next
            Next
            AllGroups.Sort()
            .Items.AddRange(AllGroups.ToArray)
            .SetSelected(0, True)
        End With
    End Sub

    Sub MeasureItem(ByVal obj As ComboBox, ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs)
        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable and it always fires before the DrawItem event.

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return

        'The string that will appear in the current item and that I will use to measure when determining the height and width variable.
        Dim str As String = cboFind.Items(e.Index)
        'The string stripped of the newline character
        Dim strOneLine As String = Join(Split(str, Environment.NewLine), "")

        'for the item height, use the maximum of the image height or the string height and add 10%.
        Dim hgt As Single = Math.Max(ImageList1.ImageSize.Height, e.Graphics.MeasureString(str, obj.Font).Height) * 1.1
        e.ItemHeight = hgt

        'if I'm using dropdownstyle = dropdownlist, I want the text area at the top of the combobox to be tall enough for the image and text together, so I set the combo box itemheight property to the hgt value. When I use Simple or DropDown with OwnerDrawVariable, I want the text area at the top of the combobox to shrink back to a height that accommodates one line of text.
        If Me.cboFind.DropDownStyle = ComboBoxStyle.DropDownList Then
            obj.ItemHeight = hgt
        Else
            obj.ItemHeight = e.Graphics.MeasureString(strOneLine, obj.Font).Height * 1.1
        End If

        'in our example, the width of the combo box item does not need to be calculated because the width of the combo box is suuficient for all of the items we're working with
        e.ItemWidth = obj.Width
    End Sub

    Private Sub cboFind_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles cboFind.MeasureItem
        MeasureItem(cboFind, sender, e)
    End Sub

    Private Sub cboReplace_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles cboReplace.MeasureItem
        MeasureItem(cboReplace, sender, e)
    End Sub

    Sub DrawItem(ByVal obj As ComboBox, ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable or OwnerDrawFixed

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return
        'a string variable to hold the text that I will draw
        Dim str As String = obj.Items(e.Index)
        ' a graphic variable to minimize my typing :)
        Dim g As Graphics = e.Graphics
        'a couple of brush objects I'll need for filling rectangles
        Dim bBlue As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
        Dim bWhite As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Window))
        Dim bBlack As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.WindowText))

        'Adjust the value of Combobox.itemheight if the drawmode is ownerdrawfixed because the Measureitem event won't fire for that mode! This is necessary because the drawmode in this sample can be changed at runtime.
        Dim hgt As Single
        If obj.DrawMode = DrawMode.OwnerDrawFixed Then
            hgt = Math.Max(ImageList1.ImageSize.Height, e.Graphics.MeasureString(str, obj.Font).Height) * 1.1
            obj.ItemHeight = hgt
        End If

        'Determine if I'm highlighting the current combo box item because 
        'I want the selected item to look different from those that are not selected.
        Dim bHighlightItem As Boolean = Me.ShouldIHighlight(obj, e.State)

        If bHighlightItem = True Then
            'fill the background of the item
            g.FillRectangle(bBlue, e.Bounds)
            'draw the image from the image list control, offset it by 5 pixels and makes sure it's centered vertically
            If e.Index > 0 Then
                Dim myImage As Image = CType(ImageList1.Images(e.Index - 1), Image)
                g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            End If
            'draw the text, position it so that it starts 5 pixels to the right of the image
            g.DrawString(str, obj.Font, bWhite, e.Bounds.Left + ImageList1.ImageSize.Width + 5, e.Bounds.Top)
        Else
            'this block does the same thing as above but uses different colors to represent the different state.
            g.FillRectangle(bWhite, e.Bounds)
            If e.Index > 0 Then
                Dim myImage As Image = CType(ImageList1.Images(e.Index - 1), Image)
                g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            End If
            g.DrawString(str, obj.Font, bBlack, e.Bounds.Left + ImageList1.ImageSize.Width + 5, e.Bounds.Top)
        End If
        'Dispose of my brushes
        bBlue.Dispose()
        bWhite.Dispose()
        bBlue = Nothing
        bWhite = Nothing
    End Sub

    Private Sub cboFind_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboFind.DrawItem
        DrawItem(cboFind, sender, e)
    End Sub

    Private Sub cboReplace_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboReplace.DrawItem
        DrawItem(cboReplace, sender, e)
    End Sub

    Private Function ShouldIHighlight(ByVal obj As ComboBox, ByVal State As DrawItemState) As Boolean
        'Note: The following IF statement is more complicated than what you would use in an actual project. This is necessary because I am testing for the dropdownstyle of the combobox during runtime. In a real project you probably would not let the user change that value at runtime.
        ' To accomplish this, I also have to check the OS version (because each generates different drawitemstate values). I will check for Win2K or XP.
        If (obj.DropDownStyle = ComboBoxStyle.Simple And State = (DrawItemState.Selected Or DrawItemState.NoFocusRect Or DrawItemState.NoAccelerator)) _
        Or (obj.DropDownStyle = ComboBoxStyle.DropDown And State = (DrawItemState.Selected Or DrawItemState.NoFocusRect Or DrawItemState.NoAccelerator)) _
        Or (obj.DropDownStyle = ComboBoxStyle.DropDownList And State = (DrawItemState.Selected Or DrawItemState.Focus Or DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect)) _
        Or (obj.DropDownStyle = ComboBoxStyle.Simple And State = DrawItemState.Selected) Then

            Return True
        End If

    End Function

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.GetSelected(2) = True Then
            ListBox1.SetSelected(2, False)
        End If
        If ListBox1.GetSelected(0) = True Then
            ListBox1.ClearSelected()
            Dim i As Integer
            For i = 3 To ListBox1.Items.Count - 1
                ListBox1.SetSelected(i, True)
            Next
        ElseIf ListBox1.GetSelected(1) = True Then
            ListBox1.ClearSelected()
        End If
        btnFindNext.Enabled = (ListBox1.SelectedIndices.Count > 0)
        btnFindAll.Enabled = (ListBox1.SelectedIndices.Count > 0 And optCurLayer.Checked = True)
        btnReplaceNext.Enabled = (ListBox1.SelectedIndices.Count > 0 And cboReplace.SelectedIndex > 0)
        btnReplaceAll.Enabled = (ListBox1.SelectedIndices.Count > 0 And cboReplace.SelectedIndex > 0)
        ll = 0 'Search from the beginning again
    End Sub

    Private Sub cboReplace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReplace.SelectedIndexChanged
        btnReplaceNext.Enabled = (ListBox1.SelectedIndices.Count > 0 And cboReplace.SelectedIndex > 0)
        btnReplaceAll.Enabled = (ListBox1.SelectedIndices.Count > 0 And cboReplace.SelectedIndex > 0)
        ll = 0 'Search from the beginning again
    End Sub

    Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
        If ListBox1.GetSelected(2) = True Then
            ListBox1.SetSelected(2, False)
        End If
    End Sub

    Private Sub optCurLayer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCurLayer.CheckedChanged
        btnFindAll.Enabled = (ListBox1.SelectedIndices.Count > 0 And optCurLayer.Checked = True)
        ll = 0 'Search from the beginning againbtnFindAll.Enabled = (ListBox1.SelectedIndices.Count > 0 And optCurLayer.Checked = True)
    End Sub

    Dim ll As Integer, mm As Integer, nn As Integer
    Sub DoFind(ByVal FindNext As Boolean, ByVal Replace As Boolean)
        Editor.pstools.Value = 2
        Editor.psedit.Deselect()

        Dim b As Boolean, m As Integer, n As Long, o As Integer
        Dim StartM As Integer
        Dim InGroup As Boolean
        Dim FoundNothing As Boolean

        Dim lStart As Short, lEnd As Short
        If optAllLevels.Checked Then
            lStart = 1
            lEnd = Game.maps.GetUpperBound(0)
        Else
            lStart = Game.CurMapIndex
            lEnd = Game.CurMapIndex
        End If

Top:

        Dim CurMap As Integer
        Dim FindCount As Integer
        Dim SelLevel As Integer, SelLayer As Integer

        'Loop through all objects in this level
        For CurMap = lStart To lEnd
            For m = 0 To 3
                For n = 1 To Game.maps(CurMap).MapSize1D

                    'Resume original search
                    If ll > 0 And b = False Then
                        CurMap = ll
                        m = mm
                        n = nn + 1
                        If m = 0 Or FindNext = False Then
                            m = 1
                            n = 0
                            FoundNothing = True
                        End If
                    End If
                    b = True

                    'Make sure it's in the right layer
                    If optCurLayer.Checked = True Then
                        If m <> psMap.CurLayer Then GoTo NextM
                    End If

                    With Game.maps(CurMap).Cells1D2(n, m)

                        'Make sure it's in the right group
                        InGroup = False
                        For o = 3 To ListBox1.Items.Count - 1
                            If ListBox1.GetSelected(o) Then
                                If .Group = ListBox1.Items(o) Or (.Group = "" And o = 3) Then
                                    InGroup = True
                                    Exit For
                                End If
                            End If
                        Next

                        'Found it
                        If .tile > 0 Then
                            If InGroup And ((cboFind.SelectedIndex = 0) Or (.TileName = cboFind.Text)) Then

                                'Select the right level
                                Editor.pslevelsel.Value = CurMap

                                'Select the right layer
                                If Not (Editor.pslayersel Is Nothing) Then
                                    Editor.pslayersel.SetCurLayer(m)
                                Else
                                    psMap.CurLayer = m
                                End If
                                If Replace = True And FindNext = False And FindCount > 0 And (m <> SelLayer Or CurMap <> SelLevel) Then
                                    Editor.psedit.Deselect()
                                End If

                                'Make a new selection
                                If FindNext = False Then
                                    ReDim Preserve Editor.psedit.seltiles(Editor.psedit.seltiles.GetUpperBound(0) + 1)
                                ElseIf Editor.psedit.seltiles.GetUpperBound(0) = 0 Then
                                    Editor.psedit.Deselect()
                                    ReDim Editor.psedit.seltiles(1)
                                End If
                                psEditor.selecting = False

                                With Editor.psedit.seltiles(Editor.psedit.seltiles.GetUpperBound(0))

                                    'Select the tile
                                    .tile = Game.maps(CurMap).Cells1D2(n, m)
                                    .x = Game.maps(CurMap).Conv1DTo2D(n).X
                                    .y = Game.maps(CurMap).Conv1DTo2D(n).Y
                                    Game.maps(CurMap).Cells1D2(n, m) = New psMapTile

                                    'Set camera                        
                                    Editor.psedit.hs.Value = MakeInRange(.x * Game.tileW + Game.tileW * 0.5 - Game.cam.w * 0.5, 0, Editor.psedit.hs.Maximum)
                                    Editor.psedit.vs.Value = MakeInRange(.y * Game.tileH + Game.tileH * 0.5 - Game.cam.h * 0.5, 0, Editor.psedit.vs.Maximum)
                                    Game.cam.X = Editor.psedit.hs.Value
                                    Game.cam.Y = Editor.psedit.vs.Value

                                    'Replace the tile
                                    If Replace Then
                                        If FindCount = 0 Then
                                            If FindNext = False Then
                                                UndoRedo.UpdateUndo(GetString("undoActionReplaceAll"), UndoRedo.UndoType.AllLevels)
                                            Else
                                                UndoRedo.UpdateUndo(GetString("undoActionReplace"), UndoRedo.UndoType.Layer, CurMap, m)
                                            End If
                                        End If
                                        .tile.tile = cboReplace.SelectedIndex
                                        SelLevel = CurMap
                                        SelLayer = m
                                    End If

                                    FindCount += 1
                                End With

                                FoundNothing = False
                                StartM = m
                                If FindNext Then
                                    'All done
                                    GoTo EndSub
                                End If

                            End If
                        End If

                    End With

                Next
NextM:
            Next
        Next
        GoTo FindFinished
EndSub:
        ll = CurMap
        mm = m
        nn = n
        GoTo End_Sub
FindFinished:
        m = 1
        n = 0
        If FoundNothing Then
            MessageBox.Show(GetString("findRepl_NoTilesFoundMessage"), GetString("findRepl_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            GoTo End_Sub
        End If
        If FindNext = False Then
            ll = 0
            mm = 0
            nn = 0
            FoundNothing = True
            If Replace = False Then
                MessageBox.Show(String.Format(GetString("findRepl_TilesFoundMessage"), Editor.psedit.seltiles.GetUpperBound(0)), GetString("findRepl_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(String.Format(GetString("findRepl_TilesReplacedMessage"), FindCount), GetString("findRepl_Title"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            GoTo End_Sub
        End If
        If MessageBox.Show(GetString("findRepl_AllTilesFoundMessage"), GetString("findRepl_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            ll = 0
            mm = 0
            nn = 0
            FoundNothing = True
            GoTo End_Sub
        Else
            FoundNothing = True
            GoTo Top
        End If
        GoTo End_Sub
End_Sub:
    End Sub

    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        DoFind(True, False)
    End Sub

    Private Sub btnFindAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAll.Click
        DoFind(False, False)
    End Sub

    Private Sub btnReplaceNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceNext.Click
        DoFind(True, True)
    End Sub

    Private Sub btnReplaceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceAll.Click
        DoFind(False, True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub optAllLevels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAllLevels.CheckedChanged
        ll = 0 'Search from the beginning again
    End Sub

    Private Sub optCurLevel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCurLevel.CheckedChanged
        ll = 0 'Search from the beginning again
    End Sub

    Private Sub cboFind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFind.SelectedIndexChanged
        ll = 0 'Search from the beginning again
    End Sub
End Class