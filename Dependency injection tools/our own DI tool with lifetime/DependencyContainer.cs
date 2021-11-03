using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class DependencyContainer
    {

        List<Type> _dependepncies = new List<Type>();

        public void AddDependency(Type type)
        {
            _dependepncies.Add(type);
        }
        public void AddDependency<T>()
        {
            _dependepncies.Add(typeof(T));
        }
        public Type GetDependency(Type type)
        {
            return _dependepncies.First(x => x.Name == type.Name);
        }

    }
}
