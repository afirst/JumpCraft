#Region "Data Structures"
<Serializable()> _
Public Structure psPath
    <Serializable()> _
    Public Structure psPathPoint
        Dim XPoint() As Integer
        Dim YPoint() As Integer
        Dim Length As Single

        Sub Init()
            ReDim XPoint(3), YPoint(3)
        End Sub

        Function Clone() As psPathPoint
            Dim tmpPt As psPathPoint
            With tmpPt
                .Init()
                If XPoint Is Nothing Then Return Nothing
                .XPoint = XPoint.Clone
                .YPoint = YPoint.Clone
                .Length = Length
            End With
            Return tmpPt
        End Function
    End Structure

    Dim Pts() As psPathPoint
    Dim Speed As Single
    Dim Enclosed As Boolean
    Dim _start As Single
    <NonSerialized()> Private _dstart As Double
    Dim Exists As Boolean

    Property Start() As Double
        Get
            Return _dstart
        End Get
        Set(ByVal Value As Double)
            _dstart = Value
        End Set
    End Property

    Sub Init()
        ReDim Pts(0)
        Speed = 3
        Exists = False
    End Sub

    Sub AddPoint()
        ReDim Preserve Pts(Pts.GetUpperBound(0) + 1)
        Pts(Pts.GetUpperBound(0)).Init()
    End Sub

    Function Clone() As psPath
        Dim tmpPath As psPath, i As Integer
        With tmpPath
            .Exists = Exists
            .Enclosed = Enclosed
            .Start = Start
            .Speed = Speed
            If Exists = False Then
                .Pts = Nothing
            Else
                ReDim .Pts(UBound(Pts))
                For i = 0 To UBound(.Pts)
                    .Pts(i) = Pts(i).Clone
                Next
            End If
        End With
        Return tmpPath
    End Function
End Structure
#End Region

#Region "Helper Module"
Public Class PathHelper
    Public Shared Sub DrawSingleBezier(ByVal Pts() As psPath.psPathPoint, ByVal Enclose As Boolean, ByVal Index As Integer, ByVal LastPt As Boolean, ByVal Precision As Double, ByVal ShowGuides As Boolean, ByVal ShowPoints As Boolean, ByVal PathColor As Color)
        Dim ax, bx, cX, ay, by, cY, t As Double

        Game.Drawing.RelativeToCam = True

        Dim XPoint(3) As Integer
        Dim YPoint(3) As Integer
        Dim Linear As Boolean
        XPoint(0) = Pts(Index).XPoint(0)
        YPoint(0) = Pts(Index).YPoint(0)
        XPoint(1) = Pts(Index).XPoint(1)
        YPoint(1) = Pts(Index).YPoint(1)
        XPoint(2) = Pts(Index).XPoint(2)
        YPoint(2) = Pts(Index).YPoint(2)
        XPoint(3) = Pts(Index).XPoint(3)
        YPoint(3) = Pts(Index).YPoint(3)
        If Enclose And LastPt Then
            LastPt = False
            XPoint(2) = Pts(0).XPoint(0) * 2 - Pts(0).XPoint(1)
            YPoint(2) = Pts(0).YPoint(0) * 2 - Pts(0).YPoint(1)
            XPoint(3) = Pts(0).XPoint(0)
            YPoint(3) = Pts(0).YPoint(0)
        End If
        If XPoint(0) = XPoint(1) And YPoint(0) = YPoint(1) And XPoint(3) = XPoint(2) And YPoint(3) = YPoint(2) Then Linear = True

        'Pic.DrawWidth = 1
        Dim X() As Integer, Y() As Integer, Colors() As Color
        ReDim X(0), Y(0), Colors(0)
        If ShowGuides Then
            'Draw control lines
            ReDim Preserve X(UBound(X) + 2), Y(UBound(Y) + 2), Colors(UBound(Colors) + 2)
            X(UBound(X) - 1) = XPoint(1)
            Y(UBound(Y) - 1) = YPoint(1)
            Colors(UBound(Colors) - 1) = Color.FromArgb(128, 0, 0, 255)
            X(UBound(X)) = XPoint(0)
            Y(UBound(Y)) = YPoint(0)
            Colors(UBound(Colors)) = Color.FromArgb(128, 0, 0, 255)
            If LastPt = False Then
                ReDim Preserve X(UBound(X) + 2), Y(UBound(Y) + 2), Colors(UBound(Colors) + 2)
                X(UBound(X) - 1) = XPoint(2)
                Y(UBound(Y) - 1) = YPoint(2)
                Colors(UBound(Colors) - 1) = Color.FromArgb(128, 0, 0, 255)
                X(UBound(X)) = XPoint(3)
                Y(UBound(Y)) = YPoint(3)
                Colors(UBound(Colors)) = Color.FromArgb(128, 0, 0, 255)
            End If
            Game.Drawing.DrawLineList(X, Y, Colors)
            ReDim X(0), Y(0), Colors(0)
        End If

        cX = 3 * (XPoint(1) - XPoint(0))
        bx = 3 * (XPoint(2) - XPoint(1)) - cX
        ax = XPoint(3) - XPoint(0) - cX - bx

        cY = 3 * (YPoint(1) - YPoint(0))
        by = 3 * (YPoint(2) - YPoint(1)) - cY
        ay = YPoint(3) - YPoint(0) - cY - by

        If Linear Then
            If LastPt = False Then
                ReDim X(2), Y(2)
                X(1) = XPoint(0) : Y(1) = YPoint(0)
                X(2) = XPoint(3) : Y(2) = YPoint(3)
                Game.Drawing.DrawLineStrip(X, Y, PathColor)
            End If
        Else
            ReDim X(1 / Precision + 3), Y(UBound(X))
            Dim c As Long
            X(1) = XPoint(0) : Y(1) = YPoint(0)
            If LastPt = False Then
                c = 1
                For t = 0 To 1 Step IIf(Linear, 1, Precision)
                    c = c + 1
                    X(c) = ax * t ^ 3 + bx * t ^ 2 + cX * t + XPoint(0)
                    Y(c) = ay * t ^ 3 + by * t ^ 2 + cY * t + YPoint(0)
                Next
                X(UBound(X)) = XPoint(3)
                Y(UBound(Y)) = YPoint(3)
                Game.Drawing.DrawLineStrip(X, Y, PathColor)
            End If
        End If

        If ShowPoints Then
            'Points
            Game.Drawing.DrawFilledBox(XPoint(0) - 2, YPoint(0) - 2, 4, 4, Color.Yellow)
            If LastPt = False Then Game.Drawing.DrawFilledBox(XPoint(3) - 2, YPoint(3) - 2, 4, 4, Color.Yellow)

            'Guide points
            Game.Drawing.DrawFilledBox(XPoint(1) - 1, YPoint(1) - 1, 2, 2, Color.Green)
            If LastPt = False Then Game.Drawing.DrawFilledBox(XPoint(2) - 1, YPoint(2) - 1, 2, 2, Color.Green)
        End If
    End Sub

    Public Shared Sub Path_GetPosOnPoint(ByVal Pt As psPath.psPathPoint, ByVal Pt0 As psPath.psPathPoint, ByVal LastPt As Boolean, ByVal Enclose As Boolean, ByVal t As Single, ByVal Index As Integer, ByRef xt As Single, ByRef yt As Single)
        'Get points
        Dim XPoint() As Integer, YPoint() As Integer
        XPoint = Pt.XPoint
        YPoint = Pt.YPoint
        If Enclose And LastPt Then
            XPoint(2) = Pt0.XPoint(0) * 2 - Pt0.XPoint(1)
            YPoint(2) = Pt0.YPoint(0) * 2 - Pt0.YPoint(1)
            XPoint(3) = Pt0.XPoint(0)
            YPoint(3) = Pt0.YPoint(0)
        End If

        'Get parametric equation
        Dim ax, bx, cX, ay, by, cY As Double
        cX = 3 * (XPoint(1) - XPoint(0))
        bx = 3 * (XPoint(2) - XPoint(1)) - cX
        ax = XPoint(3) - XPoint(0) - cX - bx
        cY = 3 * (YPoint(1) - YPoint(0))
        by = 3 * (YPoint(2) - YPoint(1)) - cY
        ay = YPoint(3) - YPoint(0) - cY - by

        ''Solve equation
        'Dim q As Double = 0.001
        'Dim partialLength As Double
        'Dim iValue As Double

        'Dim totalLength As Double
        'For i As Double = 0 To 1 - q Step q
        '    totalLength += Game.Math.Dist(ax * i ^ 3 + bx * i ^ 2 + cX * i + XPoint(0), ay * i ^ 3 + by * i ^ 2 + cY * i + YPoint(0), ax * (i + q) ^ 3 + bx * (i + q) ^ 2 + cX * (i + q) + XPoint(0), ay * (i + q) ^ 3 + by * (i + q) ^ 2 + cY * (i + q) + YPoint(0))
        'Next

        'For i As Double = 0 To 1 - q Step q
        '    partialLength += Game.Math.Dist(ax * i ^ 3 + bx * i ^ 2 + cX * i + XPoint(0), ay * i ^ 3 + by * i ^ 2 + cY * i + YPoint(0), ax * (i + q) ^ 3 + bx * (i + q) ^ 2 + cX * (i + q) + XPoint(0), ay * (i + q) ^ 3 + by * (i + q) ^ 2 + cY * (i + q) + YPoint(0))
        '    iValue = i
        '    If (partialLength / totalLength >= t) Then
        '        Exit For
        '    End If
        'Next

        't = iValue

        xt = ax * t ^ 3 + bx * t ^ 2 + cX * t + XPoint(0)
        yt = ay * t ^ 3 + by * t ^ 2 + cY * t + YPoint(0)





        'Linearization
        'xt = (3 * ax * 0.5 ^ 2 + 2 * bx * 0.5 + cX) * (t - 0.5) + ax * 0.5 ^ 3 + bx * 0.5 ^ 2 + cX * 0.5 + XPoint(0)
        'yt = (3 * ay * 0.5 ^ 2 + 2 * by * 0.5 + cY) * (t - 0.5) + ay * 0.5 ^ 3 + by * 0.5 ^ 2 + cY * 0.5 + YPoint(0)

        'Logarithmic
        'xt = ax * t ^ 3 + bx * t ^ 2 + cX * t + XPoint(0)
        'yt = ay * t ^ 3 + by * t ^ 2 + cY * t + YPoint(0)

        'Time changer
        'Split segment up into many small pieces
        'Find the length of each piece
        'Divide each length by the total length to find the proportion of
        'time to be sepnt on that part
        'Let's say that it is divided into 10 parts
        'For t=0 to .1, t is scaled to be between 0 and the proportion of
        'the first part
        'For t=.1 to .2, t is scaled tob e between the proportion of the
        'first part and that plus the proportion of the second part

    End Sub

    Public Shared Function Path_GetPos(ByVal Path As psPath, ByVal pTime As Single, ByRef xt As Single, ByRef yt As Single, Optional ByRef OneWay As Boolean = False, Optional ByRef OneWayFinished As Boolean = False, Optional ByRef StayThere As Boolean = False) As Boolean
        'If there are no points on the path, don't go through all this work
        If Path.Pts.GetUpperBound(0) = 0 Then
            xt = Path.Pts(0).XPoint(0)
            yt = Path.Pts(0).YPoint(0)
            Return False
        End If

        'Variables
        Dim PlayLength As Single
        Dim t As Single, tot As Single, curL As Single, sum As Single
        Dim atPt As Integer

        'Calculate the length of the path
        'and the amount of time it takes to go through it
        PlayLength = Path.Speed
        If PlayLength = 0 Then PlayLength = 0.0001
        tot = Path_TotalLength(Path.Pts, Path.Enclosed)

        'Get time between 0 and 1
        t = pTime / PlayLength
        If t < 0 Then t = 0
        If t > 1 Then t = 1

        If Path.Pts(1).Length < 0 Then 'Path has been activated by code;
            OneWay = True              'only go one way
            If t > 0.5 Then
                t = 0.5
                OneWayFinished = True
            End If
            If Path.Pts(1).Length = -2 Then
                StayThere = True
                If t = 0.5 Then Path.Pts(1).Length = -3
            ElseIf Path.Pts(1).Length = -3 Then
                StayThere = True
                t = 0.5
            End If
        End If

        'If the path is not enclosed, then go backwards when it is at the end
        If Path.Enclosed = False And t > 0.5 Then t = 1 - t

        'Calculate the current point
        curL = t * tot
        sum = 0
        For atPt = 0 To UBound(Path.Pts)
            If curL <= Path.Pts(atPt).Length + sum Then Exit For
            sum = sum + Path.Pts(atPt).Length
        Next
        If atPt > UBound(Path.Pts) Then Return False
        If Path.Pts(atPt).Length = 0 Then Return False

        'Calculate the position on the current point
        Path_GetPosOnPoint(Path.Pts(atPt), Path.Pts(0), (atPt = UBound(Path.Pts)), Path.Enclosed, (curL - sum) / Path.Pts(atPt).Length, atPt, xt, yt)

        'Successful!
        Return True
    End Function

    Public Shared Function Path_TotalLength(ByVal Pts_() As psPath.psPathPoint, ByVal Enclosed As Boolean) As Single
        Dim res As Single
        Dim i As Integer
        For i = 0 To UBound(Pts_)
            res += Pts_(i).Length
        Next
        Return (res - IIf(Not Enclosed, Pts_(UBound(Pts_)).Length, 0)) * IIf(Not Enclosed, 2, 1)
    End Function
End Class
#End Region