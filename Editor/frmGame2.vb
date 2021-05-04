Public Class frmGame
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Password for UI controls
        UIPlus.ColorOp.Invert(Color.FromArgb(1871549307))

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        EnableMenus(False)
        Me.dlgOpen.Filter = GetString("gameFileFilter")
        Me.dlgSave.Filter = GetString("gameFileFilter")
        Me.mnuFile.Text = GetString("fileMenu")
        Me.mnuNew.Text = GetString("fileNewMenu")
        Me.mnuWizard.Text = GetString("fileNewWizardMenu")
        Me.mnuOpen.Text = GetString("fileOpenMenu")
        Me.mnuSave.Text = GetString("fileSaveMenu")
        Me.mnuSaveAs.Text = GetString("fileSaveAsMenu")
        Me.MenuItem20.Text = GetString("fileGamePropertiesMenu")
        Me.mnuCompile.Text = GetString("fileCompileMenu")
        Me.mnuExit.Text = GetString("fileExitMenu")
        Me.mnuEdit.Text = GetString("editMenu")
        Me.mnuUndo.Text = GetString("editUndoMenu")
        Me.mnuRedo.Text = GetString("editRedoMenu")
        Me.mnuCut.Text = GetString("editCutMenu")
        Me.mnuCopy.Text = GetString("editCopyMenu")
        Me.mnuPaste.Text = GetString("editPasteMenu")
        Me.mnuDelete.Text = GetString("editDeleteMenu")
        Me.mnuSelectAll.Text = GetString("editSelectAllMenu")
        Me.mnuDeselect.Text = GetString("editDeselectMenu")
        Me.mnuReplace.Text = GetString("editFindReplaceTilesMenu")
        Me.mnuResize.Text = GetString("editResizeLevelMenu")
        Me.MenuItem36.Text = GetString("editLevelBackgroundMenu")
        Me.MenuItem35.Text = GetString("editBackgroundMusicMenu")
        Me.mnuView.Text = GetString("viewMenu")
        Me.MenuItem12.Text = GetString("viewGridMenu")
        Me.MenuItem17.Text = GetString("viewToolbarsMenu")
        Me.MenuItem15.Text = GetString("viewStatusBarMenu")
        Me.MenuItem16.Text = GetString("viewTileSelectorMenu")
        Me.MenuItem18.Text = GetString("viewLayersPanelMenu")
        Me.MenuItem38.Text = GetString("viewLevelsPanelMenu")
        Me.MenuItem39.Text = GetString("viewPropertiesPanelMenu")
        Me.MenuItem21.Text = GetString("runMenu")
        Me.MenuItem23.Text = GetString("runStartMenu")
        Me.mnuStartInSeparateProcess.Text = GetString("runStartInSeparateProcessMenu")
        Me.mnuStartInSeparateProcess.Visible = False
        Me.MenuItem24.Text = GetString("runStopMenu")
        Me.MenuItem33.Text = GetString("runRestartMenu")
        Me.MenuItem26.Text = GetString("runDebuggingOptionsMenu")
        Me.mnuSkipWindows.Text = GetString("runSkipWindowsMenu")
        Me.mnuInvincible.Text = GetString("runMakeInvincibleMenu")
        Me.mnuStartAtLevel.Text = GetString("runStartAtLevelMenu")
        Me.MenuItem37.Text = GetString("runShowFPSMenu")
        Me.mnuTools.Text = GetString("toolsMenu")
        Me.mnuTileset.Text = GetString("toolsTilesetEditorMenu")
        Me.mnuActionEdit.Text = GetString("toolsActionEditorMenu")
        Me.MenuItem1.Text = GetString("toolsWindowEditorMenu")
        Me.MenuItem11.Text = GetString("toolsOptionsMenu")
        Me.mnuHelp.Text = GetString("helpMenu")
        Me.MenuItem32.Text = GetString("helpShowHelpMenu")
        Me.MenuItem30.Text = GetString("helpOnTheWebMenu")
        Me.MenuItem29.Text = GetString("helpForumsMenu")
        Me.MenuItem28.Text = GetString("helpSupportMenu")
        Me.MenuItem40.Text = GetString("helpCheckForUpdatesMenu")
        Me.mnuAbout.Text = GetString("helpAboutMenu")
        Me.mnuUpgrade.Text = GetString("helpUpgradeMenu")
        Me.DockControl1.Text = GetString("layersPanelTitle")
        Me.DockControl2.Text = GetString("levelsPanelTitle")
        Me.DockControl3.Text = GetString("propertiesPanelTitle")
        Me.MenuItem4.Text = GetString("editUndoMenu")
        Me.MenuItem6.Text = GetString("editRedoMenu")
        Me.MenuItem2.Text = GetString("pathCopyPointMenu")
        Me.MenuItem3.Text = GetString("pathDeletePointMenu")
        Me.DockControl4.Text = GetString("tilesPanelTitle")
        Me.btnNew.ToolTipText = GetString("newIconTooltip")
        Me.btnOpen.ToolTipText = GetString("openIconTooltip")
        Me.btnSave.ToolTipText = GetString("saveIconTooltip")
        Me.btnUndo.ToolTipText = GetString("undoIconTooltip")
        Me.btnRedo.ToolTipText = GetString("redoIconTooltip")
        Me.btnCut.ToolTipText = GetString("cutIconTooltip")
        Me.btnCopy.ToolTipText = GetString("copyIconTooltip")
        Me.btnPaste.ToolTipText = GetString("pasteIconTooltip")
        Me.btnDelete.ToolTipText = GetString("deleteIconTooltip")
        Me.btnRun.ToolTipText = GetString("runIconTooltip")
        Me.btnStop.ToolTipText = GetString("stopIconTooltip")
        Me.btnRestart.ToolTipText = GetString("restartIconTooltip")
        Me.btnHelp.ToolTipText = GetString("helpIconTooltip")
        Me.btnWeb.ToolTipText = GetString("onTheWebIconTooltip")
        Me.btnForums.ToolTipText = GetString("forumsIconTooltip")
        Me.btnToolDraw.Text = GetString("drawToolIconText")
        Me.btnToolDraw.ToolTipText = GetString("drawToolIconTooltip")
        Me.btnToolErase.ToolTipText = GetString("eraseToolIconTooltip")
        Me.btnToolErase.Text = GetString("eraseToolIconText")
        Me.btnToolSelect.Text = GetString("selectToolIconText")
        Me.btnToolSelect.ToolTipText = GetString("selectToolIconTooltip")
        Me.btnToolPan.Text = GetString("panToolIconText")
        Me.btnToolPan.ToolTipText = GetString("panToolIconTooltip")
        Me.Text = String.Format(GetString("main_Title"), PlatformStudio.AssemblyVersion)
        UiPlusMenu1.SetImageList(iml)
        UiPlusMenu1.Initialize(Me, MainMenu1, ContextMenu1, mnuPathEdit)
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
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRedo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselect As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReplace As System.Windows.Forms.MenuItem
    Friend WithEvents mnuResize As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTileset As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents PsStatus1 As psStatus
    Friend WithEvents mnuActionEdit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPathEdit As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMRUSep As System.Windows.Forms.MenuItem
    Friend WithEvents MRU4 As System.Windows.Forms.MenuItem
    Friend WithEvents MRU3 As System.Windows.Forms.MenuItem
    Friend WithEvents MRU1 As System.Windows.Forms.MenuItem
    Friend WithEvents MRU2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCompile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSkipWindows As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInvincible As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStartAtLevel As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents mnuWizard As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Public WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents DockHost1 As DockingSuite.DockHost
    Friend WithEvents DockPanel1 As DockingSuite.DockPanel
    Friend WithEvents DockControl1 As DockingSuite.DockControl
    Friend WithEvents PsLayerSelector1 As psLayerSelector
    Friend WithEvents DockPanel2 As DockingSuite.DockPanel
    Friend WithEvents DockControl2 As DockingSuite.DockControl
    Friend WithEvents PsLevelSelector1 As psLevelSelector
    Friend WithEvents DockPanel3 As DockingSuite.DockPanel
    Friend WithEvents DockControl3 As DockingSuite.DockControl
    Friend WithEvents psedit As psEditor
    Friend WithEvents psProperties1 As psProperties
    Friend WithEvents DockHost2 As DockingSuite.DockHost
    Friend WithEvents DockPanel4 As DockingSuite.DockPanel
    Friend WithEvents DockControl4 As DockingSuite.DockControl
    Friend WithEvents tileselect As psTileSelector
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Public WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents tbrMain As UIPlus.UIPlusToolbar
    Friend WithEvents btnNew As ToolBarButton
    Friend WithEvents btnOpen As ToolBarButton
    Friend WithEvents btnSave As ToolBarButton
    Friend WithEvents btnUndo As ToolBarButton
    Friend WithEvents btnRedo As ToolBarButton
    Friend WithEvents btnCut As ToolBarButton
    Friend WithEvents btnCopy As ToolBarButton
    Friend WithEvents btnPaste As ToolBarButton
    Friend WithEvents btnDelete As ToolBarButton
    Friend WithEvents btnRun As ToolBarButton
    Friend WithEvents btnStop As ToolBarButton
    Friend WithEvents btnRestart As ToolBarButton
    Friend WithEvents btnHelp As ToolBarButton
    Friend WithEvents btnWeb As ToolBarButton
    Friend WithEvents btnForums As ToolBarButton
    Friend WithEvents btnToolDraw As ToolBarButton
    Friend WithEvents btnToolErase As ToolBarButton
    Friend WithEvents btnToolSelect As ToolBarButton
    Friend WithEvents btnToolPan As ToolBarButton
    Friend WithEvents btnSep1 As ToolBarButton
    Friend WithEvents btnSep2 As ToolBarButton
    Friend WithEvents btnSep3 As ToolBarButton
    Friend WithEvents btnSep4 As ToolBarButton
    Friend WithEvents btnSep5 As ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents mnuUpgrade As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents UiPlusMenu1 As UIPlus.UIPlusMenu
    Friend WithEvents DockHost3 As DockingSuite.DockHost
    Friend WithEvents DockHost4 As DockingSuite.DockHost
    Friend WithEvents picTrans2 As System.Windows.Forms.PictureBox
    Friend WithEvents loadTimer As System.Windows.Forms.Timer
    Friend WithEvents mnuStartInSeparateProcess As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGame))
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.mnuWizard = New System.Windows.Forms.MenuItem
        Me.mnuOpen = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.mnuCompile = New System.Windows.Forms.MenuItem
        Me.mnuMRUSep = New System.Windows.Forms.MenuItem
        Me.MRU1 = New System.Windows.Forms.MenuItem
        Me.MRU2 = New System.Windows.Forms.MenuItem
        Me.MRU3 = New System.Windows.Forms.MenuItem
        Me.MRU4 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
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
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.mnuReplace = New System.Windows.Forms.MenuItem
        Me.mnuResize = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.mnuView = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.mnuStartInSeparateProcess = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.mnuSkipWindows = New System.Windows.Forms.MenuItem
        Me.mnuInvincible = New System.Windows.Forms.MenuItem
        Me.mnuStartAtLevel = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.mnuTools = New System.Windows.Forms.MenuItem
        Me.mnuTileset = New System.Windows.Forms.MenuItem
        Me.mnuActionEdit = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.mnuHelp = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.mnuUpgrade = New System.Windows.Forms.MenuItem
        Me.psedit = New psEditor
        Me.DockHost1 = New DockingSuite.DockHost
        Me.DockPanel1 = New DockingSuite.DockPanel
        Me.DockControl1 = New DockingSuite.DockControl
        Me.PsLayerSelector1 = New psLayerSelector
        Me.DockPanel2 = New DockingSuite.DockPanel
        Me.DockControl2 = New DockingSuite.DockControl
        Me.PsLevelSelector1 = New psLevelSelector
        Me.DockPanel3 = New DockingSuite.DockPanel
        Me.DockControl3 = New DockingSuite.DockControl
        Me.psProperties1 = New psProperties
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.PsStatus1 = New psStatus
        Me.mnuPathEdit = New System.Windows.Forms.ContextMenu
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DockHost2 = New DockingSuite.DockHost
        Me.DockPanel4 = New DockingSuite.DockPanel
        Me.DockControl4 = New DockingSuite.DockControl
        Me.tileselect = New psTileSelector
        Me.tbrMain = New UIPlus.UIPlusToolbar
        Me.btnNew = New System.Windows.Forms.ToolBarButton
        Me.btnOpen = New System.Windows.Forms.ToolBarButton
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
        Me.btnRun = New System.Windows.Forms.ToolBarButton
        Me.btnStop = New System.Windows.Forms.ToolBarButton
        Me.btnRestart = New System.Windows.Forms.ToolBarButton
        Me.btnSep4 = New System.Windows.Forms.ToolBarButton
        Me.btnHelp = New System.Windows.Forms.ToolBarButton
        Me.btnWeb = New System.Windows.Forms.ToolBarButton
        Me.btnForums = New System.Windows.Forms.ToolBarButton
        Me.btnSep5 = New System.Windows.Forms.ToolBarButton
        Me.btnToolDraw = New System.Windows.Forms.ToolBarButton
        Me.btnToolErase = New System.Windows.Forms.ToolBarButton
        Me.btnToolSelect = New System.Windows.Forms.ToolBarButton
        Me.btnToolPan = New System.Windows.Forms.ToolBarButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UiPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.DockHost3 = New DockingSuite.DockHost
        Me.DockHost4 = New DockingSuite.DockHost
        Me.picTrans2 = New System.Windows.Forms.PictureBox
        Me.loadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DockHost1.SuspendLayout()
        Me.DockPanel1.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.DockPanel2.SuspendLayout()
        Me.DockControl2.SuspendLayout()
        Me.DockPanel3.SuspendLayout()
        Me.DockControl3.SuspendLayout()
        Me.DockHost2.SuspendLayout()
        Me.DockPanel4.SuspendLayout()
        Me.DockControl4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picTrans2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.MenuItem21, Me.mnuTools, Me.mnuHelp, Me.mnuUpgrade})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuWizard, Me.mnuOpen, Me.mnuSave, Me.mnuSaveAs, Me.MenuItem19, Me.MenuItem20, Me.MenuItem22, Me.mnuCompile, Me.mnuMRUSep, Me.MRU1, Me.MRU2, Me.MRU3, Me.MRU4, Me.MenuItem8, Me.mnuExit})
        Me.mnuFile.Text = ""
        '
        'mnuNew
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuNew, 0)
        Me.mnuNew.Index = 0
        Me.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuNew.Text = ""
        '
        'mnuWizard
        '
        Me.mnuWizard.Index = 1
        Me.mnuWizard.Text = ""
        '
        'mnuOpen
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuOpen, 1)
        Me.mnuOpen.Index = 2
        Me.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuOpen.Text = ""
        '
        'mnuSave
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuSave, 2)
        Me.mnuSave.Index = 3
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = ""
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 4
        Me.mnuSaveAs.Text = ""
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 5
        Me.MenuItem19.Text = "-"
        '
        'MenuItem20
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem20, 14)
        Me.MenuItem20.Index = 6
        Me.MenuItem20.Text = ""
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 7
        Me.MenuItem22.Text = "-"
        '
        'mnuCompile
        '
        Me.mnuCompile.Index = 8
        Me.mnuCompile.Text = ""
        '
        'mnuMRUSep
        '
        Me.mnuMRUSep.Index = 9
        Me.mnuMRUSep.Text = "-"
        Me.mnuMRUSep.Visible = False
        '
        'MRU1
        '
        Me.MRU1.Index = 10
        Me.MRU1.Text = "MRU1"
        Me.MRU1.Visible = False
        '
        'MRU2
        '
        Me.MRU2.Index = 11
        Me.MRU2.Text = "MRU2"
        Me.MRU2.Visible = False
        '
        'MRU3
        '
        Me.MRU3.Index = 12
        Me.MRU3.Text = "MRU3"
        Me.MRU3.Visible = False
        '
        'MRU4
        '
        Me.MRU4.Index = 13
        Me.MRU4.Text = "MRU4"
        Me.MRU4.Visible = False
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 14
        Me.MenuItem8.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 15
        Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.mnuExit.Text = ""
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUndo, Me.mnuRedo, Me.MenuItem5, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.mnuDelete, Me.MenuItem10, Me.mnuSelectAll, Me.mnuDeselect, Me.MenuItem13, Me.mnuReplace, Me.mnuResize, Me.MenuItem34, Me.MenuItem36, Me.MenuItem35})
        Me.mnuEdit.Text = ""
        '
        'mnuUndo
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuUndo, 3)
        Me.mnuUndo.Index = 0
        Me.mnuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.mnuUndo.Text = ""
        '
        'mnuRedo
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuRedo, 4)
        Me.mnuRedo.Index = 1
        Me.mnuRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY
        Me.mnuRedo.Text = ""
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "-"
        '
        'mnuCut
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuCut, 5)
        Me.mnuCut.Index = 3
        Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuCut.Text = ""
        '
        'mnuCopy
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuCopy, 6)
        Me.mnuCopy.Index = 4
        Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuCopy.Text = ""
        '
        'mnuPaste
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuPaste, 7)
        Me.mnuPaste.Index = 5
        Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.mnuPaste.Text = ""
        '
        'mnuDelete
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuDelete, 8)
        Me.mnuDelete.Index = 6
        Me.mnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del
        Me.mnuDelete.Text = ""
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
        Me.mnuSelectAll.Text = ""
        '
        'mnuDeselect
        '
        Me.mnuDeselect.Index = 9
        Me.mnuDeselect.Shortcut = System.Windows.Forms.Shortcut.CtrlD
        Me.mnuDeselect.Text = ""
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 10
        Me.MenuItem13.Text = "-"
        '
        'mnuReplace
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuReplace, 21)
        Me.mnuReplace.Index = 11
        Me.mnuReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mnuReplace.Text = ""
        '
        'mnuResize
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuResize, 22)
        Me.mnuResize.Index = 12
        Me.mnuResize.Text = ""
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 13
        Me.MenuItem34.Text = "-"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 14
        Me.MenuItem36.Text = ""
        '
        'MenuItem35
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem35, 23)
        Me.MenuItem35.Index = 15
        Me.MenuItem35.Text = ""
        '
        'mnuView
        '
        Me.mnuView.Index = 2
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem12, Me.MenuItem14, Me.MenuItem17, Me.MenuItem15, Me.MenuItem16, Me.MenuItem18, Me.MenuItem38, Me.MenuItem39})
        Me.mnuView.Text = ""
        '
        'MenuItem12
        '
        Me.MenuItem12.Checked = True
        Me.MenuItem12.Index = 0
        Me.MenuItem12.Text = ""
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "-"
        '
        'MenuItem17
        '
        Me.MenuItem17.Checked = True
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = ""
        '
        'MenuItem15
        '
        Me.MenuItem15.Checked = True
        Me.MenuItem15.Index = 3
        Me.MenuItem15.Text = ""
        '
        'MenuItem16
        '
        Me.MenuItem16.Checked = True
        Me.MenuItem16.Index = 4
        Me.MenuItem16.Text = ""
        '
        'MenuItem18
        '
        Me.MenuItem18.Checked = True
        Me.MenuItem18.Index = 5
        Me.MenuItem18.Text = ""
        '
        'MenuItem38
        '
        Me.MenuItem38.Checked = True
        Me.MenuItem38.Index = 6
        Me.MenuItem38.Text = ""
        '
        'MenuItem39
        '
        Me.MenuItem39.Checked = True
        Me.MenuItem39.Index = 7
        Me.MenuItem39.Text = ""
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 3
        Me.MenuItem21.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.mnuStartInSeparateProcess, Me.MenuItem24, Me.MenuItem33, Me.MenuItem25, Me.MenuItem26})
        Me.MenuItem21.Text = ""
        '
        'MenuItem23
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem23, 9)
        Me.MenuItem23.Index = 0
        Me.MenuItem23.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.MenuItem23.Text = ""
        '
        'mnuStartInSeparateProcess
        '
        Me.mnuStartInSeparateProcess.Index = 1
        Me.mnuStartInSeparateProcess.Shortcut = System.Windows.Forms.Shortcut.CtrlF5
        Me.mnuStartInSeparateProcess.Text = ""
        '
        'MenuItem24
        '
        Me.MenuItem24.Enabled = False
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem24, 10)
        Me.MenuItem24.Index = 2
        Me.MenuItem24.Text = ""
        '
        'MenuItem33
        '
        Me.MenuItem33.Enabled = False
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem33, 15)
        Me.MenuItem33.Index = 3
        Me.MenuItem33.Shortcut = System.Windows.Forms.Shortcut.ShiftF5
        Me.MenuItem33.Text = ""
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 4
        Me.MenuItem25.Text = "-"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 5
        Me.MenuItem26.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSkipWindows, Me.mnuInvincible, Me.mnuStartAtLevel, Me.MenuItem37})
        Me.MenuItem26.Text = ""
        '
        'mnuSkipWindows
        '
        Me.mnuSkipWindows.Index = 0
        Me.mnuSkipWindows.Text = ""
        '
        'mnuInvincible
        '
        Me.mnuInvincible.Index = 1
        Me.mnuInvincible.Text = ""
        '
        'mnuStartAtLevel
        '
        Me.mnuStartAtLevel.Index = 2
        Me.mnuStartAtLevel.Text = ""
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 3
        Me.MenuItem37.Text = ""
        '
        'mnuTools
        '
        Me.mnuTools.Index = 4
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTileset, Me.mnuActionEdit, Me.MenuItem1, Me.MenuItem9, Me.MenuItem11})
        Me.mnuTools.Text = ""
        '
        'mnuTileset
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuTileset, 27)
        Me.mnuTileset.Index = 0
        Me.mnuTileset.Shortcut = System.Windows.Forms.Shortcut.F2
        Me.mnuTileset.Text = ""
        '
        'mnuActionEdit
        '
        Me.UiPlusMenu1.SetImageIndex(Me.mnuActionEdit, 28)
        Me.mnuActionEdit.Index = 1
        Me.mnuActionEdit.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.mnuActionEdit.Text = ""
        '
        'MenuItem1
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem1, 26)
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Shortcut = System.Windows.Forms.Shortcut.F4
        Me.MenuItem1.Text = ""
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "-"
        '
        'MenuItem11
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem11, 24)
        Me.MenuItem11.Index = 4
        Me.MenuItem11.Text = ""
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 5
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem32, Me.MenuItem31, Me.MenuItem30, Me.MenuItem29, Me.MenuItem28, Me.MenuItem27, Me.MenuItem40, Me.MenuItem41, Me.mnuAbout})
        Me.mnuHelp.Text = ""
        '
        'MenuItem32
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem32, 13)
        Me.MenuItem32.Index = 0
        Me.MenuItem32.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.MenuItem32.Text = ""
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 1
        Me.MenuItem31.Text = "-"
        '
        'MenuItem30
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem30, 11)
        Me.MenuItem30.Index = 2
        Me.MenuItem30.Text = ""
        '
        'MenuItem29
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem29, 12)
        Me.MenuItem29.Index = 3
        Me.MenuItem29.Text = ""
        '
        'MenuItem28
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem28, 20)
        Me.MenuItem28.Index = 4
        Me.MenuItem28.Text = ""
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 5
        Me.MenuItem27.Text = "-"
        '
        'MenuItem40
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem40, 25)
        Me.MenuItem40.Index = 6
        Me.MenuItem40.Text = ""
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 7
        Me.MenuItem41.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 8
        Me.mnuAbout.Text = ""
        '
        'mnuUpgrade
        '
        Me.mnuUpgrade.DefaultItem = True
        Me.mnuUpgrade.Index = 6
        Me.mnuUpgrade.Text = ""
        Me.mnuUpgrade.Visible = False
        '
        'psedit
        '
        Me.psedit.Active = False
        Me.psedit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.psedit.Location = New System.Drawing.Point(168, 26)
        Me.psedit.Name = "psedit"
        Me.psedit.Size = New System.Drawing.Size(660, 748)
        Me.psedit.TabIndex = 3
        '
        'DockHost1
        '
        Me.DockHost1.Controls.Add(Me.DockPanel1)
        Me.DockHost1.Controls.Add(Me.DockPanel2)
        Me.DockHost1.Controls.Add(Me.DockPanel3)
        Me.DockHost1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockHost1.Location = New System.Drawing.Point(828, 26)
        Me.DockHost1.Name = "DockHost1"
        Me.DockHost1.Size = New System.Drawing.Size(160, 748)
        Me.DockHost1.TabIndex = 0
        '
        'DockPanel1
        '
        Me.DockPanel1.AutoHide = False
        Me.DockPanel1.Controls.Add(Me.DockControl1)
        Me.DockPanel1.DockedHeight = 188
        Me.DockPanel1.DockedWidth = 156
        Me.DockPanel1.Location = New System.Drawing.Point(4, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.SelectedTab = Me.DockControl1
        Me.DockPanel1.Size = New System.Drawing.Size(156, 185)
        Me.DockPanel1.TabIndex = 0
        Me.DockPanel1.Text = "Docked Panel"
        '
        'DockControl1
        '
        Me.DockControl1.Controls.Add(Me.PsLayerSelector1)
        Me.DockControl1.Guid = New System.Guid("4b364100-4769-4678-8a29-ff69ce2da1fd")
        Me.DockControl1.Location = New System.Drawing.Point(0, 20)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.PrimaryControl = Nothing
        Me.DockControl1.Size = New System.Drawing.Size(156, 142)
        Me.DockControl1.TabImage = Nothing
        Me.DockControl1.TabIndex = 0
        Me.DockControl1.Text = "Docked Control"
        '
        'PsLayerSelector1
        '
        Me.PsLayerSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PsLayerSelector1.Location = New System.Drawing.Point(0, 0)
        Me.PsLayerSelector1.Name = "PsLayerSelector1"
        Me.PsLayerSelector1.Size = New System.Drawing.Size(156, 142)
        Me.PsLayerSelector1.TabIndex = 1
        '
        'DockPanel2
        '
        Me.DockPanel2.AutoHide = False
        Me.DockPanel2.Controls.Add(Me.DockControl2)
        Me.DockPanel2.DockedHeight = 195
        Me.DockPanel2.DockedWidth = 156
        Me.DockPanel2.Location = New System.Drawing.Point(4, 188)
        Me.DockPanel2.Name = "DockPanel2"
        Me.DockPanel2.SelectedTab = Me.DockControl2
        Me.DockPanel2.Size = New System.Drawing.Size(156, 192)
        Me.DockPanel2.TabIndex = 1
        Me.DockPanel2.Text = "Docked Panel"
        '
        'DockControl2
        '
        Me.DockControl2.Controls.Add(Me.PsLevelSelector1)
        Me.DockControl2.Guid = New System.Guid("63fe16dc-72fe-4d43-a841-1e4aab2d8957")
        Me.DockControl2.Location = New System.Drawing.Point(0, 20)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.PrimaryControl = Nothing
        Me.DockControl2.Size = New System.Drawing.Size(156, 149)
        Me.DockControl2.TabImage = Nothing
        Me.DockControl2.TabIndex = 0
        Me.DockControl2.Text = "Docked Control"
        '
        'PsLevelSelector1
        '
        Me.PsLevelSelector1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.PsLevelSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PsLevelSelector1.Location = New System.Drawing.Point(0, 0)
        Me.PsLevelSelector1.Name = "PsLevelSelector1"
        Me.PsLevelSelector1.Size = New System.Drawing.Size(156, 149)
        Me.PsLevelSelector1.TabIndex = 2
        Me.PsLevelSelector1.Value = 0
        '
        'DockPanel3
        '
        Me.DockPanel3.AutoHide = False
        Me.DockPanel3.Controls.Add(Me.DockControl3)
        Me.DockPanel3.DockedHeight = 365
        Me.DockPanel3.DockedWidth = 156
        Me.DockPanel3.Location = New System.Drawing.Point(4, 383)
        Me.DockPanel3.Name = "DockPanel3"
        Me.DockPanel3.SelectedTab = Me.DockControl3
        Me.DockPanel3.Size = New System.Drawing.Size(156, 365)
        Me.DockPanel3.TabIndex = 2
        Me.DockPanel3.Text = "Docked Panel"
        '
        'DockControl3
        '
        Me.DockControl3.Controls.Add(Me.psProperties1)
        Me.DockControl3.Guid = New System.Guid("45e56c8f-9f62-433d-bf28-a8d03fd54405")
        Me.DockControl3.Location = New System.Drawing.Point(0, 20)
        Me.DockControl3.Name = "DockControl3"
        Me.DockControl3.PrimaryControl = Nothing
        Me.DockControl3.Size = New System.Drawing.Size(156, 322)
        Me.DockControl3.TabImage = Nothing
        Me.DockControl3.TabIndex = 0
        Me.DockControl3.Text = "Docked Control"
        '
        'psProperties1
        '
        Me.psProperties1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.psProperties1.Enabled = False
        Me.psProperties1.Location = New System.Drawing.Point(0, 0)
        Me.psProperties1.Name = "psProperties1"
        Me.psProperties1.Size = New System.Drawing.Size(156, 322)
        Me.psProperties1.TabIndex = 3
        '
        'ContextMenu1
        '
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
        Me.iml.Images.SetKeyName(9, "")
        Me.iml.Images.SetKeyName(10, "")
        Me.iml.Images.SetKeyName(11, "")
        Me.iml.Images.SetKeyName(12, "")
        Me.iml.Images.SetKeyName(13, "")
        Me.iml.Images.SetKeyName(14, "")
        Me.iml.Images.SetKeyName(15, "")
        Me.iml.Images.SetKeyName(16, "")
        Me.iml.Images.SetKeyName(17, "")
        Me.iml.Images.SetKeyName(18, "")
        Me.iml.Images.SetKeyName(19, "")
        Me.iml.Images.SetKeyName(20, "")
        Me.iml.Images.SetKeyName(21, "")
        Me.iml.Images.SetKeyName(22, "")
        Me.iml.Images.SetKeyName(23, "")
        Me.iml.Images.SetKeyName(24, "")
        Me.iml.Images.SetKeyName(25, "")
        Me.iml.Images.SetKeyName(26, "")
        Me.iml.Images.SetKeyName(27, "")
        Me.iml.Images.SetKeyName(28, "")
        '
        'PsStatus1
        '
        Me.PsStatus1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PsStatus1.Location = New System.Drawing.Point(0, 774)
        Me.PsStatus1.Name = "PsStatus1"
        Me.PsStatus1.Size = New System.Drawing.Size(988, 16)
        Me.PsStatus1.TabIndex = 15
        '
        'mnuPathEdit
        '
        Me.mnuPathEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem6, Me.MenuItem7, Me.MenuItem2, Me.MenuItem3})
        '
        'MenuItem4
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem4, 3)
        Me.MenuItem4.Index = 0
        '
        'MenuItem6
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem6, 4)
        Me.MenuItem6.Index = 1
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.Text = "-"
        '
        'MenuItem2
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem2, 6)
        Me.MenuItem2.Index = 3
        '
        'MenuItem3
        '
        Me.UiPlusMenu1.SetImageIndex(Me.MenuItem3, 8)
        Me.MenuItem3.Index = 4
        '
        'Timer1
        '
        '
        'DockHost2
        '
        Me.DockHost2.Controls.Add(Me.DockPanel4)
        Me.DockHost2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockHost2.Location = New System.Drawing.Point(0, 26)
        Me.DockHost2.Name = "DockHost2"
        Me.DockHost2.Size = New System.Drawing.Size(168, 748)
        Me.DockHost2.TabIndex = 16
        '
        'DockPanel4
        '
        Me.DockPanel4.AutoHide = False
        Me.DockPanel4.Controls.Add(Me.DockControl4)
        Me.DockPanel4.DockedHeight = 748
        Me.DockPanel4.DockedWidth = 164
        Me.DockPanel4.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel4.Name = "DockPanel4"
        Me.DockPanel4.SelectedTab = Me.DockControl4
        Me.DockPanel4.Size = New System.Drawing.Size(164, 748)
        Me.DockPanel4.TabIndex = 0
        Me.DockPanel4.Text = "Docked Panel"
        '
        'DockControl4
        '
        Me.DockControl4.Controls.Add(Me.tileselect)
        Me.DockControl4.Guid = New System.Guid("72d7d056-bb67-4ae8-9e3b-6be22e63b5dc")
        Me.DockControl4.Location = New System.Drawing.Point(0, 20)
        Me.DockControl4.Name = "DockControl4"
        Me.DockControl4.PrimaryControl = Nothing
        Me.DockControl4.Size = New System.Drawing.Size(164, 705)
        Me.DockControl4.TabImage = Nothing
        Me.DockControl4.TabIndex = 0
        Me.DockControl4.Text = "Docked Control"
        '
        'tileselect
        '
        Me.tileselect.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.tileselect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tileselect.Location = New System.Drawing.Point(0, 0)
        Me.tileselect.Name = "tileselect"
        Me.tileselect.Size = New System.Drawing.Size(164, 705)
        Me.tileselect.TabIndex = 9
        Me.tileselect.Value = 0
        '
        'tbrMain
        '
        Me.tbrMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNew, Me.btnOpen, Me.btnSave, Me.btnSep1, Me.btnUndo, Me.btnRedo, Me.btnSep2, Me.btnCut, Me.btnCopy, Me.btnPaste, Me.btnDelete, Me.btnSep3, Me.btnRun, Me.btnStop, Me.btnRestart, Me.btnSep4, Me.btnHelp, Me.btnWeb, Me.btnForums, Me.btnSep5, Me.btnToolDraw, Me.btnToolErase, Me.btnToolSelect, Me.btnToolPan})
        Me.tbrMain.CustomColorScheme = Nothing
        Me.tbrMain.Divider = False
        Me.tbrMain.DropDownArrows = True
        Me.tbrMain.ImageList = Me.iml
        Me.tbrMain.Location = New System.Drawing.Point(0, 0)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.ShowToolTips = True
        Me.tbrMain.Size = New System.Drawing.Size(988, 26)
        Me.tbrMain.TabIndex = 20
        Me.tbrMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'btnNew
        '
        Me.btnNew.ImageIndex = 0
        Me.btnNew.Name = "btnNew"
        '
        'btnOpen
        '
        Me.btnOpen.ImageIndex = 1
        Me.btnOpen.Name = "btnOpen"
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 2
        Me.btnSave.Name = "btnSave"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.ImageIndex = 3
        Me.btnUndo.Name = "btnUndo"
        '
        'btnRedo
        '
        Me.btnRedo.Enabled = False
        Me.btnRedo.ImageIndex = 4
        Me.btnRedo.Name = "btnRedo"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCut
        '
        Me.btnCut.ImageIndex = 5
        Me.btnCut.Name = "btnCut"
        '
        'btnCopy
        '
        Me.btnCopy.ImageIndex = 6
        Me.btnCopy.Name = "btnCopy"
        '
        'btnPaste
        '
        Me.btnPaste.ImageIndex = 7
        Me.btnPaste.Name = "btnPaste"
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 8
        Me.btnDelete.Name = "btnDelete"
        '
        'btnSep3
        '
        Me.btnSep3.Name = "btnSep3"
        Me.btnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRun
        '
        Me.btnRun.ImageIndex = 9
        Me.btnRun.Name = "btnRun"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.ImageIndex = 10
        Me.btnStop.Name = "btnStop"
        '
        'btnRestart
        '
        Me.btnRestart.Enabled = False
        Me.btnRestart.ImageIndex = 15
        Me.btnRestart.Name = "btnRestart"
        '
        'btnSep4
        '
        Me.btnSep4.Name = "btnSep4"
        Me.btnSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnHelp
        '
        Me.btnHelp.ImageIndex = 13
        Me.btnHelp.Name = "btnHelp"
        '
        'btnWeb
        '
        Me.btnWeb.ImageIndex = 11
        Me.btnWeb.Name = "btnWeb"
        '
        'btnForums
        '
        Me.btnForums.ImageIndex = 12
        Me.btnForums.Name = "btnForums"
        '
        'btnSep5
        '
        Me.btnSep5.Name = "btnSep5"
        Me.btnSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnToolDraw
        '
        Me.btnToolDraw.ImageIndex = 16
        Me.btnToolDraw.Name = "btnToolDraw"
        Me.btnToolDraw.Pushed = True
        '
        'btnToolErase
        '
        Me.btnToolErase.ImageIndex = 17
        Me.btnToolErase.Name = "btnToolErase"
        '
        'btnToolSelect
        '
        Me.btnToolSelect.ImageIndex = 18
        Me.btnToolSelect.Name = "btnToolSelect"
        '
        'btnToolPan
        '
        Me.btnToolPan.ImageIndex = 19
        Me.btnToolPan.Name = "btnToolPan"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbrMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 26)
        Me.Panel1.TabIndex = 21
        '
        'UiPlusMenu1
        '
        Me.UiPlusMenu1.CustomColorScheme = Nothing
        '
        'DockHost3
        '
        Me.DockHost3.AllowDrop = False
        Me.DockHost3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockHost3.Location = New System.Drawing.Point(0, 26)
        Me.DockHost3.Name = "DockHost3"
        Me.DockHost3.Size = New System.Drawing.Size(988, 0)
        Me.DockHost3.TabIndex = 22
        '
        'DockHost4
        '
        Me.DockHost4.AllowDrop = False
        Me.DockHost4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockHost4.Location = New System.Drawing.Point(0, 774)
        Me.DockHost4.Name = "DockHost4"
        Me.DockHost4.Size = New System.Drawing.Size(988, 0)
        Me.DockHost4.TabIndex = 23
        '
        'picTrans2
        '
        Me.picTrans2.Image = CType(resources.GetObject("picTrans2.Image"), System.Drawing.Image)
        Me.picTrans2.Location = New System.Drawing.Point(404, 334)
        Me.picTrans2.Name = "picTrans2"
        Me.picTrans2.Size = New System.Drawing.Size(18, 12)
        Me.picTrans2.TabIndex = 24
        Me.picTrans2.TabStop = False
        Me.picTrans2.Visible = False
        '
        'loadTimer
        '
        Me.loadTimer.Interval = 1
        '
        'frmGame
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(988, 790)
        Me.Controls.Add(Me.picTrans2)
        Me.Controls.Add(Me.psedit)
        Me.Controls.Add(Me.DockHost1)
        Me.Controls.Add(Me.DockHost2)
        Me.Controls.Add(Me.DockHost3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DockHost4)
        Me.Controls.Add(Me.PsStatus1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.MinimumSize = New System.Drawing.Size(267, 208)
        Me.Name = "frmGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.DockHost1.ResumeLayout(False)
        Me.DockPanel1.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.DockPanel2.ResumeLayout(False)
        Me.DockControl2.ResumeLayout(False)
        Me.DockPanel3.ResumeLayout(False)
        Me.DockControl3.ResumeLayout(False)
        Me.DockHost2.ResumeLayout(False)
        Me.DockPanel4.ResumeLayout(False)
        Me.DockControl4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picTrans2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Filenames and Titles"
    Private UntitledFileName As String = GetString("untitledGameFilename")
    Private _CurFile As String
    Private _BaseTitle As String

    Property CurFile() As String
        Get
            Return _CurFile
        End Get
        Set(ByVal Value As String)
            _CurFile = Value
            If CurFile = "" Then
                Me.Text = UntitledFileName & " - " & BaseTitle
                If Not (fWinEdit Is Nothing) Then
                    fWinEdit.Text = UntitledFileName & " - " & fWinEdit.BaseTitle
                End If
            Else
                Me.Text = _CurFile & " - " & BaseTitle
                If Not (fWinEdit Is Nothing) Then
                    fWinEdit.Text = _CurFile & " - " & fWinEdit.BaseTitle
                End If
            End If
        End Set
    End Property

    ReadOnly Property BaseTitle() As String
        Get
            Return _BaseTitle
        End Get
    End Property

    Shared ReadOnly Property OptionsFile() As String
        Get
            Return Game.Root & "options.dat"
        End Get
    End Property
#End Region

    Dim fWinEdit As frmWindowEditor
    Dim MadeChanges As Boolean
    Dim Toolbox As psTools
    Public WithEvents MRU As MruList

    Public Shared Initialized As Boolean = False

    'Dim fTest As New psTest.frmTest()

    'Dim ar As New psAutoRedraw()

#Region "Loading/Unloading"

    Private Sub frmGame_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub frmGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()

        'If IntPtr.Size = 8 Then
        ' MessageBox.Show(GetString("main_64BitError"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Close()
        '   Return
        'End If

        Game.Root = Application.StartupPath & "\"

        'Set docking controls' options
        DockPanel1.DockedHeight = 205
        DockPanel2.DockedHeight = 125
        SetDefaultColors(DockHost1)
        SetDefaultColors(DockHost2)

        'Load options
        Try
            PlatformStudio.LoadOptions(OptionsFile)
        Catch ex As Exception
            FatalError(GetString("main_OptionsError"), ex)
            Return
        End Try

        fGame = Me

        'Show the splash
        If PlatformStudio.Options.gShowSplash Then
            fSplash = New frmSplash
            Try
                fSplash.Show()
                loadTimer.Interval = 900
            Catch
            End Try
        End If
        loadTimer.Enabled = True
    End Sub

    Private Sub loadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadTimer.Tick
        loadTimer.Enabled = False

        'Welcome
        MyEdition.OnLoad(Me)

        'Init controls
        psedit.Init()
        PsLayerSelector1.Init()
        PsLevelSelector1.Init()
        psProperties1.Init()
        PsStatus1.Init()
        Toolbox = New psTools(btnToolDraw, btnToolErase, btnToolSelect, btnToolPan)
        tileselect.Init(psTileSelector.SelectorType.Tile)
        MRU = New MruList(Application.StartupPath & "\mru.ini", mnuFile, mnuMRUSep.Index, PlatformStudio.Options.gNumMRU)

        'ar.EnableAutoRedraw(picGame)
        'Game.Init(picGame.Handle.ToInt32, ar.Graphics)  'picGame.CreateGraphics)        

        'Show main form
        Try
            If PlatformStudio.Options.gStartMaximized Then
                WindowState = FormWindowState.Maximized
            Else
                WindowState = FormWindowState.Normal
            End If

            ReflectOptions()
            Show()
        Catch ex As Exception
            FatalError(GetString("main_LevelEditorError"), ex)
            Return
        End Try

        Wait(GetString("main_StartingStatus"))

        'Init filenames
        _BaseTitle = Text
        dlgSave.FileName = UntitledFileName

        'Untitled game loaded
        CurFile = ""

        'Merge the edit menu into the context menu
        ContextMenu1.MergeMenu(mnuEdit)

        'Hide splash screen
        If PlatformStudio.Options.gShowSplash Then
            fSplash.Close()
            fSplash.Dispose()
            fSplash = Nothing
        End If

        'Clean up tmp files
        Try
            Dim files() As String = IO.Directory.GetFiles(Application.StartupPath, "tmp.*")
            For i As Integer = 0 To files.Length - 1
                IO.File.Delete(files(i))
            Next
        Catch
        End Try

        'Automatic update
        If PlatformStudio.Options.gCheckForUpdatesAtStartup Then
            Game.Status = GetString("main_CheckingForUpdatesStatus")
            Dim f As New frmUpdates(True)
            f.ShowSilent()
            f.Dispose()
            If Created = False Then Exit Sub
        End If

        'Welcome
        Dim fWelcome As New frmWelcomeToPS
        If Environment.GetCommandLineArgs.Length <> 2 And PlatformStudio.Options.gShowWelcomeDialog Then
            Game.Status = GetString("main_WelcomeStatus")
            fWelcome.ShowDialog()
            fWelcome.Dispose()
        End If

        'Init game engine
        Game.Status = GetString("main_InitDirectXStatus")
        Game.InEditor = True
        If Editor.Init(psedit, 5938195395831283597) = False Then
            Close()
            Return
        End If
        Game.ReachedMaxLevels = AddressOf MyEdition.ReachedMaximumLevel
        Game.ReachedMaxWindows = AddressOf MyEdition.ReachedMaximumWindow
        Game.ReachedMaxTile = AddressOf MyEdition.ReachedMaximumTile

        'Open the requested file, if any
        If Environment.GetCommandLineArgs.Length = 2 Then
            OpenGame(Environment.GetCommandLineArgs(1))
        ElseIf fWelcome.Result = frmWelcomeToPS.WelcomeDialogResult.Open Then
            OpenGame(fWelcome.RecentFile)
        ElseIf fWelcome.Result = frmWelcomeToPS.WelcomeDialogResult.OpenRecent Then
            'LoadFromMRU(fWelcome.RecentFile.Substring(fWelcome.RecentFile.Length - 1))
            OpenGame(fWelcome.RecentFile)
        ElseIf fWelcome.Result = frmWelcomeToPS.WelcomeDialogResult.OpenSample Then
            For Each file As String In IO.Directory.GetFiles(Application.StartupPath & "\Samples")
                If IO.Path.GetFileNameWithoutExtension(file) = fWelcome.RecentFile Then
                    OpenGame(file)
                    Exit For
                End If
            Next
        ElseIf fWelcome.Result = frmWelcomeToPS.WelcomeDialogResult.[New] Then
            mnuWizard_Click(sender, e)
        End If

        'All done
        EnableMenus(True)
        psedit.Begin()
        psedit.Active = True
        Cursor.Current = Cursors.Default
        Ready()
        Timer1.Enabled = True
        Initialized = True
    End Sub

    Sub EnableMenus(ByVal Enabled As Boolean)
        If Enabled Then
            Me.Menu = MainMenu1
        Else
            Me.Menu = Nothing
        End If
    End Sub

    Sub FatalError(ByVal msg As String, ByVal ex As Exception)
        MessageBox.Show(msg & vbCrLf & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & GetString("main_FatalError"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Close()
    End Sub

    'For updates
    Public Cancelled As Boolean = False

    Private Sub frmGame_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Ask to save
        Cancelled = False
        If PlatformStudio.psFileHandler.MadeChanges Or MadeChanges Then
            Select Case MessageBox.Show(GetString("main_SaveChangesBeforeClosingMessage"), "JumpCraft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Save(True)
                Case DialogResult.Cancel
                    e.Cancel = True
                    Cancelled = True
                    Exit Sub
            End Select
        End If

        If Not MyEdition.OnClose Then Exit Sub

        'Close the test game if it is open
        MenuItem24_Click(Nothing, Nothing)

        'Save the options
        PlatformStudio.SaveOptions(OptionsFile)
    End Sub

    Private Sub frmGame_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        'End '<-Now generates a crash, so let it unload on its own
    End Sub
#End Region

#Region "MRU"
    Sub LoadFromMRU(ByVal index As Integer)
        'Top:
        '        If IO.File.Exists(MRU(index)) = False Then
        '            If MessageBox.Show("The selected file does not exist.", "Open", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) _
        '            = DialogResult.Retry Then
        '                GoTo Top
        '            Else
        '                MRU.Remove(index)
        '                Exit Sub
        '            End If
        '        End If
        OpenGame(MRU(index))
    End Sub

    Private Sub MRU_OpenFile(ByVal file_name As String) Handles MRU.OpenFile
        OpenGame(file_name)
    End Sub

    '    Public MRU() As String

    '    Sub ClickedMRU1(ByVal sender As Object, ByVal e As EventArgs) Handles MRU1.Click
    '        LoadFromMRU(1)
    '    End Sub

    '    Sub ClickedMRU2(ByVal sender As Object, ByVal e As EventArgs) Handles MRU2.Click
    '        LoadFromMRU(2)
    '    End Sub

    '    Sub ClickedMRU3(ByVal sender As Object, ByVal e As EventArgs) Handles MRU3.Click
    '        LoadFromMRU(3)
    '    End Sub

    '    Sub ClickedMRU4(ByVal sender As Object, ByVal e As EventArgs) Handles MRU4.Click
    '        LoadFromMRU(4)
    '    End Sub

    '    ReadOnly Property MRUFile() As String
    '        Get
    '            Return Game.Root & "mru.ini"
    '        End Get
    '    End Property

    '    Sub LoadMRU()
    '        Try
    '            ReDim MRU(4)
    '            Dim tmpStr As String
    '            If IO.File.Exists(MRUFile) Then
    '                With IO.File.OpenText(MRUFile)
    '                    .ReadLine()
    '                    Dim i As Integer
    '                    For i = 1 To 4
    '                        tmpStr = .ReadLine()
    '                        If tmpStr Is Nothing Then Exit For
    '                        If IO.File.Exists(tmpStr) Then
    '                            MRU(i) = tmpStr
    '                        Else
    '                            i -= 1
    '                        End If
    '                    Next
    '                    .Close()
    '                End With
    '            End If
    '            UpdateMRUList()
    '        Catch
    '            MessageBox.Show("The file, """ & MRUFile & """ appears to be corrupted or modified.  A new, blank file will be put in its place.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            SaveMRU()
    '        End Try
    '    End Sub

    '    Sub UpdateMRUList()
    '        If MRU(1) <> "" Then
    '            MRU1.Text = "1. " & MRU(1)
    '            MRU1.Visible = True
    '            If MRU(2) <> "" Then
    '                MRU2.Text = "2. " & MRU(2)
    '                MRU2.Visible = True
    '                If MRU(3) <> "" Then
    '                    MRU3.Text = "3. " & MRU(3)
    '                    MRU3.Visible = True
    '                    If MRU(4) <> "" Then
    '                        MRU4.Text = "4. " & MRU(4)
    '                        MRU4.Visible = True
    '                    End If
    '                End If
    '            End If
    '            mnuMRUSep.Visible = True
    '        Else
    '            mnuMRUSep.Visible = False
    '        End If
    '    End Sub

    '    Sub SaveMRU()
    '        Dim i As Integer
    '        With IO.File.CreateText(MRUFile)
    '            .WriteLine("[Most Recently Used Games]")
    '            For i = 1 To 4
    '                .WriteLine(MRU(i))
    '            Next
    '            .Close()
    '        End With
    '    End Sub

    '    Sub AddMRU(ByVal Filename As String)
    '        Dim i As Integer, j As Integer
    '        For i = 1 To 4
    '            Try
    '                If MRU(i).ToLower = Filename.ToLower Then
    '                    DeleteMRU(i)
    '                End If
    '            Catch
    '                MRU(i) = ""
    '            End Try
    '        Next
    '        MRU(4) = MRU(3)
    '        MRU(3) = MRU(2)
    '        MRU(2) = MRU(1)
    '        MRU(1) = Filename
    '        UpdateMRUList()
    '    End Sub

    '    Sub DeleteMRU(ByVal index As Integer)
    '        Dim i As Integer
    '        For i = index To 3
    '            MRU(i) = MRU(i + 1)
    '        Next
    '        MRU(4) = ""
    '    End Sub
#End Region

#Region "File Menu"
    Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        If Not (TypeOf sender Is frmNewGameWizard) Then
            'Ask to save
            If PlatformStudio.psFileHandler.MadeChanges Or MadeChanges Then
                Select Case MessageBox.Show(GetString("main_SaveChangesBeforeClosingFileMessage"), "JumpCraft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Save(True)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        Wait()
        MenuItem24_Click(sender, e)
        Editor.Init(psedit, 5938195395831283597)
        StartAtLevel = 1
        mnuStartAtLevel.Checked = False
        CurFile = ""
        MadeChanges = False
        'If PlatformStudio.Options.gDefaultGame Then
        'psFile.LoadTileset(Game.Root & "deftileset.pst")
        'End If
        tileselect.UpdateList()
        Ready()
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        dlgOpen.Filter = GetString("gameFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        OpenGame(dlgOpen.FileName)
    End Sub

    Sub OpenGame(ByVal Filename As String)
        'Ask to save
        If PlatformStudio.psFileHandler.MadeChanges Or MadeChanges Then
            Select Case MessageBox.Show(GetString("main_SaveChangesBeforeClosingFileMessage"), "JumpCraft", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Save(True)
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If

        Wait(GetString("main_LoadingStatus"))
        MenuItem24_Click(Nothing, Nothing)
        If psFile.LoadGame(5938195395831283597, Filename, AddressOf LoadCustomData) = True Then
            CurFile = Filename
            MRU.Add(CurFile)
            MadeChanges = False
        Else
            MRU.Remove(Filename)
        End If
        StartAtLevel = 1
        mnuStartAtLevel.Checked = False
        'Game.actions.Dat = PlatformStudio.DefaultActData.Clone
        'Game.actions.SetDefaults()
        Ready()
    End Sub

    Sub Wait(Optional ByVal msg As String = "()")
        If msg = "()" Then msg = GetString("main_WaitStatus")
        Game.Status = msg
        Cursor.Current = Cursors.WaitCursor
    End Sub

    Sub Ready(Optional ByVal msg As String = "()")
        If msg = "()" Then msg = GetString("main_ReadyStatus")
        Game.Status = msg
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Save()
    End Sub

    Sub Save(Optional ByVal QuietUpgrade As Boolean = False)
        If Not MyEdition.CheckCanSave(QuietUpgrade) Then Return

        If CurFile = "" Then
            If dlgSave.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Else
            dlgSave.FileName = CurFile
        End If

        Wait(GetString("main_SavingStatus"))
        If psFile.SaveGame(dlgSave.FileName, , AddressOf SaveCustomData) = True Then
            CurFile = dlgSave.FileName
            MRU.Add(CurFile)
            MadeChanges = False
        End If
        Ready()

    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
        If Not MyEdition.CheckCanSave(False) Then Return
        SaveAs()
    End Sub

    Sub SaveAs()
        If CurFile <> "" Then dlgSave.FileName = CurFile
        If dlgSave.ShowDialog() = DialogResult.Cancel Then Exit Sub
        CurFile = dlgSave.FileName
        Save()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
#End Region

#Region "Edit Menu"
    Private Sub mnuEdit_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Select
        Dim i As Integer
        For i = 0 To ContextMenu1.MenuItems.Count - 1
            ContextMenu1.MenuItems(i).ShowShortcut = True
        Next
    End Sub

    Private Sub mnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndo.Click
        If psedit.CanUndo Then psedit.Undo()
    End Sub

    Private Sub mnuRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRedo.Click
        If psedit.CanRedo Then psedit.Redo()
    End Sub

    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCut.Click
        If psedit.CanCut Then psedit.Cut()
    End Sub

    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        If psedit.CanCopy Then psedit.Copy()
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        If psedit.CanPaste Then psedit.Paste()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If psedit.CanDelete Then psedit.Delete()
    End Sub

    Private Sub mnuDeselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselect.Click
        If psedit.CanDeselect Then psedit.Deselect()
    End Sub

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        MadeChanges = True
        If psedit.CanSelectAll Then psedit.SelectAll()
    End Sub

    Private Sub mnuResize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResize.Click
        MadeChanges = True
        ShowResizeMap()
    End Sub
#End Region

#Region "Tools Menu"
    Private Sub mnuTileset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTileset.Click
        MadeChanges = True
        ShowTilesetEdit()
    End Sub

    Private Sub mnuActionEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActionEdit.Click
        MadeChanges = True
        ShowActionEdit()
    End Sub
#End Region

#Region "Help Menu"
    Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim f As New frmAbout
        f.ShowDialog()
        f.Dispose()
        f = Nothing
    End Sub
#End Region

#Region "Context Menu"
    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        Dim i As Integer
        For i = 0 To ContextMenu1.MenuItems.Count - 1
            ContextMenu1.MenuItems(i).ShowShortcut = False
        Next
    End Sub
#End Region

#Region "Updating Menus/Toolbars"
    Private Sub EditFunctionsChanged() Handles psedit.EditFunctionsChanged
        mnuCut.Enabled = psedit.CanCut
        mnuCopy.Enabled = psedit.CanCopy
        mnuPaste.Enabled = psedit.CanPaste
        mnuDelete.Enabled = psedit.CanDelete
        mnuSelectAll.Enabled = psedit.CanSelectAll
        mnuDeselect.Enabled = psedit.CanDeselect
        mnuReplace.Enabled = psedit.CanSelectAll
        mnuResize.Enabled = psedit.CanSelectAll
        btnCut.Enabled = psedit.CanCut
        btnCopy.Enabled = psedit.CanCopy
        btnPaste.Enabled = psedit.CanPaste
        btnDelete.Enabled = psedit.CanDelete

        'Undo and redo
        mnuUndo.Enabled = psedit.CanUndo
        mnuUndo.Text = String.Format(GetString("editUndoMenuLong"), psedit.UndoText)
        mnuRedo.Enabled = psedit.CanRedo
        mnuRedo.Text = String.Format(GetString("editRedoMenuLong"), psedit.RedoText)
        MenuItem4.Enabled = mnuUndo.Enabled
        MenuItem4.Text = mnuUndo.Text
        MenuItem6.Enabled = mnuRedo.Enabled
        MenuItem6.Text = mnuRedo.Text
        btnUndo.Enabled = psedit.CanUndo
        btnUndo.ToolTipText = String.Format(GetString("undoIconTooltipLong"), psedit.UndoText)
        btnRedo.Enabled = psedit.CanRedo
        btnRedo.ToolTipText = String.Format(GetString("redoIconTooltipLong"), psedit.RedoText)
    End Sub

    Private Sub tbrMain_ButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs) Handles tbrMain.ButtonClick

        Select Case True
            Case e.Button Is btnToolDraw
                Toolbox.Value = psTools.Tools.Draw
            Case e.Button Is btnToolErase
                Toolbox.Value = psTools.Tools.Erase
            Case e.Button Is btnToolPan
                Toolbox.Value = psTools.Tools.Pan
            Case e.Button Is btnToolSelect
                Toolbox.Value = psTools.Tools.Select

            Case e.Button Is btnNew
                mnuNew_Click(Nothing, Nothing)
            Case e.Button Is btnOpen
                mnuOpen_Click(Nothing, Nothing)
            Case e.Button Is btnSave
                mnuSave_Click(Nothing, Nothing)

            Case e.Button Is btnUndo
                If psedit.CanUndo Then psedit.Undo()
            Case e.Button Is btnRedo
                If psedit.CanRedo Then psedit.Redo()
            Case e.Button Is btnCut
                If psedit.CanCut Then psedit.Cut()
            Case e.Button Is btnCopy
                If psedit.CanCopy Then psedit.Copy()
            Case e.Button Is btnPaste
                If psedit.CanPaste Then psedit.Paste()
            Case e.Button Is btnDelete
                If psedit.CanDelete Then psedit.Delete()

            Case e.Button Is btnRun
                MenuItem23_Click(sender, Nothing)
            Case e.Button Is btnStop
                MenuItem24_Click(sender, Nothing)
            Case e.Button Is btnRestart
                MenuItem33_Click(sender, Nothing)

            Case e.Button Is btnHelp
                MenuItem32_Click(sender, Nothing)
            Case e.Button Is btnWeb
                MenuItem30_Click(sender, Nothing)
            Case e.Button Is btnForums
                MenuItem29_Click(sender, Nothing)
        End Select
    End Sub
#End Region

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        MadeChanges = True
        fWinEdit = New frmWindowEditor
        If psedit.PromptToSavePath() = DialogResult.Cancel Then Exit Sub
        fWinEdit.ShowDialog()
    End Sub

    Private _Active As Boolean
    Property Active() As Boolean
        Get
            Return _Active
        End Get
        Set(ByVal Value As Boolean)
            If Value = True Then If Not (fWinEdit Is Nothing) Then fWinEdit.Dispose()
            psedit.DoNotRenderInRenderLoop = Not Value
        End Set
    End Property

    Private Sub frmGame_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Active = True
    End Sub

    Private Sub frmGame_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Active = False
    End Sub

    Private Sub mnuReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReplace.Click
        MadeChanges = True
        ShowFindReplace()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Editor.psedit.PathEdit.CopyPoint()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Editor.psedit.PathEdit.DeletePoint()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Editor.psedit.PathEdit.Undo()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Editor.psedit.PathEdit.Redo()
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        MenuItem12.Checked = Not MenuItem12.Checked
        PlatformStudio.Options.mShowGrid = MenuItem12.Checked
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        MenuItem17.Checked = Not MenuItem17.Checked
        PlatformStudio.Options.mShowToolbars = MenuItem17.Checked
        Panel1.Visible = MenuItem17.Checked
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        MenuItem15.Checked = Not MenuItem15.Checked
        PlatformStudio.Options.mShowStatusBar = MenuItem15.Checked
        PsStatus1.Visible = MenuItem15.Checked
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        MenuItem16.Checked = Not MenuItem16.Checked
        PlatformStudio.Options.mShowTileSelector = MenuItem16.Checked
        DockControlVisible(DockControl4, DockHost2) = MenuItem16.Checked
    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        MenuItem18.Checked = Not MenuItem18.Checked
        PlatformStudio.Options.mShowLayersPanel = MenuItem18.Checked
        DockControlVisible(DockControl1, DockHost1) = MenuItem18.Checked
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Dim f As New frmOptions
        f.ShowDialog()
        ReflectOptions()
    End Sub

    Sub ReflectOptions()
        'Change based on user's options
        With PlatformStudio.Options
            MenuItem12.Checked = .mShowGrid
            MenuItem17.Checked = .mShowToolbars
            Panel1.Visible = .mShowToolbars
            MenuItem15.Checked = .mShowStatusBar
            PsStatus1.Visible = .mShowStatusBar

            'Panels
            MenuItem16.Checked = .mShowTileSelector
            DockControlVisible(DockControl4, DockHost2) = .mShowTileSelector
            MenuItem18.Checked = .mShowLayersPanel
            DockControlVisible(DockControl1, DockHost1) = .mShowLayersPanel
            MenuItem38.Checked = .mShowLevelsPanel
            DockControlVisible(DockControl2, DockHost1) = .mShowLevelsPanel
            MenuItem39.Checked = .mShowPropertiesPanel
            DockControlVisible(DockControl3, DockHost1) = .mShowPropertiesPanel

            UndoRedo.MaxUndo = .gUndoLevels
            Editor.psedit.PathEdit.ShowGuides = .pShowGuides
            Editor.psproperties.CheckBox2.Checked = .pShowGuides
            Editor.psedit.PathEdit.ShowPoints = .pShowPoints
            Editor.psproperties.CheckBox3.Checked = .pShowPoints
            If .pTintBackground Then
                Editor.psedit.PathEdit.Tint = .pTint
            Else
                Editor.psedit.PathEdit.Tint = 0
            End If
            Editor.psedit.PathEdit.SetPrecision(.pPrecision)
            Editor.psproperties.TrackBar1.Value = .pPrecision
        End With
    End Sub

    Sub LoadCustomData()

    End Sub

    Sub SaveCustomData()

    End Sub

    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        MadeChanges = True
        Dim f As New frmGameProperties
        f.ShowDialog()
    End Sub

    Private Sub mnuSkipWindows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSkipWindows.Click
        mnuSkipWindows.Checked = Not mnuSkipWindows.Checked
    End Sub

    Private Sub mnuInvincible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvincible.Click
        mnuInvincible.Checked = Not mnuInvincible.Checked
    End Sub

    Private Sub mnuStartAtLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStartAtLevel.Click
        Dim f As New frmStartAtLevel
        f.ShowDialog()
        mnuStartAtLevel.Checked = (StartAtLevel > 1)
    End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        frmAbout.Website()
    End Sub

    Private Sub MenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Click
        frmAbout.Forums()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        frmAbout.Support()
    End Sub

    Private Sub mnuCompile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCompile.Click
        MyEdition.Compile()
    End Sub

    Private Sub MenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Click
        Process.Start(Game.Root & "\psHelp.chm")
    End Sub

    Dim GameProcess As System.Diagnostics.Process

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        If Not (Editor.psedit.PathEdit Is Nothing) AndAlso Editor.psedit.PathEdit.Editing Then
            Select Case MessageBox.Show(GetString("main_SaveChangesToPathMessage"), GetString("main_RunCommand"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Editor.psedit.PathEdit.Done()
                Case DialogResult.No
                    Editor.psedit.PathEdit.Done(True)
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Editor.psedit.Deselect()

        DeleteTmp3DLL()

        'Prepare the game
        Wait(GetString("main_CompilingStatus"))

        'Compile the DLL
        Dim Compiler As New Compiler
        If Compiler.CompileDLL() = False Then
            Compiler = Nothing
            Ready()
            Exit Sub
        End If
        Compiler = Nothing

        PlatformStudio.GamePlayer.DLLFilename = Game.Root & "~_tmp3.dll"
        PlatformStudio.GamePlayer.SkipWindows = mnuSkipWindows.Checked
        PlatformStudio.GamePlayer.Invincible = mnuInvincible.Checked
        PlatformStudio.GamePlayer.StartAtLevel = StartAtLevel
        PlatformStudio.GamePlayer.ShowFPS = MenuItem37.Checked
        PlatformStudio.GamePlayer.Client = New myClient

        Dim f As New frmMain
        PlatformStudio.GamePlayer.f = f
        Ready()
        Try
            f.ShowDialog()
        Catch ex As ObjectDisposedException
        End Try

        DeleteTmp3DLL()
    End Sub

    Private Sub mnuStartInSeparateProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStartInSeparateProcess.Click
        If Not (Editor.psedit.PathEdit Is Nothing) AndAlso Editor.psedit.PathEdit.Editing Then
            Select Case MessageBox.Show(GetString("main_SaveChangesToPathMessage"), GetString("main_RunCommand"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Editor.psedit.PathEdit.Done()
                Case DialogResult.No
                    Editor.psedit.PathEdit.Done(True)
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If

        'Stop the old game if it is running
        MenuItem24_Click(sender, e)

        DeleteTmp3DLL()
        mnuStartInSeparateProcess.Enabled = False
        MenuItem23.Enabled = False
        MenuItem24.Enabled = True
        MenuItem33.Enabled = True
        btnRun.Enabled = False
        btnStop.Enabled = True
        btnRestart.Enabled = True

        'Prepare the game
        Wait(GetString("main_CompilingStatus"))

        'Compile the DLL
        Dim Compiler As New Compiler
        If Compiler.CompileDLL() = False Then
            Compiler = Nothing
            Ready()
            Exit Sub
        End If
        Compiler = Nothing

        'Save as a temporary game format
        '(inserts passcodes in the file)
        Dim strFile As String
        strFile = Game.TempRoot & "~_pstudio35tmp.tmp"
        psFile.Tag = modCompiler.Code.ToString
        psFile.SaveGame(strFile, True, AddressOf psFile.fs)

        'Test the game
        'Arguments: Passcode, Filename, SkipWindows, Invincible, StartAtLevel
        GameProcess = Process.Start(Game.Root & "pstest.exe", "531583295836193058 """ & Game.TempRoot & "~_pstudio35tmp.tmp"" """ & Game.Root & "~_tmp3.dll"" " & mnuSkipWindows.Checked & " " & mnuInvincible.Checked & " " & StartAtLevel & " " & MenuItem37.Checked)

        While Not GameProcess.HasExited And mnuStartInSeparateProcess.Enabled = False
            'Application.DoEvents()
        End While
        Try
            IO.File.Delete(Game.TempRoot & "~_pstudio35tmp.tmp")
        Catch ex As Exception

        End Try

        Ready()
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        If Not (GameProcess Is Nothing) AndAlso GameProcess.HasExited = False Then
            GameProcess.Kill()
            GameProcess.Dispose()
            GameProcess = Nothing
            mnuStartInSeparateProcess.Enabled = True
            MenuItem23.Enabled = True
            MenuItem24.Enabled = False
            MenuItem33.Enabled = False
            btnRun.Enabled = True
            btnStop.Enabled = False
            btnRestart.Enabled = False
        End If
    End Sub

    Private Sub psedit_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles psedit.MouseDown
        MadeChanges = True
    End Sub

    Private Sub MenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem33.Click
        'Restart
        mnuStartInSeparateProcess_Click(sender, e)
    End Sub

    Sub DeleteTmp3DLL()
        Dim s As Single = Microsoft.VisualBasic.Timer
TryAgain:
        If Microsoft.VisualBasic.Timer - s > 2 Then GoTo EndTry
        Try
            IO.File.Delete(Game.Root & "~_tmp3.dll")
        Catch
            GoTo TryAgain
        End Try
EndTry:
    End Sub

    Dim Titlebar As Titlebar

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not (GameProcess Is Nothing) AndAlso GameProcess.HasExited = False Then
            mnuStartInSeparateProcess.Enabled = False
            MenuItem23.Enabled = False
            MenuItem24.Enabled = True
            MenuItem33.Enabled = True
            btnRun.Enabled = False
            btnStop.Enabled = True
            btnRestart.Enabled = True
        Else
            If mnuStartInSeparateProcess.Enabled = False Then DeleteTmp3DLL()
            mnuStartInSeparateProcess.Enabled = True
            MenuItem23.Enabled = True
            MenuItem24.Enabled = False
            MenuItem33.Enabled = False
            btnRun.Enabled = True
            btnStop.Enabled = False
            btnRestart.Enabled = False
        End If
    End Sub

    Private Sub mnuWizard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWizard.Click
        Dim fWizard As New frmNewGameWizard
        fWizard.ShowDialog()
        fWizard.Dispose()
    End Sub

    Private Sub MenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem36.Click
        PsLayerSelector1.a0.Checked = True
    End Sub

    Private Sub MenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem35.Click
        Dim f As New frmBackgroundMusic
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub MenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Click
        MenuItem37.Checked = Not MenuItem37.Checked
    End Sub

    Private Sub psedit_DoubleClick() Handles psedit.DoubleClick
        'Show actions
        If Game.OnLocationLayer Then
            If UBound(Editor.psedit.sellocs) <> 1 Then Return
            Dim tmpName As String = Editor.psedit.sellocs(1).loc.Name
            Editor.psedit.Deselect()
            Dim f As New psfrmActionEditor
            f.AddLocNodes(f.tv.Nodes.Add(tmpName), Game.CurMapIndex, tmpName)
            f.ShowDialog(True)
            f.Dispose()
        Else
            If UBound(Editor.psedit.seltiles) <> 1 Then Return
            If Editor.psedit.PathEdit.Editing Then Return
            Dim tmpGroup As String = Editor.psedit.seltiles(1).tile.Group
            Dim tmpTile As Integer = Editor.psedit.seltiles(1).tile.tile
            Editor.psedit.Deselect()
            Dim f As New psfrmActionEditor
            If tmpGroup <> "" Then
                f.AddGroupNodes(f.tv.Nodes.Add(tmpGroup), Game.CurMapIndex, tmpGroup)
            Else
                f.AddTileNodes(f.tv.Nodes.Add(Game.tileset.tiles(tmpTile).name), tmpTile)
            End If
            f.ShowDialog(True)
            f.Dispose()
        End If
    End Sub

    Private Sub DockControl1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl1.Closing
        PlatformStudio.Options.mShowLayersPanel = False
        MenuItem18.Checked = False
    End Sub

    Private Sub DockControl2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl2.Closing
        PlatformStudio.Options.mShowLevelsPanel = False
        MenuItem38.Checked = False
    End Sub

    Private Sub DockControl3_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl3.Closing
        PlatformStudio.Options.mShowPropertiesPanel = False
        MenuItem39.Checked = False
    End Sub

    Private Sub DockControl4_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl4.Closing
        PlatformStudio.Options.mShowTileSelector = False
        MenuItem16.Checked = False
    End Sub

    Private Sub MenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem38.Click
        MenuItem38.Checked = Not MenuItem38.Checked
        PlatformStudio.Options.mShowLevelsPanel = MenuItem38.Checked
        DockControlVisible(DockControl2, DockHost1) = MenuItem38.Checked
    End Sub

    Private Sub MenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem39.Click
        MenuItem39.Checked = Not MenuItem39.Checked
        PlatformStudio.Options.mShowPropertiesPanel = MenuItem39.Checked
        DockControlVisible(DockControl3, DockHost1) = MenuItem39.Checked
    End Sub

    Private Sub psedit_RightClick() Handles psedit.RightClick
        If Editor.psedit.PathEdit.Editing = False Then
            ContextMenu1.Show(psedit, psedit.PointToClient(Control.MousePosition))
        End If
    End Sub

    Private Sub psedit_PathEditorRightClick() Handles psedit.PathEditorRightClick
        If Editor.psedit.PathEdit.Editing = True Then
            MenuItem2.Enabled = psedit.PathEdit.CanCopy
            MenuItem3.Enabled = psedit.PathEdit.CanDelete
            mnuPathEdit.Show(psedit, psedit.PointToClient(Control.MousePosition))
        End If
    End Sub

    Private Sub mnuUpgrade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUpgrade.Click
        MyEdition.OnClickUpgrade()
    End Sub

    Private Sub MenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem40.Click
        Dim f As New frmUpdates
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub DockPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DockPanel1.Paint, DockPanel2.Paint, DockPanel3.Paint, DockPanel4.Paint, DockHost1.Paint, DockHost2.Paint
        e.Graphics.Clear(UIPlus.DefaultColorScheme.getInstance.MenuBack)
    End Sub

    Private Sub frmGame_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized OrElse Panel1.Height = tbrMain.Height Then Return
        Panel1.Height = tbrMain.Height
    End Sub
End Class