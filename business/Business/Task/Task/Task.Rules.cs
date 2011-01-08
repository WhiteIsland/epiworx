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
    public partial class Task
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(ProjectIdProperty, 0));
            this.BusinessRules.AddRule(new IntegerRequired(CategoryIdProperty, 0));
            this.BusinessRules.AddRule(new IntegerRequired(StatusIdProperty, 0));

            this.BusinessRules.AddRule(new IsInRole(AuthorizationActions.WriteProperty, IsArchivedProperty, Role.FullControl.ToString()));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Task),
                 new IsInRole(AuthorizationActions.CreateObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Task),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Task),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }

        public static bool CanSaveObject(Task task)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && !task.IsArchived))
            {
                return true;
            }

            return false;
        }

        public static bool CanDeleteObject(Task task)
        {
            if (Csla.ApplicationContext.User.IsInRole(Role.FullControl.ToString())
                || (Csla.ApplicationContext.User.IsInRole(Role.Contribute.ToString())
                    && !task.IsArchived))
            {
                return true;
            }

            return false;
        }
    }
}
