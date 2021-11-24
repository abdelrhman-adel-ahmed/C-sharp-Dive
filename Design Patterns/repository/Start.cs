using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Persistence;
using System.Data.Entity;
using Design_Patterns.Domian.repository;

namespace Design_Patterns.repository
{

    public class x : DbContext
    {
        public x() : base(@"connect timeout=30;Data Source=.;Initial Catalog=FirstDB;Integrated Security=SSPI")
        {
        }
        public  DbSet<Employees> Employee { get; set; }
    }


    class Start
    {

        public static void run()
        {
            using (var x =new UnitOfWork(new MeContext()))
            {
                Console.WriteLine(x.Employee.GetAll().ToList().Count);
            }

        }
    }
}
