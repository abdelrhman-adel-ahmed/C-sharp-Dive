using System;
using System.Collections.Generic;

#nullable disable

namespace scaffoldingDbUsingEfCore.Model
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Employeesses = new HashSet<Employeess>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Employeess> Employeesses { get; set; }
    }
}
