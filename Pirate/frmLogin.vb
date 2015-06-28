Public Class frmLogin

    Private Sub lbVkontakte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbVkontakte.LinkClicked
        System.Diagnostics.Process.Start("https://vk.com")
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Manager.Music.Login(txtUsername.Text, txtPassword.Text)

        If (Manager.Music.IsLoggedIn) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If (Not Manager.Music.IsLoggedIn) Then
            Environment.Exit(0)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class