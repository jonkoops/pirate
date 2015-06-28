<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbVkontakte = New System.Windows.Forms.LinkLabel()
        Me.lbPassword = New System.Windows.Forms.Label()
        Me.lbUsername = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(126, 64)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 23
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(305, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "A vkontakte account is necessary for the functionality of Pirate."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(204, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "to create one."
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(149, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Click "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Don't have an account yet?"
        '
        'lbVkontakte
        '
        Me.lbVkontakte.AutoSize = True
        Me.lbVkontakte.Location = New System.Drawing.Point(177, 117)
        Me.lbVkontakte.Name = "lbVkontakte"
        Me.lbVkontakte.Size = New System.Drawing.Size(28, 13)
        Me.lbVkontakte.TabIndex = 18
        Me.lbVkontakte.TabStop = True
        Me.lbVkontakte.Text = "here"
        '
        'lbPassword
        '
        Me.lbPassword.AutoSize = True
        Me.lbPassword.Location = New System.Drawing.Point(62, 41)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(56, 13)
        Me.lbPassword.TabIndex = 17
        Me.lbPassword.Text = "Password:"
        '
        'lbUsername
        '
        Me.lbUsername.AutoSize = True
        Me.lbUsername.Location = New System.Drawing.Point(62, 15)
        Me.lbUsername.Name = "lbUsername"
        Me.lbUsername.Size = New System.Drawing.Size(58, 13)
        Me.lbUsername.TabIndex = 16
        Me.lbUsername.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(126, 38)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtPassword.TabIndex = 15
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(126, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(120, 20)
        Me.txtUsername.TabIndex = 14
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 143)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbVkontakte)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.lbUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authentication"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbVkontakte As System.Windows.Forms.LinkLabel
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents lbUsername As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
End Class
