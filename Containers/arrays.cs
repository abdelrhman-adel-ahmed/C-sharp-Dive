using System;
using System.Collections.Generic;
using System.Text;

namespace Containers
{

    class List<T>
    {
        T[] arr = new T[6];
        int count;
        public void Add(T item)
        {
            if (arr.Length == count)
                Array.Resize(ref arr, arr.Length * 2);
            arr[count++] = item;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return arr[i];
            }
        }

    }
    class arrays
    {
        public static void run()
        {
            object[] arr = new object[] { "Das", 41, 3, 5, 31, 315, 8, 9, 1,"dsa" };
            arr[0] = 2;
            //Array.Sort(arr);
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(arr.GetType().BaseType.BaseType);
            List<int> mylist = new List<int>();
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(45);
            int count = 0;
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }
          

            /*foreach get converted to 
            IEnumerator<int> iterator = mylist.GetEnumerator();
            while(iterator.MoveNext())
                Console.WriteLine(iterator.Current);
            */

        }

    }
}
