Imports PlatformStudio

Public Class psLevelSelector
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.btnNewLevel.ToolTipText = GetString("newLevelIconTooltip")
        Me.btnRenameLevel.ToolTipText = GetString("renameLevelIconTooltip")
        Me.btnDeleteLevel.ToolTipText = GetString("deleteLevelIconTooltip")
        Me.btnMoveUp.ToolTipText = GetString("moveLevelUpIconTooltip")
        Me.btnMoveDown.ToolTipText = GetString("moveLevelDownIconTooltip")
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
    Friend WithEvents btnNewLevel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRenameLevel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDeleteLevel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveUp As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnMoveDown As System.Windows.Forms.ToolBarButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psLevelSelector))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbrMain = New UIPlus.UIPlusToolbar
        Me.btnNewLevel = New System.Windows.Forms.ToolBarButton
        Me.btnRenameLevel = New System.Windows.Forms.ToolBarButton
        Me.btnDeleteLevel = New System.Windows.Forms.ToolBarButton
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
        Me.Panel1.Size = New System.Drawing.Size(160, 184)
        Me.Panel1.TabIndex = 0
        '
        'tbrMain
        '
        Me.tbrMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tbrMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnNewLevel, Me.btnRenameLevel, Me.btnDeleteLevel, Me.btnSep1, Me.btnMoveUp, Me.btnMoveDown})
        Me.tbrMain.CustomColorScheme = Nothing
        Me.tbrMain.Divider = False
        Me.tbrMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tbrMain.DropDownArrows = True
        Me.tbrMain.ImageList = Me.iml
        Me.tbrMain.Location = New System.Drawing.Point(16, 157)
        Me.tbrMain.Name = "tbrMain"
        Me.tbrMain.ShowToolTips = True
        Me.tbrMain.Size = New System.Drawing.Size(128, 26)
        Me.tbrMain.TabIndex = 22
        '
        'btnNewLevel
        '
        Me.btnNewLevel.ImageIndex = 0

        '
        'btnRenameLevel
        '
        Me.btnRenameLevel.ImageIndex = 1

        '
        'btnDeleteLevel
        '
        Me.btnDeleteLevel.ImageIndex = 2

        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnMoveUp
        '
        Me.btnMoveUp.ImageIndex = 3

        '
        'btnMoveDown
        '
        Me.btnMoveDown.ImageIndex = 4

        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Items.AddRange(New Object() {"Level1"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(160, 155)
        Me.ListBox1.TabIndex = 21
        '
        'psLevelSelector
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.Panel1)
        Me.Name = "psLevelSelector"
        Me.Size = New System.Drawing.Size(160, 184)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub Init()
        If Game Is Nothing Then Exit Sub
        Editor.pslevelsel = Me
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndices.Count = 0 Then Exit Sub
        Dim tmpLayer As Integer
        tmpLayer = psMap.CurLayer
        Game.CurMapIndex = ListBox1.SelectedIndices(0) + 1
        psMap.CurLayer = tmpLayer
        Editor.psedit.DoResize()
        UpdateEnabledState()
    End Sub

    Sub UpdateEnabledState()
        If tbrMain Is Nothing Then Exit Sub
        tbrMain.Buttons(3).Enabled = True
        tbrMain.Buttons(4).Enabled = True
        If ListBox1.SelectedIndex = 0 Then tbrMain.Buttons(3).Enabled = False
        If ListBox1.SelectedIndex = ListBox1.Items.Count - 1 Then tbrMain.Buttons(4).Enabled = False
    End Sub

    Overrides Sub Refresh()
        Dim i As Integer, tmp As Integer
        With ListBox1
            If .SelectedIndices.Count = 1 Then
                tmp = .SelectedIndices(0)
            Else
                tmp = -1
            End If
            .Items.Clear()
            For i = 1 To UBound(Game.maps)
                .Items.Add(Game.maps(i).MapName)
            Next
            If (.Items.Count > 0) Then
                If tmp = -1 Then
                    .SelectedItem = .Items(0)
                ElseIf tmp > .Items.Count - 1 Then
                    .SelectedItem = .Items(.Items.Count - 1)
                Else
                    .SelectedItem = .Items(tmp)
                End If
            Else
                .SelectedIndex = -1
            End If
        End With
        UpdateEnabledState()
    End Sub

    Sub SelectLast()
        With ListBox1
            If .Items.Count > 0 Then
                .SelectedItem = .Items(.Items.Count - 1)
            End If
        End With
    End Sub

    Delegate Function ReachedMaxLevels() As Boolean

    Private Sub tbrMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMain.ButtonClick
        psFileHandler.MadeChanges = True
        Select Case True
            Case e.Button Is btnNewLevel
                If Not (Game.ReachedMaxLevels Is Nothing) AndAlso Game.ReachedMaxLevels.DynamicInvoke(Nothing) = True Then Exit Sub
                Dim f As New psfrmNewLevelDialog
                f.TextBox1.Text = String.Format(GetString1("defaultLevelName"), Game.numMaps + 1)
                f.ShowDialog()
            Case e.Button Is btnRenameLevel
                If ListBox1.SelectedIndex = -1 Then Return
                Dim NewName As String
                NewName = InputBox(GetString("renameLevelDialogMessage"), GetString("renameLevelIconTooltip"), Game.maps(ListBox1.SelectedIndex + 1).MapName)
                If NewName = "" Then Exit Sub
                UndoRedo.UpdateUndo(GetString("renameLevelIconTooltip"), UndoRedo.UndoType.Level, Game.CurMapIndex)
                Game.maps(ListBox1.SelectedIndex + 1).MapName = NewName
                Refresh()
            Case e.Button Is btnDeleteLevel
                If ListBox1.SelectedIndex = -1 Then Return
                'Make sure the user wants to delete
                '(look at location and group actions)
                Dim i As Integer, j As Integer
                If Options.gWarnWhenDelActions Then
                    With Game.actions
                        For i = 1 To UBound(.Actions)
                            If (.Actions(i).Trigger.Chars(0) = "l" Or .Actions(i).Trigger.Chars(0) = "g") AndAlso .Actions(i).Trigger.Substring(4, 5) = Value Then
                                If MessageBox.Show(GetString("deleteActionConfirmationMessage"), GetString("deleteLevelIconTooltip"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                    Exit Sub
                                Else
                                    Exit For
                                End If
                            End If
                        Next
                    End With
                End If

ReadyToDelete:
                Editor.psedit.Deselect()
                Dim tmpLoc As Integer
                tmpLoc = psMap.CurLayer
                UndoRedo.UpdateUndo(GetString("deleteLevelIconTooltip"), UndoRedo.UndoType.All)
                Game.RemoveMap(ListBox1.SelectedIndices(0) + 1)

                'Delete actions (location, group, and level actions)
                With Game.actions
                    For i = 1 To UBound(.Actions)
                        If i > UBound(.Actions) Then Exit For
                        If (.Actions(i).Trigger.Chars(0) = "l" Or .Actions(i).Trigger.Chars(0) = "g" Or (.Actions(i).Trigger.Length > 4 AndAlso .Actions(i).Trigger.Substring(0, 4) = "nblv")) Then
                            If .Actions(i).Trigger.Substring(4, 5) = Value Then
                                For j = i To UBound(.Actions) - 1
                                    .Actions(j) = .Actions(j + 1)
                                Next
                                ReDim Preserve .Actions(UBound(.Actions) - 1)
                                i -= 1
                            ElseIf .Actions(i).Trigger.Substring(4, 5) > Value Then
                                .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & Format((CInt(.Actions(i).Trigger.Substring(4, 5)) - 1), "00000") & .Actions(i).Trigger.Substring(9)
                            End If
                        End If
                    Next
                End With

                If Game.numMaps = 0 Then
                    Game.AddMap()
                    Editor.psedit.DoResize()
                End If
                psMap.CurLayer = tmpLoc
                Refresh()
            Case e.Button Is btnMoveUp
                If ListBox1.SelectedIndex <= 0 Then Return
                UndoRedo.UpdateUndo(GetString("moveLevelUpIconTooltip"), UndoRedo.UndoType.All)
                MoveLevel(-1)
            Case e.Button Is btnMoveDown
                If ListBox1.SelectedIndex = -1 OrElse ListBox1.SelectedIndex >= ListBox1.Items.Count - 1 Then Return
                UndoRedo.UpdateUndo(GetString("moveLevelDownIconTooltip"), UndoRedo.UndoType.All)
                MoveLevel(1)
        End Select
    End Sub

    Sub MoveLevel(ByVal Amount As Integer)
        With ListBox1
            Editor.psedit.LockUpdate()

            'Move the map
            Dim tmpM As psMap
            tmpM = Game.maps(.SelectedIndex + 1)
            Game.maps(.SelectedIndex + 1) = Game.maps(.SelectedIndex + 1 + Amount)
            Game.maps(.SelectedIndex + 1 + Amount) = tmpM

            'Update actions
            Dim i As Integer
            With Game.actions
                For i = 1 To UBound(.Actions)
                    If i > UBound(.Actions) Then Exit For
                    If (.Actions(i).Trigger.Chars(0) = "l" Or .Actions(i).Trigger.Chars(0) = "g" Or (.Actions(i).Trigger.Length > 4 AndAlso .Actions(i).Trigger.Substring(0, 4) = "nblv")) Then
                        If .Actions(i).Trigger.Substring(4, 5) = Value Then
                            .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & (Format(Value + Amount, "00000")) & .Actions(i).Trigger.Substring(9)
                        ElseIf .Actions(i).Trigger.Substring(4, 5) = Value + Amount Then
                            .Actions(i).Trigger = .Actions(i).Trigger.Substring(0, 4) & (Format(Value, "00000")) & .Actions(i).Trigger.Substring(9)
                        End If
                    End If
                Next
            End With

            'Update the list
            Refresh()

            'Update the selected item
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + Amount

            Editor.psedit.UnlockUpdate()
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
End Class
