<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FeedListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Feeds</h4>
    <ul class="feed">
        <% foreach (var feed in this.Model.Feeds)
           {
        %>
        <li class="<%: feed.Type.ToLower() %>">
            <%: FeedHelper.ToString(feed, this.Url, true) %>
            <div class="clear">
            </div>
        </li>
        <%
       }
        %>
        <li>
        <%: this.Html.ActionLink("Show all feeds", "Index", "Feed") %>
        </li>
    </ul>
</div>
