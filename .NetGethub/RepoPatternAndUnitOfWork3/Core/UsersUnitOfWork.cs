using RepoPatternAndUnitOfWork3.Contracts.Repo;
using RepoPatternAndUnitOfWork3.Contracts.UnitOfWork;
using RepoPatternAndUnitOfWork3.Data;

namespace RepoPatternAndUnitOfWork3.Core
{
    public class UsersUnitOfWork : UnitOfWork<UserAccountsDbContext>, IUserAccountsUnitOfWork
    {
       public IUserRepository userRepository ;
        
       public ISuperAdminUserRepository superAdminUserRepository;

        public UsersUnitOfWork(UserAccountsDbContext dbContext)
         : base(dbContext)
        {
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(DbContext);
                }

                return userRepository;
            }
        }

        public ISuperAdminUserRepository SuperAdminUserRepository
        {
            get
            {
                if (this.superAdminUserRepository == null)
                {
                    this.superAdminUserRepository = new SuperAdminRepository(DbContext);
                }

                return superAdminUserRepository;
            }
        }


    }
}