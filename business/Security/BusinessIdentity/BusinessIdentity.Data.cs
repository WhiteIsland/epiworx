using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Security;
using Epiworx.Business;
using Epiworx.Data;
using Epiworx.Security.Helpers;

namespace Epiworx.Security
{
    public partial class BusinessIdentity
    {
        private void DataPortal_Fetch(LoginCriteria criteria)
        {
            if (criteria.IsGuest)
            {
                this.FetchGuest();
            }
            else
            {
                using (var ctx = ObjectContextManager<ApplicationEntities>
                    .GetManager(Database.SecurityConnection, false))
                {
                    IQueryable<Data.User> query = ctx.ObjectContext.Users;

                    query = query.Where(row => row.Name == criteria.Name
                        || row.Email == criteria.Name);

                    var data = query.Select(row => row);

                    if (data.Count() > 0)
                    {
                        var user = data.Single();

                        if (!string.IsNullOrEmpty(criteria.Password))
                        {
                            if (PasswordHelper.ComparePasswords(
                                user.Salt,
                                criteria.Password,
                                user.Password))
                            {
                                this.Fetch(user);
                            }
                            else
                            {
                                throw new SecurityException("User name or password is invalid.");
                            }
                        }
                        else
                        {
                            this.Fetch(user);
                        }
                    }
                    else
                    {
                        throw new SecurityException("User name or password is invalid.");
                    }
                }
            }
        }

        private void Fetch(Data.User user)
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.IsGuest = false;
            this.IsAuthenticated = true;
            this.Roles = new Csla.Core.MobileList<string>();

            this.Roles.Add(((Role)user.Role).ToString());
        }

        private void FetchGuest()
        {
            this.UserId = 0;
            this.Name = "Guest";
            this.FirstName = "Guest";
            this.LastName = "User";
            this.IsGuest = true;
            this.IsAuthenticated = true;
            this.Roles = new Csla.Core.MobileList<string>();
        }
    }
}
