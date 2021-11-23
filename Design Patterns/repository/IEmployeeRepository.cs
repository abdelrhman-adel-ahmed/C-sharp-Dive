using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Design_Patterns.core.repository;
using Design_Patterns.Domian.repository;

namespace Design_Patterns.core.repository
{
    interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetMaleEmployees();
        IEnumerable<Employee> GetFemaleEmployees();


    }
}
