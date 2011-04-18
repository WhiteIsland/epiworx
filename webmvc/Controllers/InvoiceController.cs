using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;
using Epiworx.WebMvc.Properties;

namespace Epiworx.WebMvc.Controllers
{
    public class InvoiceController : BaseController
    {
        [Authorize]
        public ActionResult Index(int[] projectId, int? taskId, string date, string number, string modifiedDate, string createdDate, int? isArchived, string label, string text, string sortBy, string sortOrder)
        {
            var model = new InvoiceIndexModel();

            model.Tab = "Invoice";
            model.FindCategory = "Invoice";
            model.FindText = text;

            model.Projects = DataHelper.GetProjectList();
            model.ProjectId = projectId ?? new int[0];
            model.ProjectName = DataHelper.ToString(model.Projects, model.ProjectId, "any project");
            model.ProjectDisplayName = DataHelper.Clip(model.ProjectName, 40);

            model.Date = date ?? string.Empty;
            model.IsArchived = isArchived ?? 0;

            model.Filters = MyService.FilterFetchInfoList("Invoice");

            model.SortBy = sortBy ?? "InvoiceId";
            model.SortOrder = sortOrder ?? "DESC";
            model.SortableColumns.Add("InvoiceId", "No.");
            model.SortableColumns.Add("ProjectName", "Project");
            model.SortableColumns.Add("Number", "User");
            model.SortableColumns.Add("TaskId", "Task");

            var criteria = new InvoiceCriteria()
                {
                    ProjectId = projectId,
                    TaskId = taskId,
                    Number = number,
                    PreparedDate = new DateRangeCriteria(model.Date),
                    ModifiedDate = new DateRangeCriteria(modifiedDate ?? string.Empty),
                    CreatedDate = new DateRangeCriteria(createdDate ?? string.Empty),
                    IsArchived = DataHelper.ToBoolean(isArchived),
                    Text = text
                };

            var invoices = InvoiceService.InvoiceFetchInfoList(criteria)
                .AsQueryable();

            invoices = invoices.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Invoices = invoices;

            return RespondTo(format =>
            {
                format[RequestExtension.Html] = () => this.View(model);
                format[RequestExtension.Xml] = () => new XmlResult { Data = model.Invoices.ToList(), TableName = "Invoice" };
                format[RequestExtension.Json] = () => new JsonResult { Data = model.Invoices, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });
        }

        [Authorize]
        public ActionResult Create(int taskId)
        {
            var model = new InvoiceFormModel();

            try
            {
                var invoice = InvoiceService.InvoiceNew(taskId);

                this.MapToModel(invoice, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int taskId, InvoiceFormModel model)
        {
            var invoice = InvoiceService.InvoiceNew(taskId);

            this.MapToObject(model, invoice);

            invoice = InvoiceService.InvoiceSave(invoice);

            if (invoice.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = invoice.InvoiceId, message = Resources.SaveSuccessfulMessage }) };
            }

            this.MapToModel(invoice, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Import()
        {
            var model = new InvoiceImportModel();

            model.Tab = "Invoice";

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Import(HttpPostedFileBase file)
        {
            var model = new InvoiceImportModel();

            model.Tab = "Invoice";

            model.Invoices = ImportHelper.ImportInvoices(this, file);

            if (this.ModelState.IsValid)
            {
                return this.View("ImportSuccess", model);

            }

            return this.View(model);
        }

        [Authorize]
        public void Export(int[] projectId, int? taskId, string modifiedDate, string createdDate, int? isArchived, string text, string sortBy, string sortOrder)
        {
            var criteria = new InvoiceCriteria()
            {
                ProjectId = projectId,
                TaskId = taskId,
                ModifiedDate = new DateRangeCriteria(modifiedDate ?? string.Empty),
                CreatedDate = new DateRangeCriteria(createdDate ?? string.Empty),
                IsArchived = DataHelper.ToBoolean(isArchived, false),
                Text = text
            };

            var invoices = InvoiceService.InvoiceFetchInfoList(criteria)
                .AsQueryable();

            invoices = invoices.OrderBy(string.Format("{0} {1}", sortBy ?? "InvoiceId", sortOrder ?? "ASC"));

            var sw = new StringWriter();

            sw.WriteLine(
                "InvoiceId,Number,TaskId,PreparedDate,ProjectName,Description,Amount,IsArchived,Notes,ModifiedByName,ModifiedDate,CreatedByName,CreatedByDate");

            foreach (var invoice in invoices)
            {
                var sb = new StringBuilder();

                sb.AppendFormat("{0},", invoice.InvoiceId);
                sb.AppendFormat("\"{0}\",", invoice.Number);
                sb.AppendFormat("{0},", invoice.TaskId);
                sb.AppendFormat("{0},", invoice.PreparedDate);
                sb.AppendFormat("\"{0}\",", invoice.ProjectName);
                sb.AppendFormat("\"{0}\",", invoice.Description.Replace("\"", "'"));
                sb.AppendFormat("{0},", invoice.Amount);
                sb.AppendFormat("{0},", invoice.IsArchived);
                sb.AppendFormat("\"{0}\",", invoice.Notes);
                sb.AppendFormat("{0},", invoice.ModifiedByName);
                sb.AppendFormat("{0},", invoice.ModifiedDate);
                sb.AppendFormat("{0},", invoice.CreatedByName);
                sb.AppendFormat("{0}", invoice.CreatedDate);

                sw.WriteLine(sb.ToString());
            }

            this.Response.AddHeader("Content-Disposition", "attachment; filename=Invoices.csv");
            this.Response.ContentType = "application/ms-excel";
            this.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            this.Response.Write(sw);
            this.Response.End();
        }

        [Authorize]
        public ActionResult Edit(int id, string message)
        {
            var model = new InvoiceFormModel();

            try
            {
                var invoice = InvoiceService.InvoiceFetch(id);

                model.Message = message;

                this.MapToModel(invoice, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, InvoiceFormModel model)
        {
            var invoice = InvoiceService.InvoiceFetch(id);

            this.MapToObject(model, invoice);

            invoice = InvoiceService.InvoiceSave(invoice);

            if (invoice.IsValid)
            {
                model.Message = Resources.SaveSuccessfulMessage;
            }

            this.MapToModel(invoice, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = new InvoiceFormModel();

            try
            {
                var invoice = InvoiceService.InvoiceFetch(id);

                this.MapToModel(invoice, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, InvoiceFormModel model)
        {
            try
            {
                var invoice = InvoiceService.InvoiceFetch(id);

                this.MapToModel(invoice, model, true);

                InvoiceService.InvoiceDelete(id);

                return this.View("DeleteSuccess", model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        private void MapToModel(Invoice invoice, InvoiceFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(invoice, model, true, "Labels");

            model.Tab = "Invoice";
            model.FindCategory = "Invoice";

            if (!invoice.IsNew)
            {
                model.NoteListModel =
                    new NoteListModel
                    {
                        Source = invoice,
                        Notes = NoteService.NoteFetchInfoList(invoice).AsQueryable()
                    };

                model.AttachmentListModel =
                    new AttachmentListModel
                    {
                        Source = invoice,
                        Attachments = AttachmentService.AttachmentFetchInfoList(invoice).AsQueryable()
                    };
            }

            model.IsNew = invoice.IsNew;
            model.IsValid = invoice.IsValid;

            if (ignoreBrokenRules)
            {
                return;
            }

            foreach (var brokenRule in invoice.BrokenRulesCollection)
            {
                this.ModelState.AddModelError(string.Empty, brokenRule.Description);
            }
        }

        private void MapToObject(InvoiceFormModel model, Invoice invoice)
        {
            Csla.Data.DataMapper.Map(
                model, invoice, true, "ProjectId", "ProjectName");
        }
    }
}
