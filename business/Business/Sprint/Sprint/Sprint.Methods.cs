using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                case "IsCompleted":
                    this.OnIsCompletedChanged();
                    break;
                case "CompletedDate":
                    this.OnCompletedDateChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnIsCompletedChanged()
        {
            if (this.IsCompleted
                && this.CompletedDate == DateTime.MaxValue.Date)
            {
                this.CompletedDate = DateTime.Now;
            }
            else if (!this.IsCompleted
                && this.CompletedDate != DateTime.MaxValue.Date)
            {
                this.CompletedDate = DateTime.MaxValue.Date;
            }
        }

        private void OnCompletedDateChanged()
        {
            if (this.EstimatedCompletedDate == DateTime.MaxValue.Date)
            {
                this.EstimatedCompletedDate = this.CompletedDate;
            }
        }

        internal static Sprint NewSprint()
        {
            return Csla.DataPortal.Create<Sprint>();
        }

        internal static Sprint FetchSprint(SprintCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Sprint>(criteria);
        }

        internal static void DeleteSprint(SprintCriteria criteria)
        {
            Csla.DataPortal.Delete<Sprint>(criteria);
        }
    }
}
