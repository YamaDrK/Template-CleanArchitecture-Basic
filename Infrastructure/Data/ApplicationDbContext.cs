using Domain.Models;
using Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().GenarateUserSeed();
            modelBuilder.Entity<Category>().GenerateCategorySeed();
            modelBuilder.Entity<Product>().GenerateProductSeed();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<double>().HaveColumnType("numeric(18, 2)");
        }
    }
}
