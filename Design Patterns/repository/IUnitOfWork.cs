using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.repository;

namespace Design_Patterns.core
{
    interface IUnitOfWork:IDisposable
    {
        ICourseRepository Course { get; }
        int Complete();
    }
}
