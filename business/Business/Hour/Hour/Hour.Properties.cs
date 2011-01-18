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
    public partial class Hour
    {
        private static Csla.PropertyInfo<int> HourIdProperty =
            RegisterProperty<int>(row => row.HourId, "HourId");
        [DataObjectField(true, false)]
        public int HourId
        {
            get { return this.GetProperty(HourIdProperty); }
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
            get { return this.GetProperty(ProjectNameProperty); }
            internal set { this.SetProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> TaskIdProperty =
            RegisterProperty<int>(row => row.TaskId, "Task");
        public int TaskId
        {
            get { return this.GetProperty(TaskIdProperty); }
            set { this.SetProperty(TaskIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> TaskNameProperty =
            RegisterProperty<string>(row => row.TaskName, "Task Description");
        public string TaskName
        {
            get { return this.GetProperty(TaskNameProperty); }
            internal set { this.SetProperty(TaskNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "User");
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            set { this.SetProperty(UserIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserNameProperty =
            RegisterProperty<string>(row => row.UserName, "UserName");
        public string UserName
        {
            get { return this.GetProperty(UserNameProperty); }
            internal set { this.SetProperty(UserNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> DateProperty =
            RegisterProperty<DateTime>(row => row.Date, "Date");
        public DateTime Date
        {
            get { return this.GetProperty(DateProperty); }
            set { this.SetProperty(DateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            set { this.SetProperty(DurationProperty, value); }
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
        [StringLength(100, ErrorMessage = "Notes must be less than 300 characters")]
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

    }
}
