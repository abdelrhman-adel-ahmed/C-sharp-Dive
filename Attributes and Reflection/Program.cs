using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using Reflections;

namespace Attributes_and_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("----------------Hello_World_Attributes----------------");
            //Hello_World_Attributes.run();
            //Console.WriteLine("----------------Reflection----------------");
            //Reflection.run();
            //Console.WriteLine("----------------Attributes----------------");
            //Attributes.run();

            //string x="ahmed";
            //Type t = typeof(String); //return the type of the object that get passed

            //Console.WriteLine("----------------Attributes Example----------------");
            //attribute_example.run();

            //Console.WriteLine("----------------instantiatingTypes----------------");
            //instantiatingTypes.run();

            //Console.WriteLine("----------------ReflectingMembers----------------");
            //ReflectingMembers.run();

            Console.WriteLine("----------------InvokeUsingReflection----------------");
            InvokeUsingReflection.run();
            

        }
    }

   
   
}
