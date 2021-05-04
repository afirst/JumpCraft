Imports PlatformStudio

Public Class psfrmParamEdit
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button2.Text = GetString("okButton")
        Me.Button3.Text = GetString("cancelButton")
        Me.btnParamRemove.Text = GetString("gameProperties_RemoveFileButton")
        Me.btnParamAdd.Text = GetString("gameProperties_AddFileButton")
        Me.GroupBox2.Text = GetString("propertiesPanelTitle")
        Me.Label9.Text = GetString("parameterEd_UnitsLabel")
        Me.Label8.Text = GetString("parameterEd_DefaultValueLabel")
        Me.Label7.Text = GetString("parameterEd_DecimalPlacesLabel")
        Me.Label3.Text = GetString("parameterEd_MaxValueLabel")
        Me.Label2.Text = GetString("parameterEd_MinValueLabel")
        Me.Label1.Text = GetString("parameterEd_ValueTypeLabel")
        Me.Label4.Text = GetString("parameterEd_IconLabel")
        Me.Label5.Text = GetString("parameterEd_ChoicesLabel")
        Me.Label6.Text = GetString("parameterEd_NameLabel")
        Me.Text = GetString("parameterEd_Title")
        Me.cboParamValue.Items.AddRange(New Object() {GetString("valueType_Number"), GetString("valueType_Text"), GetString("valueType_Direction"), GetString("valueType_DirectionWithCurrentDir"), GetString("valueType_Script"), GetString("valueType_TileGroup"), GetString("valueType_YesNo"), GetString("valueType_Sound"), GetString("valueType_Music"), GetString("valueType_Graphic"), GetString("valueType_Counter"), GetString("valueType_Timer"), GetString("valueType_Color"), GetString("valueType_Choices"), GetString("valueType_Image"), GetString("valueType_Movie"), GetString("valueType_File")})
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnParamRemove As System.Windows.Forms.Button
    Friend WithEvents btnParamAdd As System.Windows.Forms.Button
    Friend WithEvents cboParamIcon As System.Windows.Forms.ComboBox
    Friend WithEvents txtParamName As System.Windows.Forms.TextBox
    Friend WithEvents lstParamList As System.Windows.Forms.ListBox
    Friend WithEvents txtParamDesc As System.Windows.Forms.TextBox
    Friend WithEvents cboParamValue As System.Windows.Forms.ComboBox
    Friend WithEvents txtParamMin As System.Windows.Forms.TextBox
    Friend WithEvents txtParamMax As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboParamDec As System.Windows.Forms.ComboBox
    Friend WithEvents txtParamDefValue As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtParamUnits As System.Windows.Forms.TextBox
    Friend WithEvents btnParamMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnParamMoveDown As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(psfrmParamEdit))
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.btnParamRemove = New System.Windows.Forms.Button
        Me.btnParamAdd = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtParamUnits = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtParamDefValue = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboParamDec = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtParamMax = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtParamMin = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboParamValue = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cboParamIcon = New System.Windows.Forms.ComboBox
        Me.txtParamDesc = New System.Windows.Forms.TextBox
        Me.txtParamName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lstParamList = New System.Windows.Forms.ListBox
        Me.btnParamMoveUp = New System.Windows.Forms.Button
        Me.btnParamMoveDown = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(376, 288)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 7

        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button3.Location = New System.Drawing.Point(296, 288)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 24)
        Me.Button3.TabIndex = 6

        '
        'btnParamRemove
        '
        Me.btnParamRemove.Enabled = False
        Me.btnParamRemove.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnParamRemove.Location = New System.Drawing.Point(88, 256)
        Me.btnParamRemove.Name = "btnParamRemove"
        Me.btnParamRemove.Size = New System.Drawing.Size(72, 24)
        Me.btnParamRemove.TabIndex = 2

        '
        'btnParamAdd
        '
        Me.btnParamAdd.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.btnParamAdd.Location = New System.Drawing.Point(8, 256)
        Me.btnParamAdd.Name = "btnParamAdd"
        Me.btnParamAdd.Size = New System.Drawing.Size(72, 24)
        Me.btnParamAdd.TabIndex = 1

        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtParamUnits)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtParamDefValue)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboParamDec)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtParamMax)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtParamMin)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboParamValue)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.cboParamIcon)
        Me.GroupBox2.Controls.Add(Me.txtParamDesc)
        Me.GroupBox2.Controls.Add(Me.txtParamName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.GroupBox2.Location = New System.Drawing.Point(208, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 272)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False

        '
        'txtParamUnits
        '
        Me.txtParamUnits.Location = New System.Drawing.Point(88, 216)
        Me.txtParamUnits.Name = "txtParamUnits"
        Me.txtParamUnits.Size = New System.Drawing.Size(112, 20)
        Me.txtParamUnits.TabIndex = 15
        Me.txtParamUnits.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 14

        '
        'txtParamDefValue
        '
        Me.txtParamDefValue.Location = New System.Drawing.Point(88, 192)
        Me.txtParamDefValue.Name = "txtParamDefValue"
        Me.txtParamDefValue.Size = New System.Drawing.Size(112, 20)
        Me.txtParamDefValue.TabIndex = 13
        Me.txtParamDefValue.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 12

        '
        'cboParamDec
        '
        Me.cboParamDec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParamDec.DropDownWidth = 96
        Me.cboParamDec.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cboParamDec.Location = New System.Drawing.Point(88, 168)
        Me.cboParamDec.Name = "cboParamDec"
        Me.cboParamDec.Size = New System.Drawing.Size(112, 21)
        Me.cboParamDec.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 10

        '
        'txtParamMax
        '
        Me.txtParamMax.Location = New System.Drawing.Point(88, 144)
        Me.txtParamMax.Name = "txtParamMax"
        Me.txtParamMax.Size = New System.Drawing.Size(112, 20)
        Me.txtParamMax.TabIndex = 9
        Me.txtParamMax.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 8

        '
        'txtParamMin
        '
        Me.txtParamMin.Location = New System.Drawing.Point(88, 120)
        Me.txtParamMin.Name = "txtParamMin"
        Me.txtParamMin.Size = New System.Drawing.Size(112, 20)
        Me.txtParamMin.TabIndex = 7
        Me.txtParamMin.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 6

        '
        'cboParamValue
        '
        Me.cboParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParamValue.DropDownWidth = 96
        Me.cboParamValue.Location = New System.Drawing.Point(88, 96)
        Me.cboParamValue.Name = "cboParamValue"
        Me.cboParamValue.Size = New System.Drawing.Size(112, 21)
        Me.cboParamValue.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 4

        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(208, 240)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'cboParamIcon
        '
        Me.cboParamIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParamIcon.DropDownWidth = 96
        Me.cboParamIcon.Location = New System.Drawing.Point(88, 240)
        Me.cboParamIcon.Name = "cboParamIcon"
        Me.cboParamIcon.Size = New System.Drawing.Size(112, 21)
        Me.cboParamIcon.TabIndex = 17
        '
        'txtParamDesc
        '
        Me.txtParamDesc.Location = New System.Drawing.Point(88, 40)
        Me.txtParamDesc.Multiline = True
        Me.txtParamDesc.Name = "txtParamDesc"
        Me.txtParamDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtParamDesc.Size = New System.Drawing.Size(144, 48)
        Me.txtParamDesc.TabIndex = 3
        Me.txtParamDesc.Text = ""
        '
        'txtParamName
        '
        Me.txtParamName.Location = New System.Drawing.Point(88, 16)
        Me.txtParamName.Name = "txtParamName"
        Me.txtParamName.Size = New System.Drawing.Size(144, 20)
        Me.txtParamName.TabIndex = 1
        Me.txtParamName.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 16

        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 2

        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 0

        '
        'lstParamList
        '
        Me.lstParamList.IntegralHeight = False
        Me.lstParamList.Location = New System.Drawing.Point(8, 8)
        Me.lstParamList.Name = "lstParamList"
        Me.lstParamList.Size = New System.Drawing.Size(152, 240)
        Me.lstParamList.TabIndex = 0
        '
        'btnParamMoveUp
        '
        Me.btnParamMoveUp.Enabled = False
        Me.btnParamMoveUp.Image = CType(resources.GetObject("btnParamMoveUp.Image"), System.Drawing.Image)
        Me.btnParamMoveUp.Location = New System.Drawing.Point(168, 8)
        Me.btnParamMoveUp.Name = "btnParamMoveUp"
        Me.btnParamMoveUp.Size = New System.Drawing.Size(32, 32)
        Me.btnParamMoveUp.TabIndex = 3
        '
        'btnParamMoveDown
        '
        Me.btnParamMoveDown.Enabled = False
        Me.btnParamMoveDown.Image = CType(resources.GetObject("btnParamMoveDown.Image"), System.Drawing.Image)
        Me.btnParamMoveDown.Location = New System.Drawing.Point(168, 48)
        Me.btnParamMoveDown.Name = "btnParamMoveDown"
        Me.btnParamMoveDown.Size = New System.Drawing.Size(32, 32)
        Me.btnParamMoveDown.TabIndex = 4
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        '
        'Button1
        '
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(168, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 8
        '
        'psfrmParamEdit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 320)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnParamMoveUp)
        Me.Controls.Add(Me.btnParamMoveDown)
        Me.Controls.Add(Me.btnParamRemove)
        Me.Controls.Add(Me.btnParamAdd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lstParamList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "psfrmParamEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim DoNotValidate As Boolean
    Dim CurParam As Integer
    Private CurAct As psActions.psActionBehavior
    Public SelAct As Integer
    Dim DoNotValidate2 As Boolean
    Dim DoNotValidate3 As Boolean

    Private Sub psfrmParamEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To UBound(psActions.ParamIconKeys)
            cboParamIcon.Items.Add(psActions.ParamIconKeys(i))
        Next
        CurAct = Game.actions.Dat.ab(SelAct)
        With CurAct
            For i = 1 To UBound(.params)
                lstParamList.Items.Add(.params(i).Name)
            Next
        End With
        If lstParamList.Items.Count > 0 Then
            GroupBox2.Enabled = True
            btnParamRemove.Enabled = True
            lstParamList.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboParamIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParamIcon.SelectedIndexChanged
        PictureBox1.Image = fActionEdit.iml3.Images(cboParamIcon.SelectedIndex)
    End Sub

    Private Sub btnParamAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParamAdd.Click
        ValidateParam()
        lstParamList.Items.Add("Parameter " & lstParamList.Items.Count + 1)
        With CurAct
            ReDim Preserve .params(UBound(.params) + 1)
            .params(UBound(.params)).Name = lstParamList.Items(lstParamList.Items.Count - 1)
            .params(UBound(.params)).Icon = 0
        End With
        DoNotValidate3 = True
        lstParamList.SelectedIndex = lstParamList.Items.Count - 1
        DoNotValidate3 = False
        GroupBox2.Enabled = True
        btnParamRemove.Enabled = True
        CurParam = lstParamList.SelectedIndex + 1
    End Sub

    Private Sub btnParamRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParamRemove.Click
        With CurAct
            Dim i As Integer
            For i = lstParamList.SelectedIndex + 1 To UBound(.params) - 1
                .params(i) = .params(i + 1)
            Next
            ReDim Preserve .params(UBound(.params) - 1)
        End With

        DoNotValidate3 = True
        Dim tmp As Integer
        tmp = lstParamList.SelectedIndex
        lstParamList.Items.RemoveAt(lstParamList.SelectedIndex)
        If lstParamList.Items.Count = 0 Then
        ElseIf tmp > lstParamList.Items.Count - 1 Then
            lstParamList.SelectedIndex = lstParamList.Items.Count - 1
        Else
            lstParamList.SelectedIndex = tmp
        End If
        DoNotValidate3 = False

        If lstParamList.Items.Count = 0 Then
            GroupBox2.Enabled = False
            btnParamRemove.Enabled = False
        End If
    End Sub

    Private Sub lstParamList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstParamList.SelectedIndexChanged
        If DoNotValidate2 = True Then Exit Sub
        If DoNotValidate Then Exit Sub
        If DoNotValidate3 = False Then
            ValidateParam()
        End If
        CurParam = lstParamList.SelectedIndex + 1
        With CurAct.params(lstParamList.SelectedIndex + 1)
            txtParamName.Text = .Name
            txtParamDesc.Text = .Description
            cboParamValue.SelectedIndex = .ValueType
            txtParamMin.Text = .MinValue
            txtParamMax.Text = .MaxValue
            cboParamDec.Text = .DecimalPlaces
            txtParamDefValue.Text = .DefaultValue
            txtParamUnits.Text = .Units
            cboParamIcon.Text = psActions.ParamIconKeys(.Icon)
        End With
        btnParamMoveUp.Enabled = True
        btnParamMoveDown.Enabled = True
        If lstParamList.SelectedIndex = 0 Then btnParamMoveUp.Enabled = False
        If lstParamList.SelectedIndex = lstParamList.Items.Count - 1 Then btnParamMoveDown.Enabled = False
    End Sub

    Sub ValidateParam()
        If DoNotValidate Then Exit Sub
        If CurParam = 0 Then Exit Sub
        txtParamMin_Validating(Nothing, Nothing)
        txtParamMax_Validating(Nothing, Nothing)
        DoNotValidate = True
        lstParamList.Items(CurParam - 1) = txtParamName.Text
        With CurAct.params(CurParam)
            .Name = txtParamName.Text
            .Description = txtParamDesc.Text
            .ValueType = cboParamValue.SelectedIndex
            .MinValue = txtParamMin.Text
            .MaxValue = txtParamMax.Text
            .DecimalPlaces = cboParamDec.Text
            .DefaultValue = txtParamDefValue.Text
            .Units = txtParamUnits.Text
            If cboParamIcon.SelectedIndex = -1 Then cboParamIcon.SelectedIndex = 0
            .Icon = cboParamIcon.SelectedIndex
        End With
        DoNotValidate = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ValidateParam()
        Game.actions.Dat.ab(SelAct) = CurAct
    End Sub

    Private Sub txtParamMin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtParamMin.Validating
        ConvertToNumber(txtParamMin, -1000000000, 1000000000, 0, 3)
        If CDbl(txtParamMin.Text) > CDbl(txtParamMax.Text) Then txtParamMin.Text = txtParamMax.Text
    End Sub

    Private Sub txtParamMax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtParamMax.Validating
        ConvertToNumber(txtParamMax, -1000000000, 1000000000, 0, 3)
        If CDbl(txtParamMax.Text) < CDbl(txtParamMin.Text) Then txtParamMax.Text = txtParamMin.Text
    End Sub

    Private Sub btnParamMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParamMoveUp.Click
        MoveParam(-1)
    End Sub

    Private Sub btnParamMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParamMoveDown.Click
        MoveParam(1)
    End Sub

    Sub MoveParam(ByVal Amount As Integer)
        DoNotValidate = True
        DoNotValidate2 = True

        Dim tmpS As String
        tmpS = lstParamList.Items(lstParamList.SelectedIndex)
        lstParamList.Items(lstParamList.SelectedIndex) = lstParamList.Items(lstParamList.SelectedIndex + Amount)
        lstParamList.Items(lstParamList.SelectedIndex + Amount) = tmpS

        Dim tmpAP As psActions.psActionBehavior.psActionParameter
        tmpAP = CurAct.params(CurParam)
        CurAct.params(CurParam) = CurAct.params(CurParam + Amount)
        CurAct.params(CurParam + Amount) = tmpAP

        DoNotValidate = False
        DoNotValidate2 = False

        CurParam = CurParam + Amount
        lstParamList.SelectedIndex = lstParamList.SelectedIndex + Amount
    End Sub

    Private Sub txtParamDefValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtParamDefValue.Validating
        Dim vt As psActions.psValueType
        vt = cboParamValue.SelectedIndex
        If vt = psActions.psValueType.Number Then
            ConvertToNumber(txtParamDefValue, txtParamMin.Text, txtParamMax.Text, 0, cboParamDec.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lstParamList.SelectedIndices.Count = 0 Then Exit Sub
        Dim tmpParam As psActions.psActionBehavior.psActionParameter
        tmpParam = CurAct.params(CurParam).Clone
        btnParamAdd_Click(Nothing, Nothing)
        CurAct.params(UBound(CurAct.params)) = tmpParam
        DoNotValidate3 = True
        lstParamList_SelectedIndexChanged(Nothing, Nothing)
        DoNotValidate3 = False
        DoNotValidate = True
        lstParamList.Items(lstParamList.Items.Count - 1) = tmpParam.Name
        DoNotValidate = False
    End Sub
End Class