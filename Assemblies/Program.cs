using System;
using LibAssembly; //assembly that we add to our dependencies

namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sample.Print());//function in the libassembly dll
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
