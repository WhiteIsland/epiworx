using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Csla;
using Csla.Security;

namespace Epiworx.Security
{
    [Serializable]
    public partial class BusinessPrincipal : BusinessPrincipalBase
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
