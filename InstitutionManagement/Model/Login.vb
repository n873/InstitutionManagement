Namespace InstitutionManagement.Auth
    Public Class Login
        Public Property Id() As Integer
        Public Property Username() As String
        Public Property Password() As String
        Public Property Type() As AuthLevel
    End Class

    Public Class Common
        Public Const AuthErrorTitle As String = "Not Authorised"
        Public Const AuthErrorMessage As String = "You are not allowed to perform this action, please contact your administrator for assistance"
    End Class


    Public Enum AuthLevel
        Student
        Admin
        Employee
    End Enum
End Namespace