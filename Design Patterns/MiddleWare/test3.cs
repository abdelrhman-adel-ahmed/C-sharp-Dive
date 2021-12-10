using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class test3
    {
        public static void run()
        {
            //Wrap("a", First);
            //another problem if we want to pipleline here , so we send the message to the try and the delegate 
            //that the compiler will create from the lambda expression , then the msg will get sent to the wrap
            //function and then the wrap function will execute the first and send the msg 
            Try("a", (msg) => Wrap(msg, First));
        }
        public static void First(string msg)
        {
            Console.WriteLine($"exc first func {msg}");
        }

        public static void Second(string msg)
        {
            Console.WriteLine($"exc Second func {msg}");

        }

        public static void Wrap(string msg, Action<string> function)
        {
            Console.WriteLine("start");
            function(msg);
            Console.WriteLine("end");
        }

        public static void Try(string msg, Action<string> function)
        {
            try
            {
                Console.WriteLine("trying");
                function(msg);
            }
            catch (Exception)
            {

            }
        }

    }
}
