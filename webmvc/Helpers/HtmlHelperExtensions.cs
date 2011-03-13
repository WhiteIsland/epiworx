using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string FileUpload(this HtmlHelper helper, string name)
        {
            return HtmlHelperExtensions.FileUpload(helper, name, null);
        }

        public static string FileUpload(this HtmlHelper helper, string name, object htmlAttributes)
        {
            var builder = new TagBuilder("input");

            builder.Attributes.Add("type", "file");
            builder.Attributes.Add("id", name);
            builder.Attributes.Add("name", name);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public static MvcHtmlString Message(this HtmlHelper helper, string message)
        {
            var result = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(message))
            {
                result.Append("<div class=\"message\">");
                result.AppendFormat("<p>{0}</p>", message);
                result.Append("</div>");
            }

            return new MvcHtmlString(result.ToString());
        }

        public static string ArchivedBox(this HtmlHelper helper, bool isArchived)
        {
            var result = string.Empty;

            if (isArchived)
            {
                result = "<div class=\"box archived\" title=\"archived\" />";
            }
            else
            {
                result = "<div class=\"box not-archived\" title=\"not archived\" />";
            }

            return result;
        }

        public static string CompletedBox(this HtmlHelper helper, bool isCompleted)
        {
            var result = string.Empty;

            if (isCompleted)
            {
                result = "<div class=\"box complete\" title=\"complete\" />";
            }
            else
            {
                result = "<div class=\"box not-complete\" title=\"not complete\" />";
            }

            return result;
        }

        public static string FirstLastCssClass(
            this HtmlHelper helper,
            int index,
            int count)
        {
            var result = helper.FirstLastCssClass(index, count, string.Empty, "first", "last");

            if (!string.IsNullOrEmpty(result))
            {
                result = string.Format(" class=\"{0}\"", result.Trim());
            }

            return result;
        }

        public static string FirstLastCssClass(
            this HtmlHelper helper,
            int index,
            int count,
            string cssClass,
            string firstCssClass,
            string lastCssClass)
        {
            string result = string.Empty;

            if (index == 0 && count > 1)
            {
                result = string.Format(" {0}", firstCssClass);
            }
            else if (index == count - 1 && count > 1)
            {
                result = string.Format(" {0}", lastCssClass);
            }
            else if (!string.IsNullOrEmpty(cssClass))
            {
                result = string.Format(" {0}", cssClass);
            }

            return result;
        }

        public static string ToTitle(
            this HtmlHelper html,
            object value)
        {
            var result = value.ToString();

            result = result.Replace("&", "and");
            result = result.Replace(" ", "-");
            result = result.Replace(".", "");
            result = Regex.Replace(result, @"[^\w\-]", "");

            if (result.Length > 100)
            {
                result = result.Substring(0, 100);
            }

            result = result.ToLower();

            return MvcHtmlString.Create(result).ToHtmlString();
        }

        public static MvcHtmlString SortedColumnsDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, string> sortableColumns,
            string selectedValue)
        {
            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "SortBy");

            foreach (var sortableColumn in sortableColumns)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   sortableColumn.Key,
                   sortableColumn.Key == selectedValue ? " selected=\"selected\"" : string.Empty,
                   sortableColumn.Value);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString SortedColumnsOrderDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string selectedValue)
        {
            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "SortOrder");

            result.AppendFormat(
               "<option value=\"{0}\"{1}>{2}</option>",
               "ASC",
               "ASC" == selectedValue ? " selected=\"selected\"" : string.Empty,
               "Ascending");

            result.AppendFormat(
               "<option value=\"{0}\"{1}>{2}</option>",
               "DESC",
               "DESC" == selectedValue ? " selected=\"selected\"" : string.Empty,
               "Descending");

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString DateRangeDropDownList(
            this HtmlHelper htmlHelper,
            string name,
            string selectedValue)
        {
            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", name);

            result.AppendFormat(
               "<option value=\"\"{0}>any date range</option>",
               "" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Today\"{0}>Today</option>",
               "Today" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Yesterday\"{0}>Yesterday</option>",
               "Yesterday" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"ThisWeek\"{0}>This Week</option>",
               "ThisWeek" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"LastWeek\"{0}>Last Week</option>",
               "LastWeek" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"ThisMonth\"{0}>This Month</option>",
               "ThisMonth" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"LastMonth\"{0}>Last Month</option>",
               "LastMonth" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last10Days\"{0}>Last 10 Days</option>",
               "Last10Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last30Days\"{0}>Last 30 Days</option>",
               "Last30Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last60Days\"{0}>Last 60 Days</option>",
               "Last60Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last90Days\"{0}>Last 90 Days</option>",
               "Last90Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString DateRangeDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string name,
            string selectedValue)
        {
            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", name);

            result.AppendFormat(
               "<option value=\"\"{0}>any date range</option>",
               "" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Today\"{0}>Today</option>",
               "Today" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Yesterday\"{0}>Yesterday</option>",
               "Yesterday" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"ThisWeek\"{0}>This Week</option>",
               "ThisWeek" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"LastWeek\"{0}>Last Week</option>",
               "LastWeek" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"ThisMonth\"{0}>This Month</option>",
               "ThisMonth" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"LastMonth\"{0}>Last Month</option>",
               "LastMonth" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last10Days\"{0}>Last 10 Days</option>",
               "Last10Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last30Days\"{0}>Last 30 Days</option>",
               "Last30Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last60Days\"{0}>Last 60 Days</option>",
               "Last60Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat(
               "<option value=\"Last90Days\"{0}>Last 90 Days</option>",
               "Last90Days" == selectedValue ? " selected=\"selected\"" : string.Empty);

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString IsArchivedDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            int selectedValue)
        {
            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "IsArchived");

            result.AppendFormat(
               "<option value=\"{0}\"{1}>{2}</option>",
               0,
               0 == selectedValue ? " selected=\"selected\"" : string.Empty,
               "both archived and not archived");

            result.AppendFormat(
               "<option value=\"{0}\"{1}>{2}</option>",
               1,
               1 == selectedValue ? " selected=\"selected\"" : string.Empty,
               "not archived");

            result.AppendFormat(
               "<option value=\"{0}\"{1}>{2}</option>",
               -1,
               -1 == selectedValue ? " selected=\"selected\"" : string.Empty,
               "archived");

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString CategoryDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<ICategory> categories,
            int selectedValue)
        {
            return htmlHelper.CategoryDropDownListFor(expression, categories, selectedValue, "Select a category...", "0");
        }

        public static MvcHtmlString CategoryDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<ICategory> categories,
            int selectedValue,
            string emptyName,
            string emptyValue)
        {
            categories = categories
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "CategoryId");

            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a category...</option>");
            }

            foreach (var category in categories)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   category.CategoryId,
                   category.CategoryId == selectedValue ? " selected=\"selected\"" : string.Empty,
                   category.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString CategoryDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<ICategory> categories,
            int[] selectedValue)
        {
            categories = categories
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "CategoryId");

            foreach (var category in categories)
            {
                result.AppendFormat("<option value=\"{0}\"", category.CategoryId);

                if (selectedValue != null
                    && selectedValue.Contains(category.CategoryId))
                {
                    result.Append(" multiple");
                }

                result.Append(">");
                result.Append(category.Name);
                result.Append("</option>");
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ProjectDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IProject> projects,
            int selectedValue)
        {
            return htmlHelper.ProjectDropDownListFor(expression, projects, selectedValue, "Select a project...", "0");
        }

        public static MvcHtmlString ProjectDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IProject> projects,
            int selectedValue,
            string emptyName,
            string emptyValue)
        {
            projects = projects
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "ProjectId");

            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a project...</option>");
            }

            foreach (var project in projects)
            {
                result.AppendFormat(
                  "<option value=\"{0}\"{1}>{2}</option>",
                  project.ProjectId,
                  selectedValue == project.ProjectId ? " selected=\"selected\"" : string.Empty,
                  project.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ProjectDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IProject> projects,
            int[] selectedValue)
        {
            projects = projects
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "ProjectId");

            foreach (var project in projects)
            {
                result.AppendFormat("<option value=\"{0}\"", project.ProjectId);

                if (selectedValue != null
                    && selectedValue.Contains(project.ProjectId))
                {
                    result.Append(" multiple");
                }

                result.Append(">");
                result.Append(project.Name);
                result.Append("</option>");
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString EstimatedDurationDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            decimal selectedValue)
        {
            var result = new StringBuilder();
            var values = ConfigurationHelper.EstimatedDurations;

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "EstimatedDuration");

            result.Append("<option value=\"0\">Select estimated duration...</option>");

            foreach (var value in values)
            {
                result.AppendFormat("<option value=\"{0}\"", value.Key);
                if (selectedValue == value.Key)
                {
                    result.Append(" selected=\"selected\"");
                }
                result.AppendFormat(">{0}</option>", value.Value);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString EstimatedDurationDropDownList(
            this HtmlHelper htmlHelper)
        {
            var result = new StringBuilder();
            var values = ConfigurationHelper.EstimatedDurations;

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "EstimatedDuration");

            foreach (var value in values)
            {
                result.AppendFormat("<option value=\"{0}\">{0}</option>", value);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString RoleDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<NameValueItem> roles,
            int selectedValue)
        {
            roles = roles
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "Role");

            result.Append("<option value=\"0\">Select a role...</option>");

            foreach (var role in roles)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   role.Value,
                   role.Value.Equals(selectedValue) ? " selected=\"selected\"" : string.Empty,
                   role.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString SprintDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<ISprint> sprints,
            int selectedValue)
        {
            return htmlHelper.SprintDropDownListFor(expression, sprints, selectedValue, "Select a sprint...", "0");
        }

        public static MvcHtmlString SprintDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<ISprint> sprints,
            int selectedValue,
            string emptyName,
            string emptyValue)
        {
            sprints = sprints
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "SprintId");

            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a sprint...</option>");
            }

            foreach (var sprint in sprints)
            {
                result.AppendFormat(
                  "<option value=\"{0}\"{1}>{2}</option>",
                  sprint.SprintId,
                  selectedValue == sprint.SprintId ? " selected=\"selected\"" : string.Empty,
                  sprint.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString StatusDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IStatus> statuses,
            int selectedValue)
        {
            return htmlHelper.StatusDropDownListFor(expression, statuses, selectedValue, "Select a status...", "0");
        }

        public static MvcHtmlString StatusDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IStatus> statuses,
            int selectedValue,
            string emptyName,
            string emptyValue)
        {
            statuses = statuses
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "StatusId");

            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a status...</option>");
            }

            foreach (var status in statuses)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   status.StatusId,
                   status.StatusId == selectedValue ? " selected=\"selected\"" : string.Empty,
                   status.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString StatusDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IStatus> statuses,
            int[] selectedValue)
        {
            statuses = statuses
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "StatusId");

            foreach (var status in statuses)
            {
                result.AppendFormat("<option value=\"{0}\"", status.StatusId);

                if (selectedValue != null
                    && selectedValue.Contains(status.StatusId))
                {
                    result.Append(" multiple");
                }

                result.Append(">");
                result.Append(status.Name);
                result.Append("</option>");
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString UserDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users,
            int selectedValue)
        {
            return htmlHelper.UserDropDownListFor(expression, users, selectedValue, "Select a user...", "0");
        }

        public static MvcHtmlString UserDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users,
            int selectedValue,
            string emptyName,
            string emptyValue)
        {
            users = users
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "UserId");


            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a user...</option>");
            }

            foreach (var user in users)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   user.UserId,
                   user.UserId == selectedValue ? " selected=\"selected\"" : string.Empty,
                   user.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString UserDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users,
            int[] selectedValue)
        {
            users = users
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "UserId");

            foreach (var user in users)
            {
                result.AppendFormat("<option value=\"{0}\"", user.UserId);

                if (selectedValue != null
                    && selectedValue.Contains(user.UserId))
                {
                    result.Append(" multiple");
                }

                result.Append(">");
                result.Append(user.Name);
                result.Append("</option>");
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString AssignedToDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users,
            int selectedValue)
        {
            return htmlHelper.AssignedToDropDownListFor(expression, users, selectedValue, "Select a user...", "0");
        }

        public static MvcHtmlString AssignedToDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users, int selectedValue,
            string emptyName,
            string emptyValue)
        {
            users = users
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "AssignedTo");

            if (!string.IsNullOrEmpty(emptyName))
            {
                result.AppendFormat("<option value=\"{0}\">{1}</option>", emptyValue, emptyName);
            }
            else
            {
                result.Append("<option value=\"0\">Select a user...</option>");
            }

            foreach (var user in users)
            {
                result.AppendFormat(
                   "<option value=\"{0}\"{1}>{2}</option>",
                   user.UserId,
                   user.UserId == selectedValue ? " selected=\"selected\"" : string.Empty,
                   user.Name);
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString AssignedToDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<IUser> users,
            int[] selectedValue)
        {
            users = users
                .OrderBy(row => row.Name);

            var result = new StringBuilder();

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"multiple\" multiple>", "AssignedTo");

            foreach (var user in users)
            {
                result.AppendFormat("<option value=\"{0}\"", user.UserId);

                if (selectedValue != null
                    && selectedValue.Contains(user.UserId))
                {
                    result.Append(" multiple");
                }

                result.Append(">");
                result.Append(user.Name);
                result.Append("</option>");
            }

            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static string Button(
            this HtmlHelper html,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            return string.Format(
                "<input type=\"button\" onclick=\"location.href='{0}';\" value=\"{1}\"/>",
                urlHelper.Action(actionName, controllerName, routeValues),
                linkText);
        }
    }
}