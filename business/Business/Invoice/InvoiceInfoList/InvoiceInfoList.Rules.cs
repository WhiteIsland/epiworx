using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class InvoiceInfoList
    {
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(InvoiceInfoList),
                new IsInRole(AuthorizationActions.GetObject,
                    Role.FullControl.ToString()));
        }
    }
}
