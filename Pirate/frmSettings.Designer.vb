<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbDownloads = New System.Windows.Forms.TabPage()
        Me.chkOverwrite = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkDontAskDir = New System.Windows.Forms.CheckBox()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAuthentication = New System.Windows.Forms.TabPage()
        Me.lbLoggedInAs = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lbPassword = New System.Windows.Forms.Label()
        Me.lbUsername = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.tbAbout = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.fbdDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.versionLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tbDownloads.SuspendLayout()
        Me.tbAuthentication.SuspendLayout()
        Me.tbAbout.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbDownloads)
        Me.TabControl1.Controls.Add(Me.tbAuthentication)
        Me.TabControl1.Controls.Add(Me.tbAbout)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(437, 202)
        Me.TabControl1.TabIndex = 0
        '
        'tbDownloads
        '
        Me.tbDownloads.Controls.Add(Me.chkOverwrite)
        Me.tbDownloads.Controls.Add(Me.btnBrowse)
        Me.tbDownloads.Controls.Add(Me.chkDontAskDir)
        Me.tbDownloads.Controls.Add(Me.txtDir)
        Me.tbDownloads.Controls.Add(Me.Label1)
        Me.tbDownloads.Location = New System.Drawing.Point(4, 22)
        Me.tbDownloads.Name = "tbDownloads"
        Me.tbDownloads.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDownloads.Size = New System.Drawing.Size(429, 176)
        Me.tbDownloads.TabIndex = 0
        Me.tbDownloads.Text = "Downloads"
        Me.tbDownloads.UseVisualStyleBackColor = True
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(10, 73)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(169, 17)
        Me.chkOverwrite.TabIndex = 7
        Me.chkOverwrite.Text = "Overwrite file if it already exists"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(273, 22)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = "Browse.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkDontAskDir
        '
        Me.chkDontAskDir.AutoSize = True
        Me.chkDontAskDir.Location = New System.Drawing.Point(10, 50)
        Me.chkDontAskDir.Name = "chkDontAskDir"
        Me.chkDontAskDir.Size = New System.Drawing.Size(257, 17)
        Me.chkDontAskDir.TabIndex = 5
        Me.chkDontAskDir.Text = "Don't ask for directory every time, just save them!"
        Me.chkDontAskDir.UseVisualStyleBackColor = True
        '
        'txtDir
        '
        Me.txtDir.Location = New System.Drawing.Point(10, 24)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.ReadOnly = True
        Me.txtDir.Size = New System.Drawing.Size(257, 20)
        Me.txtDir.TabIndex = 4
        Me.txtDir.Text = "C:\"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "The default directory for downloads is:"
        '
        'tbAuthentication
        '
        Me.tbAuthentication.Controls.Add(Me.lbLoggedInAs)
        Me.tbAuthentication.Controls.Add(Me.btnLogin)
        Me.tbAuthentication.Controls.Add(Me.lbPassword)
        Me.tbAuthentication.Controls.Add(Me.lbUsername)
        Me.tbAuthentication.Controls.Add(Me.txtPassword)
        Me.tbAuthentication.Controls.Add(Me.txtUsername)
        Me.tbAuthentication.Location = New System.Drawing.Point(4, 22)
        Me.tbAuthentication.Name = "tbAuthentication"
        Me.tbAuthentication.Size = New System.Drawing.Size(429, 176)
        Me.tbAuthentication.TabIndex = 2
        Me.tbAuthentication.Text = "Authentication"
        Me.tbAuthentication.UseVisualStyleBackColor = True
        '
        'lbLoggedInAs
        '
        Me.lbLoggedInAs.AutoSize = True
        Me.lbLoggedInAs.Location = New System.Drawing.Point(7, 42)
        Me.lbLoggedInAs.Name = "lbLoggedInAs"
        Me.lbLoggedInAs.Size = New System.Drawing.Size(94, 13)
        Me.lbLoggedInAs.TabIndex = 13
        Me.lbLoggedInAs.Text = "Logged in as: N/A"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(71, 66)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 12
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lbPassword
        '
        Me.lbPassword.AutoSize = True
        Me.lbPassword.Location = New System.Drawing.Point(7, 42)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(56, 13)
        Me.lbPassword.TabIndex = 5
        Me.lbPassword.Text = "Password:"
        '
        'lbUsername
        '
        Me.lbUsername.AutoSize = True
        Me.lbUsername.Location = New System.Drawing.Point(7, 16)
        Me.lbUsername.Name = "lbUsername"
        Me.lbUsername.Size = New System.Drawing.Size(58, 13)
        Me.lbUsername.TabIndex = 4
        Me.lbUsername.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(71, 39)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(71, 13)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(120, 20)
        Me.txtUsername.TabIndex = 2
        '
        'tbAbout
        '
        Me.tbAbout.Controls.Add(Me.TextBox1)
        Me.tbAbout.Location = New System.Drawing.Point(4, 22)
        Me.tbAbout.Name = "tbAbout"
        Me.tbAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAbout.Size = New System.Drawing.Size(429, 176)
        Me.tbAbout.TabIndex = 1
        Me.tbAbout.Text = "About"
        Me.tbAbout.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 6)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(417, 164)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'fbdDialog
        '
        Me.fbdDialog.SelectedPath = "C:\"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(342, 220)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'versionLabel
        '
        Me.versionLabel.AutoSize = True
        Me.versionLabel.Enabled = False
        Me.versionLabel.Location = New System.Drawing.Point(12, 225)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(81, 13)
        Me.versionLabel.TabIndex = 2
        Me.versionLabel.Text = "Version: 0.0.0.0"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 252)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.tbDownloads.ResumeLayout(False)
        Me.tbDownloads.PerformLayout()
        Me.tbAuthentication.ResumeLayout(False)
        Me.tbAuthentication.PerformLayout()
        Me.tbAbout.ResumeLayout(False)
        Me.tbAbout.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbDownloads As System.Windows.Forms.TabPage
    Friend WithEvents tbAbout As System.Windows.Forms.TabPage
    Friend WithEvents chkDontAskDir As System.Windows.Forms.CheckBox
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents fbdDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents tbAuthentication As System.Windows.Forms.TabPage
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents lbUsername As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lbLoggedInAs As System.Windows.Forms.Label
End Class
