using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Design_Patterns.core.repository;
using Design_Patterns.Domian.repository;

namespace Design_Patterns.repository
{
    interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthor(int PageIndex, int pageSize);


    }
}
