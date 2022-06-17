using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeFieldInitDotNET4
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUrl url = new GetUrl();
            url.getShortUrl();
          //Console.WriteLine("------------------------EAGER INITIALIZATION---------------------------");
          ////not workin as articale said !!
          //if (args.Length == 0)
          //{
          //    Console.WriteLine("No args");
          //}
          //else
          //{
          //    Eager.StaticMethod();
          //}

         //Console.WriteLine("------------------------Lazy INITIALIZATION---------------------------");
         //
         //Console.WriteLine("Before static method");
         //Lazy.StaticMethod();
         //Console.WriteLine("Before construction");
         //Lazy lazy = new Lazy();
         //Console.WriteLine("Before instance method");
         //lazy.InstanceMethod();
         //Console.WriteLine("Before static method using field");
         //Lazy.StaticMethodUsingField();
         //Console.WriteLine("End");
         //Console.ReadKey();
           // Console.WriteLine("Starting Main");
           // // Invoke a static method on Test
           // Test.EchoAndReturn("Echo!");
           // Console.WriteLine("After echo");
           // // Reference a static field in Test
           // string y = Test.x;
           // // Use the value just to avoid compiler cleverness
           // if (y != null)
           // {
           //     Console.WriteLine("After field access");
           // }
        }
    }
    /// <summary>
    /// test will get called first thing while start the programe because the compiler know that we access the test
    /// later in the main so it go and intialize static fields
    /// </summary>
    class Test
    {
        String tt = new String(new[] { '1' });
        public static string x = EchoAndReturn("In type initializer");

        public static string EchoAndReturn(string s)
        {
            Console.WriteLine(s);
            return s;
        }
    }
    class Test2
    {
        static object o;

        static Test2()
        {
            o = new object();
        }
    }
}
