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
        //naming : either the method name start with the http verb or we add verb attribute

        //public IEnumerable<test1> GetTest()
        //{
        //    firstdbEntities2 tests = new firstdbEntities2();
        //    return tests.test1.ToList();

        //}

        //end point accept query string
        public HttpResponseMessage Get(string city="all")
        {
            firstdbEntities2 db = new firstdbEntities2();

            switch(city.ToLower())
            {
                case "all":
                    return Request.CreateResponse(HttpStatusCode.OK, db.test1.ToList());
                case "cairo":
                    return Request.CreateResponse(HttpStatusCode.OK, db.test1.Where(x=>x.city.ToLower()=="cairo").ToList());

                case "alex":
                    return Request.CreateResponse(HttpStatusCode.OK, db.test1.Where(x => x.city.ToLower() == "alex").ToList());
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not valid value");
            }
        }
        [HttpPost]
        public HttpResponseMessage CreateEmployee([FromBody]test1 test)
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
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                firstdbEntities2 tests = new firstdbEntities2();
                test1 t = tests.test1.FirstOrDefault(i => i.id == id);
                tests.test1.Remove(t);
                tests.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, $"test with id {id} got deleted");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());

            }

        }

        public HttpResponseMessage Put([FromBody]test1 test)
        {
            firstdbEntities2 tests = new firstdbEntities2();
           
            var tt = tests.test1.FirstOrDefault(x => x.id == test.id);
            if(tt == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"test cannot be found");
            }
            tt.age = test.age;
            tt.name = test.name;
            tt.city = test.city;
            tests.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
