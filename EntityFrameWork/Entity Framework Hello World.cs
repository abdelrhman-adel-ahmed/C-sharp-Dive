using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{

    class Viedo
    { 
        public int ID { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
    }

    class MeContext : DbContext
    {
        public MeContext() : base(@"Data Source=(local)\ABDELRAHMAN-ADE;Initial Catalog=FirstDB;Integrated Security=True") { }
        public DbSet<Viedo> Viedos{get;set;}
      
    }
    class Entity_Framework_Hello_World
    {

        public static void run()
        {
            Viedo v1 = new Viedo
            {
                Title = "hello entity",
                Description = "ooooh"
            };
            var mycontext = new MeContext();
            mycontext.Viedos.Add(v1);
            mycontext.SaveChanges();
            
        }

    }
}
