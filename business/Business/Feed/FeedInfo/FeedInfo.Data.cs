using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FeedInfo
    {
        private void Fetch(Data.Feed data)
        {
            this.LoadProperty(FeedIdProperty, data.FeedId);
            this.LoadProperty(TypeProperty, data.Type);
            this.LoadProperty(DataProperty, data.Data);
            this.LoadProperty(CreatedByProperty, data.CreatedBy);
            this.LoadProperty(CreatedByEmailProperty, data.CreatedByUser.Email);
            this.LoadProperty(CreatedByNameProperty, data.CreatedByUser.Name);
            this.LoadProperty(CreatedDateProperty, data.CreatedDate);
        }
    }
}
