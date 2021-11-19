using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAceess;
using System.Data.Entity;
using System.Configuration;

namespace FirstWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            string cs = ConfigurationManager.ConnectionStrings["firstdbEntities"].ConnectionString;
            firstdbEntities obj = new firstdbEntities();
            return obj.Employees.ToList();
        }
        public Employee Get(int id)
        {
            firstdbEntities obj = new firstdbEntities();
            return obj.Employees.FirstOrDefault(e => e.ID == id);
        }
        public string Delete(int id)
        {
            firstdbEntities obj = new firstdbEntities();
            Employee emp = obj.Employees.FirstOrDefault(e => e.ID == id);
            obj.Employees.Remove(emp);
            obj.SaveChanges();
            return $"employee {emp.Name} got deleted";
        }
    }

}
