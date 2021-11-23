using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Design_Patterns.Domian.repository;
using Design_Patterns.core.repository;
using Design_Patterns.repository;

namespace Design_Patterns.Persistence.repository
{
     class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MeContext meContext) :base(meContext)
        {

        }
      

        public MeContext MeContext { get { return Context as MeContext; } }

        public IEnumerable<Employee> GetMaleEmployees()
        {
            return MeContext.Employee.Where(x => x.Gender == "Male").ToList();
        }

        public IEnumerable<Employee> GetFemaleEmployees()
        {
            return MeContext.Employee.Where(x => x.Gender == "Female").ToList();
        }
    }
}
