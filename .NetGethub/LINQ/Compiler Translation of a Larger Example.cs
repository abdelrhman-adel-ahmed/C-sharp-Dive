using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Compiler_Translation_of_a_Larger_Example
    {

        public static void run()
        {
            int[] numbers = new[] { 1, 2, 3, 4, 21, 3, 313, 67, 8 ,23,312,3,4,4,1,7,89,321,44,321,5,9};
            var result1 = from number in numbers
                          orderby 8
                          where number < 5
                          where 0<number
                          where new Random().Next() ==23
                          orderby number
                          orderby number *2+3
                          orderby 5 
                          select number;

            var resultusingExtensionMethods
                =
                 numbers.OrderBy(number => 8).Where(number => number < 5).Where(number => 0 < number)
                .Where(number => new Random().Next() == 23).OrderBy(number => number).OrderBy(number => number * 2 + 3)
                .OrderBy(number => 5);
            ;
            var resultusingExtensionMethods2
            =
            Enumerable.OrderBy(numbers,number => 8)
            .Where(number => number < 5).Where(number => 0 < number)
            .Where(number => new Random().Next() == 23).OrderBy(number => number).OrderBy(number => number * 2 + 3)
            .OrderBy(number => 5);

            //or we can explicilty pass the IEnumerable that get returned from each clause, *start with inner most
            var resultusingExtensionMethods3
          =
          Enumerable.OrderBy(
              Enumerable.OrderBy(
                 Enumerable.OrderBy(
                     Enumerable.Where(
                         Enumerable.Where(
                             Enumerable.Where(
                                 Enumerable.OrderBy(numbers, number => 8), 
                                 number => number > 5),
                             number => 0 < number),
                         number => new Random().Next() == 23),
                     number => number),
                 number => number * 2 + 3),
              number => 5);

            foreach (var item in resultusingExtensionMethods3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
