using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Epiworx.Business
{
    public partial class Task
    {
        public override string ToString()
        {
            return string.Format("{0}", this.TaskId);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                case "AssignedTo":
                    this.OnAssignedToChanged();
                    break;
                case "CategoryId":
                    this.OnCategoryIdChanged();
                    break;
                case "EstimatedCompletedDate":
                    this.OnEstimatedCompletedDateChanged();
                    break;
                case "ProjectId":
                    this.OnProjectIdChanged();
                    break;
                case "StatusId":
                    this.OnStatusIdChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnAssignedToChanged()
        {
            this.LoadProperty(AssignedToNameProperty, ForeignKeyMapper.FetchUserName(this.AssignedTo));
        }

        private void OnCategoryIdChanged()
        {
            this.LoadProperty(CategoryProperty, ForeignKeyMapper.FetchCategory(this.CategoryId));
            this.LoadProperty(CategoryNameProperty, this.Category.Name);
        }

        private void OnProjectIdChanged()
        {
            this.LoadProperty(ProjectProperty, ForeignKeyMapper.FetchProject(this.ProjectId));
            this.LoadProperty(ProjectNameProperty, this.Project.Name);
        }

        private void OnStatusIdChanged()
        {
            this.LoadProperty(StatusProperty, ForeignKeyMapper.FetchStatus(this.StatusId));
            this.LoadProperty(StatusNameProperty, this.Status.Name);

            if (this.StatusId == 0)
            {
                return;
            }

            if (this.Status.IsStarted)
            {
                this.StartDate = DateTime.Now.Date;
                this.CompletedDate = DateTime.MaxValue.Date;
            }

            if (this.Status.IsCompleted)
            {
                this.CompletedDate = DateTime.Now.Date;
                if (this.EstimatedCompletedDate == DateTime.MaxValue.Date)
                {
                    this.EstimatedCompletedDate = this.CompletedDate;
                }
            }
        }

        private void OnEstimatedCompletedDateChanged()
        {
            if (this.CompletedDate != DateTime.MaxValue.Date
                && this.EstimatedCompletedDate == DateTime.MaxValue.Date)
            {
                this.EstimatedCompletedDate = this.CompletedDate;
            }
        }

        internal static Task NewTask()
        {
            return Csla.DataPortal.Create<Task>();
        }

        internal static Task FetchTask(TaskCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Task>(criteria);
        }

        internal static void DeleteTask(TaskCriteria criteria)
        {
            var task = Task.FetchTask(criteria);

            if (!Task.CanDeleteObject(task))
            {
                throw new SecurityException("Only users with full control can delete and archived task");
            }

            Csla.DataPortal.Delete<Task>(criteria);
        }

        public override Task Save()
        {
            if (this.IsDirty
                && !this.IsNew
                && !Task.CanSaveObject(this))
            {
                throw new SecurityException("Only users with full control can edit or delete and archived task");
            }

            return base.Save();
        }
    }
}
