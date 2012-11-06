Imports System.IO
Imports System.Net
Imports System.Web
Imports Pirate.Logins

Public Class FreeMusic

    Private Guid As String = ""
    Private Random As New Random
    Private UsedLogins As New List(Of Integer)

#Region "Public functions"

    Public Sub Login()
        Try
            Dim tries As Integer = 10
            While tries > 0
                ' Make request
                Dim cont As New CookieContainer
                Dim request As HttpWebRequest
                request = WebRequest.Create("http://login.vk.com/")
                request.Method = "POST"
                request.CookieContainer = cont

                ' Create POST content and send
                Dim login() As String = GetLogin()
                Dim postdata As String = "act=login&success_url=&fail_url=&try_to_login=1&to=&vk=&al_test=3&email=" & HttpUtility.UrlEncode(login(0)) & "&pass=" & HttpUtility.UrlEncode(login(1)) & "&expire="
                Dim postbytes() As Byte = System.Text.Encoding.UTF8.GetBytes(postdata)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = postbytes.Length
                Dim requestStream As Stream = request.GetRequestStream
                requestStream.Write(postbytes, 0, postbytes.Length)
                requestStream.Close()

                ' Get response and login cookie
                Dim response As HttpWebResponse = request.GetResponse
                Dim cookies As CookieCollection = request.CookieContainer.GetCookies(New Uri("http://pirate.vk.com"))
                For Each myCookie As Cookie In cookies
                    If myCookie.Name = "remixsid" Then
                        Me.Guid = myCookie.Value
                    End If
                Next
                response.Close()

                ' Validate guid
                If IsLoggedIn Then Exit While

                tries -= 1
            End While

        Catch ex As Exception
            Throw New Exception("Error at default login", ex)
        End Try
    End Sub

    Public Sub Login(ByVal Username As String, ByVal Password As String)
        Try
            
            ' Make request
            Dim cont As New CookieContainer
            Dim request As HttpWebRequest
            request = WebRequest.Create("http://login.vk.com/")
            request.Method = "POST"
            request.CookieContainer = cont

            ' Create POST content and send
            Dim postdata As String = "act=login&success_url=&fail_url=&try_to_login=1&to=&vk=&al_test=3&email=" & HttpUtility.UrlEncode(Username) & "&pass=" & HttpUtility.UrlEncode(Password) & "&expire="
            Dim postbytes() As Byte = System.Text.Encoding.UTF8.GetBytes(postdata)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = postbytes.Length
            Dim requestStream As Stream = request.GetRequestStream
            requestStream.Write(postbytes, 0, postbytes.Length)
            requestStream.Close()

            ' Get response and login cookie
            Dim response As HttpWebResponse = request.GetResponse
            Dim cookies As CookieCollection = request.CookieContainer.GetCookies(New Uri("http://pirate.vk.com"))
            For Each myCookie As Cookie In cookies
                If myCookie.Name = "remixsid" Then
                    Me.Guid = myCookie.Value
                End If
            Next
            response.Close()

            ' Throw error if cookie not found
            If Not IsLoggedIn Then Throw New Exception("Invalid login guid")

        Catch ex As Exception
            Throw New Exception("Error at custom login", ex)
        End Try
    End Sub

    Public Function Search(ByVal s As String, Optional ByVal offset As Integer = 0) As List(Of Song)
        Try
            Dim tries As Integer = 10
            While tries > 0
                Try
                    Dim data As String = "act=search&al=1&offset=" & offset & "&q=" & System.Web.HttpUtility.UrlEncode(s)

                    ' Make request
                    Dim request As HttpWebRequest
                    request = WebRequest.Create("http://vk.com/audio")
                    request.Method = "POST"
                    request.Headers.Add("Accept-Encoding", "gzip, deflate")
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                    request.ContentLength = data.Length
                    request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

                    ' Set request settings
                    request.Headers(HttpRequestHeader.Cookie) = "remixsid=" & Me.Guid & ";"
                    Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(data)
                    Dim rs As Stream = request.GetRequestStream
                    rs.Write(buffer, 0, buffer.Length)
                    rs.Close()

                    ' Get response
                    Dim response As HttpWebResponse = request.GetResponse
                    Dim responseStream As StreamReader = New StreamReader(response.GetResponseStream, System.Text.Encoding.GetEncoding("iso-8859-5"))
                    Dim result As String = responseStream.ReadToEnd
                    responseStream.Close()
                    response.Close()

                    ' Parse songs
                    Dim songs As List(Of Song) = ParseSongs(result)

                    ' Return songs
                    Return songs
                Catch ex As WebException
                    Login()
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
            Dim request As HttpWebRequest
            request = WebRequest.Create(song.Url)
            request.Method = "HEAD"

            ' Get response
            Dim response As HttpWebResponse = request.GetResponse
            Dim length As Integer = response.Headers("Content-Length")
            response.Close()

            ' Set details for song
            song.Size = length
            song.Bitrate = MapBitrate(Math.Round(song.Size * 8 / song.Duration / 1000))

            ' Return songs
            Return song
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

        If Not song.Url.StartsWith("http://") Then Return Nothing

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
            Return Not String.IsNullOrEmpty(Guid)
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

#Region "Login engine"

    Public Function GetLogin() As String()
        Dim length As Integer = Logins.AllLogins.Length
        Dim rand As Integer = Random.Next(0, length - 1)
        While UsedLogins.Contains(rand)
            If UsedLogins.Count = length Then
                Throw New Exception("All logins have been used!")
            End If
            rand = Random.Next(0, length - 1)
        End While
        Return Logins.AllLogins(rand)
    End Function

#End Region

End Class