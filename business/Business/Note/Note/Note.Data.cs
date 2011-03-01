using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Note
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(NoteCriteria criteria)
        {
            this.LoadProperty(SourceTypeProperty, criteria.SourceType);
            this.LoadProperty(SourceIdProperty, criteria.SourceId);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(NoteCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Notes
                    .Include("ModifiedByUser")
                    .Include("CreatedByUser")
                    .Single(row => row.NoteId == criteria.NoteId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Note data)
        {
            this.LoadProperty(NoteIdProperty, data.NoteId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(BodyProperty, data.Body);
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
                var data = new Data.Note();

                this.Insert(data);

                ctx.ObjectContext.AddToNotes(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(NoteIdProperty, data.NoteId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Note data)
        {
            data.NoteId = this.ReadProperty(NoteIdProperty);
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
                var data = new Data.Note
                {
                    NoteId = this.ReadProperty(NoteIdProperty)
                };

                ctx.ObjectContext.Notes.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Note data)
        {
            if (this.IsSelfDirty)
            {
                data.SourceType = (int)this.ReadProperty(SourceTypeProperty);
                data.SourceId = this.ReadProperty(SourceIdProperty);
                data.Body = this.ReadProperty(BodyProperty);
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
                var data = new Data.Note
                {
                    NoteId = this.ReadProperty(NoteIdProperty)
                };

                ctx.ObjectContext.Notes.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(NoteCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Notes
                    .Single(row => row.NoteId == criteria.NoteId);

                ctx.ObjectContext.Notes.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}