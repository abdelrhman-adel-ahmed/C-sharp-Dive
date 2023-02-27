using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	static class ExtensionMethods
	{

		//extension method should be static in static class and the first arg should take (this)
		//and the type of the this object will be same 
		static DateTime Combine(this DateTime datePart, DateTime timePart)
		{
			return new DateTime(datePart.Year, datePart.Month, datePart.Day,
				timePart.Hour, timePart.Minute, timePart.Second);
		}
		public static void run()
		{
			//if you want to add some functionality to a type you regulary inherhte from the type and add the method 
			//in the new inherted class ,but value type cannot be inherted because it struct and you cannt 
			//inherete from structs bec its implicitly sealed
			DateTime datePart = DateTime.Parse("10/10/2012");
			DateTime timePart = DateTime.Parse("1/1/0001 9:55pm");
			Console.WriteLine(datePart);
			Console.WriteLine(timePart);
			//if i want to combine the two the date part and the time part we can do this 
			DateTime combine = Combine(datePart, timePart);
			Console.WriteLine($"combined date and time {combine}");
			//if we want to do this ,to access the function on the type (datetime) which is value type ,
			//we need extension method
			DateTime combined2 = datePart.Combine(timePart);

		}
	}
}