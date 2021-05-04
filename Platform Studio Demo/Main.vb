Imports psEditor

Public Class DemoEdition
    Implements Edition

    Public Const mySplashFile As String = "splashdemo.jpg"
    Public Const myUpdatePath As String = "http://jumpcraft.com/"
    Public Const surveyUrl As String = "http://jumpcraft.com/feedback"
    Public Const myRequireUsernameAndPassword As Boolean = False    

    Shared Sub Main()
        If AlreadyRunning() Then
            MessageBox.Show("You may only have one instance of JumpCraft running at a time.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MyEdition = New DemoEdition()
        Application.Run(New frmGame)
    End Sub

    Public Sub OnLoad(ByVal f As frmGame) Implements psEditor.Edition.OnLoad
        Dim fW As New frmWelcome
        fW.ShowDialog()
        f.mnuUpgrade.Visible = True
    End Sub

    Function OnClose() As Boolean Implements Edition.OnClose
        'Dim fF As New frmFeedback
        'fF.ShowDialog()
        Return True
    End Function

    Public Sub OnClickUpgrade() Implements psEditor.Edition.OnClickUpgrade
        frmFeatureDisabled.Purchase()
    End Sub

    Public Function Compile() As Boolean Implements psEditor.Edition.Compile
        Dim f As New frmFeatureDisabled
        f.ShowDialog("compile", "demo")
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
            'f.setPrice(ProPrice)
            f.ShowDialog("level", "demo")
            Return True
        End If
        Return False
    End Function

    Public Function ReachedMaximumWindow() As Boolean Implements psEditor.Edition.ReachedMaximumWindow
        If Game.numWindows >= 9 Then
            Dim f As New frmFeatureDisabled
            'f.setMessage("You can only have up to 9 windows in this edition of JumpCraft.")
            'f.setPrice(ProPrice)
            f.ShowDialog("window", "demo")
            Return True
        End If
        Return False
    End Function

    Public Function ReachedMaximumTile() As Boolean Implements psEditor.Edition.ReachedMaximumTile
        If Game.tileset.NumTiles >= 25 Then
            Dim f As New frmFeatureDisabled
            'f.setMessage("You can only have up to 25 tiles in this edition of JumpCraft.")
            'f.setPrice(ProPrice)
            f.ShowDialog("tile", "demo")
            Return True
        End If
        Return False
    End Function

    Public Function CheckCanSave(ByVal QuietUpgrade As Boolean) As Boolean Implements psEditor.Edition.CheckCanSave
        If QuietUpgrade Then
            Process.Start("http://jumpcraft.com/purchase?action=save")
        Else
            Dim f As New frmFeatureDisabled
            'f.setMessage("You cannot save files in this edition of JumpCraft.")
            'f.setPrice(StandardPrice)
            f.ShowDialog("save", "demo")
        End If
        Return False
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