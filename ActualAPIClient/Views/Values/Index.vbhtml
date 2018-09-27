@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<ul>
    @For Each item In Model
        @<li>@item</li>
    Next
</ul>

