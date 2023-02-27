using RepoPatternAndUnitOfWork2.Contracts.Repo;

namespace RepoPatternAndUnitOfWork2.Contracts.UnitOfWork
{
    public interface IUserAccountsUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ISuperAdminUserRepository SuperAdminUserRepository { get; }

    }
}
