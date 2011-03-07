using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Models
{
    public class TaskByCategoryListModel : ModelListBase
    {
        public IEnumerable<ITask> Tasks { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
    }

    public class TaskByStatusListModel : ModelListBase
    {
        public IEnumerable<ITask> Tasks { get; set; }
        public IEnumerable<IStatus> Statuses { get; set; }
    }

    public class TaskImportModel : ModelListBase
    {
        public IEnumerable<ITask> Tasks { get; set; }
    }

    public class TaskIndexModel : TaskListModel
    {
        public int[] ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDisplayName { get; set; }
        public int[] CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDisplayName { get; set; }
        public int[] StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDisplayName { get; set; }
        public int[] AssignedTo { get; set; }
        public string AssignedToName { get; set; }
        public string AssignedToDisplayName { get; set; }
        public int IsArchived { get; set; }
    }

    public class TaskFindModel : ModelListBase
    {
        [DisplayName("Select one or more projects:")]
        public int[] ProjectId { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
        [DisplayName("Select one or more categories:")]
        public int[] CategoryId { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
        [DisplayName("Select one or more statuses:")]
        public int[] StatusId { get; set; }
        public IEnumerable<IStatus> Statuses { get; set; }
        [DisplayName("Select one or more users:")]
        public int[] AssignedTo { get; set; }
        public IEnumerable<IUser> Users { get; set; }
    }

    public class TaskListModel : ModelListBase
    {
        public bool HideUserColumn { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
        public IEnumerable<IStatus> Statuses { get; set; }
        public IEnumerable<ITask> Tasks { get; set; }
        public IEnumerable<IUser> AssignedToUsers { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
        public LabelByCountListModel LabelByCountListModel { get; set; }

        public TaskListModel()
        {
            this.HideUserColumn = false;
        }
    }

    public class TaskFormModel : ModelBusinessBase
    {
        public int TaskId { get; set; }

        [DisplayName("Project:")]
        [IntegerRequired(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }

        [DisplayName("Category:")]
        [IntegerRequired(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [DisplayName("Status:")]
        [IntegerRequired(ErrorMessage = "Status is required")]
        public int StatusId { get; set; }

        [DisplayName("Describe the work that needs to be performed:")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [DisplayName("Sprint:")]
        public int SprintId { get; set; }

        [DisplayName("Assigned to:")]
        public int AssignedTo { get; set; }

        [DisplayName("Assigned date:")]
        public DateTime AssignedDate { get; set; }

        [DisplayName("Start date:")]
        public DateTime StartDate { get; set; }

        [DisplayName("Completed date:")]
        public DateTime CompletedDate { get; set; }

        [DisplayName("Estimated completed date:")]
        public DateTime EstimatedCompletedDate { get; set; }

        [DisplayName("Duration:")]
        public decimal Duration { get; set; }

        [DisplayName("Points:")]
        public decimal EstimatedDuration { get; set; }

        [DisplayName("Labels:")]
        public string Labels { get; set; }

        [DisplayName("Enter some notes that provide more detail about the task:")]
        public string Notes { get; set; }

        [DisplayName("This task is archived")]
        public bool IsArchived { get; set; }

        public IEnumerable<IStatus> Statuses { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
        public IEnumerable<IUser> Users { get; set; }
        public IEnumerable<IHour> Hours { get; set; }
        public IEnumerable<ISprint> Sprints { get; set; }
        public LabelListModel LabelListModel { get; set; }
        public NoteListModel NoteListModel { get; set; }
        public AttachmentListModel AttachmentListModel { get; set; }
    }
}