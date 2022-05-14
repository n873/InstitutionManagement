Imports Domain.InstitutionManagement.Auth
Imports Domain.InstitutionManagement.Domain
Imports Domain.InstitutionManagement.Domain.Common
Imports IM.Data.InstitutionManagement.Data

Public Class AppForm
    Public Property _login() As Login
    Private Property _connectionString As String
    Private Property _studentRepo() As StudentRepo

    Public Sub New(login As Login)
        _login = login

        'Fetch this(encrypted) from a config file and decrypt
        _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\IM\InstitutionManagementDB.accdb'"

        InitializeComponent()
        _studentRepo = New StudentRepo(_connectionString)
    End Sub

    Private Sub studentSubmitBtn_Click(sender As Object, e As EventArgs) Handles studentSubmitBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _studentRepo.AddStudent(GetStudentFormInput())

                MessageBox.Show("Record saved.")
                ClearStudentForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Function GetStudentFormInput() As Student
        Dim student As New Student
        student.PersonalDetails = New PersonalDetails
        student.AddressDetails = New AddressDetails

        student.PersonalDetails.FirstName = studentFirstNameTxt.Text
        student.PersonalDetails.MiddleName = studentMiddleNameTxt.Text
        student.PersonalDetails.LastName = studentLastNameTxt.Text
        student.PersonalDetails.DateOfBirth = studentDOBDate.MaxDate
        student.AddressDetails.LocalAddress = studentLocalAddressTxt.Text
        student.AddressDetails.PermanentAddress = studentPermAddressTxt.Text
        student.MothersName = studentMothersNameTxt.Text
        student.FathersName = studentFathersNameTxt.Text
        student.BloodGroup = studentBloodGroupTxt.Text
        Select Case studentGenderDropbx.SelectedText
            Case Gender.Male
                student.Gender = Gender.Male
            Case Gender.Female
                student.Gender = Gender.Female
        End Select
        Select Case studentCategoryDropbx.SelectedText
            Case Category.Placeholder
                student.Category = Category.Placeholder
            Case Else
                student.Category = Category.Placeholder
        End Select
        student.EmailId = studentEmailIdTxt.Text
            student.ContactNumber = studentContactNumberTxt.Text

        Return student
    End Function

    Private Sub ClearStudentForm()
        studentFirstNameTxt.Text = ""
        studentMiddleNameTxt.Text = ""
        studentLastNameTxt.Text = ""
        studentDOBDate.Text = ""
        studentLocalAddressTxt.Text = ""
        studentPermAddressTxt.Text = ""
        studentMothersNameTxt.Text = ""
        studentFathersNameTxt.Text = ""
        studentBloodGroupTxt.Text = ""
        studentGenderDropbx.Text = ""
        studentCategoryDropbx.Text = ""
        studentEmailIdTxt.Text = ""
        studentContactNumberTxt.Text = ""
    End Sub

    Private Sub studentModifyBtn_Click(sender As Object, e As EventArgs) Handles studentModifyBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _studentRepo.UpdateStudent(GetStudentFormInput)

                MessageBox.Show("Record updated")
                ClearStudentForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub
End Class