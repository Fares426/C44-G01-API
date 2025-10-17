using E_commerce.Domain.Entities;

namespace E_commerce.Domain.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : Entity<TKey>;
}
