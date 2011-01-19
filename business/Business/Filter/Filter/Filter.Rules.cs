using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Data.Validation;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Filter
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        protected static void AddObjectAuthorizationRules()
        {
        }

        public static bool CanSaveObject(Filter filter)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && filter.CreatedBy == BusinessPrincipal.GetCurrentIdentity().UserId))
            {
                return true;
            }

            return false;
        }

        public static bool CanDeleteObject(Filter filter)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && filter.CreatedBy == BusinessPrincipal.GetCurrentIdentity().UserId))
            {
                return true;
            }

            return false;
        }
    }
}
