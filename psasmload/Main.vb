Imports System
Imports System.Diagnostics
Imports System.Reflection

Public Class AssemblyLoader
    Inherits MarshalByRefObject
    Implements PlatformStudio.IAssemblyLoader

    Private RunObj As New Object
    Private a As [Assembly]
    Private _namespaceName, _className As String

    Sub LoadDLL(ByVal Filename As String, ByVal NamespaceName As String, ByVal ClassName As String) Implements PlatformStudio.IAssemblyLoader.LoadDLL
        a = [Assembly].LoadFrom(Filename)
        _namespaceName = NamespaceName
        _className = ClassName
        CreateNewInstance()
        'RunObj = AppDomain.CurrentDomain.CreateInstanceFromAndUnwrap(Filename, NamespaceName & "." & ClassName, False, Reflection.BindingFlags.CreateInstance, Nothing, vArgs, Nothing, Nothing, Nothing)
    End Sub

    Sub CreateNewInstance()
        RunObj = a.CreateInstance(_namespaceName & "." & _className, False, Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing, Nothing)
    End Sub

    Function CallMethod(ByVal MethodName As String, ByVal ParamArray Args() As Object) As Object Implements PlatformStudio.IAssemblyLoader.CallMethod
        If RunObj IsNot Nothing Then
            'now we call the sub in the object
            Return CallByName(RunObj, MethodName, CallType.Method, Args)
        End If
        Return Nothing
    End Function

    Sub CallSetProperty(ByVal Name As String, ByVal ParamArray Args() As Object) Implements PlatformStudio.IAssemblyLoader.CallSetProperty
        If RunObj IsNot Nothing Then
            'now we call the sub in the object
            CallByName(RunObj, Name, CallType.Set, Args)
        End If
    End Sub

    Function CallGetProperty(ByVal Name As String, ByVal ParamArray Args() As Object) As Object Implements PlatformStudio.IAssemblyLoader.CallGetProperty
        If RunObj IsNot Nothing Then
            'now we call the sub in the object
            Return CallByName(RunObj, Name, CallType.Get, Args)
        End If
        Return Nothing
    End Function

    Sub CallLetProperty(ByVal Name As String, ByVal ParamArray Args() As Object) Implements PlatformStudio.IAssemblyLoader.CallLetProperty
        If RunObj IsNot Nothing Then
            'now we call the sub in the object            
            CallByName(RunObj, Name, CallType.Let, Args)
        End If
    End Sub
End Class