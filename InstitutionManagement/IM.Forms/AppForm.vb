Imports Domain.InstitutionManagement.Auth
Imports Domain.InstitutionManagement.Domain
Imports Domain.InstitutionManagement.Domain.Common
Imports IM.Data.InstitutionManagement.Data

Public Class AppForm
    Public Property _login() As Login
    Private Property _connectionString As String
    Private Property _studentRepo() As StudentRepo
    Private Property _employeeRepo() As EmployeeRepo
    Private Property _feesRepo() As FeesRepo
    Private Property _courseRepo() As CourseRepo

    Public Sub New(login As Login)
        _login = login

        'Fetch this(encrypted) from a config file and decrypt
        _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\IM\InstitutionManagementDB.accdb'"

        InitializeComponent()
        _studentRepo = New StudentRepo(_connectionString)
        _employeeRepo = New EmployeeRepo(_connectionString)
        _feesRepo = New FeesRepo(_connectionString)
        _courseRepo = New CourseRepo(_connectionString)
    End Sub

    Private Function GetStudentFormInput() As Student
        Dim student As New Student With {
            .PersonalDetails = New PersonalDetails,
            .AddressDetails = New AddressDetails,
            .ID = studentIdTxt.Text
        }
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
            Case Student.Male
                student.Gender = Gender.Male
            Case Student.Female
                student.Gender = Gender.Female
            Case Else
                student.Gender = Gender.Other
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

    Private Function GetEmployeeFormInput() As Employee
        Dim employee As New Employee
        employee.PersonalDetails = New PersonalDetails
        employee.AddreessDetails = New AddressDetails

        employee.ID = employeeIDTxt.Text
        employee.Title = employeeTitleTxt.Text
        employee.PersonalDetails.FirstName = employeeFirstNameTxt.Text
        employee.PersonalDetails.LastName = employeeLastNameTxt.Text
        employee.PersonalDetails.DateOfBirth = employeeDOBTxt.Text
        employee.AddreessDetails.LocalAddress = employeeLocalAddressTxt.Text
        employee.AddreessDetails.PermanentAddress = employeePersonalAddressTxt.Text
        employee.MobileNumber = employeeMobileNumberTxt.Text
        employee.PhoneNumber = employeePhoneNumberTxt.Text
        employee.EmailId = employeeEmailIDTxt.Text
        employee.EmployeeDesignation = employeeDesignationTxt.Text
        employee.EmployeeType = employeeTypeTxt.Text
        employee.Salary = employeeSalaryTxt.Text

        Return employee
    End Function

    Private Sub ClearEmployeeForm()
        employeeTitleTxt.Text = ""
        employeeFirstNameTxt.Text = ""
        employeeLastNameTxt.Text = ""
        employeeDOBTxt.Text = ""
        employeeLocalAddressTxt.Text = ""
        employeePersonalAddressTxt.Text = ""
        employeeMobileNumberTxt.Text = ""
        employeePhoneNumberTxt.Text = ""
        employeeEmailIDTxt.Text = ""
        employeeDesignationTxt.Text = ""
        employeeTypeTxt.Text = ""
        employeeSalaryTxt.Text = ""
    End Sub

    Private Function GetFeesFormInput() As Fees
        Dim fees As Fees = New Fees
        fees.ID = feesIDTxt.Text
        fees.StudentId = studentIdTxt.Text
        fees.PaymentType = feesPaymentTypeTxt.Text
        fees.Day = feesDateTxt.Text
        fees.Month = feesMonthTxt.Text
        fees.Year = feesYearTxt.Text
        fees.Amount = feesAmountTxt.Text

        Return fees

    End Function

    Private Sub ClearFeesForm()
        feesIDTxt.Text = ""
        feesPaymentTypeTxt.Text = ""
        feesDateTxt.Text = ""
        feesMonthTxt.Text = ""
        feesYearTxt.Text = ""
        feesAmountTxt.Text = ""
    End Sub

    Private Function GetCourseFormInput() As Course
        Dim course As Course = New Course
        course.ID = courseIDTxt.Text
        course.Title = courseTitleTxt.Text
        course.Name = courseNameTxt.Text
        course.Duration = courseDurationTxt.Text
        course.Fee = courseFeeTxt.Text
        course.Code = courseCodeTxt.Text
        Return course
    End Function

    Private Sub ClearCourseForm()
        courseIDTxt.Text = ""
        courseNameTxt.Text = ""
        courseTitleTxt.Text = ""
        courseFeeTxt.Text = ""
        courseDurationTxt.Text = ""
        courseCodeTxt.Text = ""
    End Sub

    Private Sub studentSubmitBtn_Click(sender As Object, e As EventArgs) Handles studentSubmitBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                studentIdTxt.Text = Guid.NewGuid().ToString()

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

    Private Sub studentDeleteBtn_Click(sender As Object, e As EventArgs) Handles studentDeleteBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _studentRepo.DeleteStudent(GetStudentFormInput)

                MessageBox.Show("Record delete")
                ClearStudentForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub employeeInfo_modifyBtn_Click(sender As Object, e As EventArgs) Handles employeeInfo_modifyBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _employeeRepo.UpdateEmployee(GetEmployeeFormInput)

                MessageBox.Show("Record updated")
                ClearEmployeeForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub employeeInfo_deleteBtn_Click(sender As Object, e As EventArgs) Handles employeeInfo_deleteBtn.Click

        If _login.Type = AuthLevel.Admin Then
            Try
                _employeeRepo.DeleteEmployee(GetEmployeeFormInput)

                MessageBox.Show("Record delete")
                ClearEmployeeForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub feesStructure_modifyBtn_Click(sender As Object, e As EventArgs) Handles feesStructure_modifyBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _feesRepo.UpdateFees(GetFeesFormInput)

                MessageBox.Show("Record updated")
                ClearFeesForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub feesStructure_deleteBtn_Click(sender As Object, e As EventArgs) Handles feesStructure_deleteBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _feesRepo.DeleteFees(GetFeesFormInput)

                MessageBox.Show("Record delete")
                ClearFeesForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub courseDetails_modifyBtn_Click(sender As Object, e As EventArgs) Handles courseDetails_modifyBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _courseRepo.UpdateCourse(GetCourseFormInput)

                MessageBox.Show("Record updated")
                ClearCourseForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

    Private Sub courseDetails_deleteBtn_Click(sender As Object, e As EventArgs) Handles courseDetails_deleteBtn.Click
        If _login.Type = AuthLevel.Admin Then
            Try
                _courseRepo.DeleteCourse(GetCourseFormInput)

                MessageBox.Show("Record delete")
                ClearCourseForm()
            Catch ex As Exception
                MessageBox.Show(CommonMessage.ExceptionTitle, $"{CommonMessage.ExceptionMessage} - {ex.Message}")
            End Try
        Else
            MessageBox.Show(Common.AuthErrorTitle, Common.AuthErrorMessage)
        End If
    End Sub

End Class