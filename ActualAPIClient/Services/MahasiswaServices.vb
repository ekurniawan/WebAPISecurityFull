Imports RestSharp

Public Class MahasiswaServices
    Private _client As RestClient
    Public Sub New()
        _client = New RestClient("http://localhost:62467")
    End Sub

    Public Function GetAll(token As String) As IEnumerable(Of Mahasiswa)
        Dim request = New RestRequest("api/Mahasiswa", Method.GET) With {
            .RequestFormat = DataFormat.Json}
        request.AddHeader("Authorization", $"Bearer {token}")
        Dim response = _client.Execute(Of List(Of Mahasiswa))(request)
        If response.Data Is Nothing Then
            Throw New Exception($"Error {response.ErrorMessage}")
        End If
        Return response.Data
    End Function
End Class
