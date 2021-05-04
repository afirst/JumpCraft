Imports PlatformStudio

Public Class psControlActionSelector
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        SelectThroughCode = True

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SelectThroughCode = False
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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psControlActionSelector))
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(160, 141)
        Me.ListBox1.TabIndex = 20
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(16, 16)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "All Files|*.*"
        '
        'psControlActionSelector
        '
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "psControlActionSelector"
        Me.Size = New System.Drawing.Size(160, 141)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim SelectThroughCode As Boolean

    Property Value() As Integer
        Get
            Return ListBox1.SelectedIndex
        End Get
        Set(ByVal Value As Integer)
            SelectThroughCode = True
            ListBox1.SelectedIndex = Value
            SelectThroughCode = False
        End Set
    End Property

    Sub Deselect()
        SelectThroughCode = True
        ListBox1.SelectedIndex = -1
        SelectThroughCode = False
    End Sub

    Private Sub psControlActionSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Game Is Nothing Then Exit Sub
        Game.windows.winctrlactions = Me
        Refresh()
    End Sub

    Dim ImmediateExit As Boolean

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ImmediateExit Then Exit Sub

        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If Game.windows.winedit.NumSelCtrls <> 1 Then Exit Sub

        If SelectThroughCode Then
            UpdateSelItemText()
            Exit Sub
        End If

        Dim tmpStr As String
        Dim tmpParam1 As String, tmpParam2 As String, tmpParam3 As Integer
        With Game.windows.winedit.FirstSelCtrl
            If .Action <> Value Then
                tmpParam1 = ""
                tmpParam2 = ""
                tmpParam3 = 0
            Else
                tmpParam1 = .Param1
                tmpParam2 = .Param2
                tmpParam3 = .Param3
            End If
            Select Case CType(ListBox1.SelectedIndex, psUI.psControl.psCtrlAction)
                Case psUI.psControl.psCtrlAction.ShowWindow
                    If tmpParam1 = "" Then tmpParam1 = 1
                    Dim f As New psfrmWindowSelector
                    If f.ShowDialog(tmpParam1) <> DialogResult.OK Then
                        f.Dispose()
                        SelectThroughCode = True
                        Value = .Action
                        SelectThroughCode = False
                        Exit Sub
                    Else
                        UpdateUndo("Set Control Action", psMod1.UndoType.Windows)
                        .Param1 = tmpParam1
                        f.Dispose()
                    End If
                Case psUI.psControl.psCtrlAction.MessageBox
                    Dim f As New psfrmMsgBoxEditor
                    If f.ShowDialog(tmpParam1, tmpParam2, tmpParam3) <> DialogResult.OK Then
                        f.Dispose()
                        SelectThroughCode = True
                        Value = .Action
                        SelectThroughCode = False
                        Exit Sub
                    Else
                        UpdateUndo("Set Control Action", psMod1.UndoType.Windows)
                        .Param1 = tmpParam1
                        .Param2 = tmpParam2
                        .Param3 = tmpParam3
                        f.Dispose()
                    End If
                Case psUI.psControl.psCtrlAction.OpenFile
                    dlgOpen.FileName = tmpParam1
                    dlgOpen.Title = "Select a File"
                    If dlgOpen.ShowDialog = DialogResult.Cancel Then
                        SelectThroughCode = True
                        Value = .Action
                        SelectThroughCode = False
                        Exit Sub
                    End If
                    UpdateUndo("Set Control Action", psMod1.UndoType.Windows)
                    .Param1 = dlgOpen.FileName
                Case psUI.psControl.psCtrlAction.OpenURL
                    tmpStr = InputBox("Enter a URL:", "Control Action Selector", tmpParam1)
                    If tmpStr = "" Then
                        SelectThroughCode = True
                        Value = .Action
                        SelectThroughCode = False
                        Exit Sub
                    End If
                    UpdateUndo("Set Control Action", psMod1.UndoType.Windows)
                    .Param1 = tmpStr
                Case psUI.psControl.psCtrlAction.RunScript
                    Dim f As New psfrmScriptEditor
                    If f.ShowDialog(tmpParam1, "u") = DialogResult.Cancel Then
                        f.Dispose()
                        SelectThroughCode = True
                        Value = .Action
                        SelectThroughCode = False
                        Exit Sub
                    End If
                    UpdateUndo("Set Control Action", psMod1.UndoType.WindowsAndActions)
                    .Param1 = tmpParam1
                    Game.actions.Globals = f.txtMScript.Text
                    f.Dispose()
            End Select
            .Action = Value

            UpdateSelItemText()
        End With
    End Sub

    Private Sub UpdateSelItemText()
        ImmediateExit = True
        Refresh()
        With Game.windows.winedit.FirstSelCtrl
            Select Case ListBox1.SelectedIndex
                Case 1  'ShowWindow
                    ListBox1.Items(ListBox1.SelectedIndex) &= " (" & Game.windows.Windows(.Param1).Name & ")"
                Case 2 'Three parameters
                    ListBox1.Items(ListBox1.SelectedIndex) &= " (" & .Param1 & ", " & .Param2 & ", " & .Param3 & ")"
                Case 3, 4, 7 'One parameter
                    ListBox1.Items(ListBox1.SelectedIndex) &= " (" & .Param1 & ")"
                Case Else 'No parameters = no change                
            End Select
        End With
        ImmediateExit = False
    End Sub

    Overloads Sub Refresh()
        Dim tmpSel As Integer
        tmpSel = ListBox1.SelectedIndex
        With ListBox1.Items
            .Clear()
            .Add("(None)")
            .Add("Show Window")
            .Add("Message Box")
            .Add("Open File")
            .Add("Open URL")
            .Add("Pause Game")
            .Add("Quit Game")
            .Add("Run Script")
            .Add("Exit")
        End With
        ListBox1.SelectedIndex = tmpSel
    End Sub
End Class
