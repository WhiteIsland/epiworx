<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.AttachmentFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<li><a href="<%=this.Url.Action("Delete", "Attachment", new {id = this.Model.AttachmentId})%>"
    class="action deleteAttachment">Delete</a>
    <%=this.Html.ActionLink(this.Model.Name, "Details", "Attachment", new {id = this.Model.AttachmentId}, null)%>
    <em>Posted on
        <%= this.Model.CreatedDate.ToString("MMMM d, yyyy") %>
        at
        <%= this.Model.CreatedDate.ToShortTimeString() %></em>
        </li>
