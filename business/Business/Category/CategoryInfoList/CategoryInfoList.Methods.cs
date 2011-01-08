using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class CategoryInfoList
    {
        internal static CategoryInfoList FetchCategoryInfoList(CategoryCriteria criteria)
        {
            return Csla.DataPortal.Fetch<CategoryInfoList>(criteria);
        }
    }
}
