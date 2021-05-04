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
    Public EXEFile As String
    Public EXEDir As String

    Sub Main(ByVal args() As String)
        '---------------------------------------------------------
        'Arguments are:
        'Filename & Directory of EXE that ran this program & Icon
        '---------------------------------------------------------
        If args.GetUpperBound(0) <> 2 Then Exit Sub

        SkipWindows = False
        Invincible = False
        StartAtLevel = 1
        ShowFPS = False
        EXEFile = args(0)
        EXEDir = args(1)
        Filename = Application.StartupPath & "\Game.psg"
        DLLFilename = Application.StartupPath & "\actions.dll"
        PlatformStudio.Compiled = True
        PlatformStudio.filerepldir = Application.StartupPath

        Client = New myClient

        f = New frmMain
        args(2) = Application.StartupPath & "\" & IO.Path.GetFileName(args(2))
        If IO.File.Exists(args(2)) Then f.Icon = New Icon(args(2))

        f.Show()
    End Sub

End Module