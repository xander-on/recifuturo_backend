using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecifuturoBackend.Products.Domain;

namespace RecifuturoBackend.Products.Infrastructure;

public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> entity)
    {
        entity.ToTable("ProductPrices");

        entity.HasKey(p => p.Id);

        entity.Property(p => p.ValueA).HasPrecision(18, 4);
        entity.Property(p => p.ValueB).HasPrecision(18, 4);
        entity.Property(p => p.ValueC).HasPrecision(18, 4);
        entity.Property(p => p.ValueD).HasPrecision(18, 4);

        
        entity.Property(p => p.ProductId).IsRequired();

        // Relación con Product (aunque no tengas navegación)
        entity.HasOne<Product>()
            .WithMany(p => p.Prices)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación con UnitMeasure (sin navegación)
        entity.Property(p => p.UnitMeasureId).IsRequired();
        entity.HasIndex(p => p.UnitMeasureId); 
    }
}