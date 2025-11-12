namespace E_commerce.Domain.Entities.Auth;

public class Address
{
#nullable disable
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public ApplicationUser user { get; set; }
    public string userId { get; set; }
}
