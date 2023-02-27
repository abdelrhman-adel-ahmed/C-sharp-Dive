using Microsoft.EntityFrameworkCore;
using RepoPatternAndUnitOfWork3.Models;

namespace RepoPatternAndUnitOfWork3.Data
{
    public class UserAccountsDbContext : CustomDbContext
    {
        // private readonly IConfiguration _configuration;
        // private readonly string connectionstring;
        // public UserAccountsDbContext(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        //     connectionstring = _configuration.GetConnectionString("DefaultConnection");
        // }
        public UserAccountsDbContext(DbContextOptions<UserAccountsDbContext> contextOptions)
        : base(contextOptions)
        { 
        }
       // public UserAccountsDbContext(string connectionString = "DataSource=app.db;Cache=Shared")
       // : base(connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<SuperAdmin> SuperAdminUsers { get; set; }

    }
}