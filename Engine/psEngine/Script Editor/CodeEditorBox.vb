Public Class CodeEditorBox
    Inherits System.Windows.Forms.RichTextBox

    Event Updated()
    Shadows Event TextChanged()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'sClass = New Subclass(Handle)
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    'Private Const WM_USER = &H400
    Private Const EM_GETSCROLLPOS = (WM_USER + 221)
    Private Const EM_SETSCROLLPOS = (WM_USER + 222)

    'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Integer, ByVal lParam As Object) As Long
    Private Declare Auto Function SendMessage Lib "User32" (ByVal hwnd As System.IntPtr, ByVal msg As Int32, ByVal wParams As Int64, ByVal lParams As Object) As Long
    Private Declare Function GetScrollPos Lib "user32" (ByVal hwnd As IntPtr, ByVal nBar As Integer) As Integer
    Private Declare Function SetScrollPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nBar As Integer, ByVal nPos As Integer, ByVal bRedraw As Boolean) As Integer

    Private Const SIF_RANGE As Integer = 1
    Private Const SIF_PAGE As Integer = 2
    Private Const SIF_POS As Integer = 4
    Private Const SIF_DISABLENOSCROLL As Integer = 8
    Private Const SIF_TRACKPOS As Integer = 16
    Private Const SIF_ALL As Integer = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
    Public Structure SCROLLINFO
        Dim cbSize As Integer
        Dim fMask As Integer
        Dim nMin As Integer
        Dim nMax As Integer
        Dim nPage As Integer
        Dim nPos As Integer
        Dim nTrackPos As Integer
    End Structure
    Private Declare Function GetScrollInfo Lib "user32" Alias "GetScrollInfo" (ByVal Handle As IntPtr, ByVal n As Integer, ByRef lpScrollInfo As SCROLLINFO) As Integer

    Private Const OBJID_VSCROLL = &HFFFFFFFB
    Private Const OBJID_HSCROLL = &HFFFFFFFA
    Private Const STATE_SYSTEM_UNAVAILABLE = &H1& 'Disabled
    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
    Public Structure SCROLLBARINFO
        Dim cbSize As Integer
        Dim rcScrollBar As Rectangle
        Dim dxyLineButton As Integer
        Dim xyThumbTop As Integer
        Dim xyThumbBottom As Integer
        Dim reserved As Integer
        Dim rgstate0, rgstate1, rgstate2, rgstate3, rgstate4, rgstate5 As Integer
    End Structure
    Private Declare Function GetScrollBarInfo Lib "user32" (ByVal Handle As IntPtr, ByVal idObject As Integer, ByRef psbi As SCROLLBARINFO) As Integer

    Private Declare Function IsWindowEnabled Lib "user32" Alias "IsWindowEnabled" (ByVal Handle As IntPtr) As Boolean

    '===================================================================
    ' for NativeWindow and PostMessageA
    '===================================================================
    Private Const WM_HSCROLL = &H114
    Private Const WM_VSCROLL = &H115
    Private Const WM_MOUSEWHEEL = &H20A
    Private Const WM_COMMAND = &H111
    Private Const WM_USER = &H400
    '===================================================================
    ' for GetScroll and PostMessageA
    '===================================================================
    Private Const SBS_HORZ = 0
    Private Const SBS_VERT = 1
    Private Const SB_THUMBPOSITION = 4
    '===================================================================
    ' for SubClassing
    '===================================================================
    'Private WithEvents sClass As Subclass

    Private Declare Function GetScrollRange Lib "user32" Alias "GetScrollRange" (ByVal Handle As IntPtr, ByVal nBar As Integer, ByRef lpMinPos As Integer, ByRef lpMaxPos As Integer) As Integer
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal Handle As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    'Call PostMessage(List2.hwnd, WM_VSCROLL, SB_THUMBPOSITION + &H10000 * lngScrollPos, 0)

    Class pt
        Public x, y As Integer
        Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.x = x
            Me.y = y
        End Sub
    End Class

    'Private Const WM_PAINT = &HF
    'Public LockUpdate As Boolean

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        'RaiseEvent Updated()
        'Dim m As Message = Message.Create(Handle.ToInt32, EM_GETSCROLLPOS, 0, New IntPtr(p))
        'm.
        'Me.WndProc(a)
        Dim p As New Point(0, 0)
        'p = New pt(0, 0)
        Dim i As IntPtr
        Dim max, min As Integer
        GetScrollRange(Handle, SBS_VERT, max, min)
        Dim xpasdf As Boolean = ScrollHEnabled()


        'testObj = max
        '        Dim x As Integer = VScrollPos
        'ScrollV(50)
        '        testObj = GetScrollPos(Handle, SBS_VERT)


        'MsgBox(sbi.nMax)
        Try
            'testObj = ScrollInfo(0).nMax
        Catch
            'testObj = "ERROR"
        End Try
        'SendMessage(Handle, EM_SETSCROLLPOS, 0, p)  'p)
        '        SendMessage(Handle, WM_VSCROLL, SB_THUMBPOSITION + &H10000 * ScrollToPosn, Nothing)
        'ScrollTo(128, 512)

        'MsgBox(i.ToInt32)
        'If p.X <> 0 Then Stop

        RaiseEvent TextChanged()
    End Sub

    ReadOnly Property ScrollVMax() As Integer
        Get
            Dim oldpos As Integer = ScrollV
            SetScrollPos(Handle, SBS_VERT, 1000000000, False)
            Dim tmp As Integer = ScrollV
            ScrollV = oldpos
            Return tmp
        End Get
    End Property

    ReadOnly Property ScrollHMax() As Integer
        Get
            Dim oldpos As Integer = ScrollH
            SetScrollPos(Handle, SBS_HORZ, 1000000000, False)
            Dim tmp As Integer = ScrollH
            ScrollH = oldpos
            Return tmp
        End Get
    End Property

    Property ScrollH() As Integer
        Get
            Return GetScrollPos(Handle, SBS_HORZ)
        End Get
        Set(ByVal Value As Integer)
            'SetScrollPos(Handle, SBS_HORZ, Value, True)
            PostMessage(Handle, WM_HSCROLL, SB_THUMBPOSITION + &H10000 * Value, 0)
        End Set
    End Property

    Property ScrollV() As Integer
        Get
            Return GetScrollPos(Handle, SBS_VERT)
        End Get
        Set(ByVal Value As Integer)
            'SetScrollPos(Handle, SBS_VERT, Value, True)
            PostMessage(Handle, WM_VSCROLL, SB_THUMBPOSITION + &H10000 * Value, 0)
        End Set
    End Property

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        RaiseEvent Updated()
    End Sub

    Protected Overrides Sub OnSelectionChanged(ByVal e As System.EventArgs)
        RaiseEvent Updated()
    End Sub

    ReadOnly Property ScrollHInfo() As SCROLLINFO
        Get
            Return GetScrollInfo(SBS_HORZ)
        End Get
    End Property

    ReadOnly Property ScrollVInfo() As SCROLLINFO
        Get
            Return GetScrollInfo(SBS_VERT)
        End Get
    End Property

    Private Function GetScrollInfo(ByVal n As Integer) As SCROLLINFO
        Dim si As New SCROLLINFO
        si.fMask = SIF_ALL
        si.cbSize = Runtime.InteropServices.Marshal.SizeOf(si.GetType())
        GetScrollInfo(Handle, n, si)
        Return si
    End Function

    ReadOnly Property ScrollHEnabled() As Boolean
        Get
            Return ScrollEnabled(OBJID_HSCROLL)
        End Get
    End Property

    ReadOnly Property ScrollVEnabled() As Boolean
        Get
            Return ScrollEnabled(OBJID_VSCROLL)
        End Get
    End Property

    Private ReadOnly Property ScrollEnabled(ByVal n As Integer) As Boolean
        Get
            Dim si As SCROLLBARINFO
            si.cbSize = Runtime.InteropServices.Marshal.SizeOf(si.GetType())
            GetScrollBarInfo(Handle, n, si)
            Return si.rgstate0 <> STATE_SYSTEM_UNAVAILABLE
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'If LockUpdate AndAlso m.Msg = WM_PAINT Then Exit Sub
        MyBase.WndProc(m)
        If m.Msg = WM_VSCROLL Or m.Msg = WM_HSCROLL Then
            RaiseEvent Updated()
        End If
    End Sub

    Shadows ReadOnly Property FontHeight() As Integer
        Get
            Return MyBase.FontHeight
        End Get
    End Property
End Class