Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Net
Imports System.Web
Imports VkNet
Imports VkNet.Exception
Imports VkNet.Model.Attachments

Public Class FreeMusic

    Private Session As VkApi

#Region "Public functions"

    Public Sub ResetSession()
        Session = New VkApi()
    End Sub

    Public Sub Login(ByVal username As String, ByVal password As String)
        If String.IsNullOrEmpty(username) Then
            Throw New ArgumentNullException("username", "Please enter a username.")
        End If
        If String.IsNullOrEmpty(password) Then
            Throw New ArgumentNullException("password", "Please enter a password.")
        End If

        Try
            Session = New VkApi()
            Dim appId As Integer = My.Settings.VkApplicationId
            Session.Authorize(New ApiAuthParams With {
                .ApplicationId = Convert.ToUInt64(appId),
                .Login = username,
                .Password = password,
                .Settings = Enums.Filters.Settings.Audio
            })

            ' Save username/password settings
            My.Settings.AuthUser = username
            My.Settings.AuthPass = password
        Catch ex As VkApiAuthorizationException
            Throw New Exception("The username or password is incorrect. Please try again.", ex)
        End Try
    End Sub

    Public Function Search(ByVal query As String, Optional ByVal offset As Integer = 0) As List(Of Song)
        ' Do the API request
        Dim totalCount As Integer
        Dim musics As ReadOnlyCollection(Of Audio) = Session.Audio.Search(New Model.RequestParams.AudioSearchParams With {
                .Query = query,
                .Autocomplete = False,
                .Sort = False,
                .Lyrics = False,
                .Count = 50,
                .Offset = offset
            }, totalCount)

        ' Parse songs
        Dim songs As List(Of Song) = ParseSongs(musics)

        ' Return songs
        Return songs
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

    Private Function ParseSongs(audios As ReadOnlyCollection(Of Audio)) As List(Of Song)
        ' Create list for the results
        Dim songs As New List(Of Song)

        For Each audio As Audio In audios
            songs.Add(New Song With {
                .Artist = audio.Artist,
                .Title = audio.Title,
                .Duration = audio.Duration,
                .Url = audio.Url.ToString()
            })
        Next

        Return songs
    End Function

#End Region

#Region "Private helpers"

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
            Return Session IsNot Nothing AndAlso Session.IsAuthorized
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
