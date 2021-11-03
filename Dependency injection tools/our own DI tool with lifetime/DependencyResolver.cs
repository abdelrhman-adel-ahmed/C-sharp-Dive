using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
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
            //if the type we want to intialize have some parameterized constructor
            var construtor = type.GetConstructors().Single();
            //we used toarray because tolist doesnot have length function ! <---
            var parameters = construtor.GetParameters().ToList();
            if (parameters.Count > 0)
            {
                var parametersImplemenations = new object[parameters.Count];
                for (int i = 0; i < parameters.Count; i++)
                {
                    parametersImplemenations[i] = Activator.CreateInstance(parameters[0].ParameterType);
                }
                return (T) Activator.CreateInstance(type, parametersImplemenations);
            }              
            else           
            {              
                return (T) Activator.CreateInstance(type);

            }
        }
    }
}
