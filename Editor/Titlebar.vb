Public Class Titlebar
    Private ttb_Labels() As Label 'Titlebar labels
    Private ttb_Image(3) As Image 'Titlebar images
    Private ttb_G(3) As Graphics  'Title bar graphic pointers
    Private ttb_Active(3) As Boolean 'Titlebar active

    Public Sub New(ByVal Labels() As Label)
        'Initialize the label array
        ttb_Labels = Labels

        For i As Integer = 0 To Labels.Length - 1
            'Initialize the image array
            ttb_Image(i) = New Bitmap(ttb_Labels(i).Width, ttb_Labels(i).Height)

            'Initialize the graphics array
            ttb_G(i) = Graphics.FromImage(ttb_Image(i))

            'Set the image to the corresponding label
            ttb_Labels(i).Image = ttb_Image(i)

            'Make the titlebar inactive
            '(Active = True tells CreateTitlebar to update the image)
            ttb_Active(i) = True
            MakeInactive(ttb_Labels(i), i)
        Next
    End Sub

    'Resized a label
    Public Sub Resized()
        For i As Integer = 0 To ttb_Labels.Length - 1
            'Destroy old stuff
            ttb_G(i).Dispose()
            ttb_Image(i).Dispose()

            'Initialize the image array
            ttb_Image(i) = New Bitmap(ttb_Labels(i).Width, ttb_Labels(i).Height)

            'Initialize the graphics array
            ttb_G(i) = Graphics.FromImage(ttb_Image(i))

            'Set the new image to the label
            ttb_Labels(i).Image = ttb_Image(i)

            'Get ready for redraw
            ttb_Active(i) = Not ttb_Active(i)
        Next

        'Redraw
        UpdateTitlebars(True)
    End Sub

    'Make titlebar active
    Private Sub MakeActive(ByVal lbl As Label, ByVal ttbIndex As Integer)
        CreateTitlebar(lbl, ttbIndex, Color.FromKnownColor(KnownColor.ActiveCaption), True)
    End Sub

    'Make titlebar inactive
    Private Sub MakeInactive(ByVal lbl As Label, ByVal ttbIndex As Integer)
        CreateTitlebar(lbl, ttbIndex, Color.FromKnownColor(KnownColor.InactiveCaption), False)
    End Sub

    'Creates a new titlebar image
    Private Sub CreateTitlebar(ByVal lbl As Label, ByVal ttbIndex As Integer, ByVal color1 As Color, ByVal active As Boolean)
        'Do not update if it is not needed
        If ttb_Active(ttbIndex) = active Then Exit Sub

        'Create the drawing rectangle
        Dim rect As Rectangle = New Rectangle(0, 0, lbl.Width, lbl.Height)

        'Set up colors
        Dim color2 As Color
        color2 = Color.FromArgb(color1.R + (255 - color1.R) / 1.5, _
                                color1.G + (255 - color1.G) / 1.5, _
                                color1.B + (255 - color1.B) / 1.5)

        'Draw the gradient
        ttb_G(ttbIndex).FillRectangle( _
            New Drawing2D.LinearGradientBrush _
                (rect, _
                color1, _
                color2, _
                Drawing2D.LinearGradientMode.Horizontal), _
            rect)

        'Refresh the label
        lbl.Refresh()

        'Set the active state
        ttb_Active(ttbIndex) = active
    End Sub

    'Update all the titlebars' states and draw them
    Public Sub UpdateTitlebars(ByVal active As Boolean)

        'Loop through all titlebars
        For i As Integer = 0 To UBound(ttb_Labels)

            'If the titlebar is allowed to be in the active state
            If active And ttb_Labels(i).Enabled Then

                'Store the mouse position in relation to the label
                Dim pnt As Point
                pnt = ttb_Labels(i).Parent.PointToClient(Control.MousePosition)

                'If the mouse is inside the label, make it active.
                'Otherwise, make it inactive.
                If Game.Math.Collide_PtBox(pnt.X, pnt.Y, 0, 0, ttb_Labels(i).Parent.Width, ttb_Labels(i).Parent.Height) Then
                    MakeActive(ttb_Labels(i), i)
                Else
                    MakeInactive(ttb_Labels(i), i)
                End If

            Else

                'Titlebar cannot be in an active state,
                'so make it inactive.
                MakeInactive(ttb_Labels(i), i)

            End If
        Next
    End Sub

End Class