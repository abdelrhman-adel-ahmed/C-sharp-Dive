using System.Collections.Generic;



namespace Dependency_injection_tools
{
    class InvoiceService : IInvoiceService
    {
        private readonly IInoviceRepository _invoiceRepository;
        private readonly ITranslate<Invoice,InvoiceListing> _invoiceToInvoiceListingTranslator;

        //poor man dependency injection
        public InvoiceService():this(new InoviceRepository(),
            new InvoiceToInvoiceListingTranslator())
        {
        
        }


        public InvoiceService(IInoviceRepository invoiceRepository ,
            ITranslate<Invoice, InvoiceListing> invoiceToInvoiceListingTranslator)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IEnumerable<InvoiceListing> FetchInvoiceList()
        {
           //DI constructor based
           //InoviceRepository invoiceRepository = new InoviceRepository();
           //InvoiceToInvoiceListingTranslator invoiceToInvoiceListingTranslator =
           //new InvoiceToInvoiceListingTranslator();

            IEnumerable<Invoice> listofInvoices = _invoiceRepository.FetchAll();

            foreach (var invoice in listofInvoices)
            {
                yield return _invoiceToInvoiceListingTranslator.From(invoice);
            } 
        }

        
    }


}