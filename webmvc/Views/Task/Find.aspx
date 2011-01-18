<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.TaskFindModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Find Story
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (this.Html.BeginForm())
        {
    %>
    <h2>
        Find<span>Story</span></h2>
    <fieldset>
        <p class="span1">
            <%: this.Html.LabelFor(m => m.ProjectId) %>
            <%: this.Html.ProjectDropDownListFor(m => m.ProjectId, this.Model.Projects, this.Model.ProjectId)%>
        </p>
    </fieldset>
    <div class="commands">
        <ul>
            <li>
                <input type="submit" value="Find" /></li>
        </ul>
    </div>
    <% 
        } 
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
