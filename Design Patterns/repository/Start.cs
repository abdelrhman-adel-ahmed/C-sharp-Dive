using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Persistence;

namespace Design_Patterns.repository
{
    class Start
    {

        public static void run()
        {
            using (var unitOfWork = new UnitOfWork(new MeContext()))
            {
                var emps = unitOfWork.Employee.GetAll();
                emps.ToList().ForEach(x => Console.WriteLine(x));
                //any changes we will make
            }
        }
    }
}
