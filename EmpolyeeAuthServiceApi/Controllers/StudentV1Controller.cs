using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpolyeeAuthServiceApi.Models;

namespace EmpolyeeAuthServiceApi.Controllers
{
    public class StudentV1Controller : ApiController
    {

        static List<StudentV1> stList = new List<StudentV1>
        {
           new StudentV1 {ID=1,Name="ahmed"},
           new StudentV1 {ID=2,Name="sara"},
           new StudentV1 {ID=3,Name="noha"}
        };

        public IEnumerable<StudentV1> Get()
        {
            return stList;
        }
        public HttpResponseMessage Get(int id )
        {
            var student = stList.FirstOrDefault(x => x.ID == id);
            if (student != null)
                return Request.CreateResponse(student);
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
