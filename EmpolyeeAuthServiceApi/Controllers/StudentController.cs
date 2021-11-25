using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpolyeeAuthServiceApi.Models;
using System.Data.Entity;

namespace EmpolyeeAuthServiceApi.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        static List<Student> stList = new List<Student>
        {
           new Student {ID=1,Name="ahmed"},
           new Student {ID=2,Name="sara"},
           new Student {ID=3,Name="noha"}
        };


        [Route("~/api/student/xx")]
        public HttpResponseMessage GetUsing()
        {
            return Request.CreateResponse(HttpStatusCode.OK, stList);
        }

        [Route("~/api/student/xx/{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            var student = stList.FirstOrDefault(x => x.ID == id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "sorry");
            }
            return Request.CreateResponse(HttpStatusCode.Found, student);
        }
        public IHttpActionResult GetStudentActionResult(int id)
        {
            var student = stList.FirstOrDefault(x => x.ID == id);
            if (student == null)
            {
                return Ok(student + "aaa");
            }
            else
                return Ok(HttpStatusCode.NotFound);

        }

        public IEnumerable<Student> Get()
        {
            return stList;
        }

        //overwrite the route prefix to avoid type api/student/api/teacher to enter the teacher controller
        [Route("~/api/teacher")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return new List<Teacher>()
            {
                new Teacher(){ID=1,Name="t1" },
                new Teacher{ID=1,Name="t1" },

            };

        }

        public HttpResponseMessage Post(Student student)
        {
            stList.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            //send url that user can access to view newly created student
            //here if the user at then put / so we dont add it ,and vice versa or
            //we can use the line builder and use the end point name :
            // new Uri(Url.Link("GetStudentByid", new { id = student.ID }));
            var req_uri = Request.RequestUri.ToString().EndsWith("/") ?
                Request.RequestUri.ToString() : Request.RequestUri.ToString() + "/";
            response.Headers.Location = new Uri(req_uri + student.ID.ToString());
            return response;
        }

        //we can also use constraint argument to add some restrictions to our parameters 

        //name attr we can use it later to resolve the url of the controller dynamiclly without have to 
        //explictly type it 
        [Route("{id:int:min(1)}", Name = "GetStudentByid")]
        public Student Get(int id)
        {
            return stList.FirstOrDefault(i => i.ID == id);
        }

        [Route("{name:alpha}")]
        public Student Get(string name)
        {
            return stList.FirstOrDefault(i => i.Name == name);
        }
        //it used from the Route prefix
        [Route("{id}/courses")]
        public List<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string> { "c#", "db" };
            else
                return new List<string> { "c++", "os" };


        }
    }
}
