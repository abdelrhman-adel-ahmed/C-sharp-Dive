using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _.net_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();

            var cscPath = Path.Combine(frameworkPath, "csc.exe");
            Console.WriteLine(frameworkPath);  // C:\Windows\Microsoft.NET\Framework\v4.0.30319
            Console.WriteLine(cscPath);
            Console.ReadLine();
        }
    }
}
