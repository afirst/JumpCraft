Public Class CodeEditor
    Inherits RichTextBox

#Region "API"
    Private Declare Function DrawText Lib "user32.dll" Alias "DrawTextA" (ByVal hdc As Int32, ByVal lpStr As String, ByVal nCount As Int32, ByRef lpRect As RECT, ByVal wFormat As Int32) As Int32
    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
        Sub New(ByVal l As Int32, ByVal t As Int32, ByVal w As Int32, ByVal h As Int32)
            Left = l : Top = t : Right = l + w : Bottom = t + h
        End Sub
    End Structure
    Private Declare Function SelectObject Lib "gdi32.dll" (ByVal hdc As Int32, ByVal hObject As Int32) As Int32
    Private Declare Function SetTextColor Lib "gdi32.dll" (ByVal hdc As Int32, ByVal crColor As Int32) As Int32
    Private Declare Function TextOut Lib "gdi32" Alias "TextOutA" (ByVal hdc As Int32, ByVal x As Int32, ByVal y As Int32, ByVal lpString As String, ByVal nCount As Int32) As Int32
    Private Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As Int32) As Int32
    Private Declare Function FillRect Lib "user32.dll" (ByVal hdc As Int32, ByRef lpRect As RECT, ByVal hBrush As Int32) As Int32
    Private Declare Function GetSysColorBrush Lib "user32" (ByVal nIndex As Int32) As Int32
    Private Const COLOR_HIGHLIGHT As Int32 = 13
    Private Declare Function SetBkMode Lib "gdi32.dll" (ByVal hdc As Int32, ByVal nBkMode As Int32) As Int32
    Private Declare Function GetScrollPos Lib "user32.dll" (ByVal hwnd As Int32, ByVal nBar As Int32) As Int32
    Private Const WM_VSCROLL As Int32 = &H115
    Private Const WM_HSCROLL As Int32 = &H114
#End Region

#Region "New/Dispose"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

        Me.AcceptsTab = True
        Me.BorderStyle = BorderStyle.None
        Me.Font = New System.Drawing.Font("Courier New", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Multiline = True
        Me.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.WordWrap = False

        InitKeywords()
    End Sub

    Protected Shadows Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        CustomBrushes.Dispose()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        Select Case m.Msg
            Case WM_HSCROLL, WM_VSCROLL
                Invalidate()
        End Select
    End Sub
#End Region

#Region "VB.NET Language Data"
    Private Shared _Keywords() As String = {"AddHandler", "AddressOf", "Alias", _
                                "And", "AndAlso", "Ansi", _
                                "As", "Assembly", "Auto", _
                                "Boolean", "ByRef", "Byte", _
                                "ByVal", "Call", "Case", _
                                "Catch", "CBool", "CByte", _
                                "CChar", "CDate", "CDbl", _
                                "CDec", "Char", "CInt", _
                                "Class", "CLng", "CObj", _
                                "Const", "CShort", "CSng", _
                                "CStr", "CType", "Date", _
                                "Decimal", "Declare", "Default", _
                                "Delegate", "Dim", "DirectCast", _
                                "Do", "Double", "Each", _
                                "Else", "ElseIf", "End", _
                                "EndIf", "Enum", "Erase", _
                                "Error", "Event", "Exit", _
                                "False", "Finally", "For", _
                                "Friend", "Function", "Get", _
                                "GetType", "GoSub", "GoTo", _
                                "Handles", "If", "Implements", _
                                "Imports", "In", "Inherits", _
                                "Integer", "Interface", "Is", _
                                "Let", "Lib", "Like", _
                                "Long", "Loop", "Me", _
                                "Mod", "Module", "MustInherit", _
                                "MustOverride", "MyBase", "MyClass", _
                                "Namespace", "New", "Next", _
                                "Not", "Nothing", "NotInheritable", _
                                "NotOverridable", "Object", "On", _
                                "Option", "Optional", "Or", _
                                "OrElse", "Overloads", "Overridable", _
                                "Overrides", "ParamArray", "Preserve", _
                                "Private", "Property", "Protected", _
                                "Public", "RaiseEvent", "ReadOnly", _
                                "ReDim", "RemoveHandler", "Resume", _
                                "Return", "Select", "Set", _
                                "Shadows", "Shared", "Short", _
                                "Single", "Static", "Step", _
                                "Stop", "String", "Structure", _
                                "Sub", "SyncLock", "Then", _
                                "Throw", "To", "True", _
                                "Try", "TypeOf", "Unicode", _
                                "Until", "Variant", "Wend", _
                                "When", "While", "With", _
                                "WithEvents", "WriteOnly", "Xor"}
    Private Shared _ReservedWords As String() = {"Game", "curCounter", "curGroup", _
                                "curTimer", "System", "Int16", _
                                "Int32", "Int64", "Color", _
                                "REM", "ArrayList", "Math", Chr(13)}
    Public Const Delimiters As String = "+=*/=^'""<>!:,.#$%&(){}[] " + Chr(10) + Chr(13) + vbTab

    Public Shared Keywords As New ArrayList
    Public Shared ReservedWords As New ArrayList

    Public Shared Sub InitKeywords()
        If Keywords.Count > 0 Then Return
        For i As Integer = 0 To _Keywords.Length - 1
            Keywords.Add(_Keywords(i).ToLower)
        Next
        For i As Integer = 0 To _ReservedWords.Length - 1
            ReservedWords.Add(_ReservedWords(i).ToLower)
        Next
    End Sub

    Class VBBrushes
        Public Keyword As New SolidBrush(Color.Blue)
        Public Comment As New SolidBrush(Color.DarkGreen)
        Public [String] As New SolidBrush(Color.Gray)
        Public Other As New SolidBrush(Color.Black)
        Public ReservedWord As New SolidBrush(Color.Black)

        Sub Dispose()
            Keyword.Dispose()
            Comment.Dispose()
            [String].Dispose()
            Other.Dispose()
            ReservedWord.Dispose()
        End Sub

        Function GetColor(ByVal brush As SolidBrush) As Integer
            Return Color.FromArgb(0, brush.Color.B, brush.Color.G, brush.Color.R).ToArgb
        End Function
    End Class

    Private _customBrushes As New VBBrushes

    ReadOnly Property CustomBrushes() As VBBrushes
        Get
            Return _customBrushes
        End Get
    End Property
#End Region

#Region "Drawing"
    Private _doColorCode As Boolean = True

    Property DoColorCode() As Boolean
        Get
            Return _doColorCode
        End Get
        Set(ByVal value As Boolean)
            _doColorCode = value
            SetStyle(ControlStyles.AllPaintingInWmPaint, value)
            SetStyle(ControlStyles.UserPaint, value)
            SetStyle(ControlStyles.DoubleBuffer, value)
        End Set
    End Property

    Dim tmpPos As Point
    Dim FullRedraw As Boolean
    Dim DividerPositions() As Integer = {}

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If LockUpdate Then Return
        Me.Font = New System.Drawing.Font("Courier New", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'MyBase.OnPaint(e)
        'Redraw(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height, e.Graphics)
        'Redraw(0, 0, Width, Height, e.Graphics)
        FullRedraw = Not (e.ClipRectangle.X > 0 Or e.ClipRectangle.Y > 0 Or e.ClipRectangle.Width < ClientSize.Width Or e.ClipRectangle.Height < ClientSize.Height)
        If Not DoColorCode Then
            MyBase.OnPaint(e)
        Else
            Try
                Redraw(e.Graphics)
            Catch
                DoColorCode = False
            End Try
        End If
    End Sub

    Sub Redraw(ByVal g As Graphics)
        'Sub Redraw(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal g As Graphics)
        If Text = "" Then Return

        'With g
        '    Dim startChar As Integer = GetCharIndexFromPosition(New Point(x, y))
        '    Dim endChar As Integer = GetCharIndexFromPosition(New Point(w, h))
        '    endChar = GetFirstCharIndexFromLine(GetLineFromCharIndex(GetCharIndexFromPosition(New Point(w, h)))) + Lines(GetLineFromCharIndex(GetCharIndexFromPosition(New Point(w, h)))).Length - 1
        '    'Dim normal As New SolidBrush(Colors.Other)

        '    'Dim textSize As SizeF = g.MeasureString("W", Font)
        '    'Dim textWidth As Double = textSize.Width - 2

        '    'String to draw
        '    Dim str As String = Text.Substring(startChar, endChar - startChar + 1)
        '    Dim ic As New IndexBrushArray

        '    'Separate string
        '    Dim startIndex As Integer
        '    For i As Integer = 0 To str.Length - 1
        '        If Delimiters.IndexOf(str.Chars(i)) > -1 Then
        '            'Delimiter
        '            If Keywords.Contains(i) Then
        '                ic.Add(startIndex + startChar, CustomBrushes.Keyword, str.Substring(startIndex, i - startIndex))
        '            Else
        '                ic.Add(startIndex + startChar, CustomBrushes.Other, str.Substring(startIndex, i - startIndex))
        '            End If
        '            startIndex = i
        '        End If
        '    Next

        '    'Draw string
        '    For i As Integer = 0 To ic.Count - 1
        '        'Dim pt As New PointF(textWidth * i, GetPositionFromCharIndex(i).Y)
        '        Dim pt As PointF = GetPositionFromCharIndex(i)
        '        g.DrawString(ic(i).ReplaceString, Font, ic(i).Brush, pt)
        '    Next
        '    normal.Dispose()
        'End With
        'Return
        With g
            If Me.ReadOnly Then
                .Clear(SystemColors.Control)
            Else
                .Clear(BackColor)
            End If

            'Get font dimensiosn
            Dim TextSize As SizeF = .MeasureString("W", Font)
            TextSize.Width -= 4.7

            'Get first and last characters to draw
            Dim FirstChar As Integer = GetCharIndexFromPosition(New Point(0, 0))
            Dim LastChar As Integer = GetCharIndexFromPosition(New Point(Width, Height))

            'FirstChar must start a new line
            While FirstChar > 0 AndAlso (Text.Chars(FirstChar - 1) <> Chr(13) And Text.Chars(FirstChar - 1) <> Chr(10))
                FirstChar -= 1
            End While

            'LastChar must end a line
            While LastChar < TextLength - 1 AndAlso (Text.Chars(LastChar + 1) <> Chr(13) And Text.Chars(LastChar + 1) <> Chr(10))
                LastChar += 1
            End While

            'LastChar must be a valid character number
            If LastChar > TextLength - 1 Then LastChar = TextLength - 1

            'Draw text
            Dim updatedText As String = Text
            If LastChar >= FirstChar Then

                'Color-code text
                Dim colorCode As IndexBrushArray = ParseText(FirstChar, Text.Substring(FirstChar, LastChar - FirstChar + 1))
                If colorCode.Count = 0 Then GoTo DoneDrawingText

                'Get HDC for GDI drawing
                Dim tmp As IntPtr
                Try
                    tmp = .GetHdc
                Catch
                    DoColorCode = False
                    Return
                End Try

                For i As Integer = 0 To colorCode.Count - 1
                    'Calculate where to draw
                    Dim p As Point = GetPositionFromCharIndex(colorCode(i).Index)
                    If p.X > 65000 Then p.X = p.X - 65536

                    'Calculate length of substring
                    Dim Length As Integer
                    If i = colorCode.Count - 1 Then
                        Length = (TextLength - 1) - colorCode(i).Index + 1
                    Else
                        Length = colorCode(i + 1).Index - colorCode(i).Index
                    End If

                    'Text
                    Dim str As String
                    If colorCode(i).ReplaceString <> "" Then
                        str = colorCode(i).ReplaceString
                    Else
                        str = Text.Substring(colorCode(i).Index, Length)
                    End If
                    If colorCode(i).Index + str.Length < updatedText.Length Then
                        updatedText = updatedText.Substring(0, colorCode(i).Index) & str & updatedText.Substring(colorCode(i).Index + str.Length)
                    Else
                        updatedText = updatedText.Substring(0, colorCode(i).Index) & str
                    End If

                    str = str.TrimEnd(" ", Chr(10), Chr(13), vbTab)

                    'Draw the substring
                    '.DrawString(str, Font, colorCode(i).Brush, p.X, p.Y)

                    SelectObject(tmp.ToInt32, Font.ToHfont.ToInt32)
                    SetTextColor(tmp.ToInt32, CustomBrushes.GetColor(colorCode(i).Brush))
                    'DrawText(tmp, str, str.Length, New RECT(p.X, p.Y, 32000, 100), 0)
                    'TextOut(tmp.ToInt32, p.X, p.Y, str, str.Length)
                    SetBkMode(tmp.ToInt32, 1)
                    DrawText(tmp.ToInt32, str, str.Length, New RECT(p.X, p.Y, 32000, 100), 0)
                    DeleteObject(Font.ToHfont.ToInt32)

                    '.ReleaseHdc()
                    Dim arr() As Integer
                    ReDim arr(str.Length - 1)
                    For j As Integer = 0 To str.Length - 1
                        arr(j) = 7
                    Next
                    'ExtTextOut(.GetHdc, p.X, p.Y, 0, New RECT(p.X, p.Y, 100, 100), str, str.Length, arr(0))
                    '.ReleaseHdc()

                    '.DrawLine(New Pen(charColor), p.X, p.Y, p.X + .MeasureString(str, rtb.Font).Width, p.Y + .MeasureString(str, rtb.Font).Height)
ContinueFor:
                Next
                .ReleaseHdc(tmp)

                'Draw highlighted text
                Dim starthighlight As Integer = SelectionStart
                Dim stophighlight As Integer = SelectionStart + SelectionLength - 1
                If Not ((starthighlight < FirstChar And stophighlight < FirstChar) Or _
                        (starthighlight > LastChar And stophighlight > LastChar)) Then
                    If starthighlight < FirstChar Then starthighlight = FirstChar
                    If stophighlight > LastChar Then stophighlight = LastChar
                    Try
                        Dim linestart As Integer = starthighlight
                        Dim highlighting As Boolean = True
                        For i As Integer = starthighlight To stophighlight Step 1
                            If Text.Chars(i) = Chr(13) Or Text.Chars(i) = Chr(10) Or i = stophighlight Then
                                If highlighting Then
                                    highlighting = False

                                    'Simulate line break
                                    If i = stophighlight Then i += 1

                                    'Get text
                                    Dim length As Integer = i - linestart
                                    Dim txt As String = updatedText.Substring(linestart, length)

                                    'Draw highlight
                                    Dim p As Point = GetPositionFromCharIndex(linestart)
                                    If p.X > 32768 Then p.X = p.X - 65536
                                    Dim r As RECT = New RECT(p.X + 2, p.Y, TextSize.Width * txt.Length, TextSize.Height - 1)
                                    SetBkMode(tmp.ToInt32, 1)
                                    '.FillRectangle(New Pen(SystemColors.Highlight).Brush, New Rectangle(p.X + 2, p.Y, .MeasureString(New String("N", txt.Length), Font).Width - 3, TextSize.Height - 1))
                                    tmp = .GetHdc
                                    FillRect(tmp.ToInt32, r, GetSysColorBrush(COLOR_HIGHLIGHT))

                                    'Draw highlighted text
                                    '.DrawString(txt, Font, New Pen(SystemColors.HighlightText).Brush, p.X, p.Y)
                                    SelectObject(tmp.ToInt32, Font.ToHfont.ToInt32)
                                    SetTextColor(tmp.ToInt32, CustomBrushes.GetColor(SystemBrushes.HighlightText))
                                    DrawText(tmp.ToInt32, txt, txt.Length, New RECT(p.X, p.Y, 32000, 100), 0)
                                    DeleteObject(Font.ToHfont.ToInt32)
                                    .ReleaseHdc(tmp)
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
                Dim startLine As Integer = GetLineFromCharIndex(colorCode(0).Index)
                Dim stopLine As Integer = GetLineFromCharIndex(colorCode(colorCode.Count - 1).Index)
                Dim tmpDividerPositions() As Integer = {}
                For i As Integer = startLine + 1 To stopLine
                    Dim tmpLine As String = Lines(i).Trim.ToLower
                    tmpLine = ClipModifiers(tmpLine)
                    If tmpLine.StartsWith("sub ") Or tmpLine.StartsWith("function ") Or tmpLine.StartsWith("property") Then
                        'Get char pos
                        Dim y As Integer = GetPositionFromCharIndex(colorCode(0).Index).Y
                        If y > 32768 Then y -= 65536
                        If i - startLine > 0 Then
                            If i > 0 Then
                                Dim prevline As String = ClipModifiers(Lines(i - 1).ToLower.Trim).Trim
                                If Not (prevline.StartsWith("class") Or prevline.StartsWith("interface") Or prevline.StartsWith("structure") Or prevline.StartsWith("module")) Then
                                    y += (FontHeight) * (i - startLine - IIf(i > 0 AndAlso Lines(i - 1).Trim = "", 1, 0))

                                    'Store position
                                    ReDim tmpDividerPositions(UBound(tmpDividerPositions) + 1)
                                    tmpDividerPositions(UBound(tmpDividerPositions)) = y

                                    .DrawLine(New Pen(Color.Gray), 0, y, Width, y)
                                End If
                            End If
                        End If
                    End If
                Next

                If Not FullRedraw Then
                    If tmpDividerPositions.Length <> DividerPositions.Length Then
                        Invalidate()
                    Else
                        For i As Integer = 1 To UBound(tmpDividerPositions)
                            If tmpDividerPositions(i) <> DividerPositions(i) Then
                                Invalidate()
                                Exit For
                            End If
                        Next
                    End If
                End If
                DividerPositions = tmpDividerPositions

            End If

DoneDrawingText:

            ''Draw caret
            'If rtb.Focused And blinkSwitch Then
            '    Dim SelStart As Point
            '    SelStart = GetPositionFromCharIndex(SelectionStart)
            '    .FillRectangle(Brushes.Black, SelStart.X + 2, SelStart.Y, 2, TextSize.Height - 1)
            'End If
        End With
    End Sub
#End Region

#Region "IndexBrushArray"
    Public Class IndexBrushArray
        Inherits ArrayList

        Public Overloads Sub Add(ByVal index As Integer, ByVal Brush As Brush, Optional ByVal ReplaceString As String = "")
            Add(New IndexBrushArrayItem(index, Brush, ReplaceString))
        End Sub

        Public Overloads Sub Add(ByVal value As IndexBrushArrayItem)
            MyBase.Add(value)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As IndexBrushArrayItem
            Get
                Return MyBase.Item(index)
            End Get
            Set(ByVal Value As IndexBrushArrayItem)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    Public Class IndexBrushArrayItem
        Public Index As Integer, Brush As Brush, ReplaceString As String

        Sub New(ByVal anIndex As Integer, ByVal aBrush As Brush, Optional ByVal ReplaceWith As String = "")
            Index = anIndex
            Brush = aBrush
            ReplaceString = ReplaceWith
        End Sub
    End Class
#End Region

#Region "Parsing"
    Function ParseText(ByVal offset As Integer, ByVal str As String) As IndexBrushArray
        Dim ret As New IndexBrushArray
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
                        Dim ReservedWordIndex As Integer = ReservedWords.IndexOf(str.Substring(WordStart, i - WordStart).ToLower)
                        If KeywordIndex > -1 Then
                            'Keyword
                            newLine = False
                            ret.Add(offset + WordStart, CustomBrushes.Keyword, _Keywords(KeywordIndex))
                        ElseIf ReservedWordIndex > -1 Then
                            'Reserved word
                            newLine = False
                            ret.Add(offset + WordStart, CustomBrushes.ReservedWord, _ReservedWords(ReservedWordIndex))
                        Else
                            'Other word
                            If newLine OrElse (ret.Count = 0 OrElse Not (ret(ret.Count - 1).Brush.Equals(CustomBrushes.Other))) Then
                                newLine = False
                                ret.Add(offset + WordStart, CustomBrushes.Other)
                            End If
                        End If
                    End If

                    'Non-whitespace Delimiter
                    If str.Chars(i) <> " " And str.Chars(i) <> vbTab And str.Chars(i) <> Chr(13) And str.Chars(i) <> Chr(10) Then
                        If newLine OrElse (ret.Count = 0 OrElse Not (ret(ret.Count - 1).Brush.Equals(CustomBrushes.Other))) Then
                            newLine = False
                            ret.Add(offset + i, CustomBrushes.Other)
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
                    ret.Add(offset + i, CustomBrushes.Comment)
                    newLine = True
                    NextLine(i, str) : GoTo top
                End If

                'Check strings
                If str.Chars(i) = """" Then
                    'String
                    newLine = False
                    ret.Add(offset + i, CustomBrushes.String)
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
            ret.Add(offset + WordStart, CustomBrushes.Other)
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

#Region "Typing Intellisense"
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If [ReadOnly] Then Exit Sub

        If e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            If Not Multiline Then Invalidate()
        ElseIf e.KeyCode = Keys.V AndAlso e.Control Then
            Paste(DataFormats.GetFormat(DataFormats.Text))
            e.Handled = True
        ElseIf e.KeyCode = Keys.Back Then
            'Auto-delete tabs
            If SelectionLength > 0 Then GoTo ExitSub
            Dim i As Integer
            For i = SelectionStart - 1 To 0 Step -1
                Select Case Text.Chars(i)
                    Case " "
                    Case Chr(13), Chr(10)
                        Exit For
                    Case Else
                        GoTo ExitSub
                End Select
            Next
            Dim indent As Integer = SelectionStart - i - 1
            If indent = 0 Then GoTo ExitSub
            Dim removeLength As Integer = indent Mod 4
            If removeLength = 0 Then removeLength = 4
            [Select](SelectionStart - removeLength, removeLength)
            SelectedText = ""
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            'Get current line up to caret
            Dim i, firstCharIndex As Integer
            For i = SelectionStart - 1 To 0 Step -1
                Select Case Text.Chars(i)
                    Case Chr(13), Chr(10)
                        Exit For
                End Select
            Next
            firstCharIndex = i

            'If the caret is in the middle of a line,
            'do not create any autotext
            Dim NoAutoText As Boolean
            Try
                For i = SelectionStart To TextLength - 1
                    Select Case Text.Chars(i)
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

            Dim curLine0 As String = Text.Substring(firstCharIndex + 1, SelectionStart - firstCharIndex - 1).ToLower
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
            Dim autoLine As String = ""
            Dim tryCatch As Boolean
            If Not NoAutoText Then
                Try
                    If CheckLineStartsWith(curLine, "for") Then
                        autoLine = "Next"
                    ElseIf CheckLineStartsWith(curLine, "if") Then
                        Dim p As Placement = CheckLineContains(curLine, "then")
                        If p = Placement.None Then
                            SelectedText = " Then"
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
                        Dim str As String, tmplen As Integer
                        Dim oldSelStart As Integer = SelectionStart
                        If isReadOnly Or (Not isReadOnly And Not isWriteOnly) Then
                            str = vbCrLf + New String(" ", indent + 4) + "Get" + vbCrLf + New String(" ", indent + 8)
                            tmplen = Len(str)
                            SelectedText = str + vbCrLf + New String(" ", indent + 4) + "End Get"
                        End If
                        If isWriteOnly Or (Not isReadOnly And Not isWriteOnly) Then
                            str = vbCrLf + New String(" ", indent + 4) + "Set(ByVal value As " + DataType + ")" + vbCrLf + New String(" ", indent + 8)
                            If tmplen = 0 Then tmplen = Len(str)
                            SelectedText = str + vbCrLf + New String(" ", indent + 4) + "End Set"
                        End If
                        SelectedText = vbCrLf + New String(" ", indent) + "End Property"
                        SelectionStart = oldSelStart + tmplen - 2
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
                        SelectedText = vbCrLf + New String(" ", indent + 4) + "Case "
                        autoLine = "End Select"
                    ElseIf CheckLineStartsWith(curLine, "case") Then
                        autoLine = " "
                    ElseIf CheckLineStartsWith(curLine, "elseif") Then
                        If CheckLineContains(curLine, "then") = Placement.None Then
                            SelectedText = " Then"
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
                    SelectedText = vbCrLf + New String(" ", indent + 4) + vbCrLf + New String(" ", indent) + autoLine
                    SelectionStart -= (Len(autoLine) + indent + 1)
                Else
                    SelectedText = vbCrLf + New String(" ", indent + 4)
                    SelectionStart -= (Len(autoLine) - 1)
                End If
                If tryCatch Then SelectionStart += 2
            Else
                SelectedText = vbCrLf + New String(" ", indent)
            End If
            e.Handled = True
        End If
ExitSub:
        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If [ReadOnly] Then Exit Sub
        If e.KeyChar = vbTab Then 'Tab
            SelectedText = "    "
            e.Handled = True
        End If
        MyBase.OnKeyPress(e)
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
                End If
            Catch
            End Try
        Next
        Return "Object"
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

    Shadows Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            If Value Then
                BackColor = SystemColors.Control
            Else
                BackColor = SystemColors.Window
            End If
        End Set
    End Property

    Public LockUpdate As Boolean
End Class