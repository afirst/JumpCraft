Public Class psFileUpdater
    Public AlwaysUpdate As Boolean = False

    Public Shared SupportedFormats() As String = {"Platform Studio 2.0 Game", _
                                    "PSG2.1", "PSG2.11", "PSG2.12", "PSG2.2", "PSG2.21", "PSG2.5", "PSG3.0"}

    Public Shared ReadOnly HEADER_TEXT As String = SupportedFormats(SupportedFormats.Length - 1)
    Public Shared curVersion As Double

    'Sub ReorderParameter(ByVal Action As String, ByVal Parameter As String, ByVal OldValue As String, ByVal NewValue As String)
    '    With Game.actions
    '        For i As Integer = 1 To UBound(Game.actions.Actions)
    '            If Game.actions.Dat.ab(Game.actions.Actions(i).Action.Type).Name = Action Then
    '                For j As Integer = 1 To UBound(.Dat.ab(.Actions(i).Action.Type).params)
    '                    If .Dat.ab(.Actions(i).Action.Type).params(j).Name = Parameter Then
    '                        If .Actions(i).Action.param(j) = OldValue Then
    '                            .Actions(i).Action.param(j) = NewValue
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        Next
    '    End With
    'End Sub
    Private Sub AddNecessaryParameters()
        With Game.actions
            For i As Integer = 1 To UBound(.Actions)
                While .Actions(i).Action.param.Length < .Dat.ab(.Actions(i).Action.Type).params.Length
                    ReDim Preserve .Actions(i).Action.param(UBound(.Actions(i).Action.param) + 1)
                    .Actions(i).Action.param(UBound(.Actions(i).Action.param)) = .Dat.ab(.Actions(i).Action.Type).params(UBound(.Actions(i).Action.param)).DefaultValue
                End While
            Next
        End With
    End Sub

    Enum ValidFileEnum
        Invalid
        Valid
        RefuseUpdate
    End Enum

    Function IsValidFile(ByVal headerText As String, Optional ByVal MustUpdate As Boolean = False) As ValidFileEnum
        If Not Game.InEditor Then AlwaysUpdate = False

        curVersion = GetVersionNumber(headerText)
        For n As Integer = 0 To SupportedFormats.Length - 1
            If SupportedFormats(n) = headerText Then
                If Not AlwaysUpdate AndAlso n = SupportedFormats.Length - 1 Then
                    'Latest version
                Else
                    'Needs to be updated
                    If Not MustUpdate Then
                        If MessageBox.Show(GetString("updateFileMessage"), "JumpCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            MessageBox.Show(GetString("updateFileFailedMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            FileClose(1)
                            Return ValidFileEnum.RefuseUpdate
                        End If
                    End If
                End If
                Return ValidFileEnum.Valid
            End If
        Next
        Return ValidFileEnum.Invalid
    End Function

    Function UpdateFile(ByVal headerText As String, Optional ByVal OnlyTileset As Boolean = False) As Boolean
        'If AlwaysUpdate Then headerText = "PSG2.1"

        Dim Version As Double = GetVersionNumber(headerText)

        'Finish loading any data
        If psFileHandler.OldFileType AndAlso Version >= 2.1 Then
            For i As Integer = 1 To Game.tileset.NumTiles
                Game.tileset.tiles(i).HitPoints = psFileHandler.bReader.ReadByte
            Next
        End If
        If Version >= 2.12 Then
            Game.tileW = psFileHandler.bReader.ReadInt32
            Game.tileH = psFileHandler.bReader.ReadInt32
            Game.tileColorKey = psFileHandler.bReader.ReadInt32
        End If
        If Version >= 2.21 Then
            Game.tileset.LoadData()
        End If

        If AlwaysUpdate OrElse headerText <> SupportedFormats(SupportedFormats.Length - 1) Then
            Dim UpgradeWarning As String = ""
            Select Case Version
                Case 2.0
                    'Version-specific code
                    For i As Integer = 1 To UBound(Game.actions.Actions)
                        With Game.actions.Actions(i).Action
                            If .Behavior.Name = "Jump" Then
                                .param(1) *= 4 / 0.6
                                .param(2) *= 2 / 0.25
                                .param(3) = 0.5 / .param(3)
                            End If
                        End With
                    Next
                    ReplaceScript("game.jump", "Game.Compatibility.Jump")
                    UpgradeWarning &= vbCrLf & "Make sure jump parameters are correct.  ""Jump time"" changed to ""jump height"" and ""scale speed"" changed to ""jump time""."
            End Select

            If Not OnlyTileset Then
                Game.actions.Dat = DefaultActData.Clone
            End If
            AddNecessaryParameters()

            'Show upgrade warning
            If Not OnlyTileset AndAlso UpgradeWarning <> "" Then
                MessageBox.Show(String.Format(GetString("upgradeWarning"), UpgradeWarning), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Updated
            Return True
        Else
            'Did not update
            Return False
        End If
    End Function

    Private Sub ReplaceScript(ByVal search As String, ByVal replace As String)
        For i As Integer = 1 To UBound(Game.actions.Actions)
            With Game.actions.Actions(i).Action
                If .Behavior.Name = "Execute Script" Then
                    .param(1) = .param(1).Replace(search, replace)
                End If
            End With
        Next
    End Sub

    Private Function GetVersionNumber(ByVal HeaderText As String) As Double
        Select Case HeaderText
            Case "Platform Studio 2.0 Game", "", Nothing
                Return 2.0
            Case Else
                Return CDbl(HeaderText.Substring(3))
        End Select
    End Function
End Class

Public Interface ICompatibility
    Sub Jump(ByVal Length As Single, ByVal MinLength As Single, ByVal ScaleSpeed As Single)
End Interface