using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class InvoiceService
    {
        public static Invoice InvoiceFetch(int invoiceId)
        {
            return Invoice.FetchInvoice(
                new InvoiceCriteria
                    {
                        InvoiceId = invoiceId
                    });
        }

        public static InvoiceInfoList InvoiceFetchInfoList(ITask task)
        {
            return InvoiceService.InvoiceFetchInfoList(
                new InvoiceCriteria
                    {
                        TaskId = task.TaskId
                    });
        }

        public static InvoiceInfoList InvoiceFetchInfoList()
        {
            return InvoiceService.InvoiceFetchInfoList(
                new InvoiceCriteria());
        }

        public static InvoiceInfoList InvoiceFetchInfoList(InvoiceCriteria criteria)
        {
            return InvoiceInfoList.FetchInvoiceInfoList(criteria);
        }

        public static Invoice InvoiceSave(Invoice invoice)
        {
            if (!invoice.IsValid)
            {
                return invoice;
            }

            Invoice result;

            if (invoice.IsNew)
            {
                result = InvoiceService.InvoiceInsert(invoice);
            }
            else
            {
                result = InvoiceService.InvoiceUpdate(invoice);
            }

            return result;
        }

        public static Invoice InvoiceInsert(Invoice invoice)
        {
            invoice = invoice.Save();

            FeedService.FeedAdd("Created", invoice);

            return invoice;
        }

        public static Invoice InvoiceUpdate(Invoice invoice)
        {
            invoice = invoice.Save();

            FeedService.FeedAdd("Updated", invoice);

            return invoice;
        }

        public static Invoice InvoiceNew()
        {
            return Invoice.NewInvoice();
        }

        public static Invoice InvoiceNew(int taskId)
        {
            var result = Invoice.NewInvoice();

            result.TaskId = taskId;

            return result;
        }

        public static bool InvoiceDelete(Invoice invoice)
        {
            Invoice.DeleteInvoice(
                new InvoiceCriteria
                    {
                        InvoiceId = invoice.InvoiceId
                    });

            FeedService.FeedAdd("Deleted", invoice);

            return true;
        }

        public static bool InvoiceDelete(int invoiceId)
        {
            return InvoiceService.InvoiceDelete(
                InvoiceService.InvoiceFetch(invoiceId));
        }
    }
}