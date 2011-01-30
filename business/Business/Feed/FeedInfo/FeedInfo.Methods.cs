using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FeedInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Type);
        }

        internal static FeedInfo FetchFeedInfo(Data.Feed data)
        {
            var result = new FeedInfo();
            result.Fetch(data);
            return result;
        }
    }
}
