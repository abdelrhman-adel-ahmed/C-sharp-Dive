using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Dependency_injection_tools
{
    class Program
    {
        static void Main(string[] args)
        {
            //but here we viloate DI
            //InvoiceService invoiceService = new InvoiceService(new InoviceRepository(), 
            //    new InvoiceToInvoiceListingTranslator());
           InvoiceService invoiceService = new InvoiceService();
            Console.ReadLine();
        }
    }
}
