using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class HourInfo
    {
        private static Csla.PropertyInfo<int> HourIdProperty =
            RegisterProperty<int>(row => row.HourId, "HourId");
        public int HourId
        {
            get { return this.GetProperty(HourIdProperty); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            set { this.LoadProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            set { this.LoadProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> TaskIdProperty =
            RegisterProperty<int>(row => row.TaskId, "TaskId");
        public int TaskId
        {
            get { return this.GetProperty(TaskIdProperty); }
            set { this.LoadProperty(TaskIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> TaskNameProperty =
            RegisterProperty<string>(row => row.TaskName, "TaskName");
        public string TaskName
        {
            get { return this.GetProperty(TaskNameProperty); }
            set { this.LoadProperty(TaskNameProperty, value); }
        }

        private static Csla.PropertyInfo<IUser> UserProperty =
            RegisterProperty<IUser>(row => row.User, "User");
        public IUser User
        {
            get { return this.GetProperty(UserProperty); }
            internal set { this.LoadProperty(UserProperty, value); }
        }

        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "UserId");
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            set { this.LoadProperty(UserIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserNameProperty =
            RegisterProperty<string>(row => row.UserName, "UserName");
        public string UserName
        {
            get { return this.GetProperty(UserNameProperty); }
            internal set { this.LoadProperty(UserNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> DateProperty =
            RegisterProperty<DateTime>(row => row.Date, "Date");
        public DateTime Date
        {
            get { return this.GetProperty(DateProperty); }
            set { this.LoadProperty(DateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            set { this.LoadProperty(DurationProperty, value); }
        }

        private static Csla.PropertyInfo<string> LabelsProperty =
            RegisterProperty<string>(row => row.Labels, "Labels");
        public string Labels
        {
            get { return this.GetProperty(LabelsProperty); }
            set { this.LoadProperty(LabelsProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.LoadProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NotesProperty =
            RegisterProperty<string>(row => row.Notes, "Notes");
        public string Notes
        {
            get { return this.GetProperty(NotesProperty); }
            set { this.LoadProperty(NotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            set { this.LoadProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            internal set { this.LoadProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            set { this.LoadProperty(ModifiedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            set { this.LoadProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            internal set { this.LoadProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            set { this.LoadProperty(CreatedDateProperty, value); }
        }

    }
}
