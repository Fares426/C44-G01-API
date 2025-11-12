using E_commerce.Domain.Entities.Basket;
using E_commerce.Shared.DataTransferObjects.Basket;

namespace E_commerce.Service.MappingProfiles;

internal class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
    }
}
