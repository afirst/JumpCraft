Imports PlatformStudio

#Region "Script Editor"
Public Class psfrmScriptEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.MenuItem1.Text = GetString("fileMenu")
        Me.MenuItem2.Text = GetString("fileImportMenu")
        Me.MenuItem3.Text = GetString("fileExportMenu")
        Me.MenuItem4.Text = GetString("fileExportPlainTextMenu")
        Me.MenuItem5.Text = GetString("fileExportRichTextMenu")
        Me.MenuItem6.Text = GetString("fileRevertMenu")
        Me.MenuItem10.Text = GetString("fileCloseMenu")
        Me.MenuItem23.Text = GetString("fileCloseSaveMenu")
        Me.MenuItem24.Text = GetString("fileCloseDiscardMenu")
        Me.MenuItem11.Text = GetString("editMenu")
        Me.MenuItem12.Text = GetString("editUndoMenu")
        Me.MenuItem13.Text = GetString("editRedoMenu")
        Me.MenuItem15.Text = GetString("editCutMenu")
        Me.MenuItem16.Text = GetString("editCopyMenu")
        Me.MenuItem17.Text = GetString("editPasteMenu")
        Me.MenuItem18.Text = GetString("editDeleteMenu")
        Me.MenuItem20.Text = GetString("editSelectAllMenu")
        Me.mnuKnownObjects.Text = GetString("editKnownObjectsMenu")
        Me.MenuItem7.Text = GetString("debugMenu")
        Me.MenuItem8.Text = GetString("debugListErrorsMenu")
        Me.MenuItem21.Text = GetString("helpMenu")
        Me.MenuItem22.Text = GetString("helpVBHelpMenu")
        Me.dlgOpen.Filter = GetString("scriptFileFilter")
        Me.dlgOpen.Title = GetString("scriptEd_ImportTextFileDialogTitle")
        Me.Button4.Text = GetString("scriptEd_RevertProcedureButton")
        Me.Button1.Text = GetString("scriptEd_CheckForErrorsButton")
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.TabPage1.Text = GetString("scriptEd_EditProcedureTab")
        Me.Label2.Text = GetString("compileError_ErrorsLabel")
        Me.ColumnHeader4.Text = GetString("compileError_LineColumnHeader")
        Me.ColumnHeader3.Text = GetString("compileError_MessageColumnHeader")
        Me.TabPage2.Text = GetString("scriptEd_EditClassTab")
        Me.Label1.Text = GetString("compileError_ErrorsLabel")
        Me.ColumnHeader5.Text = GetString("compileError_LineColumnHeader")
        Me.ColumnHeader8.Text = GetString("compileError_MessageColumnHeader")
        Me.Text = GetString("scriptEd_Title")
        UIPlusMenu1.SetImageList(iml)
        UIPlusMenu1.Initialize(Me, MainMenu1, ContextMenu1)
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents lstErr As System.Windows.Forms.ListView
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents iml1 As System.Windows.Forms.ImageList
    Friend WithEvents UIPlusMenu1 As UIPlus.UIPlusMenu
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'System.Windows.Forms.RichTextBox
    'System.Windows.Forms.RichTextBox
    Public WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lbl_param As System.Windows.Forms.Label
    Friend WithEvents lblParam As UIPlus.FloatControl
    Friend WithEvents lst_members As System.Windows.Forms.ListBox
    Friend WithEvents lstMembers As UIPlus.FloatControl
    Friend WithEvents txtPScript As PlatformStudio.CodeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstErr1 As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FloatControl2 As UIPlus.FloatControl
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents FloatControl1 As UIPlus.FloatControl
    Public WithEvents txtMScript As PlatformStudio.CodeEditor
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstErr2 As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuKnownObjects As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(psfrmScriptEditor))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.mnuKnownObjects = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UIPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lstMembers = New UIPlus.FloatControl
        Me.lst_members = New System.Windows.Forms.ListBox
        Me.lblParam = New UIPlus.FloatControl
        Me.lbl_param = New System.Windows.Forms.Label
        Me.txtPScript = New PlatformStudio.CodeEditor
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstErr1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.FloatControl1 = New UIPlus.FloatControl
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.FloatControl2 = New UIPlus.FloatControl
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMScript = New PlatformStudio.CodeEditor
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstErr2 = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.lstMembers.SuspendLayout()
        Me.lblParam.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.FloatControl1.SuspendLayout()
        Me.FloatControl2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem11, Me.MenuItem7, Me.MenuItem21})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem9, Me.MenuItem6, Me.MenuItem10})

        '
        'MenuItem2
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem2, 0)
        Me.MenuItem2.Index = 0



        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem5})

        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0

        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1

        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 2
        Me.MenuItem9.Text = "-"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 3

        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 4
        Me.MenuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem24})

        '
        'MenuItem23
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem23, 1)
        Me.MenuItem23.Index = 0

        '
        'MenuItem24
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem24, 7)
        Me.MenuItem24.Index = 1
        Me.MenuItem24.Shortcut = System.Windows.Forms.Shortcut.AltF4

        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem12, Me.MenuItem13, Me.MenuItem14, Me.MenuItem15, Me.MenuItem16, Me.MenuItem17, Me.MenuItem18, Me.MenuItem19, Me.MenuItem20, Me.MenuItem25, Me.mnuKnownObjects})

        '
        'MenuItem12
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem12, 2)
        Me.MenuItem12.Index = 0
        Me.MenuItem12.Shortcut = System.Windows.Forms.Shortcut.CtrlZ

        '
        'MenuItem13
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem13, 3)
        Me.MenuItem13.Index = 1
        Me.MenuItem13.Shortcut = System.Windows.Forms.Shortcut.CtrlY

        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 2
        Me.MenuItem14.Text = "-"
        '
        'MenuItem15
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem15, 4)
        Me.MenuItem15.Index = 3
        Me.MenuItem15.Shortcut = System.Windows.Forms.Shortcut.CtrlX

        '
        'MenuItem16
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem16, 5)
        Me.MenuItem16.Index = 4
        Me.MenuItem16.Shortcut = System.Windows.Forms.Shortcut.CtrlC

        '
        'MenuItem17
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem17, 6)
        Me.MenuItem17.Index = 5
        Me.MenuItem17.Shortcut = System.Windows.Forms.Shortcut.CtrlV

        '
        'MenuItem18
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem18, 7)
        Me.MenuItem18.Index = 6
        Me.MenuItem18.Shortcut = System.Windows.Forms.Shortcut.Del

        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 7
        Me.MenuItem19.Text = "-"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 8
        Me.MenuItem20.Shortcut = System.Windows.Forms.Shortcut.CtrlA

        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 9
        Me.MenuItem25.Text = "-"
        '
        'mnuKnownObjects
        '
        Me.mnuKnownObjects.Index = 10

        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem8})

        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 0

        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 3
        Me.MenuItem21.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem22})

        '
        'MenuItem22
        '
        Me.UIPlusMenu1.SetImageIndex(Me.MenuItem22, 8)
        Me.MenuItem22.Index = 0
        Me.MenuItem22.Shortcut = System.Windows.Forms.Shortcut.F1

        '
        'dlgOpen
        '

        '
        'dlgSave
        '
        Me.dlgSave.FileName = "doc1"
        '
        'iml1
        '
        Me.iml1.ImageStream = CType(resources.GetObject("iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml1.TransparentColor = System.Drawing.Color.White
        Me.iml1.Images.SetKeyName(0, "")
        Me.iml1.Images.SetKeyName(1, "")
        Me.iml1.Images.SetKeyName(2, "")
        '
        'UIPlusMenu1
        '
        Me.UIPlusMenu1.CustomColorScheme = Nothing
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 377)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(424, 32)
        Me.Panel3.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(146, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 24)
        Me.Button4.TabIndex = 10

        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(44, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 24)
        Me.Button1.TabIndex = 9

        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(344, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 8

        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(264, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 7

        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 377)
        Me.Panel1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.ItemSize = New System.Drawing.Size(82, 18)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(408, 360)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstMembers)
        Me.TabPage1.Controls.Add(Me.lblParam)
        Me.TabPage1.Controls.Add(Me.txtPScript)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(400, 334)
        Me.TabPage1.TabIndex = 0

        '
        'lstMembers
        '
        Me.lstMembers.Controls.Add(Me.lst_members)
        Me.lstMembers.Location = New System.Drawing.Point(120, 48)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(174, 167)
        Me.lstMembers.TabIndex = 8
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
        Me.lblParam.Location = New System.Drawing.Point(32, 40)
        Me.lblParam.Name = "lblParam"
        Me.lblParam.Size = New System.Drawing.Size(264, 16)
        Me.lblParam.TabIndex = 3
        Me.lblParam.Visible = False
        '
        'lbl_param
        '
        Me.lbl_param.BackColor = System.Drawing.SystemColors.Info
        Me.lbl_param.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_param.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_param.Location = New System.Drawing.Point(0, 0)
        Me.lbl_param.Name = "lbl_param"
        Me.lbl_param.Size = New System.Drawing.Size(264, 16)
        Me.lbl_param.TabIndex = 7
        '
        'txtPScript
        '
        Me.txtPScript.AcceptsTab = True
        Me.txtPScript.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPScript.ContextMenu = Me.ContextMenu1
        Me.txtPScript.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPScript.DoColorCode = True
        Me.txtPScript.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPScript.Location = New System.Drawing.Point(0, 0)
        Me.txtPScript.Name = "txtPScript"
        Me.txtPScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.txtPScript.Size = New System.Drawing.Size(400, 230)
        Me.txtPScript.TabIndex = 0
        Me.txtPScript.Text = ""
        Me.txtPScript.WordWrap = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lstErr1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 230)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 104)
        Me.Panel2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 5

        '
        'lstErr1
        '
        Me.lstErr1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstErr1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.lstErr1.FullRowSelect = True
        Me.lstErr1.GridLines = True
        Me.lstErr1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstErr1.HideSelection = False
        Me.lstErr1.Location = New System.Drawing.Point(0, 24)
        Me.lstErr1.Name = "lstErr1"
        Me.lstErr1.Size = New System.Drawing.Size(600, 84)
        Me.lstErr1.TabIndex = 6
        Me.lstErr1.UseCompatibleStateImageBehavior = False
        Me.lstErr1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "!"
        Me.ColumnHeader1.Width = 24
        '
        'ColumnHeader4
        '

        Me.ColumnHeader4.Width = 40
        '
        'ColumnHeader3
        '

        Me.ColumnHeader3.Width = 300
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FloatControl1)
        Me.TabPage2.Controls.Add(Me.FloatControl2)
        Me.TabPage2.Controls.Add(Me.txtMScript)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(400, 334)
        Me.TabPage2.TabIndex = 1

        Me.TabPage2.Visible = False
        '
        'FloatControl1
        '
        Me.FloatControl1.Controls.Add(Me.ListBox1)
        Me.FloatControl1.Location = New System.Drawing.Point(24, 48)
        Me.FloatControl1.Name = "FloatControl1"
        Me.FloatControl1.Size = New System.Drawing.Size(174, 167)
        Me.FloatControl1.TabIndex = 11
        Me.FloatControl1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(174, 167)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 10
        '
        'FloatControl2
        '
        Me.FloatControl2.Controls.Add(Me.Label3)
        Me.FloatControl2.Location = New System.Drawing.Point(136, 16)
        Me.FloatControl2.Name = "FloatControl2"
        Me.FloatControl2.Size = New System.Drawing.Size(200, 100)
        Me.FloatControl2.TabIndex = 12
        Me.FloatControl2.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Info
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 100)
        Me.Label3.TabIndex = 9
        '
        'txtMScript
        '
        Me.txtMScript.AcceptsTab = True
        Me.txtMScript.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMScript.ContextMenu = Me.ContextMenu1
        Me.txtMScript.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMScript.DoColorCode = True
        Me.txtMScript.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMScript.Location = New System.Drawing.Point(0, 0)
        Me.txtMScript.Name = "txtMScript"
        Me.txtMScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.txtMScript.Size = New System.Drawing.Size(400, 230)
        Me.txtMScript.TabIndex = 0
        Me.txtMScript.Text = ""
        Me.txtMScript.WordWrap = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.lstErr2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 230)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 104)
        Me.Panel4.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 5

        '
        'lstErr2
        '
        Me.lstErr2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstErr2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader8})
        Me.lstErr2.FullRowSelect = True
        Me.lstErr2.GridLines = True
        Me.lstErr2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstErr2.HideSelection = False
        Me.lstErr2.Location = New System.Drawing.Point(0, 24)
        Me.lstErr2.Name = "lstErr2"
        Me.lstErr2.Size = New System.Drawing.Size(600, 84)
        Me.lstErr2.TabIndex = 7
        Me.lstErr2.UseCompatibleStateImageBehavior = False
        Me.lstErr2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "!"
        Me.ColumnHeader2.Width = 24
        '
        'ColumnHeader5
        '

        Me.ColumnHeader5.Width = 40
        '
        'ColumnHeader8
        '

        Me.ColumnHeader8.Width = 300
        '
        'psfrmScriptEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 409)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(200, 200)
        Me.Name = "psfrmScriptEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.lstMembers.ResumeLayout(False)
        Me.lblParam.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.FloatControl1.ResumeLayout(False)
        Me.FloatControl2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim WithEvents txtScript As CodeEditor 'RichTextBox
    Dim OldScript As String
    Dim Intellisense1 As Intellisense
    Dim Intellisense2 As Intellisense
    Dim Trig As String
    Dim strParams As String
    Private ObjArray As New ArrayList

    Structure TypeAndName
        Public Type As System.Type
        Public Name As String
        Sub New(ByVal t As System.Type, ByVal n As String)
            Type = t
            Name = n
        End Sub
    End Structure

    Shared Function DefaultObjectArray() As ArrayList
        Dim arr As New ArrayList
        For Each str As String In psUI.psControl.ControlNames.Keys
            arr.Add(New TypeAndName(GetType(psUI.psControl), str))
        Next
        arr.Add(New TypeAndName(GetType(IGame), "game"))
        arr.Add(New TypeAndName(GetType(Color), "color"))
        arr.Add(New TypeAndName(GetType(System.Math), "math"))
        Return arr
    End Function

    Overloads Function ShowDialog(ByRef param As String, ByVal Trigger As String) As DialogResult
        Trig = Trigger
        ObjArray = DefaultObjectArray()
        Select Case Trigger.Chars(0)
            Case "c" 'counter
                ObjArray.Add(New TypeAndName(curCounter.GetType, "curcounter"))
                strParams = "ByVal curCounter As PlatformStudio.CurrentCounter"
            Case "i" 'timer
                ObjArray.Add(New TypeAndName(curTimer.GetType, "curtimer"))
                strParams = "ByVal curTimer As PlatformStudio.CurrentTimer"
            Case "g", "t" 'group
                ObjArray.Add(New TypeAndName(curGroup.GetType, "curgroup"))
                strParams = "ByVal curGroup As PlatformStudio.CurrentGroup"
        End Select
        Intellisense1 = New Intellisense(lstMembers, lblParam, lst_members, iml1, txtPScript, lbl_param)
        Intellisense1.ObjArray = ObjArray
        Intellisense2 = New Intellisense(FloatControl1, FloatControl2, ListBox1, iml1, txtMScript, Label3)
        Intellisense2.ObjArray = ObjArray
        OldScript = param
        SetupMenus()
        txtPScript.Text = param
        txtMScript.Text = Game.actions.Globals
        txtScript = txtPScript
        txtScript.Select()
        lstErr = lstErr1
        Dim dr As DialogResult
        dr = ShowDialog()
        If dr = DialogResult.OK Then
            param = txtPScript.Text
        End If
        Return dr
    End Function

    Overloads Function ShowDialog(ByVal GlobalsOnly As Boolean) As DialogResult        
        If GlobalsOnly Then
            ObjArray = DefaultObjectArray()
            Intellisense2 = New Intellisense(FloatControl1, FloatControl2, ListBox1, iml1, txtMScript, Label3)
            Intellisense2.ObjArray = ObjArray
            SetupMenus()
            txtMScript.Text = Game.actions.Globals
            txtScript = txtMScript
            txtScript.Select()
            lstErr = lstErr2
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1_SelectedIndexChanged(Nothing, Nothing)
            Dim dr As DialogResult
            dr = ShowDialog()
            Return dr
        Else
            Return ShowDialog()
        End If
    End Function

    Private Sub SetupMenus()
        For i As Integer = 0 To ObjArray.Count - 1
            mnuKnownObjects.MenuItems.Add(ObjArray(i).Name, New EventHandler(AddressOf ClickedKnownObject))
            UIPlusMenu1.HandleMenuItem(mnuKnownObjects.MenuItems(mnuKnownObjects.MenuItems.Count - 1))
        Next
        ContextMenu1.MergeMenu(MenuItem11)
    End Sub

    Sub ClickedKnownObject(ByVal sender As Object, ByVal e As EventArgs)
        txtScript.SelectedText = sender.Text
        System.Windows.Forms.SendKeys.Send(".")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 AndAlso TabControl1.TabCount > 1 Then
            txtScript = txtPScript
            Button4.Text = GetString("scriptEd_RevertProcedureButton")
            lstErr = lstErr1
        Else
            txtScript = txtMScript
            Button4.Text = GetString("scriptEd_RevertClassButton")
            lstErr = lstErr2
        End If
    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        Button2_Click(sender, e)
    End Sub

    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        Process.Start("http://msdn.microsoft.com/library/default.asp?url=/library/en-us/vbcn7/html/vaconprogrammingwithvb.asp")
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click

    End Sub

    Private Sub MenuItem11_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem11.Select
        MenuItem12.Text = String.Format(GetString("editUndoMenuLong"), txtScript.UndoActionName)
        MenuItem12.Enabled = txtScript.CanUndo
        MenuItem13.Text = String.Format(GetString("editRedoMenuLong"), txtScript.RedoActionName)
        MenuItem13.Enabled = txtScript.CanRedo
        MenuItem15.Enabled = txtScript.SelectedText <> ""
        MenuItem16.Enabled = txtScript.SelectedText <> ""
        MenuItem17.Enabled = txtScript.CanPaste(DataFormats.GetFormat(DataFormats.Text))
        'MenuItem18.Enabled = txtScript.SelectedText <> ""
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        txtScript.Undo()
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        txtScript.Redo()
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        txtScript.Cut()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        txtScript.Copy()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        txtScript.Paste(DataFormats.GetFormat(DataFormats.Text))
    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        If txtScript.SelectedText <> "" Then
            txtScript.SelectedText = ""
        Else
            If txtScript.SelectionStart < txtScript.TextLength Then
                txtScript.LockUpdate = True
                txtScript.SelectionLength = 1
                txtScript.LockUpdate = False
                txtScript.SelectedText = ""
            End If
        End If
    End Sub

    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        txtScript.SelectAll()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        With dlgSave
            .Title = GetString("scriptEd_ExportPlainTextFileDialogTitle")
            .Filter = GetString("plainTextFileFilter")
            If .ShowDialog = DialogResult.OK Then
                txtScript.SaveFile(.FileName, RichTextBoxStreamType.PlainText)
            End If
        End With
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        With dlgSave
            .Title = GetString("scriptEd_ExportRichTextFileDialogTitle")
            .Filter = GetString("richTextFileFilter")
            If .ShowDialog = DialogResult.OK Then
                txtScript.SaveFile(.FileName, RichTextBoxStreamType.RichNoOleObjs)
            End If
        End With
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        With dlgOpen
            If .ShowDialog = DialogResult.OK Then
                txtScript.LoadFile(.FileName, RichTextBoxStreamType.PlainText)
            End If
        End With
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        MenuItem11_Select(sender, e)
    End Sub

    ReadOnly Property tmpDLLFile() As String
        Get
            Return (Game.Root & "~tmp")
        End Get
    End Property

    Sub ListErrors()
        'Variables
        Dim dll As New psDLL
        Dim errors() As System.CodeDom.Compiler.CompilerError

        'Generate the code for the temporary DLL
        Dim Code As String
        Dim HeaderLines As Integer = 7 + Game.actions.getClassHeaderLines
        Code = "Imports System" & vbCrLf & _
        "Imports System.Drawing" & vbCrLf & _
        "Imports System.Windows.Forms" & vbCrLf & _
        "Imports Microsoft.VisualBasic" & vbCrLf & _
        "Imports PlatformStudio" & vbCrLf & _
        "Namespace Test" & vbCrLf & _
        "   Class TestObject" & vbCrLf & _
                Game.actions.getClassHeader & vbCrLf & _
                txtMScript.Text & vbCrLf & _
        "       Function TestFunction(" & strParams & ")" & vbCrLf & _
                    txtPScript.Text & vbCrLf & _
        "       End Function" & vbCrLf & _
        "   End Class" & vbCrLf & _
        "End Namespace"

        'Find errors
        dll.CompileDLL(tmpDLLFile, "TestObject", Code, errors)
        If IO.File.Exists(tmpDLLFile & ".dll") Then
            IO.File.Delete(tmpDLLFile & ".dll")
        End If

        'List the errors
        Dim i As Integer
        Dim ClassLines As Integer = txtMScript.Lines.Length
        lstErr1.Items.Clear()
        lstErr2.Items.Clear()
        For i = 1 To UBound(errors)
            If errors(i).Line - HeaderLines - 1 - ClassLines > 0 Then

                'Error in Procedure View
                lstErr1.Items.Add(IIf(errors(i).IsWarning, "", "!"))
                With lstErr1.Items(lstErr1.Items.Count - 1)
                    .SubItems.Add(errors(i).Line - HeaderLines - 1 - ClassLines)
                    .SubItems.Add(errors(i).ErrorText)
                End With

            Else

                'Error in Class View
                lstErr2.Items.Add(IIf(errors(i).IsWarning, "", "!"))
                With lstErr2.Items(lstErr2.Items.Count - 1)
                    .SubItems.Add(errors(i).Line - HeaderLines)
                    .SubItems.Add(errors(i).ErrorText)
                End With

            End If
        Next

        'If there are no errors on the current view, but errors
        'in the other view, go to the other view
        If lstErr1.Items.Count = 0 And TabControl1.SelectedIndex = 0 And lstErr2.Items.Count > 0 Then
            TabControl1.SelectedIndex = 1
        ElseIf lstErr1.Items.Count > 0 And TabControl1.SelectedIndex = 1 And lstErr2.Items.Count = 0 Then
            TabControl1.SelectedIndex = 0
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListErrors()
    End Sub

    Private Sub lstErr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstErr.SelectedIndexChanged
        Try
            If lstErr.SelectedIndices.Count = 0 Then Exit Sub
            Dim i As Integer, tmpS As Integer
            With lstErr.SelectedItems(0)
                For i = 0 To CInt(.SubItems(1).Text) - 2
                    tmpS += txtScript.Lines(i).Length + 1
                Next
                txtScript.LockUpdate = True
                txtScript.Select(tmpS, txtScript.Lines(.SubItems(1).Text - 1).Length)
                txtScript.ScrollToCaret()
                txtScript.Select()
                txtScript.LockUpdate = False
                txtScript.Invalidate()
                'txtScript.Redraw()
            End With
        Catch
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtScript Is txtMScript Then
            txtScript.Text = Game.actions.Globals
        Else
            txtScript.Text = OldScript
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ErrIn As String

        'Find errors
        ListErrors()
        If lstErr1.Items.Count > 0 Then ErrIn = GetString("scriptEd_ProcedureView")
        If lstErr2.Items.Count > 0 Then
            If ErrIn = "" Then
                ErrIn = GetString("scriptEd_ClassView")
            Else
                ErrIn &= " " & GetString("scriptEd_AndClassView")
            End If
        End If

        'Stop users from continuing with errors
        If ErrIn <> "" Then
            MessageBox.Show(String.Format(GetString("scriptEd_MustFixErrorsMessage"), ErrIn), GetString("scriptEd_Title"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Button4_Click(sender, e)
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Button1_Click(sender, e)
    End Sub

    Private Sub psfrmScriptEditor_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        Try
            Intellisense1.RepositionMembersList()
            Intellisense1.RepositionParamsList()
        Catch
        End Try
        Try
            Intellisense2.RepositionMembersList()
            Intellisense2.RepositionParamsList()
        Catch
        End Try
    End Sub

    Private Sub psfrmScriptEditor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FloatControl1.Visible = False
        FloatControl2.Visible = False
        lstMembers.Visible = False
        lblParam.Visible = False
    End Sub
End Class
#End Region

#Region "Intellisense"
Public Class Intellisense
    Dim WithEvents lstMembers As ListBox
    Dim WithEvents iml1 As ImageList
    Dim WithEvents txtScript As CodeEditor
    Dim WithEvents lblParam As Label
    Dim WithEvents fMembers As UIPlus.FloatControl
    Dim WithEvents fParam As UIPlus.FloatControl
    Private fParamBasePt, fMembersBasePt As Point

    Sub New()

    End Sub

    Sub New(ByVal floatList As UIPlus.FloatControl, ByVal floatParam As UIPlus.FloatControl, ByVal lst As ListBox, ByVal iml As ImageList, ByVal rtb As CodeEditor, ByVal lbl As Label)
        fMembers = floatList
        fParam = floatParam
        lstMembers = lst
        iml1 = iml
        txtScript = rtb
        lblParam = lbl
    End Sub

    Sub SetAutoCompleteList(ByVal lst As ListBox)
        lstMembers = lst
    End Sub

    Sub SetImageList(ByVal iml As ImageList)
        iml1 = iml
    End Sub

    Sub SetRichTextBox(ByVal rtb As CodeEditor)
        txtScript = rtb
    End Sub

    Sub SetParamLabel(ByVal lbl As Label)
        lblParam = lbl
    End Sub

    Dim DotPos As Integer, ParenthPos As Integer
    Dim CurIndex As Integer
    Dim mi() As System.Reflection.MethodInfo
    Dim lstIcons As New SortedList

    Private Sub txtScript_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScript.TextChanged
        If fMembers.Visible Then
            Dim strSearch As String = txtScript.Text.Substring(DotPos + 1, txtScript.SelectionStart - (DotPos + 1))
            Dim i As Integer, j As Integer
            Dim tmpSelIndex As Integer
            For i = 1 To strSearch.Length
                For j = 0 To lstMembers.Items.Count - 1
                    If lstMembers.Items(j).Length >= i Then
                        If LCase(lstMembers.Items(j).substring(0, i)) = LCase(strSearch.Substring(0, i)) Then
                            tmpSelIndex = j
                            Exit For
                        End If
                    End If
                Next
            Next
            lstMembers.SelectedIndex = tmpSelIndex
        End If
    End Sub

    Function GetObjectName() As String
        Dim i As Integer
        Dim tmpDelimit As Integer = -1
        For i = txtScript.SelectionStart - 1 To 0 Step -1
            Select Case txtScript.Text.Chars(i)
                Case ",", "=", " ", "+", "-", "*", "/", "\", "^", "(", ")", "[", "]", "{", "}", vbCr, vbLf, Chr(9)
                    If tmpDelimit = -1 Then GoTo FoundDelimeter
                    'Case ")"
                    '    tmpDelimit = i
                    'Case "("
                    '    If tmpDelimit > -1 Then tmpDelimit = -1
            End Select
        Next
        i = tmpDelimit
FoundDelimeter:
        Return txtScript.Text.Substring(i + 1, txtScript.SelectionStart - 1 - (i + 1) + 1)
    End Function

    Public ObjArray As ArrayList

    Function GetCurType(Optional ByVal MustReturnAValue As Boolean = True, Optional ByRef MethodInfo() As System.Reflection.MethodInfo = Nothing) As System.Type
        Dim strObject As String = GetObjectName()

        'Take out parenthesis ex: (3,5)
        Dim i As Integer, j As Integer
        Dim StartChar As Integer
        For i = 0 To strObject.Length - 1
            If i > strObject.Length - 1 Then Exit For
            If strObject.Chars(i) = "(" Then
                StartChar = i
            ElseIf strObject.Chars(i) = ")" Then
                If StartChar > 0 Then
                    strObject = strObject.Replace(strObject.Substring(StartChar, i - StartChar + 1), "")
                    i = StartChar
                    StartChar = 0
                End If
            End If
        Next

        For c As Integer = 0 To ObjArray.Count - 1
            If strObject.Length < ObjArray(c).Name.Length Then GoTo NextC
            If LCase(strObject.Substring(0, ObjArray(c).Name.Length)) <> ObjArray(c).Name Then GoTo NextC
            If LCase(strObject) = ObjArray(c).Name Then
                'Return Game.GetType
                Return ObjArray(c).Type
            Else

                'Clip off the "game." or "[current object]."
                strObject = strObject.Substring(ObjArray(c).Name.Length + 1)

                'Get each member and store in an array
                'For example, if we typed Game.Actions.Counters,
                'it should return {Actions, Counters}, since
                'everything must be a member of the current object
                Dim Dots As Integer = 1
                Dim strObjects() As String
                ReDim strObjects(0)
                For i = 0 To strObject.Length - 1
                    If strObject.Chars(i) = "." Then
                        ReDim Preserve strObjects(UBound(strObjects) + 1)
                        Dots += 1
                        strObjects(UBound(strObjects)) = strObject.Substring(j, i - 1 - j + 1)
                        j = i + 1
                    End If
                Next
                ReDim Preserve strObjects(UBound(strObjects) + 1)
                strObjects(UBound(strObjects)) = strObject.Substring(j)

                'Find the right member
                ReDim MethodInfo(0)
                Dim tmpType As System.Type = ObjArray(c).Type
                For i = 1 To Dots
                    Try
                        tmpType = (tmpType.GetField(strObjects(i)).FieldType)
                    Catch
                        Try
                            If MustReturnAValue = False And i = Dots Then
                                Dim mi() As System.Reflection.MethodInfo
                                mi = tmpType.GetMethods()
                                For j = 0 To UBound(mi)
                                    If mi(j).Name = "get_" & strObjects(i) Then
                                        ReDim Preserve MethodInfo(UBound(MethodInfo) + 1)
                                        MethodInfo(UBound(MethodInfo)) = mi(j)
                                    End If
                                Next
                                If UBound(MethodInfo) > 0 Then Return Nothing
                                Throw New Exception("Not a property")
                            Else
                                tmpType = (tmpType.GetProperty(strObjects(i)).PropertyType)
                            End If
                        Catch
                            Try
                                If MustReturnAValue = False And i = Dots Then
                                    'MethodInfo = tmpType.GetMethod(strObjects(i))
                                    Dim mi() As System.Reflection.MethodInfo
                                    mi = tmpType.GetMethods()
                                    For j = 0 To UBound(mi)
                                        If mi(j).Name = strObjects(i) Then
                                            ReDim Preserve MethodInfo(UBound(MethodInfo) + 1)
                                            MethodInfo(UBound(MethodInfo)) = mi(j)
                                        End If
                                    Next
                                Else
                                    tmpType = (tmpType.GetMethod(strObjects(i)).ReturnType)
                                End If
                            Catch
                                GoTo NextC
                            End Try
                        End Try
                    End Try
                Next
                Return tmpType
                'Return Nothing
            End If
NextC:
        Next
        Return Nothing
    End Function

    Private Sub txtScript_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScript.KeyPress
        If e.KeyChar = vbCr Or e.KeyChar = vbTab Or e.KeyChar = " " Or e.KeyChar = "." Or e.KeyChar = "(" Or e.KeyChar = ")" Or e.KeyChar = "+" Or e.KeyChar = "-" Or e.KeyChar = "*" Or e.KeyChar = "/" Or e.KeyChar = "\" Or e.KeyChar = "=" Or e.KeyChar = "^" Then
            If fMembers.Visible Then
                If lstMembers.SelectedIndex > -1 Then
                    Dim OldStart As Integer = txtScript.SelectionStart
                    txtScript.LockUpdate = True
                    txtScript.SelectionStart = (DotPos + 1)
                    txtScript.SelectionLength = OldStart - (DotPos + 1)
                    txtScript.LockUpdate = False
                    txtScript.SelectedText = lstMembers.SelectedItem
                End If
                fMembers.Visible = False
            End If
            If e.KeyChar = vbCr Then fParam.Visible = False
        End If
        If e.KeyChar = "." Then
            'List members
            'fMembers.Visible = False
            fParamBasePt = txtScript.GetPositionFromCharIndex(txtScript.SelectionStart)
            RepositionMembersList()

            'Make sure it is a member of the current object
            DotPos = txtScript.SelectionStart
            fMembers.Visible = False
            lstMembers.Items.Clear()

            'Get the current type
            Dim tmpType As System.Type
            tmpType = GetCurType()
            If tmpType Is Nothing Then Exit Sub

            'List the members of the current member
            ListMembers(tmpType)

            If lstMembers.Items.Count = 0 Then Exit Sub
            lstMembers.SelectedIndex = 0
            'fMembers.Visible = True
            fMembers.ShowFloating()
        ElseIf e.KeyChar = "(" Then
            fMembers.Visible = False

            'Get the current type
            ReDim mi(0)
            Dim tmpType As System.Type
            tmpType = GetCurType(False, mi)
            If mi Is Nothing Then Exit Sub
            If mi.Length = 1 Then Exit Sub

            'Set the tooltip text
            CurIndex = 1
            SetTooltip(1)

            ParenthPos = txtScript.SelectionStart
            'fParam.Visible = True
            fParam.ShowFloating()
        ElseIf e.KeyChar = Chr(27) Then
            If fMembers.Visible Then
                fMembers.Visible = False
            ElseIf fParam.Visible Then
                fParam.Visible = False
            End If
        End If
    End Sub

    Sub RepositionMembersList()
        With fParamBasePt
            Dim tmpLoc As Point = fMembers.Parent.PointToScreen( _
                New Point(.X - 13 + txtScript.Left, .Y + 20 + txtScript.Top))
            'If fMembers.Left > txtScript.Left + txtScript.Width - fMembers.Width Then fMembers.Left = txtScript.Left + txtScript.Width - fMembers.Width
            'If fMembers.Top > txtScript.Top + txtScript.Height - fMembers.Height Then
            'fMembers.Top = .Y - fMembers.Height
            'End If
            If tmpLoc.X < 0 Then tmpLoc.X = 0
            If tmpLoc.X + fMembers.Width > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width Then tmpLoc.X = tmpLoc.X - fMembers.Width + 26
            If tmpLoc.X + fMembers.Width > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width Then tmpLoc.X = Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width - fMembers.Width
            If tmpLoc.Y + fMembers.Height > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height Then tmpLoc.Y = tmpLoc.Y - fMembers.Height - 40
            If tmpLoc.Y + fMembers.Height > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height Then tmpLoc.Y = Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height - fMembers.Height
            fMembers.Location = tmpLoc
        End With
    End Sub

    Sub RepositionParamsList()
        With fParamBasePt
            Dim tmpLoc As Point = fMembers.Parent.PointToScreen( _
                New Point(.X + 13 + txtScript.Left, .Y + 20 + txtScript.Top))
            If tmpLoc.X < 0 Then tmpLoc.X = 0
            If tmpLoc.X + fParam.Width > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width Then tmpLoc.X = tmpLoc.X - fParam.Width - 26
            If tmpLoc.X + fParam.Width > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width Then tmpLoc.X = Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Width - fParam.Width
            If tmpLoc.Y + fParam.Height > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height Then tmpLoc.Y = tmpLoc.Y - fParam.Height - 40
            If tmpLoc.Y + fParam.Height > Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height Then tmpLoc.Y = Screen.GetWorkingArea(New Rectangle(0, 0, 0, 0)).Height - fParam.Height
            fParam.Location = tmpLoc
        End With
    End Sub

    Sub SetTooltip(ByVal index As Integer) 'i=overload index
        'Create our StringBuilder
        Dim tmpStr As New System.Text.StringBuilder

        'Output the amount of methods
        If UBound(mi) > 1 Then
            tmpStr.Append("(" & index & " of " & UBound(mi) & ") ")
        End If

        'Output the method name
        If mi(index).Name.Length > 4 AndAlso mi(index).Name.Substring(0, 4) = "get_" Then
            tmpStr.Append(mi(index).Name.Substring(4) & "(")
        Else
            tmpStr.Append(mi(index).Name & "(")
        End If

        'Output the parameters
        Dim i As Integer, pi() As System.Reflection.ParameterInfo
        pi = mi(index).GetParameters
        For i = 0 To UBound(pi)
            With pi(i)
                If .IsOptional Then tmpStr.Append("[")
                tmpStr.Append(IIf(.ParameterType.IsByRef, "ByRef ", "") & .Name & " As " & GetTypeText(.ParameterType))
                If .IsOptional Then tmpStr.Append(" = " & .DefaultValue & "]")
            End With
            If i < UBound(pi) Then
                tmpStr.Append(", ")
            End If
        Next

        'Close it off
        tmpStr.Append(")")

        'If there is a return type...
        If mi(index).ReturnType.Name <> "Void" Then
            tmpStr.Append(" As " & GetTypeText(mi(index).ReturnType))
        End If

        'Set the label text
        lblParam.Text = tmpStr.ToString

        'Set the label size
        Dim lblW As Integer, lblH As Integer
        lblParam.AutoSize = False
        lblW = 288
        Dim tmpH As Integer
        lblH = lblParam.CreateGraphics.MeasureString(lblParam.Text, lblParam.Font, lblW).Height + 2
        tmpH = lblH
        While CInt(lblParam.CreateGraphics.MeasureString(lblParam.Text, lblParam.Font, lblW - 3).Height + 2) = tmpH
            lblW -= 1
        End While
        fParam.Size = New Size(lblW, lblH)

        'Adjust its position
        fParamBasePt = txtScript.GetPositionFromCharIndex(txtScript.SelectionStart)
        RepositionParamsList()
    End Sub

    Function GetTypeText(ByVal Type As System.Type) As String
        With Type
            Dim tmpName As String
            If .FullName = "System." & .Name Then
                Select Case .Name
                    Case "Int16"
                        tmpName = "Short"
                    Case "Int32"
                        tmpName = "Integer"
                    Case "Int64"
                        tmpName = "Long"
                    Case Else
                        tmpName = .Name
                End Select
            Else
                tmpName = .FullName
            End If
            If tmpName.Length > 2 AndAlso tmpName.Substring(tmpName.Length - 2, 2) = "[]" Then
                'Replace the [] with ()
                Return tmpName.Substring(0, tmpName.Length - 2) & "()"
            Else
                Return tmpName
            End If
        End With
    End Function

    Private Sub lblParam_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblParam.MouseDown
        If e.Button = MouseButtons.Left Then
            CurIndex += 1
            If CurIndex > UBound(mi) Then CurIndex = 1
        ElseIf e.Button = MouseButtons.Right Then
            CurIndex -= 1
            If CurIndex <= 0 Then CurIndex = UBound(mi)
        End If
        SetTooltip(CurIndex)
    End Sub

    Sub ListMembers(ByVal type As System.Type)
        Dim mi() As System.Reflection.MemberInfo
        With type
            lstMembers.Items.Clear()
            lstIcons.Clear()
            mi = .GetProperties
            Dim i As Integer
            For i = 0 To UBound(mi)
                Try
                    lstIcons.Add(mi(i).Name, 1)
                    lstMembers.Items.Add(mi(i).Name)
                Catch
                End Try
            Next
            mi = .GetMethods(Reflection.BindingFlags.Public Or Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Static)
            For i = 0 To UBound(mi)
                Try
                    If mi(i).Name.Length > 4 AndAlso mi(i).Name.Substring(0, 4) = "get_" Then Throw New Exception("Get Property")
                    If mi(i).Name.Length > 4 AndAlso mi(i).Name.Substring(0, 4) = "set_" Then Throw New Exception("Set Property")
                    If mi(i).Name.Length > 4 AndAlso mi(i).Name.Substring(0, 4) = "add_" Then Throw New Exception("Add Handler")
                    If mi(i).Name.Length > 7 AndAlso mi(i).Name.Substring(0, 7) = "remove_" Then Throw New Exception("Remove Handler")
                    'If mi(i).Name.Length > 4 AndAlso mi(i).Name.Substring(0, 4) = "Show" Then Throw New Exception("Showing a Window")
                    lstIcons.Add(mi(i).Name, 0)
                    lstMembers.Items.Add(mi(i).Name)
                Catch
                End Try
            Next
            mi = .GetFields()
            For i = 0 To UBound(mi)
                Try
                    If mi(i).Name.Length > 2 AndAlso mi(i).Name.Substring(0, 2) = "ps" Then Throw New Exception("Acessing a Control")
                    If mi(i).Name.Length > 3 AndAlso mi(i).Name.Substring(0, 3) = "win" AndAlso mi(i).Name.Substring(4, 1) <> "d" Then Throw New Exception("Acessing a Control")
                    lstMembers.Items.Add(mi(i).Name)
                    lstIcons.Add(mi(i).Name, 2)
                Catch
                End Try
            Next
        End With
    End Sub

    Private Sub lstMemebers_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstMembers.DrawItem
        If lstMembers.Enabled = False Then Exit Sub

        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable or OwnerDrawFixed

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return
        'a string variable to hold the text that I will draw
        Dim str As String = lstMembers.Items(e.Index)
        ' a graphic variable to minimize my typing :)
        Dim g As Graphics = e.Graphics
        'a couple of brush objects I'll need for filling rectangles
        Dim bBlue As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
        Dim bWhite As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Window))
        Dim bBlack As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.WindowText))

        'Adjust the value of Combobox.itemheight if the drawmode is ownerdrawfixed because the Measureitem event won't fire for that mode! This is necessary because the drawmode in this sample can be changed at runtime.
        Dim hgt As Single, imgIndex As Integer
        imgIndex = lstIcons(lstMembers.Items(e.Index))
        Dim img As Image = iml1.Images(imgIndex)
        If lstMembers.DrawMode = DrawMode.OwnerDrawFixed Then
            hgt = Math.Max(img.Height, e.Graphics.MeasureString(str, lstMembers.Font).Height) * 1.1
            lstMembers.ItemHeight = hgt
        End If

        'Determine if I'm highlighting the current combo box item because 
        'I want the selected item to look different from those that are not selected.
        Dim bHighlightItem As Boolean = (e.State And DrawItemState.Selected) 'Me.ShouldIHighlight(e.State)

        If bHighlightItem = True Then
            'fill the background of the item
            g.FillRectangle(bBlue, e.Bounds)
            'draw the image from the image list control, offset it by 5 pixels and makes sure it's centered vertically
            Dim myImage As Image = CType(iml1.Images(imgIndex), Image)
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            'draw the text, position it so that it starts 5 pixels to the right of the image
            g.DrawString(str, lstMembers.Font, bWhite, e.Bounds.Left + myimage.Width + 5, e.Bounds.Top)
        Else
            'this block does the same thing as above but uses different colors to represent the different state.
            g.FillRectangle(bWhite, e.Bounds)
            Dim myImage As Image = CType(iml1.Images(imgIndex), Image)
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - myImage.Height) \ 2)
            g.DrawString(str, lstMembers.Font, bBlack, e.Bounds.Left + myimage.Width + 5, e.Bounds.Top)
        End If
        'Dispose of my brushes
        bBlue.Dispose()
        bWhite.Dispose()
        bBlue = Nothing
        bWhite = Nothing
    End Sub

    Private Function ShouldIHighlight(ByVal State As DrawItemState) As Boolean
        Return State And DrawItemState.Selected
    End Function

    Private Sub txtScript_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScript.KeyDown
        Select Case e.KeyCode
            Case Keys.Tab, Keys.Enter, Keys.Space, Keys.Space
                If fMembers.Visible Then e.Handled = True
            Case Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Home, Keys.End
                fMembers.Visible = False
                fParam.Visible = False
            Case Keys.Back
                If txtScript.SelectionStart <= DotPos + 1 And fMembers.Visible Then
                    fMembers.Visible = False
                ElseIf txtScript.SelectionStart <= ParenthPos + 1 Then
                    fParam.Visible = False
                End If
        End Select
    End Sub

    Private Sub txtScript_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtScript.MouseDown
        fMembers.Visible = False
        fParam.Visible = False
    End Sub

    Private Sub lstMembers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMembers.DoubleClick
        If lstMembers.SelectedIndex > -1 Then
            txtScript.LockUpdate = True
            txtScript.Select(DotPos + 1, txtScript.SelectionStart - (DotPos + 1))
            txtScript.LockUpdate = False
            txtScript.SelectedText = lstMembers.SelectedItem
            fMembers.Visible = False
            txtScript.Select()
            txtScript.ScrollToCaret()
        End If
    End Sub
End Class
#End Region