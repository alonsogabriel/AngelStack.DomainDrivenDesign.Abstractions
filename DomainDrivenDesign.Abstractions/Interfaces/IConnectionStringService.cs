namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IConnectionStringService
{
    string? GetAsync(string name, CancellationToken cancellationToken = default);
}