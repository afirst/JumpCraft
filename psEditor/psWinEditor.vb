Imports PlatformStudio
Imports PlatformStudio.psUI.psControl

Public Class psWinEditor
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents hs As System.Windows.Forms.HScrollBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents vs As System.Windows.Forms.VScrollBar
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents p As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.hs = New System.Windows.Forms.HScrollBar
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.vs = New System.Windows.Forms.VScrollBar
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.p = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.hs)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 16)
        Me.Panel1.TabIndex = 6
        '
        'hs
        '
        Me.hs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hs.Enabled = False
        Me.hs.Location = New System.Drawing.Point(0, 0)
        Me.hs.Name = "hs"
        Me.hs.Size = New System.Drawing.Size(304, 16)
        Me.hs.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(304, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'vs
        '
        Me.vs.Dock = System.Windows.Forms.DockStyle.Right
        Me.vs.Enabled = False
        Me.vs.LargeChange = 32
        Me.vs.Location = New System.Drawing.Point(304, 0)
        Me.vs.Name = "vs"
        Me.vs.Size = New System.Drawing.Size(16, 280)
        Me.vs.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel2.Controls.Add(Me.p)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(304, 280)
        Me.Panel2.TabIndex = 7
        '
        'p
        '
        Me.p.BackColor = System.Drawing.Color.Black
        Me.p.Location = New System.Drawing.Point(0, 0)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(304, 280)
        Me.p.TabIndex = 5
        Me.p.TabStop = False
        '
        'psWinEditor
        '
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.vs)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "psWinEditor"
        Me.Size = New System.Drawing.Size(320, 296)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const MaxCtrls As Byte = 200

    'Events
    Event CanCopyPasteChanged()
    Event CanUndoRedoChanged()
    Event UpdateSelection()
    Event DoubleClickControl()

    Public ms As psMoveSize

    'Mouse
    Dim MouseOut As Boolean
    Dim MDown As Boolean
    Dim sx As Integer, sy As Integer
    Dim mx As Integer, my As Integer

    'Sel vars
    Public Shared sel As Rectangle
    Public Shared selecting As Boolean

    Dim OldSelCtrls() As psUI.psControl
    Dim CopyCtrls() As psUI.psControl

    Dim Locked As Boolean

    Dim start As Single, frames As Integer, fps As Single

    Public GridX As Integer, GridY As Integer

    Public OffsetX As Integer, OffsetY As Integer

    Dim _active As Boolean
    Friend Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal Value As Boolean)
            _active = Value
            'Timer1.Enabled = _active
        End Set
    End Property

    Sub Init()
        MouseOut = True
        'ReDim SelCtrls(0)
        ReDim OldSelCtrls(0)
        ReDim CopyCtrls(0)
        ms = New psMoveSize
        ms.MapEditorCoordinates = False
        ms.SetPictureBox(p)
        '        Timer1.Enabled = True
        GridX = 16
        GridY = 16
        ms.GridX = GridX
        ms.GridY = GridY
        Deselect()
        DoResize()
    End Sub

    Private Sub psWinEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Register control
        If Game Is Nothing Then Exit Sub
        Editor.winedit = Me
        p.Size = New Size(Game.windows.Width, Game.windows.Height)
        psWinEditor_Resize(Nothing, Nothing)
        UpdateSel()
    End Sub

    Sub MakeActive()
        If Game.p Is p Then Exit Sub
        Game.Drawing.Re_Init(p)
        Editor.psedit.Active = False
        Game.p = Me.p
        Active = True
        Game.Drawing.OffsetX = OffsetX
        Game.Drawing.OffsetY = OffsetY
        p.Size = New Size(Game.windows.Width, Game.windows.Height)
        psWinEditor_Resize(Nothing, Nothing)
    End Sub

    Sub MakeInactive()
        If Not (Game.p Is p) Then Exit Sub
        Game.p = Editor.psedit.p
        Game.Drawing.Re_Init(Game.p)
        Editor.psedit.Active = True
        Active = False
        Game.Drawing.OffsetX = 0
        Game.Drawing.OffsetY = 0
    End Sub

    Overloads Sub Refresh()
        If Game Is Nothing Then Exit Sub
        If _active = False Then Exit Sub

        Static tmpCanCopy As Boolean, tmpCanPaste As Boolean
        Static DidThis As Boolean

        If Locked Then Exit Sub

        Dim i As Integer, j As Integer, R As Rectangle

        With Game.Drawing
            If start = 0 Then start = Microsoft.VisualBasic.Timer
            frames = frames + 1
            If Microsoft.VisualBasic.Timer - start >= 1 Then
                start = Microsoft.VisualBasic.Timer
                fps = frames
                frames = 0
            End If

            'If .InvalidDevice OrElse Game.Drawing.device.CheckCooperativeLevel = False Then
            'Game.Drawing.Re_Init(p.Handle)
            'End If

            .Clear()

            .AffectedByScrollSpeed = False
            .RelativeToCam = False

            'Draw current window
            If MatchAny1(Game.CurWindow.Name, "windows_PauseWindow") Then
                For i = 1 To Game.numWindows
                    For j = 1 To Game.windows.Windows(i).NumCtrls
                        If Game.windows.Windows(i).Controls(j).Type = psUI.psControl.psCtrlType.GameArea Then
                            Game.windows.Windows(i).Draw(False)
                        End If
                    Next
                Next
            End If
            Game.CurWindow.Draw(Options.wShowGrid)

            'Draw selection box
            If selecting Then
                .DrawFilledBox(R.X, R.Y, R.Width, R.Height, Color.FromArgb(128, 64, 64, 255))
                .DrawFilledBox(sel.X, sel.Y, sel.Width, sel.Height, Color.FromArgb(128, 64, 64, 255))
                .DrawBox(sel.X, sel.Y, sel.Width, sel.Height, Color.FromArgb(192, 128, 128, 255))
                .DrawBox(sel.X - 1, sel.Y - 1, sel.Width + 2, sel.Height + 2, Color.FromArgb(192, 128, 128, 255))
            End If

            'Update selection handles
            If NumSelCtrls = 1 Then
                R = ms.GetRect
                If R.X < 0 Then
                    If Not (p.Cursor Is Cursors.SizeAll) Then R.Width += R.X
                    R.X = 0
                End If
                If R.Y < 0 Then
                    If Not (p.Cursor Is Cursors.SizeAll) Then R.Height += R.Y
                    R.Y = 0
                End If
                If R.Right > Game.windows.Width Then R.Width = Game.windows.Width - R.X
                If R.Bottom > Game.windows.Height Then R.Height = Game.windows.Height - R.Y
                ms.SetRect(R)
                ms.Sync(FirstSelCtrl.Rectangle)
            End If

            'Draw selected controls
            'For i = 1 To UBound(SelCtrls)
            '    SelCtrls(i).Draw()
            '    With SelCtrls(i).Rectangle
            '        Game.Drawing.DrawFilledBox(.X, .Y, .Width, .Height, Color.FromArgb(128, 0, 0, 255))
            '        Game.Drawing.DrawBox(.X, .Y, .Width, .Height, Color.FromArgb(128, 255, 192, 128))
            '    End With
            'Next

            'Draw selection handles
            If NumSelCtrls = 1 Then
                ms.Draw()
            End If

            'Draw FPS
            If Options.wShowFramerate Then
                .IgnoreOffsets = True
                .DrawText(fps & " " & GetString("fpsUnit"), 2, 2, Color.White)
                .IgnoreOffsets = False
            End If
        End With

        'Events
        If DidThis = False Then RaiseEvent CanUndoRedoChanged()
        If CanCopy() <> tmpCanCopy Or CanPaste() <> tmpCanPaste Or DidThis = False Then
            tmpCanCopy = CanCopy()
            tmpCanPaste = CanPaste()
            DidThis = True
            RaiseEvent CanCopyPasteChanged()
        End If
    End Sub

    ReadOnly Property NumSelCtrls() As Integer
        Get
            Dim cnt As Integer
            For i As Integer = 1 To Game.CurWindow.NumCtrls
                If Game.CurWindow.Controls(i).Selected Then cnt += 1
            Next
            Return cnt
        End Get
    End Property

    Function CanUndo() As Boolean
        Return UndoRedo.CanUndo
    End Function

    Function CanRedo() As Boolean
        Return UndoRedo.CanRedo
    End Function

    Function CanCut() As Boolean
        Return NumSelCtrls > 0
    End Function

    Function CanCopy() As Boolean
        Return CanCut()
    End Function

    Function CanPaste() As Boolean
        Return (UBound(CopyCtrls) > 0)
    End Function

    Function CanDelete() As Boolean
        Return CanCut()
    End Function

    Function CanDeselect() As Boolean
        Return CanCut()
    End Function

    Sub Undo()
        psFileHandler.MadeChanges = True
        UndoRedo.DoUndo()
    End Sub

    Sub Redo()
        psFileHandler.MadeChanges = True
        UndoRedo.DoRedo()
    End Sub

    Sub Cut()
        Copy()
        Delete()
    End Sub

    Sub Copy()
        'CopyCtrls = CopyCtrlArray(SelCtrls, False)
        DoNotLoadImages = True
        ReDim CopyCtrls(0)
        For i As Integer = 1 To Game.CurWindow.NumCtrls
            If Game.CurWindow.Controls(i).Selected Then
                ReDim Preserve CopyCtrls(UBound(CopyCtrls) + 1)
                CopyCtrls(UBound(CopyCtrls)) = Game.CurWindow.Controls(i).Clone(False, False)
            End If
        Next
        DoNotLoadImages = False
    End Sub

    Sub Paste()
        psFileHandler.MadeChanges = True

        UndoRedo.UpdateUndo(GetString("undoActionPaste"), UndoRedo.UndoType.Windows)
        Editor.winctrls.Value = 0
        Deselect()

        Dim i As Integer
        For i = 1 To UBound(CopyCtrls)
            If CopyCtrls(i).Type = psUI.psControl.psCtrlType.GameArea Then
                If Not CheckForExisting____Area(psUI.psControl.psCtrlType.GameArea, GetString("winEd_Game")) Then
                    GoTo PasteCtrl
                End If
            ElseIf CopyCtrls(i).Type = psUI.psControl.psCtrlType.HighScoresArea Then
                If Not CheckForExisting____Area(psUI.psControl.psCtrlType.HighScoresArea, GetString("winEd_HighScore")) Then
                    GoTo PasteCtrl
                End If
            Else
PasteCtrl:
                If NumSelCtrls + Game.CurWindow.NumCtrls >= MaxCtrls Then
                    MessageBox.Show(String.Format(GetString("winEd_ControlLimitMessage"), MaxCtrls), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                With Game.CurWindow
                    .NewControl(CopyCtrls(i).Clone(True, True))
                End With
            End If
        Next

        If NumSelCtrls = 1 Then
            ms.SetRect(FirstSelCtrl.Rectangle)
            ms.Enable()
        End If
        UpdateSel()
    End Sub

    Sub Delete()
        UndoRedo.UpdateUndo(GetString("undoActionDelete"), UndoRedo.UndoType.Windows)
        ms.Disable()
        'Dim i As Integer
        'For i = 1 To UBound(SelCtrls)
        '    SelCtrls(i) = Nothing
        'Next
        'ReDim SelCtrls(0)
        For i As Integer = 1 To Game.CurWindow.NumCtrls
            If i > Game.CurWindow.NumCtrls Then Exit For
            If Game.CurWindow.Controls(i).Selected Then
                'For j As Integer = i To Game.CurWindow.NumCtrls - 1
                'Game.CurWindow.Controls(j) = Game.CurWindow.Controls(j + 1)
                'Next
                'ReDim Preserve Game.CurWindow.Controls(Game.CurWindow.NumCtrls - 1)
                Game.CurWindow.RemoveControl(i)
                i -= 1
            End If
        Next
        UpdateSel()
    End Sub

    Sub SelectAll()
        psFileHandler.MadeChanges = True

        Editor.winctrls.Value = 0
        Deselect()
        Dim i As Integer
        With Game.CurWindow
            For i = 1 To .NumCtrls
                .Controls(i).Selected = True
            Next
            'For i = 1 To UBound(SelCtrls)
            '    SelCtrls(i) = Nothing
            'Next
            'ReDim SelCtrls(UBound(.Controls))
            'For i = 1 To UBound(.Controls)
            '    SelCtrls(i) = .Controls(i).Clone
            '    .Controls(i) = Nothing
            'Next
            'ReDim .Controls(0)
        End With
        If NumSelCtrls = 1 Then
            ms.SetRect(FirstSelCtrl.Rectangle)
            ms.Enable()
        End If
        UpdateSel()
    End Sub

    Sub Deselect(ByVal KeepSel As Boolean)
        If KeepSel = False AndAlso (ms Is Nothing) = False Then ms.Disable()
        Dim i As Integer ', j As Integer
        If KeepSel = False Then
            For i = 1 To Game.CurWindow.NumCtrls
                Game.CurWindow.Controls(i).Selected = False
            Next
            UpdateSel()
        End If
    End Sub

    Sub Deselect()
        Deselect(False)
    End Sub

    Dim ctl As psUI.psControl

    Private Sub p_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseDown
        Me.Focus()

        psFileHandler.MadeChanges = True

        If e.Button = MouseButtons.Left Then
            MDown = True
            mx = e.X
            my = e.Y
            sx = mx
            sy = my

            'MouseDown
            If Editor.winctrls.Value = 0 Then
                If ShiftDown Or (ms.CurCursor Is Cursors.Default And p.Cursor Is Cursors.Default) Then

                    'Quick select
                    If ShiftDown = False Then
                        Dim i As Integer
                        For i = Game.CurWindow.NumCtrls To 1 Step -1
                            If Game.Math.Collide_PtBox( _
                                mx, my, Game.CurWindow.Controls(i).Rectangle) Then
                                Deselect()
                                'ReDim SelCtrls(1)
                                'SelCtrls(1) = Game.CurWindow.Controls(i).Clone
                                Game.CurWindow.Controls(i).Selected = True
                                ms.SetRect(Game.CurWindow.Controls(i).Rectangle)
                                ms.Enable()
                                'Game.CurWindow.RemoveControl(i)
                                p.Cursor = Cursors.SizeAll
                                UpdateSel()
                                GoTo Transform
                            End If
                        Next
                    End If

                    selecting = True
                    sel = New Rectangle(sx, sy, 0, 0)
                    If ShiftDown = False Then Deselect()
                Else
Transform:
                    UndoRedo.UpdateUndo(GetString("undoActionTransformSelection"), UndoRedo.UndoType.Windows)
                    GetSelCtrls()
                    OldSelCtrls = CopyCtrlArray(SelCtrls, False)
                End If
            Else
                If Game.CurWindow.NumCtrls >= MaxCtrls Then
                    MessageBox.Show(GetString(String.Format("winEd_ControlLimitMessage2", MaxCtrls)), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                UndoRedo.UpdateUndo(GetString("undoActionAddControl"), UndoRedo.UndoType.Windows)
                sx = Math.Round(sx / GridX) * GridX
                sy = Math.Round(sy / GridY) * GridY
                Dim ctlnum As Integer
                ctlnum = Game.CurWindow.NumCtrls + 1
                Select Case Editor.winctrls.Value
                    Case 1
                        ctl = Game.CurWindow.NewButton
                    Case 2
                        ctl = Game.CurWindow.NewLabel
                    Case 3
                        ctl = Game.CurWindow.NewImage
                    Case 4
                        If CheckForExisting____Area(psUI.psControl.psCtrlType.GameArea, GetString("winEd_Game")) Then Exit Sub
                        ctl = Game.CurWindow.NewGame
                    Case 5
                        ctl = Game.CurWindow.NewTextCounter
                    Case 6
                        ctl = Game.CurWindow.NewImageTextCounter
                    Case 7
                        ctl = Game.CurWindow.NewImageCounter
                    Case 8
                        If CheckForExisting____Area(psUI.psControl.psCtrlType.HighScoresArea, GetString("winEd_HighScore")) Then Exit Sub
                        ctl = Game.CurWindow.NewHighScoresArea
                    Case 9
                        ctl = Game.CurWindow.NewMovie
                End Select
                With ctl
                    ctl.SetDefaultText(ctl.Name)
                    Dim index As Integer = ctl.Name.IndexOfAny("0123456789".ToCharArray())
                    If index >= 0 Then
                        If ctl.Type < psCtrlType.GameArea Then
                            ctl.Text = ctl.Name.Substring(0, index) + " " + ctl.Name.Substring(index)
                        End If
                    End If
                    .Rectangle = New Rectangle(sx, sy, 0, 0)
                End With
            End If
        End If
        Refresh()
    End Sub

    Function CheckForExisting____Area(ByVal CtlType As psUI.psControl.psCtrlType, ByVal AreaName As String) As Boolean
        Dim i As Integer, j As Integer
        For i = 1 To Game.numWindows
            For j = 1 To Game.windows.Windows(i).NumCtrls
                If Game.windows.Windows(i).Controls(j).Type = CtlType Then
                    If MessageBox.Show(String.Format(GetString("winEd_AreaAlreadyExists"), AreaName, Game.windows.Windows(i).Name), "Window Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Game.windows.Windows(i).RemoveControl(j)
                        If MDown Then
                            MDown = False
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        MDown = False
                        Return True
                    End If
                End If
            Next
        Next
        Return False
    End Function

    Private Sub p_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p.MouseEnter
        MouseOut = False
        Refresh()
    End Sub

    Private Sub p_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p.MouseLeave
        MouseOut = True
        With Editor.winstatus.sb
            .Panels(1).Text = GetString("main_XLabel")
            .Panels(2).Text = GetString("main_YLabel")
        End With
        Refresh()
    End Sub

    Private Sub p_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseMove
        mx = e.X
        my = e.Y
        With Editor.winstatus.sb
            .Panels(1).Text = GetString("main_XLabel") & " " & mx
            .Panels(2).Text = GetString("main_YLabel") & " " & my
        End With
        Dim i As Integer
        GetSelCtrls()
        If MDown Then

            'MouseDrag
            If Editor.winctrls.Value = 0 Then
                If selecting Then
                    'Selection box
                    MakeValidRectangle(sel, sx, sy, mx, my)
                Else
                    'Drag selected items
                    If p.Cursor Is Cursors.SizeAll Then
                        For i = 1 To UBound(SelCtrls)
                            With SelCtrls(i)
                                .X = OldSelCtrls(i).Rectangle.X + Math.Round((mx - sx) / GridX) * GridX
                                .Y = OldSelCtrls(i).Rectangle.Y + Math.Round((my - sy) / GridY) * GridY
                                If .X > Game.windows.Width - .Width Then .X = Game.windows.Width - .Width
                                If .Y > Game.windows.Height - .Height Then .Y = Game.windows.Height - .Height
                                If .X < 0 Then .X = 0
                                If .Y < 0 Then .Y = 0
                            End With
                        Next
                        If ms.Enabled Then ms.SetRect(FirstSelCtrl.Rectangle)
                    End If
                End If
            Else
                mx = Math.Round(mx / GridX) * GridX
                my = Math.Round(my / GridY) * GridY
                With ctl
                    MakeValidRectangle(.Rectangle, sx, sy, mx, my)
                    With .Rectangle
                        If .X > Game.windows.Width - .Width Then ctl.X = Game.windows.Width - .Width
                        If .Y > Game.windows.Height - .Height Then ctl.Y = Game.windows.Height - .Height
                        If .X < 0 Then ctl.X = 0
                        If .Y < 0 Then ctl.Y = 0
                    End With
                End With
            End If

        Else

            'MouseMove
            Dim bOverTile As Boolean = False
            For i = 1 To UBound(SelCtrls)
                With SelCtrls(i)
                    If Game.Math.Collide_PtBox( _
                        mx, my, .Rectangle) Then
                        bOverTile = True
                    End If
                End With
            Next
            If ms.Enabled Then
                p.Cursor = ms.CurCursor
                If p.Cursor Is Cursors.Default Then
                    If bOverTile Then
                        p.Cursor = Cursors.SizeAll
                    End If
                End If
            Else
                If bOverTile Then
                    p.Cursor = Cursors.SizeAll
                Else
                    p.Cursor = Cursors.Default
                End If
            End If

        End If
        Refresh()
    End Sub

    Private _SelCtrls() As psUI.psControl
    Sub GetSelCtrls()
        ReDim _SelCtrls(0)
        For i As Integer = 1 To Game.CurWindow.NumCtrls
            If Game.CurWindow.Controls(i).Selected Then
                ReDim Preserve _SelCtrls(UBound(_SelCtrls) + 1)
                _SelCtrls(UBound(_SelCtrls)) = Game.CurWindow.Controls(i)
            End If
        Next
    End Sub
    ReadOnly Property SelCtrls() As psUI.psControl()
        Get
            Return _SelCtrls
        End Get
    End Property

    Private Sub p_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseUp
        DoNotLoadImages = True
        GetSelCtrls()
        If MDown Then
            MDown = False

            'MouseUp
            Dim i As Integer
            If Editor.winctrls.Value = 0 Then
                If selecting Then
                    selecting = False
                    With Game.CurWindow
                        If ShiftDown = False Then Deselect()

                        'Remove from selection
                        If ShiftDown And sel.Width = 0 And sel.Height = 0 Then
                            For i = 1 To UBound(SelCtrls)
                                If Game.Math.Collide_BoxBox( _
                                    sel, SelCtrls(i).Rectangle) Then
                                    '.NewControl(SelCtrls(i))
                                    'For j = i To UBound(SelCtrls) - 1
                                    '    SelCtrls(j) = SelCtrls(j + 1).Clone
                                    'Next
                                    'SelCtrls(UBound(SelCtrls)) = Nothing
                                    'ReDim Preserve SelCtrls(UBound(SelCtrls) - 1)
                                    SelCtrls(i).Selected = False
                                    GoTo DoneSel
                                End If
                            Next
                        End If

                        'Add to selection
                        For i = .NumCtrls To 1 Step -1 '1 To UBound(.Controls)
                            If i > .NumCtrls Then Exit For
                            If Game.Math.Collide_BoxBox( _
                                sel, .Controls(i).Rectangle) Then
                                'ReDim Preserve SelCtrls(UBound(SelCtrls) + 1)
                                'SelCtrls(UBound(SelCtrls)) = .Controls(i).Clone
                                'For j = i To UBound(.Controls) - 1
                                '    .Controls(j) = .Controls(j + 1).Clone
                                'Next
                                '.Controls(UBound(.Controls)) = Nothing
                                'ReDim Preserve .Controls(UBound(.Controls) - 1)
                                .Controls(i).Selected = True
                                If sel.Width = 0 And sel.Height = 0 Then Exit For
                                'i = i - 1
                            End If
                        Next
                    End With

DoneSel:
                    If NumSelCtrls = 1 Then
                        ms.SetRect(FirstSelCtrl.Rectangle)
                        ms.Enable()
                    Else
                        ms.Disable()
                    End If
                End If

            Else
                If ctl.Rectangle.Width = 0 Or ctl.Rectangle.Height = 0 Then
                    'ReDim Preserve Game.CurWindow.Controls(Game.CurWindow.NumCtrls - 1)
                    Game.CurWindow.RemoveControl(Game.CurWindow.NumCtrls)
                End If
                Editor.winctrls.Value = 0
            End If

        End If

        UpdateSel()

        DoNotLoadImages = False
        Refresh()
    End Sub

    Property FirstSelCtrl() As psUI.psControl
        Get
            For i As Integer = 1 To Game.CurWindow.NumCtrls
                If Game.CurWindow.Controls(i).Selected Then Return Game.CurWindow.Controls(i)
            Next
        End Get
        Set(ByVal Value As psUI.psControl)
            For i As Integer = 1 To Game.CurWindow.NumCtrls
                If Game.CurWindow.Controls(i).Selected Then
                    Game.CurWindow.Controls(i) = Value
                    Exit Property
                End If
            Next
        End Set
    End Property

    Public Sub UpdateSel()
        'If Game.windows.winctrlactions Is Nothing Then Exit Sub
        'With Game.windows.winctrlactions
        '    If NumSelCtrls = 1 AndAlso FirstSelCtrl.CanHaveAction Then
        '        .Value = FirstSelCtrl.Action
        '        .Enabled = True
        '    Else
        '        .Value = -1
        '        .Enabled = False
        '        .Refresh()
        '    End If
        'End With

        RaiseEvent UpdateSelection()
    End Sub

    ReadOnly Property ShiftDown() As Boolean
        Get
            Return (Control.ModifierKeys And Keys.Shift) <> 0
        End Get
    End Property

    Function CopyCtrlArray(ByVal orig() As psUI.psControl, Optional ByVal MakeActive As Boolean = True) As psUI.psControl()
        DoNotLoadImages = True
        Dim tmp() As psUI.psControl
        ReDim tmp(UBound(orig))
        Dim i As Integer
        For i = 1 To UBound(tmp)
            tmp(i) = orig(i).Clone(False, MakeActive)
        Next
        Return tmp
        DoNotLoadImages = False
    End Function

    Friend Sub DoResize()
        If GridX = 0 Then GridX = 16
        If GridY = 0 Then GridY = 16

        Dim mw As Integer, mh As Integer 'Map size in pixels
        mw = Game.windows.Width
        mh = Game.windows.Height
        If Panel2.Width < mw Then
            hs.LargeChange = GridX * 4
            hs.SmallChange = GridX
            hs.Maximum = Math.Ceiling((mw - Panel2.Width) / hs.LargeChange) * hs.LargeChange + hs.LargeChange
            hs.Enabled = True
        Else
            hs.Enabled = False
            hs.Value = 0
        End If
        hsscroll()
        If Panel2.Height < mh Then
            vs.LargeChange = GridY * 4
            vs.SmallChange = GridY
            vs.Maximum = Math.Ceiling((mh - Panel2.Height) / vs.LargeChange) * vs.LargeChange + vs.LargeChange
            vs.Enabled = True
        Else
            vs.Enabled = False
            vs.Value = 0
        End If
        vsscroll()
    End Sub

    Private Sub psWinEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Game Is Nothing Then Exit Sub
        If Not (Game.Drawing Is Nothing) Then
            DoResize()
        End If
    End Sub

    Private Sub hs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hs.Scroll
        hsscroll()
    End Sub

    Private Sub hsscroll()
        p.Left = -hs.Value
        Game.Drawing.OffsetX = OffsetX
        Refresh()
    End Sub

    Private Sub vs_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vs.Scroll
        vsscroll()
    End Sub

    Private Sub vsscroll()
        p.Top = -vs.Value
        Game.Drawing.OffsetY = OffsetY
        Refresh()
    End Sub

    Friend Sub UndoRedoTextChanged()
        RaiseEvent CanUndoRedoChanged()
    End Sub

    ReadOnly Property UndoText() As String
        Get
            If UndoRedo.UndoStr Is Nothing OrElse CanUndo() = False Then Return ""
            Return UndoRedo.UndoStr(UndoRedo.CurUndo - 1)
        End Get
    End Property

    ReadOnly Property RedoText() As String
        Get
            If UndoRedo.UndoStr Is Nothing OrElse CanRedo() = False Then Return ""
            Return UndoRedo.UndoStr(UndoRedo.CurUndo)
        End Get
    End Property

    Sub LockUpdate()
        Locked = True
    End Sub

    Sub UnlockUpdate()
        Locked = False
    End Sub

    Private Sub p_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles p.Paint
        Refresh()
    End Sub

    Sub CenterHorizontally()
        UndoRedo.UpdateUndo(GetString("undoActionCenterH"), UndoRedo.UndoType.Windows)
        GetSelCtrls()
        Dim i As Integer, R As Rectangle
        R = BoundingBox()
        For i = 1 To UBound(SelCtrls)
            SelCtrls(i).X = (Game.windows.Width - R.Width) * 0.5 + (SelCtrls(i).X - R.X)
        Next
        If ms.Enabled Then ms.SetRect(SelCtrls(1).Rectangle)
    End Sub

    Sub CenterVertically()
        UndoRedo.UpdateUndo(GetString("undoActionCenterV"), UndoRedo.UndoType.Windows)
        GetSelCtrls()
        Dim i As Integer, R As Rectangle
        R = BoundingBox()
        For i = 1 To UBound(SelCtrls)
            SelCtrls(i).Y = (Game.windows.Height - R.Height) * 0.5 + (SelCtrls(i).Y - R.Y)
        Next
        If ms.Enabled Then ms.SetRect(SelCtrls(1).Rectangle)
    End Sub

    Sub AlignToGrid()
        UndoRedo.UpdateUndo(GetString("undoActionAlignToGrid"), UndoRedo.UndoType.Windows)
        GetSelCtrls()
        Dim i As Integer
        For i = 1 To UBound(SelCtrls)
            With SelCtrls(i)
                .X = Math.Round(.X / GridX) * GridX
                .Y = Math.Round(.Y / GridY) * GridY
                .Width = Math.Round(.Width / GridX) * GridX
                .Height = Math.Round(.Height / GridY) * GridY
            End With
        Next
        If ms.Enabled Then ms.SetRect(SelCtrls(1).Rectangle)
    End Sub

    Sub DoBringToFront()
        UndoRedo.UpdateUndo(GetString("undoActionBringToFront"), UndoRedo.UndoType.Windows)
        With Game.CurWindow
            Dim cnt As Integer
            For i As Integer = 1 To .NumCtrls
                cnt += 1
                If cnt > .NumCtrls Then Exit For
                If .Controls(i).Selected Then
                    Dim tmpCtrl As psUI.psControl = .Controls(i)
                    For j As Integer = i To .NumCtrls - 1
                        .Controls(j) = .Controls(j + 1)
                    Next
                    .Controls(.NumCtrls) = tmpCtrl
                    i -= 1
                End If
            Next
        End With
    End Sub

    Sub DoSendToBack()
        UndoRedo.UpdateUndo(GetString("undoActionSendToBack"), UndoRedo.UndoType.Windows)
        With Game.CurWindow
            For i As Integer = 1 To .NumCtrls
                If .Controls(i).Selected Then
                    Dim tmpCtrl As psUI.psControl = .Controls(i)
                    For j As Integer = i To 2 Step -1
                        .Controls(j) = .Controls(j - 1)
                    Next
                    .Controls(1) = tmpCtrl
                End If
            Next
        End With
    End Sub

    Function BoundingBox() As Rectangle
        Dim i As Integer, tmpRect As Rectangle
        Dim tmpX As Integer, tmpY As Integer, tmpR As Integer, tmpB As Integer
        For i = 1 To UBound(SelCtrls)
            If SelCtrls(i).X < tmpX Or i = 1 Then
                tmpX = SelCtrls(i).X
            End If
            If SelCtrls(i).Y < tmpY Or i = 1 Then
                tmpY = SelCtrls(i).Y
            End If
            If SelCtrls(i).Rectangle.Right > tmpR Or i = 1 Then
                tmpR = SelCtrls(i).Rectangle.Right
            End If
            If SelCtrls(i).Rectangle.Bottom > tmpB Or i = 1 Then
                tmpB = SelCtrls(i).Rectangle.Bottom
            End If
        Next
        tmpRect = New Rectangle(tmpX, tmpY, tmpR - tmpX, tmpB - tmpY)
        Return tmpRect
    End Function

    Sub EditControlProperties()
        p_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub p_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.DoubleClick
        If NumSelCtrls > 0 Then
            RaiseEvent DoubleClickControl()
        End If
    End Sub

    Private Sub p_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles p.Invalidated
        Refresh()
    End Sub
End Class