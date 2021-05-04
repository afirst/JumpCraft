Imports System.ComponentModel

Public Class PropGridEx
    Public Shared Sub setColumnWidth(ByVal prop As PropertyGrid, ByVal ratio As Double)
        Dim controlsProp As System.Reflection.PropertyInfo = prop.GetType().GetProperty("Controls")
        Dim cc As System.Windows.Forms.Control.ControlCollection = DirectCast(controlsProp.GetValue(prop, Nothing), System.Windows.Forms.Control.ControlCollection)
        For Each c As Control In cc
            If c.GetType().Name = "PropertyGridView" Then
                Dim mst As System.Reflection.MethodInfo = c.GetType().GetMethod("MoveSplitterTo", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.DeclaredOnly)
                Dim widthProp As System.Reflection.PropertyInfo = c.GetType().GetProperty("Width")
                Dim width As Double = widthProp.GetValue(c, Nothing)
                mst.Invoke(c, New Object() {CInt(width * ratio)})
                Exit For
            End If
        Next
    End Sub
End Class

Public Class PropDispNameWrapper : Implements ICustomTypeDescriptor
    Dim _obj As Object
    Dim _propsCollection As PropertyDescriptorCollection

    Public Sub New(ByVal obj As Object)
        _obj = obj
        _propsCollection = New PropertyDescriptorCollection(Nothing)
        Dim pdc As PropertyDescriptorCollection = _
            TypeDescriptor.GetProperties(obj, True)
        Dim pd As PropertyDescriptor
        For Each pd In pdc
            _propsCollection.Add(New PropDescX(pd))
        Next
    End Sub

    Public ReadOnly Property Unwrap() As Object
        Get
            Return _obj
        End Get
    End Property

    '//--Implements:
    Function GetAttributes() As AttributeCollection Implements ICustomTypeDescriptor.GetAttributes
        Return New AttributeCollection(Nothing)
    End Function

    Function GetClassName() As String Implements ICustomTypeDescriptor.GetClassName
        Return Nothing
    End Function

    Function GetComponentName() As String Implements ICustomTypeDescriptor.GetComponentName
        Return Nothing
    End Function

    Function GetConverter() As TypeConverter Implements ICustomTypeDescriptor.GetConverter
        Return Nothing
    End Function

    Function GetDefaultEvent() As EventDescriptor Implements ICustomTypeDescriptor.GetDefaultEvent
        Return Nothing
    End Function

    Function GetDefaultProperty() As PropertyDescriptor Implements ICustomTypeDescriptor.GetDefaultProperty
        Return Nothing
    End Function

    Function GetEditor(ByVal editorBaseType As Type) As Object Implements ICustomTypeDescriptor.GetEditor
        Return Nothing
    End Function

    Function GetEvents() As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
        Return New EventDescriptorCollection(Nothing)
    End Function

    Function GetEvents(ByVal attributes() As Attribute) As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
        Return New EventDescriptorCollection(Nothing)
    End Function

    Function GetProperties() As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
        Return _propsCollection
    End Function

    Function GetProperties(ByVal attributes() As Attribute) As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
        Return _propsCollection
    End Function

    Function GetPropertyOwner(ByVal pd As PropertyDescriptor) As Object Implements ICustomTypeDescriptor.GetPropertyOwner
        Return Me
    End Function
End Class

Public Class PropDescX : Inherits PropertyDescriptor
    Dim _PropDesc As PropertyDescriptor, _ReadOnly As Boolean = False
    Public Sub New(ByVal PropDesc As PropertyDescriptor)
        MyBase.New(PropDesc)
        _PropDesc = PropDesc
    End Sub
    Public Property [ReadOnly]() As Boolean
        Get
            Dim mna As DynamicReadOnly = _PropDesc.Attributes(GetType(DynamicReadOnly))
            If Not IsNothing(mna) Then
                Return mna.GetReadOnly
            End If
            Return _ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            _ReadOnly = Value
        End Set
    End Property

    Public Overrides ReadOnly Property Category() As String
        Get
            Return _PropDesc.Category
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Dim mna As DisplayName = _PropDesc.Attributes(GetType(DisplayName))
            If Not IsNothing(mna) Then
                Return mna.ToString()
            End If
            Return _PropDesc.Name
        End Get
    End Property

    Public Overrides ReadOnly Property ComponentType() As Type
        Get
            Return _PropDesc.ComponentType
        End Get
    End Property

    Public Overrides ReadOnly Property IsReadOnly() As Boolean
        Get
            Dim mna As DynamicReadOnly = _PropDesc.Attributes(GetType(DynamicReadOnly))
            If Not IsNothing(mna) Then
                Return mna.GetReadOnly
            End If
            Return _ReadOnly  '//---By dedault False
        End Get
    End Property

    Public Overrides ReadOnly Property PropertyType() As Type
        Get
            Return _PropDesc.PropertyType
        End Get
    End Property

    Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
        Return _PropDesc.CanResetValue((CType(component, PropDispNameWrapper)).Unwrap)
    End Function

    Public Overrides Function GetValue(ByVal component As Object) As Object
        Try
            Return _PropDesc.GetValue((CType(component, PropDispNameWrapper)).Unwrap)
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Public Overrides Sub ResetValue(ByVal component As Object)
        Try
            _PropDesc.ResetValue((CType(component, PropDispNameWrapper)).Unwrap)
        Catch
            'Occurs when user presses Del on a disabled property
        End Try
    End Sub

    Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
        Try
            _PropDesc.SetValue((CType(component, PropDispNameWrapper)).Unwrap, value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
        Try
            Return _PropDesc.ShouldSerializeValue((CType(component, PropDispNameWrapper)).Unwrap)
        Catch ex As Exception
            Return False
        End Try        
    End Function
End Class

<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field), Serializable()> _
Public Class DisplayName : Inherits Attribute
    Dim _sText As String
    Public Sub New(ByVal Text As String)
        MyBase.New() : _sText = Text
    End Sub
    Public Overrides Function ToString() As String
        Return _sText
    End Function
End Class

<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field), Serializable()> _
Public Class DynamicReadOnly : Inherits Attribute
    Dim _key As String
    Public Sub New(ByVal key As String)
        MyBase.New()
        _key = key
    End Sub
    Function GetReadOnly() As Boolean
        Return GetValue(_key)
    End Function

    Private Shared values As New SortedList
    Shared Sub SetValue(ByVal key As String, ByVal value As Boolean)
        If values.ContainsKey(key) Then
            values(key) = value
        Else
            values.Add(key, value)
        End If
    End Sub
    Shared Function GetValue(ByVal key As String) As Boolean
        If values.ContainsKey(key) Then
            Return CBool(values(key))
        Else
            Return False
        End If
    End Function
End Class

Public Class ChoicesConverter
    Inherits TypeConverter

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'true means show a combobox
        Return True
    End Function

    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'true will limit to list.
        'false will show the list, but allow free-form entry
        Return True
    End Function
End Class

Public Class ConverterVariables
    Public Shared maxFrame As Integer
End Class

Class FrameConverter
    Inherits ChoicesConverter

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
        Dim strArray() As String
        ReDim strArray(ConverterVariables.maxFrame - 1)
        For i As Integer = 0 To strArray.Length - 1
            strArray(i) = CStr(i) + 1
        Next
        Return New StandardValuesCollection(strArray)
    End Function
End Class
