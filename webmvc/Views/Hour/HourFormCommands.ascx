<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourFormModel>" %>
<div class="commands">
    <ul>
        <li class="first">
            <input type="submit" value="Save Changes" /></li>
        <li class="last"><a href="javascript:void(0);" onclick="deleteItem('<%= this.Url.Action("Delete", "Hour", new { id = this.Model.HourId }) %>');">
            Delete</a></li>
    </ul>
</div>
