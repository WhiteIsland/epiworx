using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FilterInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static FilterInfo FetchFilterInfo(Data.Filter data)
        {
            var result = new FilterInfo();
            result.Fetch(data);
            return result;
        }
    }
}
