using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class TypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnType("varChar")
            .HasMaxLength(256);
    }
}
