using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Csla;
using Csla.Security;

namespace Epiworx.Security
{
    public partial class BusinessPrincipal
    {
        public static bool Login()
        {
            return BusinessPrincipal.SetPrincipal(BusinessIdentity.GetIdentity());
        }

        public static bool Login(string username, string password)
        {
            return BusinessPrincipal.SetPrincipal(BusinessIdentity.GetIdentity(username, password));
        }

        public static void LoadPrincipal(string username)
        {
            BusinessPrincipal.SetPrincipal(BusinessIdentity.GetIdentity(username));
        }

        private static bool SetPrincipal(BusinessIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                var principal = new BusinessPrincipal(identity);

                ApplicationContext.User = principal;
            }

            return identity.IsAuthenticated;
        }

        public static void Logout()
        {
            ApplicationContext.User = new UnauthenticatedPrincipal();
        }

        public static BusinessIdentity GetCurrentIdentity()
        {
            return (BusinessIdentity)Csla.ApplicationContext.User.Identity;
        }

        public static BusinessPrincipal GetCurrentPrincipal()
        {
            return (BusinessPrincipal)Csla.ApplicationContext.User;
        }
    }
}
