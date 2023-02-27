using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter5_primitives_refrence_and_value_types_
{
    class DynamicNotSafeTypes
    {
        public static void Run()
        {
            dynamic value;
            for (int i = 0; i < 2; i++)
            {
                value = (i == 0) ? (dynamic)5 : "A";
                value += value;
                M(value);
            }
        }
        public static void M(dynamic value)
        {
            Console.WriteLine(value);
        }
        public static void M(int value)
        {
            Console.WriteLine(value);
        }
        

    }
}
