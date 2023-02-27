using RepoPatternAndUnitOfWork.Models;

namespace RepoPatternAndUnitOfWork.Contracts.Repo;

public interface IUserRepository : IGenericRepository<User>
{
    Task<string> GetFirstNameAndLastName(int id);
}
