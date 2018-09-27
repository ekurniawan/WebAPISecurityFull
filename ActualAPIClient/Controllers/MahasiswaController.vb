Imports System.Web.Mvc

Namespace Controllers
    Public Class MahasiswaController
        Inherits Controller

        Private myServices As MahasiswaServices
        Public Sub New()
            myServices = New MahasiswaServices()
        End Sub

        ' GET: Mahasiswa
        Function Index() As ActionResult
            If Session("token_pengguna") Is Nothing Then
                Session("returnUrl") = Request.Url.ToString()
                Return RedirectToAction("FormLogin", "Values")
            End If
            Dim token = CType(Session("token_pengguna"), Token)
            Dim results = myServices.GetAll(token.access_token)
            Return View(results)
        End Function

        ' GET: Mahasiswa/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Mahasiswa/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Mahasiswa/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Mahasiswa/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Mahasiswa/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Mahasiswa/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Mahasiswa/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace