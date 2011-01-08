using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class UserPassword
    {
        private void DataPortal_Fetch(UserPasswordCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.User> query = ctx.ObjectContext.Users;

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                if (criteria.Email != null)
                {
                    query = query.Where(row => row.Email == criteria.Email);
                }

                var data = query.AsEnumerable().First();

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.User data)
        {
            this.LoadProperty(UserIdProperty, data.UserId);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(EmailProperty, data.Email);
            this.LoadProperty(SaltProperty, data.Salt);
            this.LoadProperty(PasswordProperty, data.Password);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.User
                {
                    UserId = this.ReadProperty(UserIdProperty)
                };

                ctx.ObjectContext.Users.Attach(data);

                this.Update(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        protected void Update(Data.User data)
        {
            if (this.IsSelfDirty)
            {
                data.Salt = this.ReadProperty(SaltProperty);
                data.Password = this.ReadProperty(PasswordProperty);
                data.ModifiedDate = DateTime.Now;
            }
        }
    }
}

