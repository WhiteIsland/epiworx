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
    public class HourController : Controller
    {
        [Authorize]
        public ActionResult Index(int? projectId, int? userId, int? isArchived, string sortBy, string sortOrder)
        {
            var model = new HourIndexModel();

            model.SelectedTab = "Hour";
            model.Projects = DataHelper.GetProjectList();
            model.ProjectId = projectId ?? 0;
            model.Users = DataHelper.GetUserList();
            model.UserId = userId ?? 0;
            model.IsArchived = isArchived ?? 1;
            model.SortBy = sortBy ?? "Date";
            model.SortOrder = sortOrder ?? "DESC";
            model.SortableColumns.Add("Date", "Date");
            model.SortableColumns.Add("ProjectName", "Project");
            model.SortableColumns.Add("UserName", "User");

            var criteria = new HourCriteria()
            {
                ProjectId = projectId,
                UserId = userId,
                IsArchived = DataHelper.ToBoolean(isArchived)
            };

            var hours = HourService.HourFetchInfoList(criteria)
                .AsQueryable();

            hours = hours.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Hours = hours;

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create(int? taskId)
        {
            var model = new HourFormModel();

            try
            {
                var hour = HourService.HourNew();

                if (taskId.HasValue
                    && taskId.Value != 0)
                {
                    hour.TaskId = taskId.Value;
                }

                this.Map(hour, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int? taskId, HourFormModel model)
        {
            var hour = HourService.HourNew();

            Csla.Data.DataMapper.Map(model, hour, true);

            if (taskId.HasValue
                && taskId.Value != 0)
            {
                hour.TaskId = taskId.Value;
            }
            else
            {
                // don't like that this is in the controller, should really be in the business logic
                // will come back an refactor as unit of work to save both a task and an hour in the
                // business logic ... or maybe a separate object to handle this use case, just need
                // some help

                var task = TaskService.TaskNew();

                task.AssignedTo = hour.UserId;
                task.EstimatedDuration = hour.Duration;

                Csla.Data.DataMapper.Map(model, task, true);

                if (string.IsNullOrEmpty(task.Description))
                {
                    task.Description = hour.Notes;
                }

                if (task.IsValid)
                {
                    task = TaskService.TaskSave(task);

                    hour.TaskId = task.TaskId;

                    model.Task = task;
                }
                else
                {
                    foreach (var brokenRule in task.BrokenRulesCollection)
                    {
                        this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                        this.ModelState.AddModelError(brokenRule.Property, brokenRule.Description);
                    }
                }
            }

            hour = HourService.HourSave(hour);

            if (hour.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = hour.HourId }) };
            }

            if (model.Task != null)
            {
                TaskService.TaskDelete(hour.TaskId);

                hour.TaskId = 0;
            }

            this.Map(hour, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new HourFormModel();

            try
            {
                var hour = HourService.HourFetch(id);

                this.Map(hour, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, HourFormModel model)
        {
            var hour = HourService.HourFetch(id);

            Csla.Data.DataMapper.Map(model, hour, true);

            hour = HourService.HourSave(hour);

            this.Map(hour, model, true);

            return this.PartialView("HourForm", model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            HourService.HourDelete(id);

            return this.RedirectToAction("Index", "Hour");
        }

        public HourFormModel Map(Hour hour, HourFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(hour, model, true);

            model.SelectedTab = "Hour";
            model.Users = DataHelper.GetUserList();
            model.Statuses = DataHelper.GetStatusList();
            model.Categories = DataHelper.GetCategoryList();
            model.Projects = DataHelper.GetProjectList();
            model.IsNew = hour.IsNew;
            model.IsValid = hour.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in hour.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
