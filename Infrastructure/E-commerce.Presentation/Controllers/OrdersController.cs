using E_commerce.ServiceAbstraction;
using E_commerce.Shared.DataTransferObjects.UserOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Presentation.Controllers;
[Authorize]
public class OrdersController(IOrderService orderService)
    : APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(OrderRequest orderRequest)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await orderService.CreateAsync(orderRequest, email);
        return HandleResult(result);
    }
}
