Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Net
Imports System.Web
Imports VkNet
Imports VkNet.Model.Attachments

Public Class FreeMusic

    Private Session2 As VkApi

#Region "Public functions"

    Public Sub Login(ByVal Username As String, ByVal Password As String)
        If String.IsNullOrEmpty(Username) Or String.IsNullOrEmpty(Password) Then
            MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Session2 = New VkApi()
            Dim appId As Integer = 5599548
            Session2.Authorize(New ApiAuthParams With {
                .ApplicationId = Convert.ToUInt64(appId),
                .Login = Username,
                .Password = Password,
                .Settings = Enums.Filters.Settings.Audio
            })
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        If Not Session2.IsAuthorized Then
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
                    Dim totalCount As Integer
                    Dim musics As ReadOnlyCollection(Of Audio) = Session2.Audio.Search(New Model.RequestParams.AudioSearchParams With {
                        .Query = s,
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
            Return Session2.IsAuthorized
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
