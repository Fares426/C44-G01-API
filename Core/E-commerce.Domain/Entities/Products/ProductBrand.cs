namespace E_commerce.Domain.Entities.Products;

public class ProductBrand : Entity<int>
{
    public string Name { get; set; } = default!;
}
