Namespace InstitutionManagement.Domain
    Public Class Employee
        Public Property ID As Integer
        Public Property Title As String
        Public Property PersonalDetails As Common.PersonalDetails
        Public Property AddreessDetails As Common.AddressDetails
        Public Property MobileNumber As String
        Public Property PhoneNumber As String
        Public Property EmailId As String
        Public Property EmployeeDesignation As String
        Public Property EmployeeType As String
        Public Property Salary As Double
    End Class

    Public Class EmployeeUtility
        Function GetEmployee(id As Integer) As Employee
            Dim employee As New Employee

            Return employee
        End Function

        Function AddEmployee(employee As Employee) As Boolean
            Return True
        End Function

        Function UpdateEmployee(employee As Employee) As Boolean
            Return True
        End Function

        Function DeleteEmployee(id As Integer) As Boolean
            Return True
        End Function
    End Class
End Namespace