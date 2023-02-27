using RepoPatternAndUnitOfWork2.Contracts.Repo;
using RepoPatternAndUnitOfWork2.Data;
using RepoPatternAndUnitOfWork2.Models;

namespace RepoPatternAndUnitOfWork2.Core
{
    public class UserRepository: RepositoryBase<User,int>,IUserRepository
    {
        public UserRepository(UserAccountsDbContext dbContext)
         : base(dbContext)
        {
        }
    }
}