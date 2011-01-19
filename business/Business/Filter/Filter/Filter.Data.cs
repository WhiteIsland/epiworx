using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Filter
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Filter> query = ctx.ObjectContext.Filters;

                if (criteria.FilterId != null)
                {
                    query = query.Where(row => row.FilterId == criteria.FilterId);
                }

                var data = query.Single();

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Filter data)
        {
            this.LoadProperty(FilterIdProperty, data.FilterId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(TargetProperty, data.Target);
            this.LoadProperty(QueryProperty, data.Query);
            this.LoadProperty(IsActiveProperty, data.IsActive);
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
                var data = new Data.Filter();

                this.Insert(data);

                ctx.ObjectContext.AddToFilters(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(FilterIdProperty, data.FilterId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Filter data)
        {
            data.FilterId = this.ReadProperty(FilterIdProperty);
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
                var data = new Data.Filter
                {
                    FilterId = this.ReadProperty(FilterIdProperty)
                };

                ctx.ObjectContext.Filters.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Filter data)
        {
            if (this.IsSelfDirty)
            {
                data.Name = this.ReadProperty(NameProperty);
                data.Target = this.ReadProperty(TargetProperty);
                data.Query = this.ReadProperty(QueryProperty);
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
                var data = new Data.Filter
                {
                    FilterId = this.ReadProperty(FilterIdProperty)
                };

                ctx.ObjectContext.Filters.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(FilterCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Filters
                    .Single(row => row.FilterId == criteria.FilterId);

                ctx.ObjectContext.Filters.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}