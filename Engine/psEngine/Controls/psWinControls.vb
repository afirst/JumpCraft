Public Class psWinControls
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Public WithEvents list As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents iml As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Pointer"}, 0, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Button"}, 1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Label"}, 2, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Image"}, 3, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Game Area"}, 4, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Text Counter", 5)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image & Text Counter", 6)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image Counter", 7)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("High Scores Area", 8)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Movie", 9)
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psWinControls))
        Me.Label1 = New System.Windows.Forms.Label
        Me.list = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Controls"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'list
        '
        Me.list.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.FullRowSelect = True
        Me.list.HideSelection = False
        Me.list.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10})
        Me.list.LargeImageList = Me.iml
        Me.list.Location = New System.Drawing.Point(0, 20)
        Me.list.MultiSelect = False
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(136, 300)
        Me.list.SmallImageList = Me.iml
        Me.list.StateImageList = Me.iml
        Me.list.TabIndex = 7
        Me.list.View = System.Windows.Forms.View.SmallIcon
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 120
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.iml.ImageSize = New System.Drawing.Size(20, 20)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'psWinControls
        '
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Label1)
        Me.Name = "psWinControls"
        Me.Size = New System.Drawing.Size(136, 320)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub psWinControls_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Register control
        If Game Is Nothing Then Exit Sub
        Game.windows.winctrls = Me
        list.Items(0).Selected = True
    End Sub

    Property Value() As Integer
        Get
            If list.SelectedIndices.Count = 0 Then list.Items(0).Selected = True
            Return list.SelectedIndices(0)
        End Get
        Set(ByVal Value As Integer)
            list.Items(Value).Selected = True
        End Set
    End Property

    Private Sub list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list.SelectedIndexChanged
        If Game Is Nothing Then Exit Sub
        If Game.windows.winedit Is Nothing Then Exit Sub
        If Game.windows.winedit.NumSelCtrls = 0 Then Exit Sub
        Game.windows.winedit.Deselect()
    End Sub

    Public Property TitleBarVisible() As Boolean
        Get
            Return Label1.Visible
        End Get
        Set(ByVal Value As Boolean)
            Label1.Visible = Value
        End Set
    End Property
End Class