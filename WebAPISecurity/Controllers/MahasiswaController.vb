Imports System.Net
Imports System.Web.Http

Namespace Controllers

    <Authorize>
    Public Class MahasiswaController
        Inherits ApiController

        Private mhsDAL As New MahasiswaDAL

        ' GET: api/Mahasiswa
        <HttpGet()>
        Public Function GetValues() As IEnumerable(Of Mahasiswa)
            Return mhsDAL.GetAll()
        End Function

        ' GET: api/Mahasiswa/5
        <HttpGet()>
        Public Function GetValue(id As String) As Mahasiswa
            Return mhsDAL.GetById(id)
        End Function


        <HttpGet()>
        <Route("api/Mahasiswa/GetByName")>
        Public Function GetByName(nama As String) As IEnumerable(Of Mahasiswa)
            Return mhsDAL.GetByName(nama)
        End Function

        ' POST: api/Mahasiswa
        Public Function PostValue(mhs As Mahasiswa) As IHttpActionResult
            Try
                mhsDAL.Create(mhs)
                Return Ok($"Data mahasiswa {mhs.Nama} berhasil ditambahkan")
            Catch ex As Exception
                Return BadRequest($"Kesalahan:{ex.Message}")
            End Try
        End Function

        ' PUT: api/Mahasiswa/5
        Public Function PutValue(mhs As Mahasiswa) As IHttpActionResult
            Try
                mhsDAL.Update(mhs)
                Return Ok($"Data mahasiswa {mhs.Nama} berhasil diupdate")
            Catch ex As Exception
                Return BadRequest($"Kesalahan:{ex.Message}")
            End Try
        End Function

        ' DELETE: api/Mahasiswa/5
        Public Function DeleteValue(id As String) As IHttpActionResult
            Try
                mhsDAL.Delete(id)
                Return Ok($"Data mahasiswa berhasil didelete")
            Catch ex As Exception
                Return BadRequest($"Kesalahan: {ex.Message}")
            End Try
        End Function
    End Class
End Namespace