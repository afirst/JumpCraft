Imports PlatformStudio

'Prefixes:
'---------
'a = Always
'c = Counter
'i = Timer
'g = Group
't = Tile
'l = Location
'k = Key (Keybaord)
'm = Mouse
'w = Windows

Public Class psfrmActionEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label2.Text = GetString("actionEd_ActionsLabel")
        Me.btnNew.ToolTipText = GetString("actionEd_newIconTooltip")
        Me.MenuItem13.Text = GetString("actionEd_NewActionAllMenu")
        Me.MenuItem14.Text = GetString("actionEd_NewActionGameMenu")
        Me.MenuItem16.Text = GetString("actionEd_NewActionCountersMenu")
        Me.MenuItem24.Text = GetString("actionEd_NewActionCameraMenu")
        Me.MenuItem17.Text = GetString("actionEd_NewActionCharacterMenu")
        Me.MenuItem18.Text = GetString("actionEd_NewActionMapMenu")
        Me.MenuItem19.Text = GetString("actionEd_NewActionDrawingMenu")
        Me.MenuItem21.Text = GetString("actionEd_NewActionScriptingMenu")
        Me.MenuItem22.Text = GetString("actionEd_NewActionMiscMenu")
        Me.btnCut.ToolTipText = GetString("actionEd_CutIconTooltip")
        Me.btnCopy.ToolTipText = GetString("actionEd_CopyIconTooltip")
        Me.btnPaste.ToolTipText = GetString("actionEd_PasteIconTooltip")
        Me.btnDelete.ToolTipText = GetString("actionEd_DeleteIconTooltip")
        Me.btnMoveUp.ToolTipText = GetString("actionEd_MoveUpIconTooltip")
        Me.btnMoveDown.ToolTipText = GetString("actionEd_MoveDownIconTooltip")
        Me.btnTimers.ToolTipText = GetString("actionEd_EditTimersIconTooltip")
        Me.btnCounters.ToolTipText = GetString("actionEd_EditCountersIconTooltip")
        Me.btnGlobals.ToolTipText = GetString("actionEd_EditGlobalScriptIconTooltip")
        Me.Label1.Text = GetString("actionEd_TriggersLabel")
        Me.Button3.Text = GetString("actionEd_EditDataButton")
        Me.Button2.Text = GetString("cancelButton")
        Me.Button1.Text = GetString("okButton")
        Me.lblIndentError.Text = GetString("actionEd_WarningLabel")
        Me.mnuNew.Text = GetString("actionEd_NewActionMenu")
        Me.MenuItem25.Text = GetString("actionEd_NewActionSubmenu")
        Me.mnuCut.Text = GetString("editCutMenu")
        Me.mnuCopy.Text = GetString("editCopyMenu")
        Me.mnuPaste.Text = GetString("editPasteMenu")
        Me.mnuDelete.Text = GetString("editDeleteMenu")
        Me.mnuMoveUp.Text = GetString("actionEd_MoveUpMenu")
        Me.mnuMoveDown.Text = GetString("actionEd_MoveDownMenu")
        Me.mnuTimers.Text = GetString("actionEd_TimersMenu")
        Me.mnuCounters.Text = GetString("actionEd_CountersMenu")
        Me.MenuItem12.Text = GetString("actionEd_GlobalScriptMenu")
        Me.MenuItem10.Text = GetString("fileMenu")
        Me.mnuSave.Text = GetString("actionEd_CloseSaveMenu")
        Me.mnuDiscard.Text = GetString("actionEd_CloseDiscardMenu")
        Me.MenuItem11.Text = GetString("editMenu")
        Me.mnuTriggers.Text = GetString("actionEd_TriggerMenu")
        Me.MenuItem1.Text = GetString("actionEd_ExpandMenu")
        Me.MenuItem2.Text = GetString("actionEd_CollapseMenu")
        Me.MenuItem4.Text = GetString("actionEd_ExpandAllMenu")
        Me.MenuItem6.Text = GetString("actionEd_CopyChildMenu")
        Me.MenuItem7.Text = GetString("actionEd_PasteChildMenu")
        Me.MenuItem8.Text = GetString("actionEd_PasteLinkMenu")
        Me.MenuItem9.Text = GetString("actionEd_DeleteAllChildMenu")
        Me.mnuAction.Text = GetString("actionEd_ActionMenu")
        Me.Text = GetString("actionEd_Title")
        UIPlusMenu1.SetImageList(iml2)

        'Load menus
        LoadAxnMenu()
        mnuNew.MergeMenu(ctxNewAxn)
        Context1.MergeMenu(mnuTriggers)
        Context2.MergeMenu(mnuAction)

        UIPlusMenu1.Initialize(Me, MainMenu1, Context1, Context2, ctxNewAxn)
        BackColor = UIPlus.DefaultColorScheme.getInstance.MenuBack
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
    Public WithEvents iml As System.Windows.Forms.ImageList
    Public WithEvents iml2 As System.Windows.Forms.ImageList
    Public WithEvents iml3 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Context1 As System.Windows.Forms.ContextMenu
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UIPlusMenu1 As UIPlus.UIPlusMenu
    Friend WithEvents tbrMain As UIPlus.UIPlusToolbar
    Friend WithEvents btnNew As ToolBarButton
    Friend WithEvents btnSep1 As ToolBarButton
    Friend WithEvents btnCut As ToolBarButton
    Friend WithEvents btnCopy As ToolBarButton
    Friend WithEvents btnPaste As ToolBarButton
    Friend WithEvents btnDelete As ToolBarButton
    Friend WithEvents btnSep2 As ToolBarButton
    Friend WithEvents btnMoveUp As ToolBarButton
    Friend WithEvents btnMoveDown As ToolBarButton
    Friend WithEvents btnSep3 As ToolBarButton
    Friend WithEvents btnTimers As ToolBarButton
    Friend WithEvents btnCounters As ToolBarButton
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTriggers As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAction As System.Windows.Forms.MenuItem
    Friend WithEvents Context2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMoveUp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMoveDown As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTimers As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCounters As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDiscard As System.Windows.Forms.MenuItem
    Friend WithEvents btnGlobals As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents list As psTileSelector
    Friend WithEvents lblIndentError As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ctxNewAxn As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmActionEditor))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.iml2 = New System.Windows.Forms.ImageList(Me.components)
        Me.iml3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Context2 = New System.Windows.Forms.ContextMenu
        Me.tbrMain = New UIPlus.UIPlusToolbar
        Me.btnNew = New System.Windows.Forms.ToolBarButton
        Me.ctxNewAxn = New System.Windows.Forms.ContextMenu
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton
        Me.btnCut = New System.Windows.Forms.ToolBarButton
        Me.btnCopy = New System.Windows.Forms.ToolBarButton
        Me.btnPaste = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton
        Me.btnMoveUp = New System.Windows.Forms.ToolBarButton
        Me.btnMoveDown = New System.Windows.Forms.ToolBarButton
        Me.btnSep3 = New System.Windows.Forms.ToolBarButton
        Me.btnTimers = New System.Windows.Forms.ToolBarButton
        Me.btnCounters = New System.Windows.Forms.ToolBarButton
        Me.btnGlobals = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tv = New System.Windows.Forms.TreeView
        Me.Context1 = New System.Windows.Forms.ContextMenu
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblIndentError = New System.Windows.Forms.Label
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.UIPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.mnuCut = New System.Windows.Forms.MenuItem
        Me.mnuCopy = New System.Windows.Forms.MenuItem
        Me.mnuPaste = New System.Windows.Forms.MenuItem
        Me.mnuDelete = New System.Windows.Forms.MenuItem
        Me.mnuMoveUp = New System.Windows.Forms.MenuItem
        Me.mnuMoveDown = New System.Windows.Forms.MenuItem
        Me.mnuTimers = New System.Windows.Forms.MenuItem
        Me.mnuCounters = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuDiscard = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.mnuTriggers = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.mnuAction = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml.ImageSize = New System.Drawing.Size(17, 17)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Silver
        '
        'iml2
        '
        Me.iml2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml2.ImageSize = New System.Drawing.Size(24, 24)
        Me.iml2.ImageStream = CType(resources.GetObject("iml2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml2.TransparentColor = System.Drawing.Color.Silver
        '
        'iml3
        '
        Me.iml3.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml3.ImageSize = New System.Drawing.Size(24, 24)
        Me.iml3.ImageStream = CType(resources.GetObject("iml3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml3.TransparentColor = System.Drawing.Color.Silver
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.DockPadding.Bottom = 36
        Me.Panel1.DockPadding.Top = 4
        Me.Panel1.Location = New System.Drawing.Point(256, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 333)
        Me.Panel1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 11

        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(0, 25)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 307)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'tbrMain
        '
        Me.tbrMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNew, Me.btnSep1, Me.btnCut, Me.btnCopy, Me.btnPaste, Me.btnDelete, Me.btnSep2, Me.btnMoveUp, Me.btnMoveDown, Me.btnSep3, Me.btnTimers, Me.btnCounters, Me.btnGlobals})
        Me.tbrMain.CustomColorScheme = Nothing
        Me.tbrMain.Divider = False
        Me.tbrMain.DropDownArrows = True
        Me.tbrMain.ImageList = Me.ImageList1
        Me.tbrMain.Location = New System.Drawing.Point(0, 0)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.ShowToolTips = True
        Me.tbrMain.Size = New System.Drawing.Size(552, 26)
        Me.tbrMain.TabIndex = 4
        '
        'btnNew
        '
        Me.btnNew.DropDownMenu = Me.ctxNewAxn
        Me.btnNew.Enabled = False
        Me.btnNew.ImageIndex = 0
        Me.btnNew.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton

        '
        'ctxNewAxn
        '
        Me.ctxNewAxn.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem13, Me.MenuItem14, Me.MenuItem16, Me.MenuItem24, Me.MenuItem17, Me.MenuItem18, Me.MenuItem19, Me.MenuItem21, Me.MenuItem22, Me.MenuItem23})
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 0

        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1

        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 2

        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 3

        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 4

        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 5

        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 6

        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 7

        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 8

        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 9
        Me.MenuItem23.Text = "-"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCut
        '
        Me.btnCut.Enabled = False
        Me.btnCut.ImageIndex = 6

        '
        'btnCopy
        '
        Me.btnCopy.Enabled = False
        Me.btnCopy.ImageIndex = 7

        '
        'btnPaste
        '
        Me.btnPaste.Enabled = False
        Me.btnPaste.ImageIndex = 8

        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.ImageIndex = 1

        '
        'btnSep2
        '
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Enabled = False
        Me.btnMoveUp.ImageIndex = 2

        '
        'btnMoveDown
        '
        Me.btnMoveDown.Enabled = False
        Me.btnMoveDown.ImageIndex = 3

        '
        'btnSep3
        '
        Me.btnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnTimers
        '
        Me.btnTimers.ImageIndex = 4

        '
        'btnCounters
        '
        Me.btnCounters.ImageIndex = 5

        '
        'btnGlobals
        '
        Me.btnGlobals.ImageIndex = 9

        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tv)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 333)
        Me.Panel2.TabIndex = 11
        '
        'tv
        '
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.ContextMenu = Me.Context1
        Me.tv.HideSelection = False
        Me.tv.ImageList = Me.iml
        Me.tv.Location = New System.Drawing.Point(8, 25)
        Me.tv.Name = "tv"
        Me.tv.ShowRootLines = False
        Me.tv.Size = New System.Drawing.Size(240, 307)
        Me.tv.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 2

        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.lblIndentError)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 359)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(552, 40)
        Me.Panel3.TabIndex = 12
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(312, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 12

        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(392, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 10

        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(472, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 11

        '
        'lblIndentError
        '
        Me.lblIndentError.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.lblIndentError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndentError.Location = New System.Drawing.Point(8, 8)
        Me.lblIndentError.Name = "lblIndentError"
        Me.lblIndentError.Size = New System.Drawing.Size(296, 16)
        Me.lblIndentError.TabIndex = 14

        Me.lblIndentError.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(248, 26)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(8, 333)
        Me.Splitter1.TabIndex = 13
        Me.Splitter1.TabStop = False
        '
        'UIPlusMenu1
        '
        Me.UIPlusMenu1.CustomColorScheme = Nothing
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        Me.mnuNew.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem25, Me.MenuItem26})

        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 0
        Me.MenuItem25.Shortcut = System.Windows.Forms.Shortcut.CtrlN

        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 1
        Me.MenuItem26.Text = "-"
        '
        'mnuCut
        '
        Me.mnuCut.Index = 2
        Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX

        '
        'mnuCopy
        '
        Me.mnuCopy.Index = 3
        Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC

        '
        'mnuPaste
        '
        Me.mnuPaste.Index = 4
        Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV

        '
        'mnuDelete
        '
        Me.mnuDelete.Index = 5
        Me.mnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del

        '
        'mnuMoveUp
        '
        Me.mnuMoveUp.Index = 7
        Me.mnuMoveUp.MergeOrder = 5

        '
        'mnuMoveDown
        '
        Me.mnuMoveDown.Index = 8
        Me.mnuMoveDown.MergeOrder = 6

        '
        'mnuTimers
        '
        Me.mnuTimers.Index = 0
        Me.mnuTimers.MergeOrder = 7

        '
        'mnuCounters
        '
        Me.mnuCounters.Index = 1
        Me.mnuCounters.MergeOrder = 8

        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 2

        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem11, Me.mnuTriggers, Me.mnuAction})
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSave, Me.mnuDiscard})

        '
        'mnuSave
        '
        Me.mnuSave.Index = 0

        '
        'mnuDiscard
        '
        Me.mnuDiscard.Index = 1

        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTimers, Me.mnuCounters, Me.MenuItem12})

        '
        'mnuTriggers
        '
        Me.mnuTriggers.Index = 2
        Me.mnuTriggers.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9})

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
        Me.MenuItem5.Text = "-"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5

        '
        'MenuItem7
        '
        Me.MenuItem7.Enabled = False
        Me.MenuItem7.Index = 6

        '
        'MenuItem8
        '
        Me.MenuItem8.Enabled = False
        Me.MenuItem8.Index = 7

        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 8

        '
        'mnuAction
        '
        Me.mnuAction.Index = 3
        Me.mnuAction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.MenuItem15, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.mnuDelete, Me.MenuItem20, Me.mnuMoveUp, Me.mnuMoveDown})

        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 1
        Me.MenuItem15.Text = "-"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 6
        Me.MenuItem20.Text = "-"
        '
        'psfrmActionEditor
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 399)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tbrMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "psfrmActionEditor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Panel2Height As Integer
    Private PrevFormWidth As Integer
    Dim OldAct As psActions
    Dim CopyAct As psActions.psAction.psAction2

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'getCompilePtr really means isDemo()
        If MyEdition.getCompilePtr() = False Then Exit Sub

        Dim f As New psfrmActionData
        f.ShowDialog()
        f.Dispose()
        f = Nothing
        tv_AfterSelect(sender, Nothing)
        Game.actions.IconKeysInit()
    End Sub

#Region "OLD psActionEditor_Load"
    'Private Sub psActionEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    OldAct = Game.actions.Clone

    '    Dim i As Integer, j As Integer, k As Integer
    '    Dim FirstNode As TreeNode
    '    Dim CurNode As TreeNode
    '    Dim tmpNode() As TreeNode
    '    Dim strSearch As String, strName As String, strDesc As String
    '    tv.Visible = False
    '    FirstNode = tv.Nodes.Add("Triggers")
    '    With Game.actions.Dat
    '        For i = 1 To UBound(.tb)

    '            'Find the path of the node to look for
    '            'to be the parent of the new node
    '            strSearch = Nothing
    '            For j = Len(.tb(i).Name) To 2 Step -1
    '                If Mid(.tb(i).Name, j, 1) = "\" Then
    '                    strSearch = Mid(.tb(i).Name, 1, j - 1)
    '                    Exit For
    '                End If
    '            Next

    '            'Look for the parent node
    '            tmpNode = SearchNodes(tv.Nodes(0), strSearch)

    '            Dim Max As Integer
    '            If tmpNode Is Nothing Then
    '                Max = 1
    '            Else
    '                Max = UBound(tmpNode)
    '            End If
    '            For k = 1 To Max

    '                'If a parent node was found, make it the parent.
    '                'Otherwise, make the first node the parent
    '                If tmpNode Is Nothing Then
    '                    CurNode = FirstNode
    '                Else
    '                    CurNode = tmpNode(k)
    '                End If

    '                'Generate the text that the user will see next
    '                'to the new node
    '                If strSearch Is Nothing Then
    '                    strName = .tb(i).Name
    '                Else
    '                    strName = Mid(.tb(i).Name, Len(strSearch) + 2)
    '                End If

    '                'Create the new node(s)
    '                With CurNode.Nodes.Add(strName)
    '                    .ImageIndex = Game.actions.Dat.tb(i).Icon
    '                    .SelectedImageIndex = .ImageIndex
    '                    .Tag = Game.actions.Dat.tb(i).Name

    '                    With Game.actions
    '                        For j = 1 To UBound(.Actions)
    '                            With .Actions(j)
    '                                If .Trigger = Trigger(CurNode.LastNode) Then
    '                                    CurNode.LastNode.ForeColor = Color.Blue
    '                                    Exit For
    '                                End If
    '                            End With
    '                        Next
    '                    End With

    '                End With
    '                CurNode = CurNode.LastNode
    '                Select Case .tb(i).Description
    '                    Case "&LIST_TILES"
    '                        For j = 1 To Game.tileset.NumTiles
    '                            With CurNode.Nodes.Add(Game.tileset.tiles(j).name)
    '                                If LoadedTilePreviews Then
    '                                    .ImageIndex = TilesStart + j
    '                                Else
    '                                    iml.Images.Add(Game.Drawing.Tex(Game.tileset.tiles(j).name).bmp)
    '                                    .ImageIndex = iml.Images.Count - 1
    '                                    If j = 1 Then TilesStart = iml.Images.Count - 2
    '                                End If
    '                                .SelectedImageIndex = .ImageIndex
    '                                .Tag = CurNode.Tag
    '                            End With
    '                        Next
    '                        LoadedTilePreviews = True
    '                        CurNode.Tag = ""
    '                    Case "&LIST_LOCATIONS"
    '                        For j = 1 To Game.loc.NumLocations
    '                            With CurNode.Nodes.Add(Game.loc.Locations(j).Name)
    '                                .ImageIndex = CurNode.ImageIndex
    '                                .SelectedImageIndex = CurNode.ImageIndex
    '                                .Tag = CurNode.Tag
    '                            End With
    '                        Next
    '                        CurNode.Tag = ""
    '                    Case "&LIST_KEYS"
    '                        Dim tmpTxt As String, tmpTxt2 As String
    '                        For j = 0 To 255
    '                            tmpTxt = "" : tmpTxt2 = ""
    '                            Select Case j
    '                                Case 8 : tmpTxt = "(backspace)" : tmpTxt2 = "£6"
    '                                Case 13 : tmpTxt = "(enter)" : tmpTxt2 = "£5"
    '                                Case 16 : tmpTxt = "(shift)" : tmpTxt2 = "£7"
    '                                Case 17 : tmpTxt = "(ctrl)" : tmpTxt2 = "ctl"
    '                                Case 18 : tmpTxt = "(alt)" : tmpTxt2 = "alt"
    '                                Case 19 : tmpTxt = "(print screen)" : tmpTxt2 = "£12"
    '                                Case 27 : tmpTxt = "(escape)" : tmpTxt2 = "esc"
    '                                Case 32 : tmpTxt = "(space)" : tmpTxt2 = " "
    '                                Case 33 : tmpTxt = "(page up)" : tmpTxt2 = "£10"
    '                                Case 34 : tmpTxt = "(page down)" : tmpTxt2 = "£11"
    '                                Case 35 : tmpTxt = "(end)" : tmpTxt2 = "£8"
    '                                Case 36 : tmpTxt = "(home)" : tmpTxt2 = "£9"
    '                                Case 37 : tmpTxt = "(left arrow)" : tmpTxt2 = "£1"
    '                                Case 38 : tmpTxt = "(up arrow)" : tmpTxt2 = "£2"
    '                                Case 39 : tmpTxt = "(right arrow)" : tmpTxt2 = "£3"
    '                                Case 40 : tmpTxt = "(down arrow)" : tmpTxt2 = "£4"
    '                                Case 45 : tmpTxt = "(insert)" : tmpTxt2 = "ins"
    '                                Case 46 : tmpTxt = "(delete)" : tmpTxt2 = "del"
    '                                Case 48 To 57 : tmpTxt = j - 48
    '                                Case 65 To 90 : tmpTxt = Chr(j)
    '                                Case 96 To 105 : tmpTxt = "numpad " & j - 96 : tmpTxt2 = j - 96
    '                                Case 106 : tmpTxt = "numpad *" : tmpTxt2 = "*"
    '                                Case 107 : tmpTxt = "numpad +" : tmpTxt2 = "+"
    '                                Case 109 : tmpTxt = "numpad -" : tmpTxt2 = "-"
    '                                Case 110 : tmpTxt = "numpad ." : tmpTxt2 = "."
    '                                Case 111 : tmpTxt = "numpad /" : tmpTxt2 = "/"
    '                                Case 112 To 123 : tmpTxt = "F" & j - 111
    '                                Case 186 : tmpTxt = ";"
    '                                Case 187 : tmpTxt = "="
    '                                Case 188 : tmpTxt = ","
    '                                Case 189 : tmpTxt = "-"
    '                                Case 190 : tmpTxt = "."
    '                                Case 191 : tmpTxt = "/"
    '                                Case 192 : tmpTxt = "`"
    '                                Case 219 : tmpTxt = "["
    '                                Case 220 : tmpTxt = "\"
    '                                Case 221 : tmpTxt = "]"
    '                                Case 222 : tmpTxt = "'"
    '                            End Select
    '                            If tmpTxt <> "" Then
    '                                With CurNode.Nodes.Add(tmpTxt)
    '                                    .ImageIndex = CurNode.ImageIndex
    '                                    .SelectedImageIndex = .ImageIndex
    '                                    .Tag = CurNode.Tag
    '                                End With
    '                            End If
    '                        Next
    '                        CurNode.Tag = ""
    '                End Select
    '            Next
    '        Next
    '    End With

    '    tv.Nodes(0).Expand()
    '    tv.Visible = True

    '    Panel2Height = Panel2.Height
    '    PrevFormWidth = Me.Width
    'End Sub

    'Function SearchNodes(ByVal Node As TreeNode, ByVal SearchFor As String) As TreeNode()
    '    If Node Is Nothing Then Return Nothing
    '    If SearchFor Is Nothing Then Return Nothing
    '    Dim CurNode As TreeNode
    '    Dim tmpNode() As TreeNode
    '    Dim RET_Nodes() As TreeNode
    '    ReDim RET_Nodes(0)
    '    CurNode = Node.FirstNode
    '    If CurNode Is Nothing Then Return Nothing
    '    Do
    '        If CurNode Is Nothing Then Exit Do
    '        If CurNode.Tag = SearchFor Then
    '            ReDim Preserve RET_Nodes(UBound(RET_Nodes) + 1)
    '            RET_Nodes(UBound(RET_Nodes)) = CurNode
    '        End If
    '        tmpNode = SearchNodes(CurNode, SearchFor)
    '        If Not (tmpNode Is Nothing) AndAlso Not (tmpNode Is Nothing) Then
    '            Dim i As Integer
    '            For i = 1 To UBound(tmpNode)
    '                ReDim Preserve RET_Nodes(UBound(RET_Nodes) + 1)
    '                RET_Nodes(UBound(RET_Nodes)) = tmpNode(i)
    '            Next
    '        End If
    '        CurNode = CurNode.NextNode
    '    Loop
    '    Return RET_Nodes
    'End Function
#End Region

    Dim Loaded As Boolean

    Private Sub commonInitAtFormLoad()
        If Loaded Then Exit Sub
        fActionEdit = Me
        list = New psTileSelector
        list.Location = New Point(TextBox1.Left + 1, TextBox1.Top + 1)
        list.Size = New Size(TextBox1.Width - 2, TextBox1.Height - 2)
        list.Anchor = TextBox1.Anchor
        Panel1.Controls.Add(list)
        list.BringToFront()
        list.Init(psTileSelector.SelectorType.Action)
        list.setImageList(iml2)
        list.BackColor1 = SystemColors.Window
        list.BackColor2 = SystemColors.Window
        list.CanDragDrop = True
        list.ContextMenu = Context2
        AddHandler getList.Updated, AddressOf OnUpdateList
    End Sub

    Shadows Function ShowDialog() As DialogResult
        Return ShowDialog(False)
    End Function

    Shadows Function ShowDialog(ByVal customSelectedTrigger As Boolean) As DialogResult
        commonInitAtFormLoad()
        If Not customSelectedTrigger Then
            Init()
        Else
            Init(GetString("trigger_Custom"))
            tv.SelectedNode = tv.Nodes(0)
            tv.SelectedNode.ExpandAll()
        End If
        Return MyBase.ShowDialog()
    End Function

    Shadows Function ShowDialog(ByVal selectedTrigger As String) As DialogResult
        commonInitAtFormLoad()
        Init(selectedTrigger)
        tv_AfterSelect(Nothing, Nothing)
        'SelectTrigger(tv.Nodes(0), selectedTrigger)
        Panel2.Visible = False
        Splitter1.Enabled = False
        mnuTriggers.Visible = False
        Width -= 240
        Return MyBase.ShowDialog()
    End Function

    Sub SelectTrigger(ByVal node As TreeNode, ByVal trig As String)
        If node.Tag = trig Then
            tv.SelectedNode = node
            tv_AfterSelect(Nothing, Nothing)
            Return
        End If
        For Each n As TreeNode In node.Nodes
            SelectTrigger(n, trig)
        Next
    End Sub

    Sub Init(Optional ByVal singleTrigger As String = "")
        Loaded = True

        OldAct = Game.actions.Clone

        If singleTrigger <> "" Then
            With tv.Nodes.Add("")
                .Tag = singleTrigger
            End With
            tv.SelectedNode = tv.Nodes(0)
            GoTo ExitSub
        ElseIf singleTrigger = GetString("trigger_Custom") Then
            GoTo ExitSub
        End If

        Dim i As Integer, j As Integer
        With tv
            With .Nodes.Add(GetString("trigger_Triggers"))
                With .Nodes.Add(GetString("trigger_General"))
                    .ImageIndex = 17
                    With .Nodes.Add(GetString("trigger_Always"))
                        .ImageIndex = 17
                        .Tag = "aalw"
                    End With
                    With .Nodes.Add(GetString("trigger_BeginGame"))
                        .ImageIndex = 17
                        .Tag = "nbgm"
                    End With
                    With .Nodes.Add(GetString("trigger_BeginLevel"))
                        .ImageIndex = 17
                        .Tag = "nblv"
                        For i = 1 To Game.numMaps
                            With .Nodes.Add(Game.maps(i).MapName)
                                .Tag = "nblv" & Format(i, "00000") & "_"
                                .ImageIndex = 17
                            End With
                        Next
                    End With
                End With
                With .Nodes.Add(GetString("trigger_Counters"))
                    .ImageIndex = 2
                End With
                ListCounters(.Nodes(1))
                With .Nodes.Add(GetString("trigger_Timers"))
                    .ImageIndex = 3
                End With
                ListTimers(.Nodes(2))
                With .Nodes.Add(GetString("trigger_Character"))
                    .ImageIndex = 16
                    With .Nodes.Add(GetString("trigger_Jump"))
                        .Tag = "rjum"
                        .ImageIndex = 16
                    End With
                    With .Nodes.Add(GetString("trigger_JumpHitHead"))
                        .Tag = "rstj"
                        .ImageIndex = 16
                    End With
                    With .Nodes.Add("Fall")
                        .Tag = "rfal"
                        .ImageIndex = 16
                    End With
                    With .Nodes.Add("Land")
                        .Tag = "rlan"
                        .ImageIndex = 16
                    End With
                End With
                With .Nodes.Add(GetString("trigger_Groups"))
                    .ImageIndex = 6
                    For i = 1 To UBound(Game.maps)
                        With .Nodes.Add(Game.maps(i).MapName)
                            .ImageIndex = 6
                            Dim tmpGroups() As String = ListGroups(i)
                            For j = 1 To UBound(tmpGroups)
                                AddGroupNodes(.Nodes.Add(tmpGroups(j)), i, tmpGroups(j))
                            Next
                        End With
                    Next
                End With
                With .Nodes.Add(GetString("trigger_Tiles"))
                    .ImageIndex = 5
                    For j = 1 To Game.tileset.NumTiles
                        AddTileNodes(.Nodes.Add(Game.tileset.tiles(j).name), j)
                    Next
                End With
                With .Nodes.Add(GetString("trigger_Locations"))
                    .ImageIndex = 4
                    For i = 1 To Game.numMaps
                        With .Nodes.Add(Game.maps(i).MapName)
                            .ImageIndex = 4
                            For j = 1 To Game.maps(i).loc.NumLocations
                                AddLocNodes(.Nodes.Add(Game.maps(i).loc.Locations(j).Name), i, Game.maps(i).loc.Locations(j).Name)
                            Next
                        End With
                    Next
                End With
                With .Nodes.Add(GetString("trigger_Keyboard"))
                    .ImageIndex = 14
                    Dim tmpTxt As String, tmpTxt2 As String
                    For j = 0 To 255
                        tmpTxt = "" : tmpTxt2 = ""
                        Select Case j
                            Case 8 : tmpTxt = GetString("trigger_Backspace") : tmpTxt2 = "£6"
                            Case 13 : tmpTxt = GetString("trigger_Enter") : tmpTxt2 = "£5"
                            Case 16 : tmpTxt = GetString("trigger_Shift") : tmpTxt2 = "£7"
                            Case 17 : tmpTxt = GetString("trigger_Ctrl") : tmpTxt2 = "ctl"
                            Case 18 : tmpTxt = GetString("trigger_Alt") : tmpTxt2 = "alt"
                            Case 19 : tmpTxt = GetString("trigger_PrintScreen") : tmpTxt2 = "£12"
                            Case 27 : tmpTxt = GetString("trigger_Escape") : tmpTxt2 = "esc"
                            Case 32 : tmpTxt = GetString("trigger_Space") : tmpTxt2 = " "
                            Case 33 : tmpTxt = GetString("trigger_PageUp") : tmpTxt2 = "£10"
                            Case 34 : tmpTxt = GetString("trigger_PageDown") : tmpTxt2 = "£11"
                            Case 35 : tmpTxt = GetString("trigger_EndKey") : tmpTxt2 = "£8"
                            Case 36 : tmpTxt = GetString("trigger_HomeKey") : tmpTxt2 = "£9"
                            Case 37 : tmpTxt = GetString("trigger_LeftArrowKey") : tmpTxt2 = "£1"
                            Case 38 : tmpTxt = GetString("trigger_UpArrowKey") : tmpTxt2 = "£2"
                            Case 39 : tmpTxt = GetString("trigger_RightArrowKey") : tmpTxt2 = "£3"
                            Case 40 : tmpTxt = GetString("trigger_DownArrowKey") : tmpTxt2 = "£4"
                            Case 45 : tmpTxt = GetString("trigger_InsertKey") : tmpTxt2 = "ins"
                            Case 46 : tmpTxt = GetString("trigger_DeleteKey") : tmpTxt2 = "del"
                            Case 48 To 57 : tmpTxt = j - 48
                            Case 65 To 90 : tmpTxt = Chr(j)
                            Case 96 To 105 : tmpTxt = GetString("trigger_Numpad") & " " & j - 96 : tmpTxt2 = j - 96
                            Case 106 : tmpTxt = GetString("trigger_Numpad") & " *" : tmpTxt2 = "*"
                            Case 107 : tmpTxt = GetString("trigger_Numpad") & " +" : tmpTxt2 = "+"
                            Case 109 : tmpTxt = GetString("trigger_Numpad") & " -" : tmpTxt2 = "-"
                            Case 110 : tmpTxt = GetString("trigger_Numpad") & " ." : tmpTxt2 = "."
                            Case 111 : tmpTxt = GetString("trigger_Numpad") & " /" : tmpTxt2 = "/"
                            Case 112 To 123 : tmpTxt = "F" & j - 111
                            Case 186 : tmpTxt = ";"
                            Case 187 : tmpTxt = "="
                            Case 188 : tmpTxt = ","
                            Case 189 : tmpTxt = "-"
                            Case 190 : tmpTxt = "."
                            Case 191 : tmpTxt = "/"
                            Case 192 : tmpTxt = "`"
                            Case 219 : tmpTxt = "["
                            Case 220 : tmpTxt = "\"
                            Case 221 : tmpTxt = "]"
                            Case 222 : tmpTxt = "'"
                        End Select
                        If tmpTxt <> "" Then
                            With .Nodes.Add(tmpTxt)
                                .ImageIndex = 14
                                With .Nodes.Add(GetString("trigger_KeyPress"))
                                    .ImageIndex = 14
                                    .Tag = "kpre" & j
                                End With
                                With .Nodes.Add(GetString("trigger_KeyRelease"))
                                    .ImageIndex = 14
                                    .Tag = "krel" & j
                                End With
                                With .Nodes.Add(GetString("trigger_KeyHoldDown"))
                                    .ImageIndex = 14
                                    .Tag = "khol" & j
                                End With
                            End With
                        End If
                    Next
                End With
                With .Nodes.Add(GetString("trigger_Mouse"))
                    .ImageIndex = 15
                    With .Nodes.Add(GetString("trigger_MouseLeftButtonPress"))
                        .ImageIndex = 15
                        .Tag = "mlpr"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseLeftButtonRelease"))
                        .ImageIndex = 15
                        .Tag = "mlre"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseLeftButtonHoldDown"))
                        .ImageIndex = 15
                        .Tag = "mlho"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseRightButtonPress"))
                        .ImageIndex = 15
                        .Tag = "mrpr"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseRightButtonRelease"))
                        .ImageIndex = 15
                        .Tag = "mrre"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseRightButtonHoldDown"))
                        .ImageIndex = 15
                        .Tag = "mrho"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseMiddleButtonPress"))
                        .ImageIndex = 15
                        .Tag = "mmpr"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseMiddleButtonRelease"))
                        .ImageIndex = 15
                        .Tag = "mmre"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseMiddleButtonHoldDown"))
                        .ImageIndex = 15
                        .Tag = "mmho"
                    End With
                    With .Nodes.Add(GetString("trigger_MouseMove"))
                        .ImageIndex = 15
                        .Tag = "mmov"
                    End With
                End With
                With .Nodes.Add(GetString("trigger_Windows"))
                    .ImageIndex = 25
                    With .Nodes.Add(GetString("trigger_Buttons"))
                        .ImageIndex = 27
                        For x As Integer = 1 To UBound(Game.windows.Windows)
                            For y As Integer = 1 To Game.windows.Windows(x).NumCtrls
                                If Game.windows.Windows(x).Controls(y).Type = psUI.psControl.psCtrlType.Button Then
                                    Dim str As String = Game.windows.Windows(x).Controls(y).Name
                                    With .Nodes.Add(str)
                                        .ImageIndex = 27
                                        With .Nodes.Add(GetString("trigger_ButtonClicked"))
                                            .ImageIndex = 27
                                            .Tag = "wcli" & str
                                        End With
                                    End With
                                End If
                            Next
                        Next
                    End With
                End With
            End With
        End With

        tv.SelectedNode = tv.Nodes(0).Nodes(0).Nodes(0) 'Always
        tv.Visible = True

ExitSub:
        CopyImageToSelImage(tv.Nodes(0))
        ShowActionsExist(tv.Nodes(0))

        Panel2Height = Panel2.Height
        PrevFormWidth = Me.Width
    End Sub

    Sub AddGroupNodes(ByVal atNode As TreeNode, ByVal level As Integer, ByVal groupName As String)
        With atNode
            .ImageIndex = 6
            With .Nodes.Add(GetString("trigger_TileHit"))
                .ImageIndex = 13
                .Tag = "ghit" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileHitLeft"))
                .ImageIndex = 9
                .Tag = "glef" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileHitRight"))
                .ImageIndex = 10
                .Tag = "grig" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileHitTop"))
                .ImageIndex = 8
                .Tag = "gtop" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileHitBottom"))
                .ImageIndex = 11
                .Tag = "gbot" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileExclOnTop"))
                .ImageIndex = 12
                .Tag = "gexc" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileCollect"))
                .ImageIndex = 7
                .Tag = "gcol" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileShot"))
                .ImageIndex = 18
                .Tag = "gsho" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileDestroyed"))
                .ImageIndex = 24
                .Tag = "gdes" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileChangeDirection"))
                .ImageIndex = 21
                .Tag = "gcha" & Format(level, "00000") & groupName
                With .Nodes.Add(GetString("trigger_TileChangeDirectionToForward"))
                    .ImageIndex = 22
                    .Tag = "gctf" & Format(level, "00000") & groupName
                End With
                With .Nodes.Add(GetString("trigger_TileChangeDirectionToBackward"))
                    .ImageIndex = 23
                    .Tag = "gctb" & Format(level, "00000") & groupName
                End With
            End With
            With .Nodes.Add(GetString("trigger_TileMouseHover"))
                .ImageIndex = 19
                .Tag = "ghov" & Format(level, "00000") & groupName
            End With
            With .Nodes.Add(GetString("trigger_TileMouseClick"))
                .ImageIndex = 20
                .Tag = "gcli" & Format(level, "00000") & groupName
            End With
        End With
    End Sub

    Sub AddTileNodes(ByVal atNode As TreeNode, ByVal tileIndex As Integer)
        With atNode
            iml.Images.Add(Game.Drawing.Tex(Game.tileset.tiles(tileIndex).name).preview)
            .ImageIndex = iml.Images.Count - 1
            With .Nodes.Add(GetString("trigger_TileHit"))
                .ImageIndex = 13
                .Tag = "thit" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileHitLeft"))
                .ImageIndex = 9
                .Tag = "tlef" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileHitRight"))
                .ImageIndex = 10
                .Tag = "trig" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileHitTop"))
                .ImageIndex = 8
                .Tag = "ttop" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileHitBottom"))
                .ImageIndex = 11
                .Tag = "tbot" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileExclOnTop"))
                .ImageIndex = 12
                .Tag = "texc" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileCollect"))
                .ImageIndex = 7
                .Tag = "tcol" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileShot"))
                .ImageIndex = 18
                .Tag = "tsho" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileDestroyed"))
                .ImageIndex = 24
                .Tag = "tdes" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileChangeDirection"))
                .ImageIndex = 21
                .Tag = "tcha" & tileIndex
                With .Nodes.Add(GetString("trigger_TileChangeDirectionToForward"))
                    .ImageIndex = 22
                    .Tag = "tctf" & tileIndex
                End With
                With .Nodes.Add(GetString("trigger_TileChangeDirectionToBackward"))
                    .ImageIndex = 23
                    .Tag = "tctb" & tileIndex
                End With
            End With
            With .Nodes.Add(GetString("trigger_TileMouseHover"))
                .ImageIndex = 19
                .Tag = "thov" & tileIndex
            End With
            With .Nodes.Add(GetString("trigger_TileMouseClick"))
                .ImageIndex = 20
                .Tag = "tcli" & tileIndex
            End With
        End With
    End Sub

    Sub AddLocNodes(ByVal atNode As TreeNode, ByVal level As Integer, ByVal locName As String)
        With atNode
            .ImageIndex = 4
            With .Nodes.Add(GetString("trigger_LocationEnterInto"))
                .ImageIndex = 4
                .Tag = "lent" & Format(level, "00000") & locName
            End With
            With .Nodes.Add(GetString("trigger_LocationsExitFrom"))
                .ImageIndex = 4
                .Tag = "lexi" & Format(level, "00000") & locName
            End With
            With .Nodes.Add(GetString("trigger_LocationsInside"))
                .ImageIndex = 4
                .Tag = "lins" & Format(level, "00000") & locName
            End With
        End With
    End Sub

    Sub ListCounters(ByVal n As TreeNode)
        Dim i As Integer
        With n.Nodes
            .Clear()
            For i = 1 To UBound(Game.actions.Counters)
                With .Add(Game.actions.Counters(i).Name)
                    .ImageIndex = 2
                    .SelectedImageIndex = .ImageIndex
                    With .Nodes.Add(GetString("trigger_CounterValueChanged"))
                        .ImageIndex = 2
                        .SelectedImageIndex = .ImageIndex
                        .Tag = "cval" & i
                    End With
                End With
            Next
        End With
    End Sub

    Sub ListTimers(ByVal n As TreeNode)
        Dim i As Integer
        With n.Nodes
            .Clear()
            For i = 1 To UBound(Game.actions.Timers)
                With .Add(Game.actions.Timers(i).Name)
                    .ImageIndex = 3
                    .SelectedImageIndex = .ImageIndex
                    With .Nodes.Add(GetString("trigger_TimerTick"))
                        .ImageIndex = 3
                        .SelectedImageIndex = .ImageIndex
                        .Tag = "itic" & i
                    End With
                End With
            Next
        End With
    End Sub

    Sub CopyImageToSelImage(ByVal Node As TreeNode)
        Node.SelectedImageIndex = Node.ImageIndex
        For Each N As TreeNode In Node.Nodes
            CopyImageToSelImage(N)
        Next
    End Sub

    Sub ShowActionsExist(ByVal Node As TreeNode)
        Dim N As TreeNode
        Dim i As Integer
        Dim bHasActions As Boolean
        For Each N In Node.Nodes
            bHasActions = False
            For i = 1 To UBound(Game.actions.Actions)
                If Game.actions.Actions(i).Trigger = Trigger(N) Then
                    N.ForeColor = Color.Blue
                    MakeParentForeColorBlue(N)
                    bHasActions = True
                    Exit For
                End If
            Next
            If bHasActions = False Then
                N.ForeColor = Color.Black
            End If
            ShowActionsExist(N)
        Next
    End Sub

    Sub MakeParentForeColorBlue(ByVal Node As TreeNode)
        If Node.Parent Is Nothing Then Return
        If Node.Parent.Text <> GetString("trigger_Triggers") Then
            Node.Parent.ForeColor = Color.Blue
            MakeParentForeColorBlue(Node.Parent)
        End If
    End Sub

    Private Sub psActionEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If PrevFormWidth = 0 Then Exit Sub
        Dim WidthRatio As Double = (Me.Size.Width / PrevFormWidth)
        Panel2.Size = New System.Drawing.Size(Panel2.Size.Width * WidthRatio, Panel2Height)
        PrevFormWidth = Me.Size.Width
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        tv.SelectedNode.Expand()
        tv.SelectedNode.EnsureVisible()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        tv.SelectedNode.Collapse()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        tv.Visible = False
        tv.SelectedNode.ExpandAll()
        tv.SelectedNode.EnsureVisible()
        tv.Visible = True
    End Sub

    Private tmpAxnType As Integer = 1
    Private tmpNewAxnShowDialog As Boolean = True
    Private Sub tbrMain_ButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs) Handles tbrMain.ButtonClick
        Game.actions.IconKeysInit()

        Dim i As Integer, tmpSel As Integer
        If Not (e.Button Is btnTimers Or e.Button Is btnCounters _
          Or e.Button Is btnGlobals) Then
            If tv.SelectedNode Is Nothing Then Exit Sub
            tmpSel = list.Value
        End If

        With Game.actions
            Select Case True

                Case e.Button Is btnNew
                    If UBound(Game.actions.Dat.ab) = 0 Then
                        MessageBox.Show(GetString("actionEd_NoActionTypesExist"), GetString("actionEd_Title"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    'Create a new action
                    ReDim Preserve .Actions(UBound(.Actions) + 1)
                    With .Actions(UBound(.Actions))
                        .Trigger = CurTrigger
                        .Action.Type = tmpAxnType
                        ReDim .Action.param(UBound(.Action.Behavior.params))
                        For n As Integer = 1 To UBound(.Action.param)
                            .Action.param(n) = .Action.Behavior.params(n).DefaultValue
                        Next
                    End With

                    If tmpNewAxnShowDialog Then
                        'Show Edit Action dialog
                        Dim f As New psfrmEditAction
                        Dim dr As DialogResult
                        dr = f.ShowDialog(.Actions(UBound(.Actions)))
                        f.Dispose()
                        f = Nothing

                        'Cancel if the user clicked cancel
                        If dr = DialogResult.Cancel Then
                            ReDim Preserve .Actions(UBound(.Actions) - 1)
                            Exit Sub
                        End If
                    End If

AddToListView:

                    'Add a new item to the ListView,
                    With .Actions(UBound(Game.actions.Actions))
                        getList.Add(ItemName(.Action)).ImageIndex = .Action.Behavior.Icon
                        UpdateFont(getList(getList.Count - 1))
                        getList(getList.Count - 1).Tag = UBound(Game.actions.Actions)
                    End With

                    If list.Value < 0 Then
                        'and select it.
                        list.Value = getList.Count - 1
                    Else
                        'and move it after the selected item.
                        Dim tmpSel1 As Integer = list.Value
                        Dim MoveAmt As Integer = (list.Value + 1) - (getList.Count - 1)
                        For j As Integer = 1 To Math.Abs(MoveAmt)
                            MoveAction(Math.Sign(MoveAmt), getList.Count - 1 + Math.Sign(MoveAmt) * (j - 1))
                        Next
                        list.Value = tmpSel1 + 1
                    End If

                Case e.Button Is btnCut
                    CopyAct = .Actions(getList(tmpSel).Tag).Action.Clone
                    btnPaste.Enabled = True
                    mnuPaste.Enabled = True
                    GoTo DelAction

                Case e.Button Is btnCopy
                    CopyAct = .Actions(getList(tmpSel).Tag).Action.Clone
                    btnPaste.Enabled = True
                    mnuPaste.Enabled = True
                Case e.Button Is btnPaste
                    ReDim Preserve .Actions(UBound(.Actions) + 1)
                    .Actions(UBound(.Actions)).Trigger = CurTrigger
                    .Actions(UBound(.Actions)).Action = CopyAct.Clone
                    GoTo AddToListView

                Case e.Button Is btnDelete
DelAction:
                    If tmpSel = -1 Then Exit Sub

                    'Delete the action data
                    For i = getList(tmpSel).Tag To UBound(.Actions) - 1
                        .Actions(i) = .Actions(i + 1)
                    Next
                    ReDim Preserve .Actions(UBound(.Actions) - 1)

                    'Delete the ListView item
                    getList.RemoveAt(tmpSel)
                    For i = tmpSel To getList.Count - 1
                        getList(i).Tag -= 1
                    Next

                    'Update the selected index
                    If getList.Count = 0 Then
                    ElseIf tmpSel > getList.Count - 1 Then
                        list.Value = getList.Count - 1
                    Else
                        list.Value = tmpSel
                    End If
                    If getList.Count = 0 Then list.Value = -1

                Case e.Button Is btnMoveUp
                    MoveAction(-1, tmpSel)

                Case e.Button Is btnMoveDown
                    MoveAction(1, tmpSel)

                Case e.Button Is btnTimers
                    Dim f As New psfrmTimers
                    f.ShowDialog()
                    ListTimers(tv.Nodes(0).Nodes(2))

                Case e.Button Is btnCounters
                    Dim f As New psfrmCounters
                    f.ShowDialog()
                    ListCounters(tv.Nodes(0).Nodes(1))

                Case e.Button Is btnGlobals
                    MenuItem12_Click(sender, EventArgs.Empty)

            End Select
        End With

        UpdateCurNode()
        UpdateFont()
    End Sub

    Sub MoveAction(ByVal Amount As Integer, ByVal tmpSel As Integer)
        If tmpSel = -1 Then Exit Sub
        If tmpSel + Amount < 0 Or tmpSel + Amount > getList.Count - 1 Then Return

        'Move the data
        Dim Start As Integer, Amt2 As Integer
        Start = getList(tmpSel).Tag
        Amt2 = getList(tmpSel + Amount).Tag - Start
        Dim tmpAct As psActions.psAction
        With Game.actions
            tmpAct = .Actions(Start)
            .Actions(Start) = .Actions(Start + Amt2)
            .Actions(Start + Amt2) = tmpAct
        End With

        'Move the ListView item
        Dim tmpTxt As String, tmpImg As Integer
        tmpTxt = getList(tmpSel + Amount).Text
        tmpImg = getList(tmpSel + Amount).ImageIndex
        getList(tmpSel + Amount).Text = getList(tmpSel).Text
        getList(tmpSel + Amount).ImageIndex = getList(tmpSel).ImageIndex
        getList(tmpSel).Text = tmpTxt
        getList(tmpSel).ImageIndex = tmpImg
        UpdateFont(getList(tmpSel))
        UpdateFont(getList(tmpSel + Amount))

        list.Value = tmpSel + Amount
        'list.Items(tmpSel).Tag += Amount
        'list.Items(tmpSel + Amount).Tag -= Amount
    End Sub

    Dim tmpBoldFont, tmpItalicFont As Font
    Dim tmpColor As Color
    Sub UpdateFont(ByVal ListItem As ActionList.CustomListItem)
        If tmpBoldFont Is Nothing Then tmpBoldFont = New Font(list.Font.FontFamily, list.Font.Size, FontStyle.Bold)
        If tmpItalicFont Is Nothing Then tmpItalicFont = New Font(list.Font.FontFamily, list.Font.Size, FontStyle.Italic)
        With ListItem
            If .ImageIndex >= 0 AndAlso psActions.ActIconKeys(.ImageIndex).StartsWith("Code Block") Then
                .Font = tmpBoldFont
                ListItem.ForeColor = SystemColors.ControlText
            ElseIf .ImageIndex >= 0 AndAlso Game.actions.Actions(ListItem.Tag).Action.Behavior.Name = "Comment" Then
                .Font = tmpItalicFont
                ListItem.ForeColor = Color.Green
            Else
                .Font = list.Font
                ListItem.ForeColor = SystemColors.ControlText
            End If
        End With
    End Sub

    Function ItemName(ByVal Action As psActions.psAction.psAction2) As String
        If Action.Behavior.Name = "Comment" Then
            Dim tmp As String = Action.param(1)
            If tmp Is Nothing Then tmp = ""
            If tmp.Length > 50 Then tmp = tmp.Substring(0, 50)
            Return tmp & " "
        End If

        'Returns something like: "Jump (2 tiles, 2 seconds)"

        'Variables
        Dim i As Integer
        Dim ParamText As String = ""

        With Action
            If UBound(.Behavior.params) = 0 Then
                'If there is no parameters, return just
                'the action name
                Return .Behavior.Name
            End If

            'Loop through all the parameters
            If UBound(.param) <> UBound(.Behavior.params) Then ReDim Preserve .param(UBound(.Behavior.params))
            For i = 1 To UBound(.param)

                'If a single parameter value is > 20 characters,
                If Len(.param(i)) > 20 Then
                    'then cut it off with an ellipsis (...)
                    ParamText &= Mid(.param(i), 1, 18) & "..."
                Else
                    'Otherwise, keep the whole parameter value
                    ParamText &= .param(i)
                End If

                'Include the units, if there is any
                If .Behavior.params(i).Units <> "" Then
                    ParamText &= " " & .Behavior.params(i).Units
                End If

                'Add a comma to separate the parameters
                If i < UBound(.param) Then
                    ParamText &= ", "
                End If
            Next

            'If the whole parameter list is > 32 characters,
            If Len(ParamText) > 32 Then
                'then cut it off with an ellipsis (...)
                ParamText = Mid(ParamText, 1, 30) & "..."
            End If

            'Finally, add the name of the action, and
            'enclose the parameters with parenthesis ()
            Return .Behavior.Name & " (" & ParamText & ")"
        End With
    End Function

    Private Sub list_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.DoubleClick
        If list.Value < 0 Then Exit Sub
        With Game.actions
            'Show Edit Action dialog
            Dim f As New psfrmEditAction
            f.ShowDialog(.Actions(getList(list.Value).Tag))
            f.Dispose()
            f = Nothing

            With .Actions(getList(list.Value).Tag)
                getList(list.Value).Text = (ItemName(.Action))
                getList(list.Value).ImageIndex = .Action.Behavior.Icon
                UpdateFont(getList(list.Value))
            End With
        End With
    End Sub

    Private Sub list_SelectedIndexChanged() Handles list.SelectedIndexChanged
        UpdateToolbar()
    End Sub

    Private Sub UpdateToolbar()
        Dim tmpSel As Integer
        If list.Value < 0 Then
            tmpSel = -1
        Else
            tmpSel = list.Value
        End If
        btnCut.Enabled = (tmpSel > -1)
        mnuCut.Enabled = btnCut.Enabled
        btnCopy.Enabled = (tmpSel > -1)
        mnuCopy.Enabled = btnCopy.Enabled
        btnDelete.Enabled = (tmpSel > -1)
        mnuDelete.Enabled = btnDelete.Enabled
        btnMoveUp.Enabled = (tmpSel > 0)
        mnuMoveUp.Enabled = btnMoveUp.Enabled
        btnMoveDown.Enabled = (tmpSel > -1 And tmpSel < getList.Count - 1)
        mnuMoveDown.Enabled = btnMoveDown.Enabled
    End Sub

    Private Sub tv_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        Game.actions.IconKeysInit()

        If tv.SelectedNode Is Nothing Then
            btnNew.Enabled = False
            mnuNew.Enabled = False
            btnPaste.Enabled = False
            mnuPaste.Enabled = False
            getList.Clear()
            UpdateToolbar()
            Exit Sub
        Else
            btnNew.Enabled = (tv.SelectedNode.Tag <> "")
            mnuNew.Enabled = btnNew.Enabled
            btnPaste.Enabled = IIf(CopyAct.Type = 0, False, btnNew.Enabled)
            mnuPaste.Enabled = btnPaste.Enabled
        End If

        'Populate the ListView
        Dim i As Integer
        getList.Clear()
        With Game.actions
            For i = 1 To UBound(.Actions)
                If .Actions(i).Trigger = CurTrigger Then
                    With getList.Add(ItemName(.Actions(i).Action))
                        .ImageIndex = Game.actions.Actions(i).Action.Behavior.Icon
                        .Tag = i
                    End With
                    UpdateFont(getList(getList.Count - 1))
                End If
            Next
        End With
        If getList.Count > 0 Then
            list.Value = 0
        Else
            list.Value = -1
        End If

        UpdateToolbar()

        'Paste and link child actions
        Dim tmpEnabled As Boolean = _
            Not ((tv.SelectedNode Is Clipboard) OrElse _
                (Not CompareNumChildNodes(Clipboard, tv.SelectedNode)))
        MenuItem7.Enabled = tmpEnabled
        MenuItem8.Enabled = tmpEnabled
    End Sub

    Private Function CompareNumChildNodes(ByVal tn1 As TreeNode, ByVal tn2 As TreeNode) As Boolean
        If tn1 Is Nothing Or tn2 Is Nothing Then Return False
        If tn1.GetNodeCount(False) <> tn2.GetNodeCount(False) Then Return False
        If (tn1.Tag = "" And tn2.Tag <> "") Or (tn1.Tag <> "" And tn2.Tag = "") Then Return False
        Dim child1, child2 As TreeNode
        child1 = tn1.FirstNode
        child2 = tn2.FirstNode
        For i As Integer = 1 To tn1.GetNodeCount(False)
            If CompareNumChildNodes(child1, child2) = False Then Return False
            Try
                child1 = child1.NextNode
                child2 = child2.NextNode
            Catch
            End Try
        Next
        Return True
    End Function

    ReadOnly Property CurTrigger() As String
        Get
            Return Trigger(tv.SelectedNode)
        End Get
    End Property

    ReadOnly Property Trigger(ByVal Node As TreeNode) As String
        Get
            Return Node.Tag
        End Get
    End Property

    Sub UpdateCurNode()
        If tv.SelectedNode Is Nothing Then Exit Sub
        'If list.Items.Count > 0 Then
        'tv.SelectedNode.ForeColor = Color.Blue
        'Else
        'tv.SelectedNode.ForeColor = Color.Black
        'End If
        ShowActionsExist(tv.Nodes(0))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OldAct2 As psActions
        OldAct2 = Game.actions.Clone
        Game.actions = OldAct.Clone
        UndoRedo.UpdateUndo(GetString("undoActionEditActions"), UndoRedo.UndoType.All)
        Game.actions = OldAct2.Clone
    End Sub

    Private Sub psfrmActionEditor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DialogResult <> DialogResult.OK Then
            Game.actions = OldAct.Clone
        End If
    End Sub

    Function FindNode(ByVal txt As String, Optional ByVal Node As TreeNode = Nothing) As TreeNode
        If Node Is Nothing Then Node = tv.Nodes(0)
        If Node.Tag = txt Then Return Node
        For Each tn As TreeNode In Node.Nodes
            Dim tmpNode As TreeNode = FindNode(txt, tn)
            If Not (tmpNode Is Nothing) Then Return tmpNode
        Next
        Return Nothing
    End Function

    Dim Clipboard As TreeNode
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        'Copy child actions
        Clipboard = tv.SelectedNode
        tv_AfterSelect(sender, New TreeViewEventArgs(tv.SelectedNode))
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        'Paste child actions
        PerformActionToNodes(Clipboard, tv.SelectedNode, NodeAction.Paste)
        ShowActionsExist(tv.Nodes(0))
        tv_AfterSelect(sender, New TreeViewEventArgs(tv.SelectedNode))
    End Sub

    Enum NodeAction
        Paste
        Link
        Delete
    End Enum

    Private Sub PerformActionToNodes(ByVal source As TreeNode, ByVal dest As TreeNode, ByVal Action As NodeAction)
        Dim child1, child2 As TreeNode
        child1 = source.FirstNode
        child2 = dest.FirstNode
        For i As Integer = 1 To source.GetNodeCount(False)
            PerformActionToNodes(child1, child2, Action)
            Try
                child1 = child1.NextNode
                child2 = child2.NextNode
            Catch
            End Try
        Next
        If dest.Tag <> "" Then
            Select Case Action
                Case NodeAction.Link
                    ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) + 1)
                    With Game.actions.Actions(UBound(Game.actions.Actions))
                        .Action.Type = 1
                        ReDim .Action.param(1)
                        .Action.param(1) = "Game.ExecuteTriggerString(""" & source.Tag & """)"
                        .Trigger = dest.Tag
                    End With
                Case NodeAction.Paste
                    For i As Integer = 1 To UBound(Game.actions.Actions)
                        If Game.actions.Actions(i).Trigger = source.Tag Then
                            ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) + 1)
                            With Game.actions.Actions(UBound(Game.actions.Actions))
                                .Action = Game.actions.Actions(i).Action.Clone
                                .Trigger = dest.Tag
                            End With
                        End If
                    Next
                Case NodeAction.Delete
                    For i As Integer = 1 To UBound(Game.actions.Actions)
                        If i > UBound(Game.actions.Actions) Then Exit For
                        If Game.actions.Actions(i).Trigger = dest.Tag Then
                            For j As Integer = i To UBound(Game.actions.Actions) - 1
                                Game.actions.Actions(j) = Game.actions.Actions(j + 1)
                            Next
                            ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) - 1)
                            i -= 1
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        'Link child actions
        PerformActionToNodes(Clipboard, tv.SelectedNode, NodeAction.Link)
        ShowActionsExist(tv.Nodes(0))
        tv_AfterSelect(sender, New TreeViewEventArgs(tv.SelectedNode))
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        'Delete child actions
        PerformActionToNodes(tv.SelectedNode, tv.SelectedNode, NodeAction.Delete)
        ShowActionsExist(tv.Nodes(0))
        tv_AfterSelect(sender, New TreeViewEventArgs(tv.SelectedNode))
    End Sub

    Sub UpdateFont()
        For i As Integer = 0 To getList.Count - 1
            UpdateFont(getList(i))
        Next
    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnNew))
    End Sub

    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCut.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnCut))
    End Sub

    Private Sub mnuCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnCopy))
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnPaste))
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnDelete))
    End Sub

    Private Sub mnuMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMoveUp.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnMoveUp))
    End Sub

    Private Sub mnuMoveDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMoveDown.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnMoveDown))
    End Sub

    Private Sub mnuTimers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTimers.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnTimers))
    End Sub

    Private Sub mnuCounters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCounters.Click
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnCounters))
    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Button1_Click(sender, New EventArgs)
        DialogResult = DialogResult.OK
    End Sub

    Private Sub mnuDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDiscard.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        'Globals
        Dim f As New psfrmScriptEditor
        f.ShowDialog(True)
        Game.actions.Globals = f.txtMScript.Text
        f.Dispose()
    End Sub

    Private ReadOnly Property getList() As ActionList
        Get
            Return DirectCast(list.Internal, ActionList)
        End Get
    End Property

    Private Sub OnUpdateList()
        Dim tmpIndent As Integer
        For i As Integer = 0 To getList.Count - 1
            If getList(i).ImageIndex > -1 Then
                If psActions.ActIconKeys(getList(i).ImageIndex) = "Code Block" Then
                    getList(i).Indent = tmpIndent
                    tmpIndent += 1
                ElseIf psActions.ActIconKeys(getList(i).ImageIndex) = "Code Block Item" Then
                    tmpIndent -= 1
                    getList(i).Indent = tmpIndent
                    tmpIndent += 1
                ElseIf psActions.ActIconKeys(getList(i).ImageIndex) = "Code Block End" Then
                    tmpIndent -= 1
                    getList(i).Indent = tmpIndent
                Else
                    getList(i).Indent = tmpIndent
                End If
            End If
        Next
        If tmpIndent < 0 Then
            lblIndentError.Text = GetString("actionEd_CodeBlockWarning")
        ElseIf tmpIndent > 0 Then
            lblIndentError.Text = GetString("actionEd_CodeBlockNotOpenWarning")
        End If
        lblIndentError.Visible = (tmpIndent <> 0)
    End Sub

    Private Sub list_DraggedItem(ByVal item As Integer) Handles list.DraggedItem
        Dim amt As Integer = 0
        If item > list.Value Then
            amt = item - list.Value - 1
        ElseIf item < list.Value Then
            amt = item - list.Value
        End If
        For i As Integer = 1 To Math.Abs(amt)
            MoveAction(Math.Sign(amt), list.Value)
        Next
        UpdateFont()
    End Sub

    Private Sub ctxNewAxn_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxNewAxn.Popup

    End Sub

    Private Sub LoadAxnMenu()
        With Game.actions.Dat
            Dim abbr() As String = {"", "Game", "Counters", "Camera", "Character", "Map", "Drawing", "Scripting", "Misc."}
            For n As Integer = 0 To 8
                For i As Integer = 1 To UBound(.ab)
                    If n = 0 OrElse .ab(i).Description = abbr(n) Then
                        AddActionMenuItem(i, ctxNewAxn.MenuItems(n))
                    End If
                Next
            Next
            AddActionMenuItem(1, ctxNewAxn) 'Execute Script
        End With
    End Sub

    Private Sub AddActionMenuItem(ByVal i As Integer, ByVal parent As Menu)
        With Game.actions.Dat
            Dim mi As New TaggedMenuItem(.ab(i).Name, New EventHandler(AddressOf ClickedNewAxnItem))
            mi.Tag = i
            UIPlusMenu1.SetImageIndex(mi, Game.actions.Dat.ab(i).Icon)
            parent.MenuItems.Add(mi)
        End With
    End Sub

    Private Sub ClickedNewAxnItem(ByVal sender As Object, ByVal e As EventArgs)
        tmpAxnType = DirectCast(sender, TaggedMenuItem).Tag
        tmpNewAxnShowDialog = False
        tbrMain_ButtonClick(sender, New ToolBarButtonClickEventArgs(btnNew))

        Dim curAct As psActions.psAction = Game.actions.Actions(getList(list.Value).Tag)
        If tmpAxnType = 1 Then
            'Execute script
            Dim f As New psfrmScriptEditor
            f.ShowDialog(Game.actions.Actions(getList(list.Value).Tag).Action.param(1), curAct.Trigger)
            Game.actions.Globals = f.txtMScript.Text
            f.Dispose()
            With Game.actions.Actions(getList(list.Value).Tag)
                getList(list.Value).Text = (ItemName(.Action))
            End With
        ElseIf UBound(curAct.Action.param) > 0 Then
            list_DoubleClick(Nothing, Nothing)
        End If

        tmpAxnType = 1
        tmpNewAxnShowDialog = True
    End Sub
End Class

Class TaggedMenuItem
    Inherits MenuItem

    Public Shadows Tag As String

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal text As String, ByVal onClick As EventHandler)
        MyBase.New(text, onClick)
    End Sub
End Class