using System.Collections.Generic;

namespace Dependency_injection_tools
{
    interface IInoviceRepository
    {
         IEnumerable<Invoice> FetchAll();
    }
}