namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IConnectionStringService
{
    Task<string?> GetAsync(string name, CancellationToken cancellationToken = default);
}