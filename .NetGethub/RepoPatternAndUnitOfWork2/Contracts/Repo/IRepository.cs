using System;

namespace RepoPatternAndUnitOfWork2.Contracts.Repo
{
    public interface IRepository<T, TId>
       where T : Entity<TId>, IAggregateRoot
       where TId : IEquatable<TId>
    {
    }
}
