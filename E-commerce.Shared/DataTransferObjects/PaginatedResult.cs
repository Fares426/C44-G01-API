namespace E_commerce.Shared.DataTransferObjects;

public record PaginatedResult<TResult>(int PageIndex, int PageCount, int TotalCount, IEnumerable<TResult> Data);
