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
            //orderby : sort the result-set in ascending or descending order.default is ascending order
            IEnumerable<Customer> Customers = Db.GetCustomerList();
            var result = from c in Customers
                             //ascending on the country desc on the contact name 
                         orderby c.Country ,c.ContactName descending
                         select c;


            foreach (var item in result)
            {
                Console.WriteLine(item.Country+" "+item.ContactName);
            
            }
        }
    }
}
