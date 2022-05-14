Namespace InstitutionManagement.Domain
    Public Class Salary
        Public Property ID As Integer
        Public Property Month As Common.Month
        Public Property EmployeeId As Integer
        Public Property IsPaid As Boolean
        Public Property Amount As Double
        Public Property DueAmount As Double
        Public Property SalaryDate As Date
    End Class

    Public Class SalaryUtility
        Function GetSalary(id As Integer) As Salary
            Dim salary As New Salary

            Return salary
        End Function

        Function GetSalaries(salaryDate As Date) As List(Of Salary)
            Dim salaries As New List(Of Salary)

            Return salaries
        End Function

        Function AddSalary(salary As Salary) As Boolean
            Return True
        End Function

        Function UpdateSalary(salary As Salary) As Boolean
            Return True
        End Function

        Function DeleteSalary(id As Integer) As Boolean
            Return True
        End Function
    End Class
End Namespace