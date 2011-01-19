using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class FilterInfoList : Csla.ReadOnlyListBase<FilterInfoList, FilterInfo>
    {
        private FilterInfoList()
        {
        }
    }
}
