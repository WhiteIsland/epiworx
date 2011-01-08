using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Category
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

        internal static Category NewCategory()
        {
            return Csla.DataPortal.Create<Category>();
        }

        internal static Category FetchCategory(CategoryCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Category>(criteria);
        }

        internal static void DeleteCategory(CategoryCriteria criteria)
        {
            Csla.DataPortal.Delete<Category>(criteria);
        }
    }
}
