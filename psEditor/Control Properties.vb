Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports PlatformStudio

#Region "WindowWrapper"
Class WindowWrapper
    Private w As psUI.psWindows.psWindow

    Public index As Integer
    Public p As PropertyGrid

    Sub New(ByVal window As psUI.psWindows.psWindow)
        w = window
    End Sub

    Protected Sub updateUndoOnce(ByVal propName As String)
        If ControlWrapper.shouldUpdateUndo Then
            UndoRedo.UpdateUndo(String.Format(GetString("undoActionChangedProperty"), propName), ControlWrapper.undoType, ControlWrapper.level, ControlWrapper.layer)
            ControlWrapper.shouldUpdateUndo = False
            psFileHandler.MadeChanges = True
        End If
    End Sub

    Protected Sub afterEdit()
        p.SelectedObjects(index) = New PropDispNameWrapper(w)
    End Sub

    <Category("Window"), _
    Description("Name of the window"), _
    ParenthesizePropertyNameAttribute(True)> _
    Property Name() As String
        Get
            Return w.Name
        End Get
        Set(ByVal Value As String)
            For i As Integer = 1 To UBound(Game.windows.Windows)
                If Game.windows.Windows(i).Name = Value AndAlso i <> Game.CurWinIndex Then
                    MessageBox.Show(GetString("windowAlreadyExistsMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            Next
            updateUndoOnce("Window name")
            w.Name = Value
            Editor.winsel.doNotUpdate = True
            Editor.winsel.ListBox1.Items(Game.CurWinIndex - 1) = Value
            Editor.winsel.doNotUpdate = False
            afterEdit()
        End Set
    End Property

    <Category("Window"), _
    Description("Background of the window"), _
    Editor(GetType(BackgroundEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property Background() As psUI.psBackground
        Get
            Return w.Background
        End Get
        Set(ByVal Value As psUI.psBackground)
            updateUndoOnce("Window background")
            w.Background = Value
            afterEdit()
        End Set
    End Property

    <Category("Window"), _
    Description("Background music of the window."), _
    Editor(GetType(MusicEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property Music() As Music
        Get
            Return New Music(w.Music, w.Volume)
        End Get
        Set(ByVal Value As Music)
            updateUndoOnce("Window music")
            w.Music = Value.File
            w.Volume = Value.Volume
            afterEdit()
        End Set
    End Property

    <Category("Window"), _
    Description("Specifies the transitions for the current window."), _
    Editor(GetType(TransitionEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property Transition() As Transition
        Get
            Return New Transition(w.TransitionIn, w.TransitionInLength, w.TransitionTo, w.TransitionAfter, w.TransitionOut, w.TransitionOutLength)
        End Get
        Set(ByVal Value As Transition)
            updateUndoOnce("Window transition")
            w.TransitionIn = Value.In
            w.TransitionInLength = Value.InLen
            w.TransitionTo = Value.To
            w.TransitionAfter = Value.TransitionAfter
            w.TransitionOut = Value.Out
            w.TransitionOutLength = Value.OutLen
            afterEdit()
        End Set
    End Property
End Class
#End Region

#Region "ControlWrapper"
Public Class ControlWrapper
    Public Shared shouldUpdateUndo As Boolean = True
    Public Shared undoType As UndoRedo.UndoType
    Public Shared layer, level As Integer

    Public index As Integer
    Public p As PropertyGrid

    Protected c As psUI.psControl

    Sub New(ByVal ctl As psUI.psControl)
        c = ctl
    End Sub

    Function Unwrap() As psUI.psControl
        Return c
    End Function

    Protected Sub updateUndoOnce(ByVal propName As String)
        If shouldUpdateUndo Then
            If undoType = UndoRedo.UndoType.None Then Return
            UndoRedo.UpdateUndo(String.Format(GetString("undoActionChangedProperty"), propName), undoType, level, layer)
            shouldUpdateUndo = False
            psFileHandler.MadeChanges = True
        End If
    End Sub

    Protected Sub afterEdit()
        If p Is Nothing Then Return
        p.SelectedObjects(index) = New PropDispNameWrapper(c)
    End Sub

    <Category("Actions"), _
    Description("Provides a way of identifying the control when using scripting.  If you are not using scripting or do not need to access this control's properties, you can ignore this."), _
    ParenthesizePropertyName(True), _
    DynamicReadOnly("ButtonWrapper.Action")> _
    Overridable Property Name() As String
        Get
            Return c.Name
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then

                Dim ex As New ArgumentException(GetString("nameFormatErrorMessage"))
                If Not (Char.IsLetter(Value.Chars(0)) Or (Value.Chars(0) = "_" AndAlso Value.Length > 1)) Then
                    Throw ex
                End If
                For i As Integer = 1 To Value.Length - 1
                    If Not (Char.IsNumber(Value.Chars(i)) Or Char.IsLetter(Value.Chars(i)) Or Value.Chars(i) = "_") Then
                        Throw ex
                    End If
                Next

                CodeEditor.InitKeywords()
                Dim tmpValue As String = Value.ToLower
                If CodeEditor.Keywords.Contains(tmpValue) Or CodeEditor.ReservedWords.Contains(tmpValue) Then
                    Throw New ArgumentException(GetString("nameIsReservedWordErrorMessage"))
                End If

                For i As Integer = 1 To UBound(Game.windows.Windows)
                    For j As Integer = 1 To Game.windows.Windows(i).NumCtrls
                        If (Not Game.windows.Windows(i).Controls(j).Name Is Nothing) AndAlso Game.windows.Windows(i).Controls(j).Name.ToLower = tmpValue Then
                            Throw New ArgumentException(GetString("nameInUseErrorMessage"))
                        End If
                    Next
                Next

            Else

                Value = c.createName

            End If

            updateUndoOnce("Name")

            'Rename actions
            For i As Integer = 1 To UBound(Game.actions.Actions)
                If Game.actions.Actions(i).Trigger = "wcli" & c.Name Then
                    Game.actions.Actions(i).Trigger = "wcli" & Value
                End If
            Next

            c.RemoveName()
            c.Name = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    Description("The text of the control."), _
    Editor(GetType(MultilineEditor), GetType(Drawing.Design.UITypeEditor))> _
    Overridable Property Text() As String
        Get
            Return c.Text
        End Get
        Set(ByVal Value As String)
            updateUndoOnce("Text")
            c.Text = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    Description("The font of the control.")> _
    Overridable Property Font() As Font
        Get
            Return c.Font
        End Get
        Set(ByVal Value As Font)
            updateUndoOnce("Font")
            c.Font = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    Description("The color of the text of the control."), _
    DisplayName("Text color")> _
    Overridable Property TextColor() As Color
        Get
            Return c.ForeColor
        End Get
        Set(ByVal Value As Color)
            updateUndoOnce("Text color")
            c.ForeColor = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    DefaultValue(False), _
    Description("Specifies whether the control should display a shadow under its text.")> _
    Overridable Property Shadow() As Boolean
        Get
            Return c.Shadow
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Shadow")
            c.Shadow = Value
            afterEdit()
        End Set
    End Property

    <Category("Background"), _
    Description("The background of the control."), _
    Editor(GetType(BackgroundEditor), GetType(Drawing.Design.UITypeEditor))> _
    Overridable Property Background() As psUI.psBackground
        Get
            Return c.Background
        End Get
        Set(ByVal Value As psUI.psBackground)
            updateUndoOnce("Background")
            c.Background = Value
            afterEdit()
        End Set
    End Property

    <Category("Border"), _
    Description("The color of the border of the control."), _
    DisplayName("Border color")> _
    Overridable Property BorderColor() As Color
        Get
            Return c.BorderColor
        End Get
        Set(ByVal Value As Color)
            updateUndoOnce("Border color")
            c.BorderColor = Value
            afterEdit()
        End Set
    End Property

    <Category("Border"), _
    Description("Specifies what type of border to draw."), _
    DisplayName("Border style"), _
    DefaultValue("None"), _
    TypeConverter(GetType(BorderStyleConverter))> _
    Overridable Property BorderStyle() As String
        Get
            If c.Border Then
                If c.Border3D Then
                    Return "3D"
                Else
                    Return "Flat"
                End If
            Else
                Return "None"
            End If
        End Get
        Set(ByVal Value As String)
            updateUndoOnce("Border style")
            If Value = "None" Then
                c.Border = False
            Else
                c.Border = True
                c.Border3D = (Value = "3D")
            End If
            afterEdit()
        End Set
    End Property

    <Category("Layout"), _
    Description("Specifies the X coordinate of the control.")> _
    Overridable Property X() As Integer
        Get
            Return c.X
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 OrElse Value >= Game.windows.Width Then
                Throw New ArgumentException
            End If
            updateUndoOnce("X")
            c.X = Value
            If Editor.winedit.NumSelCtrls = 1 Then
                Editor.winedit.ms.SetRect(c.Rectangle)
            End If
            afterEdit()
        End Set
    End Property

    <Category("Layout"), _
    Description("Specifies the Y coordinate of the control.")> _
    Overridable Property Y() As Integer
        Get
            Return c.Y
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 OrElse Value >= Game.windows.Height Then
                Throw New ArgumentException
            End If
            updateUndoOnce("Y")
            c.Y = Value
            If Editor.winedit.NumSelCtrls = 1 Then
                Editor.winedit.ms.SetRect(c.Rectangle)
            End If
            afterEdit()
        End Set
    End Property

    <Category("Layout"), _
    Description("Specifies the width of the control.")> _
    Overridable Property Width() As Integer
        Get
            Return c.Width
        End Get
        Set(ByVal Value As Integer)
            If Value <= 8 OrElse Value >= Game.windows.Width Then
                Throw New ArgumentException
            End If
            updateUndoOnce("Width")
            c.Width = Value
            If Editor.winedit.NumSelCtrls = 1 Then
                Editor.winedit.ms.SetRect(c.Rectangle)
            End If
            afterEdit()
        End Set
    End Property

    <Category("Layout"), _
    Description("Specifies the height of the control.")> _
    Overridable Property Height() As Integer
        Get
            Return c.Height
        End Get
        Set(ByVal Value As Integer)
            If Value <= 8 OrElse Value >= Game.windows.Height Then
                Throw New ArgumentException
            End If
            updateUndoOnce("Height")
            c.Height = Value
            If Editor.winedit.NumSelCtrls = 1 Then
                Editor.winedit.ms.SetRect(c.Rectangle)
            End If
            afterEdit()
        End Set
    End Property

    Class BorderStyleConverter
        Inherits ChoicesConverter

        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
            Return New StandardValuesCollection( _
                New String() {"None", "3D", "Flat"})
        End Function
    End Class
End Class
#End Region

#Region "ButtonWrapper"
Public Class ButtonWrapper
    Inherits ControlWrapper

    Sub New(ByVal ctl As psUI.psControl.psButton)
        MyBase.New(ctl)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psButton
        Get
            Return DirectCast(c, psUI.psControl.psButton)
        End Get
    End Property

    <Category("Actions"), _
    Description("Provides a way of identifying the control when giving it actions or when referring to it in a script."), _
    ParenthesizePropertyName(True), _
    DynamicReadOnly("ButtonWrapper.Action")> _
    Overrides Property Name() As String
        Get
            Return MyBase.Name
        End Get
        Set(ByVal Value As String)
            MyBase.Name = Value
        End Set
    End Property

    <Category("Border"), _
    Description("Specifies what type of border to draw."), _
    DisplayName("Border style"), _
    DefaultValue("3D"), _
    TypeConverter(GetType(BorderStyleConverter))> _
    Overrides Property BorderStyle() As String
        Get
            Return MyBase.BorderStyle
        End Get
        Set(ByVal Value As String)
            MyBase.BorderStyle = Value
        End Set
    End Property

    <Category("Rollover"), _
    Description("The background of the Rollover state of the button."), _
    Editor(GetType(BackgroundEditor), GetType(Drawing.Design.UITypeEditor)), _
    DisplayName("Background")> _
    Property Rollover() As psUI.psBackground
        Get
            Return getC.Over
        End Get
        Set(ByVal Value As psUI.psBackground)
            updateUndoOnce("Rollover background")
            getC.Over = Value
            afterEdit()
        End Set
    End Property

    <Category("Rollover"), _
    Description("The animation effect to display when the mouse rolls over the button."), _
    DefaultValue(GetType(psUI.psControl.psButton.Effect), "Fade"), _
    DisplayName("Animation")> _
    Property RolloverAnimation() As psUI.psControl.psButton.Effect
        Get
            Return getC.RolloverEffect
        End Get
        Set(ByVal Value As psUI.psControl.psButton.Effect)
            updateUndoOnce("Rollover animation")
            getC.RolloverEffect = Value
            afterEdit()
        End Set
    End Property

    <Category("Rollover"), _
    Description("The length of the rollover animation in seconds."), _
    DefaultValue(0.3F), _
    DisplayName("Length")> _
    Property RolloverLength() As Single
        Get
            Return getC.RolloverEffectLength
        End Get
        Set(ByVal Value As Single)
            updateUndoOnce("Rollover anim. length")
            getC.RolloverEffectLength = Value
            afterEdit()
        End Set
    End Property

    <Category("Pressed"), _
    Description("The background of the Pressed state of the button."), _
    Editor(GetType(BackgroundEditor), GetType(Drawing.Design.UITypeEditor)), _
    DisplayName("Background")> _
    Property Pressed() As psUI.psBackground
        Get
            Return getC.Down
        End Get
        Set(ByVal Value As psUI.psBackground)
            updateUndoOnce("Pressed background")
            getC.Down = Value
            afterEdit()
        End Set
    End Property

    <Category("Pressed"), _
    Description("The animation effect to display when the user holds the left mouse button down on the button."), _
    DefaultValue(GetType(psUI.psControl.psButton.Effect), "FadeOutOnly"), _
    DisplayName("Animation")> _
    Property PressedAnimation() As psUI.psControl.psButton.Effect
        Get
            Return getC.PushEffect
        End Get
        Set(ByVal Value As psUI.psControl.psButton.Effect)
            updateUndoOnce("Pressed animation")
            getC.PushEffect = Value
            afterEdit()
        End Set
    End Property

    <Category("Pressed"), _
    Description("The length of the pressed animation in seconds."), _
    DefaultValue(0.3F), _
    DisplayName("Length")> _
    Property PressedLength() As Single
        Get
            Return getC.PushEffectLength
        End Get
        Set(ByVal Value As Single)
            updateUndoOnce("Pressed anim. length")
            getC.PushEffectLength = Value
            afterEdit()
        End Set
    End Property

    <Category("Actions"), _
    Description("The action to perform when the user clicks the button."), _
    DefaultValue("(None)"), _
    DisplayName("Action"), _
    Editor(GetType(ControlActionEditor), GetType(Drawing.Design.UITypeEditor)), _
    DynamicReadOnly("ButtonWrapper.Action")> _
    Property Action() As String
        Get
            For i As Integer = 1 To UBound(Game.actions.Actions)
                If Game.actions.Actions(i).Trigger = "wcli" & Editor.winedit.SelCtrls(1).Name Then
                    Return Game.actions.Actions(i).Action.Behavior.Name
                End If
            Next
            Return "(None)"
        End Get
        Set(ByVal Value As String)
            '
        End Set
    End Property
End Class
#End Region

#Region "GameEditorWrapper"
Class GameEditorWrapper
    Inherits ControlWrapper

    Sub New(ByVal c As psUI.psControl.psGameCtl)
        MyBase.New(c)
    End Sub

    <Browsable(False)> _
    Public Overrides Property Background() As PlatformStudio.psUI.psBackground
        Get
            Return Nothing
        End Get
        Set(ByVal Value As PlatformStudio.psUI.psBackground)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property BorderColor() As System.Drawing.Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Color)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property BorderStyle() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Font)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Shadow() As Boolean
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Boolean)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property TextColor() As System.Drawing.Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Color)
        End Set
    End Property
End Class
#End Region

#Region "HighScoresWrapper"
Class HighScoresWrapper
    Inherits ControlWrapper

    Sub New(ByVal c As psUI.psControl.psHighScoresArea)
        MyBase.New(c)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psHighScoresArea
        Get
            Return DirectCast(c, psUI.psControl.psHighScoresArea)
        End Get
    End Property

    <Browsable(False)> _
    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Font)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Shadow() As Boolean
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Boolean)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property BorderStyle() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Category("Foreground"), _
    Description("Specifies the number of scores to display."), _
    DisplayName("Number of scores"), _
    DefaultValue(10)> _
    Property NumberOfScores() As Integer
        Get
            Return getC.NumberOfScores
        End Get
        Set(ByVal Value As Integer)
            If Value < 1 Or Value > 20 Then
                Throw New ArgumentException
            End If
            updateUndoOnce("Num. scores")
            getC.NumberOfScores = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    Description("Specifies whether to display the names of the people on the high scores list.  If this is set to false, JumpCraft will not prompt for a name when a high score is achieved."), _
    DisplayName("Show names"), _
    DefaultValue(True)> _
    Property ShowNames() As Boolean
        Get
            Return getC.ShowName
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Show names")
            getC.ShowName = Value
            afterEdit()
        End Set
    End Property

    <Category("Foreground"), _
    Description("Specifies whether to display the level reached at the end of the game for each high score entry."), _
    DisplayName("Show level"), _
    DefaultValue(True)> _
    Property ShowLevel() As Boolean
        Get
            Return getC.ShowLevel
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Show level")
            getC.ShowLevel = Value
            afterEdit()
        End Set
    End Property
End Class
#End Region

#Region "LabelWrapper"
Class LabelWrapper
    Inherits ControlWrapper

    Sub New(ByVal c As psUI.psControl.psLabel)
        MyBase.New(c)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psLabel
        Get
            Return DirectCast(c, psUI.psControl.psLabel)
        End Get
    End Property
End Class
#End Region

#Region "ImageWrapper"
Class ImageWrapper
    Inherits ControlWrapper

    Sub New(ByVal c As psUI.psControl.psLabel)
        MyBase.New(c)
    End Sub

    <Browsable(False)> _
    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Font)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Shadow() As Boolean
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Boolean)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property TextColor() As System.Drawing.Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Color)
        End Set
    End Property
End Class
#End Region

#Region "MovieWrapper"
Class MovieWrapper
    Inherits ControlWrapper

    Sub New(ByVal c As psUI.psControl.psMovie)
        MyBase.New(c)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psMovie
        Get
            Return DirectCast(c, psUI.psControl.psMovie)
        End Get
    End Property

    <Category("Movie"), _
    Description("The file that contains the movie to display."), _
    Editor(GetType(MovieFileNamEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property File() As String
        Get
            Return getC.GetBackground.imgFilename
        End Get
        Set(ByVal Value As String)
            updateUndoOnce("Movie file")
            Dim Background As psUI.psBackground = getC.Background
            Background.imgFilename = Value
            getC.Background = Background
            afterEdit()
        End Set
    End Property

    <Category("Movie"), _
    DefaultValue("100%"), _
    Description("The volume of the movie.")> _
    Property Volume() As String
        Get
            Return getC.Volume & "%"
        End Get
        Set(ByVal Value As String)
            Value = Value.Trim(" ", "%")
            If Not IsNumeric(Value) OrElse Value < 0 OrElse Value > 100 Then
                Throw New ArgumentException
            End If
            updateUndoOnce("Volume")
            getC.Volume = CInt(Value)
            afterEdit()
        End Set
    End Property

    <Category("Movie"), _
    Description("Specifies whether to clear the background around the movie."), _
    DefaultValue(False), _
    DisplayName("Black background")> _
    Property BlackBackground() As Boolean
        Get
            Return getC.BlackBackground
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Black background")
            getC.BlackBackground = Value
            afterEdit()
        End Set
    End Property

    <Category("Movie"), _
    Description("Specifies whether to allow the user to press a key to stop the movie and continue the game."), _
    DefaultValue(True), _
    DisplayName("Press key to stop")> _
    Property PressKeyToStop() As Boolean
        Get
            Return getC.PressKeyToStop
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Press key to stop")
            getC.PressKeyToStop = Value
            afterEdit()
        End Set
    End Property

    <Category("Movie"), _
    Description("Specifies whether to limit playback of the movie to a maximum of one time while the application is running."), _
    DefaultValue(False), _
    DisplayName("Play once")> _
    Property PlayOnce() As Boolean
        Get
            Return getC.PlayOnce
        End Get
        Set(ByVal Value As Boolean)
            updateUndoOnce("Play once")
            getC.PlayOnce = Value
            afterEdit()
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Background() As PlatformStudio.psUI.psBackground
        Get
            Return Nothing
        End Get
        Set(ByVal Value As PlatformStudio.psUI.psBackground)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property BorderColor() As System.Drawing.Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Color)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property BorderStyle() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Font() As System.Drawing.Font
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Font)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Shadow() As Boolean
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Boolean)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Browsable(False)> _
    Public Overrides Property TextColor() As System.Drawing.Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As System.Drawing.Color)
        End Set
    End Property
End Class
#End Region

#Region "TextCounterWrapper"
Public Class TextCounterWrapper
    Inherits ControlWrapper

    Sub New(ByVal ctl As psUI.psControl)
        MyBase.New(ctl)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psTextCounter
        Get
            Return DirectCast(c, psUI.psControl.psTextCounter)
        End Get
    End Property

    <Browsable(False)> _
    Overrides Property Text() As String
        Get
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    <Category("Foreground"), _
    Description("The counter to display."), _
    TypeConverter(GetType(CounterConverter))> _
    Overridable Property Counter() As String
        Get
            Return c.Text
        End Get
        Set(ByVal Value As String)
            If Value = "(Edit counters...)" Then
                Dim f As New psfrmCounters
                f.ShowDialog()
                f.Dispose()
            Else
                updateUndoOnce("Counter")
                c.Text = Value
                afterEdit()
            End If
        End Set
    End Property
End Class
#End Region

#Region "ImageTextCounterWrapper"
Public Class ImageTextCounterWrapper
    Inherits TextCounterWrapper

    Sub New(ByVal ctl As psUI.psControl)
        MyBase.New(ctl)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psImageTextCounter
        Get
            Return DirectCast(c, psUI.psControl.psImageTextCounter)
        End Get
    End Property

    <Category("Image"), _
    Description("Image file to display."), _
    Editor(GetType(ImageFileNamEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property File() As String
        Get
            Return c.GetBackground.imgFilename
        End Get
        Set(ByVal Value As String)
            updateUndoOnce("Image file")
            Dim Background As psUI.psBackground = c.Background
            Background.imgFilename = Value
            Background.Type = psUI.psBackground.BackgroundType.Picture
            c.Background = Background
            afterEdit()
        End Set
    End Property

    <Category("Image"), _
    Description("Color to make transparent in image."), _
    DisplayName("Transparent color")> _
    Property TransparentColor() As Color
        Get
            Return c.GetBackground.TransparentColor
        End Get
        Set(ByVal Value As Color)
            updateUndoOnce("Transparent color")
            Dim Background As psUI.psBackground = c.Background
            Background.TransparentColor = Value
            c.Background = Background
            Game.Drawing.img_ColorKey(c.GetBackground.imgFilename) = Value
            afterEdit()
        End Set
    End Property

    <Category("Image"), _
    Description("Size of image."), _
    DefaultValue(GetType(Size), "16, 16"), _
    DisplayName("Image size")> _
    Overridable Property ImageSize() As Size
        Get
            Return New Size(getC.imgW, getC.imgH)
        End Get
        Set(ByVal Value As Size)
            updateUndoOnce("Image size")
            getC.imgW = Value.Width
            getC.imgH = Value.Height
            Game.Drawing.img_Width(getC.GetBackground.imgFilename) = Value.Width
            Game.Drawing.img_Height(getC.GetBackground.imgFilename) = Value.Height
            afterEdit()
        End Set
    End Property

    <Browsable(False)> _
    Overrides Property Background() As psUI.psBackground
        Get
        End Get
        Set(ByVal Value As psUI.psBackground)
        End Set
    End Property
End Class
#End Region

#Region "ImageCounterWrapper"
Public Class ImageCounterWrapper
    Inherits ImageTextCounterWrapper

    Sub New(ByVal ctl As psUI.psControl)
        MyBase.New(ctl)
    End Sub

    Private ReadOnly Property getC() As psUI.psControl.psImageCounter
        Get
            Return DirectCast(c, psUI.psControl.psImageCounter)
        End Get
    End Property

    <Category("Image"), _
    Description("Size of image."), _
    DefaultValue(GetType(Size), "16, 16"), _
    DisplayName("Image size")> _
    Overrides Property ImageSize() As Size
        Get
            Return New Size(getC.imgW, getC.imgH)
        End Get
        Set(ByVal Value As Size)
            updateUndoOnce("Image size")
            getC.imgW = Value.Width
            getC.imgH = Value.Height
            Game.Drawing.img_Width(getC.GetBackground.imgFilename) = Value.Width
            Game.Drawing.img_Height(getC.GetBackground.imgFilename) = Value.Height
            afterEdit()
        End Set
    End Property

    <Category("Image"), _
    DefaultValue(1), _
    Description("Space between images in pixels.")> _
    Property Padding() As Integer
        Get
            Return getC.Padding
        End Get
        Set(ByVal Value As Integer)
            updateUndoOnce("Padding")
            getC.Padding = Value
            afterEdit()
        End Set
    End Property

    <Browsable(False)> _
    Overrides Property Font() As Font
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Font)
        End Set
    End Property

    <Browsable(False)> _
    Overrides Property TextColor() As Color
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Color)
        End Set
    End Property

    <Browsable(False)> _
    Overrides Property Shadow() As Boolean
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Boolean)
        End Set
    End Property
End Class
#End Region

#Region "Other"

Class CounterConverter
    Inherits ChoicesConverter

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
        Dim c(UBound(Game.actions.Counters)) As String
        For i As Integer = 1 To UBound(Game.actions.Counters)
            c(i - 1) = Game.actions.Counters(i).Name
        Next
        c(UBound(c)) = "(Edit counters...)"
        Return New StandardValuesCollection(c)
    End Function
End Class

Class BackgroundEditor
    Inherits Drawing.Design.UITypeEditor

    Private service As Windows.Forms.Design.IWindowsFormsEditorService

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then
            service = CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)), Windows.Forms.Design.IWindowsFormsEditorService)
            If (Not service Is Nothing) Then
                Dim f As New psfrmBackgroundEditor
                f.ShowDialog(value, value)
                f.Dispose()
            End If
        End If
        Return value
    End Function

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            Return Drawing.Design.UITypeEditorEditStyle.Modal
        End If
        Return MyBase.GetEditStyle(context)
    End Function

    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overloads Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)
        Dim b As psUI.psBackground = e.Value
        b.Draw(e.Graphics, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height, fGame.picTrans2, True)
    End Sub
End Class

Class ControlActionEditor
    Inherits AnimationsEditor

    Protected Overrides Sub ShowForm()
        Dim f As New psfrmActionEditor
        f.ShowDialog("wcli" & Editor.winedit.SelCtrls(1).Name)
        f.Dispose()
    End Sub

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            If DynamicReadOnly.GetValue("ButtonWrapper.Action") Then
                Return Drawing.Design.UITypeEditorEditStyle.None
            Else
                Return Drawing.Design.UITypeEditorEditStyle.Modal
            End If
        End If
        Return MyBase.GetEditStyle(context)
    End Function
End Class

Class MultilineEditor
    Inherits Drawing.Design.UITypeEditor

    Private service As Windows.Forms.Design.IWindowsFormsEditorService

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then
            service = CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)), Windows.Forms.Design.IWindowsFormsEditorService)
            If (Not service Is Nothing) Then
                ' Attempts to obtain an IWindowsFormsEditorService.
                Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
                If edSvc Is Nothing Then
                    Return value
                End If

                ' Displays a drop-down control.
                Dim ctl As New MultilineEditorControl(CStr(value), edSvc)
                edSvc.DropDownControl(ctl)
                Return ctl.Text
            End If
        End If
        Return value
    End Function

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        Try
            If (Not context Is Nothing And Not context.Instance Is Nothing) Then
                ' we'll show a modal form
                Return Drawing.Design.UITypeEditorEditStyle.DropDown
            End If
        Catch ex As Exception

        End Try
        Return MyBase.GetEditStyle(context)
    End Function
End Class

Class MovieFileNamEditor
    Inherits FileNameEditor

    Protected Overrides Sub InitializeDialog(ByVal openFileDialog As System.Windows.Forms.OpenFileDialog)
        openFileDialog.Filter = GetString("movieFileFilter")
    End Sub
End Class

Class ImageFileNamEditor
    Inherits FileNameEditor

    Protected Overrides Sub InitializeDialog(ByVal openFileDialog As System.Windows.Forms.OpenFileDialog)
        openFileDialog.Filter = GetString("imageFileFilter")
    End Sub
End Class

Class MusicEditor
    Inherits Drawing.Design.UITypeEditor

    Private service As Windows.Forms.Design.IWindowsFormsEditorService

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then
            service = CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)), Windows.Forms.Design.IWindowsFormsEditorService)
            If (Not service Is Nothing) Then
                Dim f As New frmBackgroundMusic
                f.ShowDialog(value)
                Return value.Clone()
                f.Dispose()
            End If
        End If
        Return value
    End Function

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            Return Drawing.Design.UITypeEditorEditStyle.Modal
        End If
        Return MyBase.GetEditStyle(context)
    End Function
End Class

Class TransitionEditor
    Inherits Drawing.Design.UITypeEditor

    Private service As Windows.Forms.Design.IWindowsFormsEditorService

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then
            service = CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)), Windows.Forms.Design.IWindowsFormsEditorService)
            If (Not service Is Nothing) Then
                Dim f As New psfrmWindowTransition
                f.ShowDialog(value)
                f.Dispose()
                Return value.Clone()
            End If
        End If
        Return value
    End Function

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            Return Drawing.Design.UITypeEditorEditStyle.Modal
        End If
        Return MyBase.GetEditStyle(context)
    End Function
End Class
#End Region