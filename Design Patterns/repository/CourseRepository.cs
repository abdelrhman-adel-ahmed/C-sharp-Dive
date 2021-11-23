using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Design_Patterns.Domian.repository;
using Design_Patterns.core.repository;
using Design_Patterns.repository;

namespace Design_Patterns.Persistence.repository
{
     class CourseRepository : Repository<Employee>, IEmployeeRepository
    {
        public CourseRepository(MeContext meContext) :base(meContext)
        {

        }
        public IEnumerable<Employee> GetCoursesWithAuthor(int PageIndex, int pageSize)
        {
            return MeContext.Employee.ToList();
        }

        public IEnumerable<Employee> GetTopSellingCourses(int count)
        {
            throw new NotImplementedException();
        }

        public MeContext MeContext { get { return Context as MeContext; } }
    }
}
