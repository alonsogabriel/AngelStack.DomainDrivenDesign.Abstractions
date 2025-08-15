namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface IConnectionStringService
{
    Task<string?> GetAsync(string name, CancellationToken cancellationToken = default);
}