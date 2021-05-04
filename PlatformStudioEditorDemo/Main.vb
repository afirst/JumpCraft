Imports psEditor

Public Class StandardEdition
    Implements Edition

    Public Const mySplashFile As String = "splash.jpg"
    Public Const myUpdatePath As String = "http://jumpcraft.com/dl_psstandard"
    Public Const myRequireUsernameAndPassword As Boolean = False
    
    Shared Sub Main()
        If AlreadyRunning() Then
            MessageBox.Show("You may only have one instance of JumpCraft running at a time.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MyEdition = New StandardEdition()
        Application.Run(New frmGame)
    End Sub

    Public Sub OnLoad(ByVal f As frmGame) Implements psEditor.Edition.OnLoad
        Dim fW As New frmWelcome
        fW.ShowDialog()
        f.mnuUpgrade.Visible = True
    End Sub

    Function OnClose() As Boolean Implements Edition.OnClose
        Return True
    End Function

    Public Sub OnClickUpgrade() Implements psEditor.Edition.OnClickUpgrade
        frmFeatureDisabled.Purchase()
    End Sub

    Public Function Compile() As Boolean Implements psEditor.Edition.Compile
        Dim f As New frmFeatureDisabled
        f.ShowDialog("compile", "standard")
        Return False
    End Function

    Private Function getCompileConstant() As Boolean Implements psEditor.Edition.getCompileConstant
        Return True
    End Function

    Public Function getCompilePtr() As Boolean Implements psEditor.Edition.getCompilePtr
        Return Compile()
    End Function

    Public Function ReachedMaximumLevel() As Boolean Implements psEditor.Edition.ReachedMaximumLevel
        If Game.numMaps >= 8 Then
            Dim f As New frmFeatureDisabled
            'f.setMessage("You can only have up to 8 levels in this edition of JumpCraft.")
            'f.setPrice(UpgradePrice)
            f.ShowDialog("level", "standard")
            Return True
        End If
        Return False
    End Function

    Public Function ReachedMaximumWindow() As Boolean Implements psEditor.Edition.ReachedMaximumWindow
        If Game.numWindows >= 9 Then
            Dim f As New frmFeatureDisabled
            'f.setMessage("You can only have up to 9 windows in this edition of JumpCraft.")
            'f.setPrice(UpgradePrice)
            f.ShowDialog("window", "standard")
            Return True
        End If
        Return False
    End Function

    Public Function ReachedMaximumTile() As Boolean Implements psEditor.Edition.ReachedMaximumTile
        If Game.tileset.NumTiles >= 25 Then
            Dim f As New frmFeatureDisabled
            'f.setMessage("You can only have up to 25 tiles in this edition of JumpCraft.")
            'f.setPrice(UpgradePrice)
            f.ShowDialog("tile", "standard")
            Return True
        End If
        Return False
    End Function

    Public Function CheckCanSave(ByVal QuietUpgrade As Boolean) As Boolean Implements psEditor.Edition.CheckCanSave
        Return True
    End Function

    Public Function RequireUsernameAndPassword() As Boolean Implements psEditor.Edition.RequireUsernameAndPassword
        Return myRequireUsernameAndPassword
    End Function

    Public Function SplashFile() As String Implements psEditor.Edition.SplashFile
        Return mySplashFile
    End Function

    Public Function UpdatePath() As String Implements psEditor.Edition.UpdatePath
        Return myUpdatePath
    End Function
End Class