


using Microsoft.EntityFrameworkCore;
using VerticalBackend.Domain.Entities;

namespace Infrastructure.Persistence;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UnitMeasure> UnitMeasures { get; set; }
    public DbSet<Product> Products { get; set; } 
    public DbSet<ProductPrice> ProductPrices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
        });
        
        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.Product)
            .WithMany(p => p.Prices)
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductPrice>()
            .HasOne(pp => pp.UnitMeasure)
            .WithMany(u => u.Prices)
            .HasForeignKey(pp => pp.UnitMeasureId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.ValueA)
            .HasPrecision(18, 4);

        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.ValueB)
            .HasPrecision(18, 4);

        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.ValueC)
            .HasPrecision(18, 4);

        modelBuilder.Entity<ProductPrice>()
            .Property(p => p.ValueD)
            .HasPrecision(18, 4);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Base>(); 
        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

}