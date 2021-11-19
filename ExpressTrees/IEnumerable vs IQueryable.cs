using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressTrees
{
    class IEnumerable_vs_IQueryable
    {
        public static void run()
        {
            int[] its = new[] { 1, 9, 2, 7, 4, 3, 6, 5 };
            IEnumerable<int> result = its.Where(i => i < 5);

            IEnumerable<int> result1 = Enumerable.Where(its, i => i < 5);

            Expression<Func<int, bool>> exp = i => i < 5;

            //IQueryable<int>result2= Queryable.Where(its, exp);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
