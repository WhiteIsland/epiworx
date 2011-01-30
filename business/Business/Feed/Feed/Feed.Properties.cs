using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Feed
    {
        private static Csla.PropertyInfo<int> FeedIdProperty =
            RegisterProperty<int>(row => row.FeedId, "FeedId");
        [DataObjectField(true, false)]
        public int FeedId
        {
            get { return this.GetProperty(FeedIdProperty); }
        }

        private static Csla.PropertyInfo<string> TypeProperty =
            RegisterProperty<string>(row => row.Type, "Type");
        [Required(ErrorMessage = "Type is required")]
        [StringLength(30, ErrorMessage = "Type must be less than 30 characters")]
        public string Type
        {
            get { return this.GetProperty(TypeProperty); }
            set { this.SetProperty(TypeProperty, value); }
        }

        private static Csla.PropertyInfo<string> DataProperty =
            RegisterProperty<string>(row => row.Data, "Data");
        [Required(ErrorMessage = "Data is required")]
        [StringLength(1000, ErrorMessage = "Data must be less than 1000 characters")]
        public string Data
        {
            get { return this.GetProperty(DataProperty); }
            set { this.SetProperty(DataProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            internal set { this.SetProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            internal set { this.SetProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            internal set { this.SetProperty(CreatedDateProperty, value); }
        }

    }
}
