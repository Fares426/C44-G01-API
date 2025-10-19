
using E_commerce.Domain.Entities.Products;
using E_commerce.Service.Specifications;
using E_commerce.Shared.DataTransferObjects;

namespace E_commerce.Service.Services;

internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    : IProductService
{
    public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
    {
        var brands = await unitOfWork.GetRepository<ProductBrand, int>()
              .GetAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<BrandResponse>>(brands);
    }

    public async Task<ProductResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await unitOfWork.GetRepository<Product, int>()
            .GetAsync(new ProductWithBrandTypeSpecification(id), cancellationToken);

        return mapper.Map<ProductResponse>(product);
    }

    public async Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        var specs = new ProductWithBrandTypeSpecification(parameters);
        var products = await unitOfWork.GetRepository<Product, int>()
      .GetAllAsync(specs, cancellationToken);

        var totalCount = await unitOfWork.GetRepository<Product, int>()
            .CountAsync(new ProductCountSpecification(parameters), cancellationToken);
        var Allproducts = mapper.Map<IEnumerable<ProductResponse>>(products);
        return new(parameters.PageIndex, Allproducts.Count(), totalCount, Allproducts);
    }

    public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
    {
        var types = await unitOfWork.GetRepository<ProductType, int>()
      .GetAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<TypeResponse>>(types);
    }



}
