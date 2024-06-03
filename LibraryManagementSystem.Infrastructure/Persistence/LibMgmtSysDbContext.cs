using LibraryManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class LibMgmtSysDbContext : DbContext
    {
        public LibMgmtSysDbContext(DbContextOptions<LibMgmtSysDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
