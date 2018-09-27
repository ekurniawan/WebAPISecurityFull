Imports RestSharp

Public Class RestsharpServices
    Private _client As RestClient
    Public Sub New()
        _client = New RestClient("http://localhost:62467")
    End Sub

    Public Function GetAll(token As String) As List(Of String)
        Dim request = New RestRequest("api/Values", Method.GET) With {
            .RequestFormat = DataFormat.Json}
        'untuk validasi token
        request.AddHeader("Authorization", token)

        Dim response = _client.Execute(Of List(Of String))(request)
        If response.Data Is Nothing Then
            Throw New Exception($"Error: {response.ErrorMessage}")
        End If
        Return response.Data
    End Function

    Public Function Login(pgn As Pengguna) As Token
        Dim request = New RestRequest("Token", Method.POST) With {
            .RequestFormat = DataFormat.Json}
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded")
        request.AddParameter("grant_type", "password")
        request.AddParameter("username", pgn.Username)
        request.AddParameter("password", pgn.Password)

        Dim response = _client.Execute(Of Token)(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception($"Gagal login {response.StatusCode} {response.ErrorMessage}")
        End If
        Return response.Data
    End Function
End Class
