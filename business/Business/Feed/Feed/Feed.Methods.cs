using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Feed
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Type);
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

        internal static Feed NewFeed()
        {
            return Csla.DataPortal.Create<Feed>();
        }

        internal static Feed FetchFeed(FeedCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Feed>(criteria);
        }
    }
}
