Imports PlatformStudio
Imports PlatformStudio.psMap.psLayer

Namespace GamePlayer
    Public Module Util
        Function Collision(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal tptr As TilePtr) As Boolean
            Return Collision(x, y, w, h, tptr.GetTile, tptr.Rectangle)
        End Function

        Function Collision(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal tile As psMapTile, ByVal rect As Rectangle) As Boolean
            '1. Bounding-box collision
            If Game.Math.Collide_BoxBox(New Rectangle(x, y, w, h), rect) Then
                ''2. Boundary collision
                With tile.GetTile.Boundaries
                    If .Style = PlatformStudio.BoundaryType.Default Then
                        '- Default (pixel-perfect)
                        If Game.GameProperties.NoPixelPerfect OrElse Game.Math.Collide_BoxTexture(x - rect.X, y - rect.Y, w, h, tile.TileName, Game.tileset.tiles(tile.tile), tile.Frame) Then
                            Return True
                        End If
                    ElseIf .Style = PlatformStudio.BoundaryType.Rectangular Then
                        '- Rectangular (already true at this point)
                        Return True
                    ElseIf .Style = PlatformStudio.BoundaryType.OneCustom Then
                        '- One Custom (one set of shapes for all frames)
                        For i As Integer = 1 To UBound(.shapes(1))
                            If CollideWithShape(x, y, w, h, rect, .shapes(1)(i)) Then Return True
                        Next
                    ElseIf .Style = BoundaryType.Custom Then
                        '- Custom (unique set of shapes for each frame)
                        If tile.Frame >= .shapes.Length OrElse .shapes(tile.Frame) Is Nothing Then Return False
                        For i As Integer = 1 To UBound(.shapes(tile.Frame))
                            If CollideWithShape(x, y, w, h, rect, .shapes(tile.Frame)(i)) Then Return True
                        Next
                    End If
                End With
            End If
            Return False
        End Function

        Private Function CollideWithShape(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal r As Rectangle, ByVal s As psBoundaryShape) As Boolean
            Select Case s.s
                Case BoundaryShape.Rectangle
                    Return Game.Math.Collide_BoxBox(x, y, w, h, r.X + s.r.X, r.Y + s.r.Y, s.r.Width, s.r.Height)
                Case BoundaryShape.Circle
                    Return Collide_RectEllipse(New Rectangle(x, y, w, h), r)
                Case BoundaryShape.Triangle1
                    Return y + h > (r.Bottom - r.Top) / (r.Right - r.Left) * (x - r.X) + r.Y
                Case BoundaryShape.Triangle2
                    Return y + h > -(r.Bottom - r.Top) / (r.Right - r.Left) * (x + w - (r.X + r.Width)) + r.Y
                Case BoundaryShape.Triangle3
                    Return y < (r.Bottom - r.Top) / (r.Right - r.Left) * (x + w - r.X) + r.Y
                Case BoundaryShape.Triangle4
                    Return y < -(r.Bottom - r.Top) / (r.Right - r.Left) * (x - (r.X + r.Width)) + r.Y
            End Select
        End Function

        Private Function Collide_RectEllipse(ByVal rect As Rectangle, ByVal ellipse As Rectangle) As Boolean
            Dim tl As New Point(rect.X, rect.Y)
            Dim tr As New Point(rect.Right, rect.Y)
            Dim bl As New Point(rect.X, rect.Bottom)
            Dim br As New Point(rect.Right, rect.Bottom)

            Dim center As New Point(ellipse.X + ellipse.Width \ 2, ellipse.Y + ellipse.Height \ 2)
            Dim a As Double = ellipse.Width / 2
            Dim b As Double = ellipse.Height / 2

            If rect.IntersectsWith(ellipse) Then
                If bl.X >= center.X AndAlso bl.Y <= center.Y Then 'Quadrant I
                    Return ptInEllipse(bl, center, a, b)
                ElseIf br.X <= center.X AndAlso br.Y <= center.Y Then 'Quadrant II
                    Return ptInEllipse(br, center, a, b)
                ElseIf tr.X <= center.X AndAlso tr.Y >= center.Y Then 'Quadrant III
                    Return ptInEllipse(tr, center, a, b)
                ElseIf tl.X >= center.X AndAlso tl.Y >= center.Y Then 'Quadrant IV
                    Return ptInEllipse(tl, center, a, b)
                End If
                Return True
            Else
                Return False
            End If
        End Function

        'Fformula for ellipse:
        '
        ' (x-h)²   (x-h)²
        ' —————— + —————— = 1
        '   a²       b²
        '
        '...turns into...
        '
        ' (pt.x-center.x)²   (pt.y-center.y)²
        ' ———————————————— + ———————————————— <= 1
        '        a²                 b²       
        '
        'where: pt is the point to check,
        '       a is the x radius,
        '       b is the y radius,
        '       and center is the center of the ellipse
        '
        Private Function ptInEllipse(ByVal pt As Point, ByVal center As Point, ByVal a As Double, ByVal b As Double) As Boolean
            Return (pt.X - center.X) ^ 2 / a ^ 2 + (pt.Y - center.Y) ^ 2 / b ^ 2 <= 1
        End Function
    End Module
End Namespace