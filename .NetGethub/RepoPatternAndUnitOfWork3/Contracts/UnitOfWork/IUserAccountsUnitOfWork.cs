using RepoPatternAndUnitOfWork3.Contracts.Repo;

namespace RepoPatternAndUnitOfWork3.Contracts.UnitOfWork
{
    public interface IUserAccountsUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ISuperAdminUserRepository SuperAdminUserRepository { get; }

    }
}
