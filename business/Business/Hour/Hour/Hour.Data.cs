using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Hour
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(DateProperty, DateTime.Now.Date);
            this.LoadProperty(UserIdProperty, BusinessPrincipal.GetCurrentIdentity().UserId);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(HourCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Hours
                    .Include("Project")
                    .Include("Task")
                    .Include("User")
                    .Single(row => row.HourId == criteria.HourId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Hour data)
        {
            this.LoadProperty(HourIdProperty, data.HourId);
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Project.Name);
            this.LoadProperty(TaskIdProperty, data.TaskId);
            this.LoadProperty(TaskNameProperty, data.TaskName);
            this.LoadProperty(UserProperty, UserInfo.FetchUserInfo(data.User));
            this.LoadProperty(UserIdProperty, data.UserId);
            this.LoadProperty(UserNameProperty, data.User.Name);
            this.LoadProperty(DateProperty, data.Date);
            this.LoadProperty(DurationProperty, data.Duration);
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
                var data = new Data.Hour();

                this.Insert(data);

                ctx.ObjectContext.AddToHours(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(HourIdProperty, data.HourId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Hour data)
        {
            data.HourId = this.ReadProperty(HourIdProperty);
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
                var data = new Data.Hour
                {
                    HourId = this.ReadProperty(HourIdProperty)
                };

                ctx.ObjectContext.Hours.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Hour data)
        {
            if (this.IsSelfDirty)
            {
                data.ProjectId = this.ReadProperty(ProjectIdProperty);
                data.TaskId = this.ReadProperty(TaskIdProperty);
                data.UserId = this.ReadProperty(UserIdProperty);
                data.Date = this.ReadProperty(DateProperty);
                data.Duration = this.ReadProperty(DurationProperty);
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
                var data = new Data.Hour
                {
                    HourId = this.ReadProperty(HourIdProperty)
                };

                ctx.ObjectContext.Hours.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(HourCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Hours
                    .Single(row => row.HourId == criteria.HourId);

                ctx.ObjectContext.Hours.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}