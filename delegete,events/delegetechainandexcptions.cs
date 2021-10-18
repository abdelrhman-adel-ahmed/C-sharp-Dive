using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class delegetechainandexcptions
    {


        public static void run()
        {
            //Action del = goo + shit + bar;//error compiler cannot add method 
            Action del = new Action(goo) + shit + bar;//now goo is delegete(action) and it know how to add del to del 
            //then we have another del bar combine with the prev delegets
            //del();

            foreach(Action a in del.GetInvocationList())
            {
                try
                {
                    a();
                }
                catch (Exception e)
                {

                    Console.WriteLine(a.Method + " throw expection");
                }
            }
        }

        static void goo() { Console.WriteLine("goo"); }
        static void shit() { throw new Exception(); }
        static void bar() { Console.WriteLine("bar"); }

    }


}
