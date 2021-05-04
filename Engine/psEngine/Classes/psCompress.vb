Imports System
Imports System.IO
Imports ICSharpCode.SharpZipLib
Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip

Public Module psCompress
    Sub Decompress(ByVal Filename As String, ByVal NewFile As String)
        ' Decompression of single-file archive
        Dim fsBZ2Archive As FileStream, fsOutput As FileStream

        fsBZ2Archive = File.OpenRead(Filename)

        fsOutput = File.Create(NewFile)

        BZip2.BZip2.Decompress(fsBZ2Archive, fsOutput, False)

        fsBZ2Archive.Close()
        fsOutput.Flush()
        fsOutput.Close()
    End Sub

    Sub Compress(ByVal Filename As String, ByVal NewFile As String)
        'Compression of single-file archive
        Dim fsInputFile As FileStream, fsBZ2Archive As FileStream
        fsInputFile = File.OpenRead(Filename)
        fsBZ2Archive = File.Create(NewFile)

        BZip2.BZip2.Compress(fsInputFile, fsBZ2Archive, False, 9)
        fsBZ2Archive.Close()

        fsInputFile.Close()
        ' fsBZ2Archive.Flush() & fsBZ2Archive.Close() are automatically called by .Compress
    End Sub

    Sub GDecompress(ByVal Filename As String, ByVal NewFile As String)
        Dim strDestinationFile As String
        Dim nSize As Integer = 2048
        Dim nSizeRead As Integer
        Dim abyWriteData(2048) As Byte

        strDestinationFile = NewFile 'Path.GetDirectoryName(NewFile) & _
        'Path.GetFileNameWithoutExtension(NewFile)

        Dim stmGzipArchive As Stream = New GZip.GZipInputStream(File.OpenRead(Filename))
        Dim stmDestinationFile As FileStream = File.Create(strDestinationFile)

        While (True)
            nSizeRead = stmGzipArchive.Read(abyWriteData, 0, nSize)
            If nSizeRead > 0 Then
                stmDestinationFile.Write(abyWriteData, 0, nSizeRead)
            Else
                Exit While
            End If
        End While

        stmDestinationFile.Flush()
        stmDestinationFile.Close()

        stmGzipArchive.Close()
    End Sub

    Sub GCompress(ByVal Filename As String, ByVal NewFile As String)
        Dim stmGzipArchive As Stream = New GZip.GZipOutputStream(File.Create(NewFile))
        Dim stmInputFile As FileStream = File.OpenRead(Filename)

        Dim nFileStreamLength As Int32
        nFileStreamLength = stmInputFile.Length
        Dim abyWriteData(nFileStreamLength) As Byte

        stmInputFile.Read(abyWriteData, 0, nFileStreamLength)
        stmGzipArchive.Write(abyWriteData, 0, nFileStreamLength)

        stmGzipArchive.Flush()
        stmGzipArchive.Close()
        stmInputFile.Close()
    End Sub
End Module

'Module psLZWCompress
'    Private Const maxCodes = 4096
'    Private Const byteSize = 8
'    Private Const excess = 4
'    Private Const alpha = 256
'    Private Const mask1 = 255
'    Private Const mask2 = 15

'    Private Structure Element
'        Dim prefix As Integer
'        Dim suffix As Integer
'    End Structure

'    Private leftOver As Integer
'    Private bitsLeftOver As Boolean
'    Private table As New Hashtable()
'    Private compData As String
'    Private size As Integer
'    Private s(maxCodes) As Integer
'    Private h(maxCodes) As Element

'    Private Sub codeOutp(ByVal pcode As Integer)
'        Dim c As Integer, d As Integer

'        If bitsLeftOver = True Then
'            d = pcode And mask1
'            c = (leftOver * (2 ^ excess)) + (pcode \ (2 ^ byteSize))
'            compData = compData + Chr(c) + Chr(d)
'            bitsLeftOver = False
'        Else
'            leftOver = pcode And mask2
'            c = pcode \ (2 ^ excess)
'            compData = compData + Chr(c)
'            bitsLeftOver = True
'        End If
'    End Sub

'    Private Sub strOutp(ByVal code As Integer)
'        Dim i As Integer

'        size = -1
'        Do While (code >= alpha)
'            size = size + 1
'            s(size) = h(code).suffix
'            code = h(code).prefix
'        Loop
'        size = size + 1
'        s(size) = code
'        For i = size To 0 Step -1
'            compData = compData + Chr(s(i))
'        Next
'    End Sub

'    Private Function getCode(ByVal data As String, ByRef pos As Integer) As Integer
'        Dim c As Integer, d As Integer, code As Integer
'        If pos > data.Length Then
'            getCode = -1
'            Exit Function
'        End If
'        c = Asc(Mid(data, pos, 1))
'        pos = pos + 1
'        If bitsLeftOver = True Then
'            code = (leftOver * (2 ^ byteSize)) + c
'        Else
'            d = Asc(Mid(data, pos, 1))
'            pos = pos + 1
'            code = (c * (2 ^ excess)) + (d \ (2 ^ excess))
'            leftOver = d And mask2
'        End If
'        bitsLeftOver = Not bitsLeftOver
'        getCode = code
'    End Function

'    Public Function lzwCompress(ByVal data As String) As String
'        Dim i As Integer, codeUsed As Integer
'        Dim c As Integer, pcode As Integer
'        Dim k As Integer, e As Integer
'        Dim pos As Integer

'        bitsLeftOver = False
'        compData = ""
'        table.Clear()
'        For i = 0 To (alpha - 1)
'            table.Add(i, i)
'        Next

'        codeUsed = alpha
'        pos = 1

'        pcode = Asc(Mid(data, pos, 1))
'        pos = pos + 1
'        c = Asc(Mid(data, pos, 1))
'        pos = pos + 1
'        Do Until pos = data.Length + 2
'            k = (pcode * (2 ^ byteSize)) + c
'            If table.ContainsKey(k) = False Then
'                codeOutp(pcode)
'                If (codeUsed < maxCodes) Then
'                    table.Add(k, codeUsed)
'                    codeUsed = codeUsed + 1
'                End If
'                pcode = c
'            Else
'                pcode = table.Item(k)
'            End If
'            If pos < data.Length + 1 Then
'                c = Asc(Mid(data, pos, 1))
'            End If
'            pos = pos + 1
'        Loop
'        codeOutp(pcode)
'        If bitsLeftOver = True Then compData = compData + Chr(leftOver * (2 ^ excess))
'        lzwCompress = compData
'    End Function

'    Public Function lzwDecompress(ByVal data As String) As String
'        Dim codeUsed As Integer = alpha
'        Dim cCode As Integer, pCode As Integer
'        Dim pos As Integer

'        pos = 1
'        bitsLeftOver = False
'        pCode = getCode(data, pos)
'        If pCode >= 0 Then
'            s(0) = pCode
'            compData = Chr(s(0))
'            size = 0

'            Do
'                cCode = getCode(data, pos)
'                If cCode < 0 Then Exit Do
'                If cCode < codeUsed Then
'                    strOutp(cCode)
'                    If codeUsed < maxCodes Then
'                        h(codeUsed).prefix = pCode
'                        h(codeUsed).suffix = s(size)
'                        codeUsed = codeUsed + 1
'                    End If
'                Else
'                    h(codeUsed).prefix = pCode
'                    h(codeUsed).suffix = s(size)
'                    codeUsed = codeUsed + 1
'                    strOutp(cCode)
'                End If
'                pCode = cCode
'            Loop
'            lzwDecompress = compData
'        End If
'    End Function
'End Module
