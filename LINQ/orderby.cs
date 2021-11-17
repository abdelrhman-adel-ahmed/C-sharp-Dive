using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class orderby
    {
        public static void run()
        {
            IEnumerable<Customer> Customers = Db.GetCustomerList();
            var result = from c in Customers
                         orderby c.ContactName
                         select c;


            foreach (var item in result)
            {
                Console.WriteLine(item.CompanyName);
                Console.WriteLine(item.ContactName);
                Console.WriteLine(item.Country);
                Console.WriteLine();
            }
        }
    }
}
