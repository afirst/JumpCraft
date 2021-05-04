Imports psEditor

Public Class ProfessionalEdition
    Implements Edition

    Public Const myRequireUsernameAndPassword As Boolean = True
    Public Const mySplashFile As String = "splashpro.jpg"
    Public Const myUpdatePath As String = "http://jumpcraft.com/dl_pspro"

    Shared Sub Main()
        If AlreadyRunning() Then
            MessageBox.Show("You may only have one instance of JumpCraft running at a time.", "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MyEdition = New ProfessionalEdition()
        Application.Run(New frmGame)
    End Sub

    Public Sub OnLoad(ByVal f As frmGame) Implements psEditor.Edition.OnLoad

    End Sub

    Function OnClose() As Boolean Implements Edition.OnClose
        Return True
    End Function

    Public Sub OnClickUpgrade() Implements psEditor.Edition.OnClickUpgrade

    End Sub

    Public Function Compile() As Boolean Implements psEditor.Edition.Compile
        Try
            If Packager.Package() Then
                Try
                    Process.Start(Packager.OutputFolder)
                Catch
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & GetString("proEd_CannotCompileErrorMessage"), "JumpCraft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function getCompileConstant() As Boolean Implements psEditor.Edition.getCompileConstant
        Return True
    End Function

    Public Function getCompilePtr() As Boolean Implements psEditor.Edition.getCompilePtr
        Return getCompileConstant()
    End Function

    Public Function ReachedMaximumLevel() As Boolean Implements psEditor.Edition.ReachedMaximumLevel
        Return False
    End Function

    Public Function ReachedMaximumWindow() As Boolean Implements psEditor.Edition.ReachedMaximumWindow
        Return False
    End Function

    Public Function ReachedMaximumTile() As Boolean Implements psEditor.Edition.ReachedMaximumTile
        Return False
    End Function

    Public Function CheckCanSave(ByVal QuietUpgrade As Boolean) As Boolean Implements psEditor.Edition.CheckCanSave
        Return True
    End Function

    Public Function RequireUsernameAndPassword() As Boolean Implements psEditor.Edition.RequireUsernameAndPassword
        Return True
    End Function

    Public Function SplashFile() As String Implements psEditor.Edition.SplashFile
        Return mySplashFile
    End Function

    Public Function UpdatePath() As String Implements psEditor.Edition.UpdatePath
        Return myUpdatePath
    End Function
End Class
