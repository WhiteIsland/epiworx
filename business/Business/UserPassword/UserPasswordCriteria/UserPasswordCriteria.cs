using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class UserPasswordCriteria : Csla.CriteriaBase<UserPasswordCriteria>
    {
        public UserPasswordCriteria()
        {
            this.Name = null;
            this.Email = null;
        }
    }
}
