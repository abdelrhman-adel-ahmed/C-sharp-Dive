using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressTrees
{
    class Why_Expression_Trees_Are_Cool__Entity_Framework_
    {

        public static void run()
        {
            
            var zrbo = new MeContext();
            //dbset implement IQueryable so this is lambda expression so this is just objects that the dbcontext
            //will invistigate and see what we want to do , oh you want to get the customer from the table and
            //order by the city, so it translate that to a query that get sent to the dataBase ,so thats why 
            //we have experssion that is just an object (metadata) that we can investigate about
            //  foreach (var item in zrbo.Customers.OrderBy(i=>i.City))
            //  {
            //      Console.WriteLine(item.ContactName);
            //      Console.WriteLine(item.City);
            //
            //      Console.WriteLine();
            //  }



            //what compiler doo

            ParameterExpression paramExp = Expression.Parameter(typeof(Customers), "i");
            
            Expression<Func<Customers, string>> exp = Expression.Lambda<Func<Customers, String>>
                (Expression.Property(paramExp,(MethodInfo)typeof(Customers).GetProperty("City").GetGetMethod()), paramExp);

            //  or

            //foreach (var item in Queryable.OrderBy(zrbo.Customers, exp))
            //{
            //    Console.WriteLine(item.ContactName);
            //    Console.WriteLine(item.City);

            //     Console.WriteLine();         
            //}

            
            Func<Customers,string> del= exp.Compile();

            List<Customers> customers = zrbo.Customers.ToList();
            /*
            ////////////////////////////////////////////////////////////////////////////////////////////////
            note: here we convert the exp to function so we longer put the group by in the query we retrived all
            the data and then group by here in the code . so thats the diffrence between ienumerable and iquerable
            is the first we have actual function ,the second we have some object that we can reason about to build
            our query
            ////////////////////////////////////////////////////////////////////////////////////////////////
            */
            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
                Console.WriteLine(del(item));

                Console.WriteLine();

            }
            //or 
            //foreach (var item in zrbo.Customers.AsEnumerable().OrderBy(i=>i.City))
            //{
            //    Console.WriteLine(item.ContactName);
            //    Console.WriteLine(item.City);

            //    Console.WriteLine();
            //}

             



            }

        }

    class MeContext:DbContext
    {
        public MeContext(): base("northwind"){}

        public DbSet<Customers> Customers { get; set; }

    }

    class Customers
    {
        [Key] 
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string City { get; set; }

    }

}
