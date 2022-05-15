Imports Domain.InstitutionManagement.Auth

Public Class LoginForm
    Private Property _connectionString As String
    Private Property _loginRepo As LoginRepo

    Public Sub New()
        'Fetch this(encrypted) from a config file and decrypt
        _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\IM\InstitutionManagementDB.accdb'"

        InitializeComponent()
        _loginRepo = New LoginRepo(_connectionString)
    End Sub

    Private Sub okBtn_Click(sender As Object, e As EventArgs) Handles okBtn.Click
        Dim login = New Login
        login.Username = "test"
        login.Password = "test"
        login.Type = AuthLevel.Admin


        Dim appForm = New AppForm(login)
        appForm.ShowDialog()
        Me.Close()
    End Sub
End Class
