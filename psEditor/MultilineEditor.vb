Imports System.Windows.Forms.Design

Public Class MultilineEditorControl
    Inherits System.Windows.Forms.UserControl

    Private edSvc As IWindowsFormsEditorService

    Public Sub New(ByVal value As String, ByVal edSvc As IWindowsFormsEditorService)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("multilineEditor_CloseButton")
        Me.Button1.Text = GetString("multilineEditor_InsertVariableButton")
        txt.Text = value

        'Stores IWindowsFormsEditorService reference to use to 
        'close the control.
        Me.edSvc = edSvc

        'Init owner-drawn menus
        UiPlusMenu1.Initialize(fGame, ContextMenu1)
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
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents UiPlusMenu1 As UIPlus.UIPlusMenu
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txt = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.UiPlusMenu1 = New UIPlus.UIPlusMenu(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt
        '
        Me.txt.AcceptsReturn = True
        Me.txt.AcceptsTab = True
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.Location = New System.Drawing.Point(0, 0)
        Me.txt.Multiline = True
        Me.txt.Name = "txt"
        Me.txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt.Size = New System.Drawing.Size(144, 120)
        Me.txt.TabIndex = 0
        Me.txt.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 24)
        Me.Panel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(96, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 23)
        Me.Button2.TabIndex = 1

        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 0

        '
        'UiPlusMenu1
        '
        Me.UiPlusMenu1.CustomColorScheme = Nothing
        '
        'MultilineEditorControl
        '
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MultilineEditorControl"
        Me.Size = New System.Drawing.Size(144, 144)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Overrides Property Text() As String
        Get
            Return txt.Text
        End Get
        Set(ByVal Value As String)
            txt.Text = Value
        End Set
    End Property

    Private Sub Button1_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Button1.MouseDown
        With ContextMenu1.MenuItems
            .Clear()
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_LevelNameVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_LevelNumberVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_NameOfGameVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_VersionVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_WebsiteVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_SupportEmailVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_CompanyVariable"), AddressOf ClickMenuItem))
            UiPlusMenu1.HandleMenuItem(.Add(GetString("multilineEditor_CreditsVariable"), AddressOf ClickMenuItem))
            For i As Integer = 1 To UBound(Game.actions.Counters)
                UiPlusMenu1.HandleMenuItem(.Add(String.Format(GetString("multilineEditor_CounterVariable"), Game.actions.Counters(i).Name), AddressOf ClickMenuItem))
            Next
        End With
        ContextMenu1.Show(Button1, New Point(0, Button1.Height))
        txt.Select()
    End Sub

    Sub ClickMenuItem(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Integer = DirectCast(sender, MenuItem).Index
        Select Case i
            Case 0
                txt.SelectedText = "&LevelName"
            Case 1
                txt.SelectedText = "&LevelNumber"
            Case 2
                txt.SelectedText = "&GameName"
            Case 3
                txt.SelectedText = "&Version"
            Case 4
                txt.SelectedText = "&Website"
            Case 5
                txt.SelectedText = "&Support"
            Case 6
                txt.SelectedText = "&Company"
            Case 7
                txt.SelectedText = "&Credits"
            Case Else
                txt.SelectedText = "&" & Game.actions.Counters(i - 7).Name
        End Select
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp, Button2.MouseUp
        txt.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        edSvc.CloseDropDown()
    End Sub
End Class