Imports PlatformStudio
Imports System.Net
Imports System.IO

Public Class frmUpdates
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        Me.New(False)
    End Sub

    Public Sub New(ByVal Silent As Boolean)
        MyBase.New()

        If Silent Then Visible = False

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Button1.Text = GetString("cancelButton")
        Me.Button2.Text = GetString("updates_DownloadButton")
        Me.Updates.Text = GetString("updates_AvailableUpdatesFrame")
        Me.UnhideAll.Text = GetString("updates_UnhideAllLink")
        Me.HideSelectedUpdate.Text = GetString("updates_HideSelectedUpdateLink")
        Me.Remember.Text = GetString("updates_RememberAccountCheckbox")
        Me.Label4.Text = GetString("updates_PasswordLabel")
        Me.Label3.Text = GetString("updates_UsernameLabel")
        Me.Label5.Text = GetString("updates_PleaseLoginLabel")
        Me.Label2.Text = GetString("updates_DownloadStatusLabel")
        Me.LinkLabel1.Text = GetString("updates_UnhideAllUpdatesLink")
        Me.lblNoUpdates.Text = GetString("updates_NoUpdatesMessage")
        Me.Label1.Text = GetString("updates_PleaseWaitMessage")
        Me.Proceed.Text = GetString("updates_ProceedButton")
        Me.CheckBox1.Text = GetString("updates_CheckAtStartupCheckbox")
        Me.ShowDesc.Text = GetString("updates_ShowDescriptionLink")
        Me.Text = GetString("updates_Title")
        SilentUpdate = Silent
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Updates As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Downloading As System.Windows.Forms.Panel
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents KBCounter As System.Windows.Forms.Label
    Friend WithEvents TimeCounter As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Login As System.Windows.Forms.Panel
    Friend WithEvents Username As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Remember As System.Windows.Forms.CheckBox
    Friend WithEvents Proceed As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents UpdatesPane As System.Windows.Forms.Panel
    Friend WithEvents UnhideAll As System.Windows.Forms.LinkLabel
    Friend WithEvents HideSelectedUpdate As System.Windows.Forms.LinkLabel
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents NoUpdates As System.Windows.Forms.Panel
    Friend WithEvents lblNoUpdates As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ShowDesc As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdates))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Updates = New System.Windows.Forms.GroupBox
        Me.UpdatesPane = New System.Windows.Forms.Panel
        Me.UnhideAll = New System.Windows.Forms.LinkLabel
        Me.HideSelectedUpdate = New System.Windows.Forms.LinkLabel
        Me.lv = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.Login = New System.Windows.Forms.Panel
        Me.Remember = New System.Windows.Forms.CheckBox
        Me.Password = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Username = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Downloading = New System.Windows.Forms.Panel
        Me.TimeCounter = New System.Windows.Forms.Label
        Me.KBCounter = New System.Windows.Forms.Label
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.NoUpdates = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lblNoUpdates = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Proceed = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ShowDesc = New System.Windows.Forms.LinkLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Updates.SuspendLayout()
        Me.UpdatesPane.SuspendLayout()
        Me.Login.SuspendLayout()
        Me.Downloading.SuspendLayout()
        Me.NoUpdates.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button1.Location = New System.Drawing.Point(280, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 24)
        Me.Button1.TabIndex = 2

        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Button2.Location = New System.Drawing.Point(368, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 24)
        Me.Button2.TabIndex = 3

        '
        'Updates
        '
        Me.Updates.Controls.Add(Me.UpdatesPane)
        Me.Updates.Controls.Add(Me.Login)
        Me.Updates.Controls.Add(Me.Downloading)
        Me.Updates.Controls.Add(Me.NoUpdates)
        Me.Updates.Controls.Add(Me.Label1)
        Me.Updates.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Updates.Location = New System.Drawing.Point(8, 6)
        Me.Updates.Name = "Updates"
        Me.Updates.Size = New System.Drawing.Size(440, 186)
        Me.Updates.TabIndex = 4
        Me.Updates.TabStop = False

        '
        'UpdatesPane
        '
        Me.UpdatesPane.Controls.Add(Me.ShowDesc)
        Me.UpdatesPane.Controls.Add(Me.UnhideAll)
        Me.UpdatesPane.Controls.Add(Me.HideSelectedUpdate)
        Me.UpdatesPane.Controls.Add(Me.lv)
        Me.UpdatesPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdatesPane.Location = New System.Drawing.Point(3, 16)
        Me.UpdatesPane.Name = "UpdatesPane"
        Me.UpdatesPane.Size = New System.Drawing.Size(434, 167)
        Me.UpdatesPane.TabIndex = 7
        Me.UpdatesPane.Visible = False
        '
        'UnhideAll
        '
        Me.UnhideAll.AutoSize = True
        Me.UnhideAll.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.UnhideAll.Location = New System.Drawing.Point(232, 144)
        Me.UnhideAll.Name = "UnhideAll"
        Me.UnhideAll.Size = New System.Drawing.Size(55, 16)
        Me.UnhideAll.TabIndex = 12
        Me.UnhideAll.TabStop = True

        '
        'HideSelectedUpdate
        '
        Me.HideSelectedUpdate.AutoSize = True
        Me.HideSelectedUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.HideSelectedUpdate.Location = New System.Drawing.Point(112, 144)
        Me.HideSelectedUpdate.Name = "HideSelectedUpdate"
        Me.HideSelectedUpdate.Size = New System.Drawing.Size(110, 16)
        Me.HideSelectedUpdate.TabIndex = 11
        Me.HideSelectedUpdate.TabStop = True

        '
        'lv
        '
        Me.lv.BackColor = System.Drawing.SystemColors.Window
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv.FullRowSelect = True
        Me.lv.GridLines = True
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(5, 3)
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(424, 136)
        Me.lv.TabIndex = 10
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 185
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Version"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 75
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 80
        '
        'Login
        '
        Me.Login.Controls.Add(Me.Remember)
        Me.Login.Controls.Add(Me.Password)
        Me.Login.Controls.Add(Me.Label4)
        Me.Login.Controls.Add(Me.Username)
        Me.Login.Controls.Add(Me.Label3)
        Me.Login.Controls.Add(Me.Label5)
        Me.Login.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Login.Location = New System.Drawing.Point(3, 16)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(434, 167)
        Me.Login.TabIndex = 7
        Me.Login.Visible = False
        '
        'Remember
        '
        Me.Remember.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Remember.Location = New System.Drawing.Point(73, 112)
        Me.Remember.Name = "Remember"
        Me.Remember.Size = New System.Drawing.Size(288, 16)
        Me.Remember.TabIndex = 5

        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(177, 88)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.Password.Size = New System.Drawing.Size(144, 20)
        Me.Password.TabIndex = 4
        Me.Password.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(113, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 3

        '
        'Username
        '
        Me.Username.Location = New System.Drawing.Point(177, 64)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(144, 20)
        Me.Username.TabIndex = 2
        Me.Username.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(113, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 1

        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(72, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 16)
        Me.Label5.TabIndex = 0

        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Downloading
        '
        Me.Downloading.Controls.Add(Me.TimeCounter)
        Me.Downloading.Controls.Add(Me.KBCounter)
        Me.Downloading.Controls.Add(Me.pb)
        Me.Downloading.Controls.Add(Me.Label2)
        Me.Downloading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Downloading.Location = New System.Drawing.Point(3, 16)
        Me.Downloading.Name = "Downloading"
        Me.Downloading.Size = New System.Drawing.Size(434, 167)
        Me.Downloading.TabIndex = 6
        Me.Downloading.Visible = False
        '
        'TimeCounter
        '
        Me.TimeCounter.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.TimeCounter.Location = New System.Drawing.Point(184, 104)
        Me.TimeCounter.Name = "TimeCounter"
        Me.TimeCounter.Size = New System.Drawing.Size(184, 16)
        Me.TimeCounter.TabIndex = 3
        Me.TimeCounter.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'KBCounter
        '
        Me.KBCounter.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.KBCounter.Location = New System.Drawing.Point(64, 104)
        Me.KBCounter.Name = "KBCounter"
        Me.KBCounter.Size = New System.Drawing.Size(120, 16)
        Me.KBCounter.TabIndex = 2
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(56, 72)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(312, 24)
        Me.pb.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 16)
        Me.Label2.TabIndex = 0

        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'NoUpdates
        '
        Me.NoUpdates.Controls.Add(Me.LinkLabel1)
        Me.NoUpdates.Controls.Add(Me.lblNoUpdates)
        Me.NoUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NoUpdates.Location = New System.Drawing.Point(3, 16)
        Me.NoUpdates.Name = "NoUpdates"
        Me.NoUpdates.Size = New System.Drawing.Size(434, 167)
        Me.NoUpdates.TabIndex = 8
        Me.NoUpdates.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.LinkLabel1.Location = New System.Drawing.Point(168, 96)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(98, 16)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True

        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LinkLabel1.Visible = False
        '
        'lblNoUpdates
        '
        Me.lblNoUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoUpdates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoUpdates.Location = New System.Drawing.Point(0, 0)
        Me.lblNoUpdates.Name = "lblNoUpdates"
        Me.lblNoUpdates.Size = New System.Drawing.Size(434, 167)
        Me.lblNoUpdates.TabIndex = 2

        Me.lblNoUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(434, 167)
        Me.Label1.TabIndex = 2

        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Proceed
        '
        Me.Proceed.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Proceed.Location = New System.Drawing.Point(368, 200)
        Me.Proceed.Name = "Proceed"
        Me.Proceed.Size = New System.Drawing.Size(80, 24)
        Me.Proceed.TabIndex = 5

        Me.Proceed.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.CheckBox1.Location = New System.Drawing.Point(8, 200)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(200, 16)
        Me.CheckBox1.TabIndex = 6

        '
        'ShowDesc
        '
        Me.ShowDesc.AutoSize = True
        Me.ShowDesc.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.ShowDesc.Location = New System.Drawing.Point(8, 144)
        Me.ShowDesc.Name = "ShowDesc"
        Me.ShowDesc.Size = New System.Drawing.Size(90, 16)
        Me.ShowDesc.TabIndex = 13
        Me.ShowDesc.TabStop = True

        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 250
        Me.ToolTip1.AutoPopDelay = 1000
        Me.ToolTip1.InitialDelay = 250
        Me.ToolTip1.ReshowDelay = 50
        '
        'frmUpdates
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 232)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Proceed)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Updates)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        Me.Updates.ResumeLayout(False)
        Me.UpdatesPane.ResumeLayout(False)
        Me.Login.ResumeLayout(False)
        Me.Downloading.ResumeLayout(False)
        Me.NoUpdates.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Structure Update_Info
        Dim Description As String
        Dim FullDescription As String
        Dim FromVersion As String
        Dim Version As String
        Dim Filename As String
        Dim Size As String
        Dim KB As Integer
        Dim [Date] As String
        Dim AddOn As Boolean
    End Structure
    Dim UpdateInfo() As Update_Info
    Dim credentials As NetworkCredential
    Dim rememberFile As String = Application.StartupPath & "\updatesettings.txt"
    Dim SilentUpdate As Boolean
    Dim Loaded As Boolean
    Dim HiddenUpdates() As String

    Sub ShowSilent()
        frmUpdates_Load(Nothing, Nothing)
        If Visible Then
            Visible = False
            ShowDialog()
        End If
    End Sub

    Private Sub frmUpdates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Loaded Then Exit Sub
        Loaded = True

        ReDim HiddenUpdates(-1)
        CheckBox1.Checked = Options.gCheckForUpdatesAtStartup
        If Not SilentUpdate Then
            Show()
            Application.DoEvents()
        Else
            Visible = False
        End If
        LoadUpdateSettings()
        If MyEdition.RequireUsernameAndPassword Then
            Login.Visible = True
            Proceed.Visible = True
            If DialogResult = DialogResult.Cancel Then Exit Sub
            Login.BringToFront()
            If SilentUpdate AndAlso Username.Text = "" Then
                Show()
            ElseIf SilentUpdate Then
                Proceed_Click(Nothing, Nothing)
            End If
        Else
            DownloadUpdateInfo()
        End If
    End Sub

    Sub DownloadUpdateInfo()
        'Store username and password
        SaveUpdateSettings()

Retry1:
        Try
            'Download update information
            Dim wRequest As HttpWebRequest = HttpWebRequest.Create(MyEdition.UpdatePath & "/updates.txt")
            If MyEdition.RequireUsernameAndPassword Then
                credentials = New NetworkCredential(Username.Text, Password.Text)
                wRequest.Credentials = credentials
            End If
            wRequest.Timeout = 5000
            Dim wResponse As WebResponse = wRequest.GetResponse()
            Dim length As Integer = wResponse.ContentLength
            Dim buffer(length) As Byte
            wResponse.GetResponseStream().Read(buffer, 0, length)
            wResponse.Close()
            Dim strb As New System.Text.StringBuilder(length)
            For i As Integer = 0 To buffer.Length - 1
                strb.Append(Chr(buffer(i)))
            Next
            Dim str As String = strb.ToString

            'Extract update information
            Dim splitStr() As String = str.Split("|")
            ReDim UpdateInfo(splitStr.Length / 5 - 1)
            Dim c As Integer = 0
            For i As Integer = 0 To splitStr.Length - 1 Step 5
                UpdateInfo(c).Description = splitStr(i).Trim(Chr(0), Chr(10), Chr(13))
                UpdateInfo(c).FromVersion = splitStr(i + 1).Trim(Chr(0), Chr(10), Chr(13))
                UpdateInfo(c).Version = splitStr(i + 2).Trim(Chr(0), Chr(10), Chr(13))
                UpdateInfo(c).Filename = splitStr(i + 3).Trim(Chr(0), Chr(10), Chr(13))
                UpdateInfo(c).FullDescription = splitStr(i + 4).Trim(Chr(0), Chr(10), Chr(13), " ")
                c += 1
            Next

            'Get current version
            Dim v As Version = Reflection.Assembly.GetExecutingAssembly.GetName.Version
            Dim curVersion As Double = CDbl(v.Major & "." & v.Minor & v.Build)

            'Compare with update versions
            For i As Integer = 0 To UpdateInfo.Length - 1
                If i > UpdateInfo.Length - 1 Then Exit For

                If UpdateInfo(i).FromVersion = "*" Then
                    'Supports all versions of PS
                    UpdateInfo(i).FromVersion = curVersion
                ElseIf Not (UpdateInfo(i).FromVersion.Chars(0) Like "#") Then
                    'Addon
                    UpdateInfo(i).AddOn = True

                    'Have we installed this before
                    If IO.Directory.Exists(Application.StartupPath & "\" & UpdateInfo(i).FromVersion) Then
                        'hide update
                        UpdateInfo(i).FromVersion = curVersion - 1
                    Else
                        'show update
                        UpdateInfo(i).FromVersion = curVersion
                    End If
                End If

                'Is this update hidden?
                For j As Integer = 0 To HiddenUpdates.Length - 1
                    If HiddenUpdates(j) = UpdateInfo(i).Description & "|" & UpdateInfo(i).Version Then
                        'hide update
                        UpdateInfo(i).FromVersion = curVersion - 1
                    End If
                Next

                Try
                    'Is the update version older than our current version
                    'or does it not support our current version?
                    Dim VParts() As String = UpdateInfo(i).Version.Split(New Char() {"."}, 2)
                    Dim Version As Double = CDbl(VParts(0) & "." & VParts(1).Replace(".", ""))
                    If UpdateInfo(i).FromVersion <> curVersion Or (Version >= 2.1 And Version <= curVersion) Then
                        For j As Integer = i To UpdateInfo.Length - 2
                            UpdateInfo(j) = UpdateInfo(j + 1)
                        Next
                        ReDim Preserve UpdateInfo(UpdateInfo.Length - 2)
                        i -= 1
                    End If
                Catch
                End Try
            Next

            'Gather other information
            For i As Integer = 0 To UpdateInfo.Length - 1
                Application.DoEvents()
                If DialogResult = DialogResult.Cancel Then Exit Sub

                wRequest = HttpWebRequest.Create(MyEdition.UpdatePath & "/" & UpdateInfo(i).Filename)
                If MyEdition.RequireUsernameAndPassword Then wRequest.Credentials = credentials
                wRequest.Timeout = 5000
                wResponse = wRequest.GetResponse()

                'Get size
                If wResponse.ContentLength >= 1000000 Then
                    UpdateInfo(i).Size = CSng(Math.Round(wResponse.ContentLength / (2 ^ 20), 2)) & " " & GetString("megabytesUnit")
                ElseIf wResponse.ContentLength >= 1000 Then
                    UpdateInfo(i).Size = CSng(Math.Round(wResponse.ContentLength / (2 ^ 10), 2)) & " " & GetString("kilobytesUnit")
                Else
                    UpdateInfo(i).Size = wResponse.ContentLength & " " & GetString("bytesUnit")
                End If
                If UpdateInfo(i).Size = "-1 " & GetString("bytesUnit") Then UpdateInfo(i).Size = GetString("updates_UnknownSize")
                UpdateInfo(i).kb = Math.Round(wResponse.ContentLength / 1024)

                'Get date
                Try
                    UpdateInfo(i).Date = Date.Parse(wResponse.Headers("Last-Modified")).ToShortDateString
                Catch
                    UpdateInfo(i).Date = GetString("updates_UnknownDate")
                End Try

                'Populate listview
                Dim li As ListViewItem = lv.Items.Add(UpdateInfo(i).Description)
                With li
                    .SubItems.Add(UpdateInfo(i).Version)
                    .SubItems.Add(UpdateInfo(i).Size)
                    .SubItems.Add(UpdateInfo(i).Date)
                End With
                li = Nothing

                wResponse.Close()
            Next

            If MyEdition.RequireUsernameAndPassword Then
                Login.Visible = False
                Proceed.Visible = False
            End If
            If lv.Items.Count > 0 Then
                'Updates
                UnhideAll.Enabled = (HiddenUpdates.Length > 0)
                lv.Items(0).Selected = True
                UpdatesPane.Visible = True
                lv.Select()
                lv_SelectedIndexChanged(Nothing, Nothing)
                UpdatesPane.BringToFront()
                If SilentUpdate And Not Visible Then Show()
            Else
                'No updates
                If SilentUpdate And Not Visible Then DialogResult = DialogResult.Cancel
                NoUpdates.Visible = True
                NoUpdates.BringToFront()
                LinkLabel1.Visible = (HiddenUpdates.Length > 0)
                Button1.Left = Button2.Left
                Button2.Visible = False
                Button1.Text = GetString("okButton")
            End If
            Label1.Visible = False

        Catch ex As WebException
            Select Case ex.Status
                Case WebExceptionStatus.ProtocolError
                    If MyEdition.RequireUsernameAndPassword Then
                        MessageBox.Show(GetString("updates_InvalidUsernameOrPasswordErrorMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        'Have a 1-second delay
                        Dim x As Integer = Environment.TickCount
                        Cursor.Current = Cursors.WaitCursor
                        Do
                        Loop Until Environment.TickCount - x >= 1000
                        Cursor.Current = Cursors.Default

                        Login.Visible = True
                        Proceed.Visible = True
                        Proceed.BringToFront()

                        If SilentUpdate And Visible = False Then Show()
                    Else
                        GoTo OtherError
                    End If
                Case WebExceptionStatus.ConnectFailure, WebExceptionStatus.ConnectionClosed, WebExceptionStatus.KeepAliveFailure, WebExceptionStatus.Timeout, WebExceptionStatus.NameResolutionFailure
                    If Not SilentUpdate Then
                        If MessageBox.Show(GetString("updates_UnableToConnectErrorMessage"), GetString("updates_Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                            Shell("rundll32.exe shell32.dll,Control_RunDLL ncpa.cpl,,0")
                            GoTo Retry1
                        End If
                    End If
                    DialogResult = DialogResult.Cancel
                Case Else
OtherError:
                    If Not SilentUpdate Then
                        If MessageBox.Show(ex.Message, GetString("updates_CannotRetrieveInfoErrorMessage"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = DialogResult.Retry Then GoTo Retry1
                    End If
                    DialogResult = DialogResult.Cancel
            End Select
        Catch ex As Exception
            If MessageBox.Show(ex.Message, GetString("updates_CannotRetrieveInfoErrorMessage"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = DialogResult.Retry Then GoTo Retry1
            DialogResult = DialogResult.Cancel
        End Try
    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        Button2.Enabled = (lv.SelectedIndices.Count = 1)
        HideSelectedUpdate.Enabled = Button2.Enabled
        If lv.SelectedIndices.Count <> 1 OrElse UpdateInfo(lv.SelectedIndices(0)).FullDescription = "" Then
            ToolTip1.RemoveAll()
            ShowDesc.Enabled = False
        Else
            ToolTip1.SetToolTip(lv, UpdateInfo(lv.SelectedIndices(0)).FullDescription)
            ShowDesc.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False

        If lv.SelectedItems(0).SubItems(3).Text = GetString("updates_UnknownSize") Then
            MessageBox.Show(GetString("updates_InvalidFileError"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DialogResult = DialogResult.None
            Exit Sub
        End If

        Dim update As Update_Info = UpdateInfo(lv.SelectedIndices(0))
        pb.Value = 0
        KBCounter.Text = "0 " & GetString("kilobytesUnit") & " / " & update.KB & " " & GetString("kilobytesUnit")
        TimeCounter.Text = ""
        Updates.Text = ""
        Downloading.BringToFront()
        Downloading.Visible = True
        Application.DoEvents()

        Try
            Dim imgPath As String = MyEdition.UpdatePath & "/" & update.Filename

            Dim wRequest As HttpWebRequest = HttpWebRequest.Create(imgPath)
            If MyEdition.RequireUsernameAndPassword Then wRequest.Credentials = credentials
            wRequest.Timeout = 5000
            Dim wResponse As WebResponse = wRequest.GetResponse()

            Dim DLPath As String = Application.StartupPath & "\tmp" & IO.Path.GetExtension(update.Filename)
            If IO.File.Exists(DLPath) Then IO.File.Delete(DLPath)
            Dim sWriter As FileStream = New FileStream(DLPath, FileMode.OpenOrCreate)
            Dim ContentLength As Integer = wResponse.ContentLength

            Dim BytesAtATime As Integer = 32 * 1024
            Dim buffer(BytesAtATime - 1) As Byte
            Dim startTime As Single = Environment.TickCount / 1000
            Dim bytesRead As Integer
            Dim stream As Stream = wResponse.GetResponseStream()

            pb.Value = 0
            pb.Maximum = ContentLength

            Dim c As Integer = 0
            Do
                bytesRead = stream.Read(buffer, 0, BytesAtATime)
                If bytesRead < 0 Then Throw New WebException("", WebExceptionStatus.ConnectionClosed)
                sWriter.Write(buffer, 0, bytesRead)

                'Update progress
                pb.Step = bytesRead
                pb.PerformStep()

                'Update KB
                c += bytesRead
                If c > ContentLength Then c = ContentLength
                KBCounter.Text = (c \ 1024) & " " & GetString("kilobytesUnit") & " / " & update.KB & " " & GetString("kilobytesUnit")

                'Update EST
                Dim TimeElapsed As Single = Environment.TickCount / 1000 - startTime
                Dim BPS As Single = c / TimeElapsed
                Dim BRemaining As Integer = ContentLength - c
                Dim TimeRemaining As Integer = Math.Round(BRemaining / BPS)

                Dim Hours As Integer = TimeRemaining \ 3600
                Dim Minutes As Integer = TimeRemaining \ 60 - Hours * 60
                Dim Seconds As Integer = TimeRemaining Mod 60

                If Hours = 0 And Minutes = 0 Then
                    TimeCounter.Text = String.Format(GetString("updates_SecondsRemaining"), Seconds)
                ElseIf Hours = 0 Then
                    TimeCounter.Text = String.Format(GetString("updates_MinutesRemaining"), Minutes, Seconds)
                Else
                    TimeCounter.Text = String.Format(GetString("updates_HoursRemaining"), Hours, Minutes)
                End If

                'Allow cancel
                Application.DoEvents()
                If DialogResult = DialogResult.Cancel Then
DoCancel:
                    sWriter.Close()
                    IO.File.Delete(DLPath)
                    wResponse.Close()
                    Exit Sub
                End If

            Loop Until bytesRead = 0

            sWriter.Close()
            sWriter = Nothing
            wResponse.Close()
            wRequest = Nothing

            If Not update.AddOn Then
                fGame.Close()
                If fGame.Cancelled Then
                    DialogResult = DialogResult.Cancel
                    Exit Sub
                End If
                fGame.Dispose()
                Process.Start(DLPath)
                Close()
            Else
                'Hide update now that we have downloaded it
                HideSelectedUpdate_LinkClicked(Nothing, Nothing)

                Process.Start(DLPath)
                lv.Items.Clear()
                Downloading.Visible = False
                Updates.Text = GetString("updates_AvailableUpdatesFrame")
                DownloadUpdateInfo()
                DialogResult = DialogResult.None
            End If

        Catch ex As WebException
            Select Case ex.Status
                Case WebExceptionStatus.ConnectFailure, WebExceptionStatus.ConnectionClosed, WebExceptionStatus.KeepAliveFailure, WebExceptionStatus.Timeout
                    MessageBox.Show(GetString("updates_UnableToConnectErrorMessage2"), GetString("updates_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DialogResult = DialogResult.Cancel
                Case Else
OtherError:
                    MessageBox.Show(ex.Message, GetString("updates_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DialogResult = DialogResult.Cancel
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, GetString("updates_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            DialogResult = DialogResult.Cancel
        End Try
    End Sub

    Private Sub Proceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Proceed.Click
        Proceed.Visible = False
        DownloadUpdateInfo()
    End Sub

    Private Sub Password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Password.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            Proceed_Click(sender, e)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Options.gCheckForUpdatesAtStartup = CheckBox1.Checked
    End Sub

    Private Sub HideSelectedUpdate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles HideSelectedUpdate.LinkClicked
        If lv.SelectedIndices.Count <> 1 Then Exit Sub
        ReDim Preserve HiddenUpdates(HiddenUpdates.Length)
        HiddenUpdates(HiddenUpdates.Length - 1) = lv.SelectedItems(0).Text & "|" & lv.SelectedItems(0).SubItems(1).Text
        For i As Integer = lv.SelectedIndices(0) To UBound(UpdateInfo) - 1
            UpdateInfo(i) = UpdateInfo(i + 1)
        Next
        ReDim Preserve UpdateInfo(UBound(UpdateInfo) - 1)
        lv.Items.Remove(lv.SelectedItems(0))
        UnhideAll.Enabled = True
        SaveUpdateSettings()
    End Sub

    Private Sub UnhideAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles UnhideAll.LinkClicked
        If HiddenUpdates.Length > 0 Then
            ReDim HiddenUpdates(-1)
            SaveUpdateSettings()
            lv.Items.Clear()
            DownloadUpdateInfo()
        End If
    End Sub

    Sub SaveUpdateSettings()
        Dim filenum As Integer = FreeFile()
        Try
            FileOpen(filenum, rememberFile, OpenMode.Output, OpenAccess.Write)
            If MyEdition.RequireUsernameAndPassword AndAlso Remember.Checked Then
                PrintLine(filenum, Username.Text)
                PrintLine(filenum, Password.Text)
            Else
                PrintLine(filenum, "")
                PrintLine(filenum, "")
            End If
            For i As Integer = 0 To HiddenUpdates.Length - 1
                PrintLine(filenum, HiddenUpdates(i))
            Next
            FileClose(filenum)
        Catch
            Try
                FileClose(filenum)
            Catch
            End Try
        End Try
    End Sub

    Sub LoadUpdateSettings()
        If IO.File.Exists(rememberFile) Then
            Dim filenum As Integer = FreeFile()
            Try
                FileOpen(filenum, rememberFile, OpenMode.Input, OpenAccess.Read)
                Username.Text = LineInput(filenum)
                Password.Text = LineInput(filenum)
                While Not EOF(filenum)
                    ReDim Preserve HiddenUpdates(HiddenUpdates.Length)
                    HiddenUpdates(HiddenUpdates.Length - 1) = LineInput(filenum)
                End While
                Remember.Checked = True
                FileClose(filenum)
            Catch
                Try
                    FileClose(filenum)
                Catch
                End Try
            End Try
        Else
            If SilentUpdate Then
                If MessageBox.Show(GetString("updates_AutoUpdateMessage"), GetString("updates_AutoUpdateMessageTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    MessageBox.Show(GetString("updates_AutoUpdateRefusedMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Options.gCheckForUpdatesAtStartup = False
                    DialogResult = DialogResult.Cancel
                Else
                    Options.gCheckForUpdatesAtStartup = True
                End If
            End If
            SaveUpdateSettings()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Button1.Left = Button2.Left - Button1.Width - 8
        Button2.Visible = True
        Button1.Text = GetString("cancelButton")
        UnhideAll_LinkClicked(sender, e)
    End Sub

    Private Sub ShowDesc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ShowDesc.LinkClicked
        MessageBox.Show(ToolTip1.GetToolTip(lv), GetString("updates_UpdateDescriptionMessageTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class