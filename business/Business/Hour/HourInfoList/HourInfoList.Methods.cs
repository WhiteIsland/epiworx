using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class HourInfoList
    {
        internal static HourInfoList FetchHourInfoList(HourCriteria criteria)
        {
            return Csla.DataPortal.Fetch<HourInfoList>(criteria);
        }
    }
}
