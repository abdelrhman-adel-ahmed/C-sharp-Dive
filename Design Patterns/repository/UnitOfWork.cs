using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.core.repository;
using Design_Patterns.Persistence.repository;
using Design_Patterns.repository;

namespace Design_Patterns.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly MeContext _meContext;
        public UnitOfWork(ref MeContext meContext)
        {
            _meContext = meContext;
            Employee = new EmployeeRepository(ref _meContext);
        }

        public IEmployeeRepository Employee { get; private set; }

        public int Complete()
        {
            return _meContext.SaveChanges();
        }

        public void Dispose()
        {
            _meContext.Dispose();
        }
    }
}
