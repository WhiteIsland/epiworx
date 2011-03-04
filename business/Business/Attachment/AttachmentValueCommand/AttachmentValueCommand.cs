using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class AttachmentValueCommand : Csla.CommandBase<AttachmentValueCommand>
    {
        private int? AttachmentId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int attachmentId, string columnName)
        {
            AttachmentValueCommand result = null;
            result = Csla.DataPortal.Execute(new AttachmentValueCommand(attachmentId, columnName));
            return result.Value;
        }

        private AttachmentValueCommand(int attachmentId, string columnName)
        {
            this.AttachmentId = attachmentId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Attachment> query = ctx.ObjectContext.Attachments;

                if (this.AttachmentId != null)
                {
                    query = query.Where(row => row.AttachmentId == this.AttachmentId);
                }

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Name);
                        break;
                    case "SourceType":
                        this.Value = data.SourceType;
                        break;
                    case "SourceId":
                        this.Value = data.SourceId;
                        break;
                    case "FileType":
                        this.Value = data.FileType;
                        break;
                    case "FileData":
                        this.Value = data.FileData;
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
