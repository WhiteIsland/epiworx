using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Attachment
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(AttachmentCriteria criteria)
        {
            this.LoadProperty(SourceTypeProperty, criteria.SourceType);
            this.LoadProperty(SourceIdProperty, criteria.SourceId);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(AttachmentCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Attachments
                    .Single(row => row.AttachmentId == criteria.AttachmentId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Attachment data)
        {
            this.LoadProperty(AttachmentIdProperty, data.AttachmentId);
            this.LoadProperty(SourceTypeProperty, data.SourceType);
            this.LoadProperty(SourceIdProperty, data.SourceId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(FileTypeProperty, data.FileType);
            this.LoadProperty(FileDataProperty, data.FileData);
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
                var data = new Data.Attachment();

                this.Insert(data);

                ctx.ObjectContext.AddToAttachments(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(AttachmentIdProperty, data.AttachmentId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Attachment data)
        {
            data.AttachmentId = this.ReadProperty(AttachmentIdProperty);
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
                var data = new Data.Attachment
                {
                    AttachmentId = this.ReadProperty(AttachmentIdProperty)
                };

                ctx.ObjectContext.Attachments.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Attachment data)
        {
            if (this.IsSelfDirty)
            {
                data.SourceType = (int)this.ReadProperty(SourceTypeProperty);
                data.SourceId = this.ReadProperty(SourceIdProperty);
                data.Name = this.ReadProperty(NameProperty);
                data.FileType = this.ReadProperty(FileTypeProperty);
                data.FileData = this.ReadProperty(FileDataProperty);
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
                var data = new Data.Attachment
                {
                    AttachmentId = this.ReadProperty(AttachmentIdProperty)
                };

                ctx.ObjectContext.Attachments.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(AttachmentCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Attachments
                    .Single(row => row.AttachmentId == criteria.AttachmentId);

                ctx.ObjectContext.Attachments.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}