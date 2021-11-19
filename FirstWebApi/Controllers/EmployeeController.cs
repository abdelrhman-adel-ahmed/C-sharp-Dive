using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAceess;
using System.Data.Entity;

namespace FirstWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            firstdbEntities obj = new firstdbEntities();
            return obj.Employees.ToList();
        }
        public Employee Get(int id)
        {
            firstdbEntities obj = new firstdbEntities();
            return obj.Employees.FirstOrDefault(e => e.ID == id);
        }
    }

}
