Imports PlatformStudio
Imports System.Reflection
Imports System.Resources
Imports System.Globalization
Imports PlatformStudio.psMap

#Region "mDeclarations"
Public Module mDeclarations
    Public WithEvents Game As New psGame
    Public MyEdition As Edition
    Private Resources As New ResourceManager("psEditor.Localization", [Assembly].GetExecutingAssembly())

    Public WithEvents psFile As New psFileHandler

    Public fSplash As frmSplash
    Public fGame As frmGame
    Public fActionEdit As psfrmActionEditor

    Public StartAtLevel As Integer = 1

    Public Function AlreadyRunning() As Boolean
        Dim processName As String = Process.GetCurrentProcess().ProcessName
        Dim processes() As Process = Process.GetProcessesByName(processName)
        Return processes.Length > 1
    End Function

    Public Function GetString(ByVal key As String) As String
        Dim s As String = Resources.GetString(key)
        Return s.Replace("\n", vbCrLf)
    End Function

    Public Function GetString1(ByVal key As String) As String
        Return psMod1.GetString(key)
    End Function

    Public Function MatchAny1(ByVal text As String, ByVal matchToKey As String) As Boolean
        Return psMod1.MatchAny(text, matchToKey)
    End Function

    Sub Wait(ByVal WaitAmount As Single)
        Dim s As Single
        s = Microsoft.VisualBasic.Timer
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Microsoft.VisualBasic.Timer - s >= WaitAmount
    End Sub

    Sub ConvertToNumber(ByRef ctl As Object, ByVal min As Integer, ByVal max As Integer, ByVal def As Integer, Optional ByVal DigitsAfterDecimal As Integer = 0)
        With ctl
            If IsNumeric(.Text) Then
                .Text = CSng(Math.Round(CDec(.Text), DigitsAfterDecimal))
                If .Text < min Then .Text = min
                If .Text > max Then .Text = max
            Else
                ctl.Text = def
            End If
        End With
    End Sub

    Public fTileset As psfrmTileset

    Sub ShowTilesetEdit()
        'Deselect
        If Not (Editor.psedit Is Nothing) Then
            If Editor.psedit.PromptToSavePath = DialogResult.Cancel Then Exit Sub
            Editor.psedit.Deselect()
        End If

        fTileset = New psfrmTileset

        Dim tmpTileset As psTileset
        Dim tw As Integer, th As Integer, tc As Integer
        tmpTileset = Game.tileset
        tw = Game.tileW
        th = Game.tileH
        tc = Game.tileColorKey

        If fTileset.ShowDialog = DialogResult.Cancel Then
            '    Game.tileset = tmpTileset
            '    Game.tileW = tw
            '    Game.tileH = th
            '    Game.tileColorKey = tc
        End If

        Editor.pstileselect.UpdateList()
        'Editor.pstileselect.RefreshPreview()
        If psEditor.CurTile > Game.tileset.NumTiles Then psEditor.CurTile = Game.tileset.NumTiles
    End Sub

    Sub ShowResizeMap()
        Dim fResize As New psfrmResize
        fResize.ShowDialog()
    End Sub

    Sub ShowActionEdit()
        'Deselect
        If Not (Editor.psedit Is Nothing) Then
            If Editor.psedit.PromptToSavePath = DialogResult.Cancel Then Exit Sub
            Editor.psedit.Deselect()
        End If

        fActionEdit = New psfrmActionEditor
        fActionEdit.ShowDialog()
        fActionEdit.Dispose()
        fActionEdit = Nothing
    End Sub

    Sub ShowFindReplace()
        Dim fFindReplace As New psfrmFindReplaceTiles
        fFindReplace.Show()
    End Sub

#Region " Global DockControl Members "
    Public Property DockControlVisible(ByVal Dock_Ctrl As DockingSuite.DockControl, ByVal Dock_Host As DockingSuite.DockHost) As Boolean
        Get
            Return Dock_Ctrl.Visible
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                Dock_Ctrl.EnsureVisible(Dock_Host)
            Else
                Dock_Ctrl.Close()
            End If
        End Set
    End Property

    Public Sub SetDefaultColors(ByVal Dock_Host As DockingSuite.DockHost)
        With Dock_Host.Colors
            .UseCustomTabStripBackColor = True
            .ActiveTitleBarBackground1 = UIPlus.ColorOp.Blend(SystemColors.ActiveCaption, SystemColors.Window, 0.24) ' Color.FromArgb(0, 84, 227)
            .ActiveTitleBarBackground2 = SystemColors.Highlight 'Color.FromArgb(60, 148, 254)
            .ActiveTitleBarWidgets = SystemColors.ActiveCaptionText 'Color.White
            .DrawTitleBarBorder = False
            .InactiveTitleBarBackground1 = UIPlus.ColorOp.Blend(SystemColors.InactiveBorder, SystemColors.ControlDark, 0.25) 'Color.FromArgb(122, 150, 223)
            .InactiveTitleBarBackground2 = .InactiveTitleBarBackground1 'Color.FromArgb(156, 184, 234)
            .InactiveTitleBarWidgets = SystemColors.WindowText 'Color.Black 'Color.FromArgb(216, 217, 236)            
            .TabHighlightColor = SystemColors.ControlDark
            .TabShadowColor = SystemColors.ControlDark
        End With
    End Sub
#End Region

    Private tmpV1, tmpV2 As Boolean
    Private tmpV1Host, tmpV2Host As DockingSuite.DockHost

    Sub BeginLoadGame() Handles psFile.BeginLoadGame
        'Deselect anything that is selected
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect()

        'Close the path editor
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.PathEdit.Done(True)
    End Sub

    Sub BeginSaveGame() Handles psFile.BeginSaveGame
        'Deselect anything that is selected
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect(True)
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect(True)
    End Sub

    Sub EndLoadGame() Handles psFile.EndLoadGame
        'Update controls
        If Not (Editor.pslevelsel Is Nothing) Then Editor.LevelSel_Refresh()
        If Not (Editor.pstileselect Is Nothing) Then Editor.pstileselect.UpdateList()
        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Sub BeginLoadingGame() Handles Game.BeginLoadingGame
        'Clear the undo buffer
        UndoRedo.ResetUndo()
    End Sub

    Sub RequestReInitInEditor() Handles Game.RequestReInitInEditor
        Editor.Init(Editor.psedit, 5938195395831283597)
    End Sub

    Sub BeginInit() Handles Game.BeginInit
        'Close the path editor
        If Not (Editor.psedit Is Nothing) AndAlso _
        Not (Editor.psedit.PathEdit Is Nothing) Then
            Editor.psedit.PathEdit.Done(True)
        End If
    End Sub

    Sub EndInit() Handles Game.EndInit
        UndoRedo.ResetUndo()

        'Configure level selector
        If (Editor.pslevelsel Is Nothing) = False Then
            Editor.pslevelsel.Refresh()
        End If

        'Configure window selector
        If (Editor.winsel Is Nothing) = False Then
            Editor.winsel.Refresh()
        End If

        'Configure tile selector
        If (Editor.pstileselect Is Nothing) = False Then
            Editor.pstileselect.UpdateList()
        End If

        'Configure properties
        If (Editor.psproperties Is Nothing) = False Then
            Editor.psproperties.Refresh()
        End If

        If Not (Editor.psproperties Is Nothing) Then Editor.psproperties.Refresh()
    End Sub

    Sub ChangedTileSize() Handles Game.ChangedTileSize
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.DoResize()
    End Sub

    Sub ChangedCurrentMap() Handles Game.ChangedCurrentMap
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.Deselect()
    End Sub

    Sub RequestStatus(ByVal Status() As String) Handles Game.RequestStatus
        If Editor.psstatus IsNot Nothing Then
            Status(0) = Editor.psstatus.sb.Panels(0).Text
        End If
    End Sub

    Sub ChangedStatus(ByVal Status As String) Handles Game.ChangedStatus
        If Editor.psstatus IsNot Nothing Then
            Editor.psstatus.sb.Panels(0).Text = Status
        End If
    End Sub
End Module
#End Region

#Region "Editor"
Public Class Editor
    Public Shared pstools As psTools
    Public Shared psedit As psEditor
    Public Shared pstileselect As psTileSelector
    Public Shared psstatus As psStatus
    Public Shared pslayersel As psLayerSelector
    Public Shared pslevelsel As psLevelSelector
    Public Shared psproperties As psProperties
    Public Shared winedit As psWinEditor
    Public Shared winctrls As psTileSelector
    Public Shared winsel As psWinSelector
    Public Shared winstatus As psWinStatus
    Private Shared layout1, layout2 As String

    Public Shared Sub LevelSel_Refresh()
        If (pslevelsel Is Nothing) = False Then
            pslevelsel.Refresh()
        End If
    End Sub

    Public Shared Sub LevelSel_SelectLast()
        If (pslevelsel Is Nothing) = False Then
            pslevelsel.SelectLast()
        End If
    End Sub

    Public Shared Sub WinSel_Refresh()
        If (winsel Is Nothing) = False Then
            winsel.Refresh()
        End If
    End Sub

    Public Shared Sub WinSel_SelectLast()
        If (winsel Is Nothing) = False Then
            winsel.SelectLast()
        End If
    End Sub

    Public Shared Sub OnBeginPathEdit()
        fGame.DockControl4.Text = GetString("toolboxPanelTitle")
        layout1 = fGame.DockHost1.LayoutInfo.GetLayout()
        layout2 = fGame.DockHost2.LayoutInfo.GetLayout()
        fGame.MenuItem18.Enabled = False
        fGame.MenuItem38.Enabled = False
        DockControlVisible(fGame.DockControl1, Nothing) = False
        DockControlVisible(fGame.DockControl2, Nothing) = False
    End Sub

    Public Shared Sub OnEndPathEdit()
        fGame.DockHost1.LayoutInfo.SetLayout(layout1)
        fGame.DockHost2.LayoutInfo.SetLayout(layout2)
        fGame.MenuItem18.Enabled = True
        fGame.MenuItem38.Enabled = True
        fGame.DockControl4.Text = GetString("tilesPanelTitle")
    End Sub

    Public Shared Function Init(ByVal PlatformStudioMapEditor As psEditor, ByVal Flags As Long) As Boolean
        Editor.psedit = PlatformStudioMapEditor
        If Game.Init(PlatformStudioMapEditor.hwnd, PlatformStudioMapEditor.p, Flags) = False Then Return False
        PlatformStudioMapEditor.Init()
        Editor.psedit.DoResize()
        Return True
    End Function
End Class
#End Region

#Region "UndoRedo"
Public Class UndoRedo
    Enum UndoType
        Windows = 1
        Actions = 2
        WindowsAndActions = 3
        Locations = 4
        Layer = 8
        Level = 16
        AllLevels = 32
        All = 35
        None
    End Enum
    Structure psUndo
        Dim Maps() As psMap
        Dim Loc As psLocationLayer
        Dim Actions As psActions
        Dim Win As psUI.psWindows
        Dim baseType As UndoType
        Dim type As UndoType
        Dim level As Integer, layer As Integer
        Dim layerdata As psLayer
    End Structure
    Shared Undo() As psUndo
    Public Shared UndoStr() As String
    Public Shared CurUndo As Integer
    Public Shared CanUndo As Boolean, CanRedo As Boolean
    Shared NeedToUpdate As Boolean
    Public Shared MaxUndo As Byte = 50

    Shared Sub ResetUndo()
        Erase Undo
        Erase UndoStr
        CanUndo = False
        CanRedo = False
        NeedToUpdate = False
        CurUndo = 0
        If Not (Editor.psedit Is Nothing) Then Editor.psedit.UndoRedoTextChanged()
    End Sub

    Public Shared Sub UpdateUndo(ByVal Description As String, ByVal Action As UndoType, Optional ByVal level As Integer = 0, Optional ByVal layer As Integer = 0)
        psFileHandler.MadeChanges = True

        DoNotLoadImages = True

        If layer = 4 Then Action = UndoType.Locations
        Dim tmpLoc As psLocationLayer = Game.CurMap.loc.Clone
        Dim tmpL As psLayer = Game.CurMap.Layer(psMap.CurLayer).Clone
        Editor.psedit.Deselect(True)
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect(True)

        Dim i As Integer
        ReDim Preserve Undo(CurUndo)
        ReDim Preserve UndoStr(CurUndo)
        ReDim Undo(UBound(Undo)).Maps(UBound(Game.maps))
        With Undo(UBound(Undo))
            .level = level
            .layer = layer
            .baseType = Action
            .type = Action
            Dim tmpType As UndoType, type2 As UndoType
            If Undo.Length = 1 Then
                tmpType = UndoType.All
            Else
                tmpType = Undo(UBound(Undo) - 1).baseType
            End If
            type2 = tmpType

            'Combine undo types
            tmpType = (.type Or type2)
            If .type = UndoType.Layer AndAlso type2 = UndoType.Layer AndAlso Not (layer = Undo(UBound(Undo) - 1).layer AndAlso level = Undo(UBound(Undo) - 1).level) Then
                tmpType = UndoType.Level
            End If
            If (.type = UndoType.Level And type2 = UndoType.Level) Or _
                (.type = UndoType.Locations And (type2 = UndoType.Level Or type2 = UndoType.Layer)) Or _
                (.type = UndoType.Layer And (type2 = UndoType.Level Or type2 = UndoType.Locations)) Or _
                (.type = UndoType.Level And (type2 = UndoType.Locations Or type2 = UndoType.Layer)) Or _
                (type2 = UndoType.Locations And (.type = UndoType.Level Or .type = UndoType.Layer)) Or _
                (type2 = UndoType.Layer And (.type = UndoType.Level Or .type = UndoType.Locations)) Or _
                (type2 = UndoType.Level And (.type = UndoType.Locations Or .type = UndoType.Layer)) Then
                tmpType = UndoType.AllLevels
            End If
            If ((.type = UndoType.Layer Or .type = UndoType.Locations) AndAlso (type2 = UndoType.Layer Or type2 = UndoType.Locations)) OrElse _
               ((.type = UndoType.Level) AndAlso (type2 = UndoType.Layer Or type2 = UndoType.Locations Or type2 = UndoType.Level)) OrElse _
               (.type = UndoType.Windows Or .type = UndoType.Actions) Then
                If UBound(Undo) > 0 Then
                    .level = Undo(UBound(Undo) - 1).level
                    .layer = Undo(UBound(Undo) - 1).layer
                End If
            End If
            .type = tmpType

            'Store only relevant data
            If (tmpType And UndoType.Actions) > 0 Then
                .Actions = Game.actions.Clone
            End If
            If (tmpType And UndoType.Windows) > 0 Then
                .Win = Game.windows.Clone(False)
            End If
            If (tmpType And UndoType.AllLevels) > 0 Then
                .Maps = Game.CloneMaps
            ElseIf (tmpType And UndoType.Level) > 0 Then
                .Maps = New psMap() {Game.maps(.level).Clone}
            Else
                If (tmpType And UndoType.Layer) > 0 Then
                    .layerdata = Game.maps(.level).Layer(.layer).Clone
                End If
                If (tmpType And UndoType.Locations) > 0 Then
                    .Loc = Game.maps(.level).loc.Clone
                End If
            End If

        End With

        UndoStr(UBound(Undo)) = Description
        NeedToUpdate = True
        CurUndo = CurUndo + 1
        CanUndo = True
        CanRedo = False
        If UBound(Undo) > MaxUndo Then
            For i = 0 To MaxUndo
                Undo(i) = Undo((i + UBound(Undo) - (MaxUndo)))
            Next
            ReDim Preserve Undo(MaxUndo)
            CurUndo = MaxUndo + 1
        End If

        Editor.psedit.UndoRedoTextChanged()
        If Not (Editor.winedit Is Nothing) Then
            Editor.winedit.UndoRedoTextChanged()
        End If

        Game.maps(Game.CurMapIndex).Layer(psMap.CurLayer) = tmpL
        Game.maps(Game.CurMapIndex).loc = tmpLoc

        DoNotLoadImages = False
    End Sub

    Shared Sub DoUndo()
        Editor.psedit.Deselect()
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect()

        If NeedToUpdate Then UpdateUndo("", UndoType.All) : CurUndo = CurUndo - 1
        NeedToUpdate = False
        CurUndo = CurUndo - 1

        RestoreState(CurUndo, False)
        If Not (Editor.pslevelsel Is Nothing) Then Editor.pslevelsel.Refresh()
        If Not (Editor.winsel Is Nothing) Then Editor.winsel.Refresh()

        If Game.CurMapIndex > UBound(Game.maps) Then Game.CurMapIndex = UBound(Game.maps)
        Editor.pslevelsel.ListBox1.SelectedIndex = Game.CurMapIndex - 1

        If CurUndo = 0 Then
            CanUndo = False
        Else
            CanUndo = True
        End If
        CanRedo = True

        Editor.psedit.UndoRedoTextChanged()
        If Not (Editor.winedit Is Nothing) Then
            Editor.winedit.UndoRedoTextChanged()
            Editor.winedit.UpdateSel()
        End If
    End Sub

    Shared Sub DoRedo()
        Editor.psedit.Deselect()
        If Not (Editor.winedit Is Nothing) Then Editor.winedit.Deselect()

        NeedToUpdate = False
        CurUndo = CurUndo + 1

        RestoreState(CurUndo, True)
        If Not (Editor.pslevelsel Is Nothing) Then Editor.pslevelsel.Refresh()
        If Not (Editor.winsel Is Nothing) Then Editor.winsel.Refresh()

        If Game.CurMapIndex > UBound(Game.maps) Then Game.CurMapIndex = UBound(Game.maps)
        Editor.pslevelsel.ListBox1.SelectedIndex = Game.CurMapIndex - 1

        If CurUndo = UBound(Undo) Then
            CanRedo = False
        Else
            CanRedo = True
        End If
        CanUndo = True

        Editor.psedit.UndoRedoTextChanged()
        If Not (Editor.winedit Is Nothing) Then
            Editor.winedit.UndoRedoTextChanged()
            Editor.winedit.UpdateSel()
        End If
    End Sub

    Private Shared Sub RestoreState(ByVal undoIndex As Integer, ByVal Redo As Boolean)
        'Store only relevant data
        With Undo(undoIndex)
            If (.type And UndoType.Actions) > 0 Then
                Game.actions = .Actions.Clone
            End If
            If (.type And UndoType.Windows) > 0 Then
                Game.windows = .Win.Clone
            End If
            If (.type And UndoType.AllLevels) > 0 Then
                ReDim Game.maps(UBound(.Maps))
                For i As Integer = 1 To UBound(.Maps)
                    Game.maps(i) = .Maps(i).Clone
                Next
            ElseIf (.type And UndoType.Level) > 0 Then
                Game.maps(.level) = .Maps(0).Clone
            Else
                If (.type And UndoType.Layer) > 0 Then
                    Game.maps(.level).Layer(.layer) = .layerdata.Clone
                End If
                If (.type And UndoType.Locations) > 0 Then
                    Game.maps(.level).loc = .Loc.Clone
                End If
            End If
        End With
        Exit Sub

        With Undo(undoIndex)
            Select Case .type
                Case UndoType.All
                    ReDim Game.maps(UBound(.Maps))
                    For i As Integer = 1 To UBound(.Maps)
                        Game.maps(i) = .Maps(i).Clone
                    Next
                    Game.actions = .Actions.Clone
                    Game.windows = .Win.Clone
                Case UndoType.AllLevels
                    ReDim Game.maps(UBound(.Maps))
                    For i As Integer = 1 To UBound(.Maps)
                        Game.maps(i) = .Maps(i).Clone
                    Next
                Case UndoType.Level
                    Game.maps(.level) = .Maps(0).Clone
                Case UndoType.Layer
                    Game.maps(.level).Layer(.layer) = .layerdata.Clone
                Case UndoType.Windows
                    Game.windows = .Win.Clone
                Case UndoType.Actions
                    Game.actions = .Actions.Clone
                Case UndoType.Locations
                    Game.maps(.level).loc = .Loc.Clone
                Case UndoType.WindowsAndActions
                    Game.windows = .Win.Clone
                    Game.actions = .Actions.Clone
            End Select
        End With
    End Sub
End Class
#End Region