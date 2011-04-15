using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IInvoice
    {
        int InvoiceId { get; }
        string Number { get; }
        string Description { get; }
        int SourceType { get; }
        int SourceId { get; }
        decimal Amount { get; }
        bool IsArchived { get; }
        string Notes { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
