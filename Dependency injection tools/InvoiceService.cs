using System.Collections.Generic;



namespace Dependency_injection_tools
{
    class InvoiceService : IInvoiceService
    {
        private readonly InoviceRepository _invoiceRepository;
        private readonly InvoiceToInvoiceListingTranslator _invoiceToInvoiceListingTranslator;

        public InvoiceService(InoviceRepository invoiceRepository , 
            InvoiceToInvoiceListingTranslator invoiceToInvoiceListingTranslator)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IEnumerable<InvoiceListing> FetchInvoiceList()
        {
           //DI constructor based
           //InoviceRepository invoiceRepository = new InoviceRepository();
            //InvoiceToInvoiceListingTranslator invoiceToInvoiceListingTranslator =
            //    new InvoiceToInvoiceListingTranslator();
            IEnumerable<Invoice> listofInvoices = _invoiceRepository.FetchAll();

            foreach (var invoice in listofInvoices)
            {
                yield return _invoiceToInvoiceListingTranslator.From(invoice);
            } 
        }
    }


}