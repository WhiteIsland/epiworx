<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.SprintFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
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
            <a href="javascript:void(0);" onclick="deleteRecord('<%=this.Url.Action("Delete", "Sprint", new {id = this.Model.SprintId})%>');">
                Delete</a>
            <%
                }%>
        </li>
        <li>
            <%: this.Html.ActionLink("Back to Project", "Edit", "Project", new { id = this.Model.ProjectId, name = this.Html.ToTitle(this.Model.ProjectName) }, null)%></li>
    </ul>
</div>
