namespace E_commerce.Persistence.Repositories;

internal class UnitOfWork(StoreDbContext dbContext) : IUnitOfWork
{
    public readonly Dictionary<string, object> _repositories = [];
    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        if (_repositories.TryGetValue(typeName, out object? value))
        {
            return (value as IRepository<TEntity, TKey>)!;
        }
        var repo = new Repository<TEntity, TKey>(dbContext);
        _repositories.Add(typeName, repo);
        return repo;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
