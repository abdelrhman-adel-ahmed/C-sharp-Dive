using RepoPatternAndUnitOfWork3.Contracts.Repo;
using RepoPatternAndUnitOfWork3.Data;
using RepoPatternAndUnitOfWork3.Models;

namespace RepoPatternAndUnitOfWork3.Core
{
    public class SuperAdminRepository : RepositoryBase<SuperAdmin,int>,ISuperAdminUserRepository
    {

        public SuperAdminRepository(UserAccountsDbContext dbContext)
        : base(dbContext)
        {
        }
    }
}