using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class lambda_and_anonymous
    {

        public static void run()
        {
            //lambda expression
            Func<int, bool> del = i => i > 5;
            Console.WriteLine(del(6));
            Console.WriteLine(del(3));

            //anonymous
            Func<int, bool> del1 = delegate (int i) { return i > 5; };//you have to use keyword delegete 
            //result is same compiler will make same method from these both expressin
            /*
             * it use <> in method name because it not allowed in the programme ,so that way it will be sure
             * that the name doesnot colid with any func name you declar
             * private static bool <> (int i){return i>5;} 
             */
            Console.WriteLine(del1.Method);//notice the method name
            Console.WriteLine(del1(10));


        }

      
    }
}
