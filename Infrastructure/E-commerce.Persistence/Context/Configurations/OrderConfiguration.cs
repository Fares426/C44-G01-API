global using Order = E_commerce.Domain.Entities.OrderEntities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(x => x.OrderItems)
            .WithOne()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DeliveryMethod)
            .WithMany()
            .HasForeignKey(o => o.DeliveryMethodId)
            .OnDelete(DeleteBehavior.SetNull);


        builder.OwnsOne(o => o.Address, x => x.WithOwner());

        builder.HasIndex(x => x.UserEmail);

        builder.Property(p => p.Subtotal)
            .HasColumnType("decimal(10,2)");

        builder.Property(p => p.UserEmail)
            .HasColumnType("varChar")
            .HasMaxLength(128);


        builder.Property(x => x.Status)
            .HasConversion<string>();


        builder.Property(p => p.PaymentIntentId)
            .HasColumnType("varChar")
            .HasMaxLength(128);
    }
}
