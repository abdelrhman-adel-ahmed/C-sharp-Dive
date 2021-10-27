using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-------------------Extension methods-------------------");
			ExtensionMethods.run();


			Console.WriteLine("-------------------how Extension methods------------------");
			ThisInCsharp.run();


			Console.WriteLine("-------------------Extension methods Example------------------");
			ExtensionMethodExample.run();


			Console.ReadLine();
		}
	}
}
