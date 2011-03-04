<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.AttachmentFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<li><a href="<%=this.Url.Action("Delete", "Attachment", new {id = this.Model.AttachmentId})%>" class="deleteAttachment">
    Delete</a>
    <%= this.Model.Name %>
</li>
