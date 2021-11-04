using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class DependencyContainer
    {

        List<Dpendency> _dependepncies = new List<Dpendency>();

        public void AddTransientDependency<T>()
        {
            _dependepncies.Add(new Dpendency(typeof(T), DependencyLifeTime.Transient));
        }
        public void AddSingletonDependency<T>()
        {
            _dependepncies.Add(new Dpendency(typeof(T), DependencyLifeTime.Singleton));
        }
        public Dpendency GetDependency(Type type)
        {

            return _dependepncies.First(x => x.Type.Name == type.Name);
        }

    }
}
