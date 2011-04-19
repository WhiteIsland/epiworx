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
    public class SprintController : BaseController
    {
        [Authorize]
        public ActionResult Create(int projectId)
        {
            var model = new SprintFormModel();

            try
            {
                var sprint = SprintService.SprintNew();

                sprint.ProjectId = projectId;

                this.MapToModel(sprint, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [Authorize]
        public ActionResult List(int projectId)
        {
            var sprints = DataHelper.GetSprintList(projectId);

            return RespondTo(format =>
            {
                format[RequestExtension.Json] = () => new JsonResult { Data = sprints, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(SprintFormModel model)
        {
            var sprint = SprintService.SprintNew();

            Csla.Data.DataMapper.Map(model, sprint, true, "ProjectName");

            sprint = SprintService.SprintSave(sprint);

            if (sprint.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = sprint.SprintId, message = Resources.SaveSuccessfulMessage }) };
            }

            this.MapToModel(sprint, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id, string message)
        {
            var model = new SprintFormModel();

            try
            {
                var sprint = SprintService.SprintFetch(id);

                model.Message = message;

                this.MapToModel(sprint, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, SprintFormModel model)
        {
            var sprint = SprintService.SprintFetch(id);

            Csla.Data.DataMapper.Map(model, sprint, true, "ProjectName");

            sprint = SprintService.SprintSave(sprint);

            if (sprint.IsValid)
            {
                model.Message = Resources.SaveSuccessfulMessage;
            }

            this.MapToModel(sprint, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var sprint = SprintService.SprintFetch(id);

            SprintService.SprintDelete(id);

            return this.RedirectToAction("Edit", "Project", new { id = sprint.ProjectId });
        }

        public SprintFormModel MapToModel(Sprint sprint, SprintFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(sprint, model, true);

            model.Tab = "Project";
            model.Projects = DataHelper.GetProjectList();
            model.IsNew = sprint.IsNew;
            model.IsValid = sprint.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in sprint.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
