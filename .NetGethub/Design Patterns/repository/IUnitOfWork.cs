using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.core.repository
{
    interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository Employee { get; }
        int Complete();
    }
}
