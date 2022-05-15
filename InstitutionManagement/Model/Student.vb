Namespace InstitutionManagement.Domain
    Public Enum Category
        Placeholder
    End Enum

    Public Class Student
        Public Const Male As String = "Male"
        Public Const Female As String = "Female"
        Public Const Other As String = "Other"

        Public Property ID As Integer
        Public Property PersonalDetails As Common.PersonalDetails
        Public Property AddressDetails As Common.AddressDetails
        Public Property MothersName As String
        Public Property FathersName As String
        Public Property BloodGroup As String
        Public Property Gender As Common.Gender
        Public Property Category As Category
        Public Property EmailId As String
        Public Property ContactNumber As String
    End Class
End Namespace