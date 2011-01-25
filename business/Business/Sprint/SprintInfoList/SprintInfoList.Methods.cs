using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class SprintInfoList
    {
        internal static SprintInfoList FetchSprintInfoList(SprintCriteria criteria)
        {
            return Csla.DataPortal.Fetch<SprintInfoList>(criteria);
        }
    }
}
