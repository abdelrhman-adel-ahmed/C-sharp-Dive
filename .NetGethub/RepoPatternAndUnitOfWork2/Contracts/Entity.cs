using System;

namespace RepoPatternAndUnitOfWork2.Contracts
{
    public abstract class Entity<T>
     where T : IEquatable<T>
    {
        public Entity(T id)
        {
            this.Id = id;
        }

        protected Entity()
        {
        }

        public virtual T Id { get; set; }

        public override bool Equals(object obj)
        {
            Entity<T> entity = obj as Entity<T>;

            if (entity != null)
            {
                return Id.Equals(entity.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.ToString().GetHashCode();
        }
    }

}
