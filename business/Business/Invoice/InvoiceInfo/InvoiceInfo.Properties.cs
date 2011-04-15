using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class InvoiceInfo
    {
        private static Csla.PropertyInfo<int> InvoiceIdProperty =
            RegisterProperty<int>(row => row.InvoiceId, "InvoiceId");
        public int InvoiceId
        {
            get { return this.GetProperty(InvoiceIdProperty); }
        }

        private static Csla.PropertyInfo<string> NumberProperty =
            RegisterProperty<string>(row => row.Number, "Number");
        public string Number
        {
            get { return this.GetProperty(NumberProperty); }
            set { this.LoadProperty(NumberProperty, value); }
        }

        private static Csla.PropertyInfo<string> DescriptionProperty =
            RegisterProperty<string>(row => row.Description, "Description");
        public string Description
        {
            get { return this.GetProperty(DescriptionProperty); }
            set { this.LoadProperty(DescriptionProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceTypeProperty =
            RegisterProperty<int>(row => row.SourceType, "SourceType");
        public int SourceType
        {
            get { return this.GetProperty(SourceTypeProperty); }
            set { this.LoadProperty(SourceTypeProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceIdProperty =
            RegisterProperty<int>(row => row.SourceId, "SourceId");
        public int SourceId
        {
            get { return this.GetProperty(SourceIdProperty); }
            set { this.LoadProperty(SourceIdProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> AmountProperty =
            RegisterProperty<decimal>(row => row.Amount, "Amount");
        public decimal Amount
        {
            get { return this.GetProperty(AmountProperty); }
            set { this.LoadProperty(AmountProperty, value); }
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
