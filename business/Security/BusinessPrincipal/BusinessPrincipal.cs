using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Security
{
    [Serializable]
    public partial class BusinessPrincipal : Csla.Security.CslaPrincipal
    {
        public BusinessPrincipal()
        {
        }

        private BusinessPrincipal(IIdentity identity)
            : base(identity)
        {
        }
    }
}
