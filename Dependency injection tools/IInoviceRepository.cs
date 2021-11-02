using System.Collections.Generic;

namespace Dependency_injection_tools
{
    internal class InoviceRepositoryBase: IInoviceRepository
    {
     
        IEnumerable<Invoice> IInoviceRepository.FetchAll()
        {
            return new List<Invoice>
            { new Invoice(2,1200),
              new Invoice(3,2000),
            };
        }
    }
}