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
    public class TaskController : BaseController
    {
        [Authorize]
        public ActionResult Index(int[] projectId, int[] categoryId, int[] statusId, int? sprintId, int[] assignedTo, string completedDate, string modifiedDate, string createdDate, int? isArchived, string label, string text, string sortBy, string sortOrder)
        {
            var model = new TaskIndexModel();

            model.Tab = "Task";

            model.Projects = DataHelper.GetProjectList();
            model.ProjectId = projectId ?? new int[0];
            model.ProjectName = DataHelper.ToString(model.Projects, model.ProjectId, "any project");
            model.ProjectDisplayName = DataHelper.Clip(model.ProjectName, 40);

            model.Categories = DataHelper.GetCategoryList();
            model.CategoryId = categoryId ?? new int[0];
            model.CategoryName = DataHelper.ToString(model.Categories, model.CategoryId, "any category");
            model.CategoryDisplayName = DataHelper.Clip(model.CategoryName, 20);

            model.Statuses = DataHelper.GetStatusList();
            model.StatusId = statusId ?? new int[0];
            model.StatusName = DataHelper.ToString(model.Statuses, model.StatusId, "any status");
            model.StatusDisplayName = DataHelper.Clip(model.StatusName, 20);

            model.AssignedToUsers = DataHelper.GetUserList();
            model.AssignedTo = assignedTo ?? new int[0];
            model.AssignedToName = DataHelper.ToString(model.AssignedToUsers, model.AssignedTo, "any user");
            model.AssignedToDisplayName = DataHelper.Clip(model.AssignedToName, 20);

            model.Label = label;
            model.IsArchived = isArchived ?? 0;

            model.Filters = MyService.FilterFetchInfoList("Task");

            model.SortBy = sortBy ?? "TaskId";
            model.SortOrder = sortOrder ?? "ASC";
            model.SortableColumns.Add("EstimatedCompletedDate", "Due");
            model.SortableColumns.Add("ProjectName", "Project");
            model.SortableColumns.Add("AssignedToName", "User");
            model.SortableColumns.Add("StatusName", "Status");
            model.SortableColumns.Add("TaskId", "No.");

            model.LabelByCountListModel =
                new LabelByCountListModel
                {
                    Action = "Task",
                    Label = label,
                    Labels = DataHelper.GetTaskLabelByCountList()
                };

            var criteria = new TaskCriteria()
                {
                    ProjectId = projectId,
                    SprintId = sprintId,
                    CategoryId = categoryId,
                    StatusId = statusId,
                    AssignedTo = assignedTo,
                    CompletedDate = new DateRangeCriteria(completedDate ?? string.Empty),
                    ModifiedDate = new DateRangeCriteria(modifiedDate ?? string.Empty),
                    CreatedDate = new DateRangeCriteria(createdDate ?? string.Empty),
                    IsArchived = DataHelper.ToBoolean(isArchived),
                    TaskLabels = string.IsNullOrEmpty(label) ? null : new[] { label },
                    Text = text
                };

            var tasks = TaskService.TaskFetchInfoList(criteria)
                .AsQueryable();

            tasks = tasks.OrderBy(string.Format("{0} {1}", model.SortBy, model.SortOrder));

            model.Tasks = tasks;

            var hours = HourService.HourFetchInfoList(tasks.Cast<ITask>().ToArray());

            model.Hours = hours;

            return RespondTo(format =>
            {
                format[RequestExtension.Html] = () => this.View(model);
                format[RequestExtension.Xml] = () => new XmlResult { Data = model.Tasks.ToList(), TableName = "Task" };
                format[RequestExtension.Json] = () => new JsonResult { Data = model.Tasks, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            });
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskNew();

                this.MapToModel(task, model, true);
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

            this.MapToObject(model, task);

            task = TaskService.TaskSave(task);

            if (task.IsValid)
            {
                return new JsonResult { Data = this.Url.Action("Edit", new { id = task.TaskId, message = Resources.SaveSuccessfulMessage }) };
            }

            this.MapToModel(task, model, false);

            return this.View(model);
        }

        [Authorize]
        public void Export(int[] projectId, int[] categoryId, int[] statusId, int? sprintId, int[] assignedTo, string completedDate, string modifiedDate, string createdDate, int? isArchived, string text, string sortBy, string sortOrder)
        {
            var criteria = new TaskCriteria()
            {
                ProjectId = projectId,
                SprintId = sprintId,
                CategoryId = categoryId,
                StatusId = statusId,
                AssignedTo = assignedTo,
                CompletedDate = new DateRangeCriteria(completedDate ?? string.Empty),
                ModifiedDate = new DateRangeCriteria(modifiedDate ?? string.Empty),
                CreatedDate = new DateRangeCriteria(createdDate ?? string.Empty),
                IsArchived = DataHelper.ToBoolean(isArchived, false),
                Text = text
            };

            var tasks = TaskService.TaskFetchInfoList(criteria)
                .AsQueryable();

            tasks = tasks.OrderBy(string.Format("{0} {1}", sortBy ?? "TaskId", sortOrder ?? "ASC"));

            var sw = new StringWriter();

            sw.WriteLine(
                "TaskId,ProjectName,SprintName,CategoryName,StatusName,Description,AssignedToName,AssignedDate,StartDate,CompletedDate,EstimatedCompletedDate,Duration,EstimatedDuration,Labels,IsArchived,Notes,ModifiedByName,ModifiedDate,CreatedByName,CreatedByDate");

            foreach (var task in tasks)
            {
                var sb = new StringBuilder();

                sb.AppendFormat("{0},", task.TaskId);
                sb.AppendFormat("\"{0}\",", task.ProjectName);
                sb.AppendFormat("\"{0}\",", task.SprintName);
                sb.AppendFormat("{0},", task.CategoryName);
                sb.AppendFormat("{0},", task.StatusName);
                sb.AppendFormat("\"{0}\",", task.Description.Replace("\"", "'"));
                sb.AppendFormat("{0},", task.AssignedToName);
                sb.AppendFormat("{0},", task.AssignedDate);
                sb.AppendFormat("{0},", task.StartDate);
                sb.AppendFormat("{0},", task.CompletedDate);
                sb.AppendFormat("{0},", task.EstimatedCompletedDate);
                sb.AppendFormat("{0},", task.Duration);
                sb.AppendFormat("{0},", task.EstimatedDuration);
                sb.AppendFormat("\"{0}\",", task.Labels);
                sb.AppendFormat("{0},", task.IsArchived);
                sb.AppendFormat("\"{0}\",", task.Notes);
                sb.AppendFormat("{0},", task.ModifiedByName);
                sb.AppendFormat("{0},", task.ModifiedDate);
                sb.AppendFormat("{0},", task.CreatedByName);
                sb.AppendFormat("{0}", task.CreatedDate);

                sw.WriteLine(sb.ToString());
            }

            this.Response.AddHeader("Content-Disposition", "attachment; filename=Stories.csv");
            this.Response.ContentType = "application/ms-excel";
            this.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            this.Response.Write(sw);
            this.Response.End();
        }

        [Authorize]
        public ActionResult Import()
        {
            var model = new TaskImportModel();

            model.Tab = "Task";

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Import(HttpPostedFileBase file)
        {
            var model = new TaskImportModel();

            model.Tab = "Task";

            model.Tasks = ImportHelper.ImportStories(this, file);

            if (this.ModelState.IsValid)
            {
                return this.View("ImportSuccess", model);

            }

            return this.View(model);
        }

        [Authorize]
        public ActionResult Edit(int id, string message)
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskFetch(id);

                model.Message = message;

                this.MapToModel(task, model, true);
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

            this.MapToObject(model, task);

            task = TaskService.TaskSave(task);

            if (task.IsValid)
            {
                model.Message = Resources.SaveSuccessfulMessage;
            }

            this.MapToModel(task, model, true);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = new TaskFormModel();

            try
            {
                var task = TaskService.TaskFetch(id);

                this.MapToModel(task, model, true);
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

                this.MapToModel(task, model, true);

                TaskService.TaskDelete(id);

                return this.View("DeleteSuccess", model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(model);
        }

        private void MapToModel(Task task, TaskFormModel model, bool ignoreBrokenRules)
        {
            Csla.Data.DataMapper.Map(task, model, true, "Labels");

            model.Tab = "Task";
            model.Statuses = DataHelper.GetStatusList();
            model.Categories = DataHelper.GetCategoryList();
            model.Projects = DataHelper.GetProjectList();
            model.Sprints = DataHelper.GetSprintList(task.ProjectId);
            model.Users = DataHelper.GetUserList();

            if (!task.IsNew)
            {
                model.Hours = HourService.HourFetchInfoList(task)
                        .OrderBy(row => row.Date)
                        .AsQueryable();

                model.NoteListModel =
                    new NoteListModel
                    {
                        Source = task,
                        Notes = NoteService.NoteFetchInfoList(task).AsQueryable()
                    };

                model.LabelListModel =
                    new LabelListModel
                    {
                        Action = "Task",
                        Labels = task.TaskLabels.Select(row => row.Name)
                    };

                model.AttachmentListModel =
                    new AttachmentListModel
                    {
                        Source = task,
                        Attachments = AttachmentService.AttachmentFetchInfoList(task).AsQueryable()
                    };
            }

            switch (ConfigurationHelper.LabelMode)
            {
                case ConfigurationMode.Simple:
                    model.Labels = task.Labels;
                    break;
                case ConfigurationMode.Advanced:
                    model.Labels = task.TaskLabels.ToString();
                    break;
                default:
                    break;
            }

            model.IsNew = task.IsNew;
            model.IsValid = task.IsValid;

            if (ignoreBrokenRules)
            {
                return;
            }

            foreach (var brokenRule in task.BrokenRulesCollection)
            {
                this.ModelState.AddModelError(string.Empty, brokenRule.Description);
            }
        }

        private void MapToObject(TaskFormModel model, Task task)
        {
            Csla.Data.DataMapper.Map(
                model, task, true, "EstimatedCompletedDate", "CompletedDate", "AssignedDate", "StartDate", "Labels");

            if (model.Labels == null)
            {
                return;
            }

            switch (ConfigurationHelper.LabelMode)
            {
                case ConfigurationMode.Simple:
                    task.Labels = model.Labels;
                    break;
                case ConfigurationMode.Advanced:
                    var labels = model.Labels.Split(' ');

                    foreach (var label in labels.Where(label => !task.TaskLabels.Contains(label)))
                    {
                        task.TaskLabels.Add(label);
                    }

                    var taskLabelsToRemove = (from taskLabel
                                                  in task.TaskLabels
                                              where !labels.Contains(taskLabel.Name)
                                              select taskLabel.Name)
                        .ToList();

                    foreach (var taskLabel in taskLabelsToRemove)
                    {
                        task.TaskLabels.Remove(taskLabel);
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
