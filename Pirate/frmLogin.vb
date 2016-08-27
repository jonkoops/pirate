Public Class frmLogin

    Private Sub lbVkontakte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbVkontakte.LinkClicked
        System.Diagnostics.Process.Start("https://vk.com")
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Manager.Music.Login(txtUsername.Text, txtPassword.Text)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If (Not Manager.Music.IsLoggedIn) Then
            Environment.Exit(0)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetLoginButtonStatus()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        SetLoginButtonStatus()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        SetLoginButtonStatus()
    End Sub

    Private Sub SetLoginButtonStatus()
        btnLogin.Enabled = Not String.IsNullOrWhiteSpace(txtUsername.Text) AndAlso Not String.IsNullOrWhiteSpace(txtPassword.Text)
    End Sub

End Class