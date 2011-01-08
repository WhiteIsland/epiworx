using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class UserCriteria : Csla.CriteriaBase<UserCriteria>
    {
        public UserCriteria()
        {
            this.UserId = null;
            this.FirstName = null;
            this.LastName = null;
            this.Name = null;
            this.Salt = null;
            this.Password = null;
            this.Email = null;
            this.Role = null;
            this.IsActive = null;
            this.IsArchived = null;
            this.Notes = null;
            this.ModifiedBy = null;
            this.ModifiedDate = new DateRangeCriteria();
            this.CreatedBy = null;
            this.CreatedDate = new DateRangeCriteria();
            this.Text = null;
            this.MaximumRecords = null;
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
