<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.NoteFormModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<li><a href="<%=this.Url.Action("Delete", "Note", new {id = this.Model.NoteId})%>" class="deleteNote">
    Delete</a> <strong>
        <%= this.Model.CreatedByName %></strong> <em>Posted on
            <%= this.Model.CreatedDate.ToString("MMMM d, yyyy") %>
            at
            <%= this.Model.CreatedDate.ToShortTimeString() %></em>
    <p>
        <%= this.Model.Body %></p>
</li>
