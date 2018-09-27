Imports System.Web.Mvc

Namespace Controllers
    Public Class ValuesController
        Inherits Controller

        Private myServices As RestsharpServices

        Public Sub New()
            myServices = New RestsharpServices()
        End Sub

        ' GET: Values
        Function Index() As ActionResult
            If Session("token_pengguna") Is Nothing Then
                Session("returnUrl") = Request.Url.ToString()
                Return RedirectToAction("FormLogin")
            End If
            Dim token = CType(Session("token_pengguna"), Token)
            Dim results = myServices.GetAll($"Bearer {token.access_token}")
            Return View(results)
        End Function

        Public Function FormLogin() As ActionResult
            Return View()
        End Function

        'baru
        <HttpPost>
        Public Function FormLogin(pgn As Pengguna) As ActionResult
            Try
                Dim result = myServices.Login(pgn)
                Session("token_pengguna") = result
                Return Redirect(Session("returnUrl").ToString())
            Catch ex As Exception
                ViewBag.Error = $"Login Gagal..."
                Return View()
            End Try
        End Function

        Public Function LogOut() As ActionResult
            Session("token_pengguna") = Nothing
            Return RedirectToAction("FormLogin", "Values")
        End Function
    End Class
End Namespace