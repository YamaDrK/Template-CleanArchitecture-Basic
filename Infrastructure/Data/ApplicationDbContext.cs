using Domain.Models;
using Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<double>().HaveColumnType("numeric(18, 2)");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().GenarateUserSeed();
            modelBuilder.Entity<Category>().GenerateCategorySeed();
            modelBuilder.Entity<Product>().GenerateProductSeed();
        }
    }
}
