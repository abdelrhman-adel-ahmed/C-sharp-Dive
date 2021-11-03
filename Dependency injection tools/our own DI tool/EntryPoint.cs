using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
  
    class EntryPoint
    {

        public static void run()
        {
          
            //normal way without DI
            //var service =(Service1)Activator.CreateInstance(typeof(Service1));
            //var serviceconsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), service);

            //service.print();
            //serviceconsumer.print();

            var container = new DependencyContainer();

            container.AddDependency(typeof(Service1));
            container.AddDependency<ServiceConsumer>();

            var resolver = new DependencyResolver(container);
            var service = resolver.GetService<Service1>();
            service.print();
  
            var serviceconsumer = resolver.GetService<ServiceConsumer>();
            serviceconsumer.print();

            List<int> ss = new List<int>();
            ss.Add(1);
            Console.WriteLine(ss.Count);

        }
    }
}
