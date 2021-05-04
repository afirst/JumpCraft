Public Module psOptionsMod
    Structure psOptions
        'General
        '
        Dim gShowWelcome As Boolean
        Dim gShowSplash As Boolean
        Dim gStartMaximized As Boolean
        Dim gCheckForUpdatesAtStartup As Boolean
        Dim gShowWelcomeDialog As Boolean
        Dim gDefaultGame As Boolean
        Dim gWarnWhenDelActions As Boolean
        Dim gUndoLevels As Byte
        Dim gNumMRU As Byte
        Dim gImageEditor As String
        Dim gShowFeedback As Boolean
        '
        'Map Editor
        '
        Dim mShowGrid As Boolean
        Dim mGridLines As Boolean
        Dim mShowToolbars As Boolean
        Dim mShowStatusBar As Boolean
        Dim mShowTileSelector As Boolean
        Dim mShowLayersPanel As Boolean
        Dim mShowLevelsPanel As Boolean
        Dim mShowPropertiesPanel As Boolean
        Dim mDrawTilePaths As Boolean
        Dim mShowFramerate As Boolean        
        '
        'Path Editor
        '
        Dim pShowPoints As Boolean
        Dim pShowGuides As Boolean
        Dim pTintBackground As Boolean
        Dim pTint As Integer
        Dim pPrecision As Integer
        '
        'Window Editor
        '
        Dim wShowGrid As Boolean
        Dim wGridSpacing As Integer
        Dim wGridLines As Boolean
        Dim wShowToolbar As Boolean
        Dim wShowStatusBar As Boolean
        Dim wShowControlSelector As Boolean
        Dim wShowWindowsPanel As Boolean
        Dim wShowActionsPanel As Boolean
        Dim wShowFramerate As Boolean

        Sub SetDefaults()
            gShowWelcome = True
            gShowSplash = True
            gStartMaximized = True
            'gCheckForUpdatesAtStartup = True
            gShowWelcomeDialog = True
            gDefaultGame = True
            gWarnWhenDelActions = True
            gUndoLevels = 100
            gImageEditor = "mspaint"
            gShowFeedback = True
            gNumMRU = 4
            mShowGrid = True
            mGridLines = True
            mShowToolbars = True
            mShowStatusBar = True
            mShowTileSelector = True
            mShowLayersPanel = True
            mShowLevelsPanel = True
            mShowPropertiesPanel = True
            mDrawTilePaths = True
            mShowFramerate = False
            pShowPoints = True
            pShowGuides = True
            pTintBackground = True
            pTint = 50
            pPrecision = 5
            wShowGrid = True
            wGridSpacing = 8
            wGridLines = False
            wShowToolbar = True
            wShowStatusBar = True
            wShowControlSelector = True
            wShowWindowsPanel = True
            wShowActionsPanel = True
            wShowFramerate = False
        End Sub
    End Structure

    Public Options As psOptions

    Private Structure psOptionsHeader
        Dim Header As String

        Sub Init()
            Header = "Platform Studio " & AssemblyVersion & " Options"
        End Sub
    End Structure

    Private OptionsHeader As psOptionsHeader

    Sub LoadOptions(ByVal Filename As String)
        OptionsHeader.Init()
        If IO.File.Exists(Filename) Then
            Dim tmpOptionsHeader As psOptionsHeader
            FileClose(1)
            Try
                FileOpen(1, Filename, OpenMode.Binary, OpenAccess.Read)
                FileGet(1, tmpOptionsHeader)
                If tmpOptionsHeader.Header <> OptionsHeader.Header Then
                    If Not tmpOptionsHeader.Header.StartsWith("Platform Studio") Then
                        'MessageBox.Show("The options file is either invalid or from a different version of Platform Studio.  A new options file with default values will be put in its place.", "Invalid Options File", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    GoTo NewOptions
                End If
                FileGet(1, Options)
            Catch ex As Exception
                'MessageBox.Show("An error occured while trying to load the options file." & vbCrLf & vbCrLf & "Message: " & ex.Message & vbCrLf & vbCrLf & "A new options file with default values will be put in its place.", "Invalid Options File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GoTo NewOptions
            Finally
                FileClose(1)
            End Try
        Else
NewOptions:
            FileClose(1)
            Options.SetDefaults()
            SaveOptions(Filename)
        End If
    End Sub

    Sub SaveOptions(ByVal Filename As String)
        OptionsHeader.Init()
        FileClose(1)
        Try
            FileOpen(1, Filename, OpenMode.Binary, OpenAccess.Write)
            FilePut(1, OptionsHeader)
            FilePut(1, Options)
        Catch ex As Exception
            'MessageBox.Show("An error occured while trying to save the options file." & vbCrLf & vbCrLf & "Message: " & ex.Message & vbCrLf & vbCrLf & "Any changes to the editor's options will be lost.", "Cannot Save Options File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            FileClose(1)
        End Try
    End Sub
End Module
