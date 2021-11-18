using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Random_Ordering
    {
        public static void run()
        {
            var customers = Db.GetCustomerList();
            var result1 = customers.OrderBy(c => c.ContactName);
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
