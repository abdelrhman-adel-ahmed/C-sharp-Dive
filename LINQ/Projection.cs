using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Projection
    {
       public static void run()
        {
            IEnumerable<Customer> Customers=Db.GetCustomerList();

            var result = from c in Customers
                         //anonymous types ... 
                         select new { c.CompanyName, c.ContactName };

        }
    }
}
