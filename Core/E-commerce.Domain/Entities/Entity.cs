namespace E_commerce.Domain.Entities;

public abstract class Entity<TKey>
{
    public TKey Id { get; set; } = default!;
}
