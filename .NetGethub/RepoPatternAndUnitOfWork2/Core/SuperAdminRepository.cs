using RepoPatternAndUnitOfWork2.Contracts.Repo;
using RepoPatternAndUnitOfWork2.Data;
using RepoPatternAndUnitOfWork2.Models;

namespace RepoPatternAndUnitOfWork2.Core
{
    public class SuperAdminRepository : RepositoryBase<SuperAdmin,int>,ISuperAdminUserRepository
    {

        public SuperAdminRepository(UserAccountsDbContext dbContext)
        : base(dbContext)
        {
        }
    }
}