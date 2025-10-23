namespace E_commerce.Shared.DataTransferObjects.Basket;

public class CustomerBasketDTO
{
#nullable disable
    public string Id { get; set; }
    public ICollection<BasketItemDTO> Items { get; set; } = [];
}
