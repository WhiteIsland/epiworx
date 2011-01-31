<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Epiworx.WebMvc.Models.FeedIndexModel>" %>

<%@ Import Namespace="Epiworx.WebMvc.Models" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Epiworx - Feeds
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Feeds</h2>
    <% this.Html.RenderPartial("FeedFilter", this.Model);%>
    <% this.Html.RenderPartial("FeedListUserControl", new FeedListModel { Feeds = this.Model.Feeds });%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarContent" runat="server">
</asp:Content>
