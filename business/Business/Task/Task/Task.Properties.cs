using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Task
    {
        private static Csla.PropertyInfo<int> TaskIdProperty =
            RegisterProperty<int>(row => row.TaskId, "TaskId");
        [DataObjectField(true, false)]
        public int TaskId
        {
            get { return this.GetProperty(TaskIdProperty); }
        }

        private static Csla.PropertyInfo<IProject> ProjectProperty =
            RegisterProperty<IProject>(row => row.Project, "Project");
        public IProject Project
        {
            get { return this.ReadProperty(ProjectProperty); }
            internal set { this.LoadProperty(ProjectProperty, value); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "Project");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            set { this.SetProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.ReadProperty(ProjectNameProperty); }
            internal set { this.LoadProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<ISprint> SprintProperty =
            RegisterProperty<ISprint>(row => row.Sprint, "Sprint");
        public ISprint Sprint
        {
            get { return this.ReadProperty(SprintProperty); }
            internal set { this.LoadProperty(SprintProperty, value); }
        }

        private static Csla.PropertyInfo<int> SprintIdProperty =
            RegisterProperty<int>(row => row.SprintId, "Sprint");
        public int SprintId
        {
            get { return this.GetProperty(SprintIdProperty); }
            set { this.SetProperty(SprintIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SprintNameProperty =
            RegisterProperty<string>(row => row.SprintName, "SprintName");
        public string SprintName
        {
            get { return this.ReadProperty(SprintNameProperty); }
            internal set { this.LoadProperty(SprintNameProperty, value); }
        }

        private static Csla.PropertyInfo<ICategory> CategoryProperty =
            RegisterProperty<ICategory>(row => row.Category, "Category");
        public ICategory Category
        {
            get { return this.ReadProperty(CategoryProperty); }
            internal set { this.LoadProperty(CategoryProperty, value); }
        }

        private static Csla.PropertyInfo<int> CategoryIdProperty =
            RegisterProperty<int>(row => row.CategoryId, "Category");
        public int CategoryId
        {
            get { return this.GetProperty(CategoryIdProperty); }
            set { this.SetProperty(CategoryIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> CategoryNameProperty =
            RegisterProperty<string>(row => row.CategoryName, "CategoryName");
        public string CategoryName
        {
            get { return this.ReadProperty(CategoryNameProperty); }
            internal set { this.LoadProperty(CategoryNameProperty, value); }
        }

        private static Csla.PropertyInfo<IStatus> StatusProperty =
            RegisterProperty<IStatus>(row => row.Status, "Status");
        public IStatus Status
        {
            get { return this.ReadProperty(StatusProperty); }
            internal set { this.LoadProperty(StatusProperty, value); }
        }

        private static Csla.PropertyInfo<int> StatusIdProperty =
            RegisterProperty<int>(row => row.StatusId, "Status");
        public int StatusId
        {
            get { return this.GetProperty(StatusIdProperty); }
            set { this.SetProperty(StatusIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> StatusNameProperty =
            RegisterProperty<string>(row => row.StatusName, "StatusName");
        public string StatusName
        {
            get { return this.ReadProperty(StatusNameProperty); }
            internal set { this.LoadProperty(StatusNameProperty, value); }
        }

        private static Csla.PropertyInfo<string> DescriptionProperty =
            RegisterProperty<string>(row => row.Description, "Description");
        [Required(ErrorMessage = "Description is required")]
        [StringLength(4000, ErrorMessage = "Description must be less than 4000 characters")]
        public string Description
        {
            get { return this.GetProperty(DescriptionProperty); }
            set { this.SetProperty(DescriptionProperty, value); }
        }

        private static Csla.PropertyInfo<int> AssignedToProperty =
            RegisterProperty<int>(row => row.AssignedTo, "Assigned");
        public int AssignedTo
        {
            get { return this.GetProperty(AssignedToProperty); }
            set { this.SetProperty(AssignedToProperty, value); }
        }

        private static Csla.PropertyInfo<string> AssignedToNameProperty =
            RegisterProperty<string>(row => row.AssignedToName, "AssignedToName");
        public string AssignedToName
        {
            get { return this.ReadProperty(AssignedToNameProperty); }
            set { this.LoadProperty(AssignedToNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> AssignedDateProperty =
            RegisterProperty<DateTime>(row => row.AssignedDate, "AssignedDate");
        public DateTime AssignedDate
        {
            get { return this.GetProperty(AssignedDateProperty); }
            set { this.SetProperty(AssignedDateProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> StartDateProperty =
            RegisterProperty<DateTime>(row => row.StartDate, "StartDate");
        public DateTime StartDate
        {
            get { return this.GetProperty(StartDateProperty); }
            set { this.SetProperty(StartDateProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CompletedDateProperty =
            RegisterProperty<DateTime>(row => row.CompletedDate, "CompletedDate");
        public DateTime CompletedDate
        {
            get { return this.GetProperty(CompletedDateProperty); }
            set { this.SetProperty(CompletedDateProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> EstimatedCompletedDateProperty =
            RegisterProperty<DateTime>(row => row.EstimatedCompletedDate, "EstimatedCompletedDate");
        public DateTime EstimatedCompletedDate
        {
            get { return this.GetProperty(EstimatedCompletedDateProperty); }
            set { this.SetProperty(EstimatedCompletedDateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            internal set { this.SetProperty(DurationProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> EstimatedDurationProperty =
            RegisterProperty<decimal>(row => row.EstimatedDuration, "EstimatedDuration");
        public decimal EstimatedDuration
        {
            get { return this.GetProperty(EstimatedDurationProperty); }
            set { this.SetProperty(EstimatedDurationProperty, value); }
        }

        private static Csla.PropertyInfo<int> NumberOfInvoicesProperty =
            RegisterProperty<int>(row => row.NumberOfInvoices, "NumberOfInvoices");
        public int NumberOfInvoices
        {
            get { return this.GetProperty(NumberOfInvoicesProperty); }
            set { this.LoadProperty(NumberOfInvoicesProperty, value); }
        }

        private static Csla.PropertyInfo<int> NumberOfNotesProperty =
            RegisterProperty<int>(row => row.NumberOfNotes, "NumberOfNotes");
        public int NumberOfNotes
        {
            get { return this.GetProperty(NumberOfNotesProperty); }
            internal set { this.LoadProperty(NumberOfNotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> NumberOfAttachmentsProperty =
            RegisterProperty<int>(row => row.NumberOfAttachments, "NumberOfAttachments");
        public int NumberOfAttachments
        {
            get { return this.GetProperty(NumberOfAttachmentsProperty); }
            internal set { this.LoadProperty(NumberOfAttachmentsProperty, value); }
        }

        private static Csla.PropertyInfo<string> LabelsProperty =
            RegisterProperty<string>(row => row.Labels, "Labels");
        [StringLength(100, ErrorMessage = "Labels must be less than 100 characters")]
        public string Labels
        {
            get { return this.GetProperty(LabelsProperty); }
            set { this.SetProperty(LabelsProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.SetProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NotesProperty =
            RegisterProperty<string>(row => row.Notes, "Notes");
        [StringLength(300, ErrorMessage = "Notes must be less than 300 characters")]
        public string Notes
        {
            get { return this.GetProperty(NotesProperty); }
            set { this.SetProperty(NotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            internal set { this.SetProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            internal set { this.SetProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            internal set { this.SetProperty(ModifiedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            internal set { this.SetProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            internal set { this.SetProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            internal set { this.SetProperty(CreatedDateProperty, value); }
        }

        public static Csla.PropertyInfo<TaskLabels> TaskLabelsProperty =
            RegisterProperty<TaskLabels>(row => row.TaskLabels);
        public TaskLabels TaskLabels
        {
            get
            {
                if (!FieldManager.FieldExists(TaskLabelsProperty))
                {
                    this.LoadProperty(TaskLabelsProperty, Csla.DataPortal.CreateChild<TaskLabels>());
                    this.OnPropertyChanged(TaskLabelsProperty);
                }
                return this.GetProperty(TaskLabelsProperty);
            }
        }
    }
}
