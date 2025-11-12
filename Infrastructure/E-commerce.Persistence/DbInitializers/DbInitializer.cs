using E_commerce.Domain.Entities.Auth;
using E_commerce.Domain.Entities.OrderEntities;
using E_commerce.Persistence.Context.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace E_commerce.Persistence.DbInitializers;

internal class DbInitializer(StoreDbContext dbContext,
    AuthDbContext authDbContext,
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager,
    ILogger<DbInitializer> logger)
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

            if (!dbContext.DeliveryMethods.Any())
            {
                var deliveryData = await File.ReadAllTextAsync(@"..\Infrastructure\E-commerce.Persistence\Context\DataSeed\delivery.json");
                var delivery = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                if (delivery is not null && delivery.Any())
                {
                    dbContext.DeliveryMethods.AddRange(delivery);
                }
                await dbContext.SaveChangesAsync();
            }



        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task InitializeAuthDbAsync()
    {
        await authDbContext.Database.MigrateAsync();

        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        }


        if (!userManager.Users.Any())
        {
            var superAdminUser = new ApplicationUser
            {
                DisplayName = "Super Admin",
                Email = "SuperAdmin@gmail.com",
                UserName = "SuperAdmin",
                PhoneNumber = "012345678900"
            };
            var adminUser = new ApplicationUser
            {
                DisplayName = "Admin",
                Email = "Admin@gmail.com",
                UserName = "Admin",
                PhoneNumber = "012345678900"
            };

            await userManager.CreateAsync(superAdminUser, "SuperAdmin@123");
            await userManager.CreateAsync(adminUser, "Admin@123");


            await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
