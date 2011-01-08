using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Security.Helpers;

namespace Epiworx.Business
{
    public partial class User
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

        public void SetPassword(string password)
        {
            this.Salt = PasswordHelper.GetSalt(10);
            this.Password = PasswordHelper.Salt(this.Salt, password);
        }

        internal static User NewUser()
        {
            return Csla.DataPortal.Create<User>();
        }

        internal static User FetchUser(UserCriteria criteria)
        {
            return Csla.DataPortal.Fetch<User>(criteria);
        }

        internal static void DeleteUser(UserCriteria criteria)
        {
            Csla.DataPortal.Delete<User>(criteria);
        }
    }
}
