Imports PlatformStudio

Public Class psWinSelector
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.btnNew.ToolTipText = GetString("newWindowIconTooltip")
        Me.btnCopy.ToolTipText = GetString("copyWindowIconTooltip")
        Me.btnRename.ToolTipText = GetString("renameWindowIconTooltip")
        Me.btnDelete.ToolTipText = GetString("deleteWindowIconTooltip")
        Me.btnMoveUp.ToolTipText = GetString("moveWindowUpIconTooltip")
        Me.btnMoveDown.ToolTipText = GetString("moveWindowDownIconTooltip")
        Panel1.BackColor = UIPlus.DefaultColorScheme.getInstance.MenuBack
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
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbrMain As UIPlus.UIPlusToolbar
    Friend WithEvents btnNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCopy As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRename As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveUp As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveDown As System.Windows.Forms.ToolBarButton
    Public WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psWinSelector))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbrMain = New UIPlus.UIPlusToolbar
        Me.btnNew = New System.Windows.Forms.ToolBarButton
        Me.btnCopy = New System.Windows.Forms.ToolBarButton
        Me.btnRename = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton
        Me.btnMoveUp = New System.Windows.Forms.ToolBarButton
        Me.btnMoveDown = New System.Windows.Forms.ToolBarButton
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.iml.ImageSize = New System.Drawing.Size(16, 16)
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.White
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbrMain)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 168)
        Me.Panel1.TabIndex = 0
        '
        'tbrMain
        '
        Me.tbrMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tbrMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNew, Me.btnCopy, Me.btnRename, Me.btnDelete, Me.btnSep1, Me.btnMoveUp, Me.btnMoveDown})
        Me.tbrMain.CustomColorScheme = Nothing
        Me.tbrMain.Divider = False
        Me.tbrMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tbrMain.DropDownArrows = True
        Me.tbrMain.ImageList = Me.iml
        Me.tbrMain.Location = New System.Drawing.Point(4, 142)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.ShowToolTips = True
        Me.tbrMain.Size = New System.Drawing.Size(152, 26)
        Me.tbrMain.TabIndex = 25
        '
        'btnNew
        '
        Me.btnNew.ImageIndex = 0

        '
        'btnCopy
        '
        Me.btnCopy.ImageIndex = 1

        '
        'btnRename
        '
        Me.btnRename.ImageIndex = 2

        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 3

        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnMoveUp
        '
        Me.btnMoveUp.ImageIndex = 4

        '
        'btnMoveDown
        '
        Me.btnMoveDown.ImageIndex = 5

        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Items.AddRange(New Object() {"Window1"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(160, 141)
        Me.ListBox1.TabIndex = 24
        '
        'psWinSelector
        '
        Me.Controls.Add(Me.Panel1)
        Me.Name = "psWinSelector"
        Me.Size = New System.Drawing.Size(160, 168)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const MaxWindows As Integer = 1024

    Private Sub psWinSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Register control
        If Game Is Nothing Then Exit Sub
        Editor.winsel = Me
        ListBox1.SelectedIndex = 0
    End Sub

    Public doNotUpdate As Boolean
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If doNotUpdate Then Return
        If Not (Game Is Nothing) AndAlso _
        Not (Editor.winedit) Is Nothing AndAlso _
        Not (Editor.winedit.NumSelCtrls = 0) Then
            Editor.winedit.Deselect()
        End If
        If ListBox1.SelectedIndices.Count = 0 Then Exit Sub
        Game.CurWinIndex = ListBox1.SelectedIndices(0) + 1
        Try
            Editor.winedit.DoResize()
        Catch
        End Try
        UpdateEnabledState()
        If Not Editor.winedit Is Nothing Then Editor.winedit.UpdateSel()
    End Sub

    Sub SelectLast()
        With ListBox1
            .SelectedItem = .Items(.Items.Count - 1)
        End With
    End Sub

    Property Value() As Integer
        Get
            Return ListBox1.SelectedIndex + 1
        End Get
        Set(ByVal Value As Integer)
            ListBox1.SelectedIndex = Value - 1
        End Set
    End Property

    Overrides Sub Refresh()
        Dim i As Integer, tmp As Integer
        With ListBox1
            If .SelectedIndices.Count = 1 Then
                tmp = .SelectedIndices(0)
            Else
                tmp = -1
            End If
            .Items.Clear()
            For i = 1 To UBound(Game.windows.Windows)
                .Items.Add(Game.windows.Windows(i).Name)
            Next
            If tmp = -1 Then
                .SelectedItem = .Items(0)
            ElseIf tmp > .Items.Count - 1 Then
                .SelectedItem = .Items(.Items.Count - 1)
            Else
                .SelectedItem = .Items(tmp)
            End If
        End With
        UpdateEnabledState()
    End Sub

    Sub UpdateEnabledState()
        If tbrMain Is Nothing Then Exit Sub
        Try
            tbrMain.Buttons(1).Enabled = (ListBox1.SelectedIndex > -1)
            btnMoveUp.Enabled = True
            btnMoveDown.Enabled = True
            If ListBox1.SelectedIndex = 0 Then btnMoveUp.Enabled = False
            If ListBox1.SelectedIndex = ListBox1.Items.Count - 1 Then btnMoveDown.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub tbrMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMain.ButtonClick
        psFileHandler.MadeChanges = True
        Select Case True
            Case e.Button Is btnNew
                If Not (Game.ReachedMaxWindows Is Nothing) AndAlso Game.ReachedMaxWindows.DynamicInvoke(Nothing) = True Then Exit Sub
                'If UBound(Game.windows.Windows) >= MaxWindows Then
                '    MessageBox.Show("You have reached the limit of " & MaxWindows & " windows in your game." & vbCrLf & vbCrLf & "You may not add another window.", "Max. Window Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
                Dim f As New psfrmNewWindowDialog
                f.TextBox1.Text = String.Format(GetString1("defaultWindowName"), Game.numWindows + 1)
                f.ShowDialog()
                f.Dispose()
            Case e.Button Is btnCopy
                If Not (Game.ReachedMaxWindows Is Nothing) AndAlso Game.ReachedMaxWindows.DynamicInvoke(Nothing) = True Then Exit Sub
                If ListBox1.SelectedIndex = -1 Then Exit Sub
                'If UBound(Game.windows.Windows) >= MaxWindows Then
                '    MessageBox.Show("You have reached the limit of " & MaxWindows & " windows in your game." & vbCrLf & vbCrLf & "You may not add another window.", "Max. Window Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
                UndoRedo.UpdateUndo(GetString("copyWindowIconTooltip"), UndoRedo.UndoType.Windows)
                Game.windows.NewWindow()
                Game.windows.Windows(Game.numWindows) = Game.CurWindow.Clone(True, True)
                Dim Suffix As String = 2
                Dim tmpName As String = Game.windows.Windows(Game.numWindows).Name
CheckAgain:
                For i As Integer = 1 To Game.numWindows - 1
                    If Game.windows.Windows(i).Name = tmpName & Suffix Then
                        Suffix += 1
                        GoTo CheckAgain
                    End If
                Next
                Game.windows.Windows(Game.numWindows).Name = tmpName & Suffix
                ListBox1.Items.Add(Game.windows.Windows(Game.numWindows).Name)
                ListBox1.SelectedIndex = ListBox1.Items.Count - 1
            Case e.Button Is btnRename
                Dim NewName As String
                'NewName = InputBox("Enter a new name for this window.", "Rename Window", Game.windows.Windows(ListBox1.SelectedIndex + 1).Name)
                'If NewName = "" Then Exit Sub
                Dim f As New psfrmNewWindowDialog
                NewName = f.ShowRenameWindow(Game.windows.Windows(ListBox1.SelectedIndex + 1).Name)
                f.Dispose()
                'UpdateUndo("Rename Window")
                Game.windows.Windows(ListBox1.SelectedIndex + 1).Name = NewName
                Refresh()
            Case e.Button Is btnDelete
                UndoRedo.UpdateUndo(GetString("deleteWindowIconTooltip"), UndoRedo.UndoType.Windows)

                'Update windows actions and transitions
                For i As Integer = 1 To Game.numWindows
                    With Game.windows.Windows(i)
                        If .TransitionTo = ListBox1.SelectedIndex + 1 Then
                            .TransitionTo = 0
                        ElseIf .TransitionTo > ListBox1.SelectedIndex + 1 Then
                            .TransitionTo -= 1
                        End If
                    End With
                Next
                For i As Integer = 1 To UBound(Game.actions.Actions)
                    With Game.actions.Actions(i).Action
                        If .Behavior.Name = "Show Window Index" Then
                            If .param(1) = ListBox1.SelectedIndex + 1 Then
                                .Type = 75
                                .param(1) = "Show Window Index(" & .param(1) & ") :: Window Deleted"
                            ElseIf .param(1) > ListBox1.SelectedIndex + 1 Then
                                .param(1) = CInt(.param(1)) - 1
                            End If
                        ElseIf .Behavior.Name = "Show Window by Name" Then
                            If .param(1) = ListBox1.SelectedItem Then
                                .Type = 75
                                .param(1) = "Show Window by Name(" & .param(1) & ") :: Window Deleted"
                            End If
                        End If
                    End With
                Next

                Game.RemoveWindow(ListBox1.SelectedIndices(0) + 1)
                If Game.numWindows = 0 Then Game.AddWindow()
                Refresh()
            Case e.Button Is btnMoveUp
                UndoRedo.UpdateUndo(GetString("moveWindowUpIconTooltip"), UndoRedo.UndoType.Windows)
                MoveWindow(-1)
            Case e.Button Is btnMoveDown
                UndoRedo.UpdateUndo(GetString("moveWindowDownIconTooltip"), UndoRedo.UndoType.Windows)
                MoveWindow(1)
        End Select
    End Sub

    Sub MoveWindow(ByVal Amount As Integer)
        With ListBox1
            Editor.winedit.LockUpdate()

            'Update windows actions and transitions
            For i As Integer = 1 To Game.numWindows
                With Game.windows.Windows(i)
                    If .TransitionTo = ListBox1.SelectedIndex + 1 Then
                        .TransitionTo = ListBox1.SelectedIndex + 1 + Amount
                    ElseIf .TransitionTo = ListBox1.SelectedIndex + 1 + Amount Then
                        .TransitionTo = ListBox1.SelectedIndex + 1
                    End If
                End With
            Next
            For i As Integer = 1 To UBound(Game.actions.Actions)
                With Game.actions.Actions(i).Action
                    If .Behavior.Name = "Show Window Index" Then
                        If .param(1) = ListBox1.SelectedIndex + 1 Then
                            .param(1) = ListBox1.SelectedIndex + 1 + Amount
                        ElseIf .param(1) = ListBox1.SelectedIndex + 1 + Amount Then
                            .param(1) = ListBox1.SelectedIndex + 1
                        End If
                    End If
                End With
            Next

            'Move the window
            Dim tmpW As psUI.psWindows.psWindow
            tmpW = Game.windows.Windows(.SelectedIndex + 1)
            Game.windows.Windows(.SelectedIndex + 1) = Game.windows.Windows(.SelectedIndex + 1 + Amount)
            Game.windows.Windows(.SelectedIndex + 1 + Amount) = tmpW

            'Update the list
            Refresh()

            'Update the selected item
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + Amount

            Editor.winedit.UnlockUpdate()
        End With
    End Sub
End Class