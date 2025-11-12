namespace E_commerce.Service.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);

public sealed class ProductNotFoundException(int id)
    : NotFoundException($"Product with id {id} was not found");

public sealed class BasketNotFoundException(string id)
    : NotFoundException($"Product with id {id} was not found");
