using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Invoice
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Number);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                case "TaskId":
                    this.OnTaskIdChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnTaskIdChanged()
        {
            if (this.TaskId == 0)
            {
                this.ProjectId = 0;
                this.ProjectName = string.Empty;
            }
            else
            {
                var task = ForeignKeyMapper.FetchTask(this.TaskId);

                this.ProjectId = task.ProjectId;
                this.ProjectName = task.ProjectName;
                this.Description = task.Description;
            }
        }

        internal static Invoice NewInvoice()
        {
            return Csla.DataPortal.Create<Invoice>();
        }

        internal static Invoice FetchInvoice(InvoiceCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Invoice>(criteria);
        }

        internal static void DeleteInvoice(InvoiceCriteria criteria)
        {
            Csla.DataPortal.Delete<Invoice>(criteria);
        }
    }
}
