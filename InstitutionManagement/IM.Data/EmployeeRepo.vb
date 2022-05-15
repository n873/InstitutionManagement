Imports System.Data
Imports System.Data.OleDb
Imports Domain.InstitutionManagement.Domain

Namespace InstitutionManagement.Data
    Public Class EmployeeRepo
        Private ReadOnly _connection As OleDbConnection
        Private Const _commandFieldNames As String = "(ID, EmployeeTitle, EmployeeFirstName, EmployeeLastName, DateOfBirth, LocalAddress, PermanentAddress, MobileNumber, PhoneNumber, EmailID, EmployeeDesignation, EmployeeType, Salary)"
        Private Const _commandParameterValues As String = "(@ID, @EmployeeTitle, @EmployeeFirstName, @EmployeeLastName, @DateOfBirth, @LocalAddress, @PermanentAddress, @MobileNumber, @PhoneNumber, @EmailID, @EmployeeDesignation, @EmployeeType, @Salary)"

        Public Sub New(connectionString As String)
            _connection = New OleDbConnection(connectionString)
            _connection.Open()
        End Sub

        Public Sub UpdateEmployee(employee As Employee)
            Try
                ExecuteOleDbCommand($"UPDATE Employee SET {_commandFieldNames} VALUES {_commandParameterValues} WHERE ID = @ID", employee)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DeleteEmployee(employee As Employee)
            Try
                ExecuteOleDbCommand($"DELETE From Employee WHERE ID = @ID", employee)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub ExecuteOleDbCommand(command As String, employee As Employee)
            Try
                Dim cm = New OleDbCommand
                With cm
                    .Connection = _connection
                    .CommandType = CommandType.Text
                    .CommandText = command

                    .Parameters.Add(New OleDbParameter("@ID", OleDbType.VarChar, 255, employee.ID))
                    .Parameters.Add(New OleDbParameter("@EmployeeTitle", OleDbType.VarChar, 255, employee.Title))
                    .Parameters.Add(New OleDbParameter("@EmployeeFirstName", OleDbType.VarChar, 255, employee.PersonalDetails.FirstName))
                    .Parameters.Add(New OleDbParameter("@EmployeeLastName", OleDbType.VarChar, 255, employee.PersonalDetails.LastName))
                    .Parameters.Add(New OleDbParameter("@DateOfBirth", OleDbType.VarChar, 255, employee.PersonalDetails.DateOfBirth))
                    .Parameters.Add(New OleDbParameter("@LocalAddress", OleDbType.VarChar, 255, employee.AddreessDetails.LocalAddress))
                    .Parameters.Add(New OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255, employee.AddreessDetails.PermanentAddress))
                    .Parameters.Add(New OleDbParameter("@MobileNumber", OleDbType.VarChar, 255, employee.MobileNumber))
                    .Parameters.Add(New OleDbParameter("@PhoneNumber", OleDbType.VarChar, 255, employee.PhoneNumber))
                    .Parameters.Add(New OleDbParameter("@EmailID", OleDbType.VarChar, 255, employee.EmailId))
                    .Parameters.Add(New OleDbParameter("@EmployeeDesignation", OleDbType.VarChar, 255, employee.EmployeeDesignation))
                    .Parameters.Add(New OleDbParameter("@EmployeeType", OleDbType.VarChar, 255, employee.EmployeeType))
                    .Parameters.Add(New OleDbParameter("@Salary", OleDbType.VarChar, 255, employee.Salary))

                    cm.Parameters("@ID").Value = employee.ID
                    cm.Parameters("@EmployeeTitle").Value = employee.Title
                    cm.Parameters("@EmployeeFirstName").Value = employee.PersonalDetails.FirstName
                    cm.Parameters("@EmployeeLastName").Value = employee.PersonalDetails.LastName
                    cm.Parameters("@DateOfBirth").Value = employee.PersonalDetails.DateOfBirth
                    cm.Parameters("@LocalAddress").Value = employee.AddreessDetails.LocalAddress
                    cm.Parameters("@PermanentAddress").Value = employee.AddreessDetails.PermanentAddress
                    cm.Parameters("@MobileNumber").Value = employee.MobileNumber
                    cm.Parameters("@PhoneNumber").Value = employee.PhoneNumber
                    cm.Parameters("@EmailID").Value = employee.EmailId
                    cm.Parameters("@EmployeeDesignation").Value = employee.EmployeeDesignation
                    cm.Parameters("@EmployeeType").Value = employee.EmployeeType
                    cm.Parameters("@Salary").Value = employee.Salary

                    cm.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            _connection.Close()
        End Sub
    End Class
End Namespace