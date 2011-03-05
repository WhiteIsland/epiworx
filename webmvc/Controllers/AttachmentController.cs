using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;
using Epiworx.WebMvc.Properties;

namespace Epiworx.WebMvc.Controllers
{
    public class AttachmentController : BaseController
    {
        [Authorize]
        public ActionResult Index(int? sourceType, int? sourceId, string sortBy, string sortOrder)
        {
            var model = new AttachmentIndexModel();

            model.Tab = "Task";

            model.SortBy = sortBy ?? "Name";
            model.SortOrder = sortOrder ?? "ASC";
            model.SortableColumns.Add("Name", "Name");

            var criteria = new AttachmentCriteria()
            {
                SourceType = DataHelper.ToSourceType(sourceType)
            };

            var attachments = AttachmentService.AttachmentFetchInfoList(criteria)
                .AsQueryable();

            attachments = attachments.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Attachments = attachments;

            return this.View(model);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var attachment = AttachmentService.AttachmentFetch(id);

            var ms = new System.IO.MemoryStream(attachment.FileData, 0, attachment.FileData.Length);

            return new FileStreamResult(ms, attachment.FileType);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(int sourceType, int sourceId, AttachmentFormModel model)
        {
            var attachment = AttachmentService.AttachmentNew((SourceType)sourceType, sourceId);

            Csla.Data.DataMapper.Map(model, attachment, true);

            var fs = model.FileData.InputStream;
            var fileData = new byte[model.FileData.ContentLength];
            fs.Read(fileData, 0, model.FileData.ContentLength);

            attachment.FileData = fileData;
            attachment.Name = Path.GetFileName(model.FileData.FileName);
            attachment.FileType = model.FileData.ContentType;

            attachment = AttachmentService.AttachmentSave(attachment);

            if (attachment.IsValid)
            {
                attachment = AttachmentService.AttachmentFetch(attachment.AttachmentId);

                this.Map(attachment, model, true);
            }

            return PartialView("AttachmentUserControl", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            AttachmentService.AttachmentDelete(id);

            return this.Json(new { success = true });
        }

        public AttachmentFormModel Map(Attachment attachment, AttachmentFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(attachment, model, true);

            model.Tab = "Task";
            model.IsNew = attachment.IsNew;
            model.IsValid = attachment.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in attachment.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
