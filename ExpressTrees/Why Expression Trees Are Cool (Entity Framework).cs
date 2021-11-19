using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ExpressTrees
{
    class Why_Expression_Trees_Are_Cool__Entity_Framework_
    {

        public static void run()
        {
            var zrbo = new MeContext();
            foreach (var item in zrbo.Customers)
            {
                Console.WriteLine(item.ContractName);
                Console.WriteLine(item.CompanyName);
            }
        }

    }

    class MeContext:DbContext
    {
        public MeContext(): base("northwind"){}

        public DbSet<Customers> Customers { get; set; }

    }

    class Customers
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }

        public string ContractName { get; set; }
        public string City { get; set; }

    }

}
