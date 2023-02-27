using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{


   
    class EntryPoint1
    {

        public static void run()
        {



          
            ////normal way without DI
            ////var service =(Service1)Activator.CreateInstance(typeof(Service1));
            ////var serviceconsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), service);

            ////service.print();
            ////serviceconsumer.print();

            //var container = new DependencyContainer();

            //container.AddDependency(typeof(Service1));
            //container.AddDependency<ServiceConsumer>();
            //container.AddDependency<Service2>();

            //var resolver = new DependencyResolver2(container);
            //var service = resolver.GetService<Service1>();
            //service.print();

            ////var serviceconsumer = (ServiceConsumer) resolver.GetService(typeof(ServiceConsumer));
            //var serviceconsumer1 = resolver.GetService<ServiceConsumer>();
            //serviceconsumer1.print();
            //var serviceconsumer2 = resolver.GetService<ServiceConsumer>();
            //serviceconsumer2.print();
            //var serviceconsumer3 = resolver.GetService<ServiceConsumer>();
            //serviceconsumer3.print();



        }
    }


}
