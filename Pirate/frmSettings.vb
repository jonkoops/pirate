Public Class FrmSettings

    Private _isLoaded As Boolean = False

    Private Sub ToggleLogin()
        If Manager.Music.IsLoggedIn Then
            btnLogin.Text = "Log out"
            lbUsername.Visible = False
            lbPassword.Visible = False
            txtUsername.Visible = False
            txtPassword.Visible = False
            lbLoggedInAs.Visible = True
            lbLoggedInAs.Text = "Logged in as: " & My.Settings.AuthUser
        Else
            btnLogin.Text = "Login"
            lbUsername.Visible = True
            lbPassword.Visible = True
            txtUsername.Visible = True
            txtPassword.Visible = True
            lbLoggedInAs.Text = "Logged in as: N/A"
            lbLoggedInAs.Visible = False
        End If
    End Sub

#Region "Form events"

    Private Sub frmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.DownloadDir.Length < 3 Then My.Settings.DownloadDir = "C:\"
        txtDir.Text = My.Settings.DownloadDir
        chkDontAskDir.Checked = My.Settings.JustDownload
        chkOverwrite.Checked = My.Settings.OverwriteFile
        txtUsername.Text = My.Settings.AuthUser
        txtPassword.Text = My.Settings.AuthPass

        versionLabel.Text = "Version: " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString

        ToggleLogin()

        _isLoaded = True
    End Sub

#End Region

#Region "Authentication"

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("https://vk.com")
    End Sub

#End Region

#Region "Downloads"

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        fbdDialog.SelectedPath = txtDir.Text
        fbdDialog.ShowDialog()
        txtDir.Text = fbdDialog.SelectedPath
        SaveDownloadSettings()
    End Sub

    Private Sub chkOverwrite_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOverwrite.CheckedChanged
        SaveDownloadSettings()
    End Sub

    Private Sub chkDontAskDir_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDontAskDir.CheckedChanged
        SaveDownloadSettings()
    End Sub

    Private Sub SaveDownloadSettings()
        If Not _isLoaded Then Exit Sub
        If Not txtDir.Text.EndsWith("\") Then txtDir.Text = txtDir.Text & "\"
        My.Settings.DownloadDir = txtDir.Text
        My.Settings.JustDownload = chkDontAskDir.Checked
        My.Settings.OverwriteFile = chkOverwrite.Checked
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SaveDownloadSettings()
        Me.Close()
    End Sub

#End Region

    Private Sub frmSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        SaveDownloadSettings()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Manager.Music.IsLoggedIn Then
            Manager.Music.ResetSession()
        Else
            Try
                Manager.Music.Login(txtUsername.Text, txtPassword.Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        ToggleLogin()
    End Sub
End Class