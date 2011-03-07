using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class LabelInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static LabelInfo FetchLabelInfo(Data.Label data)
        {
            var result = new LabelInfo();
            result.Fetch(data);
            return result;
        }
    }
}
