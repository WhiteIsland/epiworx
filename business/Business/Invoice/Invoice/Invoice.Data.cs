using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Invoice
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(InvoiceCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Invoices
                    .Include("Task")
                    .Include("Task.Project")
                    .Include("CreatedByUser")
                    .Include("ModifiedByUser")
                    .Single(row => row.InvoiceId == criteria.InvoiceId);

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.Invoice data)
        {
            this.LoadProperty(InvoiceIdProperty, data.InvoiceId);
            this.LoadProperty(NumberProperty, data.Number);
            this.LoadProperty(ProjectIdProperty, data.Task.ProjectId);
            this.LoadProperty(ProjectNameProperty, data.Task.Project.Name);
            this.LoadProperty(DescriptionProperty, data.Description);
            this.LoadProperty(TaskIdProperty, data.TaskId);
            this.LoadProperty(AmountProperty, data.Amount);
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
                var data = new Data.Invoice();

                this.Insert(data);

                ctx.ObjectContext.AddToInvoices(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(InvoiceIdProperty, data.InvoiceId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.Invoice data)
        {
            data.InvoiceId = this.ReadProperty(InvoiceIdProperty);
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
                var data = new Data.Invoice
                {
                    InvoiceId = this.ReadProperty(InvoiceIdProperty)
                };

                ctx.ObjectContext.Invoices.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.Invoice data)
        {
            if (this.IsSelfDirty)
            {
                data.Number = this.ReadProperty(NumberProperty);
                data.TaskId = this.ReadProperty(TaskIdProperty);
                data.Description = this.ReadProperty(DescriptionProperty);
                data.Amount = this.ReadProperty(AmountProperty);
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
                var data = new Data.Invoice
                {
                    InvoiceId = this.ReadProperty(InvoiceIdProperty)
                };

                ctx.ObjectContext.Invoices.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(InvoiceCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Invoices
                    .Single(row => row.InvoiceId == criteria.InvoiceId);

                ctx.ObjectContext.Invoices.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}