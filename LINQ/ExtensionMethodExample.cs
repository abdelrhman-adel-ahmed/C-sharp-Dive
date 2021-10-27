using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

	static class PlayerMethods
	{
		public static void setHours(this Player player)
		{
			player.hours = 100;
		}
	}

	class Player
	{
		public int hours;
		public string name;
	}
	class ExtensionMethodExample
	{
		public static void run()
		{
			Player p1 = new Player();
			p1.setHours();
			Console.WriteLine(p1.hours);
		}
	}
}
