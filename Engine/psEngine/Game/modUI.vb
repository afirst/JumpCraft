Imports PlatformStudio

Namespace GamePlayer
    Public Module UI
        Sub ClickedControl(ByRef ctrl As PlatformStudio.psUI.psControl, ByVal Index As Integer)
            Select Case ctrl.Action
                Case psUI.psControl.psCtrlAction.None
                Case psUI.psControl.psCtrlAction.ShowWindow
                    Game.CurWinIndex = ctrl.Param1
                Case psUI.psControl.psCtrlAction.MessageBox
                    Dim tmpIcon As MessageBoxIcon
                    Select Case ctrl.Param3
                        Case 0 : tmpIcon = MessageBoxIcon.None
                        Case 1 : tmpIcon = MessageBoxIcon.Information
                        Case 2 : tmpIcon = MessageBoxIcon.Question
                        Case 3 : tmpIcon = MessageBoxIcon.Exclamation
                        Case 4 : tmpIcon = MessageBoxIcon.Error
                    End Select
                    MessageBox.Show(ctrl.Param2, ctrl.Param1, MessageBoxButtons.OK, tmpIcon)
                Case psUI.psControl.psCtrlAction.OpenFile
                    Process.Start(GetRelativeFile(ctrl.Param1))
                Case psUI.psControl.psCtrlAction.OpenURL
                    Process.Start(ctrl.Param1)
                Case psUI.psControl.psCtrlAction.PauseGame
                    Paused = True
                    Game.CurWinIndex = PauseWindow
                    PauseStart = Timer
                Case psUI.psControl.psCtrlAction.QuitGame
                    Game.PresetActions.QuitGame()
                Case psUI.psControl.psCtrlAction.RunScript
                    ActionProcessor.ProcessUIAction("win" & Game.CurWinIndex & "ctrl" & Index, ctrl.Text, Game.CurWindow.Name, ctrl)
                Case psUI.psControl.psCtrlAction.Exit
                    f.RequestClose()
            End Select
        End Sub
    End Module
End Namespace