using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class multicastdelegate_vs_delegate
    {
        delegate int mydelegate();
        public static void  run()
        {
            mydelegate d;
            d = returnten;
            d += returnfive;
            int value = d();
            Console.WriteLine(value); //5 it wil return last one 
            Console.WriteLine(d.GetType().BaseType);
            //if we want to get all the value in the chained functions list 
            List<int> ll = new List<int>();
            foreach(mydelegate m in d.GetInvocationList())
            {
                ll.Add(m());
            }
            //chainedListValue(d);
            
            
        }
        static List<int> chainedListValue (mydelegate d)
        {
            List<int> ll = new List<int>();
            foreach (mydelegate item in d.GetInvocationList())
            {

                Console.WriteLine(item());
                ll.Add(item());
            }
        
            return ll;
        }
        static int returnten() { return 10; }
        static int returnfive (){ return 5; }
   

    }
}
