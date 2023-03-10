using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace DataAccess;

public class FyStoreDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //string conString = = "Server=(localdb)\\MSSQLLocalDB; Database=FyStore; Trusted_Connection=true";
        string conString =
            "Server=furkanyazar.dev; Database=FyStore; User Id=furkanya; Password=*********; TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        IEnumerable<EntityEntry<Entity>> datas =
            ChangeTracker.Entries<Entity>()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.DateOfCreate = data.Entity.DateOfLastUpdate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.DateOfLastUpdate = DateTime.UtcNow
            };
        }

        return base.SaveChanges();
    }
}