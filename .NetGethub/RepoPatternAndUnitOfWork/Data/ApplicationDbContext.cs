using Microsoft.EntityFrameworkCore;
using RepoPatternAndUnitOfWork.Models;

namespace RepoPatternAndUnitOfWork.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		:base(options){}

	public virtual DbSet<User> Users { get; set; }
}
