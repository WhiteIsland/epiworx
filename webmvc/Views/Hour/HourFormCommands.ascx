<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.HourFormModel>" %>
<div class="commands">
    <ul>
        <li>
            <input type="submit" value="Save Changes" /></li>
        <li>
            <%
                if (this.Model.IsNew)
                {%>
            <span class="disabled">Delete</span>
            <%
                }
                else
                {
            %>
            <%= this.Html.ActionLink("Delete", "Delete", new { id = this.Model.HourId }) %>
            <%
                }%>
        </li>
    </ul>
</div>
