using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class generic_delegate_func_action
    {
        delegate T mydelegate<T>(); 
        public static void run()
        {
            mydelegate<int> first;
            first = returnten;
            first += returnfive;
            foreach(int value in chainedListValue(first))
                Console.WriteLine(value);
            Console.WriteLine("------------Func--------------");
            //take up to 16 and reutrn 1 out result
            //func is generic delegate that take in return bool, it easer to use Func than make your own 
            //generic delegate with var length argumnet  
            Func<int,bool> second; 
            second = TakeIntRreturnBool;
            Console.WriteLine(second(1));
            Console.WriteLine("------------Action----------");
            Action nothing;
            nothing = prin1;
            nothing += prin2;
            nothing();
        }
       
        static bool TakeIntRreturnBool(int value) { return value > 10; }
        static List<ArgT> chainedListValue<ArgT>(mydelegate<ArgT> d)
        {
            List<ArgT> ll = new List<ArgT>();
            foreach (mydelegate<ArgT> func in d.GetInvocationList())
            {

                ll.Add(func());
            }
            return ll;
        }
        static int returnten() { return 10; }
        static int returnfive() { return 5; }
        static void prin1() { Console.WriteLine("print1"); }
        static void prin2() { Console.WriteLine("print1"); }
    }
}
