Imports PlatformStudio
Imports System.ComponentModel

Public Class TileWrapper
    Private ti As Integer

    Sub New(ByVal tileIndex As Integer)
        ti = tileIndex
    End Sub

    <Browsable(False)> _
    Property Contents() As psTile
        Get
            Return Game.tileset.tiles(ti)
        End Get
        Set(ByVal Value As psTile)
            Game.tileset.tiles(ti) = Value
        End Set
    End Property

    <Category("General"), _
    ParenthesizePropertyName(True), _
    Description("The name of the tile."), _
    DynamicReadOnly("TilesetEditor")> _
    Property Name() As String
        Get
            Return Contents.name
        End Get
        Set(ByVal Value As String)
            If Not uniqueKey(Value, ti) Then
                MessageBox.Show(GetString("tilesetEd_TileNameNotUniqueErrorMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Game.tileset.tileName(ti) = Value
            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("General"), _
    Description("The image file to use."), _
    Editor(GetType(ImageFileNamEditor), GetType(Drawing.Design.UITypeEditor))> _
    Property File() As String
        Get
            Return Contents.filename
        End Get
        Set(ByVal Value As String)
            Game.Drawing.AutoGetBits = True
            Game.tileset.tileFile(ti) = Value
            Game.Drawing.AutoGetBits = False
            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("General"), _
    Description("Specifies what happens when the tile interacts with the character, the user, or other elements in the game."), _
    DefaultValue("(None)"), _
    Editor(GetType(TileActionEditor), GetType(Drawing.Design.UITypeEditor)), _
    DynamicReadOnly("TilesetEditor")> _
    Property Actions() As String
        Get
            For i As Integer = 1 To UBound(Game.actions.Actions)
                If Game.actions.Actions(i).Trigger.StartsWith("t") AndAlso Game.actions.Actions(i).Trigger.Substring(4) = ti Then
                    Return Game.actions.Actions(i).Action.Behavior.Name
                End If
            Next
            Return GetString("tilesetEd_NoAction")
        End Get
        Set(ByVal Value As String)
            '
        End Set
    End Property

    <Category("Size"), _
    Description("The width of the tile.")> _
    Property Width() As Integer
        Get
            Return Contents.width
        End Get
        Set(ByVal Value As Integer)
            If Value < 8 Or Value > 1024 Then
                Throw New ArgumentException
            End If

            UpdateBoundarySize(Value, Game.tileset.tileHeight(ti))

            Game.tileset.tileWidth(ti) = Value
            GetSectorDimensions(ti, Dimension.Width, Game.tileset.tileSecW(ti))

            fTileset.propgrid.Refresh()
            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("Size"), _
    Description("The height of the tile.")> _
    Property Height() As Integer
        Get
            Return Contents.height
        End Get
        Set(ByVal Value As Integer)
            If Value < 8 Or Value > 1024 Then
                Throw New ArgumentException
            End If

            UpdateBoundarySize(Game.tileset.tileWidth(ti), Value)

            Game.tileset.tileHeight(ti) = Value
            GetSectorDimensions(ti, Dimension.Height, Game.tileset.tileSecH(ti))

            fTileset.propgrid.Refresh()
            fTileset.list.Invalidate()
        End Set
    End Property

    Private Sub UpdateBoundarySize(ByVal newWidth As Integer, ByVal newHeight As Integer)
        Try
            For i As Integer = 1 To UBound(Game.tileset.tiles(ti).Boundaries.shapes)
                For j As Integer = 1 To UBound(Game.tileset.tiles(ti).Boundaries.shapes(i))
                    With Game.tileset.tiles(ti).Boundaries.shapes(i)(j)
                        .r.X *= (newWidth / Game.tileset.tileWidth(ti))
                        .r.Y *= (newHeight / Game.tileset.tileHeight(ti))
                        .r.Width *= (newWidth / Game.tileset.tileWidth(ti))
                        .r.Height *= (newHeight / Game.tileset.tileHeight(ti))
                    End With
                Next
            Next
        Catch 'null reference
        End Try
    End Sub

    <Category("Size"), _
    DisplayName("Section width"), _
    Description("The width of one section of the tile (aka subtile)."), _
    TypeConverter(GetType(SectionWConverter))> _
    Property SectionWdith() As String
        Get
            Return Contents.sectionw
        End Get
        Set(ByVal Value As String)
            Dim intValue As Integer = Integer.Parse(Value)
            If intValue < 8 Or intValue > 1024 Then
                Throw New ArgumentException
            End If

            Game.tileset.tileSecW(ti) = Value

            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("Size"), _
    DisplayName("Section height"), _
    Description("The height of one section of the tile (aka subtile)."), _
    TypeConverter(GetType(SectionHConverter))> _
    Property SectionHeight() As String
        Get
            Return Contents.sectionh
        End Get
        Set(ByVal Value As String)
            Dim intValue As Integer = Integer.Parse(Value)
            If intValue < 8 Or intValue > 1024 Then
                Throw New ArgumentException
            End If

            Game.tileset.tileSecH(ti) = Value

            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("General"), _
    DisplayName("Transparent color"), _
    Description("The color in the tile image to make transparent."), _
    DefaultValue(GetType(Color), "Transparent")> _
    Property ColorKey() As Color
        Get
            Return Color.FromArgb(Contents.colorkey)
        End Get
        Set(ByVal Value As Color)
            Game.tileset.tileColorKey(ti) = Value.ToArgb
            fTileset.list.Invalidate()
        End Set
    End Property

    <Category("General"), _
    Description("How the tile interacts with the character."), _
    TypeConverter(GetType(BehaviorConverter)), _
    DefaultValue("Solid")> _
    Property Behavior() As String
        Get
            Return BehaviorConverter.strArray(Contents.behavior)
        End Get
        Set(ByVal Value As String)
            If Value = GetString("tileBehavior_Custom") Then
                Dim f As New psfrmTileBehavior
                f.ShowDialog(ti)
                f.Dispose()
                fTileset.propgrid.Refresh()
                Return
            End If

            Dim tmp As psTile = Contents
            For i As Integer = 0 To BehaviorConverter.strArray.Length - 1
                If BehaviorConverter.strArray(i) = Value Then
                    tmp.behavior = i
                    Exit For
                End If
            Next
            Contents = tmp
        End Set
    End Property

    <Category("General"), _
    Description("The amount of hits (shots) on this tile to destroy it."), _
    DefaultValue("N/A")> _
    Property Hitpoints() As String
        Get
            If Contents.HitPoints = 0 Then
                Return GetString("tilesetEd_HitPointsNotApplicable")
            Else
                Return Contents.HitPoints
            End If
        End Get
        Set(ByVal Value As String)
            Value = Value.Trim.ToUpper
            Dim tmp As psTile = Contents
            If Value = GetString("tilesetEd_HitPointsNotApplicable") Then
                tmp.HitPoints = 0
            Else
                If Value < 0 Or Value > 250 Then
                    Throw New ArgumentException
                End If
                tmp.HitPoints = Value
            End If
            Contents = tmp
        End Set
    End Property

    <Category("General"), _
    Description("Edits the animations for this tile."), _
    Editor(GetType(AnimationsEditor), GetType(Drawing.Design.UITypeEditor)), _
    DefaultValue("(None)"), _
    DynamicReadOnly("TilesetEditor")> _
    Property Animations() As String
        Get
            Dim output As String
            For i As Integer = 0 To Contents.Anim.Length - 1
                If Contents.Anim(i).Interval > 0 Then
                    If output <> "" Then output &= ", "
                    output &= psfrmAnimationEditor.getAnimationNames(Contents)(i)
                End If
            Next
            If output = "" Then output = GetString("tilesetEd_NoAnimations")
            Return output
        End Get
        Set(ByVal Value As String)
            '
        End Set
    End Property

    <Category("General"), _
    Description("Edits the boundaries for this tile."), _
    Editor(GetType(BoundaryEditor), GetType(Drawing.Design.UITypeEditor)), _
    DefaultValue("Default"), _
    DynamicReadOnly("TilesetEditor")> _
    Property Boundaries() As String
        Get
            Return Contents.Boundaries.Style.ToString
        End Get
        Set(ByVal Value As String)
            '
        End Set
    End Property

    Public Shared Function uniqueKey(ByVal txt As String, ByVal tileIndex As Integer) As Boolean
        Dim i As Integer
        For i = 0 To Game.Drawing.img_Count - 1
            If Game.Drawing.Tex.GetByIndex(i).key = txt AndAlso _
            Game.Drawing.Tex.GetByIndex(i).key <> Game.tileset.tileName(tileIndex) Then
                Return False
            End If
        Next
        Return True
    End Function

    Enum Dimension
        Width
        Height
    End Enum

    Public Shared Function GetSectorDimensions(ByVal tile As Integer, ByVal d As Dimension, Optional ByRef def As Integer = 0) As Integer()
        Dim curTile As psTile
        curTile = Game.tileset.tiles(tile)

        Dim x() As Integer = {}
        def = 0

        If d = Dimension.Width Then 'Width

            If curTile.width < 8 Then curTile.width = Game.tileW

            For i As Integer = 8 To curTile.width
                If curTile.width / i = curTile.width \ i Then
                    ReDim Preserve x(UBound(x) + 1)
                    x(UBound(x)) = i
                    If i = curTile.sectionw Then def = x(UBound(x))
                End If
            Next

            If def = 0 Then def = curTile.width
            Return x

        Else 'Height

            If curTile.height < 8 Then curTile.height = Game.tileH

            For i As Integer = 8 To curTile.height
                If curTile.height / i = curTile.height \ i Then
                    ReDim Preserve x(UBound(x) + 1)
                    x(UBound(x)) = i
                    If i = curTile.sectionh Then def = x(UBound(x))
                End If
            Next

            If def = 0 Then def = curTile.height
            Return x

        End If

    End Function
End Class

Class SectionWConverter
    Inherits ChoicesConverter

    Protected Overridable Function Dimension() As TileWrapper.Dimension
        Return TileWrapper.Dimension.Width
    End Function

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
        Dim strArray()() As String
        ReDim strArray(fTileset.list.SelIndices.Count - 1)
        For n As Integer = 0 To fTileset.list.SelIndices.Count - 1
            Dim intArray() As Integer = TileWrapper.GetSectorDimensions(fTileset.list.SelIndices(n), Dimension)
            ReDim strArray(n)(UBound(intArray))
            For i As Integer = 0 To strArray(n).Length - 1
                strArray(n)(i) = intArray(i)
            Next
        Next
        Dim finalArray() As String
        ReDim finalArray(-1)
        For n As Integer = 0 To UBound(strArray(0))
            For i As Integer = 1 To UBound(strArray)
                For j As Integer = 0 To UBound(strArray(i))
                    If strArray(0)(n) = strArray(i)(j) Then
                        GoTo ContinueForI
                    End If
                Next
                GoTo ContinueForN
ContinueForI: Next
            ReDim Preserve finalArray(finalArray.Length)
            finalArray(UBound(finalArray)) = strArray(0)(n)
ContinueForN: Next
        Return New StandardValuesCollection(finalArray)
    End Function
End Class

Class SectionHConverter
    Inherits SectionWConverter

    Protected Overrides Function Dimension() As TileWrapper.Dimension
        Return TileWrapper.Dimension.Height
    End Function
End Class

Class BehaviorConverter
    Inherits ChoicesConverter

    Public Shared strArray() As String = {GetString("tileBehavior_Solid"), GetString("tileBehavior_Background"), _
        GetString("tileBehavior_Collectable"), GetString("tileBehavior_Ledge"), GetString("tileBehavior_Character"), GetString("tileBehavior_NoGravity"), _
        GetString("tileBehavior_Custom")}

    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As TypeConverter.StandardValuesCollection
        Dim tmpArray() As String = strArray.Clone
        If fTileset.list.SelIndices.Count > 1 Then
            ReDim Preserve tmpArray(UBound(tmpArray) - 1)
        End If
        Return New StandardValuesCollection(tmpArray)
    End Function
End Class

Class AnimationsEditor
    Inherits Drawing.Design.UITypeEditor

    Private service As Windows.Forms.Design.IWindowsFormsEditorService

    Protected Overridable Sub ShowForm()
        Dim f As New psfrmAnimationEditor
        f.ShowDialog(Game.tileset.tiles(fTileset.Value))
        If f.DialogResult = DialogResult.OK Then fTileset.UpdateStartTimesAndFrames()
        f.Dispose()
    End Sub

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing And Not context.Instance Is Nothing And Not provider Is Nothing) Then
            service = CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)), Windows.Forms.Design.IWindowsFormsEditorService)
            If (Not service Is Nothing) Then
                ShowForm()
            End If
        End If
        Return value
    End Function

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            If DynamicReadOnly.GetValue("TilesetEditor") Then
                Return Drawing.Design.UITypeEditorEditStyle.None
            Else
                Return Drawing.Design.UITypeEditorEditStyle.Modal
            End If
        End If
        Return MyBase.GetEditStyle(context)
    End Function

    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return False
    End Function
End Class

Class BoundaryEditor
    Inherits AnimationsEditor

    Protected Overrides Sub ShowForm()
        Dim f As New frmBoundaries
        f.ShowDialog(Game.tileset.tiles(fTileset.Value))
        f.Dispose()
    End Sub
End Class

Class TileActionEditor
    Inherits AnimationsEditor

    Protected Overrides Sub ShowForm()
        fTileset.ShowActionsForSelectedTile()
    End Sub

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As Drawing.Design.UITypeEditorEditStyle
        If (Not context Is Nothing And Not context.Instance Is Nothing) Then
            ' we'll show a modal form
            If DynamicReadOnly.GetValue("TilesetEditor") Then
                Return Drawing.Design.UITypeEditorEditStyle.None
            Else
                Return Drawing.Design.UITypeEditorEditStyle.Modal
            End If
        End If
        Return MyBase.GetEditStyle(context)
    End Function
End Class