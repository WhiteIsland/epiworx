using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FeedInfoList
    {
        internal static FeedInfoList FetchFeedInfoList(FeedCriteria criteria)
        {
            return Csla.DataPortal.Fetch<FeedInfoList>(criteria);
        }
    }
}
