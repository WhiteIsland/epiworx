using System;
using System.Collections.Generic;
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
    public class NoteController : BaseController
    {
        [Authorize]
        public ActionResult Index(int? sourceType, int? sourceId, string sortBy, string sortOrder)
        {
            var model = new NoteIndexModel();

            model.Tab = "Task";

            model.SortBy = sortBy ?? "Name";
            model.SortOrder = sortOrder ?? "ASC";
            model.SortableColumns.Add("Name", "Name");

            var criteria = new NoteCriteria()
            {
                SourceType = DataHelper.ToSourceType(sourceType)
            };

            var notes = NoteService.NoteFetchInfoList(criteria)
                .AsQueryable();

            notes = notes.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Notes = notes;

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(int sourceType, int sourceId, NoteFormModel model)
        {
            var note = NoteService.NoteNew((SourceType)sourceType, sourceId);

            Csla.Data.DataMapper.Map(model, note, true);

            note = NoteService.NoteSave(note);

            if (note.IsValid)
            {
                note = NoteService.NoteFetch(note.NoteId);

                this.Map(note, model, true);

                model.IsNew = true;

                return PartialView("NoteUserControl", model);
            }

            this.Map(note, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create(int sourceType, int sourceId)
        {
            var model = new NoteFormModel();

            try
            {
                var note = NoteService.NoteNew((SourceType)sourceType, sourceId);

                this.Map(note, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int sourceType, int sourceId, NoteFormModel model)
        {
            var note = NoteService.NoteNew((SourceType)sourceType, sourceId);

            Csla.Data.DataMapper.Map(model, note, true);

            note = NoteService.NoteSave(note);

            if (note.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = note.NoteId, message = Resources.SaveSuccessfulMessage }) };
            }

            this.Map(note, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id, string message)
        {
            var model = new NoteFormModel();

            try
            {
                var note = NoteService.NoteFetch(id);

                model.Message = message;

                this.Map(note, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, NoteFormModel model)
        {
            var note = NoteService.NoteFetch(id);

            Csla.Data.DataMapper.Map(model, note, true);

            note = NoteService.NoteSave(note);

            if (note.IsValid)
            {
                model.Message = Resources.SaveSuccessfulMessage;
            }

            this.Map(note, model, true);

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            NoteService.NoteDelete(id);

            return new JsonResult();
        }

        public NoteFormModel Map(Note note, NoteFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(note, model, true);

            model.Tab = "Task";
            model.IsNew = note.IsNew;
            model.IsValid = note.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in note.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
