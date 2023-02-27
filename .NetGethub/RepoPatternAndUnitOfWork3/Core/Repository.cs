using Microsoft.EntityFrameworkCore;
using RepoPatternAndUnitOfWork3.Contracts;
using RepoPatternAndUnitOfWork3.Contracts.Repo;
using RepoPatternAndUnitOfWork3.Data;
using System;

namespace RepoPatternAndUnitOfWork3.Core
{
    public abstract class Repository<T, TId> : IRepository<T, TId>
        where T : Entity<TId>, IAggregateRoot
        where TId : IEquatable<TId>
    {
        public Repository(CustomDbContext dbContext)
        {
            DbContext = dbContext;

            // Set the default configuration for the DbContext
            //dbContext.Configuration.LazyLoadingEnabled = false;
        }

        protected CustomDbContext DbContext { get; }
    }
}