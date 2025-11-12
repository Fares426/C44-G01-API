using E_commerce.Domain.Entities.Products;

namespace E_commerce.Service.Specifications;

internal class GetProductsByIdsSpecification(List<int> ids)
    : BaseSpecification<Product>(p => ids.Contains(p.Id));
