



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RecyclersConfiguration:IEntityTypeConfiguration<Recycler>
{
    public void Configure(EntityTypeBuilder<Recycler> entity)
    {
        entity.HasKey(r => r.Id);
        entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
        entity.Property(r => r.Gender).IsRequired();
    }

   
}