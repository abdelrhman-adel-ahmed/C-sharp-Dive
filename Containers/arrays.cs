using System;
using System.Collections.Generic;
using System.Text;

namespace Containers
{
    class arrays
    {
        public static void run()
        {
            int[] arr = new int[] { 13, 41, 3, 5, 31, 315, 8, 9, 1 };
            arr[1] = 2;
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arr.GetType().BaseType.BaseType);
        }
       
    }
}
