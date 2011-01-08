using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserInfo
    {
        private void Fetch(Data.User data)
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
    }
}
