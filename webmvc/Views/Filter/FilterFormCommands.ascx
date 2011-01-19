<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FilterFormModel>" %>
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
            <a href="javascript:void(0);" onclick="deleteRecord('<%=this.Url.Action("Delete", "Filter", new {id = this.Model.FilterId})%>');">
                Delete</a>
            <%
                }%>
        </li>
    </ul>
</div>
