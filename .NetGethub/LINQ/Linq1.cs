using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Linq1
    {
        //Enumerable is static class the wrap punsh of extension method that linq uses
        public static void run()
        {
            List<int> att = new List<int>();
            int[] numbers = new[] { 1, 2, 3, 4, 21, 3, 313, 67, 8 };

            IEnumerable<int> result = from number in numbers where number > 3 select number;
            //this is equivelent to this .the compiler use the (extension methods) ,
            var result2 =
                          numbers //mumbers doesnot have method called where ,but its an extension methods
                                  //where is a extension method take IEnmerable and array is IEnmerable
                                  //and take FUNC wich is delegate that have return type(here it return bool)
                          .Where(number => number > 3)
                          .Select(number => number);

            var result3 =
                System.Linq.Enumerable.Where(numbers, number => number > 3).Select(number => number);

            //this is some how closer to misl , of course we still need to convert the anonymous func to regualr methods
            IEnumerable<int> result4 =
                Enumerable.Select(Enumerable.Where(numbers, number => number > 3), number => number);

            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            //result 1 2 3 4 all equivalent 
        }

    }
}