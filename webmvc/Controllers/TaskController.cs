using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class TaskController : Controller
    {
        [Authorize]
        public ActionResult Index(int? projectId, int? categoryId, int? statusId, int? assignedTo, int? isArchived, string text, string sortBy, string sortOrder)
        {
            var model = new TaskIndexModel();

            model.SelectedTab = "Task";
            model.Projects = DataHelper.GetProjectList();
            model.ProjectId = projectId ?? 0;
            model.Categories = DataHelper.GetCategoryList();
            model.CategoryId = categoryId ?? 0;
            model.Statuses = DataHelper.GetStatusList();
            model.StatusId = statusId ?? 0;
            model.AssignedToUsers = DataHelper.GetUserList();
            model.AssignedTo = assignedTo ?? 0;
            model.IsArchived = isArchived ?? 1;
            model.SortBy = sortBy ?? "TaskId";
            model.SortOrder = sortOrder ?? "ASC";
            model.SortableColumns.Add("EstimatedCompletedDate", "Due");
            model.SortableColumns.Add("ProjectName", "Project");
            model.SortableColumns.Add("AssignedToName", "User");
            model.SortableColumns.Add("StatusName", "Status");
            model.SortableColumns.Add("TaskId", "No.");

            var criteria = new TaskCriteria()
                {
                    ProjectId = projectId,
                    CategoryId = categoryId,
                    StatusId = statusId,
                    AssignedTo = assignedTo,
                    IsArchived = DataHelper.ToBoolean(isArchived),
                    Text = text
                };

            var tasks = TaskService.TaskFetchInfoList(criteria)
                .AsQueryable();

            tasks = tasks.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Tasks = tasks;

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskNew();

                this.Map(task, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(TaskFormModel model)
        {
            var task = TaskService.TaskNew();

            Csla.Data.DataMapper.Map(model, task, true, "CompletedDate", "AssignedDate", "StartDate");

            task = TaskService.TaskSave(task);

            if (task.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = task.TaskId }) };
            }

            this.Map(task, model, false);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskFetch(id);

                this.Map(task, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, TaskFormModel model)
        {
            var task = TaskService.TaskFetch(id);

            Csla.Data.DataMapper.Map(model, task, true, "CompletedDate", "AssignedDate", "StartDate");

            task = TaskService.TaskSave(task);

            this.Map(task, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskFetch(id);

                this.Map(task, model, true);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, TaskFormModel model)
        {
            try
            {
                var task = TaskService.TaskFetch(id);

                this.Map(task, model, true);

                TaskService.TaskDelete(id);

                return this.View("DeleteSuccess", model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        public TaskFormModel Map(Task task, TaskFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(task, model, true);

            model.SelectedTab = "Project";
            model.Statuses = DataHelper.GetStatusList();
            model.Categories = DataHelper.GetCategoryList();
            model.Projects = DataHelper.GetProjectList();
            model.Users = DataHelper.GetUserList();
            model.Hours = HourService.HourFetchInfoList(task)
                    .OrderBy(row => row.Date)
                    .AsQueryable();
            model.IsNew = task.IsNew;
            model.IsValid = task.IsValid;

            if (!ignoreBrokenRules)
            {
                foreach (var brokenRule in task.BrokenRulesCollection)
                {
                    this.ModelState.AddModelError(string.Empty, brokenRule.Description);
                }
            }

            return model;
        }
    }
}
