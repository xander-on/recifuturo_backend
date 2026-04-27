using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecifuturoBackend.Products.Domain;

namespace RecifuturoBackend.Products.Infrastructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("Products");

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        entity.HasIndex(p => p.Name)
            .IsUnique();

        entity.HasMany(p => p.Prices)
            .WithOne()
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}