using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserInfo
    {
        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "UserId");
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
        }

        private static Csla.PropertyInfo<string> FirstNameProperty =
            RegisterProperty<string>(row => row.FirstName, "FirstName");
        public string FirstName
        {
            get { return this.GetProperty(FirstNameProperty); }
            set { this.LoadProperty(FirstNameProperty, value); }
        }

        private static Csla.PropertyInfo<string> LastNameProperty =
            RegisterProperty<string>(row => row.LastName, "LastName");
        public string LastName
        {
            get { return this.GetProperty(LastNameProperty); }
            set { this.LoadProperty(LastNameProperty, value); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.LoadProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<string> SaltProperty =
            RegisterProperty<string>(row => row.Salt, "Salt");
        public string Salt
        {
            get { return this.GetProperty(SaltProperty); }
            set { this.LoadProperty(SaltProperty, value); }
        }

        private static Csla.PropertyInfo<string> PasswordProperty =
            RegisterProperty<string>(row => row.Password, "Password");
        public string Password
        {
            get { return this.GetProperty(PasswordProperty); }
            set { this.LoadProperty(PasswordProperty, value); }
        }

        private static Csla.PropertyInfo<string> EmailProperty =
            RegisterProperty<string>(row => row.Email, "Email");
        public string Email
        {
            get { return this.GetProperty(EmailProperty); }
            set { this.LoadProperty(EmailProperty, value); }
        }

        private static Csla.PropertyInfo<Role> RoleProperty =
            RegisterProperty<Role>(row => row.Role, "Role");
        public Role Role
        {
            get { return this.GetProperty(RoleProperty); }
            set { this.LoadProperty(RoleProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsActiveProperty =
            RegisterProperty<bool>(row => row.IsActive, "IsActive");
        public bool IsActive
        {
            get { return this.GetProperty(IsActiveProperty); }
            set { this.LoadProperty(IsActiveProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.LoadProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NotesProperty =
            RegisterProperty<string>(row => row.Notes, "Notes");
        public string Notes
        {
            get { return this.GetProperty(NotesProperty); }
            set { this.LoadProperty(NotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            set { this.LoadProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            internal set { this.LoadProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            set { this.LoadProperty(ModifiedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            set { this.LoadProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            internal set { this.LoadProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            set { this.LoadProperty(CreatedDateProperty, value); }
        }

    }
}
