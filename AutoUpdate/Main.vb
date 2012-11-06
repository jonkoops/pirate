Imports System.IO
Imports System.Net

Module Main

    Public Sub Main()

        Dim wc As New WebClient

        Try
            ' Read parameters
            Dim args() As String = Split(Command, "|")
            Dim path As String = args(0)
            Dim version As String = args(1)
            Dim url As String = args(2)
            Dim key As String = args(3)

            ' Download the new version
            Dim didDownload As Boolean = False
            Try
                wc.DownloadFile(url, path & ".new")
                didDownload = True
            Catch ex As Exception
            End Try

            If Not didDownload Then
                MsgBox("Could not download new application", MsgBoxStyle.Exclamation, "Auto update error")
                Environment.Exit(0)
            End If

            ' Delete old file
            Dim deleted As Boolean = False
            Dim stopwatch As New Stopwatch
            stopwatch.Start()
            While Not deleted
                Try
                    File.Delete(path)
                    deleted = True
                Catch ex As Exception
                End Try
                If stopwatch.Elapsed.Seconds > 5 Then
                    stopwatch.Stop()
                    MsgBox("Could not close parent application", MsgBoxStyle.Exclamation, "Auto update error")
                    Environment.Exit(1)
                End If
            End While

            ' Move new file
            File.Move(path & ".new", path)

            ' Start new version
            System.Diagnostics.Process.Start(path, key)

        Catch ex As Exception
            MsgBox("An unknown error occured", MsgBoxStyle.Exclamation, "Auto update error")
            Environment.Exit(-1)
        End Try
    End Sub

End Module