Imports PlatformStudio
Imports PlatformStudio.GamePlayer

Public Class myClient
    Inherits GamePlayer.GameClient

    Dim tmpMaps() As psMap
    Dim tmpWindows As psUI.psWindows
    Dim tmpActions As psActions
    Dim tmpCam As psGame.psCamera
    Dim tmpCurMapIndex As Integer
    Dim tmpCurWinIndex As Integer
    Dim tmpWindowed As Boolean

    Overrides Sub BeginRendering()
        'Handled by frmMain
    End Sub

    Overrides Sub [End]()
        'While f.InRenderLoop
        'Application.DoEvents()
        'End While
        'f.Dispose()

        ScriptDLL.UnloadDLL()

        Game.Audio.StopMusic()
        Game.Audio.StopSounds()
        Game.Audio.DisposeMP3()
        Game.InEditor = True

        Game.maps = tmpMaps
        Game.windows = tmpWindows
        Game.actions = tmpActions
        Game.cam = tmpCam
        Game.CurMapIndex = tmpCurMapIndex
        Game.CurWinIndex = tmpCurWinIndex

        Game.p = Editor.psedit.p
        Game.hwnd = Editor.psedit.p.Handle.ToInt32
        Game.GameProperties.Windowed = tmpWindowed
        Game.Drawing.Re_Init(Editor.psedit.p)
        Editor.psedit.Active = True

        'UI.psControl.rebuildControlNames()
    End Sub

    Public Overrides Sub SetupGameObject()
        Editor.psedit.Active = False

        tmpMaps = Game.CloneMaps
        tmpWindows = Game.windows.Clone
        tmpActions = Game.actions.Clone
        tmpCam = Game.cam
        tmpCurMapIndex = Game.CurMapIndex
        tmpCurWinIndex = Game.CurWinIndex
        tmpWindowed = Game.GameProperties.Windowed
        Game.GameProperties.Windowed = True

        PlatformStudio.GamePlayer.Game = PlatformStudio.Game

        Game.InEditor = False
        SetupWindow()
        If Game.GameProperties.Windowed Then
            Game.p = f.p
        Else
            Game.p = f
        End If
        Game.windows.p = f
        Game.hwnd = f.Handle.ToInt32
        Game.Drawing.Re_Init(GamePlayer.f)
        Game.PresetActions = New GamePlayer.PresetActions
        Game.CurMapIndex = 1
        Game.CurWinIndex = 1
        Game.Audio.DisposeMP3()

        'Reset game player's state
        CurHighScore = 0
        Renderer.ResetState()
    End Sub

    Public Overrides Sub OnQuickResume()
        DirectCast(f, frmMain).ClearFrameTimes()
    End Sub
End Class