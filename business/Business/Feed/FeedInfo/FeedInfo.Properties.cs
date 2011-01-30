using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class FeedInfo
    {
        private static Csla.PropertyInfo<int> FeedIdProperty =
            RegisterProperty<int>(row => row.FeedId, "FeedId");
        public int FeedId
        {
            get { return this.GetProperty(FeedIdProperty); }
        }

        private static Csla.PropertyInfo<string> TypeProperty =
            RegisterProperty<string>(row => row.Type, "Type");
        public string Type
        {
            get { return this.GetProperty(TypeProperty); }
            set { this.LoadProperty(TypeProperty, value); }
        }

        private static Csla.PropertyInfo<string> DataProperty =
            RegisterProperty<string>(row => row.Data, "Data");
        public string Data
        {
            get { return this.GetProperty(DataProperty); }
            set { this.LoadProperty(DataProperty, value); }
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
