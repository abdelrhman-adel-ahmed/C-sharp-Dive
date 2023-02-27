using RepoPatternAndUnitOfWork2.Contracts;

namespace RepoPatternAndUnitOfWork2.Models
{
    public class User : Entity<int>, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
