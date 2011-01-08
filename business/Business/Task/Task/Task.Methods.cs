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
                case "StatusId":
                    this.OnStatusChanged();
                    break;
                case "EstimatedCompletedDate":
                    this.OnEstimatedCompletedDateChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnStatusChanged()
        {
            if (this.StatusId == 0)
            {
                return;
            }

            this.Status = Epiworx.Business.Status.FetchStatus(new StatusCriteria { StatusId = this.StatusId });

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
