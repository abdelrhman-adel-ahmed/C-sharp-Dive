using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpolyeeAuthServiceApi.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {

        public IEnumerable<Employee> Get()
        {
            seconddbEntities db = new seconddbEntities();
            return db.Employees.ToList();
        }
    }
}
