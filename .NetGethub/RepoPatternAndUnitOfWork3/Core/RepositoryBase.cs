using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepoPatternAndUnitOfWork3.Contracts;
using RepoPatternAndUnitOfWork3.Contracts.Repo;
using RepoPatternAndUnitOfWork3.Data;
using System.Linq.Expressions;

namespace RepoPatternAndUnitOfWork3.Core
{
    public class RepositoryBase<T, TId> : Repository<T, TId>, IRepositoryBase<T, TId>
        where T : Entity<TId>, IAggregateRoot
      where TId : IEquatable<TId>
    {
        public RepositoryBase(CustomDbContext dbContext)
            : base(dbContext)
        {
        }

        public virtual List<T> Get()
        {
            return DbContext.Set<T>().AsNoTracking().ToList();
        }

        public virtual Task<List<T>> GetAsync()
        {
            return DbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual T Get(TId id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual ValueTask<T> GetAsync(TId id)
        {
            return DbContext.Set<T>().FindAsync(id);
        }

        public virtual int Count()
        {
            return DbContext.Set<T>().AsNoTracking().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return DbContext.Set<T>().AsNoTracking().CountAsync();
        }

        public virtual EntityEntry<T> Add(T entity)
        {
            return DbContext.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
             DbContext.Set<T>().AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(TId id)
        {
            var entity = DbContext.Set<T>().Find(id);
            Delete(entity);
        }

        public virtual T FirstOrDefault()
        {
            return DbContext.Set<T>().FirstOrDefault();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate, string include)
        {
            var q = DbContext.Set<T>().Include(include).Where(predicate).AsQueryable();
            return q.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var collection = DbContext.Set<T>().Where(predicate);

            if (includes?.Any() == true)
            {
                foreach (var include in includes)
                {
                    collection = collection.Include(include);
                }
            }

            return collection.FirstOrDefault();
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string include)
        {
            var q = DbContext.Set<T>().Include(include).Where(predicate).AsQueryable();
            return q.FirstOrDefaultAsync();
        }

        public T LastOrDefault(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var collection = DbContext.Set<T>().Where(predicate);

            if (includes?.Any() == true)
            {
                foreach (var include in includes)
                {
                    collection = collection.Include(include);
                }
            }

            return collection.OrderByDescending(i => i.Id).FirstOrDefault();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Any(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().AnyAsync(predicate);
        }
        public bool Any()
        {
            return DbContext.Set<T>().Any();
        }

        public Task<bool> AnyAsync()
        {
            return DbContext.Set<T>().AnyAsync();
        }
        public IEnumerable<T> Filter(Expression<Func<T, bool>> query, params string[] includes)
        {
            var collection = DbContext.Set<T>().Where(query);

            if (includes.Any())
            {
                includes.ToList().ForEach(x => collection = collection.Include(x));
            }

            return collection.ToList();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> query, params string[] includes)
        {
            var collection = DbContext.Set<T>().Where(query);

            if (includes.Any())
            {
                includes.ToList().ForEach(x => collection = collection.Include(x));
            }

            return collection.ToList();
        }
    }

}