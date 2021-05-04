Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Public Class psfrmTileset
    Inherits System.Windows.Forms.Form

    'Dim StartTime As Single, Frame As Integer
    Dim tmpTileset As psTileset

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("tileset_ImagesLabel")
        Me.Button2.Text = GetString("tileset_DoneButton")
        Me.Button6.Text = GetString("tileset_AddTileButton")
        Me.Button7.Text = GetString("tileset_RemoveTileButton")
        Me.dlgOpen.Filter = GetString("imageFileFilter")
        Me.Button10.Text = GetString("tileset_SetAsDefaultButton")
        Me.Button12.Text = GetString("tileset_ClearTilesetButton")
        Me.Button14.Text = GetString("tileset_ExportTilesetButton")
        Me.Button15.Text = GetString("tileset_ImportTilesetButton")
        Me.dlgExport.Filter = GetString("tilesetFileFilter")
        Me.dlgImport.Filter = GetString("tilesetFileFilter")
        Me.Button17.Text = GetString("tileset_ReplaceTilesetButton")
        Me.Label2.Text = GetString("tileset_PropertiesLabel")
        Me.Label12.Text = GetString("tileset_GridHeightLabel")
        Me.Label11.Text = GetString("tileset_GridWidthLabel")
        Me.btnAdd.Text = GetString("tileset_AddIconText")
        Me.btnAdd.ToolTipText = GetString("tileset_AddIconTooltip")
        Me.btnRemove.Text = GetString("tileset_RemoveIconText")
        Me.btnRemove.ToolTipText = GetString("tileset_RemoveIconTooltip")
        Me.btnClear.Text = GetString("tileset_ClearIconText")
        Me.btnClear.ToolTipText = GetString("tileset_ClearIconTooltip")
        Me.btnEdit.Text = GetString("tileset_EditIconText")
        Me.btnEdit.ToolTipText = GetString("tileset_EditIconTooltip")
        Me.btnMoveUp.ToolTipText = GetString("tileset_MoveUpIconTooltip")
        Me.btnMoveDown.ToolTipText = GetString("tileset_MoveDownIconTooltip")
        Me.btnOpen.Text = GetString("tileset_OpenIconText")
        Me.btnOpen.ToolTipText = GetString("tileset_OpenIconTooltip")
        Me.btnImport.Text = GetString("tileset_ImportIconText")
        Me.btnImport.ToolTipText = GetString("tileset_ImportIconTooltip")
        Me.btnExport.Text = GetString("tileset_ExportIconText")
        Me.btnExport.ToolTipText = GetString("tileset_ExportIconTooltip")
        Me.Text = GetString("tileset_Title")
        Me.list.BackColor1 = SystemColors.Window
        Me.list.BackColor2 = SystemColors.Window
        Me.list.Init(psTileSelector.SelectorType.Tile2)
        Me.list.CanMultiselect = True
        Me.list.CanDragDrop = True
        Me.list.DrawCustomIcons = True
        AddHandler DirectCast(list.Internal, TileList2).ChangedSelPos, AddressOf OnChangedSelPos
        UpdateStartTimesAndFrames()
        BackColor = UIPlus.DefaultColorScheme.getInstance.MenuBack

        Dim tt As New ToolTip()
        tt.SetToolTip(Me.btnReload, "Reload All Images")
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents tmrRender As System.Windows.Forms.Timer
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents dlgExport As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgImport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents list As psTileSelector
    Friend WithEvents propgrid As psControlProperties.FlatPropGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tb As UIPlus.UIPlusToolbar
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRemove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveUp As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveDown As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnOpen As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImport As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnExport As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnClear As System.Windows.Forms.ToolBarButton
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(psfrmTileset))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.propgrid = New Global.psEditor.psControlProperties.FlatPropGrid()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.tmrRender = New System.Windows.Forms.Timer(Me.components)
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.dlgExport = New System.Windows.Forms.SaveFileDialog()
        Me.dlgImport = New System.Windows.Forms.OpenFileDialog()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.list = New Global.psEditor.psTileSelector()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.tb = New UIPlus.UIPlusToolbar()
        Me.btnAdd = New System.Windows.Forms.ToolBarButton()
        Me.btnRemove = New System.Windows.Forms.ToolBarButton()
        Me.btnClear = New System.Windows.Forms.ToolBarButton()
        Me.btnEdit = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.btnMoveUp = New System.Windows.Forms.ToolBarButton()
        Me.btnMoveDown = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
        Me.btnOpen = New System.Windows.Forms.ToolBarButton()
        Me.btnImport = New System.Windows.Forms.ToolBarButton()
        Me.btnExport = New System.Windows.Forms.ToolBarButton()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.btnReload = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 0
        '
        'propgrid
        '
        Me.propgrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propgrid.CommandsActiveLinkColor = System.Drawing.SystemColors.ActiveCaption
        Me.propgrid.CommandsDisabledLinkColor = System.Drawing.SystemColors.ControlDark
        Me.propgrid.CommandsLinkColor = System.Drawing.SystemColors.ActiveCaption
        Me.propgrid.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.propgrid.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.propgrid.Location = New System.Drawing.Point(8, 24)
        Me.propgrid.Name = "propgrid"
        Me.propgrid.Size = New System.Drawing.Size(230, 317)
        Me.propgrid.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(422, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 24)
        Me.Button2.TabIndex = 14
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Enabled = False
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(200, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 32)
        Me.Button4.TabIndex = 4
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(200, 64)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 32)
        Me.Button5.TabIndex = 5
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(10, 319)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(84, 24)
        Me.Button6.TabIndex = 2
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(106, 319)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(84, 24)
        Me.Button7.TabIndex = 3
        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = "untitled1"
        Me.dlgOpen.Multiselect = True
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        '
        'tmrRender
        '
        Me.tmrRender.Enabled = True
        Me.tmrRender.Interval = 1
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button10.Location = New System.Drawing.Point(110, 64)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(88, 24)
        Me.Button10.TabIndex = 13
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(206, 64)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(64, 24)
        Me.Button12.TabIndex = 12
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.Location = New System.Drawing.Point(278, 64)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(64, 24)
        Me.Button14.TabIndex = 11
        '
        'Button15
        '
        Me.Button15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button15.Location = New System.Drawing.Point(350, 64)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(64, 24)
        Me.Button15.TabIndex = 10
        '
        'Button17
        '
        Me.Button17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button17.Location = New System.Drawing.Point(38, 64)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(64, 24)
        Me.Button17.TabIndex = 15
        '
        'list
        '
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.list.Location = New System.Drawing.Point(9, 25)
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(182, 285)
        Me.list.TabIndex = 16
        Me.list.Value = 0
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(8, 24)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(184, 287)
        Me.TextBox3.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReload)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.list)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 349)
        Me.Panel1.TabIndex = 18
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.propgrid)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(240, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 349)
        Me.Panel2.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Button10)
        Me.Panel3.Controls.Add(Me.Button12)
        Me.Panel3.Controls.Add(Me.Button14)
        Me.Panel3.Controls.Add(Me.Button15)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button17)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 375)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(488, 36)
        Me.Panel3.TabIndex = 18
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(176, 8)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(56, 20)
        Me.TextBox2.TabIndex = 19
        Me.TextBox2.Text = "32"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(136, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 16)
        Me.Label12.TabIndex = 18
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(64, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(56, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Text = "32"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 16)
        Me.Label11.TabIndex = 16
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(240, 26)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(8, 349)
        Me.Splitter1.TabIndex = 20
        Me.Splitter1.TabStop = False
        '
        'tb
        '
        Me.tb.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tb.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAdd, Me.btnRemove, Me.btnClear, Me.btnEdit, Me.ToolBarButton3, Me.btnMoveUp, Me.btnMoveDown, Me.ToolBarButton7, Me.btnOpen, Me.btnImport, Me.btnExport})
        Me.tb.CustomColorScheme = Nothing
        Me.tb.Divider = False
        Me.tb.DropDownArrows = True
        Me.tb.ImageList = Me.iml
        Me.tb.Location = New System.Drawing.Point(0, 0)
        Me.tb.Name = "tb"
        Me.tb.ShowToolTips = True
        Me.tb.Size = New System.Drawing.Size(488, 26)
        Me.tb.TabIndex = 21
        Me.tb.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'btnAdd
        '
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.Name = "btnAdd"
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.ImageIndex = 1
        Me.btnRemove.Name = "btnRemove"
        '
        'btnClear
        '
        Me.btnClear.ImageIndex = 7
        Me.btnClear.Name = "btnClear"
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.ImageIndex = 8
        Me.btnEdit.Name = "btnEdit"
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Name = "ToolBarButton3"
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Enabled = False
        Me.btnMoveUp.ImageIndex = 2
        Me.btnMoveUp.Name = "btnMoveUp"
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Enabled = False
        Me.btnMoveDown.ImageIndex = 3
        Me.btnMoveDown.Name = "btnMoveDown"
        '
        'ToolBarButton7
        '
        Me.ToolBarButton7.Name = "ToolBarButton7"
        Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnOpen
        '
        Me.btnOpen.ImageIndex = 4
        Me.btnOpen.Name = "btnOpen"
        '
        'btnImport
        '
        Me.btnImport.ImageIndex = 5
        Me.btnImport.Name = "btnImport"
        '
        'btnExport
        '
        Me.btnExport.ImageIndex = 6
        Me.btnExport.Name = "btnExport"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        Me.iml.Images.SetKeyName(0, "")
        Me.iml.Images.SetKeyName(1, "")
        Me.iml.Images.SetKeyName(2, "")
        Me.iml.Images.SetKeyName(3, "")
        Me.iml.Images.SetKeyName(4, "")
        Me.iml.Images.SetKeyName(5, "")
        Me.iml.Images.SetKeyName(6, "")
        Me.iml.Images.SetKeyName(7, "")
        Me.iml.Images.SetKeyName(8, "")
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReload.Enabled = True
        Me.btnReload.Image = CType(resources.GetObject("btnReload.Image"), System.Drawing.Image)
        Me.btnReload.Location = New System.Drawing.Point(200, 104)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(32, 32)
        Me.btnReload.TabIndex = 17
        '
        'psfrmTileset
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 411)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmTileset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Tile limit in Standard Edition
        If Not (Game.ReachedMaxTile Is Nothing) AndAlso Game.ReachedMaxTile.DynamicInvoke(Nothing) = True Then Exit Sub

        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        'Drawing.LoadImage(dlgOpen.FileName, "Image" & list.Items.Count + 1)
        Dim i As Integer, tmpTex As psDraw.TexPool.TexPoolItem
        Dim NewTile As psTile
        For i = 0 To UBound(dlgOpen.FileNames)

            'Tile limit in Standard Edition
            If Not (Game.ReachedMaxTile Is Nothing) AndAlso Game.ReachedMaxTile.DynamicInvoke(Nothing) = True Then Exit Sub

            'Get the name of the tile
            Dim tmpName As String = GetFilename(dlgOpen.FileNames(i))
            Dim Suffix As String = ""
            For j As Integer = tmpName.Length - 1 To 0 Step -1
                If tmpName.Chars(j) = "." Then
                    tmpName = tmpName.Substring(0, j)
                End If
            Next
            While Game.Drawing.Tex.ContainsKey(tmpName & Suffix)
                If Suffix = "" Then
                    Suffix = 2
                Else
                    Suffix += 1
                End If
            End While
            tmpName &= Suffix

            Dim numTiles As Integer = Game.tileset.NumTiles
            Try
                NewTile = New psTile(dlgOpen.FileNames(i), tmpName)
                Game.Drawing.AutoGetBits = True
                Game.tileset.AddTile(NewTile)
                Game.Drawing.AutoGetBits = False
                With Game.tileset
                    If .NumTiles > 1 Then
                        .tileColorKey(.NumTiles) = .tileColorKey(.NumTiles - 1)
                    Else
                        .tileColorKey(.NumTiles) = Color.Transparent.ToArgb
                    End If
                    tmpTex = Game.Drawing.Tex(.tileName(.NumTiles))
                    If tmpTex.width / Game.tileW = Int(tmpTex.width / Game.tileW) Then
                        .tileWidth(.NumTiles) = tmpTex.width
                        .tileSecW(.NumTiles) = Game.tileW
                    Else
                        .tileSecW(.NumTiles) = .tileWidth(.NumTiles)
                    End If
                    If tmpTex.height / Game.tileH = Int(tmpTex.height / Game.tileH) Then
                        .tileHeight(.NumTiles) = tmpTex.height
                        .tileSecH(.NumTiles) = Game.tileH
                    Else
                        .tileSecH(.NumTiles) = .tileHeight(.NumTiles)
                    End If
                End With
                'iml.Images.Add(New Bitmap(Game.tileset.tiles(Game.tileset.NumTiles).filename))
                'list.Items.Add(tmpName, list.Items.Count)
            Catch
                Game.Drawing.AutoGetBits = False
                If Game.tileset.NumTiles > numTiles Then Game.tileset.RemoveTile(Game.tileset.NumTiles)
                MessageBox.Show(String.Format(GetString("tileset_LoadImageErrorMessage"), IO.Path.GetFileName(dlgOpen.FileNames(i))), GetString("tileset_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
        'UpdateImages()
        list.SelectSingleItem(Game.tileset.NumTiles)
        'list.Items(list.SelectedIndices(0)).EnsureVisible()
        list.Select()
        Editor.pstileselect.UpdateList()
        UpdateStartTimesAndFrames()
    End Sub

    'Sub UpdateImages()
    '    Dim i As Integer
    '    With iml
    '        .Images.Clear()
    '        For i = 1 To Game.tileset.NumTiles
    '            .Images.Add(Game.tileset.tilePreview(i))
    '        Next
    '    End With
    'End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        tmrRender.Enabled = False

        Dim i As Integer, j As Integer, k As Integer

        'Delete the tiles on the maps
        Dim NumTiles As Integer
        For i = 1 To Game.numMaps
            With Game.maps(i)
                For j = 0 To 3
                    For k = 1 To .MapSize1D
                        If .Cells1D(k, j) = list.Value Then
                            NumTiles += 1
                        End If
                    Next
                Next
            End With
        Next
        If NumTiles > 0 Then
            If MessageBox.Show(String.Format(GetString("tileset_DeleteWarningMessage"), NumTiles), GetString("tileset_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If
        For i = 1 To Game.numMaps
            With Game.maps(i)
                For j = 0 To 3
                    For k = 1 To .MapSize1D
                        If .Cells1D(k, j) = list.Value Then
                            .Cells1D2(k, j) = New psMapTile
                        ElseIf .Cells1D(k, j) > list.Value Then
                            .Cells1D(k, j) -= 1
                        End If
                    Next
                Next
            End With
        Next

        'First delete the actions
        With Game.actions
            For i = 1 To .Actions.GetUpperBound(0)
                If .Actions(i).Trigger.Chars(0) = "t" AndAlso .Actions(i).Trigger.Substring(4) = list.Value Then
                    If MessageBox.Show(GetString("tileset_DeleteActionsWarningMessage"), GetString("tileset_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If
            Next
            For i = 1 To .Actions.GetUpperBound(0)
                If i > .Actions.GetUpperBound(0) Then Exit For
                If .Actions(i).Trigger.Chars(0) = "t" AndAlso .Actions(i).Trigger.Substring(4) = list.Value Then
                    For j = i To .Actions.GetUpperBound(0) - 1
                        .Actions(j) = .Actions(j + 1)
                    Next
                    ReDim Preserve .Actions(.Actions.GetUpperBound(0) - 1)
                    i = i - 1
                ElseIf .Actions(i).Trigger.Chars(0) = "t" AndAlso .Actions(i).Trigger.Substring(4) > list.Value Then
                    .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & (CInt(.Actions(i).Trigger.Substring(4)) - 1)
                End If
            Next
        End With

        Game.tileset.RemoveTile(list.Value)
        Dim tmp As Integer = list.Value
        'iml.Images.RemoveAt(list.SelectedIndices(0))
        'list.Items.Remove(list.SelectedItems(0))
        'For i = 0 To list.Items.Count - 1
        '    list.Items(i).ImageIndex = i
        'Next
        If tmp > Game.tileset.NumTiles Then tmp = Game.tileset.NumTiles
        If tmp >= 0 Then
            list.SelectSingleItem(tmp)
        End If
        tmrRender.Enabled = True
        Editor.pstileselect.UpdateList()
        UpdateStartTimesAndFrames()
    End Sub

    Private Sub list_SelectedIndexChanged() Handles list.SelectedIndexChanged
        If list.Value <= 0 Then
            Button7.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            btnEdit.Enabled = False
            btnRemove.Enabled = False
            btnMoveUp.Enabled = False
            btnMoveDown.Enabled = False
            propgrid.SelectedObjects = Nothing
            'picPreview.Image = Nothing
            Exit Sub
        End If
        Button7.Enabled = (list.SelIndices.Count = 1)
        Button4.Enabled = (Value > 1) AndAlso list.SelIndices.Count = 1
        Button5.Enabled = (Value < Game.tileset.NumTiles) AndAlso list.SelIndices.Count = 1
        btnEdit.Enabled = Button7.Enabled
        btnRemove.Enabled = Button7.Enabled
        btnMoveUp.Enabled = Button4.Enabled
        btnMoveDown.Enabled = Button5.Enabled

        Dim curTile As psTile
        curTile = Game.tileset.tiles(Value)

        'Initialize fields
        'picPreview.Image = New Bitmap(curTile.filename) ' iml.Images(list.Items(list.SelectedIndices(0)).ImageIndex)

        DynamicReadOnly.SetValue("TilesetEditor", list.SelIndices.Count <> 1)

        'Update PropertyGrid
        Dim w(list.SelIndices.Count - 1) As PropDispNameWrapper
        For i As Integer = 0 To list.SelIndices.Count - 1
            w(i) = New PropDispNameWrapper(New TileWrapper(list.SelIndices(i)))
        Next
        propgrid.SelectedObjects = w
    End Sub

    Private Sub frmTileset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        tmpTileset = Game.tileset
        With Game
            TextBox1.Text = .tileW
            TextBox2.Text = .tileH
        End With
        'UpdateList()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MoveTile(-1)
    End Sub

    Sub MoveTile(ByVal Direction As Integer)
        Dim i As Integer, j As Integer, k As Integer

        'Move the actions
        With Game.actions
            For i = 1 To .Actions.GetUpperBound(0)
                If .Actions(i).Trigger.Chars(0) = "t" AndAlso .Actions(i).Trigger.Substring(4) = list.Value Then
                    .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & (list.Value + Direction)
                ElseIf .Actions(i).Trigger.Chars(0) = "t" AndAlso .Actions(i).Trigger.Substring(4) = list.Value + Direction Then
                    .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & (list.Value)
                End If
            Next
        End With

        'Move the tile indices in the maps
        For i = 1 To Game.numMaps
            With Game.maps(i)
                For j = 0 To 3
                    For k = 1 To .MapSize1D
                        If .Cells1D(k, j) = list.Value Then
                            .Cells1D(k, j) = list.Value + Direction
                        ElseIf .Cells1D(k, j) = list.Value + Direction Then
                            .Cells1D(k, j) = list.Value
                        End If
                    Next
                Next
            End With
        Next

        'Dim tmpstr As String, tmpint As Integer
        'tmpstr = list.Items(list.SelectedIndices(0)).Text
        'tmpint = list.Items(list.SelectedIndices(0)).ImageIndex
        'list.Items(list.SelectedIndices(0)).Text = list.Items(list.SelectedIndices(0) + Direction).Text
        'list.Items(list.SelectedIndices(0)).ImageIndex = list.Items(list.SelectedIndices(0) + Direction).ImageIndex
        'list.Items(list.SelectedIndices(0) + Direction).Text = tmpstr
        'list.Items(list.SelectedIndices(0) + Direction).ImageIndex = tmpint
        Game.tileset.MoveTile(list.Value, Direction)
        list.SelectSingleItem(list.Value + Direction)
        'Try
        '    list.Items(list.SelectedIndices(0) + Direction).EnsureVisible()
        'Catch
        'End Try

        list.Select()
        list.Invalidate()
        UpdateStartTimesAndFrames()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MoveTile(1)
    End Sub

#Region "Tile Selector"
    'Sub UpdateList()
    '    Dim i As Integer, tmp As Integer

    '    'Store current item
    '    tmp = Value

    '    'Clear list and images
    '    list.Visible = False
    '    list.Items.Clear()
    '    iml.Images.Clear()

    '    'Reload
    '    UpdateImages()
    '    For i = 1 To Game.tileset.NumTiles
    '        'iml.Images.Add(New Bitmap(game.tileset.tiles(i).filename))
    '        list.Items.Add(Game.tileset.tiles(i).name, list.Items.Count)
    '    Next
    '    list.Visible = True

    '    'Reselect current item, or the first item
    '    If tmp >= 0 And tmp <= list.Items.Count - 1 Then
    '        list.Items(tmp).Selected = True
    '    Else
    '        If list.Items.Count > 0 Then list.Items(0).Selected = True
    '    End If
    '    list.Select()
    'End Sub

    ReadOnly Property Value() As Integer
        Get
            Return list.Value
        End Get
    End Property
#End Region

    ''AutoRedraw
    'Dim oImage As Image
    'Dim xg1 As Graphics

    'Sub Render()
    '    If Visible = False Then Exit Sub

    '    Static DidThis As Boolean

    '    If DidThis = False Then
    '        DidThis = True
    '        oImage = New Bitmap(picPreview.Width, picPreview.Height)
    '        xg1 = Graphics.FromImage(oImage)
    '        picPreview.Image = oImage
    '    End If

    '    With xg1
    '        .Clear(Color.FromArgb(0))
    '        If list.Value > 0 Then
    '            Dim bmp As Bitmap
    '            Try
    '                bmp = Game.tileset.tileBitmap(list.Value)
    '            Catch
    '                Exit Sub
    '            End Try
    '            If bmp Is Nothing Then Exit Sub
    '            .DrawImage(bmp, New Rectangle(0, 0, picPreview.Width, picPreview.Height), CurRect(Game.tileset.tiles(list.Value), 0, StartTime, Frame, False), System.Drawing.GraphicsUnit.Pixel)
    '        End If

    '        picPreview.Refresh()
    '    End With
    'End Sub
    'Private Sub tmrRender_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRender.Tick
    '    Render()
    'End Sub

    'Private Sub psfrmTileset_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    'If DialogResult = DialogResult.Cancel Then
    'Game.tileset = tmpTileset
    'Game.tileset.Load()
    'End If
    'End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Save the tileset
        Dim fh As New psFileHandler
        fh.SaveTileset(Game.Root & "deftileset.pst")
        fh = Nothing
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If MessageBox.Show(GetString("tileset_DeleteAllConfirmationMessage"), GetString("tileset_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Game.actions.SetDefaults()
            Cursor.Current = Cursors.WaitCursor
            Enabled = False
            While Game.tileset.NumTiles > 0
                Dim tmp As Integer = Game.tileset.NumTiles
                list.SelectSingleItem(1)
                Button7_Click(Nothing, Nothing)
                If Game.tileset.NumTiles = tmp Then Exit While 'User cancelled
            End While
            Enabled = True
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If dlgExport.ShowDialog() = DialogResult.Cancel Then Exit Sub
        psFile.SaveTileset(dlgExport.FileName)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If dlgImport.ShowDialog() = DialogResult.Cancel Then Exit Sub
        psFile.LoadTileset(dlgImport.FileName, True)
        frmTileset_Load(Nothing, Nothing)
        Editor.pstileselect.UpdateList()
        list.UpdateList()
        UpdateStartTimesAndFrames()
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        ConvertToNumber(TextBox1, 8, 128, Game.tileW)
        With Game
            .tileW = TextBox1.Text
        End With
    End Sub

    Private Sub TextBox2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        ConvertToNumber(TextBox2, 8, 128, Game.tileH)
        With Game
            .tileH = TextBox2.Text
        End With
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If dlgImport.ShowDialog() = DialogResult.Cancel Then Exit Sub
        If MessageBox.Show(GetString("tileset_ImportWarningMessage"), GetString("tileset_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        psFile.LoadTileset(dlgImport.FileName, , MessageBox.Show(GetString("tileset_ImportActionsMessage"), GetString("tileset_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
        For i As Integer = 1 To Game.numMaps
            For j As Integer = 0 To 3
                For k As Integer = 1 To Game.maps(i).MapSize1D
                    If Game.maps(i).Cells1D(k, j) > Game.tileset.NumTiles Then
                        Game.maps(i).Cells1D2(k, j) = New psMapTile
                    End If
                Next
            Next
        Next
        frmTileset_Load(Nothing, Nothing)
        Editor.pstileselect.UpdateList()
        list.UpdateList()
        UpdateStartTimesAndFrames()
    End Sub

    Private Sub OnChangedSelPos(ByVal rect As Rectangle)
        'picPreview.Location = New Point(rect.X + 1, rect.Y + 1)
        'picPreview.Visible = True
        'Render()
    End Sub

    Private StartTime() As Double, Frame() As Integer
    Friend Sub UpdateStartTimesAndFrames()
        ReDim Frame(Game.tileset.NumTiles), StartTime(Game.tileset.NumTiles)
        For i As Integer = 1 To Game.tileset.NumTiles
            Frame(i) = Game.tileset.tiles(i).Anim(0).StartFrame
            StartTime(i) = Microsoft.VisualBasic.Timer
        Next
    End Sub
    Private Sub list_DrawIcon(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal item As Integer, ByVal rect As System.Drawing.Rectangle) Handles list.DrawIcon
        With e.Graphics
            .DrawImage(Game.tileset.tileBitmap(item), New Rectangle(rect.X, rect.Y, rect.Width, rect.Height), ScaleRect(CurRect(Game.tileset.tiles(item), 0, StartTime(item), Frame(item), False), 1 / Game.tileset.tiles(item).ScaleX, 1 / Game.tileset.tiles(item).ScaleY), System.Drawing.GraphicsUnit.Pixel)
        End With
    End Sub

    Private Sub tmrRender_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRender.Tick
        list.Invalidate()
    End Sub

    Private Sub list_DraggedItem(ByVal item As Integer) Handles list.DraggedItem
        Dim amt As Integer = 0
        If item > list.Value Then
            amt = item - list.Value - 1
        ElseIf item < list.Value Then
            amt = item - list.Value
        End If
        For i As Integer = 1 To Math.Abs(amt)
            MoveTile(Math.Sign(amt))
        Next
    End Sub

    Private Sub tb_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tb.ButtonClick
        Select Case True
            Case e.Button Is btnAdd
                Button6_Click(sender, e)
            Case e.Button Is btnRemove
                Button7_Click(sender, e)
            Case e.Button Is btnEdit
                EditImage()
            Case e.Button Is btnClear
                Button12_Click(sender, e)
            Case e.Button Is btnMoveUp
                Button4_Click(sender, e)
            Case e.Button Is btnMoveDown
                Button5_Click(sender, e)
            Case e.Button Is btnOpen
                Button17_Click(sender, e)
            Case e.Button Is btnImport
                Button15_Click(sender, e)
            Case e.Button Is btnExport
                Button14_Click(sender, e)
        End Select
    End Sub

    Private Sub list_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles list.DoubleClick
        ShowActionsForSelectedTile()
    End Sub

    Public Sub ShowActionsForSelectedTile()
        If list.Value >= 1 AndAlso list.Value <= Game.tileset.NumTiles Then
            Dim f As New psfrmActionEditor
            f.AddTileNodes(f.tv.Nodes.Add(Game.tileset.tiles(list.Value).name), list.Value)
            f.ShowDialog(True)
            f.Dispose()
        End If
    End Sub

    Dim fsw() As IO.FileSystemWatcher = {}

    Sub EditImage()
        Dim filename As String = Game.Drawing.Tex(Game.tileset.tileName(Value)).filename

        ReDim fsw(fsw.Length)
        fsw(fsw.Length - 1) = New IO.FileSystemWatcher
        With fsw(fsw.Length - 1)
            AddHandler .Changed, AddressOf fsw_Changed
            .Path = IO.Path.GetDirectoryName(filename)
            .Filter = IO.Path.GetFileName(filename)
            .EnableRaisingEvents = True
        End With

        Try
            Process.Start(Options.gImageEditor, """" & Game.Drawing.Tex(Game.tileset.tileName(Value)).filename & """")
        Catch ex As Exception
            MessageBox.Show(ex.Message, GetString("tileset_EditImageAction"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub fsw_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs)
        For i As Integer = 1 To Game.tileset.NumTiles
            If Game.tileset.tiles(i).filename.ToLower = e.FullPath.ToLower Then
                Game.Drawing.Tex(Game.tileset.tiles(i).name).ReloadTexture()
            End If
        Next
    End Sub

    Private Sub btnReload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReload.Click
        For i As Integer = 1 To Game.tileset.NumTiles
            Game.Drawing.Tex(Game.tileset.tiles(i).name).ReloadTexture()
        Next
    End Sub
End Class