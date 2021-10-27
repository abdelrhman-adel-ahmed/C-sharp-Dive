using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

	static class Test
	{
		 public static IEnumerable<T> Where<T>(this IEnumerable<T> source,Func<T,bool> p)

		{
			foreach (T item in source)
			{
				if (p(item))
				{
					Console.WriteLine(item);
					yield return item;
				}
			}
		}
	}

	class Writing_Your_Own_LINQ_Extension_Method
	{

		public static void run()
		{
			IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 21, 3, 313, 67, 8 };
			//var result =numbers.OurWhere(number => number > 3);
			//Var item = 
			//foreach (var item in result)
			//{
			//	Console.WriteLine(item);
			//}
			var items = Enumerable.Select(Enumerable.Where(numbers, n => n > 3),n=>n);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

		}
	}
}
