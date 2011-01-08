using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Security
{
    [Serializable]
    public partial class LoginCriteria : Csla.CriteriaBase<LoginCriteria>
    {
        public LoginCriteria()
            : this(string.Empty, string.Empty)
        {
        }

        public LoginCriteria(string name)
            : this(name, string.Empty)
        {
        }

        public LoginCriteria(string name, string password)
        {
            this.IsGuest = false;
            this.Name = name;
            this.Password = password;
        }
    }
}
