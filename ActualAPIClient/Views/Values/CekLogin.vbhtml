@Code
    ViewData("Title") = "FormLogin"
End Code

<h2>Form Login</h2>

<form action="@Url.Action("FormLogin")" method="post">
    <label for="Username">Username :</label><br />
    <input type="text" name="Username" value="" /><br /><br />
    <label for="Password">Password :</label><br />
    <input type="password" name="Password" value="" /><br /><br />
    <input type="submit"  value="Submit" />
</form>

