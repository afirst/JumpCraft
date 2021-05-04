Public Class psDrawing

    'Image pool
    Public Shared img() As psImage

    'Primary buffer
    'Private b1 As Bitmap, gfx As Graphics
    Private p As PictureBox

    ''Backbuffer
    'Private x As New PictureBox(), xb1 As Bitmap, xg1 As Graphics

    Private xg1 As Graphics
    Private oImage As Bitmap 'New image with width of 500, height of 500.

    Sub New(ByRef pic As PictureBox)
        p = pic
        init()
    End Sub

    Sub Resize()
        'b1.Dispose()
        'gfx.Dispose()
        'xb1.Dispose()
        oImage = New Bitmap(p.Width, p.Height)
        xg1.Dispose()
        init()
    End Sub

    Private Sub init()
        Dim tw As Integer, th As Integer
        tw = IIf(p.Width < 32, 32, p.Width)
        th = IIf(p.Height < 32, 32, p.Height)

        ''Init primary buffer
        'b1 = New Bitmap(tw, th, p.CreateGraphics())
        'gfx = Graphics.FromImage(b1)

        ''Init backbuffer
        'x.Size = p.Size
        'xb1 = New Bitmap(tw, th, x.CreateGraphics())
        'xg1 = Graphics.FromImage(xb1)

        oImage = New Bitmap(tw, th)
        xg1 = Graphics.FromImage(oImage)
        p.Image = oImage

    End Sub

    '#Region "AutoRedraw"
    '    Private Sub p_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles p.Paint
    '        'e.Graphics.DrawImage(b1, 0, 0)
    '    End Sub
    '#End Region

#Region "Images"
    Structure psImage
        Dim bmp As Bitmap
        Dim width As Integer, height As Integer
        Dim key As String
        Dim colorkey As Integer
        Dim sectionw As Integer, sectionh As Integer
    End Structure

    Public RelativeToCam As Boolean
    Public AffectedByScrollSpeed As Boolean

    Sub UnloadImage(ByVal index As Integer)
        If index < 1 Then Exit Sub
        Dim i As Integer
        For i = index To UBound(img) - 1
            img(i) = img(i + 1)
        Next
        ReDim Preserve img(UBound(img) - 1)
    End Sub

    Sub LoadImage(ByVal Filename As String, ByVal Key As String, Optional ByVal SectionW As Integer = 0, Optional ByVal SectionH As Integer = 0)
        LoadImage(Filename, 0, 0, 0, Key, SectionW, SectionH)
    End Sub

    Sub LoadImage(ByVal Filename As String, ByVal Width As Integer, ByVal Height As Integer, ByVal ColorKey As Integer, ByVal Key As String, Optional ByVal SectionW As Integer = 0, Optional ByVal SectionH As Integer = 0)
        If img Is Nothing Then ReDim img(0)

        ReDim Preserve img(UBound(img) + 1)
        img(UBound(img)) = New psImage()
        img(UBound(img)).bmp = New Bitmap(Filename)

        Dim bmpw As Integer, bmph As Integer
        bmpw = img(UBound(img)).bmp.Width
        bmph = img(UBound(img)).bmp.Height

        If SectionW = 0 Then SectionW = bmpw
        If SectionH = 0 Then SectionH = bmph
        If bmpw / SectionW <> bmpw \ SectionW Then SectionW = bmpw
        If bmph / SectionH <> bmph \ SectionH Then SectionH = bmph

        img(UBound(img)).sectionw = SectionW
        img(UBound(img)).sectionh = SectionH

        If Width > 0 Then
            img(UBound(img)).width = Width
            img(UBound(img)).height = Height
        Else
            img(UBound(img)).width = img(UBound(img)).bmp.Width
            img(UBound(img)).height = img(UBound(img)).bmp.Height
        End If
        img(UBound(img)).colorkey = ColorKey
        img(UBound(img)).key = Key
    End Sub

    Property imgWidth(ByVal index As Integer)
        Get
            Return img(index).width
        End Get
        Set(ByVal Value)
            img(index).width = Value
        End Set
    End Property

    Property imgHeight(ByVal index As Integer)
        Get
            Return img(index).height
        End Get
        Set(ByVal Value)
            img(index).height = Value
        End Set
    End Property

    Property imgColorKey(ByVal index As Integer)
        Get
            Return img(index).colorkey
        End Get
        Set(ByVal Value)
            img(index).bmp.MakeTransparent(Color.FromArgb(Value))
            img(index).colorkey = Value
        End Set
    End Property

    WriteOnly Property imgFilename(ByVal index As Integer)
        Set(ByVal Value)
            img(index).bmp.FromFile(Value)
        End Set
    End Property

    Property imgKey(ByVal index As Integer)
        Get
            Return img(index).key
        End Get
        Set(ByVal Value)
            img(index).key = Value
        End Set
    End Property

    ReadOnly Property imgCount()
        Get
            If img Is Nothing Then Return 0
            Return UBound(img)
        End Get
    End Property
#End Region

#Region "Drawing"
    Sub DrawImage(ByVal index As Integer, ByVal x As Integer, ByVal y As Integer, Optional ByVal width As Integer = 0, Optional ByVal height As Integer = 0, Optional ByVal sectionx As Integer = 1, Optional ByVal sectiony As Integer = 1)
        If index < 1 Then Exit Sub
        If index > UBound(img) Then Exit Sub
        If RelativeToCam Then
            x -= psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            y -= psGame.cam.y
        End If
        sectionx -= 1
        sectiony -= 1
        If width = 0 Then width = img(index).width
        If height = 0 Then height = img(index).height
        xg1.DrawImage(img(index).bmp, New RectangleF(x, y, width, height), New RectangleF(sectionx * img(index).sectionw, sectiony * img(index).sectionh, img(index).sectionw, img(index).sectionh), GraphicsUnit.Pixel)
    End Sub

    ReadOnly Property imgIndex(ByVal key As String) As Integer
        Get
            If img Is Nothing Then Return -1
            Dim i As Integer
            For i = 1 To UBound(img)
                If img(i).key = key Then
                    Exit For
                End If
            Next
            Return i
        End Get
    End Property

    Sub DrawBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color As System.Drawing.Color)
        If RelativeToCam Then
            x = x - psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            y = y - psGame.cam.y
        End If
        xg1.DrawRectangle(New Pen(Color), x, y, w, h)
    End Sub

    Sub DrawFilledBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color As System.Drawing.Color)
        If RelativeToCam Then
            x = x - psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            y = y - psGame.cam.y
        End If
        xg1.FillRectangle(New Pen(Color).Brush, x, y, w, h)
    End Sub

    Sub DrawFilledBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As System.Drawing.Color, ByVal Color2 As System.Drawing.Color, ByVal Mode As System.Drawing.Drawing2D.LinearGradientMode)
        If RelativeToCam Then
            x = x - psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            y = y - psGame.cam.y
        End If
        Dim b As New Drawing2D.LinearGradientBrush( _
                 New Rectangle(x, y, w, h), Color1, Color2, Mode)
        xg1.FillRectangle(b, x, y, w, h)
    End Sub

    Sub DrawLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal Color As System.Drawing.Color)
        If RelativeToCam Then
            x1 = x1 - psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            x2 = x2 - psGame.cam.x * IIf(AffectedByScrollSpeed, psGame.ScrollSpeed, 1)
            y1 = y1 - psGame.cam.y
            y2 = y2 - psGame.cam.y
        End If
        xg1.DrawLine(New Pen(Color), x1, y1, x2, y2)
    End Sub

    Sub DrawText(ByVal text As String, ByVal x As Integer, ByVal y As Integer, ByVal color As Color)
        xg1.DrawString(text, New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), New Pen(color).Brush, x, y)
    End Sub

    Sub DrawText(ByVal text As String, ByVal x As Integer, ByVal y As Integer, ByVal color As Color, ByVal FontFamily As FontFamily, Optional ByVal FontSize As Single = 8, Optional ByVal FontStyle As FontStyle = FontStyle.Regular)
        xg1.DrawString(text, New Font(FontFamily, FontSize, FontStyle), New Pen(color).Brush, x, y)
    End Sub

    Sub Clear()
        xg1.Clear(Color.Black)
    End Sub

    Sub Refresh()
        'gfx = xg1
        'gfx.DrawImage(xb1, 0, 0)
        'p.CreateGraphics.DrawImage(b1, 0, 0)
        p.Refresh()
    End Sub

    ReadOnly Property Advanced() As Graphics
        Get
            Return xg1
        End Get
    End Property
#End Region
End Class

'---------

#Region "AutoRedraw"
Class psAutoRedraw
    'Bitmap holds picture of the form
    Private b1 As Bitmap
    'Graphics object (printing buffer)
    Public Graphics As Graphics
    Dim WithEvents p As PictureBox

    Sub EnableAutoRedraw(ByRef pic As PictureBox)
        p = pic

        'AUTOREDRAW INITIALIZATION
        'Create the initial bitmap from Form
        b1 = New Bitmap(p.Width, p.Height, p.CreateGraphics())

        'Create the Graphics Object buffer
        ' which ties the bitmap to it so that
        ' when you draw something on the object
        ' the bitmap is updated
        Graphics = Graphics.FromImage(b1)
    End Sub

    Private Sub p_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles p.Paint
        e.Graphics.DrawImage(b1, 0, 0)
    End Sub

    Sub Refresh()
        p.CreateGraphics.DrawImage(b1, 0, 0)
    End Sub
End Class
#End Region