using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace RepoPatternAndUnitOfWork3.Contracts.Repo
{
    public interface IRepositoryBase<T, TId> : IRepository<T, TId>
    where T : Entity<TId>, IAggregateRoot
    where TId : IEquatable<TId>
    {
        List<T> Get();
        Task<List<T>> GetAsync();
        T Get(TId id);

        ValueTask<T> GetAsync(TId id);

        int Count();

        Task<int> CountAsync();

        EntityEntry<T> Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Delete(TId id);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate, string include);

        T FirstOrDefault(Expression<Func<T, bool>> predicate, params string[] includes);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string include);

        bool Any();

        Task<bool> AnyAsync();

        bool Any(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);


        IEnumerable<T> Filter(Expression<Func<T, bool>> query, params string[] includes);

        IEnumerable<T> Get(Expression<Func<T, bool>> query, params string[] includes);

        T LastOrDefault(Expression<Func<T, bool>> predicate, params string[] includes);

    }

}
