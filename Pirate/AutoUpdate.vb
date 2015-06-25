Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GitHubApi
    Public Version As New Version("0.0.0.0")
    Public DownloadUrl As String = ""

    Public Sub New()
        Try
            Using wc As New System.Net.WebClient
                wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Safari/537.36"

                Using sr As New StreamReader(wc.OpenRead("https://api.github.com/repos/jonkoops/pirate/releases/latest"))
                    Dim result As String = sr.ReadToEnd()

                    Dim json As JObject = JObject.Parse(result)

                    Version = New Version(json.SelectToken("tag_name"))
                    DownloadUrl = json.SelectToken("assets")(0).SelectToken("browser_download_url")
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

End Class

Public Class AutoUpdate

    Private Shared key As String = "pirateapp"
    Private Shared github As New GitHubApi

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
            Dim thisVersion As Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
            If github.Version > thisVersion Then
                If MsgBox("A new version is available. Do you wish to update?", MsgBoxStyle.YesNo, "Application update") = MsgBoxResult.Yes Then
                    Dim arg As String = System.Reflection.Assembly.GetExecutingAssembly.Location & "|" & github.Version.ToString & "|" & github.DownloadUrl & "|" & key

                    Using fs As New FileStream(My.Application.Info.DirectoryPath & "\AutoUpdate.exe", FileMode.Create)
                        fs.Write(My.Resources.AutoUpdate, 0, My.Resources.AutoUpdate.Length)
                    End Using

                    System.Diagnostics.Process.Start(My.Application.Info.DirectoryPath & "\AutoUpdate.exe", arg)
                    Application.Exit()
                End If
            End If
        End If
    End Sub

End Class