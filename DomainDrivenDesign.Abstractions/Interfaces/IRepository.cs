namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IRepository;

public interface ICommonRepository : IRepository
{
    Task<T?> FindAsync<T>(object id, CancellationToken cancellationToken) where T : class;
    Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    Task RemoveAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    Task UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
}

public interface IRepository<T> : IRepository where T : class
{
    Task<T?> FindAsync(object id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task RemoveAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
}