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

        public static InvoiceInfoList InvoiceFetchInfoList()
        {
            return InvoiceService.InvoiceFetchInfoList(
                new InvoiceCriteria());
        }

        internal static InvoiceInfoList InvoiceFetchInfoList(InvoiceCriteria criteria)
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
            return invoice.Save();
        }

        public static Invoice InvoiceUpdate(Invoice invoice)
        {
            return invoice.Save();
        }

        public static Invoice InvoiceNew()
        {
            return Invoice.NewInvoice();
        }

        public static bool InvoiceDelete(Invoice invoice)
        {
            Invoice.DeleteInvoice(
                new InvoiceCriteria
                    {
                        InvoiceId = invoice.InvoiceId
                    });

            return true;
        }

        public static bool InvoiceDelete(int invoiceId)
        {
            return InvoiceService.InvoiceDelete(
                InvoiceService.InvoiceFetch(invoiceId));
        }
    }
}