using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    static class Helloworld
    {
         delegate void medeleget();
        //COMPILER CREATE -->> class medeleget {}
        public static void run()
        {
            //since it class we can intiate it but the constructor take method
            medeleget me = new medeleget(foo);
            //  medeleget me =foo --> compiler transalte to medeleget me = new medeleget(foo);
            me();//--> *call the refrence it same as  me.Invoke();
            me.Invoke();

            invoker(foo);//compiler --> new medeleget(foo) and pass it to invoker
            invoker(bar);//compiler --> new medeleget(bar) and pass it to invoker
        }

        static void invoker(medeleget del)
        {
            del();
        } 

        static void foo()
        {
            Console.WriteLine("foo");
        }
        static void bar()
        {
            Console.WriteLine("bar");
        }
    }
}
