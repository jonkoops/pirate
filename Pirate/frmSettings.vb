Public Class frmSettings

    Private isLoaded As Boolean = False
    Private frmMain As frmMain = Nothing

#Region "Form events"

    Public Sub SetParentForm(ByVal frmMain As frmMain)
        Me.frmMain = frmMain
    End Sub

    Private Sub frmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.DownloadDir.Length < 3 Then My.Settings.DownloadDir = "C:\"
        txtDir.Text = My.Settings.DownloadDir
        chkDontAskDir.Checked = My.Settings.JustDownload
        chkOverwrite.Checked = My.Settings.OverwriteFile

        rbtnDefaultLogin.Checked = Not My.Settings.AuthCustom
        rbtnCustomLogin.Checked = My.Settings.AuthCustom
        txtUsername.Enabled = My.Settings.AuthCustom
        txtPassword.Enabled = My.Settings.AuthCustom
        txtUsername.Text = My.Settings.AuthUser
        txtPassword.Text = My.Settings.AuthPass

        versionLabel.Text = "Version: " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString

        isLoaded = True
    End Sub

#End Region

#Region "Authentication"

    Private Sub rbtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDefaultLogin.CheckedChanged, rbtnCustomLogin.CheckedChanged
        txtUsername.Enabled = rbtnCustomLogin.Checked
        txtPassword.Enabled = rbtnCustomLogin.Checked
        SaveAuthenticationSettings()
    End Sub

    Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged, txtPassword.TextChanged
        SaveAuthenticationSettings()
    End Sub

    Private Sub SaveAuthenticationSettings()
        If Not isLoaded Then Exit Sub

        If (Not frmMain Is Nothing) Then
            frmMain.music.ResetGuid()
        End If

        My.Settings.AuthCustom = rbtnCustomLogin.Checked
        My.Settings.AuthUser = If(rbtnCustomLogin.Checked, txtUsername.Text, "")
        My.Settings.AuthPass = If(rbtnCustomLogin.Checked, txtPassword.Text, "")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbVkontakte.LinkClicked
        System.Diagnostics.Process.Start("http://vkontakte.ru/")
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
        If Not isLoaded Then Exit Sub
        If Not txtDir.Text.EndsWith("\") Then txtDir.Text = txtDir.Text & "\"
        My.Settings.DownloadDir = txtDir.Text
        My.Settings.JustDownload = chkDontAskDir.Checked
        My.Settings.OverwriteFile = chkOverwrite.Checked
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SaveDownloadSettings()
        SaveAuthenticationSettings()
        Me.Close()
    End Sub

#End Region

End Class