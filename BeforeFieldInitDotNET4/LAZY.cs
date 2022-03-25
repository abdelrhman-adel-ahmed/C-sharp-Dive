using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeFieldInitDotNET4
{
    class Lazy
    {
        private static int x = Log();
        private static int y = 0;

        private static int Log()
        {
            Console.WriteLine("Type initialized");
            return 0;
        }

        public static void StaticMethod()
        {
            Console.WriteLine("In static method");
        }

        public static void StaticMethodUsingField()
        {
            Console.WriteLine("In static method using field");
            Console.WriteLine($"y = {y}");
        }

        public void InstanceMethod()
        {
            Console.WriteLine("In instance method");
        }
    }
}
