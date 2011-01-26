using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;
using Epiworx.WebMvc.Properties;

namespace Epiworx.WebMvc.Controllers
{
    public class StatusController : BaseController
    {
        [Authorize]
        public ActionResult Create()
        {
            var model = new StatusFormModel();

            try
            {
                var status = StatusService.StatusNew();

                this.Map(status, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(StatusFormModel model)
        {
            var status = StatusService.StatusNew();

            Csla.Data.DataMapper.Map(model, status, true);

            status = StatusService.StatusSave(status);

            if (status.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = status.StatusId, message = Resources.SaveSuccessfulMessage }) };
            }

            this.Map(status, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id, string message)
        {
            var model = new StatusFormModel();

            try
            {
                var status = StatusService.StatusFetch(id);

                model.Message = message;

                this.Map(status, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, StatusFormModel model)
        {
            var status = StatusService.StatusFetch(id);

            Csla.Data.DataMapper.Map(model, status, true);

            status = StatusService.StatusSave(status);

            if (status.IsValid)
            {
                model.Message = Resources.SaveSuccessfulMessage;
            }

            this.Map(status, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            StatusService.StatusDelete(id);

            return this.RedirectToAction("Settings", "Home", null);
        }

        public StatusFormModel Map(Status status, StatusFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(status, model, true);

            model.Tab = "Home";
            model.IsNew = status.IsNew;
            model.IsValid = status.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in status.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
