using System;

namespace Dependency_injection_tools
{
    public class InvoiceToInvoiceListingTranslator:ITranslate<Invoice,InvoiceListing>
    {
        public InvoiceListing From(Invoice invoice)
        {
            return new InvoiceListing();
        }

       
    }
}