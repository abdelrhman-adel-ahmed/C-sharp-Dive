﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpolyeeAuthServiceApi.Models;

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


        // problem here that we have to get that accept only one paramter so we use attribute constraint
        //we can also use constraint argument to add some restrictions to our parameters 
        [Route("{id:int:min(1)}")]
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
