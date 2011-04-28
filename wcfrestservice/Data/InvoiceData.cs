using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class InvoiceData
    {
        public int InvoiceId { get; set; }
        public ProjectData Project { get; set; }
        public TaskData Task { get; set; }
        public DateTime PreparedDate { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<NoteData> Notes { get; set; }

        public InvoiceData()
        {
            this.Notes = new List<NoteData>();
        }

        public InvoiceData(Invoice invoice)
            : this()
        {
            if (invoice == null)
            {
                return;
            }

            this.InvoiceId = invoice.InvoiceId;
            this.Project = new ProjectData(invoice.Task.Project);
            this.Task = new TaskData(invoice.Task);
            this.PreparedDate = invoice.PreparedDate;
            this.Description = invoice.Description;
            this.Amount = invoice.Amount;
            this.CreatedBy = new UserData(invoice.CreatedByUser);
            this.CreatedDate = invoice.CreatedDate;
        }
    }
}
