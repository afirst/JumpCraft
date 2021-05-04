Public Class psStatus
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.StatusBarPanel1.Text = GetString("main_ReadyStatus")
        Me.StatusBarPanel2.Text = GetString("main_XLabel")
        Me.StatusBarPanel3.Text = GetString("main_YLabel")
        Me.StatusBarPanel4.Text = GetString("main_TileLabel")
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
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel4 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sb As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psStatus))
        Me.sb = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel4 = New System.Windows.Forms.StatusBarPanel()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sb
        '
        Me.sb.Location = New System.Drawing.Point(0, 56)
        Me.sb.Name = "sb"
        Me.sb.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3, Me.StatusBarPanel4})
        Me.sb.ShowPanels = True
        Me.sb.Size = New System.Drawing.Size(592, 16)
        Me.sb.TabIndex = 0
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.MinWidth = 150

        Me.StatusBarPanel1.Width = 261
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised
        Me.StatusBarPanel2.Icon = CType(resources.GetObject("StatusBarPanel2.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel2.MinWidth = 50

        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised
        Me.StatusBarPanel3.Icon = CType(resources.GetObject("StatusBarPanel3.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel3.MinWidth = 50

        '
        'StatusBarPanel4
        '
        Me.StatusBarPanel4.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised
        Me.StatusBarPanel4.Icon = CType(resources.GetObject("StatusBarPanel4.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel4.MinWidth = 100

        Me.StatusBarPanel4.Width = 120
        '
        'psStatus
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sb})
        Me.Name = "psStatus"
        Me.Size = New System.Drawing.Size(592, 72)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Property PanelText(ByVal index As Integer) As String
        Get
            Return sb.Panels(index).Text
        End Get
        Set(ByVal Value As String)
            sb.Panels(index).Text = Value
        End Set
    End Property

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Editor.psstatus = Me
    End Sub

    Dim tmpIcon2 As Icon, tmpIcon3 As Icon, tmpIcon4 As Icon
    Sub UpdateImages()
        If Editor.psedit.PathEdit.Editing Then
            tmpIcon2 = sb.Panels(1).Icon.Clone
            tmpIcon3 = sb.Panels(2).Icon.Clone
            tmpIcon4 = sb.Panels(3).Icon.Clone
            sb.Panels(1).Icon = Nothing
            sb.Panels(2).Icon = Nothing
            sb.Panels(3).Icon = Nothing
            sb.Panels(3).Text = ""
        Else
            sb.Panels(1).Icon = tmpIcon2
            sb.Panels(2).Icon = tmpIcon3
            sb.Panels(3).Icon = tmpIcon4
        End If
    End Sub
End Class
