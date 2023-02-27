using RepoPatternAndUnitOfWork2.Models;
using System.Data.Entity;

namespace RepoPatternAndUnitOfWork2.Data
{
    public class UserAccountsDbContext : CustomDbContext
    {
        public UserAccountsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<SuperAdmin> SuperAdminUsers { get; set; }
    }
}