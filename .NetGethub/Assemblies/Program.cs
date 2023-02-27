using System;
using LibAssembly; //assembly that we add to our dependencies
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.IO;

namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            Sample.Print();
            var cscPath = Path.Combine(frameworkPath, "csc.exe");
            Console.WriteLine(frameworkPath);  // C:\Windows\Microsoft.NET\Framework\v4.0.30319
            Console.WriteLine(cscPath);
            var assmebly = typeof(Program);
            Console.WriteLine(assmebly);
            Console.WriteLine(assmebly.FullName);
            Console.WriteLine(assmebly.IsClass);
            var x = assmebly.Assembly.GetLoadedModules();
            foreach (var at in x)
                Console.WriteLine(at);

            Console.ReadLine();


        }
      

    }
}
