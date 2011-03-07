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
    public partial class TaskLabel
    {
        private static Csla.PropertyInfo<int> SourceIdProperty =
            RegisterProperty<int>(row => row.SourceId, "SourceId");
        [DataObjectField(true, false)]
        public int SourceId
        {
            get { return this.GetProperty(SourceIdProperty); }
        }

        private static Csla.PropertyInfo<SourceType> SourceTypeProperty =
            RegisterProperty<SourceType>(row => row.SourceType, "SourceType");
        [DataObjectField(true, false)]
        public SourceType SourceType
        {
            get { return this.GetProperty(SourceTypeProperty); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        [DataObjectField(true, false)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be less than 30 characters")]
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
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
