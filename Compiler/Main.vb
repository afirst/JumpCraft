Imports PlatformStudio

Structure HighScore
    Dim Name As String
    Dim Level As String
    Dim Score As Long
End Structure

Public Module Main
    Sub Main(ByVal args() As String)
        '--------------------------------------------------
        'Arguments are:
        'Filename, Game Name, Version, Company, Other Files
        '--------------------------------------------------
        'ReDim args(3)
        'args(0) = "C:\Documents and Settings\Owner\My Documents\Visual Studio Projects\Platform Studio\bin\Package.bin"
        'args(1) = "Test Game"
        'args(2) = "1.0"
        'args(3) = "My Company, Inc."
        'args(4+) = File to put outside of package
        If args.GetUpperBound(0) < 3 Then Exit Sub

        Dim f As New frmWait
        f.Show()

        Try
            Dim OutputFolder As String
            OutputFolder = Application.StartupPath & "\output" & Today.Now.Hour & Today.Now.Minute & Today.Now.Second
            IO.Directory.CreateDirectory(OutputFolder)

            f.Message = "Decompressing archive"

            'Extracts the files
            Dim dir As String = OutputFolder & "\temp"
            Dim datfile As String = OutputFolder & "\data.dat"
            Dim tmpfile As String = OutputFolder & "\data.tmp"
            IO.File.Copy(args(0), datfile)
            If IO.Directory.Exists(dir) Then
                While IO.Directory.GetFiles(dir).Length > 0
                    IO.File.Delete(IO.Directory.GetFiles(dir)(0))
                End While
            Else
                IO.Directory.CreateDirectory(dir)
            End If
            GDecompress(datfile, tmpfile)

            f.Progress = 20
            f.Message = "Unpacking archive"

            Dim stream As IO.Stream = IO.File.OpenRead(tmpfile)
            Dim bytes() As Byte
            ReDim bytes(8)
            stream.Read(bytes, 0, 8)
            Dim numFiles As Long = ReadLong(bytes)
            For i As Integer = 1 To numFiles
                Dim FileSize As Long
                ReDim bytes(8)
                stream.Read(bytes, 0, 8)
                FileSize = ReadLong(bytes)
                ReDim bytes(FileSize)
                Dim FileNameLength As Long
                ReDim bytes(8)
                stream.Read(bytes, 0, 8)
                FileNameLength = ReadLong(bytes)
                Dim Filename As String = ""
                For j As Integer = 1 To FileNameLength
                    Filename &= Chr(stream.ReadByte())
                Next
                Dim tmpStream As IO.Stream = IO.File.OpenWrite(dir & "\" & Filename)
                ReDim bytes(FileSize)
                stream.Read(bytes, 0, FileSize)
                tmpStream.Write(bytes, 0, FileSize)
                tmpStream.Close()
                tmpStream = Nothing
            Next
            stream.Close()
            stream = Nothing

            f.Progress = 40
            f.Message = "Copying files"

            'Inserts the game executable and dependencies
            IO.File.Copy(Application.StartupPath & "\AxInterop.ComCtl3.dll", dir & "\AxInterop.ComCtl3.dll")
            IO.File.Copy(Application.StartupPath & "\Interop.ComCtl3.dll", dir & "\Interop.ComCtl3.dll")
            IO.File.Copy(Application.StartupPath & "\Interop.VBA.dll", dir & "\Interop.VBA.dll")
            IO.File.Copy(Application.StartupPath & "\Interop.VBRUN.dll", dir & "\Interop.VBRUN.dll")
            IO.File.Copy(Application.StartupPath & "\SharpZipLib.dll", dir & "\SharpZipLib.dll")
            IO.File.Copy(Application.StartupPath & "\psEngine.dll", dir & "\psEngine.dll")
            IO.File.Copy(Application.StartupPath & "\psGame.exe.manifest", dir & "\psGame.exe.manifest")
            IO.File.Copy(Application.StartupPath & "\psGame.exe", dir & "\psGame.exe")
            IO.File.Copy(Application.StartupPath & "\Microsoft.DirectX.AudioVideoPlayback.dll", dir & "\Microsoft.DirectX.AudioVideoPlayback.dll")
            IO.File.Copy(Application.StartupPath & "\Microsoft.DirectX.Direct3D.dll", dir & "\Microsoft.DirectX.Direct3D.dll")
            IO.File.Copy(Application.StartupPath & "\Microsoft.DirectX.Direct3DX.dll", dir & "\Microsoft.DirectX.Direct3DX.dll")
            IO.File.Copy(Application.StartupPath & "\Microsoft.DirectX.DirectSound.dll", dir & "\Microsoft.DirectX.DirectSound.dll")
            IO.File.Copy(Application.StartupPath & "\Microsoft.DirectX.dll", dir & "\Microsoft.DirectX.dll")
            IO.File.Copy(Application.StartupPath & "\SharpZipLib.dll", OutputFolder & "\SharpZipLib.dll")
            For i As Integer = 4 To UBound(args)
                IO.File.Move(dir & "\" & args(i), OutputFolder & "\" & args(i))
            Next

            'Create a data file for high scores
            Dim HighScores() As HighScore
            ReDim HighScores(0)
            FileOpen(1, OutputFolder & "\data2.dat", OpenMode.Binary, OpenAccess.Write)
            FilePut(1, 3235938437815663125) 'add some random number
            FilePut(1, HighScores)
            FileClose(1)

            f.Progress = 60
            f.Message = "Packing archive"

            'Compresses again
            Dim tmpFiles() As String = IO.Directory.GetFiles(dir)
            stream = IO.File.OpenWrite(tmpfile)
            WriteLong(UBound(tmpFiles) + 1, stream)
            For i As Integer = 0 To UBound(tmpFiles)
                Dim Filename As String = GetFilename(tmpFiles(i))
                Dim tmpStream As IO.Stream = IO.File.OpenRead(dir & "\" & filename)
                WriteLong(tmpStream.Length, stream)
                WriteLong(Filename.Length, stream)
                For j As Integer = 0 To filename.Length - 1
                    stream.WriteByte(Asc(filename.Chars(j)))
                Next
                ReDim bytes(tmpStream.Length)
                tmpStream.Read(bytes, 0, tmpstream.Length)
                stream.Write(bytes, 0, tmpstream.Length)
                tmpStream.Close()
                tmpStream = Nothing
            Next
            stream.Close()
            stream = Nothing

            'Compress archive
            f.Progress = 80
            f.Message = "Compressing archive"

            GCompress(tmpfile, datfile)
            IO.File.Delete(tmpfile)

            'Delete temp directory
            IO.Directory.Delete(dir, True)

            'Compile EXE
            f.Progress = 100
            f.Message = "Compiling EXE"

            Dim DatFileSize As Long = FileLen(OutputFolder & "\data.dat")
            Dim Code As String
            Code = "Imports System" & vbCrLf & _
                   "Imports Microsoft.VisualBasic" & vbCrLf & _
                   "Imports System.Windows.Forms" & vbCrLf & _
                                            vbCrLf & _
                   "    <Assembly: System.Reflection.AssemblyTitle(""" & args(1) & """)>" & vbCrLf & _
                   "    <Assembly: System.Reflection.AssemblyDescription(""Powered by Platform Studio Game Engine, Copyright " & Today.Year & ", First Productions, Inc."")>" & vbCrLf & _
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
            "Diagnostics.Process.Start(dir & ""\psgame.exe"", """""""" & Application.ExecutablePath & """""" """""" & Application.StartupPath & """""""")" & vbCrLf & _
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

            Dim strErr As String
            For i As Integer = 1 To UBound(Err)
                strErr &= (Err(i).Line & ": " & Err(i).ErrorText) & vbCrLf
            Next
            If strErr <> "" Then
                MsgBox(strErr)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Diagnostics.Process.Start(dir & "\psgame.exe")
    End Sub

    Function CompileEXE(ByVal Filename As String, ByVal ClassName As String, ByVal Code As String, ByRef Err() As System.CodeDom.Compiler.CompilerError) As Boolean
        Dim VBP As New VBCodeProvider
        Dim CVB As System.CodeDom.Compiler.ICodeCompiler
        CVB = VBP.CreateCompiler
        Dim PM As New System.CodeDom.Compiler.CompilerParameters

        PM.OutputAssembly = Filename
        PM.CompilerOptions = "/target:winexe"
        PM.GenerateExecutable = True
        PM.MainClass = ClassName
        PM.IncludeDebugInformation = False

        'I believe this is to get all the assemblies of the current 
        'application and add them as references to the new assembly
        Dim ASM As System.Reflection.Assembly
        For Each ASM In AppDomain.CurrentDomain.GetAssemblies()
            If Not (IO.Path.GetFileName(ASM.Location).ToLower = "pscompiler.exe" Or _
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