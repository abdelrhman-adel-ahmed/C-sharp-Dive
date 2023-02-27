using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    
    static class Introduction_To_Deferred_Execution
    {

        static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            Console.WriteLine("our where");
            foreach (T item in collection)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        //take ienumberable of type t ,and transform it to type R 
        // select(numbers,number=>number /2) ==> int ,float hehehe
        static IEnumerable<R> Select<T, R>(this IEnumerable<T> collection, Func<T, R> transform)
        {
            Console.WriteLine("our Select");
            foreach (T item in collection)
            {
                yield return transform(item);
            }
        }
        public static void run()
        {
            int[] arr = new[] { 4, 8, 1, 9 };
            //var result =
            //    from i in arr
            //    where i < 5
            //    select i + 6;
            var result =
                Enumerable.Where(arr, number => number < 5).Select(number => number + 6);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            IEnumerator<int> iterator = result.GetEnumerator();
            while (iterator.MoveNext())
                Console.WriteLine(iterator.Current);

        }
    }
}
