using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Business;
using Epiworx.Data.Validation;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(ProjectIdProperty, 0));

            this.BusinessRules.AddRule(new SprintDuplicateNameCheck { PrimaryProperty = NameProperty, AffectedProperties = { ProjectIdProperty } });
            this.BusinessRules.AddRule(new SprintDuplicateNameCheck { PrimaryProperty = ProjectIdProperty, AffectedProperties = { NameProperty } });
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(Sprint),
                  new IsInRole(AuthorizationActions.CreateObject,
                      Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Sprint),
                 new IsInRole(AuthorizationActions.DeleteObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));

            BusinessRules.AddRule(typeof(Sprint),
                 new IsInRole(AuthorizationActions.EditObject,
                     Role.FullControl.ToString(), Role.Contribute.ToString()));
        }
    }
}
