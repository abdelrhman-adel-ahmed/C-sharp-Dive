using System.Threading.Tasks;

namespace RepoPatternAndUnitOfWork2.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();

       // Task<int> CommitAsync();
    }
}
