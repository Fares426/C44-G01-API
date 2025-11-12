using E_commerce.Domain.Entities.OrderEntities;
using E_commerce.Shared.DataTransferObjects.UserOrder;

namespace E_commerce.Service.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponse>()
            .ForMember(d => d.DeliveryMethod,
            o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.DeliveryMethodCost,
            o => o.MapFrom(s => s.DeliveryMethod.Price))
            .ForMember(d => d.Total,
            o => o.MapFrom(s => s.DeliveryMethod.Price + s.Subtotal));

        CreateMap<OrderAddress, AddressDTO>().ReverseMap();

        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Product.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Product.PictureUrl));

    }
}
