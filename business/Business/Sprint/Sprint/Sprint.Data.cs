using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(CompletedDateProperty, DateTime.MaxValue.Date);
            this.LoadProperty(EstimatedCompletedDateProperty, DateTime.MaxValue.Date);
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SprintCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Sprints
                    .Single(row => row.SprintId == criteria.SprintId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Sprint data)
        {
            this.LoadProperty(SprintIdProperty, data.SprintId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(ProjectIdProperty, data.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Project.Name);
            this.LoadProperty(IsCompletedProperty, data.IsCompleted);
            this.LoadProperty(CompletedDateProperty, data.CompletedDate);
            this.LoadProperty(EstimatedCompletedDateProperty, data.EstimatedCompletedDate);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
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
                var data = new Data.Sprint();

                this.Insert(data);

                ctx.ObjectContext.AddToSprints(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(SprintIdProperty, data.SprintId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Sprint data)
        {
            data.SprintId = this.ReadProperty(SprintIdProperty);
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
                var data = new Data.Sprint
                {
                    SprintId = this.ReadProperty(SprintIdProperty)
                };

                ctx.ObjectContext.Sprints.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Sprint data)
        {
            if (this.IsSelfDirty)
            {
                data.Name = this.ReadProperty(NameProperty);
                data.ProjectId = this.ReadProperty(ProjectIdProperty);
                data.IsCompleted = this.ReadProperty(IsCompletedProperty);
                data.CompletedDate = this.ReadProperty(CompletedDateProperty);
                data.EstimatedCompletedDate = this.ReadProperty(EstimatedCompletedDateProperty);
                data.IsActive = this.ReadProperty(IsActiveProperty);
                data.IsArchived = this.ReadProperty(IsArchivedProperty);
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
                var data = new Data.Sprint
                {
                    SprintId = this.ReadProperty(SprintIdProperty)
                };

                ctx.ObjectContext.Sprints.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SprintCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Sprints
                    .Single(row => row.SprintId == criteria.SprintId);

                ctx.ObjectContext.Sprints.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}