using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Helpers
{
    public static class FeedHelper
    {
        public static MvcHtmlString ToString(IFeed feed, UrlHelper urlHelper)
        {
            return FeedHelper.ToString(feed, urlHelper, false);
        }

        public static MvcHtmlString ToString(IFeed feed, UrlHelper urlHelper, bool minimal)
        {
            var sb = new StringBuilder();

            try
            {
                sb = sb.AppendFormat(
                     "<a href=\"{0}\">{1}</a> ",
                     urlHelper.Action("Details", "User", new { id = feed.CreatedBy }),
                     feed.CreatedByName);

                var values = feed.Data
                    .Split('|')
                    .ToDictionary(value => value.Split('=')[0].Trim(), value => value.Split('=')[1].Trim());

                if (values.ContainsKey("Action"))
                {
                    sb.AppendFormat(" <strong class=\"action\">{0}</strong> ", values["Action"]);
                }

                switch (feed.Type)
                {
                    case "Attachment":

                        sb = sb.AppendFormat(
                           " the attachment <a href=\"{0}\">{1}</a> ",
                           urlHelper.Action("Details", "Attachment", new { id = values["AttachmentId"] }),
                           DataHelper.ToString(values["Text"], 20));

                        switch ((SourceType)int.Parse(values["SourceType"]))
                        {
                            case SourceType.Task:
                                sb = sb.AppendFormat(
                                   " for the story <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Task", new { id = values["SourceId"] }),
                                   values["SourceId"]);
                                break;
                            case SourceType.Project:
                                sb = sb.AppendFormat(
                                   " for the project <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Project", new { id = values["SourceId"] }),
                                   values["SourceName"]);
                                break;
                            case SourceType.Invoice:
                                sb = sb.AppendFormat(
                                   " for the invoice <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Invoice", new { id = values["SourceId"] }),
                                   values["SourceName"]);
                                break;
                            default:
                                throw new NotImplementedException();
                        }

                        break;

                    case "Category":

                        sb = sb.AppendFormat(
                            " the status <a href=\"{0}\">{1}</a> ",
                            urlHelper.Action("Edit", "Category", new { id = values["CategoryId"] }),
                            values["CategoryName"]);

                        break;

                    case "Hour":

                        sb = sb.AppendFormat(
                            " the hour <a href=\"{0}\">{1}</a> ",
                            urlHelper.Action("Edit", "Hour", new { id = values["HourId"] }),
                            values["Date"]);

                        if (values["TaskId"] != "0")
                        {
                            sb = sb.AppendFormat(
                                 " for task <a href=\"{0}\">{1}</a> ",
                                 urlHelper.Action("Edit", "Task", new { id = values["TaskId"] }),
                                 values["TaskId"]);
                        }

                        sb = sb.AppendFormat(
                              " for the project <a href=\"{0}\">{1}</a> ",
                              urlHelper.Action("Edit", "Project", new { id = values["ProjectId"] }),
                              values["ProjectName"]);

                        break;

                    case "Project":

                        sb = sb.AppendFormat(
                            " the project <a href=\"{0}\">{1}</a> ",
                            urlHelper.Action("Edit", "Project", new { id = values["ProjectId"] }),
                            values["ProjectName"]);

                        break;

                    case "Sprint":

                        sb = sb.AppendFormat(
                             " the sprint <a href=\"{0}\">{1}</a> ",
                             urlHelper.Action("Edit", "Sprint", new { id = values["SprintId"] }),
                             values["SprintName"]);

                        sb = sb.AppendFormat(
                               " for the project <a href=\"{0}\">{1}</a> ",
                               urlHelper.Action("Edit", "Project", new { id = values["ProjectId"] }),
                               values["ProjectName"]);

                        break;

                    case "Status":

                        sb = sb.AppendFormat(
                            " the status <a href=\"{0}\">{1}</a> ",
                            urlHelper.Action("Edit", "Status", new { id = values["StatusId"] }),
                            values["StatusName"]);

                        break;

                    case "Invoice":

                        sb = sb.AppendFormat(
                           " the invoice <a href=\"{0}\">{1}</a> ",
                           urlHelper.Action("Edit", "Invoice", new { id = values["InvoiceId"] }),
                           values["InvoiceNumber"]);

                        sb = sb.AppendFormat(
                               " for the project <a href=\"{0}\">{1}</a> ",
                               urlHelper.Action("Edit", "Project", new { id = values["ProjectId"] }),
                               values["ProjectName"]);

                        break;

                    case "Task":

                        sb = sb.AppendFormat(
                           " the story <a href=\"{0}\">{1}</a> ",
                           urlHelper.Action("Edit", "Task", new { id = values["TaskId"] }),
                           values["TaskId"]);

                        sb = sb.AppendFormat(
                               " for the project <a href=\"{0}\">{1}</a> ",
                               urlHelper.Action("Edit", "Project", new { id = values["ProjectId"] }),
                               values["ProjectName"]);

                        break;

                    case "Note":

                        sb = sb.AppendFormat(
                           " the note <a href=\"{0}\">{1}</a> ",
                           urlHelper.Action("Edit", "Note", new { id = values["NoteId"] }),
                           DataHelper.ToString(values["Text"], 20));

                        switch ((SourceType)int.Parse(values["SourceType"]))
                        {
                            case SourceType.Task:
                                sb = sb.AppendFormat(
                                   " for the story <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Task", new { id = values["SourceId"] }),
                                   values["SourceId"]);
                                break;
                            case SourceType.Project:
                                sb = sb.AppendFormat(
                                   " for the project <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Project", new { id = values["SourceId"] }),
                                   values["SourceName"]);
                                break;
                            case SourceType.Invoice:
                                sb = sb.AppendFormat(
                                   " for the invoice <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "Invoice", new { id = values["SourceId"] }),
                                   values["SourceName"]);
                                break;
                            case SourceType.User:
                                sb = sb.AppendFormat(
                                   " for the user <a href=\"{0}\">{1}</a> ",
                                   urlHelper.Action("Edit", "User", new { id = values["SourceId"] }),
                                   values["SourceName"]);
                                break;
                            default:
                                throw new NotImplementedException(string.Format("The source type '{0}' is not supported", values["SourceType"]));
                        }

                        break;

                    default:
                        throw new NotImplementedException(string.Format("The feed type '{0}' is not supported", feed.Type));
                }

                sb = sb.AppendFormat("<abbr class=\"date\">{0}</abbr>", feed.CreatedDate.ToRelativeDate());

                if (!minimal)
                {
                    sb = sb.Append("<p>");

                    sb = sb.AppendFormat("<img src=\"{0}\" alt=\"{1}\"/>", urlHelper.Gravatar(feed.CreatedByEmail, 32), feed.CreatedByName);

                    sb = sb.Append("<div>");

                    if (values.ContainsKey("Text"))
                    {
                        switch (feed.Type)
                        {
                            case "Category":
                                sb = sb.AppendFormat("{0}'s description", values["CategoryName"]);
                                break;
                            case "Attachment":
                            case "Hour":
                            case "Sprint":
                                sb = sb.Append("Additional notes");
                                break;
                            case "Project":
                                sb = sb.AppendFormat("{0}'s description", values["ProjectName"]);
                                break;
                            case "Task":
                                sb = sb.AppendFormat("{0}'s description", values["TaskId"]);
                                break;
                            case "Note":
                                sb = sb.Append("Note's description");
                                break;
                            case "Status":
                                sb = sb.AppendFormat("{0}'s description", values["StatusName"]);
                                break;
                            default:
                                break;
                        }

                        sb = sb.AppendFormat("<blockquote>{0}</blockquote>", string.IsNullOrWhiteSpace(values["Text"]) ? "None" : values["Text"]);
                    }

                    sb = sb.Append("</div>");

                    sb = sb.Append("</p>");
                }
            }
            catch (Exception ex)
            {
                sb = sb.AppendFormat(
                    "<span class=\"error\">Error occurred for FeedId {0} with a message of {1}</span>", feed.FeedId,
                    ex.Message);
            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}