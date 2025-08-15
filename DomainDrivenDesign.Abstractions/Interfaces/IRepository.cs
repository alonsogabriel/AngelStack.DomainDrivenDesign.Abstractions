namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IRepository;

public interface IRepository<T> : IRepository where T : class
{
    Task<T?> FindAsync(object id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Remove(T entity);
    void Update(T entity);
    IQueryable<T> Query();
}