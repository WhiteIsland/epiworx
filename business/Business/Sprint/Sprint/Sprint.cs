using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class Sprint : Csla.BusinessBase<Sprint>, ISprint
    {
        private Sprint()
        {
        }
    }
}
