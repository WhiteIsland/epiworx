<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Epiworx.Business.IProject>>" %>
<%@ Import Namespace="Epiworx.WebMvc.Helpers" %>
<div class="part">
    <h4>
        Projects</h4>
    <% if (this.Model.Count() == 0)
       {
    %>
    <p class="no-records">
        No records found.</p>
    <%
       }
       else
       {%>
    <ul>
        <%
           foreach (var project in this.Model.OrderBy(row => row.Name))
           {
        %>
        <li>
             <%:this.Html.ActionLink(
                project.Name, "Edit", "Project", new {id = project.ProjectId, title = this.Html.ToTitle(project.Name)}, null)%>
        </li>
        <%
           }%>
    </ul>
    <%
       }%>
   <div class="total">
        Total Projects<span>
            <%: string.Format("{0:N0}", this.Model.Count())%></span>
    </div>
</div>
