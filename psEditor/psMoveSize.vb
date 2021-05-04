Public Class psMoveSize
    Event Resize()

    Private R As Rectangle
    Dim ShowHandles As Boolean
    Private rHandles() As Rectangle
    Private Const HandleSize As Byte = 7
    Private Const HandleMargin As Byte = 1
    Private WithEvents p As PictureBox
    Public Enabled As Boolean
    Dim gX As Double, gY As Double
    Private _gdiPlus As Boolean

    Property GridX() As Double
        Get
            If gX = 0 Then
                Return Game.tileW
            Else
                Return gX
            End If
        End Get
        Set(ByVal Value As Double)
            gX = Value
        End Set
    End Property

    Property GridY() As Double
        Get
            If gY = 0 Then
                Return Game.tileH
            Else
                Return gY
            End If
        End Get
        Set(ByVal Value As Double)
            gY = Value
        End Set
    End Property

    Sub SetRect(ByVal Value As Rectangle)
        R = Value
        UpdateHandles()
    End Sub

    Function GetRect() As Rectangle
        Return R
    End Function

    ReadOnly Property LeftStart() As Integer
        Get
            Dim tmp As Integer = R.Left - (HandleSize + HandleMargin)
            If tmp < 0 And Not MapEditorCoordinates Then
                Return 0
            Else
                Return tmp
            End If
        End Get
    End Property

    ReadOnly Property TopStart() As Integer
        Get
            Dim tmp As Integer = R.Top - (HandleSize + HandleMargin)
            If tmp < 0 And Not MapEditorCoordinates Then
                Return 0
            Else
                Return tmp
            End If
        End Get
    End Property

    ReadOnly Property RightStart() As Integer
        Get
            Dim tmp As Integer = R.Right + HandleMargin
            If tmp > p.Width - rHandles(1).Width - 1 And Not MapEditorCoordinates Then
                Return p.Width - rHandles(1).Width - 1
            Else
                Return tmp
            End If
        End Get
    End Property

    ReadOnly Property BottomStart() As Integer
        Get
            Dim tmp As Integer = R.Bottom + HandleMargin
            If tmp > p.Height - rHandles(1).Height - 1 And Not MapEditorCoordinates Then
                Return p.Height - rHandles(1).Height - 1
            Else
                Return tmp
            End If
        End Get
    End Property

    ReadOnly Property CenterXStart() As Integer
        Get
            Return (LeftStart + RightStart) / 2
        End Get
    End Property

    ReadOnly Property CenterYStart() As Integer
        Get
            Return (TopStart + BottomStart) / 2
        End Get
    End Property

    Sub New()
        Me.New(False)
    End Sub

    Sub New(ByVal GDIPlus As Boolean)
        ShowHandles = True
        ReDim rHandles(7)
        p = Editor.psedit.p
        _gdiPlus = GDIPlus
    End Sub

    Private Sub UpdateHandles()
        '035
        '1 6
        '247
        rHandles(0) = New Rectangle(LeftStart, TopStart, HandleSize, HandleSize)
        rHandles(1) = New Rectangle(LeftStart, CenterYStart, HandleSize, HandleSize)
        rHandles(2) = New Rectangle(LeftStart, BottomStart, HandleSize, HandleSize)
        rHandles(3) = New Rectangle(CenterXStart, TopStart, HandleSize, HandleSize)
        rHandles(4) = New Rectangle(CenterXStart, BottomStart, HandleSize, HandleSize)
        rHandles(5) = New Rectangle(RightStart, TopStart, HandleSize, HandleSize)
        rHandles(6) = New Rectangle(RightStart, CenterYStart, HandleSize, HandleSize)
        rHandles(7) = New Rectangle(RightStart, BottomStart, HandleSize, HandleSize)
    End Sub

    Function CurCursor() As Cursor
        If Enabled = False Then Return Cursors.Default
        Select Case CollideWithHandle()
            Case 0, 7 : Return Cursors.SizeNWSE
            Case 1, 6 : Return Cursors.SizeWE
            Case 2, 5 : Return Cursors.SizeNESW
            Case 3, 4 : Return Cursors.SizeNS
            Case Else : Return Cursors.Default
        End Select
    End Function

    Dim MDown As Boolean, sx As Integer, sy As Integer
    Dim CurHandle As Integer
    Dim OldR As Rectangle
    Dim mx As Integer, my As Integer

    ReadOnly Property isDraggingHandle() As Boolean
        Get
            Return MDown AndAlso CurHandle > -1
        End Get
    End Property

    Public Sub MouseMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseMove
        mx = e.X
        my = e.Y
        If CurHandle = -1 Then Exit Sub
        If MDown Then
            Dim modX As Integer, modY As Integer, modW As Integer, modH As Integer
            Dim kX As Integer, kY As Integer
            kX = Math.Round((e.X - sx) / GridX) * GridX
            kY = Math.Round((e.Y - sy) / GridY) * GridY
            Select Case CurHandle
                Case 0
                    modX = kX
                    modY = kY
                    modW = -kX
                    modH = -kY
                Case 1
                    modX = kX
                    modW = -kX
                Case 2
                    modX = kX
                    modW = -kX
                    modH = kY
                Case 3
                    modY = kY
                    modH = -kY
                Case 4
                    modH = kY
                Case 5
                    modY = kY
                    modW = kX
                    modH = -kY
                Case 6
                    modW = kX
                Case 7
                    modW = kX
                    modH = kY
            End Select
            If (OldR.Width + modW) < GridX Then
                If modX <> 0 Then modX = -(GridX - OldR.Width)
                modW = GridX - OldR.Width
            End If
            If (OldR.Height + modH) < GridY Then
                If modY <> 0 Then modY = -(GridY - OldR.Height)
                modH = GridY - OldR.Height
            End If
            R.X = OldR.X + modX
            R.Y = OldR.Y + modY
            R.Width = OldR.Width + modW
            R.Height = OldR.Height + modH
            UpdateHandles()
            RaiseEvent Resize()
        End If
    End Sub

    Private Sub MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseDown
        MDown = True
        sx = e.X
        sy = e.Y
        CurHandle = CollideWithHandle()
        OldR = R
    End Sub

    Private Sub MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseUp
        MDown = False
    End Sub

    Public MapEditorCoordinates As Boolean = True
    Function CollideWithHandle() As Integer
        Dim i As Integer
        For i = 0 To 7
            If _gdiPlus Then
                If Game.Math.Collide_PtBox(mx, my, rHandles(i)) Then
                    Return i
                End If
            ElseIf MapEditorCoordinates Then
                If Game.Math.Collide_PtBox( _
                Editor.psedit.mx, Editor.psedit.my, rHandles(i)) Then
                    Return i
                End If
            Else
                If Game.Math.Collide_PtBox( _
                mx - Game.Drawing.OffsetX, my - Game.Drawing.OffsetY, rHandles(i)) Then
                    Return i
                End If
            End If
        Next
        Return -1
    End Function

    Sub Draw()
        If Enabled = False Then Exit Sub
        Dim i As Integer
        With Game.Drawing
            If MapEditorCoordinates Then
                .RelativeToCam = True
            Else
                .RelativeToCam = False
            End If
            .AffectedByScrollSpeed = False
            For i = 0 To 7
                .DrawFilledBox(rHandles(i).X, rHandles(i).Y, rHandles(i).Width, rHandles(i).Height, Color.FromArgb(128, 128, 255), Color.FromArgb(128, 128, 255), Color.FromArgb(0, 0, 192), Color.FromArgb(0, 0, 192))
                .DrawBox(rHandles(i).X, rHandles(i).Y, rHandles(i).Width, rHandles(i).Height, Color.White)
            Next
        End With
    End Sub

    Sub Draw(ByVal g As Graphics)
        If Enabled = False Then Exit Sub
        Dim i As Integer
        With g
            Dim b As New SolidBrush(Color.Blue)
            Dim p As New Pen(Color.White)
            For i = 0 To 7
                .FillRectangle(b, New Rectangle(rHandles(i).X, rHandles(i).Y, rHandles(i).Width, rHandles(i).Height))
                .DrawRectangle(p, New Rectangle(rHandles(i).X, rHandles(i).Y, rHandles(i).Width, rHandles(i).Height))
            Next
            p.Dispose()
            b.Dispose()
        End With
    End Sub

    Sub Sync(ByRef CopyTo As Rectangle)
        CopyTo = R
    End Sub

    Sub Sync(ByRef x As Integer, ByRef y As Integer, ByRef w As Integer, ByRef h As Integer)
        x = R.X
        y = R.Y
        w = R.Width
        h = R.Height
    End Sub

    Sub Enable()
        Enabled = True
    End Sub

    Sub Disable()
        Enabled = False
    End Sub

    Sub SetPictureBox(ByVal pic As PictureBox)
        p = pic
    End Sub
End Class