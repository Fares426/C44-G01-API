using E_commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(p => p.Price)
            .HasColumnType("decimal(10,2)");

        builder.Property(p => p.ShortName)
            .HasColumnType("varChar")
            .HasMaxLength(128);

        builder.Property(p => p.DeliveryTime)
            .HasColumnType("varChar")
            .HasMaxLength(128);

        builder.Property(p => p.Description)
            .HasColumnType("varChar")
            .HasMaxLength(128);
    }
}
