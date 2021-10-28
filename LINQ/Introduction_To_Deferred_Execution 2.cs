using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    static class Introduction_To_Deferred_Execution_2
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

            var result =
                arr.Where(number => number < 5).Select(number => number + 6);

            var result2 =
                Where(arr, number => number < 5).Select(number => number + 6);

            var result3 =
                Select(Where(arr, number => number < 5), number => number + 6);

            //so the exection order is from outer most to the inner most , but the outer most uses the inner 
            //most result first to perfrom ,so the where doesnot fullt evaluate and then the select
            //nooooooooooo the select perfrom on an endivaual item and then go to the where with that item 
            //and then we carry on 
            /* execution plan :
            1-outer most start (select)
            2-hit the loop relase that it need item from *collection 
            3-the item is the result from where 
            4-so where get started and loop over the collection wich the list we pass 
            5-and then spit a value (yield) after passing it to the predicate
            6-the item get to the select now 
            7-select apply the transformation ,and spit the value 
            8-and the process continue 
                        its just a lazy evaluation pipline,and the laziness * is in each stage
            */

            IEnumerator<int> iterator = result3.GetEnumerator();
            while (iterator.MoveNext())
                Console.WriteLine(iterator.Current);

        }
    }
}
