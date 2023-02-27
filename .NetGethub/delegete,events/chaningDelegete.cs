using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class chaningDelegete
    {

        delegate void mydelegate();

        public static void run()
        {
            mydelegate d = foo; // behind the scenes ==> mydelegate d = new mydelegate(d);
            d += goo;
            d += sue;
            d();
            //this is equal to
            //d =(mydelegate)Delegate.Combine(d ,new mydelegate(goo));
            //d= (mydelegate)Delegate.Combine(d ,new mydelegate(sue));
            foreach(mydelegate m in d.GetInvocationList())
            {
                Console.WriteLine(m.Method);
            }


        }

        static void goo()
        {

            Console.WriteLine("goo");
        }
        static void sue()
        {
            Console.WriteLine("sue");
        }
        static void foo()
        {
            Console.WriteLine("foo");
        }
    }

}
