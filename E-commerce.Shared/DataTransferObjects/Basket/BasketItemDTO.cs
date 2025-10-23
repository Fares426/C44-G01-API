namespace E_commerce.Shared.DataTransferObjects.Basket;

public class BasketItemDTO
{
#nullable disable
    public string Id { get; set; }
    public string Name { get; init; }
    public string PictureUrl { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; set; }
}
