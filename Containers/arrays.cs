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

    }
    class arrays
    {
        public static void run()
        {
            object[] arr = new object[] { "Das", 41, 3, 5, 31, 315, 8, 9, 1,"dsa" };
            arr[0] = 2;
            //Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arr.GetType().BaseType.BaseType);
        }
       
    }
}
