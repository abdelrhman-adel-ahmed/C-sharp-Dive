using System;

namespace BeforeFieldInitDotNET3
{
    public class StaticConstructorType
    {
        private static int x = Log();

        // Force "precise" initialization
        static StaticConstructorType() { }

        private static int Log()
        {
            Console.WriteLine("Type initialized");
            return 0;
        }

        public static void StaticMethod() { }
    }
}
