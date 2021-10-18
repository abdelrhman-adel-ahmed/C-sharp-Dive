using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class closures
    {

        public static void run()
        {

            Action a = givemeaction();
            a();
            a();
            Func<int, int> f = TakeIntReturnInt();
            Console.WriteLine(f(1));
            Console.WriteLine(f(1)); 
        }
        static void lambda_func()
        {
            int i = 0;
            Action a = () => i++; //take no argument return i++
            a();
            Console.WriteLine(a.Method);
            Console.WriteLine(i);
            a();
            Console.WriteLine(i);
        }

        static Action givemetwoactions()
        {
            Action act = null;
            int i = 0;
            //chain of delegate
            act += () => { Console.WriteLine("fist method"); i += 1; };
            act += () => { Console.WriteLine("second method"); i += 1; };
            return act;
        }
        static Func<int,int> TakeIntReturnInt()
        {
            int i = 0;
            return (int value) => {  return i += value; };
        }
        static Action givemeaction()
        {
            int i = 0;
           
            return () => { i++; Console.WriteLine(i); };
        }
        /* same as :
         *  static Action givemeaction()
        {
            int i = 0;
           void func(){i++;}
        return func;
        }
         * 
         */
    }
}
