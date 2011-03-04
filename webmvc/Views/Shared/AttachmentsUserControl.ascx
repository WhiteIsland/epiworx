<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.AttachmentListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<div class="part">
    <h4>
        Attachments</h4>
    <div class="attachments">
        <ul>
            <% foreach (var attachment in this.Model.Attachments)
               {
            %>
            <%
                   this.Html.RenderPartial("AttachmentUserControl", new AttachmentFormModel(attachment));%>
            <%
               } 
            %>
        </ul>
        <fieldset>
            <% using (this.Html.BeginForm("Add", "Attachment", new { sourceType = (int)this.Model.Source.SourceType, sourceId = this.Model.Source.SourceId }, FormMethod.Post, new { id = "attachment-edit-form", enctype = "multipart/form-data" }))
               { 
            %>
            <%= this.Html.FileUpload("FileData")%>
            <input type="submit" value="Add Attachment" />
            <% 
                } 
            %>
        </fieldset>
    </div>
</div>
