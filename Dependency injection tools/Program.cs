 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Castle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Dependency_injection_tools.our_own_DI_tool;

namespace Dependency_injection_tools
{
    class test
    {
        void dd() { }
    }

    class Program
    {

        //  sperate usage from creation
        static void Main(string[] args)
        {
            //but here we violate DI
            //InvoiceService invoiceService = new InvoiceService(new InoviceRepository(), 
            //    new InvoiceToInvoiceListingTranslator());
            //InvoiceService invoiceService = new InvoiceService();
            //WindsorContainer container = new WindsorContainer();
            var s1 =(Service1) Activator.CreateInstance(typeof(Service1));
            s1.print();
            Console.ReadLine();
        }
    }
}
