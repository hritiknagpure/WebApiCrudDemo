using Microsoft.EntityFrameworkCore;
using CodefirstDemo.Models;

namespace CodefirstDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the DbSet<Employee> to the table "employe"
            modelBuilder.Entity<Employee>().ToTable("employe");
        }
    }
}
