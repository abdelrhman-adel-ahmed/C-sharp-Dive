using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressTrees;

namespace ExpressTrees
{
    public class Program
    {
       static void Main(string[] args)
        {

            Console.WriteLine("-------------Intro--------------------");
            Intro.run();

            Console.WriteLine("-------------Expression_Trees--------------------");
            Expression_Trees.run();

            Console.WriteLine("-------------Picking_Apart_Expression_Trees--------------------");
            Picking_Apart_Expression_Trees.run();


            Console.ReadLine();
        }
    }
}
