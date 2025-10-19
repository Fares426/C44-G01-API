namespace E_commerce.Shared.DataTransferObjects.Products;

public class ProductQueryParameters
{
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string? Search { get; set; }
    public ProductSortingOptions Sort { get; set; }

    private const int MAXPAGESIZE = 10;
    private const int DEFAULTPAGESIZE = 5;
    private int _pageSize = DEFAULTPAGESIZE;

    public int PageSize
    {
        get => _pageSize;
        set => PageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value < DEFAULTPAGESIZE ? DEFAULTPAGESIZE : value;
    }
    public int PageIndex { get; set; } = 1;

}


public enum ProductSortingOptions
{
    NameAsc = 1,
    NameDesc = 2,
    PriceAsc = 3,
    PriceDesc = 4
}
