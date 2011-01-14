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
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Helpers
{
    public static class HtmlHelperExtensions
    {
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
            result = Regex.Replace(result, @"[^\w\-]", "");

            if (result.Length > 40)
            {
                result = result.Substring(0, 40);
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
                  project.ProjectId == selectedValue ? " selected=\"selected\"" : string.Empty,
                  project.Name);
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

            result.AppendFormat("<select id=\"{0}\" name=\"{0}\">", "EstimatedDuration");

            result.Append("<option value=\"0\">Select points...</option>");

            result.AppendFormat("<option value=\"0\"{0}>0</option>",
                selectedValue == 0 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"1\"{0}>1</option>",
                selectedValue == 1 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"2\"{0}>2</option>",
                selectedValue == 2 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"3\"{0}>3</option>",
                selectedValue == 3 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"5\"{0}>5</option>",
                selectedValue == 5 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"8\"{0}>8</option>",
                selectedValue == 8 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"13\"{0}>13</option>",
                selectedValue == 13 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"21\"{0}>21</option>",
                selectedValue == 21 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"34\"{0}>34</option>",
                selectedValue == 34 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"68\"{0}>68</option>",
                selectedValue == 68 ? " selected=\"selected\"" : string.Empty);

            result.AppendFormat("<option value=\"100\"{0}>100</option>",
                selectedValue == 100 ? " selected=\"selected\"" : string.Empty);

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