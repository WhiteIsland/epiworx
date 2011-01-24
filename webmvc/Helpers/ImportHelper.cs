using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Controllers;
using Microsoft.VisualBasic.FileIO;

namespace Epiworx.WebMvc.Helpers
{
    public class ImportHelper
    {
        public const int TaskColumnCount = 20;
        public const int TaskTaskIdColumn = 0;
        public const int TaskProjectNameColumn = 1;
        public const int TaskSprintNameColumn = 2;
        public const int TaskCategoryNameColumn = 3;
        public const int TaskStatusNameColumn = 4;
        public const int TaskDescriptionColumn = 5;
        public const int TaskAssignedToNameColumn = 6;
        public const int TaskAssignedDateColumn = 7;
        public const int TaskStartDateColumn = 8;
        public const int TaskCompletedDateColumn = 9;
        public const int TaskEstimatedCompletedDateColumn = 10;
        public const int TaskDurationColumn = 11;
        public const int TaskEstimatedDurationColumn = 12;
        public const int TaskLabelsColumn = 13;
        public const int TaskIsArchivedColumn = 14;
        public const int TaskNotesColumn = 15;
        public const int TaskModifiedByNameColumn = 16;
        public const int TaskModifiedDateColumn = 17;
        public const int TaskCreatedByNameColumn = 18;
        public const int TaskCreatedByDateColumn = 19;

        public static IEnumerable<ITask> ImportStories(TaskController controller, HttpPostedFileBase file)
        {
            if (file == null)
            {
                controller.ModelState.AddModelError(string.Empty, "File is required");
                return null;
            }

            if (file.ContentLength == 0)
            {
                controller.ModelState.AddModelError(string.Empty, "File with a size greater than 0 is required");
                return null;
            }

            if (!file.FileName.EndsWith(".csv"))
            {
                controller.ModelState.AddModelError(string.Empty, "Only comma separate value (.csv) files are allowed");
                return null;
            }

            var tasks = new List<Task>();

            using (var sr = new TextFieldParser(file.InputStream))
            {
                sr.TextFieldType = FieldType.Delimited;
                sr.SetDelimiters(",");
                sr.HasFieldsEnclosedInQuotes = true;

                int lineIndex = 0;

                var projects = DataHelper.GetProjectList();
                var sprints = DataHelper.GetSprintList();
                var users = DataHelper.GetUserList();
                var statuses = DataHelper.GetStatusList();
                var categories = DataHelper.GetCategoryList();

                while (!sr.EndOfData)
                {
                    lineIndex++;

                    var values = sr.ReadFields();

                    if (lineIndex == 1) // skip the first line, as it has headers
                    {
                        continue;
                    }

                    try
                    {
                        Task task;

                        if (int.Parse(values[ImportHelper.TaskTaskIdColumn]) == 0)
                        {
                            task = TaskService.TaskNew();
                        }
                        else
                        {
                            task = TaskService.TaskFetch(int.Parse(values[ImportHelper.TaskTaskIdColumn]));
                        }

                        task.ProjectId = projects.Single(row =>
                            row.Name == values[ImportHelper.TaskProjectNameColumn]).ProjectId;

                        if (sprints.Any(row =>
                            row.Name == values[ImportHelper.TaskSprintNameColumn]))
                        {
                            task.SprintId = sprints.Single(row =>
                                row.Name == values[ImportHelper.TaskSprintNameColumn]).SprintId;
                        }

                        task.CategoryId = categories.Single(row =>
                            row.Name == values[ImportHelper.TaskCategoryNameColumn]).CategoryId;
                        task.StatusId = statuses.Single(row =>
                            row.Name == values[ImportHelper.TaskStatusNameColumn]).StatusId;
                        task.Description = values[ImportHelper.TaskDescriptionColumn];

                        if (string.IsNullOrWhiteSpace(values[ImportHelper.TaskAssignedToNameColumn]))
                        {
                            task.AssignedTo = 0;
                        }
                        else
                        {
                            task.AssignedTo = users.Single(row =>
                               row.Name == values[ImportHelper.TaskAssignedToNameColumn]).UserId;
                        }

                        task.AssignedDate = DateTime.Parse(values[ImportHelper.TaskAssignedDateColumn]).Date;
                        task.StartDate = DateTime.Parse(values[ImportHelper.TaskStartDateColumn]).Date;
                        task.CompletedDate = DateTime.Parse(values[ImportHelper.TaskCompletedDateColumn]).Date;
                        task.EstimatedCompletedDate = DateTime.Parse(values[ImportHelper.TaskEstimatedCompletedDateColumn]).Date;
                        task.Duration = decimal.Parse(values[ImportHelper.TaskDurationColumn]);
                        task.EstimatedDuration = decimal.Parse(values[ImportHelper.TaskEstimatedDurationColumn]);
                        task.Labels = values[ImportHelper.TaskLabelsColumn];
                        task.IsArchived = bool.Parse(values[ImportHelper.TaskIsArchivedColumn]);
                        task.Notes = values[ImportHelper.TaskNotesColumn];

                        tasks.Add(task);

                        if (!task.IsValid)
                        {
                            controller.ModelState.AddModelError(string.Empty,
                                 string.Format("Row [{0}] has the following broken rules: {1}", lineIndex, task.BrokenRulesCollection.ToString(",")));
                        }
                    }
                    catch (Exception ex)
                    {
                        controller.ModelState.AddModelError(string.Empty,
                            string.Format("Row [{0}] encountered the following error: {1}", lineIndex, ex));
                    }
                }

                if (controller.ModelState.IsValid)
                {
                    foreach (var task in tasks)
                    {
                        TaskService.TaskSave(task);
                    }

                    return tasks;
                }
            }

            return null;
        }
    }
}