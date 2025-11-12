using E_commerce.Domain.Entities.OrderEntities;
using E_commerce.Domain.Entities.Products;
using E_commerce.Service.Specifications;
using E_commerce.Shared.DataTransferObjects.UserOrder;

namespace E_commerce.Service.Services;

internal class OrderService(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository)
    : IOrderService
{
    public async Task<Result<OrderResponse>> CreateAsync(OrderRequest orderRequest, string email)
    {
        var basket = await basketRepository.GetAsync(orderRequest.BasketId);
        if (basket is null)
            return Error.NotFound("Basket not found", $"Basket with ID {orderRequest.BasketId} Was Not Found");




        var method = await unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderRequest.DeliveryMehotdId);
        if (method is null)
            return Error.NotFound("Delivery Method not found", $"Delivery Method with ID {orderRequest.DeliveryMehotdId} Was Not Found");




        var productRepo = unitOfWork.GetRepository<Product, int>();
        var ids = basket.Items.Select(i => i.Id).ToList();
        var products = (await productRepo.GetAllAsync(new GetProductsByIdsSpecification(ids))).ToDictionary(p => p.Id);
        var validationErrors = new List<Error>();
        var orderItems = new List<OrderItem>();



        foreach (var item in basket.Items)
        {
            if (!products.TryGetValue(item.Id, out Product? product))
            {
                validationErrors.Add(Error.NotFound("Product not found", $"Product with ID {item.Id} Was Not Found"));
                continue;
            }


            var orderItem = new OrderItem
            {
                Price = product.Price,
                Quantity = item.Quantity,
                Product = new ProductInOrderItem
                {
                    Name = product.Name,
                    PictureUrl = product.PictureUrl,
                    ProductId = product.Id
                }
            };


            orderItems.Add(orderItem);
        }

        if (validationErrors.Any())
            return validationErrors;


        var subtotal = orderItems.Sum(oi => oi.Price * oi.Quantity);
        var address = mapper.Map<OrderAddress>(orderRequest.Address);

        var order = new Order
        {
            DeliveryMethod = method,
            UserEmail = email,
            OrderItems = orderItems,
            Subtotal = subtotal,
            Address = address
        };

        unitOfWork.GetRepository<Order, Guid>().Add(order);

        await unitOfWork.SaveChangesAsync();

        return mapper.Map<OrderResponse>(order);
    }
}
