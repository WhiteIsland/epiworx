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
    public partial class Project
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new ProjectDuplicateNameCheck { PrimaryProperty = NameProperty });
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Project),
                new IsInRole(AuthorizationActions.CreateObject,
                    Role.Contribute.ToString(), Role.FullControl.ToString()));

            BusinessRules.AddRule(typeof(Project),
                new IsInRole(AuthorizationActions.EditObject,
                    Role.Contribute.ToString(), Role.FullControl.ToString()));

            BusinessRules.AddRule(typeof(Project),
                new IsInRole(AuthorizationActions.DeleteObject,
                    Role.FullControl.ToString()));
        }
    }
}
