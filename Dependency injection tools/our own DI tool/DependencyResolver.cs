using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class DependencyResolver
    {
        DependencyContainer _container;
        public DependencyResolver(DependencyContainer container)
        {
            _container = container;
        }

        //return an instance of the type we pass
        public T GetService<T>()
        {
            var type = _container.GetDependency(typeof(T));
            return (T)Activator.CreateInstance(type);
        }
    }
}
