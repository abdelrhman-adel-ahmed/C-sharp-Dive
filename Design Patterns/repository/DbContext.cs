using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Domian.repository;

namespace Design_Patterns.repository
{

   
    class MeContext : DbContext
    {
        public MeContext() : base(@"Data Source=.;Initial Catalog=FirstDB;Integrated Security=True") { }

        public static DbSet<Employee> Employee { get; set; }

    }
}
