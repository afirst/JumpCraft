Imports PlatformStudio.psMod1
Imports PlatformStudio

Public Class psPathEditor
    'A cubic Bezier curve is defined by four points.
    '(x0,y0) & (x3,y3) are endpoints and (x1,y1) & (x2,y2) are control points.
    '
    'The following equations define the points on the curve.
    'Both are evaluated for an arbitrary number of values of t between 0 and 1.
    '
    ' X(t) = ax * t ^ 3 + bx * t ^ 2 + cx * t + x0
    ' X1 = x0 + cx / 3
    ' X2 = X1 + (cx + bx) / 3
    ' x3 = x0 + cx + bx + ax
    '
    ' Y(t) = ay * t ^ 3 + by * t ^ 2 + cy * t + y0
    ' Y1 = y0 + cy / 3
    ' Y2 = Y1 + (cy + by) / 3
    ' y3 = y0 + cy + by + ay

#Region "Options"
    Private _Enclose As Boolean = False
    Public Property Enclose() As Boolean
        Get
            Return _Enclose
        End Get
        Set(ByVal Value As Boolean)
            _Enclose = Value
            Dim i As Integer
            For i = 1 To UBound(Pts)
                GetLength(Pts(i), i)
            Next
        End Set
    End Property

    Public ShowGuides As Boolean = True
    Public ShowPoints As Boolean = True
    Public Precision As Double = 2 ^ (-6)
    Public Tint As Integer = 50
    Public Speed As Single = 100
    Public SpeedS As Single = 3
    Public LoopPreview As Boolean = True
#End Region

#Region "Other Declarations"
    'Whether the path editor is active or not
    Public Editing As Boolean

    'Controls
    Public progress As ProgressBar
    Public WithEvents p As PictureBox
    Public btnPreview As Button

    Sub SetPrecision(ByVal ValueFrom0To10 As Byte)
        Precision = 2 ^ -(ValueFrom0To10 + 1)
    End Sub

    Dim Pts() As psPath.psPathPoint, CurPt As Integer, PtIndex As Single
    Dim NoPoints As Boolean
    Enum PType 'Preset type
        PT_None = 0
        PT_Rectangle
        PT_RoundedRect
        PT_Ellipse
        PT_FIgure8
        PT_CloverLeaf
    End Enum
    Dim sX As Integer, sY As Integer
    Dim DoStop As Boolean
    Dim NoChange As Boolean

    Dim PresetMode As Boolean, curPreset As Integer
    Dim DontUpdateStatus As Boolean
    Dim Unloading As Boolean

    Dim PrevVis As Boolean, PrevX As Single, PrevY As Single
    Dim HalfTileW As Integer, HalfTileH As Integer

    Dim Previewing As Boolean
    Dim S As Single 'Preview start time
#End Region

#Region "Undo/Redo"
    Structure psPathEditorUndo
        Dim Pts() As psPath.psPathPoint
        Dim NoPts As Boolean
    End Structure
    Dim pUndo() As psPathEditorUndo
    Dim pUndoStr() As String
    Dim pCurUndo As Integer
    Dim pCanUndo As Boolean, pCanRedo As Boolean
    Dim pNeedToUpdate As Boolean
    Dim pMaxUndo As Byte = UndoRedo.MaxUndo

    Property CurUndo() As Integer
        Get
            Return pCurUndo
        End Get
        Set(ByVal Value As Integer)
            pCurUndo = Value
        End Set
    End Property

    ReadOnly Property UndoStr() As String()
        Get
            Return pUndoStr
        End Get
    End Property

    Function CanUndo() As Boolean
        Return pCanUndo
    End Function

    Function CanRedo() As Boolean
        Return pCanRedo
    End Function

    Sub ResetUndo()
        Erase pUndo
        Erase pUndoStr
        pCanUndo = False
        pCanRedo = False
        pNeedToUpdate = False
        pCurUndo = 0
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.UndoRedoTextChanged()
    End Sub

    Sub UpdateUndo(Optional ByVal Description As String = "")
        Dim i As Integer
        ReDim Preserve pUndo(pCurUndo)
        ReDim Preserve pUndoStr(pCurUndo)

        With pUndo(UBound(pUndo))
            ReDim .Pts(UBound(Pts))
            For i = 0 To UBound(Pts)
                .Pts(i) = Pts(i).Clone
            Next
            .NoPts = NoPoints
        End With
        pUndoStr(UBound(pUndo)) = Description

        pNeedToUpdate = True
        pCurUndo = pCurUndo + 1
        pCanUndo = True
        pCanRedo = False

        If UBound(pUndo) > pMaxUndo Then
            For i = 0 To pMaxUndo
                pUndo(i).Pts = pUndo((i + UBound(pUndo) - (pMaxUndo))).Pts.Clone
                pUndo(i).NoPts = pUndo((i + UBound(pUndo) - (pMaxUndo))).NoPts
            Next
            ReDim Preserve pUndo(pMaxUndo)
            pCurUndo = pMaxUndo + 1
        End If

        Editor.psedit.UndoRedoTextChanged()
    End Sub

    Sub Undo()
        CurPt = 0
        PtIndex = 0

        If pNeedToUpdate Then
            Me.UpdateUndo()
            pCurUndo -= 1
            pNeedToUpdate = False
        End If
        pCurUndo -= 1

        With pUndo(pCurUndo)
            Dim i As Integer
            ReDim Pts(UBound(.Pts))
            For i = 0 To UBound(.Pts)
                Pts(i) = .Pts(i).Clone
            Next
            NoPoints = .NoPts
        End With

        pCanUndo = (pCurUndo > 0)
        pCanRedo = True

        Editor.psedit.UndoRedoTextChanged()
    End Sub

    Sub Redo()
        CurPt = 0
        PtIndex = 0

        If pNeedToUpdate Then
            Me.UpdateUndo()
            pCurUndo -= 1
            pNeedToUpdate = False
        End If
        pNeedToUpdate = False
        pCurUndo += 1

        With pUndo(pCurUndo)
            Dim i As Integer
            ReDim Pts(UBound(.Pts))
            For i = 0 To UBound(.Pts)
                Pts(i) = .Pts(i).Clone
            Next
            NoPoints = .NoPts
        End With

        pCanRedo = (pCurUndo < UBound(pUndo))
        pCanUndo = True

        Editor.psedit.UndoRedoTextChanged()
    End Sub
#End Region

    Dim _CanCopy As Boolean, _CanDelete As Boolean
    Function CanCopy() As Boolean
        Return _CanCopy
    End Function
    Function CanDelete() As Boolean
        Return _CanDelete
    End Function

    Private ReadOnly Property Timer() As Double
        Get
            Return Microsoft.VisualBasic.Timer
        End Get
    End Property

    Private ReadOnly Property CurTile() As psEditor.seltile
        Get
            Try
                Return Editor.psedit.seltiles(1)
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Private ReadOnly Property CurLayer() As Integer
        Get
            Return psMap.CurLayer
        End Get
    End Property

    Sub Preview()
        If Previewing Then
            DoStop = True
            Exit Sub
        Else
            DoStop = False
        End If
        btnPreview.Text = GetString("pathEd_StopButton")
        Previewing = True
        PrevVis = True
        progress.Value = 0
        S = Timer
    End Sub

    Sub DrawBezier()
        If CurTile.Equals(Nothing) Then Exit Sub

        Dim i As Integer
        With Game.Drawing
            .RelativeToCam = False
            .AffectedByScrollSpeed = False

            .DrawFilledBox(0, 0, Game.cam.w, Game.cam.h, Color.FromArgb((Tint / 100) * 255, 0, 0, 0))

            .RelativeToCam = True
            .AffectedByScrollSpeed = True

            'Draw the grid
            Game.drawGrid(HalfTileW, HalfTileH)

            'Draw selected tile
            Game.CurMap.DrawTile(CurTile.x, CurTile.y, CurLayer, CurTile.tile, True, , , , , False)

            'Draw beizer
            If Pts Is Nothing Then NoPoints = True
            If NoPoints Then Exit Sub
            For i = 0 To UBound(Pts)
                PathHelper.DrawSingleBezier(Pts, Enclose, i, (i = UBound(Pts)), Precision, ShowGuides, ShowPoints, Color.Red)
            Next

            'Play preview
            If Previewing Then
                'Variables
                Dim PlayLength As Single
                Dim t As Single, tot As Single
                Dim Path As psPath
                Dim pbVal As Integer

                'Calculate how long it will take in seconds
                PlayLength = SpeedS
                If PlayLength = 0 Then PlayLength = 0.0001

                'Calculate the length of the path
                tot = PathHelper.Path_TotalLength(Pts, Enclose)

                'If the path has length...
                If tot > 0 Then

                    'Set up the temporary path structure
                    Path.Enclosed = Enclose
                    Path.Pts = Pts
                    Path.Speed = SpeedS

                    'Calculate how long it's been
                    t = Timer - S

                    'Update ProgressBar
                    pbVal = Int(t / IIf(SpeedS = 0, 1000, SpeedS) * 1000)
                    If pbVal < 0 Then pbVal = 0
                    If pbVal > 1000 Then pbVal = 1000
                    progress.Value = pbVal

                    'If there are no more valid positions on the
                    'path, then we can stop previewing
                    'Also finds the current position on the path
                    If PathHelper.Path_GetPos(Path, t, PrevX, PrevY) = False Then
                        PrevVis = False
                    Else
                        PrevVis = True
                    End If

                    'If we are all done...
                    If DoStop Or Timer - S >= PlayLength Then
                        If LoopPreview And DoStop = False Then
                            'either loop
                            S = Timer
                        Else
                            'or stop
                            PrevVis = False
                            Previewing = False
                            btnPreview.Text = GetString("pathEd_PreviewButton")
                            progress.Value = 0
                            DoStop = True
                        End If
                    End If

                End If
            End If

            'Draw preview
            If PrevVis Then
                .IgnoreOffsets = False
                .OffsetX = PrevX - CurTile.w * 0.5
                .OffsetY = PrevY - CurTile.h * 0.5
                Game.CurMap.DrawTile(1, 1, CurLayer, CurTile.tile, True, , , , , False)
                .OffsetX = 0
                .OffsetY = 0
            End If
        End With
    End Sub

    Sub CreatePreset(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, Optional ByVal PType As PType = PType.PT_Ellipse)
        Enclose = True
        DontUpdateStatus = True

        If CreatePreset_UpdatedUndo = False Then
            Select Case PType
                Case PType.PT_Rectangle
                    Me.UpdateUndo(GetString("undoActionPathRectangle"))
                Case PType.PT_RoundedRect
                    Me.UpdateUndo(GetString("undoActionPathRoundedRectangle"))
                Case PType.PT_Ellipse
                    Me.UpdateUndo(GetString("undoActionPathEllipse"))
                Case PType.PT_FIgure8
                    Me.UpdateUndo(GetString("undoActionPathFigure8"))
                Case PType.PT_CloverLeaf
                    Me.UpdateUndo(GetString("undoActionPathCloverLeaf"))
            End Select
            CreatePreset_UpdatedUndo = True
        End If

        'Find Y midpoint
        Dim XMid As Single, YMid As Single
        XMid = (X1 + X2) * 0.5
        YMid = (Y1 + Y2) * 0.5

        'Create a new path
        NoPoints = False
        ReDim Pts(0)
        Pts(0).Init()

        If PType = PType.PT_FIgure8 Then

            'First point
            With Pts(0)
                .XPoint(0) = X1
                .YPoint(0) = YMid
                .XPoint(1) = X1
                .YPoint(1) = Y2
            End With

            'Second point
            ReDim Preserve Pts(1) : Pts(1).Init()
            With Pts(1)
                .XPoint(0) = X2
                .YPoint(0) = YMid
                .XPoint(1) = X2
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()
        ElseIf PType = PType.PT_Ellipse Then

            'First point
            With Pts(0)
                .XPoint(0) = X1
                .YPoint(0) = YMid
                .XPoint(1) = X1
                .YPoint(1) = Y2
            End With

            'Second point
            ReDim Preserve Pts(1) : Pts(1).Init()
            With Pts(1)
                .XPoint(0) = X2
                .YPoint(0) = YMid
                .XPoint(1) = X2
                .YPoint(1) = Y1
            End With
            UpdatePrevPt()

        ElseIf PType = PType.PT_Rectangle Then

            'First point
            With Pts(0)
                .XPoint(0) = X1
                .YPoint(0) = Y1
                .XPoint(1) = X1
                .YPoint(1) = Y1
            End With

            'Second point
            ReDim Preserve Pts(1) : Pts(1).Init()
            With Pts(1)
                .XPoint(0) = X1
                .YPoint(0) = Y2
                .XPoint(1) = X1
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()

            'Third point
            ReDim Preserve Pts(2) : Pts(2).Init()
            With Pts(2)
                .XPoint(0) = X2
                .YPoint(0) = Y2
                .XPoint(1) = X2
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()

            'Fourth point
            ReDim Preserve Pts(3) : Pts(3).Init()
            With Pts(3)
                .XPoint(0) = X2
                .YPoint(0) = Y1
                .XPoint(1) = X2
                .YPoint(1) = Y1
            End With
            UpdatePrevPt()

        ElseIf PType = PType.PT_RoundedRect Then

            'First point
            With Pts(0)
                .XPoint(0) = X1
                .YPoint(0) = YMid
                .XPoint(1) = X1
                .YPoint(1) = Y2
            End With

            'Second point
            ReDim Preserve Pts(1) : Pts(1).Init()
            With Pts(1)
                .XPoint(0) = XMid
                .YPoint(0) = Y2
                .XPoint(1) = X2
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()

            'Third point
            ReDim Preserve Pts(2) : Pts(2).Init()
            With Pts(2)
                .XPoint(0) = X2
                .YPoint(0) = YMid
                .XPoint(1) = X2
                .YPoint(1) = Y1
            End With
            UpdatePrevPt()

            'Fourth point
            ReDim Preserve Pts(3) : Pts(3).Init()
            With Pts(3)
                .XPoint(0) = XMid
                .YPoint(0) = Y1
                .XPoint(1) = X1
                .YPoint(1) = Y1
            End With
            UpdatePrevPt()

        ElseIf PType = PType.PT_CloverLeaf Then

            'First point
            With Pts(0)
                .XPoint(0) = X1
                .YPoint(0) = YMid
                .XPoint(1) = X1
                .YPoint(1) = Y1
            End With

            'Second point
            ReDim Preserve Pts(1) : Pts(1).Init()
            With Pts(1)
                .XPoint(0) = XMid
                .YPoint(0) = Y2
                .XPoint(1) = X1
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()

            'Third point
            ReDim Preserve Pts(2) : Pts(2).Init()
            With Pts(2)
                .XPoint(0) = X2
                .YPoint(0) = YMid
                .XPoint(1) = X2
                .YPoint(1) = Y2
            End With
            UpdatePrevPt()

            'Fourth point
            ReDim Preserve Pts(3) : Pts(3).Init()
            With Pts(3)
                .XPoint(0) = XMid
                .YPoint(0) = Y1
                .XPoint(1) = X2
                .YPoint(1) = Y1
            End With
            UpdatePrevPt()

        End If

        DontUpdateStatus = False
        UpdateStatus()
    End Sub

    Sub Clear()
        Me.UpdateUndo(GetString("undoActionClearPath"))

        ReDim Pts(0)
        NoPoints = True
        UpdateStatus()
    End Sub

    Sub CopyPoint()
        Me.UpdateUndo(GetString("undoActionCopyPoint"))

        Dim i As Integer
        ReDim Preserve Pts(UBound(Pts) + 1)
        For i = UBound(Pts) - 1 To CurPt Step -1
            Pts(i + 1) = Pts(i).Clone
        Next
        Pts(CurPt).XPoint(0) = Pts(CurPt).XPoint(0) + Game.tileW
        Pts(CurPt).YPoint(0) = Pts(CurPt).YPoint(0) + Game.tileH
        Pts(CurPt).XPoint(1) = Pts(CurPt).XPoint(1) + Game.tileW
        Pts(CurPt).YPoint(1) = Pts(CurPt).YPoint(1) + Game.tileH
        UpdatePrevPt(CurPt + 1)
        UpdatePrevPt(CurPt)
        UpdatePrevPt(CurPt - 1)
    End Sub

    Sub DeletePoint()
        Me.UpdateUndo(GetString("undoActionDeletePoint"))

        Dim i As Integer
        For i = CurPt To UBound(Pts) - 1
            Pts(i) = Pts(i + 1)
        Next
        If UBound(Pts) = 0 Then
            NoPoints = True
        Else
            ReDim Preserve Pts(UBound(Pts) - 1)
        End If
        UpdatePrevPt(CurPt)
    End Sub

    Sub ClickedPreset(ByVal Index As Integer)
        curPreset = Index
        If Index = 0 Then
            PresetMode = False
            p.Cursor = Cursors.Default
            Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_ReadyStatus")
        Else
            PresetMode = True
            p.Cursor = Cursors.Cross
            Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_DrawPresetStatus")
        End If
    End Sub

    Private Sub p_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.MouseLeave
        Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_ReadyStatus")
    End Sub

    Private Sub p_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.MouseHover
        If PresetMode Then
            Exit Sub
        End If

        If p.Cursor Is Cursors.SizeAll And ShiftDown = False Then
            Exit Sub
        End If

        If ShiftDown Then
            Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_MovePathStatus")
            p.Cursor = Cursors.SizeAll
        Else
            Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_AddPointStatus")
            p.Cursor = Cursors.Default
        End If
    End Sub

    Private Function MouseToPixel(ByRef mx As Integer, ByRef my As Integer) As Point
        'Convert the mouse coordinates to pixel coordinates
        mx = (mx - Game.cam.X) + (Game.cam.X * Game.ScrollSpeed)
        my = (my - Game.cam.Y) + (Game.cam.Y * Game.ScrollSpeed)
    End Function

    Private Sub p_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles p.MouseDown
        _CanCopy = False
        _CanDelete = False

        Dim X As Integer, Y As Integer
        X = e.X : Y = e.Y
        X += Game.cam.X
        Y += Game.cam.Y

        MouseToPixel(X, Y)

        If PresetMode Then
            sX = Math.Round((X - HalfTileW) / Game.tileW) * Game.tileW + HalfTileW
            sY = Math.Round((Y - HalfTileH) / Game.tileH) * Game.tileH + HalfTileH
            If e.Button = MouseButtons.Right Then
                Editor.psedit.Raise_PathEditorRightClick()
            End If
            Exit Sub
        ElseIf ShiftDown Then
            sX = Math.Round((X - HalfTileW) / Game.tileW) * Game.tileW + HalfTileW
            sY = Math.Round((Y - HalfTileH) / Game.tileH) * Game.tileH + HalfTileH
            p.Cursor = Cursors.SizeAll
            If e.Button = MouseButtons.Right Then
                Editor.psedit.Raise_PathEditorRightClick()
            End If
            Exit Sub
        End If

        CurPt = -1

        'Drag point
        Dim tmpPt As Integer
        tmpPt = CollideWithGuide(X, Y)
        If tmpPt = -1 Then tmpPt = CollideWithPt(X, Y)
        If tmpPt > -1 Then
            If e.Button <> MouseButtons.Left And e.Button <> MouseButtons.Right Then Exit Sub
            CurPt = tmpPt
            If (PtIndex = 0 Or PtIndex = 3) And e.Button = MouseButtons.Right Then
                X = X - Game.cam.X
                Y = Y - Game.cam.Y
                _CanCopy = True
                _CanDelete = True
                Editor.psedit.Raise_PathEditorRightClick()
                Exit Sub
            ElseIf e.Button = MouseButtons.Right Then
                Editor.psedit.Raise_PathEditorRightClick()
            End If
            Me.UpdateUndo(GetString("undoActionPathDragPoint"))
            sX = Math.Round((X - HalfTileW) / Game.tileW) * Game.tileW + HalfTileW
            sY = Math.Round((Y - HalfTileH) / Game.tileH) * Game.tileH + HalfTileH
            Exit Sub
        ElseIf e.Button = MouseButtons.Right Then
            Editor.psedit.Raise_PathEditorRightClick()
        End If

        If e.Button <> MouseButtons.Left Then Exit Sub

        X = Math.Round((X - HalfTileW) / Game.tileW) * Game.tileW + HalfTileW
        Y = Math.Round((Y - HalfTileH) / Game.tileH) * Game.tileH + HalfTileH

        Me.UpdateUndo(GetString("undoActionPathNewPoint"))

        If NoPoints Then
            NoPoints = False
        Else
            ReDim Preserve Pts(UBound(Pts) + 1)
        End If
        Pts(UBound(Pts)).Init()
        Dim i As Integer
        For i = 0 To 1
            Pts(UBound(Pts)).XPoint(i) = X
            Pts(UBound(Pts)).YPoint(i) = Y
        Next
        UpdatePrevPt()
    End Sub

    Private ReadOnly Property ShiftDown() As Boolean
        Get
            Return ((Control.ModifierKeys And Keys.Shift) > 0)
        End Get
    End Property

    Dim CreatePreset_UpdatedUndo As Boolean
    Private Sub p_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles p.MouseMove
        If PresetMode = False And ShiftDown Then p.Cursor = Cursors.SizeAll
        If PresetMode = False And ShiftDown = False Then p.Cursor = Cursors.Default

        Dim X As Integer, Y As Integer
        X = e.X : Y = e.Y
        X += Game.cam.X
        Y += Game.cam.Y

        MouseToPixel(X, Y)

        If e.Button = MouseButtons.Left Then
            If ShiftDown Then
                X = Math.Round(X / Game.tileW) * Game.tileW
                Y = Math.Round(Y / Game.tileH) * Game.tileH
                Dim i As Integer, j As Integer
                For i = 0 To UBound(Pts)
                    For j = 0 To 3
                        Pts(i).XPoint(j) = Pts(i).XPoint(j) + (X - sX)
                        Pts(i).YPoint(j) = Pts(i).YPoint(j) + (Y - sY)
                    Next
                Next
                sX = X
                sY = Y
                p.Cursor = Cursors.SizeAll
                Exit Sub
            End If

            X = Math.Round((X - HalfTileW) / Game.tileW) * Game.tileW + HalfTileW
            Y = Math.Round((Y - HalfTileH) / Game.tileH) * Game.tileH + HalfTileH

            If PresetMode Then
                Dim tw As Integer, th As Integer
                tw = (X - sX) : th = (Y - sY)
                CreatePreset(sX - tw, sY - th, sX + tw, sY + th, curPreset)
                CreatePreset_UpdatedUndo = True
                Exit Sub
            End If

            If CurPt > -1 Then
                'Drag point
                Pts(CurPt).XPoint(PtIndex) = X
                Pts(CurPt).YPoint(PtIndex) = Y
                If PtIndex = 0 Or PtIndex = 3 Then
                    Pts(CurPt).XPoint(1) = Pts(CurPt).XPoint(1) + (X - sX)
                    Pts(CurPt).YPoint(1) = Pts(CurPt).YPoint(1) + (Y - sY)
                End If
                If PtIndex = 2 Then
                    Dim PtIndexP1 As Integer
                    If CurPt = UBound(Pts) Then
                        If Enclose Then
                            PtIndexP1 = 0
                        Else
                            PtIndexP1 = -1
                        End If
                    Else
                        PtIndexP1 = CurPt + 1
                    End If
                    If PtIndexP1 > -1 Then
                        Pts(PtIndexP1).XPoint(1) = Pts(PtIndexP1).XPoint(0) * 2 - Pts(CurPt).XPoint(2)
                        Pts(PtIndexP1).YPoint(1) = Pts(PtIndexP1).YPoint(0) * 2 - Pts(CurPt).YPoint(2)
                    End If
                End If
                sX = X
                sY = Y
                UpdatePrevPt(CurPt)
                p.Cursor = Cursors.SizeAll
            Else
                'Create point
                Pts(UBound(Pts)).XPoint(1) = X
                Pts(UBound(Pts)).YPoint(1) = Y
                Pts(UBound(Pts)).XPoint(2) = Pts(UBound(Pts)).XPoint(3) + Pts(UBound(Pts)).XPoint(1) - Pts(UBound(Pts)).XPoint(0)
                Pts(UBound(Pts)).YPoint(2) = Pts(UBound(Pts)).YPoint(3) + Pts(UBound(Pts)).YPoint(1) - Pts(UBound(Pts)).YPoint(0)
                UpdatePrevPt()
            End If
        Else
            If PresetMode Then
                Exit Sub
            End If

            If e.Button = MouseButtons.Left Then
                p.Cursor = Cursors.SizeAll
                Exit Sub
            End If

            If CollideWithPt(X, Y) > -1 Or CollideWithGuide(X, Y) > -1 Then
                p.Cursor = Cursors.SizeAll
                If PtIndex = 0 Or PtIndex = 3 Then
                    Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_MovePointStatus")
                Else
                    Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_MoveGuideStatus")
                End If
            Else
                If ShiftDown Then
                    Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_MovePathStatus")
                    p.Cursor = Cursors.SizeAll
                Else
                    Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_AddPointStatus")
                    p.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub UpdatePrevPt(Optional ByVal PtIndex As Integer = -1)
        If PtIndex = -1 Then PtIndex = UBound(Pts)
        If PtIndex > UBound(Pts) Then Exit Sub
        GetLength(Pts(PtIndex), PtIndex)
        Dim PtIndexM1 As Integer
        PtIndexM1 = PtIndex - 1
        If PtIndexM1 = -1 Then
            If Enclose Then
                PtIndexM1 = UBound(Pts)
            Else
                UpdateStatus()
                Exit Sub
            End If
        End If
        Pts(PtIndexM1).XPoint(3) = Pts(PtIndex).XPoint(0)
        Pts(PtIndexM1).YPoint(3) = Pts(PtIndex).YPoint(0)
        Pts(PtIndexM1).XPoint(2) = Pts(PtIndex).XPoint(0) * 2 - Pts(PtIndex).XPoint(1)
        Pts(PtIndexM1).YPoint(2) = Pts(PtIndex).YPoint(0) * 2 - Pts(PtIndex).YPoint(1)
        GetLength(Pts(PtIndexM1), PtIndexM1)
        UpdateStatus()
    End Sub

    Private Sub p_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles p.MouseUp
        If PresetMode Then
            CreatePreset_UpdatedUndo = False
            PresetMode = False
            p.Cursor = Cursors.Default
            If ShiftDown Then
                Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_MovePathStatus")
            Else
                Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_AddPointStatus")
            End If
            Editor.pstileselect.Value = 1 'edit points
        End If
    End Sub

    Private Function CollideWithPt(ByVal X As Integer, ByVal Y As Integer) As Integer
        If NoPoints Then Return -1
        Dim i As Integer
        For i = UBound(Pts) To 0 Step -1
            If Math.Abs(Pts(i).XPoint(0) - X) <= 8 And Math.Abs(Pts(i).YPoint(0) - Y) <= 8 Then
                PtIndex = 0
                Return i
            ElseIf (i < UBound(Pts) And Math.Abs(Pts(i).XPoint(3) - X) <= 8 And Math.Abs(Pts(i).YPoint(3) - Y) <= 8) Then
                PtIndex = 3
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function CollideWithGuide(ByVal X As Integer, ByVal Y As Integer) As Integer
        If NoPoints Then Return -1
        Dim i As Integer
        For i = UBound(Pts) To 0 Step -1
            If Math.Abs(Pts(i).XPoint(1) - X) <= 4 And Math.Abs(Pts(i).YPoint(1) - Y) <= 4 Then
                PtIndex = 1
                Return i
            ElseIf (i < UBound(Pts) And Math.Abs(Pts(i).XPoint(2) - X) <= 4 And Math.Abs(Pts(i).YPoint(2) - Y) <= 4) Then
                PtIndex = 2
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub GetLength(ByRef Pt As psPath.psPathPoint, ByVal Index As Integer)
        Dim ptP1 As Integer, i As Integer, xt() As Single, yt() As Single
        With Pt
            If Index = UBound(Pts) Then
                ptP1 = 0
            Else
                ptP1 = Index + 1
            End If
            ReDim xt(10), yt(10)
            For i = 0 To 10
                PathHelper.Path_GetPosOnPoint(Pts(Index), Pts(0), (Index = UBound(Pts)), Enclose, CSng(i) * 0.1, Index, xt(i), yt(i))
            Next
            .Length = 0
            For i = 0 To 9
                .Length += Game.Math.Dist(xt(i), yt(i), xt(i + 1), yt(i + 1))
            Next
        End With
    End Sub

    Sub UpdateStatus()
        If DontUpdateStatus Then Exit Sub
        Dim tot As Single
        tot = PathHelper.Path_TotalLength(Pts, Enclose)
        If NumPts() <> 1 Then
            Editor.psstatus.sb.Panels(1).Text = String.Format(GetString("pathEd_PointsPlural"), NumPts())
        Else
            Editor.psstatus.sb.Panels(1).Text = GetString("pathEd_PointsSingular")
        End If
        Editor.psstatus.sb.Panels(2).Text = String.Format(GetString("pathEd_Pixels"), Math.Round(tot))
    End Sub

    ReadOnly Property NumPts() As Integer
        Get
            If NoPoints Then
                Return 0
            Else
                Return UBound(Pts) + 1
            End If
        End Get
    End Property

    Sub Done(Optional ByVal Cancel As Boolean = False)
        If Not Editing Then Exit Sub

        If Cancel = False Then SavePath()

        Editing = False

        DoStop = True
        Unloading = True
        Previewing = False
        PrevVis = False

        btnPreview.Text = GetString("pathEd_PreviewButton")
        progress.Value = 0
        progress.Visible = False
        progress = Nothing
        p = Nothing

        'Init controls
        Editor.pslevelsel.Visible = True
        Editor.pstileselect.UpdateList()
        Editor.pstools.Enabled = True
        Editor.psproperties.Enabled = True
        Editor.pslayersel.Visible = True
        Editor.psproperties.Refresh()
        Editor.psedit.UndoRedoTextChanged()
        Editor.psedit.ClearStatusBar()
        Editor.psstatus.UpdateImages()

        Editor.OnEndPathEdit()
    End Sub

    Sub Init(ByVal prog As ProgressBar, ByVal pic As PictureBox, ByVal PreviewButton As Button, ByVal txtSpeed As TextBox, ByVal chkEnclosed As CheckBox)
        Editing = True

        Editor.OnBeginPathEdit()

        'Init status bar
        Editor.psstatus.sb.Panels(0).Text = GetString("pathEd_ReadyStatus")
        Editor.psstatus.sb.Panels(1).Text = String.Format(GetString("pathEd_PointsPlural"), 0)
        Editor.psstatus.sb.Panels(2).Text = String.Format(GetString("pathEd_Pixels"), 0)

        'Init points
        ReDim Pts(0)
        NoPoints = True
        ResetUndo()

        'Set some variables
        HalfTileW = CurTile.w * 0.5
        HalfTileH = CurTile.h * 0.5

        'Load the current path
        If CurTile.tile.Path.Exists = False Then
            ReDim Pts(0)
            Enclose = False
            SpeedS = 3
        Else
            With CurTile.tile.Path
                Pts = .Pts
                Enclose = .Enclosed
                SpeedS = .Speed
                If SpeedS = 0 Then SpeedS = 3
            End With
        End If
        If UBound(Pts) = 0 Then
            NoPoints = True
        Else
            NoPoints = False
        End If

        'Init progress bar
        progress = prog
        progress.Value = 0
        progress.Visible = True

        'Init picture box
        p = pic

        'Init preview button
        btnPreview = PreviewButton

        'Init fields
        txtSpeed.Text = SpeedS
        chkEnclosed.Checked = Enclose

        'Init controls
        Editor.pslevelsel.Visible = False
        Editor.pstileselect.UpdateList()
        Editor.pstools.Enabled = False
        Editor.pslayersel.Visible = False
        Editor.psproperties.Refresh()
        Editor.psedit.UndoRedoTextChanged()
        Editor.pstileselect.Value = 1 '.list.Items(0).Selected = True
        Editor.psstatus.UpdateImages()
    End Sub

    Private Sub SavePath()
        UndoRedo.UpdateUndo(GetString("undoActionEditPath"), UndoRedo.UndoType.Layer, Game.CurMapIndex, psMap.CurLayer)
        With Editor.psedit.seltiles(1).tile.Path
            .Exists = (Not NoPoints)
            .Pts = Pts
            .Enclosed = Enclose
            .Speed = SpeedS
        End With
    End Sub
End Class