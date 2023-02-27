using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
  
    class EntryPoint2
    {

        public static void run()
        {
            var container = new DependencyContainer();

            container.AddSingletonDependency<Service1>();
            container.AddTransientDependency<ServiceConsumer>();
            container.AddSingletonDependency<Service2>();

            var resolver = new DependencyResolver(container);
          
            //var serviceconsumer = (ServiceConsumer) resolver.GetService(typeof(ServiceConsumer));
            var serviceconsumer1 = resolver.GetService<ServiceConsumer>();
            serviceconsumer1.print();
            var serviceconsumer2 = resolver.GetService<ServiceConsumer>();
            serviceconsumer2.print();
            var serviceconsumer3 = resolver.GetService<ServiceConsumer>();
            serviceconsumer3.print();

        }
    }
}
