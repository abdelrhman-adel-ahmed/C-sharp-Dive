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
            using (var unitOfWork =new UnitOfWork(new MeContext()))
            {
                unitOfWork.Employee.GetMaleEmployees().ToList().ForEach(x => Console.WriteLine(x.Name));
                Employees emp = new Employees
                {
                    ID=10,
                    Name = "aa",
                    Gender = "male"
                };
                unitOfWork.Employee.Add(emp);
                unitOfWork.Complete();
            }

        }
    }
}
