using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.WebMvc.Controllers;
using Microsoft.VisualBasic.FileIO;

namespace Epiworx.WebMvc.Helpers
{
    public partial class ImportHelper
    {
        public const int InvoiceColumnCount = 11;
        public const int InvoiceInvoiceIdColumn = 0;
        public const int InvoiceNumberColumn = 1;
        public const int InvoiceTaskIdColumn = 2;
        public const int InvoicePreparedDateColumn = 3;
        public const int InvoiceProjectNameColumn = 4;
        public const int InvoiceDescriptionColumn = 5;
        public const int InvoiceAmountColumn = 6;
        public const int InvoiceIsArchivedColumn = 7;
        public const int InvoiceNotesColumn = 8;
        public const int InvoiceModifiedByNameColumn = 9;
        public const int InvoiceModifiedDateColumn = 10;
        public const int InvoiceCreatedByNameColumn = 11;
        public const int InvoiceCreatedByDateColumn = 12;

        public static IEnumerable<IInvoice> ImportInvoices(InvoiceController controller, HttpPostedFileBase file)
        {
            if (file == null)
            {
                controller.ModelState.AddModelError(string.Empty, "File is required");
                return null;
            }

            if (file.ContentLength == 0)
            {
                controller.ModelState.AddModelError(string.Empty, "File with a size greater than 0 is required");
                return null;
            }

            if (!file.FileName.EndsWith(".csv"))
            {
                controller.ModelState.AddModelError(string.Empty, "Only comma separate value (.csv) files are allowed");
                return null;
            }

            var invoices = new List<Invoice>();

            using (var sr = new TextFieldParser(file.InputStream))
            {
                sr.TextFieldType = FieldType.Delimited;
                sr.SetDelimiters(",");
                sr.HasFieldsEnclosedInQuotes = true;

                int lineIndex = 0;

                while (!sr.EndOfData)
                {
                    lineIndex++;

                    var values = sr.ReadFields();

                    if (lineIndex == 1) // skip the first line, as it has headers
                    {
                        continue;
                    }

                    try
                    {
                        Invoice invoice;

                        if (int.Parse(values[ImportHelper.InvoiceInvoiceIdColumn]) == 0)
                        {
                            invoice = InvoiceService.InvoiceNew();
                        }
                        else
                        {
                            invoice = InvoiceService.InvoiceFetch(int.Parse(values[ImportHelper.InvoiceInvoiceIdColumn]));
                        }


                        invoice.Number = values[ImportHelper.InvoiceNumberColumn];
                        invoice.Description = values[ImportHelper.InvoiceDescriptionColumn];
                        invoice.TaskId = (int)ImportHelper.TryParse(values[ImportHelper.InvoiceTaskIdColumn], 0);
                        invoice.PreparedDate = ImportHelper.TryParse(values[ImportHelper.InvoicePreparedDateColumn], DateTime.MaxValue);
                        invoice.Amount = ImportHelper.TryParse(values[ImportHelper.InvoiceAmountColumn], 0);

                        if (invoice.CanWriteProperty("IsArchived"))
                        {
                            invoice.IsArchived =
                                ImportHelper.TryParse(values[ImportHelper.InvoiceIsArchivedColumn], false);
                        }

                        invoice.Notes = values[ImportHelper.InvoiceNotesColumn];

                        invoices.Add(invoice);

                        if (!invoice.IsValid)
                        {
                            controller.ModelState.AddModelError(string.Empty,
                                 string.Format("Row [{0}] has the following broken rules: {1}", lineIndex, invoice.BrokenRulesCollection.ToString(",")));
                        }
                    }
                    catch (Exception ex)
                    {
                        controller.ModelState.AddModelError(string.Empty,
                            string.Format("Row [{0}] encountered the following error: {1}", lineIndex, ex));
                    }
                }

                if (controller.ModelState.IsValid)
                {
                    foreach (var invoice in invoices)
                    {
                        InvoiceService.InvoiceSave(invoice);
                    }

                    return invoices;
                }
            }

            return null;
        }
    }
}