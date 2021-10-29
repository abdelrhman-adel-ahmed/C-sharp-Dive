using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    static  class Deferred_Execution___Assembly_Line
    {
        
        static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            Console.WriteLine("our where");
            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    
                    yield return item;
                }
            }
        }

        static IEnumerable<R> Select<T, R>(this IEnumerable<T> collection, Func<T, R> transform)
        {
            Console.WriteLine("our Select");
            foreach (T item in collection)
            {
                var result = transform(item);
                yield return transform(item);
            }
        }
        public static void run()
        {
            int[] arr = new[] { 4,13, 8, 1, 9 };
            var result1 = arr.
                Where(i => i < 10).Where(i => i < 4).Select(i => i * 2)
                .Where(i => i % 2 == 0).Select(i => i + " zrbo");

            var result2= Enumerable.Where(arr, i => i < 10).Where(i => i < 4).Select(i => i * 2)
                .Where(i => i % 2 == 0).Select(i => i + " zrbo");

            var result3 = 
              Enumerable.Select(
                Enumerable.Where(
                    Enumerable.Select(
                        Enumerable.Where(
                            Enumerable.Where(
                                arr, i => i < 10),
                            i => i < 4), 
                        i => i * 2),
                    i => i % 2 == 0), 
                i => i + " zrbo");

            /*
             * start:
             *  > select > where > select > where > where 
             *  then go back:
             *  
             */
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
