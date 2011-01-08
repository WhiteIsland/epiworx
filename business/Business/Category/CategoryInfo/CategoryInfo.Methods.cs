using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class CategoryInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static CategoryInfo FetchCategoryInfo(Data.Category data)
        {
            var result = new CategoryInfo();
            result.Fetch(data);
            return result;
        }
    }
}
