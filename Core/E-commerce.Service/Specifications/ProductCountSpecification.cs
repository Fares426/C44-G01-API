using E_commerce.Domain.Entities.Products;
using System.Linq.Expressions;

namespace E_commerce.Service.Specifications;

internal sealed class ProductCountSpecification(ProductQueryParameters parameters)
    : BaseSpecification<Product>(CreateCriteria(parameters))
{
    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
       && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
       && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
    }
}
