using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class SprintInfoList : Csla.ReadOnlyListBase<SprintInfoList, SprintInfo>
    {
        private SprintInfoList()
        {
        }
    }
}
