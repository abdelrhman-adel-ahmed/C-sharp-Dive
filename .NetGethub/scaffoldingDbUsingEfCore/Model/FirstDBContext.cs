using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace scaffoldingDbUsingEfCore.Model
{
    public partial class FirstDBContext : DbContext
    {
        public FirstDBContext()
        {
        }

        public FirstDBContext(DbContextOptions<FirstDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetSqlCacheTablesForChangeNotification> AspNetSqlCacheTablesForChangeNotifications { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Departmentss> Departmentsses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeess> Employeesses { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<PlayList> PlayLists { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        public virtual DbSet<TblStudent> TblStudents { get; set; }
        public virtual DbSet<Test1> Test1s { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Zrbo> Zrbos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FirstDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetSqlCacheTablesForChangeNotification>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK__AspNet_S__93F7AC69EDD84FAC");

                entity.ToTable("AspNet_SqlCacheTablesForChangeNotification");

                entity.Property(e => e.TableName).HasColumnName("tableName");

                entity.Property(e => e.ChangeId).HasColumnName("changeId");

                entity.Property(e => e.NotificationCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("notificationCreated")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Departmentss>(entity =>
            {
                entity.ToTable("Departmentss");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__0D7A0286");
            });

            modelBuilder.Entity<Employeess>(entity =>
            {
                entity.ToTable("Employeess");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employeesses)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__06CD04F7");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PlayList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tblEmplo__7AD04F11DECBE5DF");

                entity.ToTable("tblEmployees");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.ToTable("tblStudents");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Test1>(entity =>
            {
                entity.ToTable("test1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasIndex(e => e.PlayListId, "IX_playlist_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlayListId).HasColumnName("PlayList_ID");

                entity.HasOne(d => d.PlayList)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.PlayListId)
                    .HasConstraintName("FK_dbo.Videos_dbo.PlayLists_PlayList_ID");
            });

            modelBuilder.Entity<Zrbo>(entity =>
            {
                entity.ToTable("zrbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
