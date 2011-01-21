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

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        public ActionResult Index(int? isArchived, string sortBy, string sortOrder)
        {
            var model = new ProjectIndexModel();

            model.Tab = "Project";

            model.IsArchived = isArchived ?? 1;

            model.SortBy = sortBy ?? "Name";
            model.SortOrder = sortOrder ?? "ASC";
            model.SortableColumns.Add("Name", "Name");

            var criteria = new ProjectCriteria()
            {
                IsArchived = DataHelper.ToBoolean(isArchived, false)
            };

            var projects = ProjectService.ProjectFetchInfoList(criteria)
                .AsQueryable();

            projects = projects.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Projects = projects;

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new ProjectFormModel();

            try
            {
                var project = ProjectService.ProjectNew();

                this.Map(project, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ProjectFormModel model)
        {
            var project = ProjectService.ProjectNew();

            Csla.Data.DataMapper.Map(model, project, true);

            project = ProjectService.ProjectSave(project);

            if (project.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = project.ProjectId }) };
            }

            this.Map(project, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new ProjectFormModel();

            try
            {
                var project = ProjectService.ProjectFetch(id);

                this.Map(project, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, ProjectFormModel model)
        {
            var project = ProjectService.ProjectFetch(id);

            Csla.Data.DataMapper.Map(model, project, true);

            project = ProjectService.ProjectSave(project);

            this.Map(project, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = new ProjectFormModel();

            try
            {
                var project = ProjectService.ProjectFetch(id);

                this.Map(project, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, ProjectFormModel model)
        {
            try
            {
                var project = ProjectService.ProjectFetch(id);

                this.Map(project, model, true);

                ProjectService.ProjectDelete(id);

                return this.View("DeleteSuccess", model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        public ProjectFormModel Map(Project project, ProjectFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(project, model, true);

            model.Tab = "Project";
            model.IsNew = project.IsNew;
            model.IsValid = project.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in project.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
