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

            //query syntax
            var result = from c in Customers
                         //anonymous types ... 
                         select new { c.CompanyName, c.ContactName };

            //method syntax
            var result1 = Customers.Select(c => new { c.CompanyName, c.ContactName });

            //method call
            var result2 = Enumerable.Select(Customers, c => new { c.CompanyName, c.ContactName });

            //desugared the lambda expression !!

            var result3 = Enumerable.Select(Customers, xxxx);

            foreach (var item in result3)
            {
                Console.WriteLine(item.CompanyName);
                Console.WriteLine(item.ContactName);
                Console.WriteLine();

            }
        }

        static ttttt xxxx(Customer c)
        {
            return new ttttt ( c.CompanyName, c.ContactName );
        }
        class ttttt
        {
            public string CompanyName { get; private set; }
            public string ContactName { get; private set; }
            public ttttt(string companyname, string contactname)
            {
                CompanyName = companyname;
                ContactName = contactname;
            }

        }
    }

    
}
