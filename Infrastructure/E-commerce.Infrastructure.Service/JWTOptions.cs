namespace E_commerce.Infrastructure.Service;

public class JWTOptions
{
    public static string SectionName { get; set; } = "JWTOptions";
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationInHours { get; set; }
}
