using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class InvoiceExistsCommand : Csla.CommandBase<InvoiceExistsCommand>
    {
        public int? InvoiceId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int invoiceId)
        {
            InvoiceExistsCommand result = null;
            result = Csla.DataPortal.Execute(new InvoiceExistsCommand(invoiceId));
            return result.Success;
        }

        private InvoiceExistsCommand(int invoiceId)
        {
            this.InvoiceId = invoiceId;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Invoice> query = ctx.ObjectContext.Invoices;

                if (this.InvoiceId != null)
                {
                    query = query.Where(row => row.InvoiceId == this.InvoiceId);
                }

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
