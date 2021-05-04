Public Class psTools
    Public Enum Tools
        Draw = 0
        [Erase]
        [Select]
        Pan
    End Enum

    Public buttons(3) As Object
    Private _value As Byte

    Sub New(ByVal DrawButton As Object, ByVal EraseButton As Object, ByVal SelectButton As Object, ByVal PanButton As Object)
        buttons(0) = DrawButton
        buttons(1) = EraseButton
        buttons(2) = SelectButton
        buttons(3) = PanButton
        Editor.pstools = Me
    End Sub

    Property Enabled() As Boolean
        Get
            Return buttons(0).Enabled
        End Get
        Set(ByVal Value As Boolean)
            For i As Integer = 0 To 3
                buttons(i).Enabled = Value
            Next
        End Set
    End Property

    Property Value() As Tools
        Get
            Dim i As Integer
            For i = 0 To 3
                If buttons(i).Pushed Then
                    Return i
                End If
            Next
        End Get
        Set(ByVal Value As Tools)
            Dim i As Integer
            For i = 0 To 3
                If buttons(Value).ImageIndex <> i Then
                    buttons(i).Pushed = False
                End If
            Next
            buttons(Value).Pushed = True
            ChangedValue()
        End Set
    End Property

    Sub PushedButton(ByVal buttonIndex As Integer)
        Editor.psedit.Deselect()
        Dim i As Integer
        For i = 0 To 3
            If buttonIndex <> i Then
                buttons(i).Pushed = False
            End If
        Next
        buttons(buttonIndex).Pushed = True
        ChangedValue()
        If Editor.pstileselect Is Nothing Then Exit Sub
        Select Case buttonIndex
            Case 0 'Draw
                If Editor.pstileselect.Value > -1 Then '.list.SelectedIndices.Count = 0 Then
                    Try
                        Editor.pstileselect.Value = 1 '.list.Items(0).Selected = True
                    Catch
                        Value = 1
                    End Try
                End If
                'Case Else 'Erase
                'If Editor.pstileselect.list.SelectedIndices.Count > 0 Then
                '    Editor.pstileselect.list.Items(Editor.pstileselect.list.SelectedIndices(0)).Selected = False
                'End If
        End Select
    End Sub

    Private Sub ChangedValue()
        If Game Is Nothing Then Exit Sub
        If Editor.psedit Is Nothing Then Exit Sub
        With Editor.psedit
            .Deselect()
            psEditor.sel = New Rectangle(0, 0, 0, 0)
            psEditor.selecting = True
            If Value = 2 Then
                .p.Cursor = Cursors.Cross
            ElseIf Value = 3 Then
                .p.Cursor = Cursors.SizeAll
            Else
                .p.Cursor = Cursors.Default
            End If
        End With
    End Sub
End Class