Imports PlatformStudio

Public Class psfrmTileBehavior
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Label1.Text = GetString("tileBehaviorEd_CategoriesLabel")
        Me.Label2.Text = GetString("tileBehaviorEd_CustomizeLabel")
        Me.Button5.Text = GetString("okButton")
        Me.Button6.Text = GetString("cancelButton")
        Me.txtS.Text = GetString1("noValue")
        Me.lblS.Text = GetString("tileBehaviorEd_SoundOnCollisionLabel")
        Me.Text = GetString("tileBehaviorEd_Title")
        Me.tv.Nodes.AddRange(New System.Windows.Forms.TreeNode() { _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_Background"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_CurrentValue")), _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_NormalValue"))}), _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_Character"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_CurrentValue")), _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_NormalValue"))}), _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_Collectable"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_CurrentValue")), _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_NormalValue")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Bullet")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Coin")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_ExtraLife")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Gem")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Heart"))}), _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_Ledge"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_CurrentValue")), _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_NormalValue"))}), _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_NoGravity"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Ladder")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Water"))}), _
            New System.Windows.Forms.TreeNode(GetString("tileBehavior_Solid"), _
            New System.Windows.Forms.TreeNode() { _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_CurrentValue")), _
                New System.Windows.Forms.TreeNode(GetString("tileBehaviorEd_NormalValue")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Disintegrate")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Enemy")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Exit")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Fire")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Ice")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_SpikeDown")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_SpikeLeft")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_SpikeRight")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_SpikeUp")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Spring")), _
                New System.Windows.Forms.TreeNode(GetString("gameObjects_Unstable"))})})
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP3 As System.Windows.Forms.TextBox
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents txtP2 As System.Windows.Forms.TextBox
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents txtP1 As System.Windows.Forms.TextBox
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblS As System.Windows.Forms.Label
    Friend WithEvents txtS As System.Windows.Forms.TextBox
    Friend WithEvents btnS As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.tv = New System.Windows.Forms.TreeView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnS = New System.Windows.Forms.Button
        Me.txtS = New System.Windows.Forms.TextBox
        Me.lblS = New System.Windows.Forms.Label
        Me.txtP3 = New System.Windows.Forms.TextBox
        Me.lblP3 = New System.Windows.Forms.Label
        Me.txtP2 = New System.Windows.Forms.TextBox
        Me.lblP2 = New System.Windows.Forms.Label
        Me.txtP1 = New System.Windows.Forms.TextBox
        Me.lblP1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0

        '
        'tv
        '
        Me.tv.HideSelection = False
        Me.tv.ImageIndex = -1
        Me.tv.Location = New System.Drawing.Point(8, 24)
        Me.tv.Name = "tv"
        Me.tv.SelectedImageIndex = -1
        Me.tv.Size = New System.Drawing.Size(152, 232)
        Me.tv.Sorted = True
        Me.tv.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 2

        '
        'Button5
        '
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button5.Location = New System.Drawing.Point(360, 264)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 24)
        Me.Button5.TabIndex = 7

        '
        'Button6
        '
        Me.Button6.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button6.Location = New System.Drawing.Point(280, 264)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(72, 24)
        Me.Button6.TabIndex = 6

        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnS)
        Me.GroupBox1.Controls.Add(Me.txtS)
        Me.GroupBox1.Controls.Add(Me.lblS)
        Me.GroupBox1.Controls.Add(Me.txtP3)
        Me.GroupBox1.Controls.Add(Me.lblP3)
        Me.GroupBox1.Controls.Add(Me.txtP2)
        Me.GroupBox1.Controls.Add(Me.lblP2)
        Me.GroupBox1.Controls.Add(Me.txtP1)
        Me.GroupBox1.Controls.Add(Me.lblP1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox1.Location = New System.Drawing.Point(168, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 238)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'btnS
        '
        Me.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnS.Location = New System.Drawing.Point(232, 16)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(24, 20)
        Me.btnS.TabIndex = 20
        Me.btnS.Text = "..."
        '
        'txtS
        '
        Me.txtS.Location = New System.Drawing.Point(128, 16)
        Me.txtS.Name = "txtS"
        Me.txtS.ReadOnly = True
        Me.txtS.Size = New System.Drawing.Size(104, 20)
        Me.txtS.TabIndex = 19

        '
        'lblS
        '
        Me.lblS.Location = New System.Drawing.Point(8, 16)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(104, 16)
        Me.lblS.TabIndex = 18

        '
        'txtP3
        '
        Me.txtP3.Location = New System.Drawing.Point(128, 112)
        Me.txtP3.Name = "txtP3"
        Me.txtP3.Size = New System.Drawing.Size(104, 20)
        Me.txtP3.TabIndex = 16
        Me.txtP3.Text = "TextBox1"
        Me.txtP3.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(8, 112)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(38, 16)
        Me.lblP3.TabIndex = 15
        Me.lblP3.Text = "Label4"
        Me.lblP3.Visible = False
        '
        'txtP2
        '
        Me.txtP2.Location = New System.Drawing.Point(128, 80)
        Me.txtP2.Name = "txtP2"
        Me.txtP2.Size = New System.Drawing.Size(104, 20)
        Me.txtP2.TabIndex = 13
        Me.txtP2.Text = "TextBox1"
        Me.txtP2.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(8, 80)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(38, 16)
        Me.lblP2.TabIndex = 12
        Me.lblP2.Text = "Label3"
        Me.lblP2.Visible = False
        '
        'txtP1
        '
        Me.txtP1.Location = New System.Drawing.Point(128, 48)
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(104, 20)
        Me.txtP1.TabIndex = 10
        Me.txtP1.Text = "TextBox1"
        Me.txtP1.Visible = False
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(8, 48)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(38, 16)
        Me.lblP1.TabIndex = 9
        Me.lblP1.Text = "Label3"
        Me.lblP1.Visible = False
        '
        'psfrmTileBehavior
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 296)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmTileBehavior"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Tile As Integer
    Dim tmpFile As String
    Dim tmpVolume As Integer = 100
    Dim tmpPan As Integer = 0
    Dim tmpFrequency As Integer = 22

    Overloads Function ShowDialog(ByVal TileIndex As Integer) As DialogResult
        Tile = TileIndex

        Dim n As TreeNode
        For Each n In tv.Nodes
            n.Expand()
        Next
        Select Case Game.tileset.tiles(Tile).behavior
            Case psTile.TileBehavior.Background
                tv.SelectedNode = tv.Nodes(0)
            Case psTile.TileBehavior.Character
                tv.SelectedNode = tv.Nodes(1)
            Case psTile.TileBehavior.Collectable
                tv.SelectedNode = tv.Nodes(2)
            Case psTile.TileBehavior.Ledge
                tv.SelectedNode = tv.Nodes(3)
            Case psTile.TileBehavior.NoGravity
                tv.SelectedNode = tv.Nodes(4)
            Case psTile.TileBehavior.Solid
                tv.SelectedNode = tv.Nodes(5)
        End Select
        tv.Refresh()

        Return ShowDialog()
    End Function

    Private n1 As Single, m1 As Single, p1 As Byte, d1 As Single
    Private n2 As Single, m2 As Single, p2 As Byte, d2 As Single
    Private n3 As Single, m3 As Single, p3 As Byte, d3 As Single

    Private Sub tv_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        If e.Node Is Nothing Then
            EnableSound(False)
            Exit Sub
        End If
        If e.Node.Parent Is Nothing Then
            tv.SelectedNode = e.Node.FirstNode
            Exit Sub
        End If
        If (Not e.Node.Text = GetString("tileBehaviorEd_CurrentValue")) And (e.Node.Parent.Text = GetString("tileBehavior_Collectable")) Then
            EnableSound(True)
            If e.Node.Parent.Text = GetString("tileBehavior_Collectable") Then
                lblS.Text = GetString("tileBehaviorEd_SoundOnCollectLabel")
            Else
                lblS.Text = GetString("tileBehaviorEd_SoundOnCollisionLabel")
            End If
        Else
            EnableSound(False)
        End If
        p1 = 0 : p2 = 0 : p3 = 0
        lblS.Text = GetString("tileBehaviorEd_SoundOnCollisionLabel")
        Select Case e.Node.Text
            Case GetString("gameObjects_Coin")
                lblP1.Text = GetString("tileBehaviorEd_IncreaseScoreByAmountLabel")
                txtP1.Text = "100" : n1 = -1000000 : m1 = 1000000
                lblP2.Text = GetString("tileBehaviorEd_IncreaseCoinsByAmountLabel")
                txtP2.Text = "1" : n2 = -10000 : m2 = 10000
                lblP3.Text = GetString("tileBehaviorEd_CoinsToGetExtraLifeLabel")
                txtP3.Text = "300" : n3 = 0 : m3 = 10000
                ShowFields(3)
            Case GetString("gameObjects_Gem")
                lblP1.Text = GetString("tileBehaviorEd_IncreaseScoreByAmountLabel")
                txtP1.Text = "200" : n1 = -10000 : m1 = 10000
                ShowFields(1)
            Case GetString("gameObjects_Heart")
                lblP1.Text = GetString("tileBehaviorEd_IncreaseScoreByAmountLabel")
                txtP1.Text = "250" : n1 = -1000000 : m1 = 1000000
                lblP2.Text = GetString("tileBehaviorEd_IncreaseHealthByAmountLabel")
                txtP2.Text = "1" : n2 = -10000 : m2 = 10000
                lblP3.Text = GetString("tileBehaviorEd_MaxHealthLabel")
                txtP3.Text = "5" : n3 = 1 : m3 = 10000
                ShowFields(3)
            Case GetString("gameObjects_ExtraLife")
                lblP1.Text = GetString("tileBehaviorEd_IncreaseScoreByAmountLabel")
                txtP1.Text = "1000" : n1 = -1000000 : m1 = 1000000
                lblP2.Text = GetString("tileBehaviorEd_IncreaseLivesByLabel")
                txtP2.Text = "1" : n2 = -10000 : m2 = 10000
                ShowFields(2)
            Case GetString("gameObjects_Exit")
                EnableSound(True)
                ShowFields(0)
            Case GetString("gameObjects_Ice")
                lblP1.Text = GetString("tileBehaviorEd_SlipSpeedLabel")
                txtP1.Text = "2" : n1 = 0.1 : m1 = 10 : p1 = 2
                ShowFields(1)
            Case GetString("gameObjects_SpikeUp"), GetString("gameObjects_SpikeDown"), GetString("gameObjects_SpikeLeft"), GetString("gameObjects_SpikeRight"), GetString("gameObjects_Fire"), GetString("gameObjects_Bullet")
                lblP1.Text = GetString("tileBehaviorEd_DecreaseHealthByLabel")
                txtP1.Text = "1" : n1 = -10000 : m1 = 10000
                lblP2.Text = GetString("tileBehaviorEd_DecreaseScoreLabel")
                txtP2.Text = "0" : n2 = -1000000 : m2 = 1000000
                ShowFields(2)
            Case GetString("gameObjects_Spring")
                EnableSound(True)
                lblP1.Text = GetString("tileBehaviorEd_JumpHeightLabel")
                txtP1.Text = "8" : n1 = 1 : m1 = 50 : p1 = 1
                lblP2.Text = GetString("tileBehaviorEd_JumpTime")
                txtP2.Text = "0.5" : n2 = 0.05 : m2 = 10 : p2 = 2
                ShowFields(2)
            Case GetString("gameObjects_Unstable")
                lblP1.Text = GetString("tileBehaviorEd_FallAfter")
                txtP1.Text = "1" : n1 = 0.1 : m1 = 10 : p1 = 2
                lblP2.Text = GetString("tileBehaviorEd_DropScaleSpeed")
                txtP2.Text = "1" : n2 = 0.1 : m2 = 10 : p2 = 2
                ShowFields(2)
            Case GetString("gameObjects_Disintegrate")
                lblP1.Text = GetString("tileBehaviorEd_DisintegrateAfter")
                txtP1.Text = "0.5" : n1 = 0 : m1 = 10 : p1 = 2
                ShowFields(1)
            Case GetString("gameObjects_Enemy")
                lblS.Text = GetString("tileBehaviorEd_SoundOnKill")
                EnableSound(True)
                lblP1.Text = GetString("tileBehaviorEd_KillBonusLabel")
                txtP1.Text = "200" : n1 = -1000000 : m1 = 1000000
                lblP2.Text = GetString("tileBehaviorEd_JumpHeightOnKillLabel")
                txtP2.Text = "2" : n2 = 0 : m2 = 10
                lblP3.Text = GetString("tileBehaviorEd_DecreaseHealthByLabel")
                txtP3.Text = "1" : n3 = -10000 : m3 = 10000
                ShowFields(3)
            Case GetString("gameObjects_Ladder")
                ShowFields(0)
            Case GetString("gameObjects_Water")
                ShowFields(0)
            Case Else
                ShowFields(0)
        End Select
    End Sub

    Sub EnableSound(ByVal Value As Boolean)
        lblS.Visible = Value
        txtS.Visible = Value
        btnS.Visible = Value
    End Sub

    Sub EnableField1(ByVal Value As Boolean)
        lblP1.Visible = Value
        txtP1.Visible = Value
        Try
            d1 = txtP1.Text
        Catch
        End Try
    End Sub

    Sub EnableField2(ByVal Value As Boolean)
        lblP2.Visible = Value
        txtP2.Visible = Value
        Try
            d2 = txtP2.Text
        Catch
        End Try
    End Sub

    Sub EnableField3(ByVal Value As Boolean)
        lblP3.Visible = Value
        txtP3.Visible = Value
        Try
            d3 = txtP3.Text
        Catch
        End Try
    End Sub

    Sub ShowFields(ByVal NumFields As Integer)
        Select Case NumFields
            Case 0
                EnableField1(False)
                EnableField2(False)
                EnableField3(False)
            Case 1
                EnableField1(True)
                EnableField2(False)
                EnableField3(False)
            Case 2
                EnableField1(True)
                EnableField2(True)
                EnableField3(False)
            Case 3
                EnableField1(True)
                EnableField2(True)
                EnableField3(True)
        End Select
    End Sub

    Private Sub txtP1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP1.Validating
        ConvertToNumber(txtP1, n1, m1, d1, p1)
    End Sub

    Private Sub txtP2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP2.Validating
        ConvertToNumber(txtP2, n2, m2, d2, p2)
    End Sub

    Private Sub txtP3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP3.Validating
        ConvertToNumber(txtP3, n3, m3, d3, p3)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not tv.SelectedNode.Text = GetString("tileBehaviorEd_CurrentValue") Then

            'Make sure we can delete the current actions
            For i As Integer = 1 To UBound(Game.actions.Actions)
                With Game.actions.Actions(i).Trigger
                    If .Chars(0) = "t" AndAlso .Substring(4) = CStr(Tile) Then
                        If MessageBox.Show(GetString("deleteActionConfirmationMessage"), GetString("tileBehaviorEd_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            DialogResult = DialogResult.None
                            Exit Sub
                        Else
                            Exit For
                        End If
                    End If
                End With
            Next

            'and do it.
            For i As Integer = 1 To Game.actions.Actions.GetUpperBound(0)
                If i > Game.actions.Actions.GetUpperBound(0) Then Exit For
                With Game.actions.Actions(i).Trigger
                    If .Chars(0) = "t" AndAlso .Substring(4) = CStr(Tile) Then
                        For j As Integer = i To UBound(Game.actions.Actions) - 1
                            Game.actions.Actions(j) = Game.actions.Actions(j + 1).Clone
                        Next
                        ReDim Preserve Game.actions.Actions(Game.actions.Actions.GetUpperBound(0) - 1)
                        i -= 1
                    End If
                End With
            Next

        End If

        'Set the behavior
        Select Case tv.SelectedNode.Parent.Text
            Case GetString("tileBehavior_Background")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.Background
            Case GetString("tileBehavior_Character")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.Character
            Case GetString("tileBehavior_Collectable")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.Collectable
            Case GetString("tileBehavior_Ledge")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.Ledge
            Case GetString("tileBehavior_NoGravity")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.NoGravity
            Case GetString("tileBehavior_Solid")
                Game.tileset.tiles(Tile).behavior = psTile.TileBehavior.Solid
        End Select

        'Current = no change
        If tv.SelectedNode.Text = GetString("tileBehaviorEd_CurrentValue") Then Exit Sub

        'Create the actions and, if needed, counters
        With Game.actions
            Select Case tv.SelectedNode.Text
                Case GetString("tileBehaviorEd_NormalValue")
                    Select Case tv.SelectedNode.Parent.Text
                        Case GetString("tileBehavior_Collectable")
                            If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                        Case GetString("tileBehavior_Ledge")
                            If tmpFile <> "" Then .AddAction("ttop" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                        Case GetString("tileBehavior_Solid")
                            If tmpFile <> "" Then .AddAction("thit" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    End Select
                Case GetString("gameObjects_Coin")
                    If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")

                    'Make sure we have a coin counter
                    Dim CounterExists As Boolean, CounterExists2 As Boolean
                    For i As Integer = 1 To UBound(.Counters)
                        If .Counters(i).Name = "Coins" Then CounterExists = True
                        If .Counters(i).Name = "Coins2" Then CounterExists2 = True
                    Next
                    If Not CounterExists Then
                        ReDim Preserve .Counters(.Counters.GetUpperBound(0) + 1)
                        .Counters(.Counters.GetUpperBound(0)).Name = "Coins"
                    End If
                    If txtP3.Text > 0 Then
                        If Not CounterExists2 Then
                            ReDim Preserve .Counters(.Counters.GetUpperBound(0) + 1)
                            .Counters(.Counters.GetUpperBound(0)).Name = "Coins2"
                        End If
                    End If

                    For i As Integer = 1 To UBound(.Actions)
                        If i > UBound(.Actions) Then Exit For
                        If .Actions(i).Trigger = "cval" & GetCounter("Coins") Then
                            For j As Integer = i To UBound(.Actions) - 1
                                .Actions(j) = .Actions(j + 1)
                            Next
                            ReDim Preserve .Actions(UBound(.Actions) - 1)
                            i -= 1
                        End If
                    Next

                    'Add the actions
                    .AddAction("tcol" & Tile, "Modify Score", txtP1.Text)
                    .AddAction("tcol" & Tile, "Modify Counter", "Coins", txtP2.Text)
                    If txtP3.Text > 0 Then
                        .AddAction("cval" & GetCounter("Coins"), "Execute Script", "Game.ModifyCounter(""Coins2"", curCounter.ChangedBy)")
                        .AddAction("cval" & GetCounter("Coins"), "If Counter...", "Coins2", ">=", txtP3.Text)
                        .AddAction("cval" & GetCounter("Coins"), "Modify Lives", "1")
                        .AddAction("cval" & GetCounter("Coins"), "Set Counter", "Coins2", "0")
                        .AddAction("cval" & GetCounter("Coins"), "End If")
                    End If

                Case GetString("gameObjects_Gem")
                    If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("tcol" & Tile, "Modify Score", txtP1.Text)

                Case GetString("gameObjects_Heart")
                    If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("tcol" & Tile, "Modify Score", txtP1.Text)
                    .AddAction("tcol" & Tile, "Modify Health", txtP2.Text)
                    .AddAction("tcol" & Tile, "If Counter...", "Health", ">", txtP3.Text)
                    .AddAction("tcol" & Tile, "Set Health", txtP3.Text)
                    .AddAction("tcol" & Tile, "End If")

                Case GetString("gameObjects_ExtraLife")
                    If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("tcol" & Tile, "Modify Score", txtP1.Text)
                    .AddAction("tcol" & Tile, "Modify Lives", txtP2.Text)

                Case GetString("gameObjects_Bullet")
                    If tmpFile <> "" Then .AddAction("tcol" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("tcol" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("tcol" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_Exit")
                    If tmpFile <> "" Then .AddAction("ttop" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("thit" & Tile, "Modify Level", "1")

                Case GetString("gameObjects_Ice")
                    .AddAction("ttop" & Tile, "Move Character", "Current Direction", txtP1.Text, "No")

                Case GetString("gameObjects_Fire")
                    .AddAction("thit" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("thit" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_SpikeUp")
                    .AddAction("ttop" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("ttop" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_SpikeDown")
                    .AddAction("tbot" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("tbot" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_SpikeLeft")
                    .AddAction("tlef" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("tlef" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_SpikeRight")
                    .AddAction("trig" & Tile, "Modify Score", CStr(-txtP2.Text))
                    .AddAction("trig" & Tile, "Modify Health", CStr(-txtP1.Text))

                Case GetString("gameObjects_Spring")
                    If tmpFile <> "" Then .AddAction("ttop" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("ttop" & Tile, "Jump", txtP1.Text, txtP1.Text, txtP2.Text)

                Case GetString("gameObjects_Unstable")
                    .AddAction("ttop" & Tile, "Drop Current Tile", txtP1.Text, txtP2.Text, "Yes")

                Case GetString("gameObjects_Disintegrate")
                    .AddAction("ttop" & Tile, "Disintegrate Current Tile", txtP1.Text)

                Case GetString("gameObjects_Ladder")
                    .AddAction("thit" & Tile, "Set Gravity", "No", "1")
                    .AddAction("thit" & Tile, "Set Climbing State", "Yes")

                Case GetString("gameObjects_Water")
                    .AddAction("thit" & Tile, "Set Gravity", "No", "1")

                Case GetString("gameObjects_Enemy")
                    If tmpFile <> "" Then .AddAction("ttop" & Tile, "Play Sound", tmpFile, CStr(tmpVolume), CStr(tmpPan), CStr(tmpFrequency), "No")
                    .AddAction("ttop" & Tile, "Modify Score", txtP1.Text)
                    .AddAction("ttop" & Tile, "Kill Current Tile")
                    If txtP2.Text <> "0" Then .AddAction("ttop" & Tile, "Jump", txtP2.Text, txtP2.Text, CStr(0.5 * txtP2.Text / 4))
                    .AddAction("tlef" & Tile, "Modify Health", CStr(-txtP3.Text))
                    .AddAction("trig" & Tile, "Execute Script", "Game.ExecuteTrigger.TileHitLeft()")
                    .AddAction("tbot" & Tile, "Execute Script", "Game.ExecuteTrigger.TileHitLeft()")

                Case Else
                    ShowFields(0)
            End Select
        End With
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        Dim f As New psfrmSoundSelector
        f.ShowDialog(tmpFile, tmpVolume, tmpPan, tmpFrequency)
        f.Dispose()
        txtS.Text = tmpFile
    End Sub
End Class