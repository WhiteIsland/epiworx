<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.UserFormModel>" %>
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
            <a href="javascript:void(0);" onclick="deleteRecord('<%=this.Url.Action("Delete", "User", new {id = this.Model.UserId})%>');">
                Delete</a>
            <%
                }%>
        </li>
    </ul>
</div>
