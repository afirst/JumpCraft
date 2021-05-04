Public Class CodeEditor
    Inherits System.Windows.Forms.UserControl

    Private Declare Function GetCaretBlinkTime Lib "user32" () As Integer

    Private WithEvents rtb As CodeEditorBox
    Private tmp As CodeEditorBox
    Private lockUpdate0, lockUpdate1 As Boolean
    Private blinkSwitch As Boolean = False
    Private DoNotUpdateScroll As Boolean
    Private Loaded As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SuspendLayout()

        Init()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
        tmp.Dispose()
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents hs As System.Windows.Forms.HScrollBar
    Friend WithEvents vs As System.Windows.Forms.VScrollBar
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pic = New System.Windows.Forms.PictureBox
        Me.hs = New System.Windows.Forms.HScrollBar
        Me.vs = New System.Windows.Forms.VScrollBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pic
        '
        Me.pic.BackColor = System.Drawing.SystemColors.Window
        Me.pic.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic.Location = New System.Drawing.Point(0, 0)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(328, 368)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'hs
        '
        Me.hs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hs.Enabled = False
        Me.hs.LargeChange = 8
        Me.hs.Location = New System.Drawing.Point(0, 0)
        Me.hs.Name = "hs"
        Me.hs.Size = New System.Drawing.Size(312, 16)
        Me.hs.SmallChange = 8
        Me.hs.TabIndex = 2
        '
        'vs
        '
        Me.vs.Dock = System.Windows.Forms.DockStyle.Right
        Me.vs.Enabled = False
        Me.vs.LargeChange = 17
        Me.vs.Location = New System.Drawing.Point(311, 0)
        Me.vs.Name = "vs"
        Me.vs.Size = New System.Drawing.Size(17, 352)
        Me.vs.SmallChange = 17
        Me.vs.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.hs)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 352)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 16)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(312, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 16)
        Me.Panel2.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000000000
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.vs)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.pic)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(328, 368)
        Me.Panel3.TabIndex = 5
        '
        'CodeEditor
        '
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CodeEditor"
        Me.Size = New System.Drawing.Size(328, 368)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VB.NET Language Data"
    Dim _Keywords() As String = {"AddHandler", _
                                "AddressOf", _
                                "Alias", _
                                "And", _
                                "AndAlso", _
                                "Ansi", _
                                "As", _
                                "Assembly", _
                                "Auto", _
                                "Boolean", _
                                "ByRef", _
                                "Byte", _
                                "ByVal", _
                                "Call", _
                                "Case", _
                                "Catch", _
                                "CBool", _
                                "CByte", _
                                "CChar", _
                                "CDate", _
                                "CDbl", _
                                "CDec", _
                                "Char", _
                                "CInt", _
                                "Class", _
                                "CLng", _
                                "CObj", _
                                "Const", _
                                "CShort", _
                                "CSng", _
                                "CStr", _
                                "CType", _
                                "Date", _
                                "Decimal", _
                                "Declare", _
                                "Default", _
                                "Delegate", _
                                "Dim", _
                                "DirectCast", _
                                "Do", _
                                "Double", _
                                "Each", _
                                "Else", _
                                "ElseIf", _
                                "End", _
                                "EndIf", _
                                "Enum", _
                                "Erase", _
                                "Error", _
                                "Event", _
                                "Exit", _
                                "False", _
                                "Finally", _
                                "For", _
                                "Friend", _
                                "Function", _
                                "Get", _
                                "GetType", _
                                "GoSub", _
                                "GoTo", _
                                "Handles", _
                                "If", _
                                "Implements", _
                                "Imports", _
                                "In", _
                                "Inherits", _
                                "Integer", _
                                "Interface", _
                                "Is", _
                                "Let", _
                                "Lib", _
                                "Like", _
                                "Long", _
                                "Loop", _
                                "Me", _
                                "Mod", _
                                "Module", _
                                "MustInherit", _
                                "MustOverride", _
                                "MyBase", _
                                "MyClass", _
                                "Namespace", _
                                "New", _
                                "Next", _
                                "Not", _
                                "Nothing", _
                                "NotInheritable", _
                                "NotOverridable", _
                                "Object", _
                                "On", _
                                "Option", _
                                "Optional", _
                                "Or", _
                                "OrElse", _
                                "Overloads", _
                                "Overridable", _
                                "Overrides", _
                                "ParamArray", _
                                "Preserve", _
                                "Private", _
                                "Property", _
                                "Protected", _
                                "Public", _
                                "RaiseEvent", _
                                "ReadOnly", _
                                "ReDim", _
                                "RemoveHandler", _
                                "Resume", _
                                "Return", _
                                "Select", _
                                "Set", _
                                "Shadows", _
                                "Shared", _
                                "Short", _
                                "Single", _
                                "Static", _
                                "Step", _
                                "Stop", _
                                "String", _
                                "Structure", _
                                "Sub", _
                                "SyncLock", _
                                "Then", _
                                "Throw", _
                                "To", _
                                "True", _
                                "Try", _
                                "TypeOf", _
                                "Unicode", _
                                "Until", _
                                "Variant", _
                                "Wend", _
                                "When", _
                                "While", _
                                "With", _
                                "WithEvents", _
                                "WriteOnly", _
                                "Xor"}
    Const Delimiters As String = "+=*/=^'""<>!:,.#$%&(){}[] " + Chr(10) + Chr(13) + vbTab

    Dim Keywords As New ArrayList

    Class VBColors
        Public Keyword As Color = Color.Blue
        Public Comment As Color = Color.DarkGreen
        Public [String] As Color = Color.Gray
        Public Other As Color = Color.Black
    End Class

    Private _colors As New VBColors

    ReadOnly Property Colors() As VBColors
        Get
            Return _colors
        End Get
    End Property
#End Region

    Private oImage As Image, xg1 As Graphics

    Shadows Event TextChanged(ByVal sender As Object, ByVal e As EventArgs)
    Shadows Event KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    Shadows Event KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    Shadows Event MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

#Region "Init"
    Sub Init()
        rtb = New CodeEditorBox
        rtb.BorderStyle = BorderStyle.None
        rtb.Font = Me.Font
        rtb.Dock = DockStyle.Fill
        rtb.AcceptsTab = True
        rtb.ScrollBars = RichTextBoxScrollBars.ForcedBoth
        rtb.WordWrap = False
        Controls.Add(rtb)
        rtb.SendToBack()

        'Temp RTB used for selecting the last character
        tmp = New CodeEditorBox
        tmp.BorderStyle = BorderStyle.None
        tmp.Font = Me.Font
        tmp.Dock = DockStyle.Fill
        tmp.AcceptsTab = True
        tmp.ScrollBars = RichTextBoxScrollBars.ForcedBoth
        tmp.WordWrap = False
        tmp.TabStop = False
        Controls.Add(tmp)
        tmp.SendToBack()

        ResumeLayout(False)

        For i As Integer = 0 To _Keywords.Length - 1
            Keywords.Add(_Keywords(i).ToLower)
        Next
        InitAutoRedraw()

        Timer1.Interval = GetCaretBlinkTime
        Timer1.Enabled = True

        Loaded = True
    End Sub

    Private Sub InitAutoRedraw()
        Try
            'AutoRedraw
            oImage = New Bitmap(pic.Width, pic.Height)
            xg1 = Graphics.FromImage(oImage)
            pic.Image = oImage
            'xg1 = pic.CreateGraphics
            xg1.CompositingMode = Drawing2D.CompositingMode.SourceOver
            xg1.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            xg1.InterpolationMode = Drawing2D.InterpolationMode.Low

        Catch
        End Try
    End Sub
#End Region

#Region "Drawing"
    Sub Redraw()
        If lockUpdate0 Or lockUpdate1 Then Exit Sub

        'Update scrollbars
        Dim si As CodeEditorBox.SCROLLINFO

        DoNotUpdateScroll = True

        'Horizontal scrollbar
        si = rtb.ScrollHInfo
        hs.LargeChange = si.nPage
        hs.Maximum = si.nMax
        hs.Value = si.nPos
        hs.Enabled = rtb.ScrollHEnabled
        tmp.ScrollH = rtb.ScrollH

        'Vertical scrollbar
        si = rtb.ScrollVInfo
        vs.LargeChange = si.nPage
        vs.Maximum = si.nMax
        vs.Value = si.nPos
        vs.Enabled = rtb.ScrollVEnabled
        tmp.ScrollV = rtb.ScrollV

        DoNotUpdateScroll = False

        'pic.Visible = False
        With xg1
            If rtb.ReadOnly Then
                .Clear(SystemColors.Control)
            Else
                .Clear(rtb.BackColor)
            End If

            'Get font dimensiosn
            Dim TextSize As SizeF = .MeasureString("W", rtb.Font)
            TextSize.Width -= 4

            'Get first and last characters to draw
            Dim FirstChar As Integer = rtb.GetCharIndexFromPosition(New Point(0, 0))
            Dim LastChar As Integer = rtb.GetCharIndexFromPosition(New Point(rtb.Width, rtb.Height))

            'FirstChar must start a new line
            While FirstChar > 0 AndAlso (rtb.Text.Chars(FirstChar - 1) <> Chr(13) And rtb.Text.Chars(FirstChar - 1) <> Chr(10))
                FirstChar -= 1
            End While

            'LastChar must end a line
            While LastChar < rtb.TextLength - 1 AndAlso (rtb.Text.Chars(LastChar + 1) <> Chr(13) And rtb.Text.Chars(LastChar + 1) <> Chr(10))
                LastChar += 1
            End While

            'LastChar must be a valid character number
            If LastChar > rtb.TextLength - 1 Then LastChar = rtb.TextLength - 1

            'Draw text
            If LastChar >= FirstChar Then

                'Color-code text
                Dim colorCode As IndexColorArray = ParseText(FirstChar, rtb.Text.Substring(FirstChar, LastChar - FirstChar + 1))
                If colorCode.Count = 0 Then GoTo DoneDrawingText

                For i As Integer = 0 To colorCode.Count - 1
                    'Calculate where to draw
                    Dim p As Point = rtb.GetPositionFromCharIndex(colorCode(i).Index)

                    'Calculate length of substring
                    Dim Length As Integer
                    If i = colorCode.Count - 1 Then
                        Length = (rtb.TextLength - 1) - colorCode(i).Index + 1
                    Else
                        Length = colorCode(i + 1).Index - colorCode(i).Index
                    End If

                    'Colorize
                    Dim charColor As Color = colorCode(i).Color

                    'Text
                    Dim str As String
                    If colorCode(i).ReplaceString <> "" Then
                        str = colorCode(i).ReplaceString
                    Else
                        str = rtb.Text.Substring(colorCode(i).Index, Length)
                    End If

                    'Draw the substring
                    .DrawString(str, rtb.Font, New Pen(charColor).Brush, p.X, p.Y)
                    '.DrawLine(New Pen(charColor), p.X, p.Y, p.X + .MeasureString(str, rtb.Font).Width, p.Y + .MeasureString(str, rtb.Font).Height)
                Next

                'Draw highlighted text
                Dim starthighlight As Integer = rtb.SelectionStart
                Dim stophighlight As Integer = rtb.SelectionStart + rtb.SelectionLength - 1
                If Not ((starthighlight < FirstChar And stophighlight < FirstChar) Or _
                        (starthighlight > LastChar And stophighlight > LastChar)) Then
                    If starthighlight < FirstChar Then starthighlight = FirstChar
                    If stophighlight > LastChar Then stophighlight = LastChar
                    Try
                        Dim linestart As Integer = starthighlight
                        Dim highlighting As Boolean = True
                        For i As Integer = starthighlight To stophighlight Step 1
                            If rtb.Text.Chars(i) = Chr(13) Or rtb.Text.Chars(i) = Chr(10) Or i = stophighlight Then
                                If highlighting Then
                                    highlighting = False

                                    'Simulate line break
                                    If i = stophighlight Then i += 1

                                    'Get text
                                    Dim length As Integer = i - linestart
                                    Dim txt As String = rtb.Text.Substring(linestart, Length)

                                    'Draw highlight
                                    Dim p As Point = rtb.GetPositionFromCharIndex(linestart)
                                    .FillRectangle(New Pen(SystemColors.Highlight).Brush, New Rectangle(p.X + 2, p.Y, .MeasureString(New String("N", txt.Length), rtb.Font).Width - 3, TextSize.Height))

                                    'Draw highlighted text
                                    .DrawString(txt, rtb.Font, New Pen(SystemColors.HighlightText).Brush, p.X, p.Y)
                                End If
                            Else
                                If Not highlighting Then
                                    linestart = i
                                    highlighting = True
                                End If
                            End If
                        Next
                    Catch
                        'end of string
                    End Try
                End If

                'Dividers
                Dim startLine As Integer = rtb.GetLineFromCharIndex(colorCode(0).Index)
                Dim stopLine As Integer = rtb.GetLineFromCharIndex(colorCode(colorCode.Count - 1).Index)
                For i As Integer = startLine + 1 To stopLine
                    Dim tmpLine As String = rtb.Lines(i).Trim.ToLower
                    tmpLine = ClipModifiers(tmpLine)
                    If tmpLine.StartsWith("sub ") Or tmpLine.StartsWith("function ") Or tmpLine.StartsWith("property") Then
                        'Get char pos
                        Dim y As Integer = rtb.GetPositionFromCharIndex(colorCode(0).Index).Y
                        If i - startLine > 0 Then
                            'Dim str As String = ""
                            'For j As Integer = 1 To i - startLine
                            '    str += vbCrLf
                            'Next
                            'y += .MeasureString(str, rtb.Font).Height
                            If i > 0 Then
                                Dim prevline As String = ClipModifiers(rtb.Lines(i - 1).ToLower.Trim).Trim
                                If Not (prevline.StartsWith("class") Or prevline.StartsWith("interface") Or prevline.StartsWith("structure") Or prevline.StartsWith("module")) Then
                                    y += (rtb.FontHeight + 1) * (i - startLine - IIf(i > 0 AndAlso rtb.Lines(i - 1).Trim = "", 1, 0))
                                    .DrawLine(New Pen(Color.Gray), 0, y, rtb.Width, y)
                                End If
                            End If
                        End If
                    End If
                Next
            End If

DoneDrawingText:

            'Draw caret
            If rtb.Focused And blinkSwitch Then
                Dim SelStart As Point
                SelStart = rtb.GetPositionFromCharIndex(rtb.SelectionStart)
                .FillRectangle(Brushes.Black, SelStart.X + 2, SelStart.Y, 2, TextSize.Height - 1)
            End If

            lockUpdate0 = True
            pic.Refresh()
            lockUpdate0 = False


            'rtb.CreateGraphics.DrawImage(oImage, New Point(0, 0))
            'rtb.Refresh()

            'pic.Refresh()
            'For i As Integer = FirstChar To LastChar
            '    Dim p As Point = rtb.GetPositionFromCharIndex(i)
            '    .DrawString(rtb.Text.Chars(i), rtb.Font, Brushes.Black, p.X, p.Y)
            'Next

        End With
    End Sub
#End Region

#Region "Parsing"
    Function ParseText(ByVal offset As Integer, ByVal str As String) As IndexColorArray
        Dim ret As New IndexColorArray
        Dim WordStart As Integer = -1
        Dim newLine As Boolean
        str += " "
        Try
            For i As Integer = 0 To str.Length - 1
Top:
                'Check words
                If Delimiters.IndexOf(str.Chars(i)) = -1 Then
                    'Beginning of a word
                    If WordStart = -1 Then WordStart = i
                Else
                    'Delimiter
                    If WordStart > -1 Then
                        Dim KeywordIndex As Integer = Keywords.IndexOf(str.Substring(WordStart, i - WordStart).ToLower)
                        If str.Substring(WordStart, i - WordStart).ToLower = "REM" Then
                            'Comment
                            newLine = False
                            ret.Add(offset + WordStart, Colors.Comment)
                            NextLine(i, str) : GoTo top
                        ElseIf KeywordIndex > -1 Then
                            'Keyword
                            newLine = False
                            ret.Add(offset + WordStart, Colors.Keyword, _Keywords(KeywordIndex))
                        Else
                            'Other word
                            If newLine OrElse (ret.Count = 0 OrElse (ret(ret.Count - 1).Color.ToArgb <> Colors.Other.ToArgb)) Then
                                newLine = False
                                ret.Add(offset + WordStart, Colors.Other)
                            End If
                        End If
                    End If

                    'Non-whitespace Delimiter
                    If str.Chars(i) <> " " And str.Chars(i) <> vbTab And str.Chars(i) <> Chr(13) And str.Chars(i) <> Chr(10) Then
                        If newLine OrElse (ret.Count = 0 OrElse (ret(ret.Count - 1).Color.ToArgb <> Colors.Other.ToArgb)) Then
                            newLine = False
                            ret.Add(offset + i, Colors.Other)
                        End If
                    End If

                    WordStart = -1

                    'Check line break
                    If str.Chars(i) = Chr(13) Or str.Chars(i) = Chr(10) Then
                        newLine = True
                        NextLine(i, str) : GoTo top
                    End If
                End If

                'Check comments
                If str.Chars(i) = "'" Then
                    'Comment
                    ret.Add(offset + i, Colors.Comment)
                    newLine = True
                    NextLine(i, str) : GoTo top
                End If

                'Check strings
                If str.Chars(i) = """" Then
                    'String
                    newLine = False
                    ret.Add(offset + i, Colors.String)
                    Do
                        i += 1
                        If str.Chars(i) = """" Then
                            If Not str.Chars(i + 1) = """" Then
                                'End of string
                                i += 1
                                GoTo Top
                            Else
                                i += 1
                            End If
                        ElseIf str.Chars(i) = Chr(13) Or str.Chars(i) = Chr(10) Then
                            'Double quote "" escape sequence
                            newLine = True
                            NextLine(i, str) : GoTo Top
                        End If
                    Loop
                End If
            Next
        Catch 'ex As EndOfStringException
        End Try

        'Other word
        If WordStart > -1 Then
            ret.Add(offset + WordStart, Colors.Other)
        End If

        Return ret
    End Function

    Private Sub NextLine(ByRef i As Integer, ByVal str As String)
        Dim EncounteredLineEndChars As Boolean = str.Chars(i) = Chr(13) Or str.Chars(i) = Chr(10)
        Do
            i += 1
            If i > str.Length - 1 Then Throw New EndOfStringException
            If str.Chars(i) = Chr(13) Or str.Chars(i) = Chr(10) Then EncounteredLineEndChars = True
        Loop Until EncounteredLineEndChars AndAlso Not (str.Chars(i) = Chr(13) Or str.Chars(i) = Chr(10))
    End Sub
#End Region

#Region "Typing Intellisense"
    Private Sub rtb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtb.KeyDown
        If rtb.ReadOnly Then Exit Sub

        If e.KeyCode = Keys.V AndAlso e.Control Then
            rtb.Paste(DataFormats.GetFormat(DataFormats.Text))
            e.Handled = True
        ElseIf e.KeyCode = Keys.Back Then
            'Auto-delete tabs
            If rtb.SelectionLength > 0 Then GoTo ExitSub
            Dim i As Integer
            For i = rtb.SelectionStart - 1 To 0 Step -1
                Select Case rtb.Text.Chars(i)
                    Case " "
                    Case Chr(13), Chr(10)
                        Exit For
                    Case Else
                        GoTo ExitSub
                End Select
            Next
            Dim indent As Integer = rtb.SelectionStart - i - 1
            If indent = 0 Then GoTo ExitSub
            Dim removeLength As Integer = indent Mod 4
            If removeLength = 0 Then removeLength = 4
            lockUpdate0 = True
            rtb.Select(rtb.SelectionStart - removeLength, removeLength)
            lockUpdate0 = False
            rtb.SelectedText = ""
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            'Get current line up to caret
            Dim i, firstCharIndex As Integer
            For i = rtb.SelectionStart - 1 To 0 Step -1
                Select Case rtb.Text.Chars(i)
                    Case Chr(13), Chr(10)
                        Exit For
                End Select
            Next
            firstCharIndex = i

            'If the caret is in the middle of a line,
            'do not create any autotext
            Dim NoAutoText As Boolean
            Try
                For i = rtb.SelectionStart To rtb.TextLength - 1
                    Select Case rtb.Text.Chars(i)
                        Case Chr(10), Chr(13)
                            Exit Try
                        Case " ", vbTab
                        Case Else
                            NoAutoText = True
                            Exit Try
                    End Select
                Next
            Catch
            End Try

            Dim curLine0 As String = rtb.Text.Substring(firstCharIndex + 1, rtb.SelectionStart - firstCharIndex - 1).ToLower
            If curLine0.TrimEnd <> "" Then curLine0 = curLine0.TrimEnd
            Dim curLine As String = curLine0.Trim
            Dim indent As Integer = Len(curLine0) - Len(curLine)

            'Clip off modifiers
            Dim oldtmpline As String
            Dim isReadOnly As Boolean
            Dim isWriteOnly As Boolean
            Do
                oldtmpline = curLine
                If curLine.StartsWith("notoverridable ") Then curLine = curLine.Substring(14).Trim
                If curLine.StartsWith("notinheritable ") Then curLine = curLine.Substring(14).Trim
                If curLine.StartsWith("mustinherit ") Then curLine = curLine.Substring(11).Trim
                If curLine.StartsWith("overridable ") Then curLine = curLine.Substring(11).Trim
                If curLine.StartsWith("writeonly ") Then curLine = curLine.Substring(9).Trim : isWriteOnly = True
                If curLine.StartsWith("protected ") Then curLine = curLine.Substring(9).Trim
                If curLine.StartsWith("overrides ") Then curLine = curLine.Substring(9).Trim
                If curLine.StartsWith("overloads ") Then curLine = curLine.Substring(9).Trim
                If curLine.StartsWith("readonly ") Then curLine = curLine.Substring(8).Trim : isReadOnly = True
                If curLine.StartsWith("shadows ") Then curLine = curLine.Substring(7).Trim
                If curLine.StartsWith("private ") Then curLine = curLine.Substring(7).Trim
                If curLine.StartsWith("friend ") Then curLine = curLine.Substring(6).Trim
                If curLine.StartsWith("public ") Then curLine = curLine.Substring(6).Trim
                If curLine.StartsWith("shared ") Then curLine = curLine.Substring(6).Trim
            Loop Until curLine = oldtmpline

            'Dim lineIndex As Integer = rtb.GetLineFromCharIndex(rtb.SelectionStart)
            'Dim curLine0 As String = rtb.Lines(lineIndex).TrimEnd
            'Dim curLine As String = curLine0.Trim
            Dim autoLine As String
            Dim tryCatch As Boolean
            If Not NoAutoText Then
                Try
                    If CheckLineStartsWith(curLine, "for") Then
                        autoLine = "Next"
                    ElseIf CheckLineStartsWith(curLine, "if") Then
                        Dim p As Placement = CheckLineContains(curLine, "then")
                        If p = Placement.None Then
                            rtb.SelectedText = " Then"
                        End If
                        If p <> Placement.Middle Then
                            autoLine = "End If"
                        End If
                    ElseIf CheckLineStartsWith(curLine, "while") Then
                        autoLine = "End While"
                    ElseIf CheckLineStartsWith(curLine, "do") Then
                        autoLine = "Loop"
                    ElseIf CheckLineStartsWith(curLine, "sub") Then
                        autoLine = "End Sub"
                    ElseIf CheckLineStartsWith(curLine, "class") Then
                        autoLine = "End Class"
                    ElseIf CheckLineStartsWith(curLine, "try") Then
                        autoLine = "Catch ex As Exception" + vbCrLf + New String(" ", indent + 4) + vbCrLf + New String(" ", indent) + "End Try"
                        tryCatch = True
                    ElseIf CheckLineStartsWith(curLine, "property") Then
                        Dim DataType As String = GetReturnType(curLine)
                        If DataType = "" Then DataType = "Object"
                        Dim str As String, tmplen As Integer
                        Dim oldSelStart As Integer = rtb.SelectionStart
                        If isReadOnly Or (Not isReadOnly And Not isWriteOnly) Then
                            str = vbCrLf + New String(" ", indent + 4) + "Get" + vbCrLf + New String(" ", indent + 8)
                            tmplen = Len(str)
                            rtb.SelectedText = str + vbCrLf + New String(" ", indent + 4) + "End Get"
                        End If
                        If isWriteOnly Or (Not isReadOnly And Not isWriteOnly) Then
                            str = vbCrLf + New String(" ", indent + 4) + "Set(ByVal value As " + DataType + ")" + vbCrLf + New String(" ", indent + 8)
                            If tmplen = 0 Then tmplen = Len(str)
                            rtb.SelectedText = str + vbCrLf + New String(" ", indent + 4) + "End Set"
                        End If
                        rtb.SelectedText = vbCrLf + New String(" ", indent) + "End Property"
                        rtb.SelectionStart = oldSelStart + tmplen - 2
                        e.Handled = True
                        GoTo ExitSub
                    ElseIf CheckLineStartsWith(curLine, "function") Then
                        autoLine = "End Function"
                    ElseIf CheckLineStartsWith(curLine, "structure") Then
                        autoLine = "End Structure"
                    ElseIf CheckLineStartsWith(curLine, "with") Then
                        autoLine = "End With"
                    ElseIf CheckLineStartsWith(curLine, "synclock") Then
                        autoLine = "End Synclock"
                    ElseIf CheckLineStartsWith(curLine, "interface") Then
                        autoLine = "End Interface"
                    ElseIf CheckLineStartsWith(curLine, "module") Then
                        autoLine = "End Module"
                    ElseIf CheckLineStartsWith(curLine, "select case") Then
                        rtb.SelectedText = vbCrLf + New String(" ", indent + 4) + "Case "
                        autoLine = "End Select"
                    ElseIf CheckLineStartsWith(curLine, "case") Then
                        autoLine = " "
                    ElseIf CheckLineStartsWith(curLine, "elseif") Then
                        If CheckLineContains(curLine, "then") = Placement.None Then
                            rtb.SelectedText = " Then"
                        End If
                        autoLine = " "
                    ElseIf CheckLineStartsWith(curLine, "else") Then
                        autoLine = " "
                    End If
                Catch
                End Try
            End If
            If autoLine <> "" Then
                If autoLine <> " " Then
                    rtb.SelectedText = vbCrLf + New String(" ", indent + 4) + vbCrLf + New String(" ", indent) + autoLine
                    rtb.SelectionStart -= (Len(autoLine) + indent + 1)
                Else
                    rtb.SelectedText = vbCrLf + New String(" ", indent + 4)
                    rtb.SelectionStart -= (Len(autoLine) - 1)
                End If
                If tryCatch Then rtb.SelectionStart += 2
            Else
                rtb.SelectedText = vbCrLf + New String(" ", indent)
            End If
            e.Handled = True
        End If
        blinkSwitch = True
ExitSub:
        RaiseEvent KeyDown(sender, e)
        Redraw()
    End Sub

    Private Sub rtb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rtb.KeyPress
        If rtb.ReadOnly Then Exit Sub

        If e.KeyChar = vbTab Then 'Tab
            rtb.SelectedText = "    "
            e.Handled = True
        End If
        blinkSwitch = True
        RaiseEvent KeyPress(sender, e)
        'Redraw()
    End Sub

    Private Function CheckLineStartsWith(ByVal line As String, ByVal startsWith As String) As Boolean
        If line = startsWith Then
            Return True
        Else
            Return line.StartsWith(startsWith) AndAlso Delimiters.IndexOf(line.Chars(startsWith.Length)) > -1
        End If
    End Function

    Enum Placement
        None
        Beginning
        Middle
        [End]
        BeforeComment
    End Enum

    Private Function CheckLineContains(ByVal line As String, ByVal contains As String) As Placement
        Dim bln As Boolean
        line = TakeOutStrings(TakeOffComment(line, bln)).ToLower.Trim
        If bln Then Return Placement.BeforeComment
        For i As Integer = 0 To line.Length - contains.Length
            If line.Substring(i, contains.Length) = contains Then
                If (i = 0 OrElse Delimiters.IndexOf(line.Chars(i - 1)) > -1) AndAlso _
                    (i = line.Length - contains.Length OrElse Delimiters.IndexOf(line.Chars(i + contains.Length)) > -1) Then
                    If i = 0 Then
                        Return Placement.Beginning
                    ElseIf i = line.Length - contains.Length Then
                        Return Placement.End
                    Else
                        Return Placement.Middle
                    End If
                End If
            End If
        Next
        Return Placement.None
        'If bln Then Return True
        'Try
        '    Return line.EndsWith(endsWith) AndAlso Delimiters.IndexOf(line.Chars(line.Length - endsWith.Length - 1)) > -1
        'Catch
        '    Return False
        'End Try
    End Function

    Function GetReturnType(ByVal line As String) As String
        line = TakeOffComment(line).ToLower.Trim
        For i As Integer = line.Length - 1 To 0 Step -1
            Try
                If line.Substring(i, 3) = "as " Then ' Delimiters.IndexOf(line.Chars(i)) > -1 Then
                    Return line.Substring(i + 3).Trim
                    Exit Function
                End If
            Catch
            End Try
        Next
    End Function

    Private Function TakeOffComment(ByVal line As String, Optional ByRef CommentAtEnd As Boolean = False) As String
        'Take off possible comment at end of string
        Dim oldline As String = line
        Dim inString As Boolean, strStart As Integer
        For i As Integer = 0 To line.Length - 1
            If Not inString Then
                If line.Chars(i) = "'" Then
                    line = line.Substring(0, i).Trim
                    CommentAtEnd = True
                    Exit For
                ElseIf line.Chars(i) = """" Then
                    inString = True
                    strStart = i
                End If
            Else
                If line.Chars(i) = """" Then
                    If Not (strStart = i - 1) Then
                        inString = False
                    End If
                End If
            End If
        Next
        Return line
    End Function

    Function TakeOutStrings(ByVal line As String) As String
        Dim inString As Boolean
        For i As Integer = 0 To line.Length - 1
            If line.Chars(i) = """" Then
                If Not inString Then
                    inString = True
                Else
                    If i < line.Length AndAlso line.Chars(i + 1) <> """" Then
                        inString = False
                    End If
                End If
                line = line.Remove(i, 1)
                i -= 1
            Else
                If inString Then
                    line = line.Remove(i, 1)
                End If
            End If
        Next
        Return line
    End Function

    Function ClipModifiers(ByVal tmpLine As String) As String
        Dim oldtmpline As String
        Do
            oldtmpline = tmpLine
            If tmpLine.StartsWith("notoverridable ") Then tmpLine = tmpLine.Substring(14).Trim
            If tmpLine.StartsWith("notinheritable ") Then tmpLine = tmpLine.Substring(14).Trim
            If tmpLine.StartsWith("mustinherit ") Then tmpLine = tmpLine.Substring(11).Trim
            If tmpLine.StartsWith("overridable ") Then tmpLine = tmpLine.Substring(11).Trim
            If tmpLine.StartsWith("writeonly ") Then tmpLine = tmpLine.Substring(9).Trim
            If tmpLine.StartsWith("protected ") Then tmpLine = tmpLine.Substring(9).Trim
            If tmpLine.StartsWith("overrides ") Then tmpLine = tmpLine.Substring(9).Trim
            If tmpLine.StartsWith("overloads ") Then tmpLine = tmpLine.Substring(9).Trim
            If tmpLine.StartsWith("readonly ") Then tmpLine = tmpLine.Substring(8).Trim
            If tmpLine.StartsWith("shadows ") Then tmpLine = tmpLine.Substring(7).Trim
            If tmpLine.StartsWith("private ") Then tmpLine = tmpLine.Substring(7).Trim
            If tmpLine.StartsWith("friend ") Then tmpLine = tmpLine.Substring(6).Trim
            If tmpLine.StartsWith("public ") Then tmpLine = tmpLine.Substring(6).Trim
            If tmpLine.StartsWith("shared ") Then tmpLine = tmpLine.Substring(6).Trim            
        Loop Until tmpLine = oldtmpline
        Return tmpLine
    End Function
#End Region

#Region "Mouse and Highlighting"
    Dim tmpSelStart As Integer

    Private Sub pic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic.MouseDown
        If e.Button = MouseButtons.Left Then
            'Move caret
            tmp.Size = rtb.Size
            tmp.Rtf = rtb.Rtf
            tmp.Text += vbCrLf
            rtb.Select(tmp.GetCharIndexFromPosition(New Point(e.X, e.Y)), 0)
            tmpSelStart = rtb.SelectionStart
            rtb.Focus()
            blinkSwitch = True
            Redraw()
        End If
    End Sub

    Private Sub pic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic.MouseMove
        If e.Button = MouseButtons.Left Then
            'Drag select
            tmp.Size = rtb.Size
            tmp.Rtf = rtb.Rtf
            tmp.Text += vbCrLf
            Dim tmpSelLen As Integer = tmp.GetCharIndexFromPosition(New Point(e.X, e.Y)) - tmpSelStart
            If tmpSelLen < 0 Then
                rtb.Select(tmpSelStart + tmpSelLen, -tmpSelLen)
            Else
                rtb.Select(tmpSelStart, tmpSelLen)
            End If
            blinkSwitch = True
            Redraw()
        End If
    End Sub

    Private Sub pic_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic.DoubleClick
        'Select word
        Dim StartChar As Integer = rtb.SelectionStart
        Dim StopChar As Integer = rtb.SelectionStart
        For i As Integer = StartChar - 1 To 0 Step -1
            If Delimiters.IndexOf(rtb.Text.Chars(i)) > 0 Then
                StartChar = i + 1
                Exit For
            ElseIf i = 0 Then
                StartChar = 0
            End If
        Next
        For i As Integer = StopChar To rtb.TextLength - 1
            If i = rtb.TextLength - 1 Or Delimiters.IndexOf(rtb.Text.Chars(i)) > 0 Then
                If i = rtb.TextLength - 1 Then i += 1
                StopChar = i - 1
                Exit For
            End If
        Next
        Try
            rtb.Select(StartChar, StopChar - StartChar + 1)
        Catch
        End Try
        blinkSwitch = True
        Redraw()
    End Sub
#End Region

#Region "Cursor Timer"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        blinkSwitch = Not blinkSwitch
        Redraw()
    End Sub
#End Region

#Region "Scrolling"
    Private Sub hs_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hs.ValueChanged
        If Not DoNotUpdateScroll Then
            rtb.ScrollH = hs.Value
            Redraw()
        End If
    End Sub

    Private Sub vs_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vs.ValueChanged
        If Not DoNotUpdateScroll Then
            rtb.ScrollV = vs.Value
            Redraw()
        End If
    End Sub

    <System.ComponentModel.Category("Behavior"), _
    System.ComponentModel.DefaultValue(GetType(Boolean), "True")> _
    Property Multiline() As Boolean
        Get
            Return rtb.Multiline
        End Get
        Set(ByVal Value As Boolean)
            rtb.Multiline = Value
            Panel1.Visible = Value
            vs.Visible = Value
        End Set
    End Property
#End Region

#Region "Events that Require a Redraw"
    Private Sub pic_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic.Resize
        If Loaded Then
            InitAutoRedraw()
            Redraw()
        End If
    End Sub

    Private Sub rtb_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtb.MouseWheel
        Redraw()
    End Sub

    Private Sub rtb_Updated() Handles rtb.Updated
        Redraw()
    End Sub

    Private Sub pic_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pic.Paint
        Redraw()
    End Sub

    Private Sub rtb_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtb.Resize
        Redraw()
    End Sub
#End Region

#Region "Wrapper"
    Function GetRTB() As CodeEditorBox
        Return rtb
    End Function

    Overrides Property ContextMenu() As ContextMenu
        Get
            Return pic.ContextMenu
        End Get
        Set(ByVal Value As ContextMenu)
            pic.ContextMenu = Value
        End Set
    End Property

    Overrides Property Text() As String
        Get
            Return rtb.Text
        End Get
        Set(ByVal Value As String)
            rtb.Text = Value
        End Set
    End Property

    ReadOnly Property Lines() As String()
        Get
            Return rtb.Lines
        End Get
    End Property

    ReadOnly Property UndoActionName() As String
        Get
            Return rtb.UndoActionName
        End Get
    End Property

    ReadOnly Property RedoActionName() As String
        Get
            Return rtb.RedoActionName
        End Get
    End Property

    Sub Undo()
        rtb.Undo()
    End Sub

    Sub Redo()
        rtb.Redo()
    End Sub

    Property SelectedText() As String
        Get
            Return rtb.SelectedText
        End Get
        Set(ByVal Value As String)
            rtb.SelectedText = Value
        End Set
    End Property

    ReadOnly Property CanUndo() As Boolean
        Get
            Return rtb.CanUndo
        End Get
    End Property

    ReadOnly Property CanRedo() As Boolean
        Get
            Return rtb.CanRedo
        End Get
    End Property

    ReadOnly Property CanPaste(ByVal clipFormat As DataFormats.Format) As Boolean
        Get
            Return rtb.CanPaste(clipFormat)
        End Get
    End Property

    Sub Copy()
        rtb.Copy()
    End Sub

    Sub Cut()
        rtb.Cut()
    End Sub

    Sub LoadFile(ByVal path As String)
        rtb.LoadFile(path)
    End Sub

    Sub LoadFile(ByVal path As String, ByVal fileType As RichTextBoxStreamType)
        rtb.LoadFile(path, fileType)
    End Sub

    Sub Paste(ByVal clipFormat As DataFormats.Format)
        rtb.Paste(clipFormat)
    End Sub

    Sub Paste()
        rtb.Paste()
    End Sub

    Sub SaveFile(ByVal path As String)
        rtb.SaveFile(path)
    End Sub

    Sub SaveFile(ByVal path As String, ByVal fileType As RichTextBoxStreamType)
        rtb.SaveFile(path, fileType)
    End Sub

    Sub SelectAll()
        rtb.SelectAll()
    End Sub

    Property SelectionLength()
        Get
            Return rtb.SelectionLength
        End Get
        Set(ByVal Value)
            rtb.SelectionLength = Value
        End Set
    End Property

    Property SelectionStart()
        Get
            Return rtb.SelectionStart
        End Get
        Set(ByVal Value)
            rtb.SelectionStart = Value
        End Set
    End Property

    ReadOnly Property TextLength() As Integer
        Get
            Return rtb.TextLength
        End Get
    End Property

    Shadows Sub [Select](ByVal start As Integer, ByVal length As Integer)
        rtb.Select(start, length)
    End Sub

    Function GetPositionFromCharIndex(ByVal index As Integer) As Point
        Return rtb.GetPositionFromCharIndex(index)
    End Function

    Private Sub rtb_TextChanged() Handles rtb.TextChanged
        RaiseEvent TextChanged(rtb, New EventArgs)
    End Sub

    Sub LockUpdate()
        lockUpdate1 = True
    End Sub

    Sub UnlockUpdate()
        lockUpdate1 = False
    End Sub

    Shadows Sub [Select]()
        rtb.Select()
    End Sub

    Sub ScrollToCaret()
        rtb.ScrollToCaret()
    End Sub

    Property Locked() As Boolean
        Get
            Return rtb.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            rtb.ReadOnly = Value
        End Set
    End Property
#End Region

    Private Sub CodeEditor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If Loaded Then Redraw()
    End Sub
End Class

#Region "IndexColorArray"
Public Class IndexColorArray
    Inherits ArrayList

    Public Overloads Sub Add(ByVal index As Integer, ByVal Color As Color, Optional ByVal ReplaceString As String = "")
        Add(New IndexColorArrayItem(index, Color, ReplaceString))
    End Sub

    Public Overloads Sub Add(ByVal value As IndexColorArrayItem)
        MyBase.Add(value)
    End Sub

    Default Public Shadows Property Item(ByVal index As Integer) As IndexColorArrayItem
        Get
            Return MyBase.Item(index)
        End Get
        Set(ByVal Value As IndexColorArrayItem)
            MyBase.Item(index) = Value
        End Set
    End Property
End Class

Public Class IndexColorArrayItem
    Public Index As Integer, Color As Color, ReplaceString As String

    Sub New(ByVal anIndex As Integer, ByVal aColor As Color, Optional ByVal ReplaceWith As String = "")
        Index = anIndex
        Color = aColor
        ReplaceString = ReplaceWith
    End Sub
End Class
#End Region

#Region "End of Stirng Exception"
Class EndOfStringException
    Inherits Exception

    Public Overrides ReadOnly Property Message() As String
        Get
            Return "End of string"
        End Get
    End Property
End Class
#End Region