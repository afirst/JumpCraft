Public Interface Edition
    Function SplashFile() As String
    Function UpdatePath() As String
    Function RequireUsernameAndPassword() As Boolean
    Sub OnLoad(ByVal f As frmGame)
    Function OnClose() As Boolean
    Sub OnClickUpgrade()
    Function Compile() As Boolean
    Function getCompileConstant() As Boolean
    Function getCompilePtr() As Boolean
    Function ReachedMaximumLevel() As Boolean
    Function ReachedMaximumWindow() As Boolean
    Function ReachedMaximumTile() As Boolean
    Function CheckCanSave(ByVal QuietUpgrade As Boolean) As Boolean
End Interface
