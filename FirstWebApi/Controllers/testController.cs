using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAceess;

namespace FirstWebApi.Controllers
{
    public class testController : ApiController
    {

        public IEnumerable<test1> Get()
        {
            firstdbEntities2 tests = new firstdbEntities2();
            return tests.test1.ToList();

        }
        public HttpResponseMessage Post([FromBody]test1 test)
        {
            try
            {
                firstdbEntities2 tests = new firstdbEntities2();
                tests.test1.Add(test);
                tests.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,e.ToString());

            }

        }
    }
}
