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
    public partial class UserPassword
    {
        protected override void AddBusinessRules()
        {
            this.BusinessRules.AddRule(new Required(SaltProperty));
            this.BusinessRules.AddRule(new MaxLength(SaltProperty, 30));
            this.BusinessRules.AddRule(new Required(PasswordProperty));
            this.BusinessRules.AddRule(new MaxLength(PasswordProperty, 30));
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
