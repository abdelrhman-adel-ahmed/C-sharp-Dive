using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace RepoPatternAndUnitOfWork2.Data
{
    public class CustomDbContext : DbContext
    {

        public CustomDbContext()
        {

        }

        public CustomDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public CustomDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {

        }

        public CustomDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        //public CustomDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //
        //}

        public CustomDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {

        }

        protected CustomDbContext(DbCompiledModel model)
            : base(model)
        {

        }

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
