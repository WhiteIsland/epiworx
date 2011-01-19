using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class Filter : Csla.BusinessBase<Filter>, IFilter
    {
        private Filter()
        {
        }
    }
}
