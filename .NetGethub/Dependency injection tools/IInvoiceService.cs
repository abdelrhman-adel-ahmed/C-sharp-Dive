using System.Collections.Generic;

namespace Dependency_injection_tools
{
    interface IInvoiceService
    {
        IEnumerable<InvoiceListing> FetchInvoiceList();
    }
}