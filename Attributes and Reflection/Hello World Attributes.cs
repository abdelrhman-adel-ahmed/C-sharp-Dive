using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Attributes_and_Reflection
{

    class TestAttribute: Attribute { }



    [TestAttribute] //MyTestSuite has custom attribute 
    class MyTestSuite { } 

    class Hello_World_Attributes
    {
        public static void run()
        {
            foreach (Type e in Assembly.GetExecutingAssembly().GetTypes())
                foreach (Attribute a in e.GetCustomAttributes(false))
                {
                    Console.WriteLine(a);
                    if (a is TestAttribute)
                        Console.WriteLine(e.Name + " is a test suite");
                }
        }
    }
}
