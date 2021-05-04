Imports PlatformStudio

Public Class frmWindowEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.mnuFile.Text = GetString("fileMenu")
        Me.mnuSave.Text = GetString("fileSaveMenu")
        Me.mnuSaveAs.Text = GetString("fileSaveAsMenu")
        Me.mnuExit.Text = GetString("fileCloseMenu")
        Me.mnuEdit.Text = GetString("editMenu")
        Me.mnuUndo.Text = GetString("editUndoMenu")
        Me.mnuRedo.Text = GetString("editRedoMenu")
        Me.mnuCut.Text = GetString("editCutMenu")
        Me.mnuCopy.Text = GetString("editCopyMenu")
        Me.mnuPaste.Text = GetString("editPasteMenu")
        Me.mnuDelete.Text = GetString("editDeleteMenu")
        Me.mnuSelectAll.Text = GetString("editSelectAllMenu")
        Me.mnuDeselect.Text = GetString("editDeselectMenu")
        Me.MenuItem13.Text = GetString("editWindowPropertiesMenu")
        Me.MenuItem14.Text = GetString("editWindowBackgroundMenu")
        Me.MenuItem17.Text = GetString("editWindowMusicMenu")
        Me.MenuItem19.Text = GetString("editWindowTransitionMenu")
        Me.mnuCtrlProp.Text = GetString("editControlPropertiesMenu")
        Me.mnuView.Text = GetString("viewMenu")
        Me.MenuItem1.Text = GetString("viewGridMenu")
        Me.MenuItem3.Text = GetString("viewToolbarMenu")
        Me.MenuItem6.Text = GetString("viewStatusBarMenu")
        Me.MenuItem7.Text = GetString("viewControlSelectorMenu")
        Me.MenuItem8.Text = GetString("viewWindowsPanelMenu")
        Me.MenuItem28.Text = GetString("viewPropertiesPanelMenu")
        Me.mnuFormat.Text = GetString("formatMenu")
        Me.mnuBTF.Text = GetString("formatBringToFrontMenu")
        Me.mnuSTB.Text = GetString("formatSendToBackMenu")
        Me.mnuCHoriz.Text = GetString("formatCenterHMenu")
        Me.mnuCVert.Text = GetString("formatCenterVMenu")
        Me.mnuAlignToGrid.Text = GetString("formatAlignToGridMenu")
        Me.mnuTools.Text = GetString("toolsMenu")
        Me.MenuItem15.Text = GetString("toolsWindowSchemeWizardMenu")
        Me.mnuActionEdit.Text = GetString("toolsLevelEditorMenu")
        Me.MenuItem11.Text = GetString("toolsOptionsMenu")
        Me.mnuHelp.Text = GetString("helpMenu")
        Me.MenuItem18.Text = GetString("helpShowHelpMenu")
        Me.MenuItem24.Text = GetString("helpOnTheWebMenu")
        Me.MenuItem25.Text = GetString("helpForumsMenu")
        Me.MenuItem26.Text = GetString("helpSupportMenu")
        Me.mnuAbout.Text = GetString("helpAboutMenu")
        Me.DockControl1.Text = GetString("winEd_WindowsPanelTitle")
        Me.DockControl2.Text = GetString("propertiesPanelTitle")
        Me.DockControl3.Text = GetString("winEd_ControlsPanelTitle")
        Me.btnSave.ToolTipText = GetString("saveIconTooltip")
        Me.btnUndo.ToolTipText = GetString("undoIconTooltip")
        Me.btnRedo.ToolTipText = GetString("redoIconTooltip")
        Me.btnCut.ToolTipText = GetString("cutIconTooltip")
        Me.btnCopy.ToolTipText = GetString("copyIconTooltip")
        Me.btnPaste.ToolTipText = GetString("pasteIconTooltip")
        Me.btnDelete.ToolTipText = GetString("deleteIconTooltip")
        Me.btnBTF.ToolTipText = GetString("bringToFrontIconTooltip")
        Me.btnSTB.ToolTipText = GetString("sendToBackIconTooltip")
        Me.btnHelp.ToolTipText = GetString("helpIconTooltip")
        Me.btnWeb.ToolTipText = GetString("onTheWebIconTooltip")
        Me.btnForums.ToolTipText = GetString("forumsIconTooltip")
        Me.Text = String.Format(GetString("winEd_Title"), PlatformStudio.AssemblyVersion)
        UIPlusMenu1.SetImageList(iml)
        UIPlusMenu1.Initialize(Me, MainMenu1, ContextMenu1)
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRedo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselect As System.Windows.Forms.MenuItem
    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuActionEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormat As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCHoriz As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCVert As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAlignToGrid As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents pswin As psWinEditor
    Friend WithEvents PsWinControls1 As psTileSelector
    Friend WithEvents PsWinSelector1 As psWinSelector
    Friend WithEvents PsWinStatus1 As psWinStatus
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBTF As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSTB As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCtrlProp As System.Windows.Forms.MenuItem
    Friend WithEvents UIPlusMenu1 As UIPlus.UIPlusMenu
    Friend WithEvents DockHost1 As DockingSuite.DockHost
    Friend WithEvents DockPanel1 As DockingSuite.DockPanel
    Friend WithEvents DockPanel2 As DockingSuite.DockPanel
    Friend WithEvents DockControl1 As DockingSuite.DockControl
    Friend WithEvents DockControl2 As DockingSuite.DockControl
    Friend WithEvents DockHost2 As DockingSuite.DockHost
    Friend WithEvents DockPanel3 As DockingSuite.DockPanel
    Friend WithEvents DockControl3 As DockingSuite.DockControl
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As ToolBarButton
    Friend WithEvents btnSep1 As ToolBarButton
    Friend WithEvents btnUndo As ToolBarButton
    Friend WithEvents btnRedo As ToolBarButton
    Friend WithEvents btnSep2 As ToolBarButton
    Friend WithEvents btnCut As ToolBarButton
    Friend WithEvents btnCopy As ToolBarButton
    Friend WithEvents btnPaste As ToolBarButton
    Friend WithEvents btnDelete As ToolBarButton
    Friend WithEvents btnSep3 As ToolBarButton
    Friend WithEvents btnBTF As ToolBarButton
    Friend WithEvents btnSTB As ToolBarButton
    Friend WithEvents btnSep4 As ToolBarButton
    Friend WithEvents btnHelp As ToolBarButton
    Friend WithEvents btnWeb As ToolBarButton
    Friend WithEvents btnForums As ToolBarButton
    Friend WithEvents tbrMain As UIPlus.UIPlusToolbar
    Public WithEvents imlCtrls As System.Windows.Forms.ImageList
    Friend WithEvents ctlprop As psControlProperties
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWindowEditor))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.mnuEdit = New System.Windows.Forms.MenuItem
        Me.mnuUndo = New System.Windows.Forms.MenuItem
        Me.mnuRedo = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuCut = New System.Windows.Forms.MenuItem
        Me.mnuCopy = New System.Windows.Forms.MenuItem
        Me.mnuPaste = New System.Windows.Forms.MenuItem
        Me.mnuDelete = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuDeselect = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.mnuCtrlProp = New System.Windows.Forms.MenuItem
        Me.mnuView = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.mnuFormat = New System.Windows.Forms.MenuItem
        Me.mnuBTF = New System.Windows.Forms.MenuItem
        Me.mnuSTB = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.mnuCHoriz = New System.Windows.Forms.MenuItem
        Me.mnuCVert = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnuAlignToGrid = New System.Windows.Forms.MenuItem
        Me.mnuTools = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.mnuActionEdit = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.PsWinControls1 = New psTileSelector
        Me.PsWinSelector1 = New psWinSelector
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.pswin = New psWinEditor
        Me.PsWinStatus1 = New psWinStatus
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UIPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.DockHost1 = New DockingSuite.DockHost
        Me.DockPanel1 = New DockingSuite.DockPanel
        Me.DockControl1 = New DockingSuite.DockControl
        Me.DockPanel2 = New DockingSuite.DockPanel
        Me.DockControl2 = New DockingSuite.DockControl
        Me.ctlprop = New psControlProperties
        Me.DockHost2 = New DockingSuite.DockHost
        Me.DockPanel3 = New DockingSuite.DockPanel
        Me.DockControl3 = New DockingSuite.DockControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbrMain = New UIPlus.UIPlusToolbar
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton
        Me.btnUndo = New System.Windows.Forms.ToolBarButton
        Me.btnRedo = New System.Windows.Forms.ToolBarButton
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton
        Me.btnCut = New System.Windows.Forms.ToolBarButton
        Me.btnCopy = New System.Windows.Forms.ToolBarButton
        Me.btnPaste = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnSep3 = New System.Windows.Forms.ToolBarButton
        Me.btnBTF = New System.Windows.Forms.ToolBarButton
        Me.btnSTB = New System.Windows.Forms.ToolBarButton
        Me.btnSep4 = New System.Windows.Forms.ToolBarButton
        Me.btnHelp = New System.Windows.Forms.ToolBarButton
        Me.btnWeb = New System.Windows.Forms.ToolBarButton
        Me.btnForums = New System.Windows.Forms.ToolBarButton
        Me.imlCtrls = New System.Windows.Forms.ImageList(Me.components)
        Me.DockHost1.SuspendLayout()
        Me.DockPanel1.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.DockPanel2.SuspendLayout()
        Me.DockControl2.SuspendLayout()
        Me.DockHost2.SuspendLayout()
        Me.DockPanel3.SuspendLayout()
        Me.DockControl3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuFormat, Me.mnuTools, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSave, Me.mnuSaveAs, Me.MenuItem20, Me.mnuExit})

        '
        'mnuSave
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuSave, 2)
        Me.mnuSave.Index = 0
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS

        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 1

        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 2
        Me.MenuItem20.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 3

        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUndo, Me.mnuRedo, Me.MenuItem5, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.mnuDelete, Me.MenuItem10, Me.mnuSelectAll, Me.mnuDeselect, Me.MenuItem12, Me.MenuItem13, Me.MenuItem21, Me.MenuItem14, Me.MenuItem17, Me.MenuItem19, Me.MenuItem27, Me.mnuCtrlProp})

        '
        'mnuUndo
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuUndo, 3)
        Me.mnuUndo.Index = 0
        Me.mnuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ

        '
        'mnuRedo
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuRedo, 4)
        Me.mnuRedo.Index = 1
        Me.mnuRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY

        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "-"
        '
        'mnuCut
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuCut, 5)
        Me.mnuCut.Index = 3
        Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX

        '
        'mnuCopy
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuCopy, 6)
        Me.mnuCopy.Index = 4
        Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC

        '
        'mnuPaste
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuPaste, 7)
        Me.mnuPaste.Index = 5
        Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV

        '
        'mnuDelete
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuDelete, 8)
        Me.mnuDelete.Index = 6
        Me.mnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del

        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 7
        Me.MenuItem10.Text = "-"
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 8
        Me.mnuSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA

        '
        'mnuDeselect
        '
        Me.mnuDeselect.Index = 9
        Me.mnuDeselect.Shortcut = System.Windows.Forms.Shortcut.CtrlD

        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 10
        Me.MenuItem12.Text = "-"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 11

        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 12
        Me.MenuItem21.Text = "-"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 13
        Me.MenuItem14.Shortcut = System.Windows.Forms.Shortcut.F2

        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 14
        Me.MenuItem17.Shortcut = System.Windows.Forms.Shortcut.F3

        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 15
        Me.MenuItem19.Shortcut = System.Windows.Forms.Shortcut.F4

        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 16
        Me.MenuItem27.Text = "-"
        '
        'mnuCtrlProp
        '
        Me.mnuCtrlProp.Index = 17

        '
        'mnuView
        '
        Me.mnuView.Index = 2
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem28})

        '
        'MenuItem1
        '
        Me.MenuItem1.Checked = True
        Me.MenuItem1.Index = 0

        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'MenuItem3
        '
        Me.MenuItem3.Checked = True
        Me.MenuItem3.Index = 2

        '
        'MenuItem6
        '
        Me.MenuItem6.Checked = True
        Me.MenuItem6.Index = 3

        '
        'MenuItem7
        '
        Me.MenuItem7.Checked = True
        Me.MenuItem7.Index = 4

        '
        'MenuItem8
        '
        Me.MenuItem8.Checked = True
        Me.MenuItem8.Index = 5

        '
        'MenuItem28
        '
        Me.MenuItem28.Checked = True
        Me.MenuItem28.Index = 6

        '
        'mnuFormat
        '
        Me.mnuFormat.Index = 3
        Me.mnuFormat.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuBTF, Me.mnuSTB, Me.MenuItem29, Me.mnuCHoriz, Me.mnuCVert, Me.MenuItem4, Me.mnuAlignToGrid})

        '
        'mnuBTF
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuBTF, 15)
        Me.mnuBTF.Index = 0
        Me.mnuBTF.Shortcut = System.Windows.Forms.Shortcut.CtrlF

        '
        'mnuSTB
        '
        Me.UIPlusMenu1.SetImageIndex(Me.mnuSTB, 16)
        Me.mnuSTB.Index = 1
        Me.mnuSTB.Shortcut = System.Windows.Forms.Shortcut.CtrlB

        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 2
        Me.MenuItem29.Text = "-"
        '
        'mnuCHoriz
        '
        Me.mnuCHoriz.Index = 3
        Me.mnuCHoriz.Shortcut = System.Windows.Forms.Shortcut.CtrlH

        '
        'mnuCVert
        '
        Me.mnuCVert.Index = 4
        Me.mnuCVert.Shortcut = System.Windows.Forms.Shortcut.CtrlK

        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 5
        Me.MenuItem4.Text = "-"
        '
        'mnuAlignToGrid
        '
        Me.mnuAlignToGrid.Index = 6

        '
        'mnuTools
        '
        Me.mnuTools.Index = 4
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem16, Me.mnuActionEdit, Me.MenuItem9, Me.MenuItem11})

        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0

        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "-"
        '
        'mnuActionEdit
        '
        Me.mnuActionEdit.Index = 2

        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "-"
        '
        'MenuItem11
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem11, 18)
        Me.MenuItem11.Index = 4

        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 5
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem18, Me.MenuItem22, Me.MenuItem24, Me.MenuItem25, Me.MenuItem26, Me.MenuItem23, Me.mnuAbout})

        '
        'MenuItem18
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem18, 13)
        Me.MenuItem18.Index = 0
        Me.MenuItem18.Shortcut = System.Windows.Forms.Shortcut.F1

        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 1
        Me.MenuItem22.Text = "-"
        '
        'MenuItem24
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem24, 11)
        Me.MenuItem24.Index = 2

        '
        'MenuItem25
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem25, 12)
        Me.MenuItem25.Index = 3

        '
        'MenuItem26
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem26, 17)
        Me.MenuItem26.Index = 4

        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 5
        Me.MenuItem23.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 6

        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(16, 16)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'PsWinControls1
        '
        Me.PsWinControls1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PsWinControls1.Location = New System.Drawing.Point(0, 0)
        Me.PsWinControls1.Name = "PsWinControls1"
        Me.PsWinControls1.Size = New System.Drawing.Size(158, 436)
        Me.PsWinControls1.TabIndex = 0
        Me.PsWinControls1.Value = 0
        '
        'PsWinSelector1
        '
        Me.PsWinSelector1.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(228, Byte), CType(214, Byte))
        Me.PsWinSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PsWinSelector1.Location = New System.Drawing.Point(0, 0)
        Me.PsWinSelector1.Name = "PsWinSelector1"
        Me.PsWinSelector1.Size = New System.Drawing.Size(204, 134)
        Me.PsWinSelector1.TabIndex = 1
        Me.PsWinSelector1.Value = 0
        '
        'pswin
        '
        Me.pswin.ContextMenu = Me.ContextMenu1
        Me.pswin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pswin.Location = New System.Drawing.Point(162, 26)
        Me.pswin.Name = "pswin"
        Me.pswin.Size = New System.Drawing.Size(390, 479)
        Me.pswin.TabIndex = 22
        '
        'PsWinStatus1
        '
        Me.PsWinStatus1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PsWinStatus1.Location = New System.Drawing.Point(0, 505)
        Me.PsWinStatus1.Name = "PsWinStatus1"
        Me.PsWinStatus1.Size = New System.Drawing.Size(760, 16)
        Me.PsWinStatus1.TabIndex = 23
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'UIPlusMenu1
        '
        Me.UIPlusMenu1.CustomColorScheme = Nothing
        '
        'DockHost1
        '
        Me.DockHost1.Controls.Add(Me.DockPanel1)
        Me.DockHost1.Controls.Add(Me.DockPanel2)
        Me.DockHost1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockHost1.Location = New System.Drawing.Point(552, 26)
        Me.DockHost1.Name = "DockHost1"
        Me.DockHost1.Size = New System.Drawing.Size(208, 479)
        Me.DockHost1.TabIndex = 24
        '
        'DockPanel1
        '
        Me.DockPanel1.AutoHide = False
        Me.DockPanel1.Controls.Add(Me.DockControl1)
        Me.DockPanel1.DockedHeight = 180
        Me.DockPanel1.DockedWidth = 0
        Me.DockPanel1.Location = New System.Drawing.Point(4, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.SelectedTab = Me.DockControl1
        Me.DockPanel1.Size = New System.Drawing.Size(204, 177)
        Me.DockPanel1.TabIndex = 0
        Me.DockPanel1.Text = "Docked Panel"
        '
        'DockControl1
        '
        Me.DockControl1.Controls.Add(Me.PsWinSelector1)
        Me.DockControl1.Guid = New System.Guid("488d955c-0d3a-48c9-9226-8c811df01528")
        Me.DockControl1.Location = New System.Drawing.Point(0, 20)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.PrimaryControl = Nothing
        Me.DockControl1.Size = New System.Drawing.Size(204, 134)
        Me.DockControl1.TabImage = Nothing
        Me.DockControl1.TabIndex = 0

        '
        'DockPanel2
        '
        Me.DockPanel2.AutoHide = False
        Me.DockPanel2.Controls.Add(Me.DockControl2)
        Me.DockPanel2.DockedHeight = 299
        Me.DockPanel2.DockedWidth = 0
        Me.DockPanel2.Location = New System.Drawing.Point(4, 180)
        Me.DockPanel2.Name = "DockPanel2"
        Me.DockPanel2.SelectedTab = Me.DockControl2
        Me.DockPanel2.Size = New System.Drawing.Size(204, 299)
        Me.DockPanel2.TabIndex = 1
        Me.DockPanel2.Text = "Docked Panel"
        '
        'DockControl2
        '
        Me.DockControl2.Controls.Add(Me.ctlprop)
        Me.DockControl2.Guid = New System.Guid("9ddd5592-9c41-4865-a094-b4494a8a0e78")
        Me.DockControl2.Location = New System.Drawing.Point(0, 20)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.PrimaryControl = Nothing
        Me.DockControl2.Size = New System.Drawing.Size(204, 256)
        Me.DockControl2.TabImage = Nothing
        Me.DockControl2.TabIndex = 0

        '
        'ctlprop
        '
        Me.ctlprop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlprop.Location = New System.Drawing.Point(0, 0)
        Me.ctlprop.Name = "ctlprop"
        Me.ctlprop.Size = New System.Drawing.Size(204, 256)
        Me.ctlprop.TabIndex = 1
        '
        'DockHost2
        '
        Me.DockHost2.Controls.Add(Me.DockPanel3)
        Me.DockHost2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockHost2.Location = New System.Drawing.Point(0, 26)
        Me.DockHost2.Name = "DockHost2"
        Me.DockHost2.Size = New System.Drawing.Size(162, 479)
        Me.DockHost2.TabIndex = 25
        '
        'DockPanel3
        '
        Me.DockPanel3.AutoHide = False
        Me.DockPanel3.Controls.Add(Me.DockControl3)
        Me.DockPanel3.DockedHeight = 479
        Me.DockPanel3.DockedWidth = 0
        Me.DockPanel3.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel3.Name = "DockPanel3"
        Me.DockPanel3.SelectedTab = Me.DockControl3
        Me.DockPanel3.Size = New System.Drawing.Size(158, 479)
        Me.DockPanel3.TabIndex = 0
        Me.DockPanel3.Text = "Docked Panel"
        '
        'DockControl3
        '
        Me.DockControl3.Controls.Add(Me.PsWinControls1)
        Me.DockControl3.Guid = New System.Guid("19f684f1-46fa-46bb-b8d8-191032d4cb71")
        Me.DockControl3.Location = New System.Drawing.Point(0, 20)
        Me.DockControl3.Name = "DockControl3"
        Me.DockControl3.PrimaryControl = Nothing
        Me.DockControl3.Size = New System.Drawing.Size(158, 436)
        Me.DockControl3.TabImage = Nothing
        Me.DockControl3.TabIndex = 0

        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbrMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 26)
        Me.Panel1.TabIndex = 26
        '
        'tbrMain
        '
        Me.tbrMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnSave, Me.btnSep1, Me.btnUndo, Me.btnRedo, Me.btnSep2, Me.btnCut, Me.btnCopy, Me.btnPaste, Me.btnDelete, Me.btnSep3, Me.btnBTF, Me.btnSTB, Me.btnSep4, Me.btnHelp, Me.btnWeb, Me.btnForums})
        Me.tbrMain.CustomColorScheme = Nothing
        Me.tbrMain.Divider = False
        Me.tbrMain.DropDownArrows = True
        Me.tbrMain.ImageList = Me.iml
        Me.tbrMain.Location = New System.Drawing.Point(0, 0)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.ShowToolTips = True
        Me.tbrMain.Size = New System.Drawing.Size(760, 26)
        Me.tbrMain.TabIndex = 0
        Me.tbrMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 2

        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.ImageIndex = 3

        '
        'btnRedo
        '
        Me.btnRedo.Enabled = False
        Me.btnRedo.ImageIndex = 4

        '
        'btnSep2
        '
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCut
        '
        Me.btnCut.ImageIndex = 5

        '
        'btnCopy
        '
        Me.btnCopy.ImageIndex = 6

        '
        'btnPaste
        '
        Me.btnPaste.ImageIndex = 7

        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 8

        '
        'btnSep3
        '
        Me.btnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBTF
        '
        Me.btnBTF.Enabled = False
        Me.btnBTF.ImageIndex = 15

        '
        'btnSTB
        '
        Me.btnSTB.Enabled = False
        Me.btnSTB.ImageIndex = 16

        '
        'btnSep4
        '
        Me.btnSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnHelp
        '
        Me.btnHelp.ImageIndex = 13

        '
        'btnWeb
        '
        Me.btnWeb.ImageIndex = 11

        '
        'btnForums
        '
        Me.btnForums.ImageIndex = 12

        '
        'imlCtrls
        '
        Me.imlCtrls.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imlCtrls.ImageSize = New System.Drawing.Size(20, 20)
        Me.imlCtrls.ImageStream = CType(resources.GetObject("imlCtrls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCtrls.TransparentColor = System.Drawing.Color.White
        '
        'frmWindowEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 521)
        Me.Controls.Add(Me.pswin)
        Me.Controls.Add(Me.DockHost2)
        Me.Controls.Add(Me.DockHost1)
        Me.Controls.Add(Me.PsWinStatus1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(320, 240)
        Me.Name = "frmWindowEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.DockHost1.ResumeLayout(False)
        Me.DockPanel1.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.DockPanel2.ResumeLayout(False)
        Me.DockControl2.ResumeLayout(False)
        Me.DockHost2.ResumeLayout(False)
        Me.DockPanel3.ResumeLayout(False)
        Me.DockControl3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Filenames and Titles"
    Private _BaseTitle As String

    ReadOnly Property BaseTitle() As String
        Get
            Return _BaseTitle
        End Get
    End Property
#End Region

#Region "Loading/Unloading"
    Private Sub frmWindowEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Game Is Nothing Then Exit Sub
        If fGame Is Nothing Then Exit Sub
        AddHandler pswin.CanUndoRedoChanged, AddressOf CanUndoRedoChanged
        AddHandler pswin.CanCopyPasteChanged, AddressOf CanCopyPasteChanged
        _BaseTitle = Me.Text
        fGame.CurFile = fGame.CurFile

        ContextMenu1.MergeMenu(mnuEdit)

        'Set docking controls' options
        SetDefaultColors(DockHost1)
        SetDefaultColors(DockHost2)

        'Setup properties panel
        ControlWrapper.undoType = UndoRedo.UndoType.Windows

        pswin.Init()
        pswin.UnlockUpdate()
        pswin.MakeActive()

        'Init controls list
        PsWinControls1.Init(psTileSelector.SelectorType.Control)
        PsWinControls1.setImageList(imlCtrls)

        ReflectOptions()

        PsWinSelector1.Refresh()
        Timer1.Enabled = True
    End Sub

    Private Sub frmWindowEditor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Enabled = False
        pswin.LockUpdate()
        pswin.MakeInactive()
        pswin.Deselect()
        RemoveHandler pswin.CanUndoRedoChanged, AddressOf CanUndoRedoChanged
        RemoveHandler pswin.CanCopyPasteChanged, AddressOf CanCopyPasteChanged
        DialogResult = DialogResult.Cancel
        Editor.winedit = Nothing
        'UI.psControl.rebuildControlNames()
    End Sub
#End Region

#Region "File Menu"
    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        fGame.Save()
    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        fGame.SaveAs()
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Close()
    End Sub
#End Region

#Region "Edit Menu"
    Private Sub mnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndo.Click
        If pswin.CanUndo Then pswin.Undo()
    End Sub

    Private Sub mnuRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRedo.Click
        If pswin.CanRedo Then pswin.Redo()
    End Sub

    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCut.Click
        If pswin.CanCut Then pswin.Cut()
    End Sub

    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        If pswin.CanCopy Then pswin.Copy()
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        If pswin.CanPaste Then pswin.Paste()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If pswin.CanDelete Then pswin.Delete()
    End Sub

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        pswin.SelectAll()
    End Sub

    Private Sub mnuDeselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselect.Click
        If pswin.CanDeselect Then pswin.Deselect()
    End Sub
#End Region

#Region "Format Menu"
    Private Sub mnuCHoriz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCHoriz.Click
        If Me.pswin.CanCopy() Then pswin.CenterHorizontally()
    End Sub

    Private Sub mnuCVert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCVert.Click
        If Me.pswin.CanCopy() Then pswin.CenterVertically()
    End Sub

    Private Sub mnuAlignToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlignToGrid.Click
        If Me.pswin.CanCopy() Then pswin.AlignToGrid()
    End Sub

    Private Sub mnuBTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBTF.Click
        If Me.pswin.CanCopy() Then pswin.DoBringToFront()
    End Sub

    Private Sub mnuSTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSTB.Click
        If Me.pswin.CanCopy() Then pswin.DoSendToBack()
    End Sub
#End Region

#Region "Tools Menu"
    Private Sub mnuMapEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActionEdit.Click
        Close()
        'fGame.Select()
    End Sub
#End Region

#Region "Help Menu"
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        fGame.mnuAbout_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        frmAbout.Website()
    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        frmAbout.Forums()
    End Sub

    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Click
        frmAbout.Support()
    End Sub
#End Region

#Region "Toolbar Click"
    Private Sub tbrMain_ButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs) Handles tbrMain.ButtonClick
        Select Case True
            Case e.Button Is btnSave
                mnuSave_Click(Nothing, Nothing)
            Case e.Button Is btnUndo
                If pswin.CanUndo Then pswin.Undo()
            Case e.Button Is btnRedo
                If pswin.CanRedo Then pswin.Redo()
            Case e.Button Is btnCut
                If pswin.CanCut Then pswin.Cut()
            Case e.Button Is btnCopy
                If pswin.CanCopy Then pswin.Copy()
            Case e.Button Is btnPaste
                If pswin.CanPaste Then pswin.Paste()
            Case e.Button Is btnDelete
                If pswin.CanDelete Then pswin.Delete()
            Case e.Button Is btnBTF
                mnuBTF_Click(sender, Nothing)
            Case e.Button Is btnSTB
                mnuSTB_Click(sender, Nothing)
            Case e.Button Is btnHelp
                MenuItem18_Click(sender, Nothing)
            Case e.Button Is btnWeb
                MenuItem24_Click(sender, Nothing)
            Case e.Button Is btnForums
                MenuItem25_Click(sender, Nothing)
        End Select
    End Sub
#End Region

#Region "Updating Menus/Toolbars"
    Private Sub CanCopyPasteChanged() Handles pswin.CanCopyPasteChanged
        mnuCut.Enabled = pswin.CanCut
        mnuCopy.Enabled = pswin.CanCopy
        mnuPaste.Enabled = pswin.CanPaste
        mnuDelete.Enabled = pswin.CanDelete
        mnuDeselect.Enabled = pswin.CanDeselect
        mnuCHoriz.Enabled = pswin.CanCopy
        mnuCVert.Enabled = pswin.CanCopy
        mnuBTF.Enabled = pswin.CanCopy
        mnuSTB.Enabled = pswin.CanCopy
        mnuAlignToGrid.Enabled = pswin.CanCopy
        mnuCtrlProp.Enabled = (pswin.NumSelCtrls = 1)
        btnCut.Enabled = pswin.CanCut
        btnCopy.Enabled = pswin.CanCopy
        btnPaste.Enabled = pswin.CanPaste
        btnDelete.Enabled = pswin.CanDelete
        btnBTF.Enabled = pswin.CanCopy
        btnSTB.Enabled = pswin.CanCopy
    End Sub

    Private Sub CanUndoRedoChanged() Handles pswin.CanUndoRedoChanged
        mnuUndo.Enabled = pswin.CanUndo
        mnuUndo.Text = String.Format(GetString("editUndoMenuLong"), pswin.UndoText)
        mnuRedo.Enabled = pswin.CanRedo
        mnuRedo.Text = String.Format(GetString("editRedoMenuLong"), pswin.RedoText)
        btnUndo.Enabled = pswin.CanUndo
        btnUndo.ToolTipText = String.Format(GetString("undoIconTooltipLong"), pswin.UndoText)
        btnRedo.Enabled = pswin.CanRedo
        btnRedo.ToolTipText = String.Format(GetString("redoIconTooltipLong"), pswin.RedoText)
    End Sub
#End Region

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        MenuItem1.Checked = Not MenuItem1.Checked
        PlatformStudio.Options.wShowGrid = MenuItem1.Checked
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        MenuItem3.Checked = Not MenuItem3.Checked
        PlatformStudio.Options.wShowToolbar = MenuItem3.Checked
        Panel1.Visible = MenuItem3.Checked
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        MenuItem6.Checked = Not MenuItem6.Checked
        PlatformStudio.Options.wShowStatusBar = MenuItem6.Checked
        PsWinStatus1.Visible = MenuItem6.Checked
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        MenuItem7.Checked = Not MenuItem7.Checked
        PlatformStudio.Options.wShowControlSelector = MenuItem7.Checked
        DockControlVisible(DockControl3, DockHost2) = MenuItem7.Checked
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        MenuItem8.Checked = Not MenuItem8.Checked
        PlatformStudio.Options.wShowWindowsPanel = MenuItem8.Checked
        DockControlVisible(DockControl1, DockHost1) = MenuItem8.Checked
    End Sub

    Sub ReflectOptions()
        'Change based on user's options
        With PlatformStudio.Options
            MenuItem1.Checked = .wShowGrid
            MenuItem3.Checked = .wShowToolbar
            Panel1.Visible = .wShowToolbar
            MenuItem6.Checked = .wShowStatusBar
            PsWinStatus1.Visible = .wShowStatusBar
            MenuItem7.Checked = .wShowControlSelector
            DockControlVisible(DockControl3, DockHost2) = .wShowControlSelector
            MenuItem8.Checked = .wShowWindowsPanel
            DockControlVisible(DockControl1, DockHost1) = .wShowWindowsPanel
            MenuItem28.Checked = .wShowActionsPanel
            DockControlVisible(DockControl2, DockHost1) = .wShowActionsPanel
            pswin.GridX = .wGridSpacing
            pswin.GridY = .wGridSpacing
            pswin.ms.GridX = .wGridSpacing
            pswin.ms.GridY = .wGridSpacing
        End With
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Dim f As New frmOptions
        f.TabControl1.SelectedIndex = 3
        f.ShowDialog()
        ReflectOptions()
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        Dim f As New frmGameProperties
        f.TabControl1.SelectedIndex = 2
        f.ShowDialog()
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        Dim f As New psfrmBackgroundEditor
        UndoRedo.UpdateUndo(GetString("undoActionEditWindowBackground"), UndoRedo.UndoType.Windows)
        f.ShowDialog(Game.windows.Windows(Game.CurWinIndex).Background, Game.windows.Windows(Game.CurWinIndex).Background)
        ctlprop.prop.Refresh()
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        pswin.Deselect()
        Game.CurWinIndex = 1
        Dim f As New frmNewGameWizard
        f.ShowWindowScheme()
        f.Dispose()
        PsWinSelector1.Refresh()
        ctlprop.prop.Refresh()
    End Sub

    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        Dim f As New psfrmWindowTransition
        f.ShowDialog()
        f.Dispose()
        ctlprop.prop.Refresh()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        Dim f As New frmBackgroundMusic
        f.ShowWindowDialog()
        f.Dispose()
        ctlprop.prop.Refresh()
    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        Process.Start(Game.Root & "\psHelp.chm")
    End Sub

    Dim Titlebar As Titlebar

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Game.Drawing Is Nothing) = False Then
            pswin.Refresh()
        End If
Done:
    End Sub

    Dim b As Boolean

    Private Sub frmWindowEditor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        pswin.Refresh()
    End Sub

    Private Sub mnuCtrlProp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCtrlProp.Click
        pswin.EditControlProperties()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        MenuItem28.Checked = Not MenuItem28.Checked
        PlatformStudio.Options.wShowActionsPanel = MenuItem28.Checked
        DockControlVisible(DockControl2, DockHost1) = MenuItem28.Checked
    End Sub

    Private Sub DockControl1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl1.Closing
        PlatformStudio.Options.wShowWindowsPanel = False
        MenuItem8.Checked = False
    End Sub

    Private Sub DockControl2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl2.Closing
        PlatformStudio.Options.wShowActionsPanel = False
        MenuItem28.Checked = False
    End Sub

    Private Sub DockControl3_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl3.Closing
        PlatformStudio.Options.wShowControlSelector = False
        MenuItem7.Checked = False
    End Sub

    Private Sub DockPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DockPanel1.Paint, DockPanel2.Paint, DockPanel3.Paint, DockHost1.Paint, DockHost2.Paint
        e.Graphics.Clear(UIPlus.DefaultColorScheme.getInstance.MenuBack)
    End Sub

    Private Sub pswin_UpdateSelection() Handles pswin.UpdateSelection
        Editor.winedit.GetSelCtrls()
        If Editor.winedit.NumSelCtrls > 0 Then
            Dim selObj(Editor.winedit.NumSelCtrls - 1) As PropDispNameWrapper
            For i As Integer = 0 To Editor.winedit.NumSelCtrls - 1
                Dim wrapper As ControlWrapper
                Dim ctl As psUI.psControl = Editor.winedit.SelCtrls(i + 1)
                Select Case ctl.Type
                    Case psUI.psControl.psCtrlType.Button
                        wrapper = New ButtonWrapper(ctl)
                    Case psUI.psControl.psCtrlType.GameArea
                        wrapper = New GameEditorWrapper(ctl)
                    Case psUI.psControl.psCtrlType.HighScoresArea
                        wrapper = New HighScoresWrapper(ctl)
                    Case psUI.psControl.psCtrlType.Label
                        wrapper = New LabelWrapper(ctl)
                    Case psUI.psControl.psCtrlType.Image
                        wrapper = New ImageWrapper(ctl)
                    Case psUI.psControl.psCtrlType.Movie
                        wrapper = New MovieWrapper(ctl)
                    Case psUI.psControl.psCtrlType.TextCounter
                        wrapper = New TextCounterWrapper(ctl)
                    Case psUI.psControl.psCtrlType.ImageTextCounter
                        wrapper = New ImageTextCounterWrapper(ctl)
                    Case psUI.psControl.psCtrlType.ImageCounter
                        wrapper = New ImageCounterWrapper(ctl)
                    Case Else
                        wrapper = New ControlWrapper(ctl)
                End Select
                wrapper.index = i
                wrapper.p = ctlprop.prop
                selObj(i) = New PropDispNameWrapper(wrapper)
            Next
            If selObj.Length = 0 Then
                ctlprop.prop.SelectedObject = Nothing
            Else
                DynamicReadOnly.SetValue("ButtonWrapper.Action", (selObj.Length > 1))
                ctlprop.prop.SelectedObjects = selObj
            End If
        Else
            Dim wrapper As New WindowWrapper(Game.CurWindow)
            wrapper.index = 0
            wrapper.p = ctlprop.prop
            ctlprop.prop.SelectedObject = New PropDispNameWrapper(wrapper)
        End If
    End Sub

    Private Sub ctlprop_PropertyValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles ctlprop.PropertyValueChanged
        ControlWrapper.shouldUpdateUndo = True
    End Sub

    Private Sub pswin_DoubleClickControl() Handles pswin.DoubleClickControl
        If Not Options.wShowActionsPanel Then
            Options.wShowActionsPanel = True
            ReflectOptions()
        End If
        ctlprop.Focus()
    End Sub
End Class