using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class AttachmentInfo
    {
        private static Csla.PropertyInfo<int> AttachmentIdProperty =
            RegisterProperty<int>(row => row.AttachmentId, "AttachmentId");
        public int AttachmentId
        {
            get { return this.GetProperty(AttachmentIdProperty); }
        }

        private static Csla.PropertyInfo<SourceType> SourceTypeProperty =
            RegisterProperty<SourceType>(row => row.SourceType, "SourceType");
        public SourceType SourceType
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

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.LoadProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<string> FileTypeProperty =
            RegisterProperty<string>(row => row.FileType, "FileType");
        public string FileType
        {
            get { return this.GetProperty(FileTypeProperty); }
            set { this.LoadProperty(FileTypeProperty, value); }
        }

        private static Csla.PropertyInfo<byte[]> FileDataProperty =
            RegisterProperty<byte[]>(row => row.FileData, "FileData");
        public byte[] FileData
        {
            get { return this.GetProperty(FileDataProperty); }
            set { this.LoadProperty(FileDataProperty, value); }
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
