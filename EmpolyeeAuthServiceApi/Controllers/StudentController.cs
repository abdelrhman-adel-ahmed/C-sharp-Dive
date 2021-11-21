﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpolyeeAuthServiceApi.Models;

namespace EmpolyeeAuthServiceApi.Controllers
{
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

        [Route("api/student/{id}")]
        public Student Get(int id)
        {
            return stList.FirstOrDefault(i => i.ID == id);
        }

        [Route("api/student/{id}/courses")]
        public List<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string> { "c#", "db" };
            else
                return new List<string> { "c++", "os" };


        }
    }
}