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
    public partial class Hour
    {
        protected override void AddBusinessRules()
        {
            this.BusinessRules.AddRule(new IntegerRequired(TaskIdProperty, 0));
            this.BusinessRules.AddRule(new IntegerRequired(UserIdProperty, 0));
            this.BusinessRules.AddRule(new DateTimeRequired(DateProperty));
            this.BusinessRules.AddRule(new DecimalRequired(DurationProperty, 0));

            this.BusinessRules.AddRule(new IsInRole(AuthorizationActions.WriteProperty, IsArchivedProperty, Role.FullControl.ToString()));
            this.BusinessRules.AddRule(new IsInRole(AuthorizationActions.WriteProperty, UserIdProperty, Role.FullControl.ToString()));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Hour),
                 new IsInRole(AuthorizationActions.CreateObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Hour),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Hour),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }

        public static bool CanSaveObject(Hour hour)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && hour.UserId == BusinessPrincipal.GetCurrentIdentity().UserId
                    && !hour.IsArchived))
            {
                return true;
            }

            return false;
        }

        public static bool CanDeleteObject(Hour hour)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && hour.UserId == BusinessPrincipal.GetCurrentIdentity().UserId
                    && !hour.IsArchived))
            {
                return true;
            }

            return false;
        }
    }
}
