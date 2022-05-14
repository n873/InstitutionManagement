<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.titleLbl = New System.Windows.Forms.Label()
        Me.loginPicbx = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.okBtn = New System.Windows.Forms.Button()
        Me.usernameText = New System.Windows.Forms.TextBox()
        Me.usernameLbl = New System.Windows.Forms.Label()
        Me.passwordText = New System.Windows.Forms.TextBox()
        Me.passwordLbl = New System.Windows.Forms.Label()
        CType(Me.loginPicbx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'titleLbl
        '
        Me.titleLbl.AutoSize = True
        Me.titleLbl.BackColor = System.Drawing.Color.DarkGray
        Me.titleLbl.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point)
        Me.titleLbl.Location = New System.Drawing.Point(184, 52)
        Me.titleLbl.Name = "titleLbl"
        Me.titleLbl.Padding = New System.Windows.Forms.Padding(60, 0, 60, 20)
        Me.titleLbl.Size = New System.Drawing.Size(743, 92)
        Me.titleLbl.TabIndex = 5
        Me.titleLbl.Text = "RGIT Automation System"
        Me.titleLbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'loginPicbx
        '
        Me.loginPicbx.Location = New System.Drawing.Point(62, 182)
        Me.loginPicbx.Name = "loginPicbx"
        Me.loginPicbx.Size = New System.Drawing.Size(248, 346)
        Me.loginPicbx.TabIndex = 6
        Me.loginPicbx.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cancelBtn)
        Me.GroupBox1.Controls.Add(Me.okBtn)
        Me.GroupBox1.Controls.Add(Me.usernameText)
        Me.GroupBox1.Controls.Add(Me.usernameLbl)
        Me.GroupBox1.Controls.Add(Me.passwordText)
        Me.GroupBox1.Controls.Add(Me.passwordLbl)
        Me.GroupBox1.Location = New System.Drawing.Point(379, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 358)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(398, 263)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(150, 46)
        Me.cancelBtn.TabIndex = 21
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'okBtn
        '
        Me.okBtn.Location = New System.Drawing.Point(155, 263)
        Me.okBtn.Name = "okBtn"
        Me.okBtn.Size = New System.Drawing.Size(150, 46)
        Me.okBtn.TabIndex = 20
        Me.okBtn.Text = "OK"
        Me.okBtn.UseVisualStyleBackColor = True
        '
        'usernameText
        '
        Me.usernameText.Location = New System.Drawing.Point(237, 80)
        Me.usernameText.Name = "usernameText"
        Me.usernameText.Size = New System.Drawing.Size(311, 39)
        Me.usernameText.TabIndex = 7
        '
        'usernameLbl
        '
        Me.usernameLbl.AutoSize = True
        Me.usernameLbl.Location = New System.Drawing.Point(69, 80)
        Me.usernameLbl.Name = "usernameLbl"
        Me.usernameLbl.Size = New System.Drawing.Size(121, 32)
        Me.usernameLbl.TabIndex = 6
        Me.usernameLbl.Text = "Username"
        '
        'passwordText
        '
        Me.passwordText.Location = New System.Drawing.Point(237, 182)
        Me.passwordText.Name = "passwordText"
        Me.passwordText.Size = New System.Drawing.Size(311, 39)
        Me.passwordText.TabIndex = 5
        '
        'passwordLbl
        '
        Me.passwordLbl.AutoSize = True
        Me.passwordLbl.Location = New System.Drawing.Point(69, 182)
        Me.passwordLbl.Name = "passwordLbl"
        Me.passwordLbl.Size = New System.Drawing.Size(111, 32)
        Me.passwordLbl.TabIndex = 4
        Me.passwordLbl.Text = "Password"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 678)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.loginPicbx)
        Me.Controls.Add(Me.titleLbl)
        Me.Name = "LoginForm"
        Me.Text = "Institution Management"
        CType(Me.loginPicbx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleLbl As Label
    Friend WithEvents loginPicbx As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents usernameText As TextBox
    Friend WithEvents usernameLbl As Label
    Friend WithEvents passwordText As TextBox
    Friend WithEvents passwordLbl As Label
    Friend WithEvents cancelBtn As Button
    Friend WithEvents okBtn As Button
End Class
