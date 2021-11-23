using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Design_Patterns.Domian.repository;
using Design_Patterns.repository;

namespace Design_Patterns.Persistenec.repository
{
     class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository():base(new DbContext("x"))
        {

        }
        public IEnumerable<Course> GetCoursesWithAuthor(int PageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            throw new NotImplementedException();
        }
    }
}
