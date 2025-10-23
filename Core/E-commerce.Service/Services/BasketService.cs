using E_commerce.Domain.Entities.Basket;
using E_commerce.Shared.DataTransferObjects.Basket;

namespace E_commerce.Service.Services;

internal class BasketService(IBasketRepository basketRepository, IMapper mapper)
    : IBasketService
{
    public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO)
    {
        var basket = mapper.Map<CustomerBasket>(basketDTO);
        var updatedBasket = await basketRepository.CreateOrUpdateAsync(basket);
        return mapper.Map<CustomerBasketDTO>(updatedBasket);
    }

    public Task DeleteAsync(string id)
    {
        return basketRepository.DeleteAsync(id);
    }

    public async Task<CustomerBasketDTO> GetByIdAsync(string id)
    {
        var basket = await basketRepository.GetAsync(id);
        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
