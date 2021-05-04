Imports PlatformStudio

Public Class psfrmEditAction
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.TabPage8.Text = GetString("actionCategory_Game")
        Me.TabPage1.Text = GetString("actionCategory_Counters")
        Me.TabPage5.Text = GetString("actionCategory_Camera")
        Me.TabPage2.Text = GetString("actionCategory_Character")
        Me.TabPage3.Text = GetString("actionCategory_Map")
        Me.TabPage4.Text = GetString("actionCategory_Drawing")
        Me.TabPage6.Text = GetString("actionCategory_Scripting")
        Me.TabPage7.Text = GetString("actionCategory_Misc")
        Me.Label2.Text = GetString("editAction_ParametersLabel")
        Me.Label1.Text = GetString("editAction_ActionTypeLabel")
        Me.Text = GetString("editAction_Title")
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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstAct As System.Windows.Forms.ListView
    Friend WithEvents lstParam As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.lstAct = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.lstParam = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(352, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 5

        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(272, 328)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 4

        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(416, 312)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage8
        '
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(408, 286)
        Me.TabPage8.TabIndex = 7

        '
        'TabPage1
        '
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(408, 286)
        Me.TabPage1.TabIndex = 0

        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(408, 286)
        Me.TabPage5.TabIndex = 8

        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(408, 286)
        Me.TabPage2.TabIndex = 1

        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(408, 286)
        Me.TabPage3.TabIndex = 2

        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(408, 286)
        Me.TabPage4.TabIndex = 3

        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(408, 286)
        Me.TabPage6.TabIndex = 4

        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(408, 286)
        Me.TabPage7.TabIndex = 5

        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 160
        '
        'lstAct
        '
        Me.lstAct.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstAct.FullRowSelect = True
        Me.lstAct.HideSelection = False
        Me.lstAct.Location = New System.Drawing.Point(20, 52)
        Me.lstAct.MultiSelect = False
        Me.lstAct.Name = "lstAct"
        Me.lstAct.Size = New System.Drawing.Size(196, 256)
        Me.lstAct.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstAct.TabIndex = 18
        Me.lstAct.View = System.Windows.Forms.View.SmallIcon
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 152
        '
        'lstParam
        '
        Me.lstParam.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lstParam.FullRowSelect = True
        Me.lstParam.HideSelection = False
        Me.lstParam.Location = New System.Drawing.Point(224, 52)
        Me.lstParam.MultiSelect = False
        Me.lstParam.Name = "lstParam"
        Me.lstParam.Size = New System.Drawing.Size(192, 256)
        Me.lstParam.StateImageList = Me.ImageList1
        Me.lstParam.TabIndex = 19
        Me.lstParam.View = System.Windows.Forms.View.SmallIcon
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 160
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(224, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 17

        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 16

        '
        'psfrmEditAction
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(434, 360)
        Me.Controls.Add(Me.lstAct)
        Me.Controls.Add(Me.lstParam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmEditAction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim SelAct As Integer
    Dim CurAct As psActions.psAction

    Overloads Function ShowDialog(ByRef Action As psActions.psAction) As DialogResult
        CurAct = Action

        Dim dr As DialogResult
        dr = ShowDialog()

        If dr = DialogResult.OK Then Action = CurAct
        Return dr
    End Function

    Private Sub lstAct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAct.SelectedIndexChanged
        If lstAct.SelectedIndices.Count = 0 Then
            Exit Sub
        End If

        SelAct = lstAct.SelectedItems(0).Tag
        Dim NoReset As Boolean
        If CurAct.Action.Type = SelAct And CurAct.Action.param.GetUpperBound(0) >= Game.actions.Dat.ab(SelAct).params.GetUpperBound(0) Then
            NoReset = True
            If CurAct.Action.param.GetUpperBound(0) > Game.actions.Dat.ab(SelAct).params.GetUpperBound(0) Then
                ReDim Preserve CurAct.Action.param(Game.actions.Dat.ab(SelAct).params.GetUpperBound(0))
            End If
        Else
            CurAct.Action.Type = SelAct
        End If

        'Load parameters
        lstParam.Visible = False
        lstParam.Items.Clear()
        Dim i As Integer
        With Game.actions.Dat.ab(SelAct)
            If NoReset = False Then ReDim CurAct.Action.param(UBound(.params))
            For i = 1 To UBound(.params)
                If NoReset = False Then CurAct.Action.param(i) = .params(i).DefaultValue
                lstParam.Items.Add(.params(i).Name & ": " & CurAct.Action.param(i) & " " & .params(i).Units).ImageIndex = .params(i).Icon
            Next
        End With
        lstParam.Visible = True
    End Sub

    Private Sub psfrmEditAction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstAct.SmallImageList = fActionEdit.iml2
        lstParam.SmallImageList = fActionEdit.iml3

        'Load actions
        Dim i As Integer
        For i = 0 To TabControl1.TabPages.Count - 1
            If TabControl1.TabPages(i).Text = CurAct.Action.Behavior.Description Then
                TabControl1.SelectedIndex = i
                Exit For
            End If
        Next
        LoadActions()

        For i = 0 To lstAct.Items.Count - 1
            If lstAct.Items(i).Tag = CurAct.Action.Type Then
                With lstAct.Items(i)
                    .Selected = True
                    .EnsureVisible()
                End With
                Exit For
            End If
        Next
    End Sub

    Sub LoadActions()
        Dim i As Integer
        lstAct.Visible = False
        lstAct.Items.Clear()
        With Game.actions.Dat
            For i = 1 To UBound(.ab)
                If .ab(i).Description = TabControl1.SelectedTab.Text Then
                    With lstAct.Items.Add(.ab(i).Name)
                        .ImageIndex = Game.actions.Dat.ab(i).Icon
                        .Tag = i
                        If CurAct.Action.Type = .Tag Then .Selected = True
                    End With
                End If
            Next
        End With
        lstAct.Visible = True
    End Sub

    Private Sub lstParam_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstParam.DoubleClick
        If lstParam.SelectedIndices.Count = 0 Then Exit Sub

        Dim CurParam As Integer
        CurParam = lstParam.SelectedIndices(0) + 1

        If CurAct.Action.Behavior.params(CurParam).ValueType = psActions.psValueType.Script Then
            Dim f As New psfrmScriptEditor
            f.ShowDialog(CurAct.Action.param(CurParam), CurAct.Trigger)
            Game.actions.Globals = f.txtMScript.Text
            f.Dispose()
        ElseIf CurAct.Action.Behavior.params(CurParam).ValueType = psActions.psValueType.Color Then
            Dim f As New psfrmColorValue
            f.ShowDialog(CurAct.Action.param(CurParam), CurAct.Action.Behavior.params(CurParam))
            f.Dispose()
        Else
            Dim f As New psfrmValue
            f.ShowDialog(CurAct.Action.param(CurParam), CurAct.Action.Behavior.params(CurParam))
            f.Dispose()
        End If

        lstParam.Items(lstParam.SelectedIndices(0)).Text = CurAct.Action.Behavior.params(CurParam).Name & ": " & CurAct.Action.param(CurParam) & " " & CurAct.Action.Behavior.params(CurParam).Units
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        LoadActions()
    End Sub
End Class
