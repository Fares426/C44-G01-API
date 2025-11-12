using E_commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.OwnsOne(i => i.Product, o => o.WithOwner());

        builder.Property(p => p.Price)
            .HasColumnType("decimal(10,2)");
    }
}
