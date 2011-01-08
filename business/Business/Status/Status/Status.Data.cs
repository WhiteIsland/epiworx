using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Status
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(StatusCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Status> query = ctx.ObjectContext.Statuses;

                if (criteria.StatusId != null)
                {
                    query = query.Where(row => row.StatusId == criteria.StatusId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                var data = query.Single();


                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Status data)
        {
            this.LoadProperty(StatusIdProperty, data.StatusId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(OrdinalProperty, data.Ordinal);
            this.LoadProperty(ForeColorProperty, data.ForeColor);
            this.LoadProperty(BackColorProperty, data.BackColor);
            this.LoadProperty(IsStartedProperty, data.IsStarted);
            this.LoadProperty(IsCompletedProperty, data.IsCompleted);
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
                var data = new Data.Status();

                this.Insert(data);

                ctx.ObjectContext.AddToStatuses(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(StatusIdProperty, data.StatusId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Status data)
        {
            data.StatusId = this.ReadProperty(StatusIdProperty);
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
                var data = new Data.Status
                {
                    StatusId = this.ReadProperty(StatusIdProperty)
                };

                ctx.ObjectContext.Statuses.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Status data)
        {
            if (this.IsSelfDirty)
            {
                data.Name = this.ReadProperty(NameProperty);
                data.Description = this.ReadProperty(DescriptionProperty);
                data.Ordinal = this.ReadProperty(OrdinalProperty);
                data.ForeColor = this.ReadProperty(ForeColorProperty);
                data.BackColor = this.ReadProperty(BackColorProperty);
                data.IsStarted = this.ReadProperty(IsStartedProperty);
                data.IsCompleted = this.ReadProperty(IsCompletedProperty);
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
                var data = new Data.Status
                {
                    StatusId = this.ReadProperty(StatusIdProperty)
                };

                ctx.ObjectContext.Statuses.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(StatusCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Statuses
                    .Single(row => row.StatusId == criteria.StatusId);

                ctx.ObjectContext.Statuses.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}