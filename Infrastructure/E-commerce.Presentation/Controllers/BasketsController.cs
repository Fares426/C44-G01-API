using E_commerce.ServiceAbstraction;
using E_commerce.Shared.DataTransferObjects.Basket;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Presentation.Controllers;

public class BasketsController(IBasketService basketService)
    : APIBaseController
{
    // baseUrl/api/Baskets
    [HttpPost]
    public async Task<ActionResult<CustomerBasketDTO>> Update(CustomerBasketDTO basketDTO)
    {
        return Ok(await basketService.CreateOrUpdateAsync(basketDTO));
    }

    // baseUrl/api/Baskets?id=value
    [HttpGet]
    public async Task<ActionResult<CustomerBasketDTO>> Get(string id)
    {
        return Ok(await basketService.GetByIdAsync(id));
    }

    // baseUrl/api/Baskets?id=value
    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        await basketService.DeleteAsync(id);
        return NoContent();
    }
}
