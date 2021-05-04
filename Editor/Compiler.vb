Public Module modCompiler
    Public Code As New System.Text.StringBuilder
End Module

Public Class Compiler
    Function CompileDLL() As Boolean
        Dim i As Integer, j As Integer
        Dim Triggers() As String
        Dim SortedActions()() As PlatformStudio.psActions.psAction
        Dim bInTriggerList As Boolean

        Code = New System.Text.StringBuilder

        'Header---------------------------------------------------
        Code.Append("Imports System" & vbCrLf & _
                    "Imports System.Drawing" & vbCrLf & _
                    "Imports System.Windows.Forms" & vbCrLf & _
                    "Imports Microsoft.VisualBasic" & vbCrLf & _
                    "Imports PlatformStudio" & vbCrLf & _
                    vbCrLf & _
                    "Namespace Script" & vbCrLf & _
                    "    <Serializable> Class ScriptObject" & vbCrLf & _
                             Game.actions.getClassHeader() & vbCrLf & _
                             Game.actions.Globals & vbCrLf & _
                             vbCrLf)

        'Body-----------------------------------------------------
        ReDim Triggers(0)

        'Structure: 1st dimension is the list of triggers,
        '2nd is the list of actions for each trigger
        ReDim SortedActions(0)

        For i = 1 To UBound(Game.actions.Actions)
            With Game.actions.Actions(i)
                bInTriggerList = False
                For j = 1 To UBound(Triggers)
                    If Triggers(j) = .Trigger Then

                        'Add to actions list
                        ReDim Preserve SortedActions(j)(UBound(SortedActions(j)) + 1)
                        SortedActions(j)(UBound(SortedActions(j))) = Game.actions.Actions(i).Clone
                        bInTriggerList = True
                        Exit For

                    End If
                Next
                If Not bInTriggerList Then

                    'Make a new actions list and Add to it
                    ReDim Preserve SortedActions(UBound(SortedActions) + 1)
                    ReDim SortedActions(UBound(SortedActions))(1)
                    SortedActions(UBound(SortedActions))(1) = Game.actions.Actions(i).Clone

                    'Add to triggers list
                    ReDim Preserve Triggers(UBound(Triggers) + 1)
                    Triggers(UBound(Triggers)) = .Trigger

                End If
            End With
        Next

        'Create the body string
        Dim strParams As String

        '1. Trigger Actions
        Code.Append("'Trigger actions" & vbCrLf)
        Code.Append("'---------------" & vbCrLf)
        For i = 1 To UBound(SortedActions)
            Select Case SortedActions(i)(1).Trigger.Chars(0)
                Case "c" : strParams = "ByVal curCounter As PlatformStudio.CurrentCounter"
                Case "i" : strParams = "ByVal curTimer As PlatformStudio.CurrentTimer"
                Case "g", "t" : strParams = "ByVal curGroup As PlatformStudio.CurrentGroup"
                Case Else : strParams = ""
            End Select
            Code.Append("Function " & SortedActions(i)(1).Trigger & "(" & strParams & ")" & vbCrLf)
            For j = 1 To UBound(SortedActions(i))
                Code.Append(Action2Code(SortedActions(i)(j).Action) & vbCrLf)
                If j = UBound(SortedActions(i)) Then
                    Code.Append("End Function" & vbCrLf)
                End If
            Next
            Code.Append(vbCrLf)
        Next

        ''2. Click Actions
        'strParams = ""
        'Dim FirstCtrlScript As Boolean = True
        'For i = 1 To Game.numWindows
        '    For j = 1 To Game.windows.Windows(i).NumCtrls
        '        With Game.windows.Windows(i).Controls(j)
        '            If .Action = PlatformStudio.UI.psControl.psCtrlAction.RunScript Then
        '                If FirstCtrlScript Then
        '                    Code.Append("'Control scripts" & vbCrLf)
        '                    Code.Append("'---------------" & vbCrLf)
        '                    FirstCtrlScript = False
        '                End If
        '                Code.Append("Function " & "win" & i & "ctrl" & j & "(" & strParams & ")" & vbCrLf)
        '                Code.Append(.Param1 & vbCrLf)
        '                Code.Append("End Function" & vbCrLf & vbCrLf)
        '            End If
        '        End With
        '    Next
        'Next

        'Footer---------------------------------------------------
        Code.Append("    End Class" & vbCrLf & _
                    "End Namespace")
        '---------------------------------------------------------

        'Variables
        Dim DLLCreator As New PlatformStudio.psDLL
        Dim err() As System.CodeDom.Compiler.CompilerError
        Dim strCode As String = Code.ToString

        'Compile the DLL
        If DLLCreator.CompileDLL(Game.Root & "~_tmp3", "ScriptObject", strCode, err) = False Then
            Dim f As New frmCompileError
            f.ShowDialog(strCode, err)
            If IO.File.Exists(Game.Root & "~_tmp3.dll") Then
                IO.File.Delete(Game.Root & "~_tmp3.dll")
            End If
            DLLCreator = Nothing
            Return False
        End If

        DLLCreator = Nothing
        Return True

    End Function

    Function Action2Code(ByVal Action As PlatformStudio.psActions.psAction.psAction2) As String
        Dim tmp As String = Action.Behavior.Code
        If tmp Is Nothing Then Return ""
        Dim i As Integer
        For i = UBound(Action.param) To 1 Step -1
            If Not Action.param(i) Is Nothing AndAlso Action.param(i).StartsWith("<SCRIPT>") Then
                tmp = tmp.Replace("Color.FromARGB(&param" & i & ")", Action.param(i).Substring(8))
                tmp = tmp.Replace("""&param" & i & """", Action.param(i).Substring(8))
                tmp = tmp.Replace("&param" & i, Action.param(i).Substring(8))
            Else
                If Action.Behavior.params(i).ValueType = PlatformStudio.psActions.psValueType.YesNo Then
                    tmp = tmp.Replace("&param" & i, IIf(Action.param(i) = "Yes", "True", "False"))
                ElseIf Action.Behavior.params(i).ValueType = PlatformStudio.psActions.psValueType.Color Then
                    Dim tmpColor As Color
                    tmpColor = Color.FromName(Action.param(i))
                    If tmpColor.ToArgb = 0 Then tmpColor = Color.FromArgb(Convert.ToInt32(Action.param(i), 16))
                    tmp = tmp.Replace("&param" & i, tmpColor.ToArgb)
                Else
                    tmp = tmp.Replace("&param" & i, Action.param(i))
                End If
            End If
        Next
        Return tmp
    End Function
End Class