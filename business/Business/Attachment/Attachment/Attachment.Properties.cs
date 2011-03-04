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
    public partial class Attachment
    {
        private static Csla.PropertyInfo<int> AttachmentIdProperty =
            RegisterProperty<int>(row => row.AttachmentId, "AttachmentId");
        [DataObjectField(true, false)]
        public int AttachmentId
        {
            get { return this.GetProperty(AttachmentIdProperty); }
        }

        private static Csla.PropertyInfo<SourceType> SourceTypeProperty =
            RegisterProperty<SourceType>(row => row.SourceType, "SourceType");
        public SourceType SourceType
        {
            get { return this.GetProperty(SourceTypeProperty); }
            internal set { this.SetProperty(SourceTypeProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceIdProperty =
            RegisterProperty<int>(row => row.SourceId, "SourceId");
        public int SourceId
        {
            get { return this.GetProperty(SourceIdProperty); }
            internal set { this.SetProperty(SourceIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<string> FileTypeProperty =
            RegisterProperty<string>(row => row.FileType, "FileType");
        [Required(ErrorMessage = "FileType is required")]
        [StringLength(100, ErrorMessage = "FileType must be less than 100 characters")]
        public string FileType
        {
            get { return this.GetProperty(FileTypeProperty); }
            set { this.SetProperty(FileTypeProperty, value); }
        }

        private static Csla.PropertyInfo<byte[]> FileDataProperty =
            RegisterProperty<byte[]>(row => row.FileData, "FileData");
        public byte[] FileData
        {
            get { return this.GetProperty(FileDataProperty); }
            set { this.SetProperty(FileDataProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            internal set { this.SetProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            internal set { this.SetProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            internal set { this.SetProperty(ModifiedDateProperty, value); }
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
