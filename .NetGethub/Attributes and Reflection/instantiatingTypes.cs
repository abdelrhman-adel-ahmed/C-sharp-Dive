using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes_and_Reflection
{
    class instantiatingTypes
    {
        public static void run()
        {
            emp ee1 = (emp)Activator.CreateInstance(typeof(emp));
            Console.WriteLine(ee1.GetType());
           // -----------------------not working!!------------------------------ -
            //do
            //{
            //    var assName = "Attributes_and_Reflection";
            //    var sss = typeof(Program).FullName;
            //    var en_name = assName + "." + Console.ReadLine();
            //    var o = Activator.CreateInstance(assName, en_name);
            //    object obj = o.Unwrap();
            //    Console.WriteLine(o);
            //} while (true);
        }
    }

    public class e1
    {
        public override string ToString()
        {
            return "e1";
        }
    }
    class e2
    {
        public override string ToString()
        {
            return "e2";
        }

    }
    class e3
    {
        public override string ToString()
        {
            return "e3";
        }
    }
    class emp
    {
        public int x ;
        public string y;
    }

}
