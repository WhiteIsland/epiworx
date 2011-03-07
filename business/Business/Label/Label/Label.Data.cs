using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Label
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(LabelCriteria criteria)
        {
            this.LoadProperty(SourceTypeProperty, criteria.SourceType);
            this.LoadProperty(SourceIdProperty, criteria.SourceId);
            this.LoadProperty(NameProperty, criteria.Name);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(LabelCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Labels
                    .Include("CreatedByUser")
                    .Single(row => row.SourceId == criteria.SourceId
                        && row.SourceType == (int)criteria.SourceType
                        && row.Name == criteria.Name);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Label data)
        {
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(NameProperty, data.Name);
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
                var data = new Data.Label();

                this.Insert(data);

                ctx.ObjectContext.AddToLabels(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Label data)
        {
            data.SourceId = this.ReadProperty(SourceIdProperty);
            data.SourceType = (int)this.ReadProperty(SourceTypeProperty);
            data.Name = this.ReadProperty(NameProperty);
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
                var data = new Data.Label
                {
                    SourceId = this.ReadProperty(SourceIdProperty),
                    SourceType = (int)this.ReadProperty(SourceTypeProperty),
                    Name = this.ReadProperty(NameProperty)
                };

                ctx.ObjectContext.Labels.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

            }
        }

        protected void Update(Data.Label data)
        {
            if (this.IsSelfDirty)
            {
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Label
                {
                    SourceId = this.ReadProperty(SourceIdProperty),
                    SourceType = (int)this.ReadProperty(SourceTypeProperty),
                    Name = this.ReadProperty(NameProperty)
                };

                ctx.ObjectContext.Labels.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(LabelCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Labels
                    .Single(row => row.SourceId == criteria.SourceId
                        && row.SourceType == (int)criteria.SourceType
                        && row.Name == criteria.Name);

                ctx.ObjectContext.Labels.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}