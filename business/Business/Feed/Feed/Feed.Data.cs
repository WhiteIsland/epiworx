using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Feed
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(FeedCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Feeds
                    .Include("CreatedByUser")
                    .Single(row => row.FeedId == criteria.FeedId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Feed data)
        {
            this.LoadProperty(FeedIdProperty, data.FeedId);
            this.LoadProperty(TypeProperty, data.Type);
            this.LoadProperty(DataProperty, data.Data);
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
                var data = new Data.Feed();

                this.Insert(data);

                ctx.ObjectContext.AddToFeeds(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(FeedIdProperty, data.FeedId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Feed data)
        {
            data.FeedId = this.ReadProperty(FeedIdProperty);
            data.CreatedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
            data.CreatedDate = DateTime.Now;

            this.Update(data);
        }

        protected void Update(Data.Feed data)
        {
            if (this.IsSelfDirty)
            {
                data.Type = this.ReadProperty(TypeProperty);
                data.Data = this.ReadProperty(DataProperty);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Feed
                {
                    FeedId = this.ReadProperty(FeedIdProperty)
                };

                ctx.ObjectContext.Feeds.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(FeedCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Feeds
                    .Single(row => row.FeedId == criteria.FeedId);

                ctx.ObjectContext.Feeds.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}