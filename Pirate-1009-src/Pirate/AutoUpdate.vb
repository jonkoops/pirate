Imports System.IO
Imports System.Threading

Public Class AutoUpdate

    Private Shared key As String = "pirateapp"
    Private Shared user As String = "pirateapp"

    Public Shared Function AutoUpdate() As Boolean
        Dim thread As New Thread(New ThreadStart(AddressOf AutoUpdateThread))
        thread.Start()
    End Function

    Private Shared Sub AutoUpdateThread()
        If Command.Contains(key) Then
            ' Called from auto-update
            Dim deleted As Boolean = False
            Dim stopwatch As New Stopwatch
            stopwatch.Start()
            While Not deleted
                Try
                    System.IO.File.Delete(My.Application.Info.DirectoryPath & "\AutoUpdate.exe")
                    deleted = True
                Catch ex As Exception
                End Try
                If stopwatch.Elapsed.Seconds > 5 Then
                    stopwatch.Stop()
                    MsgBox("Could not delete auto update file", MsgBoxStyle.Exclamation, "Auto update error")
                End If
            End While
        Else
            ' Called from application
            Dim onlinestring As String = GetVersion()
            If onlinestring.Contains("|") Then
                Dim onlineinfo() As String = Split(onlinestring, "|")
                Dim onlineversion As Integer = CInt(onlineinfo(0).Replace(".", ""))
                Dim thisversion As Integer = CInt(My.Application.Info.Version.ToString.Replace(".", ""))
                If onlineversion > thisversion Then
                    If MsgBox("A new version is available. Do you wish to update?", MsgBoxStyle.YesNo, "Application update") = MsgBoxResult.Yes Then
                        Dim arg As String = System.Reflection.Assembly.GetExecutingAssembly.Location & "|" & onlinestring & "|" & key
                        Dim fs As New FileStream(My.Application.Info.DirectoryPath & "\AutoUpdate.exe", FileMode.Create)
                        fs.Write(My.Resources.AutoUpdate, 0, My.Resources.AutoUpdate.Length)
                        fs.Dispose()
                        System.Diagnostics.Process.Start(My.Application.Info.DirectoryPath & "\AutoUpdate.exe", arg)
                        Application.Exit()
                    End If
                End If
            End If
        End If
    End Sub

    Private Shared Function GetVersion() As String
        Try
            Dim wc As New System.Net.WebClient
            Dim sr As New StreamReader(wc.OpenRead("http://api.twitter.com/1/users/show.xml?screen_name=" & user))
            Dim result As String = sr.ReadToEnd()
            sr.Dispose()
            wc.Dispose()
            Return TextBetween(result, "<text>", "</text>")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Shared Function TextBetween(ByVal i As String, ByVal s As String, ByVal e As String) As String
        Dim splitter() As String = Split(i, s, 2)
        splitter = Split(splitter(1), e, 2)
        Return splitter(0)
    End Function

End Class