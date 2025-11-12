using E_commerce.ServiceAbstraction.Common;
using E_commerce.Shared.DataTransferObjects;
using E_commerce.Shared.DataTransferObjects.Products;

namespace E_commerce.ServiceAbstraction;

public interface IProductService
{
    Task<Result<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default);

    Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);
}
