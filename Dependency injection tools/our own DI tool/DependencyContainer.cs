using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool
{
    class DependencyContainer
    {

        List<Type> _dependepncies;

        public void AddDependency(Type type)
        {
            _dependepncies.Add(type);
        }
        public Type GetDependency(Type type)
        {
            //compair by name , because we send objects to this function
            return _dependepncies.First(x => x.Name == type.Name);
        }
    }
}
