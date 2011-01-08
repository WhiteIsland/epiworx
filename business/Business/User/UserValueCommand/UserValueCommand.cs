using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class UserValueCommand : Csla.CommandBase<UserValueCommand>
    {
        private int? UserId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int userId, string columnName)
        {
            UserValueCommand result = null;
            result = Csla.DataPortal.Execute(new UserValueCommand(userId, columnName));
            return result.Value;
        }

        private UserValueCommand(int userId, string columnName)
        {
            this.UserId = userId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.User> query = ctx.ObjectContext.Users;

                if (this.UserId != null)
                {
                    query = query.Where(row => row.UserId == this.UserId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Name);
                        break;
                    case "FirstName":
                        this.Value = data.FirstName;
                        break;
                    case "LastName":
                        this.Value = data.LastName;
                        break;
                    case "Salt":
                        this.Value = data.Salt;
                        break;
                    case "Password":
                        this.Value = data.Password;
                        break;
                    case "Email":
                        this.Value = data.Email;
                        break;
                    case "Role":
                        this.Value = data.Role;
                        break;
                    case "IsActive":
                        this.Value = data.IsActive;
                        break;
                    case "IsArchived":
                        this.Value = data.IsArchived;
                        break;
                    case "Notes":
                        this.Value = data.Notes;
                        break;
                    case "ModifiedBy":
                        this.Value = data.ModifiedBy;
                        break;
                    case "ModifiedDate":
                        this.Value = data.ModifiedDate;
                        break;
                    case "CreatedBy":
                        this.Value = data.CreatedBy;
                        break;
                    case "CreatedDate":
                        this.Value = data.CreatedDate;
                        break;
                    default:
                        throw new ArgumentException("No such column name.");
                }
            }
        }
    }
}
