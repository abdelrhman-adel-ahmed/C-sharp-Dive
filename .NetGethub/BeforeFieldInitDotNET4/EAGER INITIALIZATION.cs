using System;

namespace BeforeFieldInitDotNET4
{
    public class Eager
    {
        private static int x = Log();

        private static int Log()
        {
            Console.WriteLine("Type initialized");
            return 0;
        }

        public static void StaticMethod() { }
    }
}
