Imports System.Data
Imports System.Data.OleDb
Imports Domain.InstitutionManagement.Domain

Namespace InstitutionManagement.Data
    Public Class StudentRepo
        Private ReadOnly _connection As OleDbConnection
        Private Const _commandFieldNames As String = "(ID, FirstName,MiddleName,LastName,DateOfBirth, LocalAddress, PermanentAddress, MotherName, FatherName, BloodGroup, Gender, Category, EmailID, ContactNumber)"
        Private Const _commandParameterValues As String = "(@ID, @FirstName, @MiddleName, @LastName, @DateOfBirth, @LocalAddress, @PermanentAddress, @MotherName, @FatherName, @BloodGroup, @Gender, @Category, @EmailID, @ContactNumber)"

        Public Sub New(connectionString As String)
            _connection = New OleDbConnection(connectionString)
            _connection.Open()
        End Sub

        Public Sub AddStudent(student As Student)
            Try
                ExecuteOldDbCommand($"INSERT INTO Student {_commandFieldNames} VALUES {_commandParameterValues}", student)

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub UpdateStudent(student As Student)
            Try
                ExecuteOldDbCommand($"UPDATE Student SET {_commandFieldNames} VALUES {_commandParameterValues} WHERE ID = @ID", student)

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DeleteStudent(student As Student)
            Try
                ExecuteOldDbCommand("DELETE From Student WHERE ID = @ID", student)

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub ExecuteOldDbCommand(command As String, student As Student)
            Try
                Dim cm = New OleDbCommand
                With cm
                    .Connection = _connection
                    .CommandType = CommandType.Text
                    .CommandText = command

                    .Parameters.Add(New OleDbParameter("@ID", OleDbType.VarChar, 255, student.ID))
                    .Parameters.Add(New OleDbParameter("@FirstName", OleDbType.VarChar, 255, student.PersonalDetails.FirstName))
                    .Parameters.Add(New OleDbParameter("@MiddleName", OleDbType.VarChar, 255, student.PersonalDetails.MiddleName))
                    .Parameters.Add(New OleDbParameter("@LastName", OleDbType.VarChar, 255, student.PersonalDetails.LastName))
                    .Parameters.Add(New OleDbParameter("@DateOfBirth", OleDbType.VarChar, 255, student.PersonalDetails.DateOfBirth))
                    .Parameters.Add(New OleDbParameter("@LocalAddress", OleDbType.VarChar, 255, student.AddressDetails.LocalAddress))
                    .Parameters.Add(New OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255, student.AddressDetails.PermanentAddress))
                    .Parameters.Add(New OleDbParameter("@MotherName", OleDbType.VarChar, 255, student.MothersName))
                    .Parameters.Add(New OleDbParameter("@FatherName", OleDbType.VarChar, 255, student.FathersName))
                    .Parameters.Add(New OleDbParameter("@BloodGroup", OleDbType.VarChar, 255, student.BloodGroup))
                    .Parameters.Add(New OleDbParameter("@Gender", OleDbType.VarChar, 255, student.Gender))
                    .Parameters.Add(New OleDbParameter("@Category", OleDbType.VarChar, 255, student.Category))
                    .Parameters.Add(New OleDbParameter("@EmailID", OleDbType.VarChar, 255, student.EmailId))
                    .Parameters.Add(New OleDbParameter("@ContactNumber", OleDbType.VarChar, 255, student.ContactNumber))


                    ' RUN THE COMMAND
                    cm.Parameters("@ID").Value = student.ID
                    cm.Parameters("@FirstName").Value = student.PersonalDetails.FirstName
                    cm.Parameters("@MiddleName").Value = student.PersonalDetails.MiddleName
                    cm.Parameters("@LastName").Value = student.PersonalDetails.LastName
                    cm.Parameters("@DateOfBirth").Value = student.PersonalDetails.DateOfBirth
                    cm.Parameters("@LocalAddress").Value = student.AddressDetails.LocalAddress
                    cm.Parameters("@PermanentAddress").Value = student.AddressDetails.PermanentAddress
                    cm.Parameters("@MotherName").Value = student.MothersName
                    cm.Parameters("@FatherName").Value = student.FathersName
                    cm.Parameters("@BloodGroup").Value = student.BloodGroup
                    cm.Parameters("@Gender").Value = student.Gender
                    cm.Parameters("@Category").Value = student.Category
                    cm.Parameters("@EmailID").Value = student.EmailId
                    cm.Parameters("@ContactNumber").Value = student.ContactNumber


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