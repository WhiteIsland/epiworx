using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;

namespace Epiworx.Security
{
    public partial class BusinessIdentity
    {
        public static BusinessIdentity GetCurrentIdentity()
        {
            return (BusinessIdentity)Csla.ApplicationContext.User.Identity;
        }

        internal static BusinessIdentity GetIdentity()
        {
            return Csla.DataPortal.Fetch<BusinessIdentity>(new LoginCriteria { IsGuest = true });
        }

        internal static BusinessIdentity GetIdentity(string username)
        {
            return Csla.DataPortal.Fetch<BusinessIdentity>(
                new LoginCriteria
                    {
                        Name = username
                    });
        }

        internal static BusinessIdentity GetIdentity(string username, string password)
        {
            return Csla.DataPortal.Fetch<BusinessIdentity>(
                new LoginCriteria
                    {
                        Name = username,
                        Password = password
                    });
        }
    }
}
