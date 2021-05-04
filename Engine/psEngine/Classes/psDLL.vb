Imports System
Imports System.Reflection
Imports System.Reflection.Assembly

Public Class psDLL
    Function CompileDLL(ByVal ClassName As String, ByVal Code As String, ByRef Err() As System.CodeDom.Compiler.CompilerError) As Boolean
        Return CompileDLL("", ClassName, Code, Err)
    End Function

    Function CompileDLL(ByVal Filename As String, ByVal ClassName As String, ByVal Code As String, ByRef Err() As System.CodeDom.Compiler.CompilerError) As Boolean
        Dim VBP As New VBCodeProvider
        Dim CVB As System.CodeDom.Compiler.ICodeCompiler
        CVB = VBP.CreateCompiler
        Dim PM As New System.CodeDom.Compiler.CompilerParameters
        'set PM.GenerateExecutable = True to create exe instead of the following
        If Filename = "" Then
            PM.GenerateInMemory = True
        Else
            '  PM.GenerateExecutable = True
            'note it saves it in a temporary folder "user temp folder"
            'also note you could enhance this by pulling the namespace info 
            'and class name from the code instead of having seperate vars for them.
            PM.OutputAssembly = Filename
        End If
        PM.MainClass = ClassName
        PM.IncludeDebugInformation = False

        'I believe this is to get all the assemblies of the current 
        'application and add them as references to the new assembly
        Dim ASM As System.Reflection.Assembly
        For Each ASM In AppDomain.CurrentDomain.GetAssemblies()
            If Not (IO.Path.GetFileName(ASM.Location).ToLower = "pscompiler.exe" Or _
                    IO.Path.GetFileName(ASM.Location).ToLower = "psctlx.dll" Or _
                    IO.Path.GetFileName(ASM.Location).ToLower = "dockingsuite.dll" Or _
                    IO.Path.GetExtension(ASM.Location).ToLower = ".exe") Then
                PM.ReferencedAssemblies.Add(ASM.Location)
            End If
        Next

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

    Private RunObj As New Object
    Dim domain As AppDomain
    Dim loader As IAssemblyLoader

    Sub LoadDLL(ByVal Filename As String, ByVal NamespaceName As String, ByVal ClassName As String)
        domain = AppDomain.CreateDomain("ScriptingDomain")
        loader = domain.CreateInstanceFromAndUnwrap(Application.StartupPath & "\psasmload.dll", "psasmload.AssemblyLoader")    ', False, Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing, Nothing, Nothing)
        loader.LoadDLL(Filename, NamespaceName, ClassName)
    End Sub

    Function CallMethod(ByVal MethodName As String, ByVal ParamArray Args() As Object) As Object
        Return loader.CallMethod(MethodName, Args)
        If Not RunObj Is Nothing Then
            'now we call the sub in the object
            Return CallByName(RunObj, MethodName, CallType.Method, Args)
        End If
    End Function

    Sub CallSetProperty(ByVal Name As String, ByVal ParamArray Args() As Object)
        loader.CallSetProperty(Name, Args)
        Return
        If Not RunObj Is Nothing Then
            'now we call the sub in the object
            CallByName(RunObj, Name, CallType.Set, Args)
        End If
    End Sub

    Function CallGetProperty(ByVal Name As String, ByVal ParamArray Args() As Object) As Object
        Return loader.CallGetProperty(Name, Args)
        If Not RunObj Is Nothing Then
            'now we call the sub in the object
            Return CallByName(RunObj, Name, CallType.Get, Args)
        End If
    End Function

    Sub CallLetProperty(ByVal Name As String, ByVal ParamArray Args() As Object)
        loader.CallLetProperty(Name, Args)
        Return
        If Not RunObj Is Nothing Then
            'now we call the sub in the object
            CallByName(RunObj, Name, CallType.Let, Args)
        End If
    End Sub

    Sub UnloadDLL()
        RunObj = Nothing
        AppDomain.Unload(domain)
    End Sub
End Class

Public Interface IAssemblyLoader
    Sub LoadDLL(ByVal Filename As String, ByVal NamespaceName As String, ByVal ClassName As String)
    Function CallMethod(ByVal MethodName As String, ByVal ParamArray Args() As Object) As Object
    Sub CallSetProperty(ByVal Name As String, ByVal ParamArray Args() As Object)
    Function CallGetProperty(ByVal Name As String, ByVal ParamArray Args() As Object) As Object
    Sub CallLetProperty(ByVal Name As String, ByVal ParamArray Args() As Object)
End Interface