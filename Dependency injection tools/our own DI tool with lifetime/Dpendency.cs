using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_injection_tools.our_own_DI_tool_with_lifetime
{
    class Dpendency
    {
        public Dpendency(Type type , DependencyLifeTime lifetime)
        {
            Type = type;
            lifeTime = lifetime;
        }
        public Type Type { get; set; }
        public DependencyLifeTime lifeTime { get; set; }

        public object Implementation { get; set; }
        public bool Implemented { get; set; }

        public void AddImplementation(object i)
        {
            Implementation = i;
            Implemented = true;
        }
    }
}
