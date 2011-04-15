<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.InvoiceFormModel>" %>
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
            <%= this.Html.ActionLink("Delete", "Delete", new { id = this.Model.InvoiceId}) %>
            <%
                }%>
        </li>
        <%
            if (!string.IsNullOrEmpty(this.Request.QueryString["returnUrl"]))
            {
        %>
        <li><a href="<%= this.Server.UrlDecode(this.Request.QueryString["returnUrl"]) %>">Back</a></li>
        <%
            }
        %>
    </ul>
</div>
