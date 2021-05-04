Public Class psTileCombo
    Inherits System.Windows.Forms.ComboBox

    Const imgSize As Integer = 12

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Add any initialization after the InitializeComponent() call
        Me.DrawMode = DrawMode.OwnerDrawFixed
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.MaxDropDownItems = 12
        Me.ItemHeight = imgSize
    End Sub

    Overloads Sub Refresh()
        If Game Is Nothing Then Exit Sub
        With Me
            Dim tmpSel As Integer
            tmpSel = SelectedIndex
            Items.Clear()
            For i As Integer = 1 To Game.tileset.NumTiles
                .Items.Add(Game.tileset.tiles(i).name)
                cboIconValue_MeasureItem(Nothing, New MeasureItemEventArgs(Me.CreateGraphics, i - 1))
            Next
            Try
                SelectedIndex = tmpSel
            Catch
            End Try
        End With
    End Sub
#End Region

    Private Sub cboIconValue_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MyBase.MeasureItem
        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable and it always fires before the DrawItem event.

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return

        ''The string that will appear in the current item and that I will use to measure when determining the height and width variable.
        'Dim str As String = Me.Items(e.Index)
        ''The string stripped of the newline character
        'Dim strOneLine As String = Join(Split(str, Environment.NewLine), "")

        ''for the item height, use the maximum of the image height or the string height and add 10%.
        'Dim hgt As Single = Math.Max(imgSize, e.Graphics.MeasureString(str, Me.Font).Height) * 1.1
        'e.ItemHeight = hgt

        ''if I'm using dropdownstyle = dropdownlist, I want the text area at the top of the combobox to be tall enough for the image and text together, so I set the combo box itemheight property to the hgt value. When I use Simple or DropDown with OwnerDrawVariable, I want the text area at the top of the combobox to shrink back to a height that accommodates one line of text.
        'If Me.DropDownStyle = ComboBoxStyle.DropDownList Then
        '    Me.ItemHeight = hgt
        'Else
        '    Me.ItemHeight = e.Graphics.MeasureString(strOneLine, Me.Font).Height * 1.1
        'End If

        'in our example, the width of the combo box item does not need to be calculated because the width of the combo box is suuficient for all of the items we're working with
        e.ItemWidth = Me.Width + imgSize
    End Sub

    Private Sub cboIconValue_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
        If Enabled = False Then Exit Sub

        'NOTE: This event fires only when the draw mode is set to OwnerDrawVariable or OwnerDrawFixed

        'don't do anything unless the index is greater than -1 
        If e.Index < 0 Then Return
        'a string variable to hold the text that I will draw
        Dim str As String = Me.Items(e.Index)
        ' a graphic variable to minimize my typing :)
        Dim g As Graphics = e.Graphics
        'a couple of brush objects I'll need for filling rectangles
        Dim bBlue As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Highlight))
        Dim bWhite As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Window))
        Dim bBlack As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.WindowText))

        'Adjust the value of Combobox.itemheight if the drawmode is ownerdrawfixed because the Measureitem event won't fire for that mode! This is necessary because the drawmode in this sample can be changed at runtime.
        Dim hgt As Single
        Dim img As Image = Game.tileset.tilePreview(e.Index + 1)
        If Me.DrawMode = DrawMode.OwnerDrawFixed Then
            hgt = Math.Max(imgSize, e.Graphics.MeasureString(str, Me.Font).Height) * 1.1
            Me.ItemHeight = hgt
        End If

        'Determine if I'm highlighting the current combo box item because 
        'I want the selected item to look different from those that are not selected.
        Dim bHighlightItem As Boolean = Me.ShouldIHighlight(e.State)

        Dim myImage As Image = Game.tileset.tilePreview(e.Index + 1)
        If bHighlightItem = True Then
            'Fill background
            g.FillRectangle(bBlue, e.Bounds)

            'Draw image, offset it by 5 pixels and makes sure it's centered vertically
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - imgSize) \ 2, imgSize, imgSize)

            'Draw text and position it so that it starts 5 pixels to the right of the image
            g.DrawString(str, Me.Font, bWhite, e.Bounds.Left + imgSize + 5, e.Bounds.Top)
        Else
            'This block does the same thing as above but
            'uses different colors to represent the different state.
            g.FillRectangle(bWhite, e.Bounds)
            g.DrawImage(myImage, 5, e.Bounds.Top + (e.Bounds.Height - imgSize) \ 2, imgSize, imgSize)
            g.DrawString(str, Me.Font, bBlack, e.Bounds.Left + imgSize + 5, e.Bounds.Top)
        End If
        'Dispose of my brushes
        bBlue.Dispose()
        bWhite.Dispose()
        bBlue = Nothing
        bWhite = Nothing
    End Sub

    Private Function ShouldIHighlight(ByVal State As DrawItemState) As Boolean
        Return (State And DrawItemState.Selected) OrElse _
               (State And DrawItemState.HotLight)
    End Function
End Class
