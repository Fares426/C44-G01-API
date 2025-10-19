using E_commerce.Domain.Entities.Products;
using System.Linq.Expressions;

namespace E_commerce.Service.Specifications;

internal class ProductWithBrandTypeSpecification : BaseSpecification<Product>
{
    public ProductWithBrandTypeSpecification(ProductQueryParameters parameters)
        : base(CreateCriteria(parameters))
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
        ApplyPagination(parameters.PageSize, parameters.PageIndex);
        Sort(parameters);
    }

    private void Sort(ProductQueryParameters parameters)
    {
        switch (parameters.Sort)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDesc(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDesc(p => p.Price);
                break;
            default:
                AddOrderBy(p => p.Name);
                break;
        }
    }

    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
       && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
       && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
    }

    public ProductWithBrandTypeSpecification(int id)
        : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
    }
}
