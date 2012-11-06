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
        Me.lbVkontakte = New System.Windows.Forms.LinkLabel()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.rbtnCustomLogin = New System.Windows.Forms.RadioButton()
        Me.rbtnDefaultLogin = New System.Windows.Forms.RadioButton()
        Me.tbAbout = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.fbdDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnClose = New System.Windows.Forms.Button()
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
        Me.tbAuthentication.Controls.Add(Me.lbVkontakte)
        Me.tbAuthentication.Controls.Add(Me.lblLogin)
        Me.tbAuthentication.Controls.Add(Me.Label4)
        Me.tbAuthentication.Controls.Add(Me.Label3)
        Me.tbAuthentication.Controls.Add(Me.txtPassword)
        Me.tbAuthentication.Controls.Add(Me.txtUsername)
        Me.tbAuthentication.Controls.Add(Me.rbtnCustomLogin)
        Me.tbAuthentication.Controls.Add(Me.rbtnDefaultLogin)
        Me.tbAuthentication.Location = New System.Drawing.Point(4, 22)
        Me.tbAuthentication.Name = "tbAuthentication"
        Me.tbAuthentication.Size = New System.Drawing.Size(429, 176)
        Me.tbAuthentication.TabIndex = 2
        Me.tbAuthentication.Text = "Authentication"
        Me.tbAuthentication.UseVisualStyleBackColor = True
        '
        'lbVkontakte
        '
        Me.lbVkontakte.AutoSize = True
        Me.lbVkontakte.Location = New System.Drawing.Point(320, 153)
        Me.lbVkontakte.Name = "lbVkontakte"
        Me.lbVkontakte.Size = New System.Drawing.Size(28, 13)
        Me.lbVkontakte.TabIndex = 7
        Me.lbVkontakte.TabStop = True
        Me.lbVkontakte.Text = "here"
        '
        'lblLogin
        '
        Me.lblLogin.Location = New System.Drawing.Point(8, 140)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(418, 29)
        Me.lblLogin.TabIndex = 6
        Me.lblLogin.Text = "Using the default login for vkontakte is not always a secure function. To ensure " & _
            "accessibility for the functionality, you should create your own login         ."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(98, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(98, 49)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 2
        '
        'rbtnCustomLogin
        '
        Me.rbtnCustomLogin.AutoSize = True
        Me.rbtnCustomLogin.Location = New System.Drawing.Point(11, 26)
        Me.rbtnCustomLogin.Name = "rbtnCustomLogin"
        Me.rbtnCustomLogin.Size = New System.Drawing.Size(160, 17)
        Me.rbtnCustomLogin.TabIndex = 1
        Me.rbtnCustomLogin.TabStop = True
        Me.rbtnCustomLogin.Text = "Use the following credentials"
        Me.rbtnCustomLogin.UseVisualStyleBackColor = True
        '
        'rbtnDefaultLogin
        '
        Me.rbtnDefaultLogin.AutoSize = True
        Me.rbtnDefaultLogin.Location = New System.Drawing.Point(11, 7)
        Me.rbtnDefaultLogin.Name = "rbtnDefaultLogin"
        Me.rbtnDefaultLogin.Size = New System.Drawing.Size(176, 17)
        Me.rbtnDefaultLogin.TabIndex = 0
        Me.rbtnDefaultLogin.TabStop = True
        Me.rbtnDefaultLogin.Text = "Used default login for vkontakte"
        Me.rbtnDefaultLogin.UseVisualStyleBackColor = True
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
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 252)
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents rbtnCustomLogin As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnDefaultLogin As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbVkontakte As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLogin As System.Windows.Forms.Label
End Class
