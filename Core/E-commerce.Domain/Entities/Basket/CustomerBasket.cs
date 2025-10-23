namespace E_commerce.Domain.Entities.Basket;

public class CustomerBasket
{
#nullable disable
    public string Id { get; set; }
    public ICollection<BasketItem> Items { get; set; } = [];
}
