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
           
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            var dependency = _container.GetDependency(type);
            //if the type we want to intialize have some parameterized constructor
            var construtor = dependency.Type.GetConstructors().Single();
            //we used to array because tolist doesnot have length function ! <---
            var parameters = construtor.GetParameters().ToList();
            if (parameters.Count > 0)
            {
                var parametersImplemenations = new object[parameters.Count];
                for (int i = 0; i < parameters.Count; i++)
                {
                   
                    parametersImplemenations[i] = GetService(parameters[0].ParameterType);
                }
                // return Activator.CreateInstance(dependency.Type, parametersImplemenations);
                return CreateImplementation(dependency, f => Activator.CreateInstance(f, parametersImplemenations));
            }
            return CreateImplementation(dependency, f => Activator.CreateInstance(f));

        }

        public object CreateImplementation(Dpendency dependency, Func<Type, object> factory)
        {
            //if its Implemented then no need to implement it again, we set the implemented flag if the object lifetime is Singleton
            if (dependency.Implemented)
            {
                return dependency.Implementation;
            }

            //var implementation = Activator.CreateInstance(dependency.Type);
            var implementation = factory(dependency.Type);

            //if it not implemented and the life time is singleton then we need to store that object 
            if (dependency.lifeTime == DependencyLifeTime.Singleton)
            {
                dependency.AddImplementation(implementation);
            }
            return implementation;
        }
    }
}
