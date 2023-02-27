using Microsoft.EntityFrameworkCore;
using RepoPatternAndUnitOfWork.Contracts.Repo;
using RepoPatternAndUnitOfWork.Data;

namespace RepoPatternAndUnitOfWork.Core.Repo;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext context;
    protected DbSet<T> dbSet;

    public GenericRepository(ApplicationDbContext _context)
    {
        context = _context;
        dbSet = context.Set<T>();
    }
    public async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await dbSet.ToListAsync();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetById(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public Task<bool> Upsert(T entitiy)
    {
        throw new NotImplementedException();
    }
}
