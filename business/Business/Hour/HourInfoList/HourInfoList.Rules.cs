using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class HourInfoList
    {
        protected static void AddObjectAuthorizationRules()
        {
            // BusinessRules.AddRule(typeof(HourInfoList), 
            //     new IsInRole(AuthorizationActions.GetObject, 
            //         Roles.Administrators, Permissions.GetHours));
        }
    }
}
