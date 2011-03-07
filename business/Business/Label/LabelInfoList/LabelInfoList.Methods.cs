using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class LabelInfoList
    {
        internal static LabelInfoList FetchLabelInfoList(LabelCriteria criteria)
        {
            return Csla.DataPortal.Fetch<LabelInfoList>(criteria);
        }
    }
}
