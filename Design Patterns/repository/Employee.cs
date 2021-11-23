using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Domian.repository
{
    class Employee
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public string Gender { get; set; }
        public int DepartmentId { get; set; }
    }
}
