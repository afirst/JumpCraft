Public Class frmWelcomeToPS
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.dlgOpen.Filter = GetString("gameFileFilter")
        Me.btnOpenS.Text = GetString("welcome_OpenButton")
        Me.GroupBox1.Text = GetString("welcome_DidYouKnow")
        Me.btnNextTip.Text = GetString("welcome_NextTipButton")
        Me.btnClose.Text = GetString("welcome_CloseButton")
        Me.btnOpen.Text = GetString("welcome_OpenButton")
        Me.Text = GetString("welcome_Title")
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents btnNextTip As UIPlus.UIPlusFlatButton
    Friend WithEvents btnClose As UIPlus.UIPlusFlatButton
    Friend WithEvents btnOpen As UIPlus.UIPlusFlatButton
    Friend WithEvents btnOpenS As UIPlus.UIPlusFlatButton
    Friend WithEvents cboOpen1 As UIPlus.UIPlusFlatComboBox
    Friend WithEvents cboOpen2 As UIPlus.UIPlusFlatComboBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcomeToPS))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNextTip = New UIPlus.UIPlusFlatButton()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.btnClose = New UIPlus.UIPlusFlatButton()
        Me.cboOpen1 = New UIPlus.UIPlusFlatComboBox()
        Me.btnOpen = New UIPlus.UIPlusFlatButton()
        Me.btnOpenS = New UIPlus.UIPlusFlatButton()
        Me.cboOpen2 = New UIPlus.UIPlusFlatComboBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(149, 136)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(120, 24)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(149, 88)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(76, 24)
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(149, 112)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(131, 24)
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'PictureBox5
        '
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(152, 248)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(76, 24)
        Me.PictureBox5.TabIndex = 6
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(152, 272)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(52, 24)
        Me.PictureBox6.TabIndex = 7
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(152, 296)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(56, 24)
        Me.PictureBox7.TabIndex = 8
        Me.PictureBox7.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.Location = New System.Drawing.Point(349, 464)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(13, 13)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(152, 192)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(120, 24)
        Me.PictureBox8.TabIndex = 13
        Me.PictureBox8.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(9, 328)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(432, 2)
        Me.Label2.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNextTip)
        Me.GroupBox1.Controls.Add(Me.PictureBox9)
        Me.GroupBox1.Controls.Add(Me.lblTip)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 336)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 96)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'btnNextTip
        '
        Me.btnNextTip.Border = True
        Me.btnNextTip.CustomColorScheme = Nothing
        Me.btnNextTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextTip.Location = New System.Drawing.Point(360, 16)
        Me.btnNextTip.Name = "btnNextTip"
        Me.btnNextTip.Size = New System.Drawing.Size(56, 24)
        Me.btnNextTip.TabIndex = 0
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(373, 48)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox9.TabIndex = 12
        Me.PictureBox9.TabStop = False
        '
        'lblTip
        '
        Me.lblTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTip.Location = New System.Drawing.Point(16, 24)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(336, 64)
        Me.lblTip.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Border = True
        Me.btnClose.CustomColorScheme = Nothing
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageIndex = 1
        Me.btnClose.ImageList = Me.ImageList1
        Me.btnClose.Location = New System.Drawing.Point(168, 448)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 24)
        Me.btnClose.TabIndex = 17
        '
        'cboOpen1
        '
        Me.cboOpen1.Border = True
        Me.cboOpen1.CustomColorScheme = Nothing
        Me.cboOpen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpen1.Location = New System.Drawing.Point(154, 162)
        Me.cboOpen1.Name = "cboOpen1"
        Me.cboOpen1.Size = New System.Drawing.Size(123, 21)
        Me.cboOpen1.TabIndex = 18
        '
        'btnOpen
        '
        Me.btnOpen.Border = True
        Me.btnOpen.CustomColorScheme = Nothing
        Me.btnOpen.Enabled = False
        Me.btnOpen.ImageIndex = 0
        Me.btnOpen.ImageList = Me.ImageList1
        Me.btnOpen.Location = New System.Drawing.Point(281, 160)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(57, 24)
        Me.btnOpen.TabIndex = 19
        '
        'btnOpenS
        '
        Me.btnOpenS.Border = True
        Me.btnOpenS.CustomColorScheme = Nothing
        Me.btnOpenS.Enabled = False
        Me.btnOpenS.ImageIndex = 0
        Me.btnOpenS.ImageList = Me.ImageList1
        Me.btnOpenS.Location = New System.Drawing.Point(281, 216)
        Me.btnOpenS.Name = "btnOpenS"
        Me.btnOpenS.Size = New System.Drawing.Size(57, 24)
        Me.btnOpenS.TabIndex = 21
        '
        'cboOpen2
        '
        Me.cboOpen2.Border = True
        Me.cboOpen2.CustomColorScheme = Nothing
        Me.cboOpen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpen2.Location = New System.Drawing.Point(154, 218)
        Me.cboOpen2.Name = "cboOpen2"
        Me.cboOpen2.Size = New System.Drawing.Size(123, 21)
        Me.cboOpen2.TabIndex = 20
        '
        'PictureBox10
        '
        Me.PictureBox10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(0, 441)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(450, 40)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 22
        Me.PictureBox10.TabStop = False
        '
        'frmWelcomeToPS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(450, 481)
        Me.Controls.Add(Me.btnOpenS)
        Me.Controls.Add(Me.cboOpen2)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.cboOpen1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWelcomeToPS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum WelcomeDialogResult
        Close
        [New]
        Open
        OpenRecent
        OpenSample
    End Enum
    Public Result As WelcomeDialogResult = WelcomeDialogResult.Close
    Public RecentFile As String
    Public Tips() As String = {}
    Dim curTip As Integer

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Result = WelcomeDialogResult.[New]
        Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        dlgOpen.Filter = GetString("gameFileFilter")
        If dlgOpen.ShowDialog = DialogResult.Cancel Then Exit Sub
        Result = WelcomeDialogResult.Open
        RecentFile = dlgOpen.FileName
        Close()
    End Sub

    Private Sub frmWelcomeToPS_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        PlatformStudio.Options.gShowWelcomeDialog = Not CheckBox1.Checked
    End Sub

    Private Sub frmWelcomeToPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tipsText As String = My.Computer.FileSystem.ReadAllText("tips." & GetString("locale") & ".txt")
            Tips = tipsText.Split(vbCrLf)
        Catch
            Tips = New String() {GetString("welcome_LoadTipsError")}
        End Try
        CheckBox1.Checked = Not PlatformStudio.Options.gShowWelcomeDialog
        For i As Integer = 1 To fGame.MRU.Count
            If IO.File.Exists(fGame.MRU(i)) Then
                cboOpen1.Items.Add(IO.Path.GetFileNameWithoutExtension(fGame.MRU(i))) '& New String(" ", 1024) & i)
            End If
        Next
        For Each file As String In IO.Directory.GetFiles(Application.StartupPath & "\Samples")
            cboOpen2.Items.Add(IO.Path.GetFileNameWithoutExtension(file))
        Next
        NextTip()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        frmAbout.Website()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        frmAbout.Forums()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        frmAbout.Support()
    End Sub

    Sub NextTip()
        Randomize()
        Dim tipNumber As Integer
        Do
            tipNumber = Int(Rnd(1) * Tips.Length)
        Loop Until tipNumber <> curTip
        lblTip.Text = Tips(tipNumber)
        curTip = tipNumber
    End Sub

    Private Sub btnNextTip_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNextTip.Click
        NextTip()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Static bln As Boolean
            If bln = False Then
                bln = True
                MessageBox.Show(GetString("welcome_HideAtStartupMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Result = WelcomeDialogResult.OpenRecent
        RecentFile = cboOpen1.Text
        Close()
    End Sub

    Private Sub btnOpenS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenS.Click
        Result = WelcomeDialogResult.OpenSample
        RecentFile = cboOpen2.Text
        Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Result = WelcomeDialogResult.Close
        Close()
    End Sub

    Private Sub cboOpen1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpen1.SelectedIndexChanged
        btnOpen.Enabled = True
    End Sub

    Private Sub cboOpen2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpen2.SelectedIndexChanged
        btnOpenS.Enabled = True
    End Sub
End Class