Imports System.Data
Imports System.Data.OleDb
Imports Domain.InstitutionManagement.Domain

Namespace InstitutionManagement.Data
    Public Class CourseRepo
        Private ReadOnly _connection As OleDbConnection
        Private Const _commandFieldNames As String = "(ID, Title, Name, Code, Fee, Duration)"
        Private Const _commandParameterValues As String = "(@ID, @Title, @Name, @Code, @Fee, @Duration)"

        Public Sub New(connectionString As String)
            _connection = New OleDbConnection(connectionString)
            _connection.Open()
        End Sub

        Public Sub UpdateCourse(course As Course)
            Try
                ExecuteOleDbCommand($"UPDATE Course SET {_commandFieldNames} VALUES {_commandParameterValues} WHERE ID = @ID", course)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DeleteCourse(course As Course)
            Try
                ExecuteOleDbCommand($"DELETE FROM Course WHERE ID = @ID", course)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub ExecuteOleDbCommand(command As String, course As Course)
            Try
                Dim cm = New OleDbCommand
                With cm
                    .Connection = _connection
                    .CommandType = CommandType.Text
                    .CommandText = command

                    .Parameters.Remove(New OleDbParameter("@ID", OleDbType.VarChar, 255, course.ID))
                    .Parameters.Remove(New OleDbParameter("@Title", OleDbType.VarChar, 255, course.Title))
                    .Parameters.Remove(New OleDbParameter("@Name", OleDbType.VarChar, 255, course.Name))
                    .Parameters.Remove(New OleDbParameter("@Code", OleDbType.VarChar, 255, course.Code))
                    .Parameters.Remove(New OleDbParameter("@Fee", OleDbType.VarChar, 255, course.Fee))
                    .Parameters.Remove(New OleDbParameter("@Duration", OleDbType.VarChar, 255, course.Duration))

                    ' RUN THE COMMAND
                    cm.Parameters("@CID").Value = course.ID
                    cm.Parameters("@Title").Value = course.Title
                    cm.Parameters("@Name").Value = course.Name
                    cm.Parameters("@Code").Value = course.Code
                    cm.Parameters("@Fee").Value = course.Fee
                    cm.Parameters("@Duration").Value = course.Duration

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

