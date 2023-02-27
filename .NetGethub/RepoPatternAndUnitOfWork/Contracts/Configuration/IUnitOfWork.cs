using RepoPatternAndUnitOfWork.Contracts.Repo;

namespace RepoPatternAndUnitOfWork.Contracts.Configuration;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task CompleteAsync();
}
