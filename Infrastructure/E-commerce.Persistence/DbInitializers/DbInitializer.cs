

using System.Text.Json;

namespace E_commerce.Persistence.DbInitializers;

internal class DbInitializer(ApplicationDbContext dbContext)
    : IDbInitializer
{
    public async Task InitializeAsync()
    {
        try
        {
            if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            if (!dbContext.ProductBrands.Any())
            {
                var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-commerce.Persistence\Context\DataSeed\brands.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData, options);
                if (brands is not null && brands.Any())
                {
                    dbContext.ProductBrands.AddRange(brands);
                }
                await dbContext.SaveChangesAsync();

            }


            if (!dbContext.ProductTypes.Any())
            {
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\E-commerce.Persistence\Context\DataSeed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types is not null && types.Any())
                {
                    dbContext.ProductTypes.AddRange(types);
                }
                await dbContext.SaveChangesAsync();
            }



            if (!dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-commerce.Persistence\Context\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null && products.Any())
                {
                    dbContext.Products.AddRange(products);
                }
                await dbContext.SaveChangesAsync();
            }



        }
        catch (Exception)
        {
            throw;
        }
    }
}
