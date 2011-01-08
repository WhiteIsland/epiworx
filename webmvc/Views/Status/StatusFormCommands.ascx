<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.StatusFormModel>" %>
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
            <a href="javascript:void(0);" onclick="deleteRecord('<%=this.Url.Action("Delete", "Status", new {id = this.Model.StatusId})%>');">
                Delete</a>
            <%
                }%>
        </li>
    </ul>
</div>
