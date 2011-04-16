using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class InvoiceIndexModel : InvoiceListModel
    {
        public int[] ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDisplayName { get; set; }
        public string Date { get; set; }
        public int IsArchived { get; set; }
    }

    public class InvoiceListModel : ModelListBase
    {
        public IEnumerable<IInvoice> Invoices { get; set; }
        public IEnumerable<IProject> Projects { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
    }

    public class InvoiceImportModel : ModelListBase
    {
        public IEnumerable<IInvoice> Invoices { get; set; }
    }

    public class InvoiceFormModel : ModelBusinessBase
    {
        [DisplayName("InvoiceId:")]
        public int InvoiceId { get; set; }

        [DisplayName("ProjectId:")]
        public int ProjectId { get; set; }

        [DisplayName("Project:")]
        public string ProjectName { get; set; }

        [DisplayName("TaskId:")]
        public int TaskId { get; set; }

        [DisplayName("No.:")]
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }

        [DisplayName("Prepared on:")]
        public DateTime PreparedDate { get; set; }

        [DisplayName("Description:")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [DisplayName("Amount:")]
        public decimal Amount { get; set; }

        [DisplayName("Enter some notes about the invoice:")]
        public string Notes { get; set; }

        [DisplayName("This invoice is archived")]
        public bool IsArchived { get; set; }

        public NoteListModel NoteListModel { get; set; }
        public AttachmentListModel AttachmentListModel { get; set; }
    }
}