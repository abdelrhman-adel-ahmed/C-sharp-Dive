using Microsoft.EntityFrameworkCore;
using RepoPatternAndUnitOfWork.Data;
using RepoPatternAndUnitOfWork.Models;
using RepoPatternAndUnitOfWork.Contracts.Repo;

namespace RepoPatternAndUnitOfWork.Core.Repo;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {}
    public Task<string> GetFirstNameAndLastName(int id)
    {
        throw new NotImplementedException();
    }
    public override async Task<IEnumerable<User>> All()
    {
        try
        {
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
