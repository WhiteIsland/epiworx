using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Task
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(AssignedDateProperty, DateTime.MaxValue.Date);
            this.LoadProperty(StartDateProperty, DateTime.MaxValue.Date);
            this.LoadProperty(CompletedDateProperty, DateTime.MaxValue.Date);
            this.LoadProperty(EstimatedCompletedDateProperty, DateTime.MaxValue.Date);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(TaskCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Tasks
                    .Include("Category")
                    .Include("Status")
                    .Include("Project")
                    .Include("Sprint")
                    .Include("AssignedToUser")
                    .Single(row => row.TaskId == criteria.TaskId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Task data)
        {
            this.LoadProperty(TaskIdProperty, data.TaskId);
            this.LoadProperty(ProjectProperty, ProjectInfo.FetchProjectInfo(data.Project));
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Project.Name);
            this.LoadProperty(SprintProperty, SprintInfo.FetchSprintInfo(data.Sprint));
            this.LoadProperty(SprintIdProperty, data.SprintId);
            this.LoadProperty(SprintNameProperty, data.SprintName);
            this.LoadProperty(CategoryProperty, CategoryInfo.FetchCategoryInfo(data.Category));
            this.LoadProperty(CategoryIdProperty, data.CategoryId);
            this.LoadProperty(CategoryNameProperty, data.Category.Name);
            this.LoadProperty(StatusProperty, StatusInfo.FetchStatusInfo(data.Status));
            this.LoadProperty(StatusIdProperty, data.StatusId);
            this.LoadProperty(StatusNameProperty, data.Status.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(AssignedToProperty, data.AssignedTo);
            this.LoadProperty(AssignedToNameProperty, data.AssignedToUser == null ? "No one" : data.AssignedToUser.Name);
            this.LoadProperty(AssignedDateProperty, data.AssignedDate);
            this.LoadProperty(StartDateProperty, data.StartDate);
            this.LoadProperty(CompletedDateProperty, data.CompletedDate);
            this.LoadProperty(EstimatedCompletedDateProperty, data.EstimatedCompletedDate);
            this.LoadProperty(DurationProperty, data.Duration);
            this.LoadProperty(EstimatedDurationProperty, data.EstimatedDuration);
            this.LoadProperty(LabelsProperty, data.Labels);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
            this.LoadProperty(NotesProperty, data.Notes);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedByNameProperty, data.ModifiedByUser.Name);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Task();

                this.Insert(data);

                ctx.ObjectContext.AddToTasks(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(TaskIdProperty, data.TaskId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Task data)
        {
            data.TaskId = this.ReadProperty(TaskIdProperty);
            data.CreatedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
            data.CreatedDate = DateTime.Now;

            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Task
                {
                    TaskId = this.ReadProperty(TaskIdProperty)
                };

                ctx.ObjectContext.Tasks.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Task data)
        {
            if (this.IsSelfDirty)
            {
                data.ProjectId = this.ReadProperty(ProjectIdProperty);
                data.SprintId = this.ReadProperty(SprintIdProperty);
                data.CategoryId = this.ReadProperty(CategoryIdProperty);
                data.StatusId = this.ReadProperty(StatusIdProperty);
                data.Description = this.ReadProperty(DescriptionProperty);
                data.AssignedTo = this.ReadProperty(AssignedToProperty);
                data.AssignedDate = this.ReadProperty(AssignedDateProperty);
                data.StartDate = this.ReadProperty(StartDateProperty);
                data.CompletedDate = this.ReadProperty(CompletedDateProperty);
                data.EstimatedCompletedDate = this.ReadProperty(EstimatedCompletedDateProperty);
                data.Duration = this.ReadProperty(DurationProperty);
                data.EstimatedDuration = this.ReadProperty(EstimatedDurationProperty);
                data.Labels = this.ReadProperty(LabelsProperty);
                data.IsArchived = this.ReadProperty(IsArchivedProperty);
                data.Notes = this.ReadProperty(NotesProperty);
                data.ModifiedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                data.ModifiedDate = DateTime.Now;
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Task
                {
                    TaskId = this.ReadProperty(TaskIdProperty)
                };

                ctx.ObjectContext.Tasks.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(TaskCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Tasks
                    .Single(row => row.TaskId == criteria.TaskId);

                ctx.ObjectContext.Tasks.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}