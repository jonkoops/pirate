Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Web

Public Class frmMain

#Region "Main variables"

    Public WithEvents music As New FreeMusic
    Private Settings As New frmSettings
    Public songs As New List(Of FreeMusic.Song)
    Delegate Sub UpdateSearchDelegate(ByVal result As List(Of FreeMusic.Song))
    Delegate Sub UpdateProgressDelegate(ByVal song As FreeMusic.Song)
    Delegate Sub UpdateDownloadDelegate(ByVal info() As String)
    Private progress As Integer = 0
    Private isMouseDown As Boolean = False
    Private progressY As Integer = 0
    Private CurrentDownloads As New ArrayList
    Private DownloadIdMax As Integer = 0
    Private didCancel As Boolean
    Private searchString As String = ""
    Private SearchIdMax As Integer = 0
    Private SongsToFetch As Integer = 0

#End Region

#Region "Data handling"

#Region "Search"

    Public Sub Search()
        If searchString <> txtSearch.Text Then
            searchString = txtSearch.Text
            Me.songs.Clear()
            tmSearch.Rows.Clear()
            SearchIdMax = 0
        End If
        pbProgress.Value = 0
        btnSearch.Text = "Searching.."
        btnSearch.Enabled = False
        didCancel = False
        Dim thread As New Thread(New ThreadStart(AddressOf SearchThread))
        thread.Start()
    End Sub

    Public Sub SearchThread()
        Try
            If Not music.IsLoggedIn And My.Settings.AuthCustom Then
                music.Login(My.Settings.AuthUser, My.Settings.AuthPass)
            ElseIf Not music.IsLoggedIn Then
                music.Login()
            End If
            Dim result As List(Of FreeMusic.Song) = music.Search(txtSearch.Text, SearchIdMax)
            songs.AddRange(result)
            Invoke(New UpdateSearchDelegate(AddressOf SearchCompleted), result)
        Catch ex As Exception
            MsgBox("Could not search and parse data: " & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "An error occured")
            Invoke(New UpdateSearchDelegate(AddressOf SearchCompleted), New List(Of FreeMusic.Song))
        End Try
    End Sub

    Public Sub SearchCompleted(ByVal result As List(Of FreeMusic.Song))
        For Each song As FreeMusic.Song In result
            song.RowId = SearchIdMax
            Dim length As New TimeSpan(0, 0, song.Duration)
            Dim r As New XPTable.Models.Row()
            r.Cells.Add(New XPTable.Models.Cell(song.RowId))
            r.Cells.Add(New XPTable.Models.Cell(song.Quantity))
            r.Cells.Add(New XPTable.Models.Cell(song.Artist))
            r.Cells.Add(New XPTable.Models.Cell(song.Title))
            r.Cells.Add(New XPTable.Models.Cell(length.Minutes & ":" & length.Seconds.ToString.PadLeft(2, "0")))
            r.Cells.Add(New XPTable.Models.Cell(song.Bitrate))
            r.Cells.Add(New XPTable.Models.Cell(song.Size))
            r.Cells.Add(New XPTable.Models.Cell("Download"))
            tmSearch.Rows.Add(r)
            SearchIdMax += 1
        Next
        tblSearch.ScrollToTop()
        FetchDetails(result)
    End Sub

#End Region

#Region "Details"

    Public Sub FetchDetails(ByVal songs As List(Of FreeMusic.Song))
        If songs.Count > 0 Then
            btnSearch.Text = "Fetching.."
            SongsToFetch = songs.Count
            progress = 0
            For i As Integer = 1 To songs.Count
                ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf FetchDetail), songs(i - 1))
                pbProgress.Value = Math.Round(i / songs.Count * 100)
            Next
        Else
            FinishSearch()
        End If
    End Sub

    Public Sub FetchDetail(ByVal song As FreeMusic.Song)
        Try
            If didCancel Then Exit Sub
            song = music.FetchDetail(song)
            Invoke(New UpdateProgressDelegate(AddressOf UpdateProgress), New Object() {song})
        Catch ex As Exception
        End Try
    End Sub

    Public Sub UpdateProgress(ByVal song As FreeMusic.Song)
        progress += 1

        For Each row As XPTable.Models.Row In tmSearch.Rows
            If row.Cells(0).Data = song.RowId Then
                row.Cells(5).Data = song.Bitrate
                row.Cells(6).Data = Math.Round(song.Size / 1024 / 1024, 2)
                Exit For
            End If
        Next

        If progress = SongsToFetch Then
            FinishSearch()
        End If
    End Sub

    Private Sub FinishSearch()
        btnSearch.Enabled = True
        tblSearch.Sort(tblSearch.SortingColumn, cmSearch.Columns(tblSearch.SortingColumn).SortOrder)
        pbProgress.Value = 100
        RenderSearchButton()
    End Sub

    Private Sub RenderSearchButton()
        If txtSearch.Text = searchString And searchString.Length > 0 Then
            btnSearch.Text = "More.."
        Else
            btnSearch.Text = "Search"
        End If
    End Sub

#End Region

#Region "Download"

    Private Sub StartDownload(ByVal row)
        Dim song As FreeMusic.Song = GetSongFromRow(row)
        If Not IsNothing(song) Then
            Dim filename As String = tmSearch.Rows(row).Cells(2).Text & " - " & tmSearch.Rows(row).Cells(3).Text & ".mp3"
            If My.Settings.JustDownload Then
                filename = My.Settings.DownloadDir & filename
            Else
                sfdDialog.FileName = filename
                sfdDialog.InitialDirectory = My.Settings.DownloadDir
                If sfdDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                filename = sfdDialog.FileName
            End If

            If Not My.Settings.OverwriteFile Then
                Dim fileexists As Boolean = File.Exists(filename)
                Dim counter As Integer = 1
                Do While fileexists
                    filename = filename.Replace(If(counter = 1, ".mp3", " (" & (counter - 1) & ").mp3"), " (" & counter & ").mp3")
                    counter += 1
                    fileexists = File.Exists(filename)
                Loop
            End If

            Download(song.Url, filename)
        End If
    End Sub

    Public Sub Download(ByVal url As String, ByVal file As String)
        Dim id As Integer = DownloadIdMax
        DownloadIdMax += 1
        Dim r As New XPTable.Models.Row
        r.Cells.Add(New XPTable.Models.Cell(id))
        r.Cells.Add(New XPTable.Models.Cell(file))
        r.Cells.Add(New XPTable.Models.Cell(0))
        r.Cells.Add(New XPTable.Models.Cell("0 KB/s"))
        tmDownload.Rows.Insert(0, r)
        CurrentDownloads.Add(New Integer() {id, 0})

        Dim info() As String = {url, file, id}
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DownloadFile), info)
    End Sub

    Public Sub DownloadFile(ByVal info() As String)
        Try
            ' Make request
            Dim request As HttpWebRequest
            request = WebRequest.Create(info(0))
            request.Method = "GET"

            ' Get response
            Dim response As HttpWebResponse = request.GetResponse
            Dim length As Integer = response.ContentLength
            Dim responseStream As Stream = response.GetResponseStream
            Dim writeStream As New FileStream(info(1), FileMode.Create)

            ' Download file
            Dim speedTimer As New Stopwatch
            Dim totalRead As Integer = 0
            Dim readings As Integer = 0
            Dim speed As Double = 0
            Do
                speedTimer.Start()

                Dim readBytes(8191) As Byte
                Dim bytesread As Integer = responseStream.Read(readBytes, 0, 8192)
                totalRead += bytesread

                Dim tmp() As String = {info(2), totalRead, length, speed}
                Invoke(New UpdateDownloadDelegate(AddressOf UpdateDownload), New Object() {tmp})

                If bytesread = 0 Then Exit Do
                writeStream.Write(readBytes, 0, bytesread)

                speedTimer.Stop()

                For Each i() As Integer In CurrentDownloads
                    If i(0) = info(2) And i(1) = 1 Then
                        responseStream.Close()
                        writeStream.Close()
                        response.Close()
                        File.Delete(info(1))
                        Exit Sub
                    End If
                Next

                readings += 1
                If readings >= 10 Then
                    speed = 81920 / (speedTimer.ElapsedMilliseconds / 1000)
                    speedTimer.Reset()
                    readings = 0
                End If
            Loop
            responseStream.Close()
            writeStream.Close()
            response.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub UpdateDownload(ByVal info() As String)
        Dim p As Integer = CInt(Math.Round((info(1) / info(2)) * 100))
        For Each row As XPTable.Models.Row In tmDownload.Rows
            If row.Cells(0).Data = info(0) Then
                row.Cells(2).Data = p
                row.Cells(3).Text = If(progress >= 100, "Completed", Math.Round(CType(info(3), Double) / 1024, 2) & " KB/s")
                Exit For
            End If
        Next
    End Sub

#End Region

#End Region

#Region "Control methods"

    Private Sub pbProgress_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbProgress.MouseDown
        progressY = pbProgress.PointToClient(Cursor.Position).Y
        isMouseDown = True
    End Sub

    Private Sub pbProgress_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbProgress.MouseMove
        If isMouseDown Then
            Dim frmPoint As Integer = Me.PointToClient(Cursor.Position).Y
            SplitContainer1.SplitterDistance = frmPoint - progressY - 30
            pbProgress.Location = New Point(2, frmPoint - progressY)
        End If
    End Sub

    Private Sub pbProgress_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbProgress.MouseUp
        isMouseDown = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter And btnSearch.Enabled Then
            Search()
        ElseIf e.KeyCode = Keys.Escape Then
            didCancel = True
            FinishSearch()
        End If
    End Sub

    Private Sub tblSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblSearch.DoubleClick
        If tblSearch.SelectedIndicies.Count = 1 Then
            StartDownload(tblSearch.SelectedIndicies(0))
        End If
    End Sub

    Private Sub tblSearch_CellButtonClicked(ByVal sender As Object, ByVal e As XPTable.Events.CellButtonEventArgs) Handles tblSearch.CellButtonClicked
        StartDownload(e.Row)
    End Sub

    Private Sub tblDownload_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblDownload.DoubleClick
        If tblDownload.SelectedItems.Count = 1 Then
            Try
                System.Diagnostics.Process.Start(tblDownload.SelectedItems(0).Cells(1).Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        Settings.Close()
        Settings = New frmSettings
        Settings.Show()
        Settings.Focus()
    End Sub

    Private Sub tblDownload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tblDownload.KeyDown
        If e.KeyCode = Keys.Delete Then
            If tblDownload.SelectedItems.Count = 1 Then
                For Each i() As Integer In CurrentDownloads
                    If i(0) = tblDownload.SelectedItems(0).Cells(0).Data Then
                        i(1) = 1
                        tmDownload.Rows.RemoveAt(tblDownload.SelectedIndicies(0))
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        RenderSearchButton()
    End Sub

#End Region

#Region "Helpers"

    Private Function GetSongFromRow(ByVal row As Integer) As FreeMusic.Song
        Return songs(tmSearch.Rows(row).Cells(0).Data)
    End Function

#End Region

#Region "Form events"

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoUpdate.AutoUpdate()
        ThreadPool.SetMinThreads(12, 24)
        tblSearch.Sort(5, SortOrder.Descending)
    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        cmSearch.Columns(1).Width = 40
        cmSearch.Columns(2).Width = Math.Round((tblSearch.Width - 314) / 2)
        cmSearch.Columns(3).Width = Math.Round((tblSearch.Width - 314) / 2)
        cmSearch.Columns(4).Width = 55
        cmSearch.Columns(5).Width = 55
        cmSearch.Columns(6).Width = 71
        cmSearch.Columns(7).Width = 70

        cmDownload.Columns(1).Width = Math.Round(tblDownload.Width - 350)
        cmDownload.Columns(2).Width = 252
        cmDownload.Columns(3).Width = 75

        pbProgress.Location = New Point(2, SplitContainer1.SplitterDistance + 30)
    End Sub

#End Region

End Class
