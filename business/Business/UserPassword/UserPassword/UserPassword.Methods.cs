using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Security.Helpers;

namespace Epiworx.Business
{
    public partial class UserPassword
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static UserPassword FetchUserPassword(UserPasswordCriteria criteria)
        {
            return Csla.DataPortal.Fetch<UserPassword>(criteria);
        }

        public void SetPassword(string password)
        {
            this.Salt = PasswordHelper.GetSalt(10);
            this.Password = PasswordHelper.Salt(this.Salt, password);
        }
    }
}
