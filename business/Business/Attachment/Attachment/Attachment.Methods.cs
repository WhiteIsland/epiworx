using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Attachment
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
                default:
                    break;
            }
        }

        internal static Attachment NewAttachment(AttachmentCriteria criteria)
        {
            return Csla.DataPortal.Create<Attachment>(criteria);
        }

        internal static Attachment FetchAttachment(AttachmentCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Attachment>(criteria);
        }

        internal static void DeleteAttachment(AttachmentCriteria criteria)
        {
            Csla.DataPortal.Delete<Attachment>(criteria);
        }
    }
}
