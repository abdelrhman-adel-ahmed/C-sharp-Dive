using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class howClosuerActullayWork
    {


        public static void run()
        {
            Action a = givemeaction();
            a(); a();
            Console.WriteLine(a.Target);
            Action b = givemeaction();
            b(); b(); b();
            Console.WriteLine(b.Target);
        }
        class displayclass
        {
            public int x;
            public void inc()
            {
                this.x++;
                Console.WriteLine($"{x}");
            }
        }

        static Action givemeaction()
        {
            displayclass obj = new displayclass();
            return new Action(obj.inc);
        }


        //----------------------------------------------------------
    }
}
