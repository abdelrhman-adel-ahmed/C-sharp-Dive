using Microsoft.EntityFrameworkCore;

namespace RepoPatternAndUnitOfWork3.Data
{
    public class CustomDbContext : DbContext
    {
        private readonly string _connectionstring;
        private readonly IConfiguration _configuration;
        public CustomDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public CustomDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
        // public CustomDbContext(string connectionstring)
        // {
        //     _connectionstring = connectionstring;
        // }

        //public CustomDbContext(string nameOrConnectionString, DbCompiledModel model)
        //    : base(nameOrConnectionString, model)
        //{
        //
        //}

        //public CustomDbContext(DbConnection existingConnection, bool contextOwnsConnection)
        //    : base(existingConnection, contextOwnsConnection)
        //{
        //
        //}

        //public CustomDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //
        //}

        // public CustomDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
        //     : base(existingConnection, model, contextOwnsConnection)
        // {
        //
        // }
        //
        // protected CustomDbContext(DbCompiledModel model)
        //     : base(model)
        // {
        //
        // }

        public override int SaveChanges()
        {
            //apply audit
            return base.SaveChanges();
        }

        // public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        // {
        //     //apply audit
        //
        //     return base.SaveChangesAsync(cancellationToken);
        // }


    }

}
