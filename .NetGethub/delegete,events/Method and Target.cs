using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class Method_and_Target
    {

        delegate void medeleget(int value);
       public static void run()
        {
            medeleget d1 = go; //go is static method so 
            d1(1);
            Method_and_Target obj = new Method_and_Target();
            medeleget d2 = obj.gh; //this is not static so it need object to get called on it
            Console.WriteLine($"(d1 static method) {d1.Method} target : {d1.Target}");

            Console.WriteLine($"(d2 nonstatic method) {d2.Method} target: {d2.Target}");


        }
        static void go(int v)
        {
            Console.WriteLine("go");
        }
        void gh(int v)
        {
            Console.WriteLine("gh");
        }

    }
}
