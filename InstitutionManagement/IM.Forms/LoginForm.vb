Imports Domain.InstitutionManagement.Auth

Public Class LoginForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
