<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.FeedListModel>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<ul class="feed">
    <% foreach (var feed in this.Model.Feeds)
       {
    %>
    <li class="<%: feed.Type.ToLower() %>">
       <%: FeedHelper.ToString(feed, this.Url) %>
       <div class="clear"></div>
    </li>
    <%
           }
    %>
</ul>
