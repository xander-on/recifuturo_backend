using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecifuturoBackend.UnitMeasures.Domain;

namespace RecifuturoBackend.UnitMeasures.Infrastructure;

public class UnitMeasureConfiguration : IEntityTypeConfiguration<UnitMeasure>
{
    public void Configure(EntityTypeBuilder<UnitMeasure> entity)
    {
        entity.ToTable("UnitMeasures");

        entity.HasKey(u => u.Id);

        entity.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Opcional pero recomendado: evitar duplicados a nivel DB
        entity.HasIndex(u => u.Name)
            .IsUnique();

        entity.Property(u => u.Abbreviation)
            .HasMaxLength(10)
            .IsRequired(false);
    }
}