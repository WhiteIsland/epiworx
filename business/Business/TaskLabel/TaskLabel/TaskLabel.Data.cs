using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class TaskLabel
    {
        [Csla.RunLocal]
        private void Child_Create(string name)
        {
            this.LoadProperty(NameProperty, name);

            this.BusinessRules.CheckRules();
        }

        private void Child_Fetch(Data.Label data)
        {
            this.Fetch(data);

            this.BusinessRules.CheckRules();
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
        protected void Child_Insert(Task parent)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Label();

                this.Insert(data, parent);

                ctx.ObjectContext.AddToLabels(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Label data, Task parent)
        {
            data.SourceId = parent.TaskId;
            data.SourceType = (int)parent.SourceType;
            data.Name = this.ReadProperty(NameProperty);
            data.CreatedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
            data.CreatedDate = DateTime.Now;

            this.Update(data, parent);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected void Child_Update(Task parent)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.Label
                {
                    SourceId = parent.SourceId,
                    SourceType = (int)parent.SourceType,
                    Name = this.ReadProperty(NameProperty)
                };

                ctx.ObjectContext.Labels.Attach(data);

                this.Update(data, parent);

                ctx.ObjectContext.SaveChanges();

            }
        }

        protected void Update(Data.Label data, Task parent)
        {
            if (this.IsSelfDirty)
            {
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected void Child_DeleteSelf()
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

                ctx.ObjectContext.Labels.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}