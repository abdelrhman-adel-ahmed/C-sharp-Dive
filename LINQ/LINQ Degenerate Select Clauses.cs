using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    static class extension
    {
        public static IEnumerable<T> OurSelect<T>(this IEnumerable<T> source,Func<T,T> transformation)
        {
            foreach (var item in source)
            {
                yield return transformation(item);
            }
        }
    }
    class LINQ_Degenerate_Select_Clauses
    {

        public static void run()
        {
            int[] numbers = new[] { 1, 2, 3, 4, 21, 3, 313, 67, 8 };
            IEnumerable<int> result = from number in numbers
                                      where number > 3 
                                      select number;
            //here we just select the number that come from the where clause wiuthout doing any thing 
            //so compiler realse it and do nothing ,so its a degenrate clause(do nothing)

            //here we actually do somthing ,not just return the n
            IEnumerable<int> result1 = numbers.OurSelect(n => n+2);
           
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
