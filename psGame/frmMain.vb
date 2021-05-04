Imports PlatformStudio
Imports PlatformStudio.GamePlayer

Public Class frmMain
    Inherits GamePlayer.MainForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Overrides Sub DoClose()
        Try
            GamePlayer.Game.Drawing.SetDialogBoxesEnabled(False)
        Catch
        End Try
        GamePlayer.Game.Drawing.SetDeviceEqualsNothing()
        Me.Visible = False

        'Only difference between psGame.frmMain and psTest.frmMain
        Process.Start(EXEFile, """" & Application.StartupPath & """")

        End
    End Sub
End Class
