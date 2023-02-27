using System;
using System.Collections.Generic;

#nullable disable

namespace scaffoldingDbUsingEfCore.Model
{
    public partial class Employeess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
