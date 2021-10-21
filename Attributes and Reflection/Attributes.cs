using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes_and_Reflection
{
    class MeAttribute : Attribute 
    {
        public MeAttribute(int a)
        {
            Console.WriteLine("MeAttribute");
            Console.WriteLine(a);

        }
    }

    [Me(1)]
    class Attributes
    {
        public static void run()
        {
            //typeof take the class type ,return the type that is known at compile-time
            //gettype it is used to obtain the type of an object at run-time.
            object s = "ahmed";
            //get type is run time so it will evaluate so object will evaluate to string 
            Console.WriteLine(s.GetType() ==typeof(object)); 
            int a = 1;
            Console.WriteLine(a.GetType() == typeof(int));
            object[] obj =typeof(Attributes).GetCustomAttributes(false);
            foreach(Attribute aa in obj)
            {
                Console.WriteLine(aa);
            }
        }
    }
}
