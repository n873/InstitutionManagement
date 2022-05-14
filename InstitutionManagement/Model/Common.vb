Namespace InstitutionManagement.Domain.Common
    Public Class PersonalDetails
        Public Property FirstName As String
        Public Property MiddleName As String
        Public Property LastName As String
        Public Property DateOfBirth As Date
    End Class

    Public Class AddressDetails
        Public Property LocalAddress As String
        Public Property PermanentAddress As String
    End Class

    Public Class CommonMessage
        Public Const ExceptionTitle As String = "Something went wrong"
        Public Const ExceptionMessage As String = "Please contact support for assistance to resolve this error"
    End Class

    Public Enum Gender
        Male
        Female
        Other
    End Enum
End Namespace