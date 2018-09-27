@ModelType IEnumerable(Of ActualAPIClient.Mahasiswa)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nim)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nama)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IPK)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nim)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nama)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IPK)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
