using Domain.EntityAbstractions;
using Domain.Enums;
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
        public DbSet<Audit> Audit { get; set; }

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

        public virtual async Task<int> SaveChangesAsync(string? userId = null)
        {
            OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        private void OnBeforeSaveChanges(string? userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId ?? "Unknown"
                };

                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (propertyName == nameof(AuditableEntity.IsDeleted)
                        || propertyName == nameof(AuditableEntity.CreationDate)
                        || propertyName == nameof(AuditableEntity.ModificationDate)
                        || propertyName == nameof(AuditableEntity.DeletionDate))
                    {
                        continue;
                    }

                    if (property.Metadata.IsPrimaryKey())
                    {
                        if (entry.State != EntityState.Added || entry.Entity is not BaseEntity)
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        }
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditTypeEnum.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditTypeEnum.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                if (property.OriginalValue != null
                                    && !property.OriginalValue.Equals(property.CurrentValue))
                                {
                                    auditEntry.ChangedColumns.Add(propertyName);
                                }
                                auditEntry.AuditType = AuditTypeEnum.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                Audit.Add(auditEntry.ToAudit());
            }
        }
    }
}
