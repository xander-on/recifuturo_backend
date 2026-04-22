using Microsoft.EntityFrameworkCore;
using RecifuturoBackend.Products.Domain;
using RecifuturoBackend.UnitMeasures.Domain;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {}

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();
    public DbSet<UnitMeasure> UnitMeasures => Set<UnitMeasure>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica automáticamente todas las configuraciones
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }



    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Base>();
        var now     = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }

            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = now;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}