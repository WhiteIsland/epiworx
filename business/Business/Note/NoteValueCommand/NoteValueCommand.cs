using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class NoteValueCommand : Csla.CommandBase<NoteValueCommand>
    {
		private int? NoteId { get; set; }
        private string ColumnName { get; set; }
        private object Value { get; set; }

        public static object FetchValue(int noteId, string columnName)
        {
            NoteValueCommand result = null;
            result = Csla.DataPortal.Execute(new NoteValueCommand(noteId, columnName));
            return result.Value;
        }

        private NoteValueCommand(int noteId, string columnName)
        {
			this.NoteId = noteId;
            this.ColumnName = columnName;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                        .GetManager(Database.ApplicationConnection, false))
            {
                IQueryable<Data.Note> query = ctx.ObjectContext.Notes;
				
				if (this.NoteId != null)
				{
                    query = query.Where(row => row.NoteId == this.NoteId);
				}

                var data = query.Single();

                switch (this.ColumnName)
                {
                    case "Name":
                        this.Value = string.Format("{0}", data.Body);
                        break;
                    case "SourceType":
                        this.Value = data.SourceType;
                        break;
                    case "SourceId":
                        this.Value = data.SourceId;
                        break;
                    case "Body":
                        this.Value = data.Body;
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
