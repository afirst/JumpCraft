'NOTE: This module and the game window
'(design, not code), and the error window
'are the only things that will change from the
'tester to the final game.  The rest of the
'modules and files are identical.
'In this module, only code below the
'RenderingWindow variable differs.

Imports PlatformStudio
Imports PlatformStudio.GamePlayer

Public Module modMain

    Sub Main(ByVal args() As String)
        '---------------------------------------------------------
        'Arguments are:
        'Passcode, Filename, SkipWindows, Invincible, StartAtLevel
        '---------------------------------------------------------
        If args.GetUpperBound(0) <> 6 Then Exit Sub
        If args(0) <> 531583295836193058 Then Exit Sub 'Passcode
        Filename = args(1)
        DLLFilename = args(2)
        SkipWindows = args(3)
        Invincible = args(4)
        StartAtLevel = args(5)
        ShowFPS = args(6)

        Client = New myClient

        f = New frmMain
        f.Show()
    End Sub

End Module