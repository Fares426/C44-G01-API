using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.Property(p => p.Name)
        .HasColumnType("varChar")
        .HasMaxLength(256);
    }
}
