using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class InvoiceValueCommand : Csla.CommandBase<InvoiceValueCommand>
    {
        private int? InvoiceId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int invoiceId, string columnName)
        {
            InvoiceValueCommand result = null;
            result = Csla.DataPortal.Execute(new InvoiceValueCommand(invoiceId, columnName));
            return result.Value;
        }

        private InvoiceValueCommand(int invoiceId, string columnName)
        {
            this.InvoiceId = invoiceId;
            this.ColumnName = columnName;
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

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Number);
                        break;
                    case "Number":
                        this.Value = data.Number;
                        break;
                    case "Description":
                        this.Value = data.Description;
                        break;
                    case "SourceType":
                        this.Value = data.SourceType;
                        break;
                    case "SourceId":
                        this.Value = data.SourceId;
                        break;
                    case "Amount":
                        this.Value = data.Amount;
                        break;
                    case "IsArchived":
                        this.Value = data.IsArchived;
                        break;
                    case "Notes":
                        this.Value = data.Notes;
                        break;
                    case "ModifiedBy":
                        this.Value = data.ModifiedBy;
                        break;
                    case "ModifiedDate":
                        this.Value = data.ModifiedDate;
                        break;
                    case "CreatedBy":
                        this.Value = data.CreatedBy;
                        break;
                    case "CreatedDate":
                        this.Value = data.CreatedDate;
                        break;
                    default:
                        throw new ArgumentException("No such column name.");
                }
            }
        }
    }
}
