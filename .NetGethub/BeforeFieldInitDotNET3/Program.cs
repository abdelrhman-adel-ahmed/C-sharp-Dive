using System;
using System.Collections.Generic;
using System.Text;

namespace BeforeFieldInitDotNET3
{
    /// <summary>
    /// beforefieldinit flag is put by the compiler if the class doesnot have static constructor ....
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------PRECISE INITIALIZATION---------------------------");
            if (args.Length == 0)
            {
                Console.WriteLine("No args");
            }
            else
            {
                StaticConstructorType.StaticMethod();
            }

            Console.WriteLine("------------------------EAGER INITIALIZATION---------------------------");

            if (args.Length == 0)
            {
                Console.WriteLine("No args");
            }
            else
            {
                Eager.StaticMethod();
            }
        }
    }
    
}
