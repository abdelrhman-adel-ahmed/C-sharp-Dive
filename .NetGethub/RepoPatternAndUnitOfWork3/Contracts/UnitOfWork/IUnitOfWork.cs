using System.Threading.Tasks;

namespace RepoPatternAndUnitOfWork3.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();

       // Task<int> CommitAsync();
    }
}
