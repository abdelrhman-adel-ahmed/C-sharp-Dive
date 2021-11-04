using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.MVC
{
    class TheProblem
    {
       public static void run()
        {
            var uri = new Uri("http://localhost/home/index");
            Console.WriteLine(uri.AbsolutePath);
            uri.AbsolutePath.Split('/').Skip(1).ToList().ForEach(x => Console.WriteLine(x));
            if (uri.AbsolutePath.StartsWith("/home/index"))
            {
                //execute some logic (controller action) *index action here 
                //problem here is that we will have many if else for each rout we have (not s
            }
            typeof(TheProblem).Assembly.GetTypes().ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
