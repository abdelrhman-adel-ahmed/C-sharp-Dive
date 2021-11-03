using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
  
    class EntryPoint1
    {

        public static void run()
        {
            var container = new DependencyContainer();

            container.AddDependency(typeof(Service1));
            container.AddDependency<ServiceConsumer>();
            container.AddDependency<Service2>();

            var resolver = new DependencyResolver2(container);
            var service = resolver.GetService<Service1>();
            service.print();

            //var serviceconsumer = (ServiceConsumer) resolver.GetService(typeof(ServiceConsumer));
            var serviceconsumer = resolver.GetService<ServiceConsumer>();
            serviceconsumer.print();


        }
    }
}
