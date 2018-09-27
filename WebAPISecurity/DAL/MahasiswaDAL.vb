Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class MahasiswaDAL

    Private Function GetConn() As String
        Return ConfigurationManager.ConnectionStrings("ApiConnection").ConnectionString
    End Function

    Public Sub Create(obj As Mahasiswa)
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "insert into Mahasiswa(Nim,Nama,IPK) 
                          values(@Nim,@Nama,@IPK)"
            Dim param = New With {.Nim = obj.Nim, .Nama = obj.Nama, .IPK = obj.IPK}
            Try
                conn.Execute(strSql, param)
            Catch sqlEx As SqlException
                Throw New Exception($"Number:{sqlEx.Number} Desc:{sqlEx.Message}")
            Catch ex As Exception
                Throw New Exception($"Error: {ex.Message}")
            End Try
        End Using
    End Sub

    Public Sub Update(obj As Mahasiswa)
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "update Mahasiswa set Nama=@Nama,IPK=@IPK 
                          where Nim=@Nim"
            Dim param = New With {.Nama = obj.Nama, .IPK = obj.IPK, .Nim = obj.Nim}
            Try
                conn.Execute(strSql, param)
            Catch sqlEx As SqlException
                Throw New Exception($"Number:{sqlEx.Number} Desc:{sqlEx.Message}")
            Catch ex As Exception
                Throw New Exception($"Error: {ex.Message}")
            End Try
        End Using
    End Sub

    Public Sub Delete(id As String)
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "delete from Mahasiswa where Nim=@Nim"
            Dim param = New With {.Nim = id}
            Try
                conn.Execute(strSql, param)
            Catch sqlEx As SqlException
                Throw New Exception($"Number:{sqlEx.Number} Desc:{sqlEx.Message}")
            Catch ex As Exception
                Throw New Exception($"Error: {ex.Message}")
            End Try
        End Using
    End Sub

    Public Function GetAll() As IEnumerable(Of Mahasiswa)
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "select * from Mahasiswa order by Nama asc"
            Return conn.Query(Of Mahasiswa)(strSql)

            'Dim lstMhs As New List(Of Mahasiswa)
            'Dim cmd As New SqlCommand(strSql, conn)
            'conn.Open()
            'Dim dr As SqlDataReader
            'dr = cmd.ExecuteReader
            'If dr.HasRows Then
            '    While dr.Read
            '        lstMhs.Add(New Mahasiswa With {
            '                   .Nim = dr("Nim").ToString(),
            '                   .Nama = dr("Nama").ToString(),
            '                   .IPK = CDbl(dr("IPK"))})
            '    End While
            'End If
            'dr.Close()
            'cmd.Dispose()
            'conn.Close()
            'Return lstMhs
        End Using
    End Function

    Public Function GetById(id As String) As Mahasiswa
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "select * from Mahasiswa 
                          where Nim=@Nim"
            Dim param = New With {.Nim = id}
            Dim result = conn.QuerySingle(Of Mahasiswa)(strSql, param)
            Return result
        End Using
    End Function

    Public Function GetByName(nama As String) As IEnumerable(Of Mahasiswa)
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "select * from Mahasiswa
                          where Nama like @Nama"
            Dim param = New With {.Nama = $"%{nama}%"}
            Dim results = conn.Query(Of Mahasiswa)(strSql, param)

            Return results
        End Using
    End Function

    Public Async Function GetByNameAsync(nama As String) As Task(Of IEnumerable(Of Mahasiswa))
        Using conn As New SqlConnection(GetConn())
            Dim strSql = "select * from Mahasiswa
                          where Nama like @Nama"
            Dim param = New With {.Nama = $"%{nama}%"}
            Dim results = Await conn.QueryAsync(Of Mahasiswa)(strSql, param)
            Return results
        End Using
    End Function

    Public Sub BulkInsertData(lstData As List(Of Mahasiswa))
        Using conn As New SqlConnection(GetConn())
            Dim dt As New DataTable
            dt.Columns.Add("Nim")
            dt.Columns.Add("Nama")
            dt.Columns.Add("IPK")

            For Each mhs In lstData
                dt.Rows.Add(mhs.Nim, mhs.Nama, mhs.IPK)
            Next

            Using sqlBulk As New SqlBulkCopy(conn)
                sqlBulk.DestinationTableName = "Mahasiswa"
                sqlBulk.WriteToServer(dt)
            End Using
        End Using
    End Sub
End Class
