Imports System.IO

Public Class MruList
    Private iniFile As String
    Private FileMenu As Menu
    Private _NumEntries As Integer
    Private FileNames As Collection
    Private MenuItems As Collection
    Private startIndex As Integer

    Public Event OpenFile(ByVal file_name As String)

    Public Sub New(ByVal iniFileName As String, ByVal file_menu As Menu, ByVal start_index As Integer, ByVal num_entries As Integer)
        iniFile = iniFileName
        FileMenu = file_menu
        _NumEntries = num_entries
        FileNames = New Collection
        MenuItems = New Collection
        startIndex = start_index

        ' Load saved file names from the Registry.
        LoadMruList()

        ' Display the MRU list.
        DisplayMruList()
    End Sub

    ' Load previously saved file names from the Registry.
    Private Sub LoadMruList()
        Try
            Dim stream As StreamReader = File.OpenText(iniFile)
            stream.ReadLine()

            Dim file_name As String
            While stream.BaseStream.CanRead
                ' Get the next file name and title.
                file_name = stream.ReadLine()
                If file_name Is Nothing Then Exit While

                ' See if we got anything.
                If file_name.Length > 0 Then
                    ' Save this file name.
                    FileNames.Add(file_name, file_name)
                End If
            End While

            stream.Close()
        Catch
            'MessageBox.Show("An error occured while trying to load the 'most recently used games' file, """ & iniFile & """.  A new blank file will be written in its place.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SaveMruList()
        End Try
    End Sub

    ' Save the MRU list into the Registry.
    Private Sub SaveMruList()
        Try
            Dim stream As StreamWriter = File.CreateText(iniFile)
            stream.WriteLine("[Most Recently Used Games]")

            ' Make the new entries.
            For i As Integer = 1 To FileNames.Count
                stream.WriteLine(FileNames(i).ToString)
            Next

            stream.Close()
        Catch
            MessageBox.Show(String.Format(GetString("main_SaveMRUError"), iniFile), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' MRU menu item event handler.
    Private Sub MruItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnu As MenuItem = DirectCast(sender, MenuItem)

        ' Find the menu item that raised this event.
        For i As Integer = 1 To FileNames.Count
            ' See if this is the item. (Add 1 for the separator.)
            If MenuItems(i + 1) Is mnu Then
                ' This is the item. Raise the OpenFile 
                ' event for its file name.
                RaiseEvent OpenFile(FileNames(i).ToString)
                Exit For
            End If
        Next i
    End Sub

    ' Display the MRU list.
    Private Sub DisplayMruList()
        ' Remove old menu items from the File menu.
        For Each mnu As MenuItem In MenuItems
            FileMenu.MenuItems.Remove(mnu)
        Next mnu
        MenuItems = New Collection

        ' See if we have any file names.
        If FileNames.Count > 0 Then
            ' Make the separator.
            Dim mnu As New MenuItem
            mnu.Text = "-"
            MenuItems.Add(mnu)
            FileMenu.MenuItems.Add(mnu)
            mnu.Index = startIndex + 1
            fGame.UiPlusMenu1.HandleMenuItem(mnu)

            ' Make the other menu items.
            For i As Integer = 1 To FileNames.Count
                mnu = New MenuItem( _
                    "&" & i & " " & IO.Path.GetFileName(FileNames(i).ToString), _
                    New System.EventHandler(AddressOf MruItem_Click))
                MenuItems.Add(mnu)
                FileMenu.MenuItems.Add(mnu)
                mnu.Index = startIndex + 1 + i
                fGame.UiPlusMenu1.HandleMenuItem(mnu)
            Next i
        End If
    End Sub

    ' Add a file to the MRU list.
    Public Sub Add(ByVal file_name As String)
        ' Remove this file from the MRU list
        ' if it is present.
        Dim i As Integer = FileNameIndex(file_name)
        If i > 0 Then FileNames.Remove(i)

        Try
            ' Add the item to the begining of the list.
            If FileNames.Count > 0 Then
                FileNames.Add(file_name, file_name, FileNames.Item(1))
            Else
                FileNames.Add(file_name, file_name)
            End If
        Catch
            'filename might already be in the list
        End Try

        ' If the list is too long, remove the last item.
        If FileNames.Count > NumEntries Then
            FileNames.Remove(NumEntries + 1)
        End If

        ' Display the list.
        DisplayMruList()

        ' Save the updated list.
        SaveMruList()
    End Sub

    ' Return the index of this file in the list.
    Private Function FileNameIndex(ByVal file_name As String) As Integer
        For i As Integer = 1 To FileNames.Count
            If FileNames(i).ToString = file_name Then Return i
        Next i
        Return 0
    End Function

    ' Remove a file from the MRU list.
    Public Sub Remove(ByVal file_name As String)
        ' See if the file is present.
        Dim i As Integer = FileNameIndex(file_name)
        If i > 0 Then
            ' Remove the file.
            FileNames.Remove(i)

            ' Display the list.
            DisplayMruList()

            ' Save the updated list.
            SaveMruList()
        End If
    End Sub

    Public Property NumEntries() As Integer
        Get
            Return _NumEntries
        End Get
        Set(ByVal Value As Integer)
            _NumEntries = Value
            DisplayMruList()
        End Set
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return FileNames.Count
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal index As Integer) As String
        Get
            Return FileNames(index)
        End Get
    End Property
End Class