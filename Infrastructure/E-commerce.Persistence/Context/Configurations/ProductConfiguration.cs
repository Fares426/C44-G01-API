using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Persistence.Context.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
        .HasColumnType("varChar")
        .HasMaxLength(256);

        builder.Property(p => p.PictureUrl)
        .HasColumnType("varChar")
        .HasMaxLength(256);

        builder.Property(p => p.Description)
        .HasColumnType("varChar")
        .HasMaxLength(1024);

        builder.Property(p => p.Price)
        .HasColumnType("decimal(10,2)");


        builder.HasOne(p => p.ProductBrand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ProductType)
            .WithMany()
            .HasForeignKey(p => p.TypeId)
            .OnDelete(DeleteBehavior.NoAction);



    }
}
