using E_commerce.Shared.DataTransferObjects.Basket;

namespace E_commerce.ServiceAbstraction;

public interface IBasketService
{
    Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO);
    Task<CustomerBasketDTO> GetByIdAsync(string id);
    Task DeleteAsync(string id);
}
