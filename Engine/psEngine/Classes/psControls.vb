Namespace psUI

#Region "Module"
    Friend Module MouseHelper
        Public ClickHandled As Boolean, ClickRect As Rectangle
        Public MouseOverHandled As Boolean, MouseOverRect As Rectangle

        Function CanCaptureMouse(ByVal ctrltype As psControl.psCtrlType) As Boolean
            Select Case ctrltype
                Case psControl.psCtrlType.Button
                    Return True
                Case Else
                    Return False
            End Select
        End Function
    End Module
#End Region

    Public Class psControl
        Inherits MarshalByRefObject

#Region "Base Class"
        Public Shared ControlNames As New Hashtable

        Enum psCtrlType As Byte
            Button = 0
            Label = 1
            Image = 2
            GameArea = 3
            TextCounter = 4
            ImageTextCounter = 5
            ImageCounter = 6
            HighScoresArea = 7
            Movie = 8
        End Enum

        Enum psCtrlAction As Byte
            None = 0
            ShowWindow
            MessageBox
            OpenFile
            OpenURL
            PauseGame
            QuitGame
            RunScript
            [Exit]
        End Enum

        Public X As Integer, Y As Integer
        Public Width As Integer, Height As Integer
        Public Name As String
        Public Background As psBackground
        Function GetBackground() As psBackground
            Return Background
        End Function
        Public Border As Boolean
        Public Border3D As Boolean
        Public BorderColor As Color
        Function GetBorderColor() As Color
            Return BorderColor
        End Function
        Public ForeColor As Color
        Function GetForeColor() As Color
            Return ForeColor
        End Function
        Public Text As String
        Public Shadow As Boolean
        Public Type As psCtrlType
        Public CanHaveAction As Boolean

        Public Selected As Boolean

        'Private _Action As Integer
        'Public Param1 As String, Param2 As String, Param3 As Integer

        Public ID As String

        Private _Font As System.Drawing.Font
        Private OldFont As System.Drawing.Font

        Private _Active As Boolean

#Region "Mouse"
        Private _MouseInside As Boolean
        Private _MouseDown As Boolean

        Overridable Sub setMouseInside(ByVal value As Boolean, ByVal invokeEffect As Boolean)
            _MouseInside = value
        End Sub

        Overridable Sub setMouseDown(ByVal value As Boolean, ByVal invokeEffect As Boolean)
            _MouseDown = value
        End Sub
#End Region

        Sub SetDefaultText(ByVal txt As String)
            If Type < psCtrlType.GameArea Then
                Text = txt
            End If
        End Sub

        'Property Action() As psCtrlAction
        '    Get
        '        Return _Action
        '    End Get
        '    Set(ByVal Value As psCtrlAction)
        '        _Action = Value
        '    End Set
        'End Property

        Overridable Property Active() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal Value As Boolean)
                ActiveBase = Value
            End Set
        End Property

        Private Property ActiveBase() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal Value As Boolean)
                _Active = Value
                If _Active = False Then
                    'p = Nothing
                    'Background.UnloadImage()
                Else
                    'p = Game.p
                    If Background.Type = psBackground.BackgroundType.Picture Then Background.imgFilename = Background.imgFilename
                End If
            End Set
        End Property

        Property Font() As System.Drawing.Font
            Get
                Return _Font
            End Get
            Set(ByVal Value As System.Drawing.Font)
                _Font = Value
            End Set
        End Property

        ReadOnly Property MouseInside() As Boolean
            Get
                Return _MouseInside
            End Get
        End Property

        ReadOnly Property MouseDown() As Boolean
            Get
                Return _MouseDown
            End Get
        End Property

        ReadOnly Property ShiftDown() As Boolean
            Get
                Return Game.windows.ShiftDown
            End Get
        End Property

        Property Rectangle() As Rectangle
            Get
                Return New Rectangle(X, Y, Width, Height)
            End Get
            Set(ByVal Value As Rectangle)
                X = Value.X
                Y = Value.Y
                Width = Value.Width
                Height = Value.Height
            End Set
        End Property

        Overridable Sub Draw()
            'Do nothing
        End Sub

        Friend Sub DrawBorder(Optional ByVal Pressed As Boolean = False)
            With Game.Drawing
                If Border Then
                    If Border3D Then
                        If Pressed Then
                            .DrawLine(X, Y, X + Width - 1, Y, Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5))
                            .DrawLine(X, Y, X, Y + Height - 1, Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5))
                            .DrawLine(X + Width - 1, Y, X + Width - 1, Y + Height - 1, BorderColor)
                            .DrawLine(X, Y + Height - 1, X + Width, Y + Height - 1, BorderColor)
                        Else
                            .DrawLine(X, Y, X + Width - 1, Y, BorderColor)
                            .DrawLine(X, Y, X, Y + Height - 1, BorderColor)
                            .DrawLine(X + Width - 1, Y, X + Width - 1, Y + Height - 1, Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5))
                            .DrawLine(X, Y + Height - 1, X + Width, Y + Height - 1, Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5))
                        End If
                    Else
                        .DrawBox(X, Y, Width - 1, Height - 1, BorderColor)
                    End If
                End If
            End With
        End Sub

        Sub DrawBorderPreview(Optional ByVal Pressed As Boolean = False)
            With xg1
                If Border Then
                    If Border3D Then
                        If Pressed Then
                            .DrawLine(New Pen(Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5)), prevRect.X, prevRect.Y, prevRect.X + prevRect.Width - 1, prevRect.Y)
                            .DrawLine(New Pen(Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5)), prevRect.X, prevRect.Y, prevRect.X, prevRect.Y + prevRect.Height - 1)
                            .DrawLine(New Pen(BorderColor), prevRect.X + prevRect.Width - 1, prevRect.Y, prevRect.X + prevRect.Width - 1, prevRect.Y + prevRect.Height - 1)
                            .DrawLine(New Pen(BorderColor), prevRect.X, prevRect.Y + prevRect.Height - 1, prevRect.X + prevRect.Width - 1, prevRect.Y + prevRect.Height - 1)
                        Else
                            .DrawLine(New Pen(BorderColor), prevRect.X, prevRect.Y, prevRect.X + prevRect.Width - 1, prevRect.Y)
                            .DrawLine(New Pen(BorderColor), prevRect.X, prevRect.Y, prevRect.X, prevRect.Y + prevRect.Height - 1)
                            .DrawLine(New Pen(Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5)), prevRect.X + prevRect.Width - 1, prevRect.Y, prevRect.X + prevRect.Width - 1, prevRect.Y + prevRect.Height - 1)
                            .DrawLine(New Pen(Color.FromArgb(BorderColor.R * 0.5, BorderColor.G * 0.5, BorderColor.B * 0.5)), prevRect.X, prevRect.Y + prevRect.Height - 1, prevRect.X + prevRect.Width - 1, prevRect.Y + prevRect.Height - 1)
                        End If
                    Else
                        .DrawRectangle(New Pen(BorderColor), New Rectangle(prevRect.X, prevRect.Y, prevRect.Width - 1, prevRect.Height - 1))
                    End If
                End If
            End With
        End Sub

        Private Sub DrawString(ByVal s As String, ByVal font As System.Drawing.Font, ByVal brush As System.Drawing.Brush, ByVal layoutRectangle As System.Drawing.RectangleF, Optional ByVal Format As System.Drawing.StringFormat = Nothing)
            With xg1
                If Format Is Nothing Then
                    Format = New System.Drawing.StringFormat
                    Format.Alignment = StringAlignment.Near
                    Format.LineAlignment = StringAlignment.Near
                End If
                Dim sSize As SizeF
                sSize = .MeasureString(s, font)
                With layoutRectangle
                    .X = .X + (.Width - sSize.Width) * 0.5
                    .Y = .Y + (.Height - sSize.Height) * 0.5
                End With
                If Shadow Then .DrawString(s, font, New Pen(Color.Black).Brush, New RectangleF(layoutRectangle.X + 1, layoutRectangle.Y + 1, layoutRectangle.Width, layoutRectangle.Height), Format)
                .DrawString(s, font, brush, layoutRectangle, Format)
            End With
        End Sub

        Private Sub DrawText(Optional ByVal offsetX As Integer = 0, Optional ByVal offsetY As Integer = 0)
            With Game.Drawing
                Dim tmpTxt As String = Text
                tmpTxt = Replace(tmpTxt, "&LevelName", Game.CurMap.MapName, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&LevelNumber", Game.CurMapIndex, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&GameName", Game.GameProperties.Name, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&Version", Game.GameProperties.Version, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&Website", Game.GameProperties.Website, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&Support", Game.GameProperties.Support, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&Company", Game.GameProperties.Company, , , CompareMethod.Text)
                tmpTxt = Replace(tmpTxt, "&Credits", Game.GameProperties.Credits, , , CompareMethod.Text)
                For i As Integer = 1 To UBound(Game.actions.Counters)
                    tmpTxt = Replace(tmpTxt, "&" & Game.actions.Counters(i).Name, Game.actions.Counters(i).Value, , , CompareMethod.Text)
                Next
                If Shadow Then .DrawText(ID, tmpTxt, New Rectangle(Rectangle.X + offsetX + 1, Rectangle.Y + offsetY + 1, Rectangle.Width, Rectangle.Height), Color.Black)
                .DrawText(ID, tmpTxt, New Rectangle(Rectangle.X + +offsetX, Rectangle.Y + +offsetY, Rectangle.Width, Rectangle.Height), ForeColor)
            End With
        End Sub

        Private Sub DrawFooterBase()
            If Selected Then
                Game.Drawing.DrawFilledBox(X, Y, Width, Height, Color.FromArgb(128, 64, 64, 255))
                Game.Drawing.DrawBox(X, Y, Width, Height, Color.FromArgb(192, 128, 128, 255))
                Game.Drawing.DrawBox(X - 1, Y - 1, Width + 2, Height + 2, Color.FromArgb(192, 128, 128, 255))
            End If
        End Sub

        Private Sub UpdateFont()
            'Update font
            ID = Font.FontFamily.Name & "|" & Font.Size & "|" & Font.Style.ToString
            Game.Drawing.fonts_Add(ID, Font)
            'CleanUpFonts()
            'If OldFont Is Nothing OrElse _
            '_Font.FontFamily.Name <> OldFont.FontFamily.Name OrElse _
            '_Font.Size <> OldFont.Size OrElse _
            '_Font.Style <> OldFont.Style Then
            '    If _Font Is Nothing Then Exit Sub
            '    If ID <> "" Then
            '        Game.Drawing.Fonts(ID).Font = _Font
            '        Game.Drawing.Fonts(ID).dxFont = New Microsoft.DirectX.Direct3D.Font(Game.Drawing.device, _Font)
            '    Else
            '        ID = "ctrl|" & CDbl(Microsoft.VisualBasic.Timer) + (Rnd(1) * 10000000 + 10000000)
            '        Game.Drawing.fonts_Add(ID, _Font)
            '    End If
            '    OldFont = _Font.Clone
            'End If
        End Sub

        Overridable Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
            Dim tmpCtl As New psControl
            CloneBase(CreateNewName, tmpCtl, MakeActive)
            Return tmpCtl
        End Function

        Overridable Sub Init()
            InitBase()
        End Sub

        Friend Overridable Sub Load()
            LoadBase()
        End Sub

        Friend Overridable Sub Save()
            SaveBase()
        End Sub

        Friend Sub InitBase()
            Active = True
            _Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)
            CanHaveAction = False
            Name = createName()
            If Not ControlNames.ContainsKey(Name.ToLower) Then
                ControlNames.Add(Name.ToLower, Name.ToLower)
            End If
        End Sub

        Public Function createName(Optional ByVal hint As String = "") As String
            If hint <> "" AndAlso Not ControlNames.ContainsKey(hint.ToLower) Then
                Return hint
            Else
                Dim num As Integer = 1
                While ControlNames.ContainsKey(String.Format(GetString("defaultControlName"), num).ToLower())
                    num += 1
                End While
                Return String.Format(GetString("defaultControlName"), num)
            End If
        End Function

        Friend Sub SetName(ByVal value As String)
            If ControlNames.Contains(Name.ToLower) Then
                ControlNames.Remove(Name.ToLower)
            End If
            If Not ControlNames.ContainsKey(value.ToLower) Then
                ControlNames.Add(value.ToLower, value.ToLower)
            End If
            Name = value
        End Sub

        Public Shared Sub rebuildControlNames()
            ControlNames.Clear()
            For i As Integer = 1 To UBound(Game.windows.Windows)
                For j As Integer = 1 To Game.windows.Windows(i).NumCtrls
                    ControlNames.Add(Game.windows.Windows(i).Controls(j).Name, Game.windows.Windows(i).Controls(j).Name)
                Next
            Next
        End Sub

        Sub RemoveName()
            While ControlNames.ContainsKey(Name.ToLower)
                ControlNames.Remove(Name.ToLower)
            End While

            'Delete actions
            If Game.actions.Actions Is Nothing Then Return
            For i As Integer = 1 To UBound(Game.actions.Actions)
                If i > UBound(Game.actions.Actions) Then Exit For
                If Game.actions.Actions(i).Trigger = "wcli" & Name Then
                    For j As Integer = i To UBound(Game.actions.Actions) - 1
                        Game.actions.Actions(j) = Game.actions.Actions(j + 1)
                    Next
                    ReDim Preserve Game.actions.Actions(UBound(Game.actions.Actions) - 1)
                    i -= 1
                End If
            Next
        End Sub

        Friend Sub SaveBase()
            psFileHandler.FilePutString(Name)
            psFileHandler.bWriter.Write(X)
            psFileHandler.bWriter.Write(Y)
            psFileHandler.bWriter.Write(Width)
            psFileHandler.bWriter.Write(Height)
            psFileHandler.bWriter.Write(Border)
            psFileHandler.bWriter.Write(Border3D)
            psFileHandler.bWriter.Write(BorderColor.ToArgb)
            psFileHandler.bWriter.Write(ForeColor.ToArgb)
            psFileHandler.FilePutString(Text)
            psFileHandler.bWriter.Write(Shadow)

            'Save font
            psFileHandler.FilePutString(_Font.FontFamily.Name)
            psFileHandler.bWriter.Write(_Font.Size)
            psFileHandler.bWriter.Write((_Font.Style And FontStyle.Bold) <> 0)
            psFileHandler.bWriter.Write((_Font.Style And FontStyle.Italic) <> 0)
            psFileHandler.bWriter.Write((_Font.Style And FontStyle.Underline) <> 0)
            psFileHandler.bWriter.Write((_Font.Style And FontStyle.Strikeout) <> 0)

            psFileHandler.bWriter.Write(CanHaveAction)
            Background.Save()
        End Sub

        Friend Sub LoadBase()
            psFileHandler.FileGetString(Name)
            If Name Is Nothing OrElse Name = "" Then Name = createName()
            If Not ControlNames.ContainsKey(Name.ToLower) Then
                ControlNames.Add(Name.ToLower, Name.ToLower)
            End If
            X = psFileHandler.bReader.ReadInt32
            Y = psFileHandler.bReader.ReadInt32
            Width = psFileHandler.bReader.ReadInt32
            Height = psFileHandler.bReader.ReadInt32
            Border = psFileHandler.ReadBoolean
            Border3D = psFileHandler.ReadBoolean
            Dim i As Integer
            i = psFileHandler.bReader.ReadInt32
            BorderColor = Color.FromArgb(i)
            i = psFileHandler.bReader.ReadInt32
            ForeColor = Color.FromArgb(i)
            psFileHandler.FileGetString(Text)
            Shadow = psFileHandler.ReadBoolean

            'Load font
            Dim str As String = Nothing, sng As Single, fs As FontStyle
            Dim bln As Boolean
            psFileHandler.FileGetString(str)
            sng = psFileHandler.bReader.ReadSingle
            fs = FontStyle.Regular
            bln = psFileHandler.ReadBoolean : If bln Then fs += FontStyle.Bold
            bln = psFileHandler.ReadBoolean : If bln Then fs += FontStyle.Italic
            bln = psFileHandler.ReadBoolean : If bln Then fs += FontStyle.Underline
            bln = psFileHandler.ReadBoolean : If bln Then fs += FontStyle.Strikeout
            If str = "Microsoft Sans Serif" Or str = "MS Sans Serif" Then
                str = FontFamily.GenericSansSerif.Name
            End If
            Try
                _Font = New System.Drawing.Font(New FontFamily(str), sng, fs)
            Catch
                _Font = New System.Drawing.Font(FontFamily.GenericSansSerif, sng, fs)
            End Try

            'Convert old window action system to new action system
            If psFileUpdater.curVersion < 3.0 Then
                Dim axn As psUI.psControl.psCtrlAction = psFileHandler.bReader.ReadInt32
                Dim p1 As String = Nothing
                Dim p2 As String = Nothing
                Dim p3 As Integer
                psFileHandler.FileGetString(p1)
                psFileHandler.FileGetString(p2)
                p3 = psFileHandler.bReader.ReadInt32
                Select Case axn
                    Case psCtrlAction.Exit
                        Game.actions.AddAction("wcli" & Name, "Exit Program")
                    Case psCtrlAction.MessageBox
                        Dim strIcons() As String = {"None", "Information", "Question", "Exclamation", "Error"}
                        Game.actions.AddAction("wcli" & Name, "Message Dialog", p1, p2, strIcons(p3))
                    Case psCtrlAction.OpenFile
                        Game.actions.AddAction("wcli" & Name, "Open File", p1)
                    Case psCtrlAction.OpenURL
                        Game.actions.AddAction("wcli" & Name, "Open URL", p1)
                    Case psCtrlAction.PauseGame
                        Game.actions.AddAction("wcli" & Name, "Pause Game")
                    Case psCtrlAction.QuitGame
                        Game.actions.AddAction("wcli" & Name, "Quit Game")
                    Case psCtrlAction.RunScript
                        Game.actions.AddAction("wcli" & Name, "Execute Script", p1)
                    Case psCtrlAction.ShowWindow
                        Game.actions.AddAction("wcli" & Name, "Show Window Index", p1)
                End Select
            End If

            CanHaveAction = psFileHandler.ReadBoolean
            Background.Load()
        End Sub

        Sub CloneBase(ByVal CreateNewName As Boolean, ByRef CopyTo As psControl, Optional ByVal MakeActive As Boolean = True)
            With CopyTo
                If CreateNewName Then
                    .Name = createName(Name)
                Else
                    .Name = Name
                End If
                If MakeActive AndAlso Not ControlNames.ContainsKey(.Name.ToLower) Then ControlNames.Add(.Name.ToLower, .Name.ToLower)
                .X = X
                .Y = Y
                .Width = Width
                .Height = Height
                .Background = Background.Clone
                .Border = Border
                .Border3D = Border3D
                .BorderColor = BorderColor
                .ID = ""
                .Font = _Font
                .ForeColor = ForeColor
                .Text = Text
                .Shadow = Shadow
                .Type = Type
                ._MouseDown = False
                ._MouseInside = False
                ClickHandled = False
                MouseOverHandled = False
                .Active = MakeActive
                .CanHaveAction = CanHaveAction
                .Selected = Selected
            End With
        End Sub

        Private oImage As Image, xg1 As Graphics
        Private prevRect As Rectangle
        Private Sub DrawPreviewBase(ByRef pic As PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
            'AutoRedraw
            oImage = New Bitmap(pic.Width, pic.Height)
            xg1 = Graphics.FromImage(oImage)
            pic.Image = oImage

            prevRect = New Rectangle(0, 0, pic.Width, pic.Height)
        End Sub

        Overridable Sub DrawPreview(ByRef pic As PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
            DrawPreviewBase(pic)
        End Sub
#End Region

#Region "Button"
        Public Class psButton
            Inherits psUI.psControl
            Public Over As psBackground
            Function GetOver() As psBackground
                Return Over
            End Function
            Public Down As psBackground
            Function GetDown() As psBackground
                Return Down
            End Function

            Public RolloverEffect As Effect
            Public RolloverEffectLength As Single
            Public PushEffect As Effect
            Public PushEffectLength As Single

            Enum Effect As Byte
                None
                Fade
                FadeInOnly
                FadeOutOnly
            End Enum

            Public Shared ReadOnly Effects() As String = { _
                GetString("effect_None"), GetString("effect_Fade"), GetString("effect_FadeIn"), GetString("effect_FadeOut")}

            Friend Overrides Sub Save()
                SaveBase()
                Over.Save()
                Down.Save()
                psFileHandler.bWriter.Write(RolloverEffect)
                psFileHandler.bWriter.Write(RolloverEffectLength)
                psFileHandler.bWriter.Write(PushEffect)
                psFileHandler.bWriter.Write(PushEffectLength)
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
                Over.Load()
                Down.Load()

                'Version 2.2+ specific
                If psFileUpdater.curVersion >= 2.2 Then
                    RolloverEffect = psFileHandler.bReader.ReadByte
                    RolloverEffectLength = psFileHandler.bReader.ReadSingle
                    PushEffect = psFileHandler.bReader.ReadByte
                    PushEffectLength = psFileHandler.bReader.ReadSingle
                End If
            End Sub

            Overrides Sub Init()
                InitBase()
                Text = String.Format(GetString("defaultButtonText"), 1)
                Background = psBackground.NewVGradientBackground( _
                    Color.White, Color.DarkGray)
                Over = psBackground.NewVGradientBackground( _
                    Color.White, Color.LightGreen)
                Down = psBackground.NewVGradientBackground( _
                    Color.FromArgb(96, 192, 96), Color.FromArgb(160, 255, 160))
                ForeColor = Color.Black
                BorderColor = Color.LightGray
                Border = True
                Border3D = True
                RolloverEffect = Effect.Fade
                RolloverEffectLength = 0.3F
                PushEffect = Effect.FadeOutOnly
                PushEffectLength = 0.3F
                Rectangle = New Rectangle(100, 100, 128, 64)
                Type = psCtrlType.Button
                CanHaveAction = True
            End Sub

            Overrides Sub Draw()
                UpdateFont()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False

                    Dim frame As EffectFrame = nextFrame(Rectangle, MouseInside, MouseDown)
                    frame.to.Draw(frame.x, frame.y, frame.w, frame.h)
                    DrawBorder(MouseInside AndAlso MouseDown)
                    DrawText(IIf(MouseInside AndAlso MouseDown, 1, 0), IIf(MouseInside AndAlso MouseDown, 1, 0))
                End With
                If Game.InEditor Then DrawFooterBase()

                'Exit Sub

                'With Game.Drawing
                '    If MouseInside Then
                '        If MouseDown Then
                '            'Down
                '            Down.Draw(X, Y, Width, Height)
                '            DrawBorder(True)
                '            .DrawText(ID, Text, New Rectangle(Rectangle.X + 1, Rectangle.Y + 1, Rectangle.Width, Rectangle.Height), ForeColor)
                '        Else
                '            'Over
                '            Over.Draw(X, Y, Width, Height)
                '            DrawBorder()
                '            If Shadow Then .DrawText(ID, Text, New Rectangle(Rectangle.X + 1, Rectangle.Y + 1, Rectangle.Width, Rectangle.Height), Color.Black)
                '            .DrawText(ID, Text, Rectangle, ForeColor)
                '        End If
                '    Else
                '        'Normal
                '        Background.Draw(X, Y, Width, Height)
                '        DrawBorder()
                '        If Shadow Then .DrawText(ID, Text, New Rectangle(Rectangle.X + 1, Rectangle.Y + 1, Rectangle.Width, Rectangle.Height), Color.Black)
                '        .DrawText(ID, Text, Rectangle, ForeColor)
                '    End If
                'End With
                'If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Sub DrawPreview(ByRef pic As PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                Dim frame As EffectFrame = nextFrame(prevRect, MouseInside, MouseDown)

                'Draw
                frame.to.Draw(xg1, frame.x, frame.y, frame.w, frame.h, picTrans)
                DrawBorderPreview(MouseInside AndAlso MouseDown)
                DrawString(Text, _Font, New Pen(ForeColor).Brush, New RectangleF(prevRect.X + IIf(MouseInside AndAlso MouseDown, 1, 0), prevRect.Y + IIf(MouseInside AndAlso MouseDown, 1, 0), prevRect.Width, prevRect.Height))

                'Exit Sub

                'DrawPreviewBase(pic, Rollover, Pressed)
                'With xg1
                '    If prevRollover Then
                '        If prevPressed Then
                '            'Down
                '            Down.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                '            DrawBorderPreview(True)
                '            DrawString(Text, _Font, New Pen(ForeColor).Brush, New RectangleF(prevRect.X + 1, prevRect.Y + 1, prevRect.Width, prevRect.Height))
                '        Else
                '            'Over
                '            Over.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                '            DrawBorderPreview()
                '            DrawString(Text, _Font, New Pen(ForeColor).Brush, New RectangleF(prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height))
                '        End If
                '    Else
                '        'Normal
                '        Background.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                '        DrawBorderPreview()
                '        DrawString(Text, _Font, New Pen(ForeColor).Brush, New RectangleF(prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height))
                '    End If
                'End With
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psButton
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                    .Text = Text
                    .Over = Over.Clone
                    .Down = Down.Clone
                    .RolloverEffect = RolloverEffect
                    .RolloverEffectLength = RolloverEffectLength
                    .PushEffect = PushEffect
                    .PushEffectLength = PushEffectLength
                End With
                Return NewObj
            End Function

            Public Overrides Property Active() As Boolean
                Get
                    Return ActiveBase
                End Get
                Set(ByVal Value As Boolean)
                    ActiveBase = Value
                    If _Active = False Then
                        'Over.UnloadImage()
                        'Down.UnloadImage()
                    Else
                        If Over.Type = psBackground.BackgroundType.Picture Then Over.imgFilename = Over.imgFilename
                        If Down.Type = psBackground.BackgroundType.Picture Then Down.imgFilename = Down.imgFilename
                    End If
                End Set
            End Property

#Region "Mouse & Effects"
            Enum EffectType
                None
                NormalToRollover
                RolloverToPush
                PushToRollover
                RolloverToNormal
                NormalToPushed
                PushedToNormal
            End Enum

            Private effect_Start As Double
            Private effect_Type As EffectType
            Private effect_Effect As Effect
            Private effect_Length As Single

            Public Overrides Sub setMouseDown(ByVal value As Boolean, ByVal invokeEffect As Boolean)
                If invokeEffect AndAlso (MouseDown = Not value) Then
                    'Push effect
                    effect_Start = Timer
                    If MouseInside Then
                        If value Then
                            effect_Type = EffectType.RolloverToPush
                        Else
                            effect_Type = EffectType.PushToRollover
                        End If
                    Else
                        effect_Type = EffectType.None
                    End If
                    effect_Effect = PushEffect
                    effect_Length = PushEffectLength
                    If effect_Effect = Effect.None OrElse effect_Length = 0 Then effect_Type = EffectType.None
                ElseIf Not invokeEffect Then
                    'Changed window -> no effect
                    effect_Type = EffectType.None
                End If
                MyBase.setMouseDown(value, invokeEffect)
            End Sub

            Public Overrides Sub setMouseInside(ByVal value As Boolean, ByVal invokeEffect As Boolean)
                If invokeEffect AndAlso (MouseInside = Not value) Then
                    'Rollover effect
                    effect_Start = Timer
                    If value Then
                        If MouseDown Then
                            effect_Type = EffectType.NormalToPushed
                        Else
                            effect_Type = EffectType.NormalToRollover
                        End If
                    Else
                        If MouseDown Then
                            effect_Type = EffectType.PushedToNormal
                        Else
                            effect_Type = EffectType.RolloverToNormal
                        End If
                    End If
                    effect_Effect = RolloverEffect
                    effect_Length = RolloverEffectLength
                    If effect_Effect = Effect.None OrElse effect_Length = 0 Then effect_Type = EffectType.None
                ElseIf Not invokeEffect Then
                    'Changed window -> no effect
                    effect_Type = EffectType.None
                End If
                MyBase.setMouseInside(value, invokeEffect)
            End Sub

            Structure EffectFrame
                Dim x, y, w, h As Integer
                Dim from, [to] As psUI.psBackground
                Dim transition As Boolean
            End Structure

            Function nextFrame(ByVal rect As Rectangle, ByVal rollover As Boolean, ByVal pressed As Boolean) As EffectFrame
                Dim frame As New EffectFrame
                frame.x = rect.X
                frame.y = rect.Y
                frame.w = rect.Width
                frame.h = rect.Height

                'Get the 2 frames to blend between
                Select Case effect_Type
                    Case EffectType.None
                        If rollover Then
                            If pressed Then
                                frame.to = Down
                            Else
                                frame.to = Over
                            End If
                        Else
                            frame.to = Background
                        End If
                    Case EffectType.NormalToRollover
                        frame.transition = True
                        frame.from = Background
                        frame.to = Over
                    Case EffectType.RolloverToPush
                        frame.transition = True
                        frame.from = Over
                        frame.to = Down
                    Case EffectType.PushToRollover
                        frame.transition = True
                        frame.from = Down
                        frame.to = Over
                    Case EffectType.RolloverToNormal
                        frame.transition = True
                        frame.from = Over
                        frame.to = Background
                    Case EffectType.NormalToPushed
                        frame.transition = True
                        frame.from = Background
                        frame.to = Down
                    Case EffectType.PushedToNormal
                        frame.transition = True
                        frame.from = Down
                        frame.to = Background
                End Select
                If frame.transition = False Then Return frame

                'Are we fading in or out?
                Dim fadingIn As Boolean = (effect_Type = EffectType.NormalToRollover OrElse effect_Type = EffectType.RolloverToPush)
                Dim fadingOut As Boolean = (effect_Type = EffectType.RolloverToNormal OrElse effect_Type = EffectType.PushToRollover)

                'Calculate time
                Dim time As Double = (Timer - effect_Start) / effect_Length
                If time < 0.0 Then time = 0.0
                If time > 1.0 Then
                    effect_Type = EffectType.None
                    Return nextFrame(rect, rollover, pressed)
                End If

                'Perform the effect
                Select Case effect_Effect
                    Case Effect.FadeInOnly
                        If fadingIn Then
                            GoTo Fade
                        Else
                            effect_Type = EffectType.None
                            Return nextFrame(rect, rollover, pressed)
                        End If
                    Case Effect.FadeOutOnly
                        If fadingOut Then
                            GoTo Fade
                        Else
                            effect_Type = EffectType.None
                            Return nextFrame(rect, rollover, pressed)
                        End If
                    Case Effect.Fade
Fade:
                        Dim c1, c2, c3, c4 As Color
                        c1 = Color.FromArgb(time * frame.to.ColorTL.A + (1 - time) * frame.from.ColorTL.A, time * frame.to.ColorTL.R + (1 - time) * frame.from.ColorTL.R, time * frame.to.ColorTL.G + (1 - time) * frame.from.ColorTL.G, time * frame.to.ColorTL.B + (1 - time) * frame.from.ColorTL.B)
                        c2 = Color.FromArgb(time * frame.to.ColorTR.A + (1 - time) * frame.from.ColorTR.A, time * frame.to.ColorTR.R + (1 - time) * frame.from.ColorTR.R, time * frame.to.ColorTR.G + (1 - time) * frame.from.ColorTR.G, time * frame.to.ColorTR.B + (1 - time) * frame.from.ColorTR.B)
                        c3 = Color.FromArgb(time * frame.to.ColorBR.A + (1 - time) * frame.from.ColorBR.A, time * frame.to.ColorBR.R + (1 - time) * frame.from.ColorBR.R, time * frame.to.ColorBR.G + (1 - time) * frame.from.ColorBR.G, time * frame.to.ColorBR.B + (1 - time) * frame.from.ColorBR.B)
                        c4 = Color.FromArgb(time * frame.to.ColorBL.A + (1 - time) * frame.from.ColorBL.A, time * frame.to.ColorBL.R + (1 - time) * frame.from.ColorBL.R, time * frame.to.ColorBL.G + (1 - time) * frame.from.ColorBL.G, time * frame.to.ColorBL.B + (1 - time) * frame.from.ColorBL.B)
                        frame.to.Color1 = c1
                        frame.to.Color2 = c2
                        frame.to.Color3 = c3
                        frame.to.Color4 = c4
                        frame.to.Type = psBackground.BackgroundType.Gradient4
                        Return frame
                End Select
                Return Nothing
            End Function
#End Region

        End Class
#End Region

#Region "Label"
        Public Class psLabel
            Inherits psUI.psControl

            Friend Overrides Sub Save()
                SaveBase()
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
            End Sub

            Overrides Sub Init()
                InitBase()
                Text = String.Format(GetString("defaultLabelText"), 1)
                Background = psBackground.NewSolidBackground( _
                    Color.FromArgb(0, 0, 0, 0))
                ForeColor = Color.White
                BorderColor = Color.LightGray
                Border3D = False
                Border = False
                Rectangle = New Rectangle(200, 100, 128, 64)
                Type = psCtrlType.Label
            End Sub

            Overrides Sub Draw()
                UpdateFont()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False

                    Background.Draw(X, Y, Width, Height)
                    DrawBorder()
                    DrawText()
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psLabel
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                End With
                Return NewObj
            End Function

            Overrides Sub DrawPreview(ByRef pic As System.Windows.Forms.PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                With xg1
                    Background.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                    DrawBorderPreview()
                    DrawString(Text, _Font, New Pen(ForeColor).Brush, New RectangleF(prevRect.X - 500, prevRect.Y - 500, prevRect.Width + 1000, prevRect.Height + 1000))
                End With
            End Sub
        End Class
#End Region

#Region "Image"
        Public Class psImage
            Inherits psLabel

            Overrides Sub Init()
                InitBase()
                Background = psBackground.NewSolidBackground( _
                    Color.FromArgb(255, 128, 128, 128))
                Rectangle = New Rectangle(200, 200, 128, 64)
                Type = psCtrlType.Image
            End Sub

            Overrides Sub Draw()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False
                    Background.Draw(X, Y, Width, Height)
                    DrawBorder()
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Sub DrawPreview(ByRef pic As System.Windows.Forms.PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                With xg1
                    Background.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                    DrawBorderPreview()
                End With
            End Sub
        End Class
#End Region

#Region "Game Ctl"
        Public Class psGameCtl
            Inherits psUI.psControl

            Friend Overrides Sub Save()
                SaveBase()
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
            End Sub

            Overrides Sub Init()
                InitBase()
                Type = psCtrlType.GameArea
                Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
            End Sub

            Overrides Sub Draw()
                If Not Game.InEditor Then Exit Sub
                UpdateFont()
                With Game.Drawing
                    .DrawFilledBox(X, Y, Width, Height, Color.FromArgb(128, 255, 128, 0))
                    .DrawBox(X, Y, Width, Height, Color.Blue)
                    .DrawText(ID, GetString("windows_GameAreaPlaceholder"), New Rectangle(X + 1, Y + 1, Width, Height), Color.Black)
                    .DrawText(ID, GetString("windows_GameAreaPlaceholder"), New Rectangle(X, Y, Width, Height), Color.White)
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psGameCtl
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                End With
                Return NewObj
            End Function

            Protected Overrides Sub Finalize()
                MyBase.Finalize()
            End Sub
        End Class
#End Region

#Region "High Scores Area"
        Public Class psHighScoresArea
            Inherits psUI.psControl
            Public NumberOfScores As Integer
            Public ShowName As Boolean
            Public ShowLevel As Boolean

            Friend Overrides Sub Save()
                SaveBase()
                psFileHandler.bWriter.Write(NumberOfScores)
                psFileHandler.bWriter.Write(ShowName)
                psFileHandler.bWriter.Write(ShowLevel)
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
                NumberOfScores = psFileHandler.bReader.ReadInt32
                ShowName = psFileHandler.ReadBoolean
                ShowLevel = psFileHandler.ReadBoolean
            End Sub

            Overrides Sub Init()
                InitBase()
                Type = psCtrlType.HighScoresArea
                NumberOfScores = 10
                ShowName = True
                ShowLevel = True
                ForeColor = Color.White
                BorderColor = Color.LightGray
                Border3D = False
                Border = True
                Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                Game.Drawing.fonts_Add("HighScoresHeader", New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold))
                If Game.InEditor Then Game.Drawing.fonts_Add("HighScoresArea", New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold))
            End Sub

            Overrides Sub Draw()
                UpdateFont()
                If Not Game.InEditor Then Exit Sub
                With Game.Drawing
                    .DrawFilledBox(X, Y, Width, Height, Color.FromArgb(128, 255, 128, 0))
                    .DrawBox(X, Y, Width, Height, Color.Blue)
                    .DrawText("HighScoresArea", GetString("windows_HighScoresPlaceholder"), New Rectangle(X + 1, Y + 1, Width, Height), Color.Black)
                    .DrawText("HighScoresArea", GetString("windows_HighScoresPlaceholder"), New Rectangle(X, Y, Width, Height), Color.White)
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psHighScoresArea
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                    .NumberOfScores = NumberOfScores
                    .ShowName = ShowName
                    .ShowLevel = ShowLevel
                End With
                Return NewObj
            End Function

            Protected Overrides Sub Finalize()
                MyBase.Finalize()
            End Sub
        End Class
#End Region

#Region "Text Counter"
        Public Class psTextCounter
            Inherits psUI.psControl

            Friend Overrides Sub Save()
                SaveBase()
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
            End Sub

            Overrides Sub Init()
                InitBase()
                Text = GetString("counters_Score")
                Background = psBackground.NewSolidBackground( _
                    Color.FromArgb(0, 0, 0, 0))
                ForeColor = Color.White
                BorderColor = Color.LightGray
                Border3D = False
                Border = False
                Rectangle = New Rectangle(200, 100, 128, 64)
                Type = psCtrlType.TextCounter
            End Sub

            Overrides Sub Draw()
                UpdateFont()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False
                    Background.Draw(X, Y, Width, Height)
                    DrawBorder()
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        With Game.actions.Counters(tmpInt)
                            If Shadow Then Game.Drawing.DrawText(ID, .Name & ": " & .Value, New Rectangle(Rectangle.X + 1, Rectangle.Y + 1, Rectangle.Width, Rectangle.Height), Color.Black, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                            Game.Drawing.DrawText(ID, .Name & ": " & .Value, Rectangle, ForeColor, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                        End With
                    Else
                        Game.Drawing.DrawFilledBox(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Color.White)
                        Game.Drawing.DrawText(String.Format(GetString("error_CounterDoesntExist"), Text), Rectangle, Color.Red, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                    End If
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psTextCounter
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                End With
                Return NewObj
            End Function

            Overrides Sub DrawPreview(ByRef pic As System.Windows.Forms.PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                With xg1
                    Background.Draw(xg1, prevRect.X, prevRect.Y, prevRect.Width, prevRect.Height, picTrans)
                    DrawBorderPreview()
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        With Game.actions.Counters(GetCounter(Text))
                            If Shadow Then xg1.DrawString(.Name & ": " & .Value, _Font, New Pen(Color.Black).Brush, prevRect.X + 1, prevRect.Y + (prevRect.Height - _Font.Height) \ 2 + 1)
                            xg1.DrawString(.Name & ": " & .Value, _Font, New Pen(ForeColor).Brush, prevRect.X, prevRect.Y + (prevRect.Height - _Font.Height) \ 2)
                        End With
                    Else
                        With xg1
                            .FillRectangle(New Pen(Color.White).Brush, prevRect)
                            DrawString(GetString("error_CounterDoesntExist"), DefaultFont, New Pen(Color.Red).Brush, New RectangleF(prevRect.X - 500, prevRect.Y - 500, prevRect.Width + 1000, prevRect.Height + 1000))
                        End With
                    End If
                End With
            End Sub
        End Class
#End Region

#Region "Image and Text Counter"
        Public Class psImageTextCounter
            Inherits psUI.psControl
            Public imgW, imgH As Short

            Friend Overrides Sub Save()
                SaveBase()
                psFileHandler.bWriter.Write(imgW)
                psFileHandler.bWriter.Write(imgH)
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
                imgW = psFileHandler.bReader.ReadInt16
                imgH = psFileHandler.bReader.ReadInt16
            End Sub

            Overrides Sub Init()
                InitBase()
                Text = GetString("counters_Score")
                Background = psBackground.NewSolidBackground( _
                    Color.FromArgb(255, 128, 128, 128))
                ForeColor = Color.White
                BorderColor = Color.LightGray
                Border3D = False
                Border = False
                Rectangle = New Rectangle(200, 100, 128, 64)
                imgW = 16
                imgH = 16
                Type = psCtrlType.ImageTextCounter
            End Sub

            Overrides Sub Draw()
                UpdateFont()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False
                    DrawBorder()
                    Dim R As Rectangle = Game.Drawing.GetClippingRect()
                    Game.Drawing.SetClippingRect(New Rectangle(Me.Rectangle.X, Me.Rectangle.Y, Me.Rectangle.Width, Me.Rectangle.Height))
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        Background.Draw(X, Y + (Height - imgH) \ 2, imgW, imgH)
                        With Game.actions.Counters(tmpInt)
                            If Shadow Then Game.Drawing.DrawText(ID, ": " & .Value, New Rectangle(Rectangle.X + imgW + 2, Rectangle.Y + 1, Rectangle.Width - imgW - 1, Rectangle.Height), Color.Black, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                            Game.Drawing.DrawText(ID, ": " & .Value, New Rectangle(Rectangle.X + imgW + 1, Rectangle.Y, Rectangle.Width - imgW - 1, Rectangle.Height), ForeColor, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                        End With
                    Else
                        Game.Drawing.DrawFilledBox(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Color.White)
                        Game.Drawing.DrawText(String.Format(GetString("error_CounterDoesntExist"), Text), Rectangle, Color.Red, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                    End If
                    Game.Drawing.SetClippingRect(R)
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psImageTextCounter
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                    .imgW = imgW
                    .imgH = imgH
                End With
                Return NewObj
            End Function

            Overrides Sub DrawPreview(ByRef pic As System.Windows.Forms.PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                With xg1
                    DrawBorderPreview()
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        Background.Draw(xg1, prevRect.X, prevRect.Y + (prevRect.Height - imgH) \ 2, imgW, imgH)
                        With Game.actions.Counters(tmpInt)
                            If Shadow Then xg1.DrawString(": " & .Value, _Font, New Pen(Color.Black).Brush, prevRect.X + imgW + 2, prevRect.Y + (prevRect.Height - _Font.Height) \ 2 + 1)
                            xg1.DrawString(": " & .Value, _Font, New Pen(ForeColor).Brush, prevRect.X + imgW + 1, prevRect.Y + (prevRect.Height - _Font.Height) \ 2)
                        End With
                    Else
                        .FillRectangle(New Pen(Color.White).Brush, prevRect)
                        DrawString(GetString("error_CounterDoesntExist"), DefaultFont, New Pen(Color.Red).Brush, New RectangleF(prevRect.X - 500, prevRect.Y - 500, prevRect.Width + 1000, prevRect.Height + 1000))
                    End If
                End With
            End Sub
        End Class
#End Region

#Region "Image Counter"
        Public Class psImageCounter
            Inherits psUI.psControl

            Public imgW, imgH, Padding As Short

            Friend Overrides Sub Save()
                SaveBase()
                psFileHandler.bWriter.Write(imgW)
                psFileHandler.bWriter.Write(imgH)
                psFileHandler.bWriter.Write(Padding)
            End Sub

            Friend Overrides Sub Load()
                LoadBase()
                imgW = psFileHandler.bReader.ReadInt16
                imgH = psFileHandler.bReader.ReadInt16
                Padding = psFileHandler.bReader.ReadInt16
            End Sub

            Overrides Sub Init()
                InitBase()
                Text = GetString("counters_Score")
                Background = psBackground.NewSolidBackground( _
                    Color.FromArgb(255, 128, 128, 128))
                BorderColor = Color.LightGray
                Border3D = False
                Border = False
                Rectangle = New Rectangle(200, 100, 128, 64)
                imgW = 16
                imgH = 16
                Padding = 1
                Type = psCtrlType.ImageCounter
            End Sub

            Overrides Sub Draw()
                With Game.Drawing
                    .RelativeToCam = False
                    .AffectedByScrollSpeed = False
                    DrawBorder()
                    Dim R As Rectangle = Game.Drawing.GetClippingRect()
                    Game.Drawing.SetClippingRect(New Rectangle(Me.Rectangle.X, Me.Rectangle.Y, Me.Rectangle.Width, Me.Rectangle.Height))
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        If Game.InEditor AndAlso Game.actions.Counters(tmpInt).Value = 0 Then
                            Game.Drawing.DrawFilledBox(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Color.FromArgb(128, 255, 255, 255))
                            Game.Drawing.DrawText(GetString("windows_ImageCounterPlaceholder"), Rectangle, Color.Black)
                        Else
                            For i As Integer = 1 To Game.actions.Counters(tmpInt).Value
                                Background.Draw(X + (i - 1) * (imgW + Padding), Y + (Height - imgH) \ 2, imgW, imgH)
                            Next
                        End If
                    Else
                        Game.Drawing.DrawFilledBox(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, Color.White)
                        Game.Drawing.DrawText(String.Format(GetString("error_CounterDoesntExist"), Text), Rectangle, Color.Red, Microsoft.DirectX.Direct3D.DrawTextFormat.Left + Microsoft.DirectX.Direct3D.DrawTextFormat.VerticalCenter)
                    End If
                    Game.Drawing.SetClippingRect(R)
                End With
                If Game.InEditor Then DrawFooterBase()
            End Sub

            Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psImageCounter
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                    .imgW = imgW
                    .imgH = imgH
                    .Padding = Padding
                End With
                Return NewObj
            End Function

            Overrides Sub DrawPreview(ByRef pic As System.Windows.Forms.PictureBox, Optional ByVal picTrans As PictureBox = Nothing)
                DrawPreviewBase(pic)
                With xg1
                    DrawBorderPreview()
                    Dim tmpInt As Integer = GetCounter(Text)
                    If tmpInt > 0 Then
                        For i As Integer = 1 To Game.actions.Counters(tmpInt).Value
                            Background.Draw(xg1, prevRect.X + (i - 1) * (imgW + Padding), prevRect.Y + (prevRect.Height - imgH) \ 2, imgW, imgH)
                        Next
                    Else
                        .FillRectangle(New Pen(Color.White).Brush, prevRect)
                        DrawString(GetString("error_CounterDoesntExist"), DefaultFont, New Pen(Color.Red).Brush, New RectangleF(prevRect.X - 500, prevRect.Y - 500, prevRect.Width + 1000, prevRect.Height + 1000))
                    End If
                End With
            End Sub
        End Class
#End Region

#Region "Movie"
        Public Class psMovie
            Inherits psUI.psControl
            'Private Texture As Microsoft.DirectX.Direct3D.Texture
            'Private MissedFrames As Byte

            'Public AdvanceOnClick As Boolean
            'Public AdvanceWhenMovieStops As Boolean
            'Public AdvanceTo As String
            'Public LoopMovie As Boolean
            Public PressKeyToStop As Boolean
            Public Volume As Byte
            Public BlackBackground As Boolean
            Public PlayOnce As Boolean
            Public Played As Boolean

            Overrides Sub Init()
                InitBase()
                Rectangle = New Rectangle(200, 200, 128, 64)
                Background.Type = psBackground.BackgroundType.Picture
                Type = psCtrlType.Movie
                Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
                PressKeyToStop = True
                Volume = 100
                BlackBackground = False
                PlayOnce = False
                Played = False
                'CanHaveAction = True
            End Sub

            'Private Sub LoadMovie()
            '    Game.videoMissedFrames = 0

            '    'Load the movie if it is not loaded
            '    'or if the filename changed.
            '    If Game.video Is Nothing Or Game.videoFile <> Background.imgFilename Then
            '        If Not (Game.video Is Nothing) Then
            '            Game.StopMovie()
            '        End If
            '        If Background.imgFilename <> "" AndAlso IO.File.Exists(Background.imgFilename) Then
            '            Game.videoFile = Background.imgFilename
            '            Try
            '                Game.video = New Microsoft.DirectX.AudioVideoPlayback.Video(Background.imgFilename)
            '            Catch
            '                'Invalid file
            '                Exit Sub
            '            End Try
            '            Try
            '                Game.video.RenderToTexture(Game.Drawing.device)
            '            Catch
            '            End Try
            '        End If
            '    End If
            'End Sub

            Overrides Sub Draw()
                If Not Game.InEditor Then Exit Sub
                UpdateFont()
                With Game.Drawing
                    .DrawFilledBox(X, Y, Width, Height, Color.FromArgb(128, 255, 128, 0))
                    .DrawBox(X, Y, Width, Height, Color.Blue)
                    .DrawText(ID, GetString("windows_MoviePlaceholder"), New Rectangle(X + 1, Y + 1, Width, Height), Color.Black)
                    .DrawText(ID, GetString("windows_MoviePlaceholder"), New Rectangle(X, Y, Width, Height), Color.White)
                End With
                If Game.InEditor Then DrawFooterBase()

                'LoadMovie()

                ''Could not load movie
                ''(no file specified, invalid file, or other problem)
                'If Game.video Is Nothing Then DrawError() : Exit Sub

                ''When movie stops...
                ''Try
                ''    If Game.video.Playing = False Then
                ''        If LoopMovie OrElse Game.InEditor Then
                ''            'Loop
                ''            Game.video.RenderToTexture(Game.Drawing.device)
                ''        Else
                ''            'Or advance to the next window
                ''            '(if not in editor)
                ''            If AdvanceWhenMovieStops Then
                ''                For i As Integer = 1 To UBound(Game.windows.Windows)
                ''                    If Game.windows.Windows(i).Name = AdvanceTo Then
                ''                        Game.CurWinIndex = i
                ''                        Exit Sub
                ''                    End If
                ''                Next
                ''            End If
                ''        End If
                ''    End If
                ''Catch
                ''    Exit Sub
                ''End Try

                ''Draw only if we have a valid texture
                'If Game.videotex Is Nothing Then DrawError() : Exit Sub

                ''Draw the window
                'With Game.Drawing
                '    .RelativeToCam = False
                '    .AffectedByScrollSpeed = False
                '    DrawBorder()
                '    Try
                '        .DrawSprite(Game.videotex, X, Y, Width, Height, Color.White)
                '    Catch
                '    End Try
                'End With

                'If Game.InEditor Then DrawFooterBase()
            End Sub

            'Private Sub DrawError()
            '    With Game.Drawing
            '        .RelativeToCam = False
            '        .AffectedByScrollSpeed = False
            '        DrawBorder()
            '        .DrawFilledBox(X, Y, Width, Height, Color.Gray)
            '    End With
            'End Sub

            'Sub AutoSize()
            '    LoadMovie()
            '    If Game.video Is Nothing Then
            '        Width = 16
            '        Height = 16
            '    Else
            '        Width = Game.video.DefaultSize.Width
            '        Height = Game.video.DefaultSize.Height
            '    End If
            'End Sub

            Friend Overrides Sub Load()
                LoadBase()
                PressKeyToStop = psFileHandler.ReadBoolean
                Volume = psFileHandler.bReader.ReadByte
                BlackBackground = psFileHandler.ReadBoolean
                PlayOnce = psFileHandler.ReadBoolean
            End Sub

            Friend Overrides Sub Save()
                SaveBase()
                psFileHandler.bWriter.Write(PressKeyToStop)
                psFileHandler.bWriter.Write(Volume)
                psFileHandler.bWriter.Write(BlackBackground)
                psFileHandler.bWriter.Write(PlayOnce)
            End Sub

            Public Overrides Function Clone(ByVal CreateNewName As Boolean, ByVal MakeActive As Boolean) As Object
                Dim NewObj As New psMovie
                With NewObj
                    CloneBase(CreateNewName, NewObj, MakeActive)
                    .PressKeyToStop = PressKeyToStop
                    .Volume = Volume
                    .BlackBackground = BlackBackground
                    .PlayOnce = PlayOnce
                    .Played = False
                    '.AdvanceOnClick = AdvanceOnClick
                    '.AdvanceTo = AdvanceTo
                    '.AdvanceWhenMovieStops = AdvanceWhenMovieStops
                    '.LoopMovie = LoopMovie
                End With
                Return NewObj
            End Function
        End Class
#End Region

    End Class

    Public Class psWindows

#Region "Windows"

        Public Title As String
        Public Width As Integer, Height As Integer
        Public Windows() As psWindow
        Private _CurWinIndex As Short

        Sub set__CurWinIndex(ByVal Value As Integer)
            _CurWinIndex = Value
        End Sub

        Public Property CurWinIndex() As Short
            Get
                If _CurWinIndex < 1 Then _CurWinIndex = 1
                If _CurWinIndex > UBound(Windows) Then _CurWinIndex = UBound(Windows)
                Return _CurWinIndex
            End Get
            Set(ByVal Value As Short)
                For j As Integer = 1 To Windows(CurWinIndex).NumCtrls
                    With Windows(CurWinIndex).Controls(j)
                        .setMouseDown(False, False)
                        .setMouseInside(False, False)
                    End With
                Next
                _CurWinIndex = Value
            End Set
        End Property

        Friend Sub MakeInactive()
            Dim i As Integer, j As Integer
            For i = 1 To UBound(Windows)
                For j = 1 To Windows(i).NumCtrls
                    Windows(i).Controls(j).Active = False
                Next
            Next
            p = Nothing
        End Sub

        ReadOnly Property CurWindow() As psWindow
            Get
                If CurWinIndex > UBound(Windows) Then CurWinIndex = UBound(Windows)
                If CurWinIndex = 0 Then CurWinIndex = 1
                Try
                    Return Windows(CurWinIndex)
                Catch
                    Return Windows(1)
                End Try
            End Get
        End Property

        Function Clone(Optional ByVal MakeActive As Boolean = True, Optional ByVal ChangeNames As Boolean = False) As psWindows
            Dim tmpWindows As New psWindows, i As Integer
            With tmpWindows
                ._CurWinIndex = CurWinIndex
                .Title = Title
                .Width = Width
                .Height = Height
                ReDim .Windows(UBound(Windows))
                For i = 1 To UBound(Windows)
                    .Windows(i) = Windows(i).Clone(MakeActive, ChangeNames)
                Next
                If MakeActive Then .p = Game.p
            End With
            Return tmpWindows
        End Function

        Sub Init()
            ReDim Windows(0)
            Width = 450
            Height = 300
            p = Game.p
        End Sub

        Function GetDefaultBack() As psBackground
            Dim tmpBack As New psBackground
            tmpBack = psUI.psBackground.NewVGradientBackground(Color.DarkBlue, Color.Black)
            Return tmpBack
        End Function

        Function GetDefaultMenuBtn() As psControl.psButton
            Dim tmpMenuBtn As New psControl.psButton
            With tmpMenuBtn
                .Init()
                .Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                .RemoveName()
            End With
            Return tmpMenuBtn
        End Function

        Function GetDefaultMenuLbl() As psControl.psLabel
            Dim tmpMenuLbl As New psControl.psLabel
            With tmpMenuLbl
                .Init()
                .Font = New Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold)
                .RemoveName()
            End With
            Return tmpMenuLbl
        End Function

        Function GetDefaultGameBtn() As psControl.psButton
            Dim tmpGameBtn As New psControl.psButton
            With tmpGameBtn
                .Init()
                Dim Background As psUI.psBackground = .Background
                Dim Over As psUI.psBackground = .Over
                Dim Down As psUI.psBackground = .Down
                Background.Color1 = Color.FromArgb(64, Background.Color1.R, Background.Color1.G, Background.Color1.B)
                Over.Color1 = Color.FromArgb(64, Over.Color1.R, Over.Color1.G, Over.Color1.B)
                Down.Color1 = Color.FromArgb(64, Down.Color1.R, Down.Color1.G, Down.Color1.B)
                Background.Color2 = Color.FromArgb(128, Background.Color2.R, Background.Color2.G, Background.Color2.B)
                Over.Color2 = Color.FromArgb(128, Over.Color2.R, Over.Color2.G, Over.Color2.B)
                Down.Color2 = Color.FromArgb(128, Down.Color2.R, Down.Color2.G, Down.Color2.B)
                .Background = Background
                .Over = Over
                .Down = Down
                .RemoveName()
            End With
            Return tmpGameBtn
        End Function

        Sub CreateFromPreset(Optional ByVal AboutWindow As Boolean = True, Optional ByVal HelpFile As Boolean = False, Optional ByVal WebsiteBtn As Boolean = True, Optional ByVal SupportBtn As Boolean = True, Optional ByVal HelpText As String = "()")
            If (HelpText = "()") Then
                HelpText = GetString("defaultHelpText")
            End If
            CreateFromPreset(GetDefaultBack, GetDefaultMenuBtn, GetDefaultMenuLbl, GetDefaultGameBtn, AboutWindow, HelpFile, WebsiteBtn, SupportBtn, HelpText)
        End Sub

        Private Property GetLastCtl() As psControl
            Get
                Return Windows(UBound(Windows)).Controls(Windows(UBound(Windows)).NumCtrls)
            End Get
            Set(ByVal Value As psControl)
                Windows(UBound(Windows)).Controls(Windows(UBound(Windows)).NumCtrls) = Value
            End Set
        End Property

        Sub CreateFromPreset(ByVal defBack As psBackground, ByVal defMenuBtn As psControl.psButton, ByVal defMenuTitle As psControl.psLabel, ByVal defGameBtn As psControl.psButton, Optional ByVal AboutWindow As Boolean = True, Optional ByVal HelpFile As Boolean = False, Optional ByVal WebsiteBtn As Boolean = True, Optional ByVal SupportBtn As Boolean = True, Optional ByVal HelpText As String = "()")
            If (HelpText = "()") Then
                HelpText = GetString("defaultHelpText")
            End If
            Dim ww As Integer = Width, wh As Integer = Height

            Dim AboutWinNum As Integer, HelpWinNum As Integer
            If HelpFile = False Then
                HelpWinNum = 3
                AboutWinNum = 4
            Else
                AboutWinNum = 3
            End If

            'Main Menu window
            Erase Windows
            ReDim Windows(0)
            With NewWindow()
                Dim cw As Integer = 112, ch As Integer = 40 'ctrl w/h
                .Name = GetString("windows_Main")
                .Background = defBack.Clone
                .NewButton()
                GetLastCtl = defMenuTitle.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_MainLabel"))
                    .Text = "&GameName"
                    .Rectangle = New Rectangle(0, (wh - ch * 4 - 8 * 4 - 64) \ 2, ww, 64)
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_PlayButton"))
                    .Text = GetString("windows_PlayButtonText")
                    .Rectangle = New Rectangle((ww - cw) \ 2, (wh - ch * 4 - 8 * 4 - 64) \ 2 + 64 + 8, cw, ch)
                    Game.actions.AddAction("wcli" & .Name, "Show Window Index", "2")
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_HelpButton"))
                    .Text = GetString("windows_HelpButtonText")
                    .Rectangle = New Rectangle((ww - cw) \ 2, (wh - ch * 4 - 8 * 4 - 64) \ 2 + 64 + 8 * 2 + ch, cw, ch)
                    If HelpFile Then
                        Game.actions.AddAction("wcli" & .Name, "Open File", HelpText)
                    Else
                        Game.actions.AddAction("wcli" & .Name, "Show Window Index", "3")
                    End If
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_AboutButton"))
                    .Text = GetString("windows_AboutButtonText")
                    .Rectangle = New Rectangle((ww - cw) \ 2, (wh - ch * 4 - 8 * 4 - 64) \ 2 + 64 + 8 * 3 + ch * 2, cw, ch)
                    If AboutWindow Then
                        Game.actions.AddAction("wcli" & .Name, "Show Window Index", CStr(AboutWinNum))
                    Else
                        Game.actions.AddAction("wcli" & .Name, "Message Dialog", String.Format(GetString("windows_AboutDialogTitle"), "&GameName"), _
                            String.Format(GetString("windows_AboutDialogMessage"), "&GameName", "&Version", "&Credits", Today.Year, "&Company"))
                    End If
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_ExitButton"))
                    .Text = GetString("windows_ExitButtonText")
                    .Rectangle = New Rectangle((ww - cw) \ 2, (wh - ch * 4 - 8 * 4 - 64) \ 2 + 64 + 8 * 4 + ch * 3, cw, ch)
                    Game.actions.AddAction("wcli" & .Name, "Exit Program")
                End With
                .TransitionIn = psWindow.TransitionType.Random
                .TransitionInLength = 1
            End With

            'Game window
            With NewWindow()
                Dim cw As Integer = 72, ch As Integer = 24
                .Name = GetString("windows_GameWindow")
                .Background = defBack.Clone
                With .NewGame
                    .SetName(GetString("windows_GameArea"))
                    .Rectangle = New Rectangle(0, 0, ww, wh)
                End With
                .NewButton()
                GetLastCtl = defGameBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_PauseButton"))
                    .Text = GetString("windows_PauseButtonText")
                    .Rectangle = New Rectangle(ww - (8 + cw) * 2, wh - (8 + ch), cw, ch)
                    Game.actions.AddAction("wcli" & .Name, "Pause Game")
                End With
                .NewButton()
                GetLastCtl = defGameBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_QuitButton"))
                    .Text = GetString("windows_QuitButtonText")
                    .Rectangle = New Rectangle(ww - (8 + cw), wh - (8 + ch), cw, ch)
                    Game.actions.AddAction("wcli" & .Name, "Quit Game")
                End With
                With .NewTextCounter
                    .SetName(GetString("windows_ScoreCounter"))
                    .Text = GetString("counters_Score")
                    .Rectangle = New Rectangle(8, 8, 128, 16)
                    .Shadow = True
                End With
                With .NewTextCounter
                    .SetName(GetString("windows_LivesCounter"))
                    .Text = GetString("counters_Lives")
                    .Rectangle = New Rectangle(8, 32, 128, 16)
                    .Shadow = True
                End With
                With .NewTextCounter
                    .SetName(GetString("windows_HealthCounter"))
                    .Text = GetString("counters_Health")
                    .Rectangle = New Rectangle(8, 56, 128, 16)
                    .Shadow = True
                End With
                .TransitionIn = psWindow.TransitionType.Fade
                .TransitionInLength = 0.5
            End With

            'Help window
            If HelpFile = False Then
                With NewWindow()
                    .Name = GetString("windows_HelpWindow")
                    .Background = defBack.Clone
                    .NewButton()
                    GetLastCtl = defMenuTitle.Clone(True, True)
                    With GetLastCtl
                        .SetName(GetString("windows_HelpLabel"))
                        .Text = GetString("windows_HelpLabelText")
                        .Rectangle = New Rectangle(0, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2, ww, 64)
                    End With
                    With .NewLabel
                        .SetName(GetString("windows_HelpText"))
                        .Text = HelpText
                        .Rectangle = New Rectangle(0, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2 + 64 + 8, ww, (wh - 180))
                        .Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                        .ForeColor = defMenuTitle.ForeColor
                    End With
                    .NewButton()
                    GetLastCtl = defMenuBtn.Clone(True, True)
                    With GetLastCtl
                        .SetName(GetString("windows_HelpOKButton"))
                        .Text = GetString("windows_HelpOKButtonText")
                        .Rectangle = New Rectangle((ww - 112) \ 2, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2 + 64 + 8 + (wh - 180) + 8, 112, 40)
                        Game.actions.AddAction("wcli" & .Name, "Show Window Index", "1")
                    End With
                    .TransitionIn = psWindow.TransitionType.Fade
                    .TransitionInLength = 0.5
                End With
            End If

            'About window
            If AboutWindow Then
                With NewWindow()
                    .Name = GetString("windows_AboutWindow")
                    .Background = defBack.Clone
                    .NewButton()
                    GetLastCtl = defMenuTitle.Clone(True, True)
                    With GetLastCtl
                        .SetName(GetString("windows_AboutLabel"))
                        .Text = String.Format(GetString("windows_AboutLabelText"), "&GameName")
                        .Rectangle = New Rectangle(0, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2, ww, 64)
                    End With
                    With .NewLabel
                        .SetName(GetString("windows_AboutText"))
                        .Text = String.Format(GetString("windows_AboutDialogMessage"), "&GameName", "&Version", "&Credits", Today.Year, "&Company")
                        .Rectangle = New Rectangle(0, (wh - 64 - 8 - (wh - (wh - 180)) - 8 - 40) \ 2 + 64 + 8, ww, (wh - 180))
                        .Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                        .ForeColor = defMenuTitle.ForeColor
                    End With

                    Dim LeftBtnEdge As Integer = _
                        (ww - IIf(WebsiteBtn, 112 + 8, 0) - IIf(SupportBtn, 112 + 8, 0) - 112) \ 2
                    If WebsiteBtn Then
                        .NewButton()
                        GetLastCtl = defMenuBtn.Clone(True, True)
                        With GetLastCtl
                            .SetName(GetString("windows_WebsiteButton"))
                            .Text = GetString("windows_WebsiteButtonText")
                            .Rectangle = New Rectangle(LeftBtnEdge, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2 + 64 + 8 + (wh - 180) + 8, 112, 40)
                            Game.actions.AddAction("wcli" & .Name, "Open URL", Game.GameProperties.Website)
                        End With
                        LeftBtnEdge += 112 + 8
                    End If
                    If SupportBtn Then
                        .NewButton()
                        GetLastCtl = defMenuBtn.Clone(True, True)
                        With GetLastCtl
                            .SetName(GetString("windows_SupportButton"))
                            .Text = GetString("windows_SupportButtonText")
                            .Rectangle = New Rectangle(LeftBtnEdge, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2 + 64 + 8 + (wh - 180) + 8, 112, 40)
                            Game.actions.AddAction("wcli" & .Name, "Open URL", "mailto:" & Game.GameProperties.Support)
                        End With
                        LeftBtnEdge += 112 + 8
                    End If
                    .NewButton()
                    GetLastCtl = defMenuBtn.Clone(True, True)
                    With GetLastCtl
                        .SetName(GetString("windows_AboutOKButton"))
                        .Text = GetString("windows_AboutOKButtonText")
                        .Rectangle = New Rectangle(LeftBtnEdge, (wh - 64 - 8 - (wh - 180) - 8 - 40) \ 2 + 64 + 8 + (wh - 180) + 8, 112, 40)
                        Game.actions.AddAction("wcli" & .Name, "Show Window Index", "1")
                    End With
                    .TransitionIn = psWindow.TransitionType.Fade
                    .TransitionInLength = 0.5
                End With
            End If

            'Pause window
            With NewWindow()
                .Name = GetString("windows_PauseWindow")
                .Background = psUI.psBackground.NewSolidBackground(Color.FromArgb(128, 0, 0, 0))
                With .NewLabel
                    .SetName(GetString("windows_PauseLabel"))
                    .Text = GetString("windows_PauseText")
                    .Rectangle = New Rectangle(0, (wh - 100) \ 2, ww, 100)
                    .Font = New Font(FontFamily.GenericSansSerif, 18, FontStyle.Regular)
                    .ForeColor = defMenuTitle.ForeColor
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_ResumeButton"))
                    .Text = GetString("windows_ResumeText")
                    .Rectangle = New Rectangle((ww - 112) \ 2, (wh - 100) \ 2 + 132, 112, 40)
                    Game.actions.AddAction("wcli" & .Name, "Show Window Index", "2")
                End With
                .TransitionIn = psWindow.TransitionType.Fade
                .TransitionOut = psWindow.TransitionType.Fade
                .TransitionInLength = 0.5
                .TransitionOutLength = 0.5
            End With

            'Win window
            With NewWindow()
                .Name = GetString("windows_WinWindow")
                .Background = defBack.Clone
                With .NewLabel
                    .SetName(GetString("windows_WinLabel"))
                    .Text = GetString("windows_WinLabelText")
                    .Rectangle = New Rectangle(0, (wh - 100) \ 2, ww, 100)
                    .Font = New Font(FontFamily.GenericSansSerif, 18, FontStyle.Regular)
                    .ForeColor = defMenuTitle.ForeColor
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_WinOKButton"))
                    .Text = GetString("windows_WinOKButtonText")
                    .Rectangle = New Rectangle((ww - 112) \ 2, (wh - 100) \ 2 + 132, 112, 40)
                    Game.actions.AddAction("wcli" & .Name, "Show Window Index", "1")
                End With
                .TransitionIn = psWindow.TransitionType.Fade
                .TransitionInLength = 1
            End With

            'Lose window
            With NewWindow()
                .Name = GetString("windows_LoseWindow")
                .Background = defBack.Clone
                With .NewLabel
                    .SetName(GetString("windows_LoseLabel"))
                    .Text = GetString("windows_LoseLabelText")
                    .Rectangle = New Rectangle(0, (wh - 100) \ 2, ww, 100)
                    .Font = New Font(FontFamily.GenericSansSerif, 18, FontStyle.Regular)
                    .ForeColor = defMenuTitle.ForeColor
                End With
                .NewButton()
                GetLastCtl = defMenuBtn.Clone(True, True)
                With GetLastCtl
                    .SetName(GetString("windows_LoseOKButton"))
                    .Text = GetString("windows_LoseOKButtonText")
                    .Rectangle = New Rectangle((ww - 112) \ 2, (wh - 100) \ 2 + 132, 112, 40)
                    Game.actions.AddAction("wcli" & .Name, "Show Window Index", "1")
                End With
                .TransitionIn = psWindow.TransitionType.Fade
                .TransitionInLength = 1
            End With

            'Level Complete window
            With NewWindow()
                .Name = GetString("windows_LevelCompletedWindow")
                .Background = defBack.Clone
                With .NewLabel
                    .SetName(GetString("windows_LevelCompletedLabel"))
                    .Text = String.Format(GetString("windows_LevelCompletedLabelText"), "&LevelName")
                    .Rectangle = New Rectangle(0, (wh - 100) \ 2, ww, 100)
                    .Font = New Font(FontFamily.GenericSansSerif, 18, FontStyle.Regular)
                    .ForeColor = defMenuTitle.ForeColor
                End With
                .TransitionIn = psWindow.TransitionType.Fade
                .TransitionOut = psWindow.TransitionType.Fade
                .TransitionInLength = 1
                .TransitionOutLength = 1
                .TransitionAfter = 1.5
                .TransitionTo = 2
            End With
        End Sub

        Function NewWindow() As psWindow
            ReDim Preserve Windows(UBound(Windows) + 1)
            Windows(UBound(Windows)) = New psWindow
            Windows(UBound(Windows)).Init()
            Windows(UBound(Windows)).Name = String.Format(GetString("defaultWindowName"), UBound(Windows))
            If CurWinIndex = 0 Then CurWinIndex = 1
            Return Windows(UBound(Windows))
        End Function

        Sub Draw()
            CurWindow.Draw()
        End Sub

        Friend Sub Save()
            psFileHandler.FilePutString(Title)
            psFileHandler.bWriter.Write(Width)
            psFileHandler.bWriter.Write(Height)
            Dim i As Short
            i = UBound(Windows)
            psFileHandler.bWriter.Write(i)
            For i = 1 To UBound(Windows)
                Windows(i).Save()
            Next
        End Sub

        Friend Sub Load()
            psControl.ControlNames.Clear()
            psFileHandler.FileGetString(Title)
            Width = psFileHandler.bReader.ReadInt32
            Height = psFileHandler.bReader.ReadInt32
            Dim i As Short
            i = psFileHandler.bReader.ReadInt16
            ReDim Windows(i)
            For i = 1 To UBound(Windows)
                Windows(i) = New psWindow
                Windows(i).Load()
                If FileNotFoundCancel Then Exit Sub
            Next
            p = Game.p
        End Sub

        Sub RemoveWindow(ByVal index As Integer)
            For i As Integer = 1 To Windows(index).NumCtrls
                Windows(index).Controls(i).RemoveName()
            Next
            For i As Integer = index To UBound(Windows) - 1
                Windows(i) = Windows(i + 1).Clone
            Next
            ReDim Preserve Windows(UBound(Windows) - 1)
        End Sub

#Region "Mouse"
        Public WithEvents p As Control

        Private Sub p_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.MouseLeave
            Dim i As Integer
            For i = 1 To CurWindow.NumCtrls
                If CanCaptureMouse(CurWindow.Controls(i).Type) Then
                    CurWindow.Controls(i).setMouseInside(False, True)
                End If
            Next
            MouseOverHandled = False
        End Sub

        Private Sub p_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseMove
            'Dim i As Integer, j As Integer
            'For i = 1 To UBound(Deleted)
            '    If Deleted(i) = ID Then
            '        For j = i To UBound(Deleted) - 1
            '            Deleted(j) = Deleted(j + 1)
            '        Next
            '        ReDim Preserve Deleted(UBound(Deleted) - 1)
            '        Active = False
            '        Exit Sub
            '    End If
            'Next

            Dim i As Integer
            For i = 1 To CurWindow.NumCtrls
                If CanCaptureMouse(CurWindow.Controls(i).Type) Then
                    If Game.Math.Collide_PtBox(e.X, e.Y, CurWindow.Controls(i).Rectangle) Then
                        If MouseOverHandled = False Or MouseOverRect.ToString = CurWindow.Controls(i).Rectangle.ToString Then
                            CurWindow.Controls(i).setMouseInside(True, True)
                            MouseOverHandled = True
                            MouseOverRect = CurWindow.Controls(i).Rectangle
                        End If
                    Else
                        If CurWindow.Controls(i).MouseInside Then
                            MouseOverHandled = False
                            CurWindow.Controls(i).setMouseInside(False, True)
                        End If
                    End If
                End If
            Next
        End Sub

        Private Sub p_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseDown
            Dim i As Integer
            For i = 1 To CurWindow.NumCtrls
                If CanCaptureMouse(CurWindow.Controls(i).Type) Then
                    If CurWindow.Controls(i).MouseInside And e.Button = MouseButtons.Left Then
                        If ClickHandled = False Or CurWindow.Controls(i).Rectangle.ToString = ClickRect.ToString Then
                            CurWindow.Controls(i).setMouseDown(True, True)
                            ClickHandled = True
                            ClickRect = CurWindow.Controls(i).Rectangle
                        End If
                    End If
                End If
            Next
        End Sub

        Private Sub p_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p.MouseUp
            Dim ClickCtrl As Integer
            For i As Integer = 1 To CurWindow.NumCtrls
                If CanCaptureMouse(CurWindow.Controls(i).Type) Then
                    If CurWindow.Controls(i).MouseDown Then
                        CurWindow.Controls(i).setMouseDown(False, True)
                        ClickHandled = False
                        If CurWindow.Controls(i).MouseInside Then
                            'Click
                            ClickCtrl = i
                        End If
                    End If
                End If
            Next

            ''Reset controls' states
            'For i As Integer = 1 To UBound(CurWindow.Controls)
            '    CurWindow.Controls(i).setMouseDown(False, False)
            '    CurWindow.Controls(i).setMouseInside(False, False)
            'Next

            If ClickCtrl > 0 Then
                MouseOverHandled = False
                ClickHandled = False
                Game.ClickedControl(CurWindow.Controls(ClickCtrl), ClickCtrl)
                If Not Game.InEditor Then
                    If GamePlayer.f.RequestedClose Then
                        GamePlayer.f.DoClose()
                    End If
                End If
            End If
        End Sub

        Private Sub p_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles p.Click
            'MouseOverHandled = False
            'ClickHandled = False
            'Dim i As Integer
            'For i = 1 To UBound(CurWindow.Controls)
            '    If CanCaptureMouse(CurWindow.Controls(i).Type) Then
            '        If CurWindow.Controls(i).MouseInside And CurWindow.Controls(i)._MouseDownInside Then
            '            Game.ClickedControl(CurWindow.Controls(i), i)
            '            Exit Sub
            '        End If
            '    End If
            'Next
        End Sub

        ReadOnly Property ShiftDown() As Boolean
            Get
                Return ((Control.ModifierKeys And Keys.Shift) = 0)
            End Get
        End Property
#End Region

#End Region

        Public Class psWindow

#Region "Window"
            Public Name As String
            Private _Controls() As psControl
            Public Background As psBackground
            Public Music As String, Volume As Integer

            ReadOnly Property NumCtrls() As Integer
                Get
                    Return _Controls.Length - 1
                End Get
            End Property

            Default Property Controls(ByVal index As Integer) As psControl
                Get
                    Return _Controls(index)
                End Get
                Set(ByVal Value As psControl)
                    Dim dup As Boolean
                    If (_Controls(index) IsNot Nothing) Then
                        For i As Integer = 0 To UBound(_Controls) - 1
                            If (_Controls(i) IsNot Nothing AndAlso _Controls(i).Name = _Controls(index).Name AndAlso i <> index) Then
                                dup = True
                            End If
                        Next
                        If (_Controls(index).Name = Value.Name) Then
                            dup = True
                        End If
                    End If
                    If Not _Controls(index) Is Nothing AndAlso Not dup Then
                        _Controls(index).RemoveName()
                    End If
                    If Not Value.Name Is Nothing Then
                        If Not psControl.ControlNames.ContainsKey(Value.Name.ToLower) Then
                            psControl.ControlNames.Add(Value.Name.ToLower, Value.Name.ToLower)
                        End If
                    End If
                    _Controls(index) = Value
                End Set
            End Property

            Enum TransitionType As Byte
                None = 0
                Fade
                FadeThroughBlack
                FlipHorizontal
                FlipVertical
                RotateCCW
                RotateCW
                ZoomIn
                ZoomOut
                FlyLeft
                FlyRight
                FlyUp
                FlyDown
                DivideHorizontally
                DivideVertically
                DivideBoth
                Random
            End Enum
            Private _TransitionIn As Byte
            Property TransitionIn() As TransitionType
                Get
                    Return _TransitionIn
                End Get
                Set(ByVal Value As TransitionType)
                    _TransitionIn = Value
                End Set
            End Property
            Public TransitionInLength As Single
            Private _TransitionOut As Byte
            Property TransitionOut() As TransitionType
                Get
                    Return _TransitionOut
                End Get
                Set(ByVal Value As TransitionType)
                    _TransitionOut = Value
                End Set
            End Property
            Public TransitionOutLength As Single
            Public TransitionTo As Integer
            Public TransitionAfter As Single

            Function Clone(Optional ByVal MakeActive As Boolean = True, Optional ByVal ChangeNames As Boolean = False) As psWindow
                Dim tmpWindow As New psWindow, i As Integer
                With tmpWindow
                    .Name = Name
                    .TransitionAfter = TransitionAfter
                    .TransitionIn = TransitionIn
                    .TransitionInLength = TransitionInLength
                    .TransitionOut = TransitionOut
                    .TransitionOutLength = TransitionOutLength
                    .TransitionTo = TransitionTo
                    .Background = Background.Clone
                    .Music = Music
                    .Volume = Volume
                    ReDim ._Controls(NumCtrls)
                    For i = 1 To NumCtrls
                        .Controls(i) = Controls(i).Clone(ChangeNames, MakeActive)
                    Next
                End With
                Return tmpWindow
            End Function

            Function NewButton() As psControl.psButton
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psButton
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewLabel() As psControl.psLabel
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psLabel
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewGame() As psControl.psGameCtl
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psGameCtl
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewImage() As psControl.psImage
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psImage
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewTextCounter() As psControl.psTextCounter
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psTextCounter
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewImageTextCounter() As psControl.psImageTextCounter
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psImageTextCounter
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewImageCounter() As psControl.psImageCounter
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psImageCounter
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewHighScoresArea() As psControl.psHighScoresArea
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psHighScoresArea
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewMovie() As psControl.psMovie
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = New psControl.psMovie
                Controls(NumCtrls).Init()
                Return Controls(NumCtrls)
            End Function

            Function NewControl(ByVal ctrl As psControl) As psControl
                ReDim Preserve _Controls(NumCtrls + 1)
                Controls(NumCtrls) = ctrl.Clone(False, True)
                Return Controls(NumCtrls)
            End Function

            Sub RemoveControl(ByVal index As Integer)
                _Controls(index).RemoveName()
                For i As Integer = index To NumCtrls - 1
                    Controls(i) = Controls(i + 1) '.Clone
                Next
                ReDim Preserve _Controls(NumCtrls - 1)
            End Sub

            Sub Init()
                ReDim _Controls(0)
                Background = psBackground.NewSolidBackground( _
                    Color.Black)
                TransitionInLength = 1
                TransitionOutLength = 1
                TransitionAfter = 3
            End Sub

            Sub Draw(Optional ByVal Grid As Boolean = False)
                Dim i As Short
                Game.Drawing.RelativeToCam = False
                Game.Drawing.AffectedByScrollSpeed = False
                Background.Draw(0, 0, Game.windows.Width, Game.windows.Height)
                If Grid Then drawGrid()
                For i = 1 To NumCtrls
                    Controls(i).Draw()
                Next
            End Sub

            Private Sub drawGrid()
                Dim i As Integer
                With Game.Drawing
                    'Draw grid
                    Dim X(), Y() As Integer, Colors() As Color
                    ReDim X(0), Y(0), Colors(0)
                    If Options.wGridLines Then
                        If Options.wShowGrid And Options.wGridSpacing >= 4 Then
                            For i = 0 To Game.windows.Width Step Options.wGridSpacing
                                ReDim Preserve X(UBound(X) + 4), Y(UBound(Y) + 4), Colors(UBound(Colors) + 4)

                                X(UBound(X) - 3) = i
                                Y(UBound(Y) - 3) = 0
                                Colors(UBound(Colors) - 3) = Color.FromArgb(64, 255, 255, 255)
                                X(UBound(X) - 2) = i
                                Y(UBound(Y) - 2) = Game.windows.Height
                                Colors(UBound(Colors) - 2) = Colors(UBound(Colors) - 3)

                                X(UBound(X) - 1) = i + 1
                                Y(UBound(Y) - 1) = 0
                                Colors(UBound(Colors) - 1) = Color.FromArgb(64, 0, 0, 0)
                                X(UBound(X)) = i + 1
                                Y(UBound(Y)) = Game.windows.Height
                                Colors(UBound(Colors)) = Colors(UBound(Colors) - 1)

                                '.DrawLine(i, 0, i, Game.windows.Height, Color.FromArgb(64, 255, 255, 255))
                                '.DrawLine(i + 1, 0, i + 1, Game.windows.Height, Color.FromArgb(64, 0, 0, 0))
                            Next
                            .DrawLineList(X, Y, Colors)

                            ReDim X(0), Y(0), Colors(0)
                            For i = 0 To Game.windows.Height Step Options.wGridSpacing
                                ReDim Preserve X(UBound(X) + 4), Y(UBound(Y) + 4), Colors(UBound(Colors) + 4)

                                X(UBound(X) - 3) = 0
                                Y(UBound(Y) - 3) = i
                                Colors(UBound(Colors) - 3) = Color.FromArgb(64, 255, 255, 255)
                                X(UBound(X) - 2) = Game.windows.Width
                                Y(UBound(Y) - 2) = i
                                Colors(UBound(Colors) - 2) = Colors(UBound(Colors) - 3)

                                X(UBound(X) - 1) = 0
                                Y(UBound(Y) - 1) = i + 1
                                Colors(UBound(Colors) - 1) = Color.FromArgb(64, 0, 0, 0)
                                X(UBound(X)) = Game.windows.Width
                                Y(UBound(Y)) = i + 1
                                Colors(UBound(Colors)) = Colors(UBound(Colors) - 1)

                                '.DrawLine(0, i, Game.windows.Width, i, Color.FromArgb(64, 255, 255, 255))
                                '.DrawLine(0, i + 1, Game.windows.Width, i + 1, Color.FromArgb(64, 0, 0, 0))
                            Next
                            .DrawLineList(X, Y, Colors)
                        End If
                    Else
                        ReDim X((Game.windows.Width \ Options.wGridSpacing) * (Game.windows.Height \ Options.wGridSpacing) * 2), Y(UBound(X)), Colors(UBound(X))
                        Dim cnt As Integer = 0
                        For i = Options.wGridSpacing To Game.windows.Width Step Options.wGridSpacing
                            For j As Integer = Options.wGridSpacing To Game.windows.Height Step Options.wGridSpacing
                                cnt += 1
                                X(cnt) = i
                                Y(cnt) = j
                                Colors(cnt) = Color.FromArgb(192, 255, 255, 255)
                                cnt += 1
                                X(cnt) = i + 1
                                Y(cnt) = j + 1
                                Colors(cnt) = Color.FromArgb(192, 0, 0, 0)
                            Next
                        Next
                        .DrawPointList(X, Y, Colors)
                    End If
                End With
            End Sub

            Friend Sub Save()
                psFileHandler.FilePutString(Name)
                psFileHandler.FilePutString(Music)
                psFileHandler.bWriter.Write(Volume)
                psFileHandler.bWriter.Write(TransitionAfter)
                psFileHandler.bWriter.Write(_TransitionIn)
                psFileHandler.bWriter.Write(TransitionInLength)
                psFileHandler.bWriter.Write(_TransitionOut)
                psFileHandler.bWriter.Write(TransitionOutLength)
                psFileHandler.bWriter.Write(TransitionTo)
                Background.Save()
                Dim i As Short
                i = NumCtrls
                psFileHandler.bWriter.Write(i)
                For i = 1 To NumCtrls
                    psFileHandler.bWriter.Write(CByte(Controls(i).Type))
                    Controls(i).Save()
                Next
            End Sub

            Friend Sub Load()
                psFileHandler.FileGetString(Name)
                psFileHandler.FileGetString(Music)
                Volume = psFileHandler.bReader.ReadInt32()
                TransitionAfter = psFileHandler.bReader.ReadSingle()
                _TransitionIn = psFileHandler.bReader.ReadByte()
                TransitionInLength = psFileHandler.bReader.ReadSingle()
                _TransitionOut = psFileHandler.bReader.ReadByte()
                TransitionOutLength = psFileHandler.bReader.ReadSingle()
                TransitionTo = psFileHandler.bReader.ReadInt32()

                Background.Load()
                Dim i As Short
                i = psFileHandler.bReader.ReadInt16
                ReDim _Controls(i)
                For i = 1 To NumCtrls
                    Dim b As Byte
                    b = psFileHandler.bReader.ReadByte
                    Select Case b
                        Case 0 : Controls(i) = New psControl.psButton
                        Case 1 : Controls(i) = New psControl.psLabel
                        Case 2 : Controls(i) = New psControl.psImage
                        Case 3 : Controls(i) = New psControl.psGameCtl
                        Case 4 : Controls(i) = New psControl.psTextCounter
                        Case 5 : Controls(i) = New psControl.psImageTextCounter
                        Case 6 : Controls(i) = New psControl.psImageCounter
                        Case 7 : Controls(i) = New psControl.psHighScoresArea
                        Case 8 : Controls(i) = New psControl.psMovie
                    End Select
                    Controls(i).Init()
                    Controls(i).Load()
                    If FileNotFoundCancel Then Exit Sub
                Next
            End Sub
#End Region

        End Class
    End Class
End Namespace