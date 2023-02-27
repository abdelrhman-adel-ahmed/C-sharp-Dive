using RepoPatternAndUnitOfWork2.Contracts.UnitOfWork;
using System.Threading.Tasks;

namespace RepoPatternAndUnitOfWork2.Data
{
    public class UnitOfWork<T> : IUnitOfWork
      where T : CustomDbContext
    {
        public UnitOfWork(T dbContext)
        {
            DbContext = dbContext;
        }

        protected T DbContext { get; }

        public bool Commit()
        {
            return DbContext.SaveChanges() > 0;
        }

        //public Task<int> CommitAsync()
        //{
        //    return DbContext.SaveChangesAsync();
        //}
    }
}
