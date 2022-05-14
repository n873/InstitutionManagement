Namespace InstitutionManagement.Domain
    Public Class Fees
        Public Property ID As Integer
        Public Property StudentId As Integer
        Public Property Day As Integer
        Public Property Month As String
        Public Property Year As Integer
        Public Property Amount As Double
    End Class

    Public Class FeesUtility
        Function GetFees(id As Integer) As Fees
            Dim fees As New Fees

            Return fees
        End Function

        Function AddFees(fees As Fees) As Boolean
            Return True
        End Function

        Function UpdateFees(fees As Fees) As Boolean
            Return True
        End Function

        Function DeleteFees(id As Integer) As Boolean
            Return True
        End Function
    End Class
End Namespace