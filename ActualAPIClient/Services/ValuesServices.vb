Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class ValuesServices
    Private _baseUrl As String = "http://localhost:62467"
    Private _httpClient As HttpClient

    Public Sub New()
        _httpClient = New HttpClient()
    End Sub

    Public Async Function GetAllAsync() As Task(Of IEnumerable(Of String))
        Dim listValue As List(Of String)
        Dim _uri = $"{_baseUrl}/api/Values"
        _httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", "1bebwre1bkj7uy5ffDmp_nz8yzGZZE-0YSVLPlGDJBM82ybxgTO6285VkZ4W48Xd5NW4gs_NYZyWq7um3Dx1BZtwS26mvOBhCp54o4Dnw0Dn-SgftDfDST6Xu4ghEY6QGZpWtRtutNecBab7MqjFHOxLQjeolqNYpBvqqrgrq1Q1qAhD3wkxFud2B0Y90KE5MwE5V4G50vkJPJWHZC2-z_5kpoLqdZ1XTubxhsly9Gz3Nz8ClZqvLZNTSwlD31PDze9QRixmMqQ-bQSZgJtm8UL2T6cEOo9UnXONLLR6AXK-luEdMpu4hZ_ixzsN_d7lxizafw_vZR8qwhieT_FrClLC7JaZCqY50PPsz63vJmXlQNa4ZZDOC75XqdLBiFIXEL_80u0nMtkudukJT8jWwz4_Gv85Ra2dr1qxRqFVitXH6Atfd5-eH27Ug9Pcs65qnpWq5jzulGpSLAsXTi56evMabXRRbX7h2_5-H5q33BY")
        Dim _response = Await _httpClient.GetAsync(_uri)
        If _response.IsSuccessStatusCode Then
            Dim _content = Await _response.Content.ReadAsStringAsync()
            listValue = JsonConvert.DeserializeObject(Of List(Of String))(_content)
            Return listValue
        Else
            Throw New Exception("Request data gagal")
        End If
    End Function
End Class
