Imports System
Imports System.Drawing
Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

Public Class psDraw
    Inherits MarshalByRefObject

#Region "Declarations"
    Public device As Device = Nothing ' Our rendering device

    Private start As Single, frames As Integer
    Public fps As Integer

    Private sprite As Direct3D.Sprite
#End Region

#Region "Init DirectX 9"
    'Private WorkingDevType, WorkingFormat, WorkingVProc As Integer

    Public Function Init(ByVal Handle As Control, Optional ByVal Windowed As Boolean = True, Optional ByVal FullscreenW As Integer = 640, Optional ByVal FullscreenH As Integer = 480) As Boolean
        If Not createDevice(Handle, Windowed, FullscreenW, FullscreenH) Then
            MessageBox.Show(GetString("error_DirectX"), GetString("error_"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        'Init texture and font pools
        Tex = New TexPool
        Fonts = New FontPool
        ReDim dbuffer1(0)
        ReDim dbuffer2(0)

        newDevice()

        Return True
    End Function

    Private Function createDevice(ByVal Handle As Control, ByVal Windowed As Boolean, ByVal FullscreenW As Integer, ByVal FullscreenH As Integer) As Boolean
        Try
            'Set up presentation parameters
            Dim presentParams As New PresentParameters
            presentParams.Windowed = Windowed
            If Windowed = False Then
                presentParams.BackBufferWidth = FullscreenW ' Game.GameProperties.ResWidth
                presentParams.BackBufferHeight = FullscreenH ' Game.GameProperties.ResHeight
                presentParams.BackBufferFormat = Format.X8R8G8B8
            End If
            presentParams.BackBufferFormat = Format.X8R8G8B8
            presentParams.SwapEffect = SwapEffect.Discard
            presentParams.PresentationInterval = PresentInterval.Immediate
            presentParams.PresentFlag = PresentFlag.LockableBackBuffer

            'Create device
            Dim DevTypes() As Direct3D.DeviceType = {DeviceType.Hardware, DeviceType.Software, DeviceType.Reference}
            Dim Formats() As Direct3D.Format = {Format.X8R8G8B8, Format.R8G8B8, Format.R5G6B5, Format.X1R5G5B5}
            Dim VProc() As Direct3D.CreateFlags = {CreateFlags.PureDevice, CreateFlags.HardwareVertexProcessing, CreateFlags.MixedVertexProcessing, CreateFlags.SoftwareVertexProcessing}
            For i As Integer = 0 To DevTypes.Length - 1
                For j As Integer = 0 To Formats.Length - 1
                    For k As Integer = 0 To VProc.Length - 1
                        Try                            
                            presentParams.BackBufferFormat = Formats(j)
                            device = New Device(0, DevTypes(i), Handle, VProc(k), presentParams)
                            If Not device Is Nothing Then
                                'WorkingDevType = i
                                'WorkingFormat = j
                                'WorkingVProc = k
                                GoTo CreatedDevice
                            End If
                        Catch
                        End Try
                    Next
                Next
            Next
            Return False
CreatedDevice:

            'Try 'first try 32 bit color
            '    device = New Device(0, DeviceType.Hardware, Handle, CreateFlags.SoftwareVertexProcessing, presentParams)
            '    If device Is Nothing Then Throw New Exception("Invalid device.")
            'Catch
            '    Try 'then try 24 bit color
            '        presentParams.BackBufferFormat = Format.R8G8B8
            '        device = New Device(0, DeviceType.Hardware, Handle, CreateFlags.SoftwareVertexProcessing, presentParams)
            '        If device Is Nothing Then Throw New Exception("Invalid device.")
            '    Catch
            '        Try 'then try 16 bit color
            '            presentParams.BackBufferFormat = Format.R5G6B5
            '            device = New Device(0, DeviceType.Hardware, Handle, CreateFlags.SoftwareVertexProcessing, presentParams)
            '            If device Is Nothing Then Throw New Exception("Invalid device.")
            '        Catch 'then try "15" bit color
            '            presentParams.BackBufferFormat = Format.X1R5G5B5
            '            device = New Device(0, DeviceType.Hardware, Handle, CreateFlags.SoftwareVertexProcessing, presentParams)
            '        End Try
            '    End Try
            'End Try

            Try
                If Windowed = False Then device.SetDialogBoxesEnabled(True)
            Catch
                MessageBox.Show(GetString("error_FullscreenDialog"), GetString("error_"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

            'When the device resets/resizes, go to OnResetDevice
            AddHandler device.DeviceResizing, AddressOf Me.OnResizeDevice
            AddHandler device.DeviceReset, AddressOf Me.OnResetDevice

            Return True
        Catch e As DirectXException
            MessageBox.Show(e.Message & vbCrLf & vbCrLf & GetString("error_DirectXInit"), GetString("error_"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function Re_Init(ByVal Handle As Control) As Boolean
        If Not createDevice(Handle, (Game.InEditor = True Or Game.GameProperties.Windowed), Game.GameProperties.ResWidth, Game.GameProperties.ResHeight) Then Return False

        newDevice()
        OnResetDevice(Nothing, Nothing)

        Return True
    End Function

    ReadOnly Property InvalidDevice() As Boolean
        Get
            Return (device Is Nothing Or Game.p.Width = 0)
        End Get
    End Property

    Friend Sub OnResizeDevice(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Game.p.Width = 0 Then e.Cancel = True
    End Sub

    Friend Sub OnResetDevice(ByVal sender As Object, ByVal e As System.EventArgs)
        If InvalidDevice Then Exit Sub

        'Reload textures
        Dim t As TexPool.TexPoolItem
        Dim CopyList() As Integer
        ReDim CopyList(Tex.Count - 1)
        For i As Integer = 0 To Tex.Count - 1
            For j As Integer = 0 To i - 1
                If Tex.GetByIndex(i).Texture Is Tex.GetByIndex(j).Texture Then
                    CopyList(i) = j + 1
                    Exit For
                End If
            Next
        Next
        For i As Integer = 0 To Tex.Count - 1
            Try
                'For j As Integer = 0 To i - 1
                'If Tex.GetByIndex(i).Texture Is Tex.GetByIndex(j).Texture Then
                'CopyList(i) = j + 1
                'Tex.GetByIndex(i).Texture = Tex.GetByIndex(j).Texture
                'Exit Try
                'End If
                'Next
                If CopyList(i) = 0 Then
                    t = Tex.GetByIndex(i)
                    Tex.GetByIndex(i).Texture = TextureLoader.FromFile(device, t.filename, t.width, t.height, 1, Usage.SoftwareProcessing, Format.Unknown, Pool.Default, Filter.Triangle, Filter.Triangle, t.ColorKey.ToArgb)
                End If
                't.Texture = New Texture(device, t.width, t.height, 0, Usage.SoftwareProcessing, Format.A8R8G8B8, Pool.Default)
                't.Texture = Texture.FromBitmap(device, t.bmp, Usage.SoftwareProcessing, Pool.Default)
            Catch
            End Try
        Next
        For i As Integer = 0 To Tex.Count - 1
            If CopyList(i) > 0 Then
                Tex.GetByIndex(i).Texture = Tex.GetByIndex(CopyList(i) - 1).Texture
            End If
        Next

        'Reload fonts
        Dim f As FontPool.FontPoolItem
        For Each f In Fonts.Values
            f.dxFont = New Direct3D.Font(device, f.Font)
        Next

        'Set up device and other device-dependent objects
        newDevice()

        'Reset movie
        Try
            If Not (Game.video Is Nothing) AndAlso Game.video.Playing Then
                Game.video.RenderToTexture(Game.Drawing.device)
            End If
        Catch
        End Try
    End Sub

    Private Sub newDevice()
        'Render states
        device.RenderState.SourceBlend = Blend.SourceAlpha
        device.RenderState.DestinationBlend = Blend.InvSourceAlpha
        device.RenderState.AlphaBlendEnable = True

        'Create the sprite object
        sprite = New Sprite(device)
        drawingSprite = False

        'Create the default font
        Dim tmpFont As New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 10)
        DefaultFont = New Direct3D.Font(device, tmpFont)

        Rendered = True
    End Sub

    Sub SetDialogBoxesEnabled(ByVal value As Boolean)
        device.SetDialogBoxesEnabled(value)
    End Sub

    Sub SetDeviceEqualsNothing()
        device = Nothing
    End Sub
#End Region

#Region "Images"

#Region "Data Structure"
    Public Class TexPool
        Inherits SortedList

        Class TexPoolItem
            Public bmp As System.Drawing.Bitmap
            Public preview As System.Drawing.Bitmap
            Public Texture As Texture
            Public Key As String
            Public filename As String
            Public ColorKey As Color
            Public width As Integer, height As Integer
            Public sectionw As Integer, sectionh As Integer
            Public Bits(,,) As Byte

            Sub ReloadTexture()
                Try
                    Game.Drawing.img_Add(filename, Key, ColorKey, width, height, sectionw, sectionh, True)
                Catch 'file might currently be used by another process
                End Try
            End Sub

            ReadOnly Property SuggestedWidth() As Integer
                Get
                    Return bmp.Width
                End Get
            End Property

            ReadOnly Property SuggestedHeight() As Integer
                Get
                    Return bmp.Height
                End Get
            End Property

            ReadOnly Property ScaleX() As Single
                Get
                    Return width / SuggestedWidth
                End Get
            End Property

            ReadOnly Property ScaleY() As Single
                Get
                    Return height / SuggestedHeight
                End Get
            End Property
        End Class

        Default Overloads Property Item(ByVal Key As String) As TexPoolItem
            Get
                If Key Is Nothing Then Return Nothing
                Return Item(CObj(Key))
            End Get
            Set(ByVal Value As TexPoolItem)
                Item(CObj(Key)) = Value
            End Set
        End Property

        Overloads Function ItemFromIndex(ByVal index As Integer) As TexPoolItem
            Return GetByIndex(index)
        End Function

        Overloads Sub Add(ByVal Key As String, ByVal Obj As TexPoolItem)
            Add(CObj(Key), CObj(Obj))
        End Sub
    End Class
#End Region

    Public Tex As TexPool

#Region "Add/Remove Images"
    Public AutoGetBits As Boolean

    Sub img_Add(ByRef filename As String, ByRef key As String, ByVal ColorKey As Color, Optional ByVal width As Integer = 0, Optional ByVal height As Integer = 0, Optional ByVal sec_w As Integer = 0, Optional ByVal sec_h As Integer = 0, Optional ByVal reload As Boolean = False)
        If DataOnly Then Exit Sub
        If DoNotLoadImages Then Exit Sub
        If filename = "" Or key = "" Then Exit Sub
        Dim b As Boolean
        If key = filename Then b = True
        If LoadingFile Or Compiled Then filename = GetRelativeFile(filename)
        If FileNotFoundCancel Then Exit Sub
        If b Then key = filename

        Dim NewItem As TexPool.TexPoolItem

        Dim Copy As Integer = -1
        Try
            Dim i As Integer
            For i = 0 To Tex.Count - 1
                If Not (Tex.GetByIndex(i).Texture Is Nothing OrElse Tex.GetByIndex(i).Texture.Disposed) Then
                    If Tex.GetByIndex(i).key = key Then
                        If reload Then
                            NewItem = Tex.GetByIndex(i)
                            NewItem.bmp.Dispose()
                            NewItem.preview.Dispose()
                            NewItem.Texture.Dispose()
                            Exit For
                        Else
                            Return
                        End If
                    ElseIf Tex.GetByIndex(i).filename = filename Then
                        Copy = i
                    End If
                End If
            Next
        Catch
        End Try

        If NewItem Is Nothing Then NewItem = New TexPool.TexPoolItem
        With NewItem
            If Copy > -1 Then
                .Texture = Tex.GetByIndex(Copy).Texture
            Else
                .Texture = TextureLoader.FromFile(device, filename, 0, 0, 1, Usage.SoftwareProcessing, Format.A8R8G8B8, Pool.Default, Filter.Triangle Or Filter.Mirror, Filter.Triangle Or Filter.Mirror, ColorKey.ToArgb)
            End If
            'Dim tmpW As Integer, tmpH As Integer
            'If width <> 0 Then
            '    tmpW = width
            '    tmpH = height
            '    EnlargeToPowerOf2(tmpW, tmpH)
            '    width = tmpW
            '    height = tmpH
            'End If
            '.Texture = TextureLoader.FromFile(device, filename, tmpW, tmpH, 0, Usage.SoftwareProcessing, Format.A8R8G8B8, Pool.Default, Filter.None, Filter.None, ColorKey.ToArgb)
            .Key = key
            .filename = filename
            .ColorKey = ColorKey
            .width = width
            .height = height
            If Copy > -1 Then
                .bmp = Tex.GetByIndex(Copy).bmp
            Else
                .bmp = New Bitmap(filename)
            End If
            If .width = 0 Then
                .width = .bmp.Width
                '.width = .Texture.GetLevelDescription(0).Width
            End If
            If .height = 0 Then
                .height = .bmp.Height
                '.height = .Texture.GetLevelDescription(0).Height
            End If
            If Copy = -1 Then
                .bmp.MakeTransparent(.ColorKey)
            End If
            If sec_w = 0 Then
                .sectionw = .width
            Else
                .sectionw = sec_w
            End If
            If sec_h = 0 Then
                .sectionh = .height
            Else
                .sectionh = sec_h
            End If
            If Copy > -1 Then
                .preview = Tex.GetByIndex(Copy).preview
            Else
                If Game.InEditor Then
                    Dim tmpBMP As New Bitmap(.bmp, .width, .height)
                    Dim newBMP As New Bitmap(.sectionw, .sectionh)
                    Dim g As Graphics = Graphics.FromImage(newBMP)
                    g.DrawImage(tmpBMP, 0, 0)
                    .preview = newBMP.Clone
                    g.Dispose()
                    newBMP.Dispose()
                    tmpBMP.Dispose()
                End If
            End If
        End With
        If reload Then
            Tex(key) = NewItem
        Else
            Tex.Add(key, NewItem)
        End If
        If AutoGetBits Then
            'If Copy > -1 Then
            'Tex(key).Bits = Tex.GetByIndex(Copy).Bits
            'Else
            'Tex(key).Bits = img_GetBits_(key)
            'End If
        End If
        NewItem = Nothing
    End Sub

    Sub img_Add(ByRef filename As String, ByVal key As String, Optional ByVal width As Integer = 0, Optional ByVal height As Integer = 0, Optional ByVal sec_w As Integer = 0, Optional ByVal sec_h As Integer = 0)
        img_Add(filename, key, Color.FromArgb(0), width, height, sec_w, sec_h)
    End Sub

    Sub img_Remove(ByVal key As String)
        Tex.Remove(key)
    End Sub

    Sub img_Clear()
        Tex.Clear()
    End Sub
#End Region

#Region "Image Properties"
    Sub img_SetBits(ByVal Key As String, ByVal Bits(,,) As Byte)
        Tex(Key).Bits = Bits
    End Sub

    Function img_ForceGetBits(ByVal Key As String) As Byte(,,)
        If (Tex(Key).Bits Is Nothing) Then
            Tex(Key).Bits = img_GetBits_(Key)
        End If
        Return Tex(Key).Bits
    End Function

    Private Function img_GetBits_(ByVal Key As String) As Byte(,,)

        'Dim tmpW As Integer, tmpH As Integer
        'tmpW = Tex(Key).width
        'tmpH = Tex(Key).height
        'EnlargeToPowerOf2(tmpW, tmpH)
        'Dim Bits() As Byte
        'Dim r, g, b, a As Byte
        'Dim Surface As Surface = Tex(Key).Texture.GetSurfaceLevel(0)
        'Dim g_Stream As Direct3D.GraphicsStream = Surface.LockRectangle(New Rectangle(0, 0, tmpW, tmpH), LockFlags.ReadOnly)
        'While Not (g_Stream.Position >= tmpH * (tmpW * 4))
        '    b = g_Stream.ReadByte()
        '    g = g_Stream.ReadByte()
        '    r = g_Stream.ReadByte()
        '    a = g_Stream.ReadByte()
        'End While
        'Surface.UnlockRectangle()

        Dim Bits(,,) As Byte
        ReDim Bits(Tex(Key).SuggestedWidth - 1, Tex(Key).SuggestedHeight - 1, 3)
        Dim i As Integer, j As Integer
        For i = 0 To Tex(Key).SuggestedWidth - 1
            For j = 0 To Tex(Key).SuggestedHeight - 1
                With Tex(Key).bmp.GetPixel(i, j)
                    Bits(i, j, 0) = .A
                    Bits(i, j, 1) = .R
                    Bits(i, j, 2) = .G
                    Bits(i, j, 3) = .B
                End With
            Next
        Next

        'MsgBox(UBound(Bits))
        Return Bits
    End Function

    Property img_Width(ByVal key As String) As Integer
        Get
            Return Tex(key).width
        End Get
        Set(ByVal Value As Integer)
            Tex(key).width = Value
            With Tex(key)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, Value, .height, .sectionw, .sectionw)
            End With
        End Set
    End Property

    Property img_Width(ByVal index As Integer) As Integer
        Get
            Return Tex.ItemFromIndex(index).width
        End Get
        Set(ByVal Value As Integer)
            Tex.ItemFromIndex(index).width = Value
            With Tex.ItemFromIndex(index)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, Value, .height, .sectionw, .sectionw)
            End With
        End Set
    End Property

    Property img_Height(ByVal key As String) As Integer
        Get
            Return Tex(key).height
        End Get
        Set(ByVal Value As Integer)
            Tex(key).height = Value
            With Tex(key)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, Value, .sectionw, .sectionw)
            End With
        End Set
    End Property

    Property img_Height(ByVal index As Integer) As Integer
        Get
            Return Tex.ItemFromIndex(index).height
        End Get
        Set(ByVal Value As Integer)
            Tex.ItemFromIndex(index).height = Value
            With Tex.ItemFromIndex(index)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, Value, .sectionw, .sectionw)
            End With
        End Set
    End Property

    Property img_SectionW(ByVal key As String) As Integer
        Get
            Return Tex(key).sectionw
        End Get
        Set(ByVal Value As Integer)
            Tex(key).sectionw = Value
            With Tex(key)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, .height, Value, .sectionw)
            End With
        End Set
    End Property

    Property img_SectionW(ByVal index As Integer) As Integer
        Get
            Return Tex.ItemFromIndex(index).sectionw
        End Get
        Set(ByVal Value As Integer)
            Tex.ItemFromIndex(index).sectionw = Value
            With Tex.ItemFromIndex(index)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, .height, Value, .sectionw)
            End With
        End Set
    End Property

    Property img_SectionH(ByVal key As String) As Integer
        Get
            Return Tex(key).sectionh
        End Get
        Set(ByVal Value As Integer)
            Tex(key).sectionh = Value
            With Tex(key)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, .height, .sectionw, Value)
            End With
        End Set
    End Property

    Property img_SectionH(ByVal index As Integer) As Integer
        Get
            Return Tex.ItemFromIndex(index).sectionh
        End Get
        Set(ByVal Value As Integer)
            Tex.ItemFromIndex(index).sectionh = Value
            With Tex.GetByIndex(index)
                img_Remove(.Key)
                img_Add(.filename, .Key, .ColorKey, .width, .height, .sectionw, Value)
            End With
        End Set
    End Property

    Property img_ColorKey(ByVal key As String) As Color
        Get
            Return Tex(key).ColorKey
        End Get
        Set(ByVal Value As Color)
            With Tex(key)
                img_Remove(key)
                img_Add(.filename, .Key, Value, .width, .height, .sectionw, .sectionw)
            End With
        End Set
    End Property

    Property img_ColorKey(ByVal index As Integer) As Color
        Get
            Return Tex.ItemFromIndex(index).ColorKey
        End Get
        Set(ByVal Value As Color)
            Tex.ItemFromIndex(index).ColorKey = Value
            With Tex.ItemFromIndex(index)
                img_Remove(.Key)
                img_Add(.filename, .Key, Value, .width, .height, .sectionw, .sectionw)
            End With
        End Set
    End Property

    ReadOnly Property img_Count() As Integer
        Get
            Return Tex.Count
        End Get
    End Property

    ReadOnly Property img_UBound() As Integer
        Get
            Return Tex.Count - 1
        End Get
    End Property

    ReadOnly Property img_Key(ByVal index As Integer) As String
        Get
            Return Tex.ItemFromIndex(index).Key
        End Get
    End Property

    WriteOnly Property img_Key(ByVal key As String) As String
        Set(ByVal Value As String)
            Tex(key).Key = Value
            Dim tItem As TexPool.TexPoolItem
            tItem = Tex.Item(key)
            Tex.Remove(key)
            Tex.Add(Value, tItem)
        End Set
    End Property
#End Region

#End Region

#Region "Fonts"

#Region "Data Structure"
    Public Class FontPool
        Inherits SortedList

        Class FontPoolItem
            Public dxFont As Direct3D.Font
            Public Font As System.Drawing.Font
        End Class

        Default Overloads Property Item(ByVal Key As String) As FontPoolItem
            Get
                Return Item(CObj(Key))
            End Get
            Set(ByVal Value As FontPoolItem)
                Item(CObj(Key)) = Value
            End Set
        End Property

        Overloads Sub Add(ByVal Key As String, ByVal Obj As FontPoolItem)
            Add(CObj(Key), CObj(Obj))
        End Sub
    End Class
#End Region

    Public Fonts As FontPool
    Private DefaultFont As Direct3D.Font

#Region "Add/Remove Fonts"
    Sub fonts_Add(ByVal Key As String, ByVal Font_ As System.Drawing.Font)
        If Fonts.IndexOfKey(Key) > -1 Then Exit Sub

        Dim tmpItem As New FontPool.FontPoolItem
        tmpItem.Font = Font_
        tmpItem.dxFont = New Direct3D.Font(device, tmpItem.Font)
        Fonts.Add(Key, tmpItem)
    End Sub

    Sub fonts_Add(ByVal Key As String, ByVal FontName As String, ByVal Size As Integer, Optional ByVal Bold As Boolean = False, Optional ByVal Italic As Boolean = False, Optional ByVal Underline As Boolean = False, Optional ByVal Strikeout As Boolean = False)
        If DataOnly Then Exit Sub

        If Fonts.IndexOfKey(Key) > -1 Then Exit Sub

        If FontName = "Microsoft Sans Serif" Then FontName = FontFamily.GenericSansSerif.Name

        Dim FontStyle As System.Drawing.FontStyle
        FontStyle = FontStyle.Regular
        If Bold Then FontStyle = FontStyle + FontStyle.Bold
        If Italic Then FontStyle = FontStyle + FontStyle.Italic
        If Underline Then FontStyle = FontStyle + FontStyle.Underline
        If Strikeout Then FontStyle = FontStyle + FontStyle.Strikeout

        Dim tmpItem As New FontPool.FontPoolItem
        tmpItem.Font = New System.Drawing.Font(FontName, Size, FontStyle)
        tmpItem.dxFont = New Direct3D.Font(device, tmpItem.Font)
        Fonts.Add(Key, tmpItem)
    End Sub

    Sub fonts_Remove(ByVal Key As String)
        Fonts.Remove(Key)
    End Sub

    Sub fonts_Clear()
        Fonts.Clear()
    End Sub
#End Region

#End Region

#Region "Drawing"

#Region "Declarations"
    Public RelativeToCam As Boolean
    Public AffectedByScrollSpeed As Boolean
    Public OffsetX As Integer, OffsetY As Integer
    Public IgnoreOffsets As Boolean
    Private ClippingRect As Rectangle

    Sub SetClippingRect(ByVal Rect As Rectangle)
        Dim tmpView As Direct3D.Viewport
        With tmpView
            .X = Rect.X
            .Y = Rect.Y
            .Width = Rect.Width
            .Height = Rect.Height
        End With
        device.Viewport = tmpView
    End Sub

    Function GetClippingRect() As Rectangle
        Dim R As Rectangle
        With device.Viewport
            R.X = .X
            R.Y = .Y
            R.Width = .Width
            R.Height = .Height
        End With
        If R.Width = 0 Then
            R.Width = Game.cam.w
            R.Height = Game.cam.h
        End If
        Return R
    End Function
#End Region

#Region "Draw Buffer"
    Private _DrawLater As Boolean
    WriteOnly Property DrawLater() As Integer
        Set(ByVal Value As Integer)
            If Value <> 1971116 And Value <> 6111791 Then
                Throw New Exception(GetString("error_PropertyNotAccessible"))
            ElseIf Value = 1971116 Then
                _DrawLater = True
            ElseIf Value = 6111791 Then
                _DrawLater = False
            End If
        End Set
    End Property

    Enum DrawType
        Box = 0
        FilledBox
        Line
        Point
        Image
        Sprite
        TextAlignLeft
        TextAlignCenter
        TextFontKey
        LineList
        LineStrip
        PointList
    End Enum
    Structure DrawBuffer
        Dim i1, i2, i3, i4 As Integer           'i=integer
        Dim c1, c2, c3, c4 As Color             'c=color
        Dim ai1() As Integer, ai2() As Integer  'a=array
        Dim ac1() As Color                      's=string
        Dim s1 As String, s2 As String          'f=float
        Dim f1 As Single                        'o=options
        Dim o1 As Integer                       'r=rectangle
        Dim r1 As Rectangle                     't=font
        Dim type As DrawType                    'b=boolean
        Dim t1 As Direct3D.Font
        Dim b1 As Boolean
    End Structure
    Private dbuffer1() As DrawBuffer, dbuffer2() As DrawBuffer
    Sub DrawItemsInBuffer(ByVal args As Integer, Optional ByVal dbuffer() As DrawBuffer = Nothing)
        If dbuffer Is Nothing Then dbuffer = dbuffer1
        If args <> 1971116 Then
            Throw New Exception(GetString("error_MethodNotAccessible"))
        Else
            If dbuffer Is Nothing Then Exit Sub
            Dim i As Integer
            For i = 1 To UBound(dbuffer)
                With dbuffer(i)
                    Select Case .type
                        Case DrawType.Box
                            DrawBox(.i1, .i2, .i3, .i4, .c1, .c2, .c3, .c4)
                        Case DrawType.FilledBox
                            DrawFilledBox(.i1, .i2, .i3, .i4, .c1, .c2, .c3, .c4)
                        Case DrawType.Line
                            DrawLine(.i1, .i2, .i3, .i4, .c1, .c2)
                        Case DrawType.Point
                            DrawPoint(.i1, .i2, .c1)
                        Case DrawType.LineList
                            DrawLineList(.ai1, .ai2, .ac1)
                        Case DrawType.LineStrip
                            DrawLineStrip(.ai1, .ai2, .c1)
                        Case DrawType.PointList
                            DrawPointList(.ai1, .ai2, .ac1)
                        Case DrawType.Image
                            DrawImage(.s1, .i1, .i2, .i3, .i4, .c1, .c2, .c3, .c4)
                        Case DrawType.Sprite
                            DrawSprite(.s1, .r1, .i1, .i2, .i3, .i4, .f1, .c1)
                        Case DrawType.TextAlignLeft
                            DrawText(.s1, .i1, .i2, .c1)
                        Case DrawType.TextAlignCenter
                            DrawText(.s1, .r1, .c1, .i1)
                        Case DrawType.TextFontKey
                            DrawText(.s1, .s2, .r1, .c1, .i1)
                    End Select
                End With
            Next
            ReDim dbuffer1(0)
        End If
    End Sub
#End Region

#Region "Begin/End Scene"
    Private Rendered As Boolean = True
    Private drawingSprite As Boolean

    Sub Clear()
        Clear(Color.Black)
    End Sub

    Sub Clear(ByVal Color As Color)
        If InvalidDevice Then Exit Sub

        If Rendered = False Then RenderToScreen()

        Try
            'Clear the backbuffer
            device.Clear(ClearFlags.Target, Color, 1.0F, 0)

            'Begin the scene
            device.BeginScene()
        Catch
        End Try
        ReDim dbuffer2(0)

        Rendered = False
    End Sub

    Sub RenderToScreen()
        If InvalidDevice Then Exit Sub

        If Rendered Then Clear()

        If drawingSprite Then sprite.End() : drawingSprite = False

        If start = 0 Then start = Microsoft.VisualBasic.Timer
        frames = frames + 1
        If Microsoft.VisualBasic.Timer - start >= 1 Then
            fps = frames
            frames = 0
            start = Microsoft.VisualBasic.Timer
        End If

        Try
            'Game.Drawing.DrawSprite(Game.videotex, 25, 25, 256, 256, Color.White)
        Catch
        End Try

        Try
            device.EndScene()
            device.Present()
        Catch
        End Try

        Game.Audio.UpdateMusic()

        Rendered = True
    End Sub
#End Region

#Region "Capturing the Backbuffer"
    Private rsurf As Surface

    Private Function StoreBackbuffer2() As Boolean
        Try
            'Texture sizes must be powers of 2
            Dim TmpW As Integer = Game.cam.w
            Dim TmpH As Integer = Game.cam.h
            EnlargeToPowerOf2(TmpW, TmpH)

            'Create a new texture entry
            Dim NewItem As New TexPool.TexPoolItem
            With NewItem
                .Key = "Backbuffer"
                .width = TmpW
                .height = TmpH
                .sectionw = TmpW
                .sectionh = TmpH

                'It took hours for me to come up with these two lines!
                '(Copies the backbuffer to a new texture):
                .Texture = New Texture( _
                    device, TmpW, TmpH, 0, _
                    Usage.RenderTarget, device.PresentationParameters.BackBufferFormat, Pool.Default)
                device.StretchRectangle( _
                    device.GetBackBuffer(0, 0, BackBufferType.Mono), _
                    New Rectangle(0, 0, Game.cam.w, Game.cam.h), _
                    .Texture.GetSurfaceLevel(0), _
                    New Rectangle(0, 0, Game.cam.w, Game.cam.h), _
                    TextureFilter.None)
            End With

            'Adds/replaces the backbuffer texture in the texture pool
            If Not Tex.ContainsKey("Backbuffer") Then
                Tex.Add("Backbuffer", NewItem)
            Else
                With Tex("Backbuffer")
                    Try
                        If Not (.Texture Is Nothing) Then
                            .Texture.Dispose()
                            .Texture = Nothing
                        End If
                        Erase .Bits
                        .bmp.Dispose()
                        .preview.Dispose()
                    Catch
                    End Try
                End With
                Tex("Backbuffer") = NewItem
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function StoreBackbuffer() As Boolean
        Return StoreBackbuffer2()
    End Function

    Function StoreBlankBackbuffer() As Boolean
        Clear(Color.Black)
        RenderToScreen()
        Return StoreBackbuffer2()
    End Function
#End Region

#Region "Primitives"
    Sub DrawBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Color)
        DrawBox(x, y, w, h, Color1, Color1, Color1, Color1)
    End Sub

    Sub DrawBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Color, ByVal Color2 As Color, ByVal Color3 As Color, ByVal Color4 As Color)
        If InvalidDevice Then Exit Sub

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.Box
                .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color4 : .c4 = Color4
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.Box
            .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color4 : .c4 = Color4
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False
        Const NumVerts As Byte = 5

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored '= CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(4)

        verts(0) = New CustomVertex.TransformedColored(x, y, 0.5F, 1, Color1.ToArgb)
        verts(1) = New CustomVertex.TransformedColored(x + w, y, 0.5F, 1, Color2.ToArgb)
        verts(2) = New CustomVertex.TransformedColored(x + w, y + h, 0.5F, 1, Color3.ToArgb)
        verts(3) = New CustomVertex.TransformedColored(x, y + h, 0, 1, Color4.ToArgb)
        verts(4) = verts(0)
        'vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        'device.DrawPrimitives(PrimitiveType.LineStrip, 0, 4)
        device.DrawUserPrimitives(PrimitiveType.LineStrip, 4, verts)

        'vb.Dispose()
        Erase verts
    End Sub

    Sub DrawBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Integer, ByVal Color2 As Integer, ByVal Gradient As Boolean, ByVal Horizontal As Boolean)
        If Gradient Then
            If Horizontal Then
                DrawBox(x, y, w, h, Color.FromArgb(Color1), Color.FromArgb(Color2), Color.FromArgb(Color2), Color.FromArgb(Color1))
            Else
                DrawBox(x, y, w, h, Color.FromArgb(Color1), Color.FromArgb(Color1), Color.FromArgb(Color2), Color.FromArgb(Color2))
            End If
        Else
            DrawBox(x, y, w, h, Color.FromArgb(Color1))
        End If
    End Sub

    Sub DrawFilledBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Color)
        DrawFilledBox(x, y, w, h, Color1, Color1, Color1, Color1)
    End Sub

    Sub DrawFilledBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Color, ByVal Color2 As Color, ByVal Color3 As Color, ByVal Color4 As Color)
        If InvalidDevice Then Exit Sub

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.FilledBox
                .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color4 : .c4 = Color4
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.FilledBox
            .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color4 : .c4 = Color4
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        Dim verts() As CustomVertex.TransformedColored '= CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(3)

        verts(0) = New CustomVertex.TransformedColored(x, y, 0.5F, 1, Color1.ToArgb)
        verts(1) = New CustomVertex.TransformedColored(x + w, y, 0.5F, 1, Color2.ToArgb)
        verts(2) = New CustomVertex.TransformedColored(x, y + h, 0.5F, 1, Color4.ToArgb)
        verts(3) = New CustomVertex.TransformedColored(x + w, y + h, 0, 1, Color3.ToArgb)

        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, verts)

        Erase verts
    End Sub

    Sub DrawFilledBox(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Integer, ByVal Color2 As Integer, ByVal Gradient As Boolean, ByVal Horizontal As Boolean)
        If Gradient Then
            If Horizontal Then
                DrawFilledBox(x, y, w, h, Color.FromArgb(Color1), Color.FromArgb(Color2), Color.FromArgb(Color2), Color.FromArgb(Color1))
            Else
                DrawFilledBox(x, y, w, h, Color.FromArgb(Color1), Color.FromArgb(Color1), Color.FromArgb(Color2), Color.FromArgb(Color2))
            End If
        Else
            DrawFilledBox(x, y, w, h, Color.FromArgb(Color1))
        End If
    End Sub

    Sub DrawLineStrip(ByVal X() As Integer, ByVal Y() As Integer, ByVal Color As Color)
        If InvalidDevice Then Exit Sub

        Dim NumVerts As Short = UBound(X)

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored ' = CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(UBound(X) - 1)

        Dim i As Integer
        For i = 1 To UBound(X)
            If RelativeToCam Then
                X(i) -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
                Y(i) -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            End If
            If Not IgnoreOffsets Then
                X(i) += OffsetX
                Y(i) += OffsetY
            End If
            verts(i - 1) = New CustomVertex.TransformedColored(X(i), Y(i), 0.5F, 1, Color.ToArgb)
        Next

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.LineStrip
                .ai1 = X : .ai2 = Y : .c1 = Color
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.LineStrip
            .ai1 = X : .ai2 = Y : .c1 = Color
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        'vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        'device.DrawPrimitives(PrimitiveType.LineStrip, 0, UBound(X) - 1)
        device.DrawUserPrimitives(PrimitiveType.LineStrip, UBound(X) - 1, verts)

        'vb.Dispose()
        Erase verts
    End Sub

    Sub DrawLineList(ByVal X() As Integer, ByVal Y() As Integer, ByVal Colors() As Color)
        If InvalidDevice Then Exit Sub

        Dim NumVerts As Short = UBound(X)

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored '= CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(UBound(X) - 1)

        Dim i As Integer
        For i = 1 To UBound(X)
            If RelativeToCam Then
                X(i) -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
                Y(i) -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            End If
            If Not IgnoreOffsets Then
                X(i) += OffsetX
                Y(i) += OffsetY
            End If
            verts(i - 1) = New CustomVertex.TransformedColored(X(i), Y(i), 0.5F, 1, Colors(i).ToArgb)
        Next

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.LineList
                .ai1 = X : .ai2 = Y : .ac1 = Colors
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.LineList
            .ai1 = X : .ai2 = Y : .ac1 = Colors
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        '        vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        device.DrawUserPrimitives(PrimitiveType.LineList, UBound(X) \ 2, verts)

        'vb.Dispose()
        Erase verts
    End Sub

    Sub DrawPointList(ByVal X() As Integer, ByVal Y() As Integer, ByVal Colors() As Color)
        If InvalidDevice Then Exit Sub

        Dim NumVerts As Short = UBound(X)

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored '= CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(UBound(X) - 1)

        Dim i As Integer
        For i = 1 To UBound(X)
            If RelativeToCam Then
                X(i) -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
                Y(i) -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            End If
            If Not IgnoreOffsets Then
                X(i) += OffsetX
                Y(i) += OffsetY
            End If
            verts(i - 1) = New CustomVertex.TransformedColored(X(i), Y(i), 0.5F, 1, Colors(i).ToArgb)
        Next

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.PointList
                .ai1 = X : .ai2 = Y : .ac1 = Colors
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.PointList
            .ai1 = X : .ai2 = Y : .ac1 = Colors
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        '        vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        device.DrawUserPrimitives(PrimitiveType.PointList, UBound(X), verts)

        'vb.Dispose()
        Erase verts
    End Sub

    Sub DrawLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal Color1 As Color)
        DrawLine(x1, y1, x2, y2, Color1, Color1)
    End Sub

    Sub DrawLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal Color1 As Color, ByVal Color2 As Color)
        If InvalidDevice Then Exit Sub

        If RelativeToCam Then
            x1 -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            x2 -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y1 -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y2 -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x1 += OffsetX
            y1 += OffsetY
            x2 += OffsetX
            y2 += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.Line
                .i1 = x1 : .i2 = y1 : .i3 = x2 : .i4 = y2 : .c1 = Color1 : .c2 = Color2
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.Line
            .i1 = x1 : .i2 = y1 : .i3 = x2 : .i4 = y2 : .c1 = Color1 : .c2 = Color2
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored ' = CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(2)

        verts(0) = New CustomVertex.TransformedColored(x1, y1, 0.5F, 1, Color1.ToArgb)
        verts(1) = New CustomVertex.TransformedColored(x2, y2, 0.5F, 1, Color2.ToArgb)
        'vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        'device.DrawPrimitives(PrimitiveType.LineList, 0, 1)
        device.DrawUserPrimitives(PrimitiveType.LineList, 1, verts)

        'vb.Dispose()
        Erase verts
    End Sub

    Sub DrawPoint(ByVal x As Integer, ByVal y As Integer, ByVal Color As Color)
        If InvalidDevice Then Exit Sub

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.Point
                .i1 = x : .i2 = y : .c1 = Color
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.Point
            .i1 = x : .i2 = y : .c1 = Color
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False
        Const NumVerts As Byte = 1

        'Dim vb As VertexBuffer = New VertexBuffer(GetType(CustomVertex.TransformedColored), NumVerts, device, 0, CustomVertex.TransformedColored.Format, Pool.Default)
        Dim verts() As CustomVertex.TransformedColored ' = CType(vb.Lock(0, 0), CustomVertex.TransformedColored())
        ReDim verts(0)

        verts(0) = New CustomVertex.TransformedColored(x, y, 0.5F, 1, Color.ToArgb)
        'vb.Unlock()

        'device.SetStreamSource(0, vb, 0)
        device.VertexFormat = CustomVertex.TransformedColored.Format
        device.SetTexture(0, Nothing)
        'device.DrawPrimitives(PrimitiveType.PointList, 0, 1)
        device.DrawUserPrimitives(PrimitiveType.PointList, 1, verts)

        'vb.Dispose()
        Erase verts
    End Sub
#End Region

#Region "Images/Sprites"
    Sub DrawImage(ByVal key As String, ByVal x As Integer, ByVal y As Integer)
        DrawImage(key, x, y, 0, 0, Color.White, Color.White, Color.White, Color.White)
    End Sub

    Sub DrawImage(ByVal key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        DrawImage(key, x, y, w, h, Color.White, Color.White, Color.White, Color.White)
    End Sub

    Sub DrawImage(ByVal key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color As Color)
        DrawImage(key, x, y, w, h, Color, Color, Color, Color)
    End Sub

    Sub DrawImage(ByVal key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color1 As Color, ByVal Color2 As Color, ByVal Color3 As Color, ByVal Color4 As Color)
        If InvalidDevice Then Exit Sub

        Try
            If key Is Nothing Then Exit Sub
            If Tex(key).Texture Is Nothing Then Exit Sub
        Catch
            Exit Sub
        End Try

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If w = 0 Then w = Tex(key).width
        If h = 0 Then h = Tex(key).height

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.Image
                .s1 = key : .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color3 : .c4 = Color4
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.Image
            .s1 = key : .i1 = x : .i2 = y : .i3 = w : .i4 = h : .c1 = Color1 : .c2 = Color2 : .c3 = Color3 : .c4 = Color4
        End With

        If drawingSprite Then sprite.End() : drawingSprite = False

        Dim verts() As CustomVertex.TransformedColoredTextured '= CType(vb.Lock(0, 0), CustomVertex.TransformedColoredTextured())
        ReDim verts(3)

        verts(0) = New CustomVertex.TransformedColoredTextured(x, y, 0.5F, 1, Color1.ToArgb, 0, 0)
        verts(1) = New CustomVertex.TransformedColoredTextured(x + w, y, 0.5F, 1, Color2.ToArgb, 1, 0)
        verts(2) = New CustomVertex.TransformedColoredTextured(x, y + h, 0.5F, 1, Color3.ToArgb, 0, 1)
        verts(3) = New CustomVertex.TransformedColoredTextured(x + w, y + h, 0, 1, Color4.ToArgb, 1, 1)

        device.VertexFormat = CustomVertex.TransformedColoredTextured.Format
        device.SetTexture(0, Tex(key).Texture)
        device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, verts)

        Erase verts
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, Tex(Key).width, Tex(Key).height, 0, Color.White)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer, ByVal Color As Color)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, Tex(Key).width, Tex(Key).height, 0, Color)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, w, h, 0, Color.White)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color As Color)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, w, h, 0, Color)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Rotation As Single)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, w, h, Rotation, Color.White)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Rotation As Single, ByVal Color As Color)
        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return
        DrawSprite(Key, New Rectangle(0, 0, Tex(Key).Texture.GetLevelDescription(0).Width, Tex(Key).Texture.GetLevelDescription(0).Height), x, y, w, h, Rotation, Color)
    End Sub

    Public Sub DrawSprite(ByVal Key As String, ByVal Src As Rectangle, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Rotation As Single, ByVal Color As Color)
        If InvalidDevice Then Return

        If Key Is Nothing Then Return
        If Tex(Key) Is Nothing Then Return
        If Tex(Key).Texture Is Nothing Then Return
        If Tex(Key).Texture.Disposed Then Return

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.Sprite
                .s1 = Key : .r1 = Src : .i1 = x : .i2 = y : .i3 = w : .i4 = h : .f1 = Rotation : .c1 = Color
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.Sprite
            .s1 = Key : .r1 = Src : .i1 = x : .i2 = y : .i3 = w : .i4 = h : .f1 = Rotation : .c1 = Color
        End With

        Dim TempScaling As Microsoft.DirectX.Vector2, TempCenter As Microsoft.DirectX.Vector2
        Dim TmpW As Integer, TmpH As Integer
        Src.X *= (Tex(Key).Texture.GetLevelDescription(0).Width / Tex(Key).width)
        Src.Y *= (Tex(Key).Texture.GetLevelDescription(0).Height / Tex(Key).height)
        Src.Width *= (Tex(Key).Texture.GetLevelDescription(0).Width / Tex(Key).width)
        Src.Height *= (Tex(Key).Texture.GetLevelDescription(0).Height / Tex(Key).height)
        TmpW = Tex(Key).width
        TmpH = Tex(Key).height
        EnlargeToPowerOf2(TmpW, TmpH)
        TempScaling.X = w / Src.Width
        TempScaling.Y = h / Src.Height
        TempCenter.X = Tex(Key).width * 0.5 * TempScaling.X
        TempCenter.Y = Tex(Key).height * 0.5 * TempScaling.Y
        Src.Width = Src.Width + Src.X
        Src.Height = Src.Height + Src.Y
        If Not drawingSprite Then sprite.Begin() : drawingSprite = True
        Try
            sprite.Draw(Tex(Key).Texture, Src, TempScaling, TempCenter, Rotation, New Vector2(x, y), Color)
        Catch
        End Try
    End Sub

    Sub DrawSprite(ByVal Texture As Direct3D.Texture, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal Color As System.Drawing.Color)
        If Not drawingSprite Then sprite.Begin() : drawingSprite = True
        sprite.Draw(Texture, New Rectangle(0, 0, Texture.GetLevelDescription(0).Width, Texture.GetLevelDescription(0).Height), New Vector2(w / Texture.GetLevelDescription(0).Width, h / Texture.GetLevelDescription(0).Height), New Vector2(0, 0), 0, New Vector2(x, y), Color)
    End Sub
#End Region

#Region "Text"
    Sub DrawText(ByVal Text As String, ByVal x As Integer, ByVal y As Integer, ByVal Color As Color)
        If InvalidDevice Then Exit Sub

        Dim p As Point
        p.X = Screen.PrimaryScreen.WorkingArea.Width()
        p.Y = Screen.PrimaryScreen.WorkingArea.Height()

        If RelativeToCam Then
            x -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            x += OffsetX
            y += OffsetY
        End If

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.TextAlignLeft
                .s1 = Text : .i1 = x : .i2 = y : .c1 = Color
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.TextAlignLeft
            .s1 = Text : .i1 = x : .i2 = y : .c1 = Color
        End With

        p_drawText(DefaultFont, Text, New Rectangle(x, y, p.X, p.Y), DrawTextFormat.Left + DrawTextFormat.Top, Color)
    End Sub

    Sub DrawText(ByVal Text As String, ByVal Rect As Rectangle, ByVal Color As Color)
        DrawText(Text, Rect, Color, DrawTextFormat.Center + DrawTextFormat.VerticalCenter)
    End Sub

    Sub DrawText(ByVal Text As String, ByVal Rect As Rectangle, ByVal Color As Color, ByVal Format As Direct3D.DrawTextFormat)
        If InvalidDevice Then Exit Sub
        p_drawTextFormatRectangle(Rect)
        If Game.Math.Collide_BoxBox(Rect, New Rectangle(0, 0, Game.cam.w, Game.cam.h)) = False Then Exit Sub

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.TextAlignCenter
                .s1 = Text : .r1 = Rect : .c1 = Color : .i1 = Format
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.TextAlignCenter
            .s1 = Text : .r1 = Rect : .c1 = Color : .i1 = Format
        End With

        p_drawTextFormatRectangle2(Rect)
        p_drawText(DefaultFont, Text, Rect, Format, Color)
    End Sub

    Sub DrawText(ByVal key As String, ByVal Text As String, ByVal x As Integer, ByVal y As Integer, ByVal Color As Color)
        Dim p As Point
        p.X = Screen.PrimaryScreen.WorkingArea.Width()
        p.Y = Screen.PrimaryScreen.WorkingArea.Height()
        DrawText(key, Text, New Rectangle(x, y, p.X, p.Y), Color, DrawTextFormat.Left + DrawTextFormat.Top)
    End Sub

    Sub DrawText(ByVal key As String, ByVal Text As String, ByVal Rect As Rectangle, ByVal Color As Color, Optional ByVal Format As Direct3D.DrawTextFormat = DrawTextFormat.Center + DrawTextFormat.VerticalCenter)
        If InvalidDevice Then Exit Sub
        p_drawTextFormatRectangle(Rect)
        If Game.Math.Collide_BoxBox(Rect, New Rectangle(0, 0, Game.cam.w, Game.cam.h)) = False Then Exit Sub

        If _DrawLater Then
            ReDim Preserve dbuffer1(UBound(dbuffer1) + 1)
            With dbuffer1(UBound(dbuffer1))
                .type = DrawType.TextFontKey
                .s1 = key : .s2 = Text : .r1 = Rect : .c1 = Color : .i1 = Format
            End With
            Exit Sub
        End If
        ReDim Preserve dbuffer2(UBound(dbuffer2) + 1)
        With dbuffer2(UBound(dbuffer2))
            .type = DrawType.TextFontKey
            .s1 = key : .s2 = Text : .r1 = Rect : .c1 = Color : .i1 = Format
        End With

        p_drawTextFormatRectangle2(Rect)
        p_drawText(Fonts(key).dxFont, Text, Rect, Format, Color)
    End Sub

    Private Sub p_drawTextFormatRectangle(ByRef Rect As Rectangle)
        If RelativeToCam Then
            Rect.X -= Game.cam.X * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
            Rect.Y -= Game.cam.Y * IIf(AffectedByScrollSpeed, Game.ScrollSpeed, 1)
        End If
        If Not IgnoreOffsets Then
            Rect.X += OffsetX
            Rect.Y += OffsetY
        End If
    End Sub

    Private Sub p_drawTextFormatRectangle2(ByRef Rect As Rectangle)
        If Game.Math.Collide_BoxBox(Rect, New Rectangle(0, 0, Game.cam.w, Game.cam.h)) = False Then Exit Sub

        Rect.Width += Rect.X
        Rect.Height += Rect.Y

        If Rect.Width > Game.p.Width Then Rect.Width = Game.p.Width
        If Rect.Height > Game.p.Height Then Rect.Height = Game.p.Height
        If Rect.X < 0 Then Rect.X = 0
        If Rect.Y < 0 Then Rect.Y = 0
    End Sub

    Private Sub p_drawText(ByVal f As Direct3D.Font, ByVal Text As String, ByVal Rect As Rectangle, ByVal Format As Direct3D.DrawTextFormat, ByVal Color As Color)
        If Rect.Width <= Rect.X Or Rect.Height <= Rect.Y Then Exit Sub
        If Not drawingSprite Then sprite.Begin() : drawingSprite = True
        With f
            '.Begin()
            'Format += DrawTextFormat.WordEllipsis
            'Text &= Chr(0) & Chr(9)
            Format += DrawTextFormat.WordBreak
            .DrawText(Text, Rect, Format, Color)
            '.End()
        End With
    End Sub
#End Region

#End Region

#Region "Util"
    Private Sub EnlargeToPowerOf2(ByRef X As Integer, ByRef Y As Integer)
        Dim i As Integer, j As Integer
        For i = 1 To 10
            j = 2 ^ i
            If j >= X Then X = j : Exit For
        Next i
        For i = 1 To 10
            j = 2 ^ i
            If j >= Y Then Y = j : Exit For
        Next i
    End Sub
#End Region

End Class