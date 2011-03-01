using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Note
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Body);
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

        internal static Note NewNote(NoteCriteria criteria)
        {
            return Csla.DataPortal.Create<Note>(criteria);
        }

        internal static Note FetchNote(NoteCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Note>(criteria);
        }

        internal static void DeleteNote(NoteCriteria criteria)
        {
            Csla.DataPortal.Delete<Note>(criteria);
        }
    }
}
