using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------Entity_Framework_Hello_World---------------");
            MeContext context = new MeContext();  
            var xx = context.Videos.Where(x => x.ID == 14).ToList();

            Entity_Framework_Hello_World.run();

            //Console.WriteLine("---------------ManyToMany---------------");
            //ManyToMany.run();
        }
    }
}
