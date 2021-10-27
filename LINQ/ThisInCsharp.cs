using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

	/*
	 * this in c# is like self in python 
	 * so if we have some code inside a class function the code is the same for all instance ,so we can 
	*/

	class cow
	{
		int numMoos;
		int UseExpliciThis;
		//the code of the function it self is shared between all the object that get created ,
		//in python we have to pass self (wich is the object it self to the function) to access any member 
		//date of the function ,(and that what differ the date) but the code is the same between all instance
		//in c# this get passed implicilty ,thats imply that all methods (the code)under the hood are static ,
		//there only one copy of the code in the memory and all instance that want to use the code refrence 
		//there self (this) to the function
		public void Moo()
		{
			numMoos++;
			Console.WriteLine("MOOOO " +numMoos);
		}
		public void Explicit()
		{
			this.UseExpliciThis++;
			Console.WriteLine("explicit"+ this.UseExpliciThis);
			
		}
		public static void HardWa(cow _this)
		{
			_this.UseExpliciThis++;
			Console.WriteLine("MOOOO " + _this.UseExpliciThis);
		}
	}
	class ThisInCsharp
	{
		public static void run()
		{
			cow c1 = new cow();
			c1.Moo(); c1.Moo(); c1.Moo();
			cow c2 = new cow();
			cow.HardWa(c2);
			cow.HardWa(c2);
			cow.HardWa(c2);

		}
	}
}
