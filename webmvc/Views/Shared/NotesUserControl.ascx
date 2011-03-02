<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.NoteListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<div class="clear">
</div>
<div class="notes">
    <ul>
        <% foreach (var note in this.Model.Notes)
           {%>
        <%
               this.Html.RenderPartial("NoteUserControl", new NoteFormModel(note));%>
        <%
           } %>
    </ul>
    <fieldset>
        <% using (this.Html.BeginForm("Add", "Note", new { sourceType = (int)this.Model.Source.SourceType, sourceId = this.Model.Source.SourceId }, FormMethod.Post, new { id = "note-edit-form" }))
           { %>
        <%= this.Html.TextArea("Body", string.Empty)%>
        <input type="submit" value="Add Note" />
        <% } %>
    </fieldset>
</div>
