<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskImportModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Import Stories
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm("Import", "Task", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {
    %>
    <h2>
        Import<span>Stories</span></h2>
    <%:this.Html.ValidationSummary(true,
                                                          "Whoops! Looks like some errors were encountered, please correct and try again.")%>
    <fieldset>
        <p class="span3">
            <label>
                Select a file to import:</label>
            <input type="file" name="File" id="File" value="File" />
            <span class="tip">Your import should use commas as separators and quoted identifiers.
                Make sure to use single quotes in any text fields, instead of double quotes. Click
                <a href="<%:this.Url.Content("~/Content/StoryImportTemplate.csv")%>">here</a> to
                get a copy of the import template.</span>
        </p>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Import Stories" /></li>
        </ul>
    </div>
    <%
        }
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
