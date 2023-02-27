using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpolyeeAuthServiceApi.Models;

namespace EmpolyeeAuthServiceApi.Controllers
{
    public class StudentV2Controller : ApiController
    {

        static List<StudentV2> stList = new List<StudentV2>
        {
           new StudentV2 {ID=1,Name="ahmed",Age=25},
           new StudentV2 {ID=2,Name="sara",Age=30},
           new StudentV2 {ID=3,Name="noha",Age=3}
        };

        public IEnumerable<StudentV2> Get()
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
