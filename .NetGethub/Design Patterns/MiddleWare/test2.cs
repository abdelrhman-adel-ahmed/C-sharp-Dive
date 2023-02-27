﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class test2
    {
        public static void run()
        {
            //we can use lambda function to send the arg without alter the action to make it take parameters 
            //and the misl code will generate the delegate that will get sent to Try and then to wrap
            Try(() => Wrap(() => First("a")));
            //Wrap(() => Try(Second("a")));
        }
        public static void First(string msg)
        {
            Console.WriteLine($"exc first func {msg}");
        }

        public static void Second(string msg)
        {
            Console.WriteLine($"exc Second func {msg}");

        }

        public static void Wrap(Action function)
        {
            Console.WriteLine("start");
            function();
            Console.WriteLine("end");
        }

        public static void Try(Action function)
        {
            try
            {
                Console.WriteLine("trying");
                function();
            }
            catch (Exception)
            {

            }
        }

    }
}