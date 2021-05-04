Imports PlatformStudio
Imports psEditor
Imports psEditor.mDeclarations

Module Packager
    Public OtherFilesStart As Integer
    Private _OutputFolder As String

    Private Structure HighScore
        Dim Name As String
        Dim Level As String
        Dim Score As Long
    End Structure

    ReadOnly Property OutputFolder() As String
        Get
            Return _OutputFolder
        End Get
    End Property

    Function Package() As Boolean
        If Game.GameProperties.Name = "" Then
            MessageBox.Show(GetString("proEd_NoNameErrorMessage"), GetString("proEd_Compile"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim fGP As New frmGameProperties
            fGP.TextBox1.BackColor = Color.Yellow
            fGP.ShowDialog()
            fGP.Dispose()
            Exit Function
        ElseIf Game.GameProperties.Version = "" Then
            MessageBox.Show(GetString("proEd_VersionErrorMessage"), GetString("proEd_Compile"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim fGP As New frmGameProperties
            fGP.TextBox2.BackColor = Color.Yellow
            fGP.ShowDialog()
            fGP.Dispose()
            Exit Function
        End If

        'Choose folder
        Dim folderDialog As New FolderBrowserDialog()
        folderDialog.Description = GetString("proEd_CompileChooseFolderDesc")
        folderDialog.SelectedPath = Application.StartupPath & "\Compiled Games"
        Dim folderDialogResult As DialogResult = folderDialog.ShowDialog()
        folderDialog.Dispose()
        If folderDialogResult = DialogResult.Cancel Then
            Exit Function
        End If
        _OutputFolder = folderDialog.SelectedPath

        'Begin
        psEditor.fGame.Enabled = False
        Dim f As New frmWait
        f.Show()

        Editor.psedit.Deselect(True)
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect(True)

        'Delete package folder
        If IO.Directory.Exists(Game.Root & "Package") Then
            IO.Directory.Delete(Game.Root & "Package", True)
        End If

        'Create DLL
        f.Message = GetString("proEd_CompilingActionsStatus")
        Dim c As New Compiler
        If c.CompileDLL() = False Then GoTo EndSub
        c = Nothing
        f.Progress = 10

        'Create the new directory
        If IO.Directory.Exists(Game.Root & "Package") Then
            While IO.Directory.GetFiles(Game.Root & "Package").Length > 0
                IO.File.Delete(IO.Directory.GetFiles(Game.Root & "Package")(0))
            End While
            IO.Directory.Delete(Game.Root & "Package")
        End If
        IO.Directory.CreateDirectory(Game.Root & "Package")

        'Variables
        f.Message = GetString("proEd_RetrievingFileInfoStatus")
        ReDim filerepl(0)
        Dim Files() As String
        ReDim Files(0)

        'Search for filenames
        AddFileToList(Game.GameProperties.Icon, Files)
        GetActionFilenames(Files)
        'GetControlFilenames(Files)
        For i As Integer = 1 To UBound(Game.tileset.tiles)
            AddFileToList(Game.tileset.tiles(i).filename, Files)
        Next
        For i As Integer = 1 To UBound(Game.maps)
            If Game.maps(i).Background.Type = psUI.psBackground.BackgroundType.Picture Then AddFileToList(Game.maps(i).Background.imgFilename, Files)
            AddFileToList(Game.maps(i).Music, Files)
        Next
        For i As Integer = 1 To UBound(Game.windows.Windows)
            If Game.windows.Windows(i).Background.Type = psUI.psBackground.BackgroundType.Picture Then AddFileToList(Game.windows.Windows(i).Background.imgFilename, Files)
            AddFileToList(Game.windows.Windows(i).Music, Files)
            For j As Integer = 1 To Game.windows.Windows(i).NumCtrls
                With Game.windows.Windows(i).Controls(j)
                    If .GetBackground.Type = psUI.psBackground.BackgroundType.Picture Then AddFileToList(.GetBackground.imgFilename, Files)
                    If .Type = psUI.psControl.psCtrlType.Button Then
                        Dim tmpBtn As psUI.psControl.psButton = Game.windows.Windows(i).Controls(j)
                        If tmpBtn.GetOver.Type = psUI.psBackground.BackgroundType.Picture Then AddFileToList(tmpBtn.GetOver.imgFilename, Files)
                        If tmpBtn.GetDown.Type = psUI.psBackground.BackgroundType.Picture Then AddFileToList(tmpBtn.GetDown.imgFilename, Files)
                    End If
                End With
            Next
        Next

        OtherFilesStart = UBound(Files) + 1
        AddFileToList(Game.GameProperties.fLicenseAgrmt, Files, True)
        AddFileToList(Game.GameProperties.fReadme, Files, True)
        AddFileToList(Game.GameProperties.fReleaseNotes, Files, True)
        For i As Integer = 1 To UBound(Game.GameProperties.fOtherFiles)
            AddFileToList(Game.GameProperties.fOtherFiles(i), Files, True)
        Next
        f.Progress = 15

        'Copy the files into the directory
        f.Message = GetString("proEd_CopyingFilesStatus")
        For i As Integer = 1 To UBound(Files)
            AddFileToPackage(Files(i))
            f.Progress = 15 + (i / UBound(Files)) * 15
        Next
        IO.File.Move(Game.Root & "~_tmp3.dll", Game.Root & "Package\actions.dll")

        'Inserts the game executable and dependencies
        AddToPackage(Application.StartupPath & "\AxInterop.ComCtl3.dll", Game.Root & "Package\" & "\AxInterop.ComCtl3.dll")
        AddToPackage(Application.StartupPath & "\Interop.ComCtl3.dll", Game.Root & "Package\" & "\Interop.ComCtl3.dll")
        AddToPackage(Application.StartupPath & "\Interop.VBA.dll", Game.Root & "Package\" & "\Interop.VBA.dll")
        AddToPackage(Application.StartupPath & "\Interop.VBRUN.dll", Game.Root & "Package\" & "\Interop.VBRUN.dll")
        AddToPackage(Application.StartupPath & "\SharpZipLib.dll", Game.Root & "Package\" & "\SharpZipLib.dll")
        AddToPackage(Application.StartupPath & "\psEngine.dll", Game.Root & "Package\" & "\psEngine.dll")
        AddToPackage(Application.StartupPath & "\psasmload.dll", Game.Root & "Package\" & "\psasmload.dll")
        AddToPackage(Application.StartupPath & "\psGame.exe.manifest", Game.Root & "Package\" & "\psGame.exe.manifest")
        AddToPackage(Application.StartupPath & "\psGame.exe", Game.Root & "Package\" & "\psGame.exe")
        AddToPackage(Application.StartupPath & "\Microsoft.DirectX.AudioVideoPlayback.dll", Game.Root & "Package\" & "\Microsoft.DirectX.AudioVideoPlayback.dll")
        AddToPackage(Application.StartupPath & "\Microsoft.DirectX.Direct3D.dll", Game.Root & "Package\" & "\Microsoft.DirectX.Direct3D.dll")
        AddToPackage(Application.StartupPath & "\Microsoft.DirectX.Direct3DX.dll", Game.Root & "Package\" & "\Microsoft.DirectX.Direct3DX.dll")
        AddToPackage(Application.StartupPath & "\Microsoft.DirectX.DirectSound.dll", Game.Root & "Package\" & "\Microsoft.DirectX.DirectSound.dll")
        AddToPackage(Application.StartupPath & "\Microsoft.DirectX.dll", Game.Root & "Package\" & "\Microsoft.DirectX.dll")

        f.Progress = 30

        'Save game
        f.Message = GetString("proEd_SavingGameStatus")
        Dim fh As New psFileHandler
        fh.SaveGame(Game.Root & "Package\game.psg", False, AddressOf fh.fs2)
        f.Progress = 40

        'Compress the directory
        f.Message = GetString("proEd_PackingFilesStatus")
        Dim stream As IO.Stream = IO.File.OpenWrite(Game.TempRoot & "~pstudio35tmp.tmp")

        'Insert game files
        Dim PackageFiles() As String = IO.Directory.GetFiles(Game.Root & "Package")

        'Write how many files to save
        WriteLong(PackageFiles.Length, stream)

        'For each file,
        For i As Integer = 0 To UBound(PackageFiles)
            Dim tmpStream As IO.Stream = IO.File.OpenRead(PackageFiles(i))

            'write its size,
            WriteLong(tmpStream.Length, stream)

            'write its filename,
            Dim tmpFilename As String = GetFilename(PackageFiles(i))
            WriteLong(tmpFilename.Length, stream)
            For j As Integer = 0 To tmpFilename.Length - 1
                stream.WriteByte(Asc(tmpFilename.Chars(j)))
            Next

            'and then its stream.
            Dim bytes() As Byte
            ReDim bytes(tmpStream.Length - 1)
            tmpStream.Read(bytes, 0, tmpStream.Length)
            stream.Write(bytes, 0, tmpStream.Length)
            Erase bytes

            tmpStream.Close()
            tmpStream = Nothing

            f.Progress = 40 + (i / UBound(PackageFiles)) * 35
        Next

        'Close the stream
        stream.Close()
        f.Progress = 75

        'Delete the directory
        While IO.Directory.GetFiles(Game.Root & "Package").Length > 0
            IO.File.Delete(IO.Directory.GetFiles(Game.Root & "Package")(0))
        End While
        IO.Directory.Delete(Game.Root & "Package")

        'Create output folder
        '_OutputFolder = Application.StartupPath & "\Compiled Games\Output " & Today.Date.Month & "-" & Today.Date.Day & "-" & Today.Date.Year & " " & Date.Now.Hour & "." & Date.Now.Minute & "." & Date.Now.Second
        _OutputFolder &= "\Output " & Today.Date.Month & "-" & Today.Date.Day & "-" & Today.Date.Year & " " & Date.Now.Hour & "." & Date.Now.Minute & "." & Date.Now.Second
        IO.Directory.CreateDirectory(OutputFolder)

        'Compress the package
        f.Message = GetString("proEd_CompressingStatus")
        psCompress.GCompress(Game.TempRoot & "~pstudio35tmp.tmp", _OutputFolder & "\data.dat")
        IO.File.Delete(Game.TempRoot & "~pstudio35tmp.tmp")
        f.Progress = 90
        f.Message = GetString("proEd_BuildingOutputStatus")

        'Create a data file for high scores
        Dim HighScores() As HighScore
        ReDim HighScores(0)
        FileOpen(1, OutputFolder & "\data2.dat", OpenMode.Binary, OpenAccess.Write)
        FilePut(1, 3235938437815663125) 'add some random number
        FilePut(1, HighScores)
        FileClose(1)

        'Compile EXE
        f.Progress = 100
        f.Message = GetString("proEd_CompilingEXEStatus")

        Dim args() As String = GetCommandLineArgs()
        Dim DatFileSize As Long = FileLen(OutputFolder & "\data.dat")
        Dim Code As String
        Code = "Imports System" & vbCrLf & _
               "Imports Microsoft.VisualBasic" & vbCrLf & _
               "Imports System.Windows.Forms" & vbCrLf & _
                                        vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyTitle(""" & args(1) & """)>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyDescription(""Powered by JumpCraft Game Engine, Copyright " & Today.Year & ", First Productions, Inc."")>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyCompany(""" & args(3) & """)>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyProduct(""" & args(1) & """)>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyCopyright(""Copyright " & Today.Year & ", " & args(3) & """)>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyTrademark("""")>" & vbCrLf & _
               "    <Assembly: CLSCompliant(True)>" & vbCrLf & _
               "    <Assembly: System.Reflection.AssemblyVersion(""" & args(2) & """)>" & vbCrLf & _
               "Namespace Starter" & vbCrLf & _
                                        vbCrLf & _
               "    Module Main" & vbCrLf & _
               "        Sub Main(ByVal args() As String)" & vbCrLf & _
               "If FileLen(Application.StartupPath & ""\data.dat"") <> " & DatFileSize & " Then Exit Sub" & vbCrLf & _
               "Try" & vbCrLf & _
               "If Not (args Is Nothing) AndAlso args.Length = 1 Then" & vbCrLf & _
        "If IO.Directory.Exists(args(0)) Then" & vbCrLf & _
            "While IO.Directory.GetFiles(args(0)).Length > 0" & vbCrLf & _
                "Try" & vbCrLf & _
                    "IO.File.Delete(IO.Directory.GetFiles(args(0))(0))" & vbCrLf & _
                "Catch" & vbCrLf & _
                "End Try" & vbCrLf & _
            "End While" & vbCrLf & _
            "IO.Directory.Delete(args(0))" & vbCrLf & _
        "End If" & vbCrLf & _
               "Exit Sub" & vbCrLf & _
               "End If" & vbCrLf & _
               "            GDecompress(Application.StartupPath & ""\data.dat"", System.IO.Path.GetTempPath & ""data.tmp"")" & vbCrLf & _
        "Dim dir As String = System.IO.Path.GetTempPath & ""pstudio""" & vbCrLf & _
        "Dim datfile As String = Application.StartupPath & ""\data.dat""" & vbCrLf & _
        "Dim tmpfile As String = dir & ""\data.tmp""" & vbCrLf & _
        "If IO.Directory.Exists(Dir) Then" & vbCrLf & _
            "While IO.Directory.GetFiles(Dir).Length > 0" & vbCrLf & _
                "IO.File.Delete(IO.Directory.GetFiles(Dir)(0))" & vbCrLf & _
            "End While" & vbCrLf & _
        "Else" & vbCrLf & _
            "IO.Directory.CreateDirectory(Dir)" & vbCrLf & _
        "End If" & vbCrLf & _
        "GDecompress(datfile, tmpfile)" & vbCrLf & _
        "Dim stream As IO.Stream = IO.File.OpenRead(tmpfile)" & vbCrLf & _
        "Dim bytes() As Byte" & vbCrLf & _
        "ReDim bytes(8)" & vbCrLf & _
        "stream.Read(bytes, 0, 8)" & vbCrLf & _
        "Dim numFiles As Long = ReadLong(bytes)" & vbCrLf & _
        "For i As Integer = 1 To numFiles" & vbCrLf & _
            "Dim FileSize As Long" & vbCrLf & _
            "ReDim bytes(8)" & vbCrLf & _
            "stream.Read(bytes, 0, 8)" & vbCrLf & _
            "FileSize = ReadLong(bytes)" & vbCrLf & _
            "ReDim bytes(FileSize)" & vbCrLf & _
            "Dim FileNameLength As Long" & vbCrLf & _
            "ReDim bytes(8)" & vbCrLf & _
            "stream.Read(bytes, 0, 8)" & vbCrLf & _
            "FileNameLength = ReadLong(bytes)" & vbCrLf & _
            "Dim Filename As String = """"" & vbCrLf & _
            "For j As Integer = 1 To FileNameLength" & vbCrLf & _
                "Filename &= Chr(stream.ReadByte())" & vbCrLf & _
            "Next" & vbCrLf & _
            "Dim tmpStream As IO.Stream = IO.File.OpenWrite(dir & ""\"" & Filename)" & vbCrLf & _
            "ReDim bytes(FileSize)" & vbCrLf & _
            "stream.Read(bytes, 0, FileSize)" & vbCrLf & _
            "tmpStream.Write(bytes, 0, FileSize)" & vbCrLf & _
            "tmpStream.Close()" & vbCrLf & _
            "tmpStream = Nothing" & vbCrLf & _
        "Next" & vbCrLf & _
        "stream.Close()" & vbCrLf & _
        "stream = Nothing" & vbCrLf & _
        "Dim Icon As String = """ & Game.GameProperties.Icon & """" & vbCrLf & _
        "Diagnostics.Process.Start(dir & ""\psgame.exe"", """""""" & Application.ExecutablePath & """""" """""" & Application.StartupPath & """""" """""" & Icon & """""""")" & vbCrLf & _
        "Catch ex as exception" & vbCrLf & _
        "msgbox(ex.message)" & vbCrLf & _
        "End Try" & vbCrLf & _
               "        End Sub" & vbCrLf & _
                                   vbCrLf & _
               "        Sub GDecompress(ByVal Filename As String, ByVal NewFile As String)" & vbCrLf & _
               "            Dim strDestinationFile As String" & vbCrLf & _
               "            Dim nSize As Integer = 2048" & vbCrLf & _
               "            Dim nSizeRead As Integer" & vbCrLf & _
               "            Dim abyWriteData(2048) As Byte" & vbCrLf & _
                                                             vbCrLf & _
               "            strDestinationFile = NewFile" & vbCrLf & _
                                                        vbCrLf & _
               "            Dim stmGzipArchive As IO.Stream = New ICSharpCode.SharpZipLib.GZip.GZipInputStream(IO.File.OpenRead(Filename))" & vbCrLf & _
               "            Dim stmDestinationFile As IO.FileStream = IO.File.Create(strDestinationFile)" & vbCrLf & _
                                                        vbCrLf & _
               "            While (True)" & vbCrLf & _
               "                nSizeRead = stmGzipArchive.Read(abyWriteData, 0, nSize)" & vbCrLf & _
               "                If nSizeRead > 0 Then" & vbCrLf & _
               "                    stmDestinationFile.Write(abyWriteData, 0, nSizeRead)" & vbCrLf & _
               "                Else" & vbCrLf & _
               "                    Exit While" & vbCrLf & _
               "                End If" & vbCrLf & _
               "            End While" & vbCrLf & _
                                        vbCrLf & _
               "            stmDestinationFile.Flush()" & vbCrLf & _
               "            stmDestinationFile.Close()" & vbCrLf & _
               "            stmGzipArchive.Close()" & vbCrLf & _
               "        End Sub" & vbCrLf & _
                                        vbCrLf & _
               "    Function ReadLong(ByVal bytes() As Byte) As Long" & vbCrLf & _
               "        Return bytes(7) * &H100000000000000 + _" & vbCrLf & _
               "               bytes(6) * &H1000000000000 + _" & vbCrLf & _
               "               bytes(5) * &H10000000000 + _" & vbCrLf & _
               "               bytes(4) * &H100000000 + _" & vbCrLf & _
               "               bytes(3) * &H1000000 + _" & vbCrLf & _
               "               bytes(2) * &H10000 + _" & vbCrLf & _
               "               bytes(1) * &H100 + _" & vbCrLf & _
               "               bytes(0)" & vbCrLf & _
               "        End Function" & vbCrLf & _
               "    End Module" & vbCrLf & _
               "End Namespace"

        'Create EXE
        Dim Err() As System.CodeDom.Compiler.CompilerError
        CompileEXE(OutputFolder & "\Game.exe", "Starter.Main", Code, Err)

        Dim strErr As String = Nothing
        For i As Integer = 1 To UBound(Err)
            strErr &= (Err(i).Line & ": " & Err(i).ErrorText) & vbCrLf
        Next
        If strErr <> "" Then
            MsgBox(strErr)
            Exit Function
        End If

        'Get other files
        Dim tmpFiles As New SortedList
        AddFileToSortedList(tmpFiles, Game.GameProperties.fLicenseAgrmt)
        AddFileToSortedList(tmpFiles, Game.GameProperties.fReadme)
        AddFileToSortedList(tmpFiles, Game.GameProperties.fReleaseNotes)
        For i As Integer = 1 To UBound(Game.GameProperties.fOtherFiles)
            AddFileToSortedList(tmpFiles, Game.GameProperties.fOtherFiles(i))
        Next

        'and copy them
        For i As Integer = 0 To tmpFiles.Count - 1
            IO.File.Copy(tmpFiles.GetByIndex(i), OutputFolder & "\" & tmpFiles.GetKey(i))
        Next

        'Allow decompression
        IO.File.Copy(Application.StartupPath & "\SharpZipLib.dll", OutputFolder & "\SharpZipLib.dll")

        'BuildGame()
        'DeletePackageFile()

EndSub:
        fGame.TopMost = True
        f.Close()
        f.Dispose()
        fGame.Enabled = True
        fGame.Select()
        fGame.TopMost = False

        'Successful!
        Return True
    End Function

    Sub AddFileToSortedList(ByVal list As SortedList, ByVal File As String)
        If IO.File.Exists(File) Then
            Dim Pathname As String = File
            Dim Filename As String = IO.Path.GetFileName(Pathname)

            'Make sure File is not a duplicate
            For Each entry As DictionaryEntry In list
                If entry.Value = Pathname Then Exit Sub
            Next

            'If File has the same filename as another file,
            'but is in a different folder, change the new filename
            Dim FileWOExtension As String = IO.Path.GetFileNameWithoutExtension(Pathname)
            Dim Midfix As String
            Dim Extension As String = IO.Path.GetExtension(Pathname)
            Dim Repeat As Boolean = True
            While Repeat
                Repeat = False

                'Enumerate through all the keys
                For Each entry As DictionaryEntry In list
                    If entry.Key = FileWOExtension + Midfix + Extension Then

                        'test.txt -> test1.txt -> test2.txt -> ...
                        If Midfix = "" Then
                            Midfix = 1
                        Else
                            Midfix += 1
                        End If

                        'Check for the new filename
                        Repeat = True
                        Exit For

                    End If
                Next
            End While

            'Add item to list
            list.Add(FileWOExtension + Midfix + Extension, Pathname)

        End If
    End Sub

    Sub AddToPackage(ByVal File1 As String, ByVal File2 As String)
        IO.File.Copy(File1, File2)
    End Sub

    Function GetCommandLineArgs() As String()
        'Get the command line arguments
        Dim args() As String
        ReDim args(3 + (UBound(filerepl) - OtherFilesStart + 1))
        args(0) = Game.Root & "Package.bin"
        args(1) = Game.GameProperties.Name
        args(2) = Game.GameProperties.Version
        args(3) = Game.GameProperties.Company
        For i As Integer = OtherFilesStart To UBound(filerepl)
            args(4 + (i - OtherFilesStart)) = filerepl(i).NewFile
        Next
        Return args
    End Function

    Sub DeletePackageFile()
        'Delete package file
        IO.File.Delete(Game.Root & "Package.bin")
    End Sub

    Private Sub AddFileToList(ByVal File As String, ByRef Files() As String, Optional ByVal UseOtherFilesStart As Boolean = False)
        If File = "" Then Exit Sub
        If File.Chars(0) = "(" Then Exit Sub
        For z As Integer = IIf(UseOtherFilesStart, OtherFilesStart, 1) To UBound(Files)
            If Files(z) = File Then Exit Sub
        Next
        ReDim Preserve Files(UBound(Files) + 1)
        Files(UBound(Files)) = File
    End Sub

    Private Sub GetActionFilenames(ByRef tmpArr() As String)
        'Loop through all actions
        For i As Integer = 1 To UBound(Game.actions.Actions)
            With Game.actions.Actions(i).Action
                'Loop through all parameters
                For j As Integer = 1 To UBound(.param)
                    GetFilenamesFromText(.param(j), tmpArr)
                Next
            End With
        Next
    End Sub

    Sub GetFilenamesFromText(ByRef txt As String, ByRef tmpArr() As String)
        'Find all filenames and replace it with
        'one that is relative to the new location
        'of the game file

        'Variables
        Dim tmpStart As Integer
        Dim tmpFile As String

        'Loop until we have reached the end of the string
        Do
LookForAnotherFile:

            'Find ":\", which refers to a drive
            If txt Is Nothing Then Exit Sub
            tmpStart = txt.IndexOf(":\", tmpStart + 1)

            'If no more were found, then exit the loop
            If tmpStart = -1 Then Exit Do

            'Make sure this is really a file
            Try
                If Not (Char.IsLetter(txt.Chars(tmpStart - 1))) Then
                    GoTo LookForAnotherFile
                End If
            Catch ex As Exception
                GoTo LookForAnotherFile
            End Try

            'Find the filename around the ":\"
            tmpStart -= 1 'Start at the drive letter
            For k As Integer = tmpStart + 1 To txt.Length - 1
                If txt.Chars(k) = """" Then
                    tmpFile = txt.Substring(tmpStart, k - tmpStart)
                    AddFileToList(tmpFile, tmpArr)
                    GoTo ContinueLoop
                End If
            Next
            tmpFile = txt.Substring(tmpStart)
            AddFileToList(tmpFile, tmpArr)

ContinueLoop:

            tmpStart += 2

        Loop Until tmpStart = -1
    End Sub

    Private Sub AddFileToPackage(ByVal tmpFile As String)
        'Make sure this file hasn't come up yet
        For z As Integer = 1 To UBound(filerepl)
            If filerepl(z).OldFile = tmpFile Then Exit Sub
        Next

        'Stores the old filename
        ReDim Preserve filerepl(UBound(filerepl) + 1)
        filerepl(UBound(filerepl)).OldFile = tmpFile

        'Determine the new filename
        Dim tmpFileName As String = GetFilename(tmpFile)
        Dim tmpFileRoot As String = "", tmpFileExtension As String = ""
        For z As Integer = tmpFileName.Length - 1 To 0 Step -1
            If tmpFileName.Chars(z) = "." Then
                tmpFileRoot = tmpFileName.Substring(0, z)
                tmpFileExtension = tmpFileName.Substring(z + 1)
                Exit For
            End If
        Next
        If tmpFileRoot = "" And tmpFileExtension = "" Then tmpFileRoot = tmpFileName
        Dim Suffix As String = ""
        While IO.File.Exists(Game.Root & "Package\" & tmpFileRoot & Suffix & "." & tmpFileExtension)
            If Suffix = "" Then
                Suffix = 1
            Else
                Suffix += 1
            End If
        End While
        Dim NewFile As String = Game.Root & "Package\" & tmpFileRoot & Suffix & "." & tmpFileExtension

        'Copy the new file
        IO.File.Copy(tmpFile, NewFile)

        'Store the new file
        filerepl(UBound(filerepl)).NewFile = GetFilename(NewFile)
    End Sub

    Function CompileEXE(ByVal Filename As String, ByVal ClassName As String, ByVal Code As String, ByRef Err() As System.CodeDom.Compiler.CompilerError) As Boolean
        Dim VBP As New VBCodeProvider
        Dim CVB As System.CodeDom.Compiler.ICodeCompiler
        CVB = VBP.CreateCompiler
        Dim PM As New System.CodeDom.Compiler.CompilerParameters

        'Add icon
        'Dim rwrite As New System.Resources.ResourceWriter(Application.StartupPath & "\res.resources")
        'rwrite.AddResource("Icon1", New Icon("C:\Documents and Settings\Owner\My Documents\Visual Studio Projects\JumpCraft\x.ico"))
        'rwrite.Close()
        PM.OutputAssembly = Filename
        PM.CompilerOptions = "/target:winexe"
        If IO.File.Exists(Game.GameProperties.Icon) Then
            PM.CompilerOptions += " /win32icon:""" & Game.GameProperties.Icon & """"
        End If
        PM.GenerateExecutable = True
        PM.MainClass = ClassName
        PM.IncludeDebugInformation = False

        'I believe this is to get all the assemblies of the current 
        'application and add them as references to the new assembly
        Dim ASM As System.Reflection.Assembly
        For Each ASM In AppDomain.CurrentDomain.GetAssemblies()
            If Not (IO.Path.GetFileName(ASM.Location).ToLower = "pscompiler.exe" Or _
                    IO.Path.GetFileName(ASM.Location).ToLower = "psctlx.dll" Or _
                    IO.Path.GetFileName(ASM.Location).ToLower = "dockingsuite.dll" Or _
                    IO.Path.GetExtension(ASM.Location).ToLower = ".exe" Or _
                    IO.Path.GetFileName(ASM.Location).ToLower.IndexOf("direct") >= 0 Or _
                    IO.Path.GetFileName(ASM.Location).ToLower.IndexOf("sharp") >= 0 Or _
                    IO.Path.GetFileName(ASM.Location).ToLower = "psengine.dll") Then
                PM.ReferencedAssemblies.Add(ASM.Location)
            End If
        Next
        PM.ReferencedAssemblies.Add(Application.StartupPath & "\SharpZipLib.dll")

        'here we do the deed
        Dim Results As System.CodeDom.Compiler.CompilerResults
        Results = CVB.CompileAssemblyFromSource(PM, Code)

        'this is just to list out all the errors if any
        ReDim Err(0)
        Dim e As System.CodeDom.Compiler.CompilerError
        For Each e In Results.Errors
            ReDim Preserve Err(UBound(Err) + 1)
            Err(UBound(Err)) = e
        Next

        If UBound(Err) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ReadLong(ByVal bytes() As Byte) As Long
        Return bytes(7) * &H100000000000000 + _
               bytes(6) * &H1000000000000 + _
               bytes(5) * &H10000000000 + _
               bytes(4) * &H100000000 + _
               bytes(3) * &H1000000 + _
               bytes(2) * &H10000 + _
               bytes(1) * &H100 + _
               bytes(0)
    End Function

    Sub WriteLong(ByVal l As Long, ByVal stream As IO.Stream)
        Dim bytes() As Byte
        ReDim bytes(7)
        bytes(0) = l And &HFF
        bytes(1) = (l \ &H100) And &HFF
        bytes(2) = (l \ &H10000) And &HFF
        bytes(3) = (l \ &H1000000) And &HFF
        bytes(4) = (l \ &H100000000) And &HFF
        bytes(5) = (l \ &H10000000000) And &HFF
        bytes(6) = (l \ &H1000000000000) And &HFF
        bytes(7) = (l \ &H100000000000000) And &HFF
        stream.Write(bytes, 0, 8)
    End Sub
End Module