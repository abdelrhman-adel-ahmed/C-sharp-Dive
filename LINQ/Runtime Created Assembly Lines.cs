using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Runtime_Created_Assembly_Lines
    {
        static Random rand =new Random();
        static bool RandomBool
        {
            get { return rand.Next() % 2 == 0; }
        }
  

        public static void run()
        {
            int[] arr =  { 3, 31, 5, 6, 7, 1, 3 };
            IEnumerable<int> result = arr;

            //runtime linq shit
            if (RandomBool)
                result = result.Where(i=> i <8);
            if (RandomBool)
                result = result.Where(i => i < 2);
            if (RandomBool)
                result = result.Select(i => i * 2);
            if (RandomBool)
                result = result.Select(i => i + 9);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            var result1 = arr.Where(x => x < 10);
            var result2 = result1.Where(x => x < 6).Select(x => x % 2 == 0);
            var result3 = result1.OrderBy(i => i < 4).Select(x => x);
            /*
             *             result2 > where > select 
             * arr > where
             *             result3 > orderby > select
             */

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
