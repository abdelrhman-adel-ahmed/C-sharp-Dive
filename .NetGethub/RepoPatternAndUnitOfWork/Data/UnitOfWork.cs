using RepoPatternAndUnitOfWork.Contracts.Configuration;
using RepoPatternAndUnitOfWork.Contracts.Repo;
using RepoPatternAndUnitOfWork.Core.Repo;

namespace RepoPatternAndUnitOfWork.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly ApplicationDbContext context;
    public IUserRepository Users { get; private set; }

    public UnitOfWork(ApplicationDbContext _context)
    {
        context = _context;
        Users = new UserRepository(context);
    }

    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
