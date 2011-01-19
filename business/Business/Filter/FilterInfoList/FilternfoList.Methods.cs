using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FilterInfoList
    {
        internal static FilterInfoList FetchFilterInfoList(FilterCriteria criteria)
        {
            return Csla.DataPortal.Fetch<FilterInfoList>(criteria);
        }
    }
}
