using E_commerce.ServiceAbstraction;
using E_commerce.Shared.DataTransferObjects.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Presentation.Controllers;

public class ProductsController(IProductService productService)
    : APIBaseController
{
    //Get All Products (with filtering, sorting, pagination , search)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(CancellationToken cancellationToken = default)
    {
        var response = await productService.GetProductsAsync(cancellationToken);
        return Ok(response);
    }

    //Get By Id (int id)
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var response = await productService.GetByIdAsync(id, cancellationToken);
        return Ok(response);
    }

    //Get Brands
    [HttpGet("Brands")]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
    {
        var response = await productService.GetBrandsAsync(cancellationToken);
        return Ok(response);
    }

    //Get Types 
    [HttpGet("Types")]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
    {
        var response = await productService.GetTypesAsync(cancellationToken);
        return Ok(response);
    }
}
