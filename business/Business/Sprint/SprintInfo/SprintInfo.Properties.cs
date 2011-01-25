using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class SprintInfo
    {
        private static Csla.PropertyInfo<int> SprintIdProperty =
            RegisterProperty<int>(row => row.SprintId, "SprintId");
        public int SprintId
        {
            get { return this.GetProperty(SprintIdProperty); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.LoadProperty(NameProperty, value); }
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

        private static Csla.PropertyInfo<bool> IsCompletedProperty =
            RegisterProperty<bool>(row => row.IsCompleted, "IsCompleted");
        public bool IsCompleted
        {
            get { return this.GetProperty(IsCompletedProperty); }
            set { this.LoadProperty(IsCompletedProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CompletedDateProperty =
            RegisterProperty<DateTime>(row => row.CompletedDate, "CompletedDate");
        public DateTime CompletedDate
        {
            get { return this.GetProperty(CompletedDateProperty); }
            set { this.LoadProperty(CompletedDateProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> EstimatedCompletedDateProperty =
            RegisterProperty<DateTime>(row => row.EstimatedCompletedDate, "EstimatedCompletedDate");
        public DateTime EstimatedCompletedDate
        {
            get { return this.GetProperty(EstimatedCompletedDateProperty); }
            set { this.LoadProperty(EstimatedCompletedDateProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsActiveProperty =
            RegisterProperty<bool>(row => row.IsActive, "IsActive");
        public bool IsActive
        {
            get { return this.GetProperty(IsActiveProperty); }
            set { this.LoadProperty(IsActiveProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.LoadProperty(IsArchivedProperty, value); }
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
