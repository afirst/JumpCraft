Imports PlatformStudio

Public Class psControlProperties
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Public WithEvents prop As FlatPropGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.prop = New FlatPropGrid
        Me.SuspendLayout()
        '
        'prop
        '
        Me.prop.CommandsVisibleIfAvailable = True
        Me.prop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prop.LargeButtons = False
        Me.prop.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.prop.Location = New System.Drawing.Point(0, 0)
        Me.prop.Name = "prop"
        Me.prop.Size = New System.Drawing.Size(150, 150)
        Me.prop.TabIndex = 0
        Me.prop.Text = "PropertyGrid1"
        Me.prop.ViewBackColor = System.Drawing.SystemColors.Window
        Me.prop.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'psControlProperties
        '
        Me.Controls.Add(Me.prop)
        Me.Name = "psControlProperties"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Event PropertyValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs)

    Public UndoType As UndoRedo.UndoType = UndoRedo.UndoType.Windows

    Public Class FlatPropGrid
        Inherits PropertyGrid

        Sub New()
            MyBase.New()
            DrawFlatToolbar = True
        End Sub
    End Class

    Private x As Boolean
    Private Sub prop_PropertyValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles prop.PropertyValueChanged
        RaiseEvent PropertyValueChanged(sender, e)
    End Sub
End Class