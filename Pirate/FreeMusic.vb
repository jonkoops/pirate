Imports System
Imports System.IO
Imports System.Net
Imports System.Web

Public Class FreeMusic

    Private Session As Session

#Region "Public functions"

    Public Sub ResetSession()
        Try
            Session = New Session()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub Login(ByVal Username As String, ByVal Password As String)
        If String.IsNullOrEmpty(Username) Or String.IsNullOrEmpty(Password) Then
            MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Session = New Session(Username, Password)
            Session.TryLogin()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        If Not Session.IsLoggedIn Then
            MessageBox.Show("The username or password is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            My.Settings.AuthUser = Username
            My.Settings.AuthPass = Password
        End If
    End Sub

    Public Function Search(ByVal s As String, Optional ByVal offset As Integer = 0) As List(Of Song)
        Try
            Dim tries As Integer = 10
            While tries > 0
                Try
                    Dim data As String = "act=search&al=1&offset=" & offset & "&q=" & System.Web.HttpUtility.UrlEncode(s)

                    ' Make request
                    Dim request As HttpWebRequest = WebRequest.Create("https://vk.com/audio")
                    request.Method = "POST"
                    request.Headers.Add("Accept-Encoding", "gzip, deflate")
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                    request.ContentLength = data.Length
                    request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

                    ' Set request settings
                    request.Headers(HttpRequestHeader.Cookie) = "remixsid=" & Me.Session.Guid & ";"
                    Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(data)
                    Using rs As Stream = request.GetRequestStream
                        rs.Write(buffer, 0, buffer.Length)
                    End Using

                    Dim result As String = ""

                    ' Get response
                    Using response As HttpWebResponse = request.GetResponse
                        Using responseStream As StreamReader = New StreamReader(response.GetResponseStream, System.Text.Encoding.GetEncoding("iso-8859-5"))
                            result = responseStream.ReadToEnd
                        End Using
                    End Using

                    ' Parse songs
                    Dim songs As List(Of Song) = ParseSongs(result)

                    ' Return songs
                    Return songs
                Catch ex As WebException
                    'Login()
                End Try
                tries -= 1
            End While
        Catch ex As Exception
            Throw New Exception("Error at searching for songs", ex)
        End Try
        Return New List(Of Song)
    End Function

    Public Function FetchDetail(ByVal song As Song) As Song
        Try
            ' Make request
            Dim request As HttpWebRequest = WebRequest.Create(song.Url)
            request.Method = "HEAD"

            ' Get response
            Using response As HttpWebResponse = request.GetResponse
                Dim length As Integer = response.Headers("Content-Length")

                ' Set details for song
                song.Size = length
                song.Bitrate = MapBitrate(Math.Round(song.Size * 8 / song.Duration / 1000))

                ' Return songs
                Return song
            End Using

        Catch ex As Exception
            ' Return the song without any details
            Return song
        End Try
    End Function

#End Region

#Region "Private functions"

    Private Function ParseSongs(ByVal html As String) As List(Of Song)

        ' Create list for the results
        Dim songs As New List(Of Song)

        ' No songs will return the empty list
        If Not html.Contains("<div class=""area clear_fix""") Then
            Return songs
        End If

        ' Get the songs
        Dim splitter() As String = Split(html, "<div class=""area clear_fix""")
        Dim duplicate As Boolean
        For Each audioRow As String In splitter
            duplicate = False
            If audioRow.StartsWith(" onclick=""") Then
                Dim song As Song = GetSong(audioRow)

                ' If song is parsed correctly
                If Not IsNothing(song) Then

                    ' Check if song exists and add quantity
                    For Each s As Song In songs
                        If s.Url = song.Url Then
                            s.Quantity += 1
                            duplicate = True
                        End If
                    Next

                    ' If it does not exist, then add it
                    If Not duplicate Then
                        songs.Add(song)
                    End If
                End If

            End If
        Next

        ' Return result
        Return songs

    End Function

#End Region

#Region "Private helpers"

    Private Function GetSong(ByVal audioRow As String) As Song
        Dim song As New Song

        song.Artist = TextInTag(audioRow, "<a href=""", "</a>")
        song.Title = TextInTag(audioRow, "<span class=""title", "</a>")
        song.Duration = TextBetween(TextBetween(audioRow, "<input type=""hidden"" id=""", " />"), ",", """")
        song.Url = TextBetween(TextBetween(audioRow, "<input type=""hidden"" id=""", """ />"), " value=""", ",")

        If Not song.Url.StartsWith("https://") Then Return Nothing

        Return song
    End Function

    Private Function StripHtml(ByVal i As String) As String
        If i.Length < 1 Then Return ""
        i = i.Replace("<br/>", vbCrLf)
        Return System.Text.RegularExpressions.Regex.Replace(i, "<[^>]*>", String.Empty)
    End Function

    Private Function TextInTag(ByVal i As String, ByVal s As String, ByVal e As String, ByVal p As String) As String
        Dim result As String
        result = i.Substring(i.IndexOf(s) + s.Length)
        result = TextBetween(result, p, e)
        result = StripHtml(result)
        result = HttpUtility.HtmlDecode(result)
        Return result
    End Function

    Private Function TextInTag(ByVal i As String, ByVal s As String, ByVal e As String) As String
        Dim result As String
        result = i.Substring(i.IndexOf(s) + s.Length)
        result = TextBetween(result, """>", e)
        result = StripHtml(result)
        result = HttpUtility.HtmlDecode(result)
        result = result.Trim()
        Return result
    End Function

    Private Function TextBetween(ByVal i As String, ByVal s As String, ByVal e As String) As String
        Dim splitter() As String = Split(i, s, 2)
        splitter = Split(splitter(1), e, 2)
        Return splitter(0)
    End Function

    Private Function MapBitrate(ByVal bitrate As Integer)
        Dim tolerance As Integer = 10
        Dim mappings() As Integer = {8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 192, 224, 256, 320}
        For Each map As Integer In mappings
            If (bitrate * 0.9) < map And (bitrate * 1.1) > map Then
                Return map
            End If
        Next
        Return bitrate
    End Function

#End Region

#Region "Public properties"

    Public ReadOnly Property IsLoggedIn() As Boolean
        Get
            If Session IsNot Nothing Then
                Return Session.IsLoggedIn
            Else
                Return False
            End If
        End Get
    End Property

#End Region

#Region "Public subclasses"

    Public Class Song
        Public RowId As Integer = 0
        Public Quantity As Integer = 1
        Public Artist As String = "-"
        Public Title As String = "-"
        Public Duration As Integer = 0
        Public Size As Integer = 0
        Public Bitrate As Integer = 0
        Public Url As String = "-"
    End Class

#End Region

End Class
