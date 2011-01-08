using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;
using Epiworx.Security;

namespace Epiworx.Business
{
    public partial class User
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            this.LoadProperty(RoleProperty, Role.None);
            this.LoadProperty(IsActiveProperty, true);

            this.BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(UserCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.User> query = ctx.ObjectContext.Users;

                if (criteria.UserId != null)
                {
                    query = query.Where(row => row.UserId == criteria.UserId);
                }

                if (criteria.Name != null)
                {
                    query = query.Where(row => row.Name == criteria.Name);
                }

                var data = query.Single();

                this.Fetch(data);

                this.BusinessRules.CheckRules();
            }
        }

        protected void Fetch(Data.User data)
        {
            this.LoadProperty(UserIdProperty, data.UserId);
            this.LoadProperty(FirstNameProperty, data.FirstName);
            this.LoadProperty(LastNameProperty, data.LastName);
            this.LoadProperty(NameProperty, data.Name);
            this.LoadProperty(SaltProperty, data.Salt);
            this.LoadProperty(PasswordProperty, data.Password);
            this.LoadProperty(EmailProperty, data.Email);
            this.LoadProperty(RoleProperty, data.Role);
            this.LoadProperty(IsActiveProperty, data.IsActive);
            this.LoadProperty(IsArchivedProperty, data.IsArchived);
            this.LoadProperty(NotesProperty, data.Notes);
            this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
            this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.User();

                this.Insert(data);

                ctx.ObjectContext.AddToUsers(data);

                ctx.ObjectContext.SaveChanges();

                this.LoadProperty(UserIdProperty, data.UserId);
                this.LoadProperty(CreatedByProperty, data.CreatedBy);
                this.LoadProperty(CreatedDateProperty, data.CreatedDate);
            }
        }

        protected void Insert(Data.User data)
        {
            data.UserId = this.ReadProperty(UserIdProperty);
            data.CreatedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
            data.CreatedDate = DateTime.Now;

            this.Update(data);
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

                this.LoadProperty(ModifiedByProperty, data.ModifiedBy);
                this.LoadProperty(ModifiedDateProperty, data.ModifiedDate);
            }
        }

        protected void Update(Data.User data)
        {
            if (this.IsSelfDirty)
            {
                data.FirstName = this.ReadProperty(FirstNameProperty);
                data.LastName = this.ReadProperty(LastNameProperty);
                data.Name = this.ReadProperty(NameProperty);
                data.Salt = this.ReadProperty(SaltProperty);
                data.Password = this.ReadProperty(PasswordProperty);
                data.Email = this.ReadProperty(EmailProperty);
                data.Role = (int)this.ReadProperty(RoleProperty);
                data.IsActive = this.ReadProperty(IsActiveProperty);
                data.IsArchived = this.ReadProperty(IsArchivedProperty);
                data.Notes = this.ReadProperty(NotesProperty);
                data.ModifiedBy = ((BusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                data.ModifiedDate = DateTime.Now;
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = new Data.User
                {
                    UserId = this.ReadProperty(UserIdProperty)
                };

                ctx.ObjectContext.Users.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(UserCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                var data = ctx.ObjectContext.Users
                    .Single(row => row.UserId == criteria.UserId);

                ctx.ObjectContext.Users.DeleteObject(data);

                ctx.ObjectContext.SaveChanges();
            }
        }
    }
}