using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class UserExistsCommand : Csla.CommandBase<UserExistsCommand>
    {
        public int? UserId { get; set; }
        private bool Success { get; set; }

        public static bool Exists(int userId)
        {
            UserExistsCommand result = null;
            result = Csla.DataPortal.Execute(new UserExistsCommand(userId));
            return result.Success;
        }

        private UserExistsCommand(int userId)
        {
            this.UserId = userId;
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

                var data = query.Select(row => row);

                this.Success = data.Count() > 0;
            }
        }
    }
}
