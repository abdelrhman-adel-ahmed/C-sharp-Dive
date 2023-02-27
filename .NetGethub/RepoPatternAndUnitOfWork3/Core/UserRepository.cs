using RepoPatternAndUnitOfWork3.Contracts.Repo;
using RepoPatternAndUnitOfWork3.Data;
using RepoPatternAndUnitOfWork3.Models;

namespace RepoPatternAndUnitOfWork3.Core
{
    public class UserRepository: RepositoryBase<User,int>,IUserRepository
    {
        public UserRepository(CustomDbContext dbContext)
         : base(dbContext)
        {
        }
    }
}