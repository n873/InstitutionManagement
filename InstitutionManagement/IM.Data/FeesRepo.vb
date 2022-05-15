Imports System.Data
Imports System.Data.OleDb
Imports Domain.InstitutionManagement.Domain

Namespace InstitutionManagement.Data
    Public Class FeesRepo
        Private ReadOnly _connection As OleDbConnection
        Private Const _commandFieldNames As String = "(ID, StudentID, PaymentType, FeesDay, FeesMonth, FeesYear, FeesAmount)"
        Private Const _commandParameterValues As String = "(@ID, @StudentID, @PaymentType, @FeesDay, @FeesMonth, @FeesYear, @FeesAmount)"

        Public Sub New(connectionString As String)
            _connection = New OleDbConnection(connectionString)
            _connection.Open()
        End Sub

        Public Sub UpdateFees(fees As Fees)
            Try
                ExecuteOleDbCommand($"UPDATE Fees SET {_commandFieldNames} VALUES {_commandParameterValues} WHERE ID = @ID", fees)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DeleteFees(fees As Fees)
            Try
                ExecuteOleDbCommand($"DELETE FROM Fees WHERE ID = @ID", fees)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub ExecuteOleDbCommand(command As String, fees As Fees)
            Try
                Dim cm = New OleDbCommand
                With cm
                    .Connection = _connection
                    .CommandType = CommandType.Text
                    .CommandText = command

                    .Parameters.Add(New OleDbParameter("@ID", OleDbType.VarChar, 255, fees.ID))
                    .Parameters.Add(New OleDbParameter("@StudentID", OleDbType.VarChar, 255, fees.StudentId))
                    .Parameters.Add(New OleDbParameter("@PaymentType", OleDbType.VarChar, 255, fees.PaymentType))
                    .Parameters.Add(New OleDbParameter("@FeesDay", OleDbType.VarChar, 255, fees.Day))
                    .Parameters.Add(New OleDbParameter("@FeesMonth", OleDbType.VarChar, 255, fees.Month))
                    .Parameters.Add(New OleDbParameter("@FeesYear", OleDbType.VarChar, 255, fees.Year))
                    .Parameters.Add(New OleDbParameter("@FeesAmount", OleDbType.VarChar, 255, fees.Amount))

                    cm.Parameters("@FeesID").Value = fees.ID
                    cm.Parameters("@StudentID").Value = fees.StudentId
                    cm.Parameters("@PaymentType").Value = fees.PaymentType
                    cm.Parameters("@FeesDate").Value = fees.Day
                    cm.Parameters("@FeesMonth").Value = fees.Month
                    cm.Parameters("@FeesYear").Value = fees.Year
                    cm.Parameters("@FeesAmount").Value = fees.Amount

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