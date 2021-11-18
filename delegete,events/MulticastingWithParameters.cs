using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events
{
    class MulticastingWithParameters
    {
        delegate int mydelegate(int i);

        public static void run()
        {
            mydelegate dd = new mydelegate(x);
            dd += y;

            foreach (var item in dd.GetInvocationList())
            {
                //what if we want to send diffrent arg to each func that subscribed to the delegate
                Console.WriteLine(item.Method.Invoke(null,new object[] { 2 }));
            }
        }

        public static int x(int i)
        {
            return i*2;
        }
        public static int y(int i)
        {
            return i*3;
        }
    }
}
