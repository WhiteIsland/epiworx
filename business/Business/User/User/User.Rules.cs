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
    public partial class User
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new RoleRequired { PrimaryProperty = RoleProperty });
            this.BusinessRules.AddRule(new UserDuplicateNameCheck { PrimaryProperty = NameProperty });
            this.BusinessRules.AddRule(new UserDuplicateEmailCheck { PrimaryProperty = EmailProperty });
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
