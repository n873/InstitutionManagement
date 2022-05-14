Namespace InstitutionManagement.Domain
    Public Class Course
        Public Property ID As String
        Public Property Title As String
        Public Property Name As String
        Public Property Code As String
        Public Property Fee As String
        Public Property Duration As String
    End Class

    Public Class CourseUtility
        Function GetCourse(id As Integer) As Course
            Dim course As New Course

            Return course
        End Function

        Function AddCourse(course As Course) As Boolean
            Return True
        End Function

        Function UpdateCourse(course As Course) As Boolean
            Return True
        End Function

        Function DeleteCourse(id As Integer) As Boolean
            Return True
        End Function
    End Class
End Namespace