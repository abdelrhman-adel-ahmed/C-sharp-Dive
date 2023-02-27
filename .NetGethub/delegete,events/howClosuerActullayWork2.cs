using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class howClosuerActullayWork2
    {
        public static void run()
        {
            Action a = givemetwoactions2();
            a();
        }
        class display
        {
            int i ;
            public void fun1()
            {
                i++;
                Console.WriteLine(i);
            }

            public void func2()
            {
                i += 2;
                Console.WriteLine(i);

            }
        }
        static Action givemetwoactions2()
        {
            int i = 0;
            Action ret = null;
            display obj = new display();
            ret += obj.fun1;
            ret += obj.func2;
            return ret;
        }
        static Action givemetwoactions()
        {
            int i = 0;
            Action ret = null;
            ret += () => { i++; Console.WriteLine(i); };
            ret += () => { i += 2; Console.WriteLine(i); };
            return ret;
        }
    }
}
