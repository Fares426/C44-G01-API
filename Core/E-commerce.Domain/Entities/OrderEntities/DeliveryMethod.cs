namespace E_commerce.Domain.Entities.OrderEntities;

public class DeliveryMethod : Entity<int>
{
#nullable disable
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string DeliveryTime { get; set; }
    public decimal Price { get; set; }

}
