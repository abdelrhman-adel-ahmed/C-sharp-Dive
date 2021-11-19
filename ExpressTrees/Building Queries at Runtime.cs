using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ExpressTrees
{
    class Building_Queries_at_Runtime
    {

        public static void run()
        {
            var zrbo = new MeContext2();
            foreach (var item in zrbo.Employees)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Gender);
                Console.WriteLine(item.DepartmentId);
                Console.WriteLine();


            }
        }
    }
    class MeContext2 : DbContext
    {
        public MeContext2() : base("firstdb") { }

        public DbSet<Employees> Employees { get; set; }

    }

    class Employees
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int DepartmentId { get; set; }

    }
}
