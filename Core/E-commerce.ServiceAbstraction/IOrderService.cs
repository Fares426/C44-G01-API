using E_commerce.ServiceAbstraction.Common;
using E_commerce.Shared.DataTransferObjects.UserOrder;

namespace E_commerce.ServiceAbstraction;

public interface IOrderService
{
    Task<Result<OrderResponse>> CreateAsync(OrderRequest orderRequest, string email);
}
