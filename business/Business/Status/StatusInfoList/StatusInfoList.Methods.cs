using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class StatusInfoList
    {
        internal static StatusInfoList FetchStatusInfoList(StatusCriteria criteria)
        {
            return Csla.DataPortal.Fetch<StatusInfoList>(criteria);
        }
    }
}
