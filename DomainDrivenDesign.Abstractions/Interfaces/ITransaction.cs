namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface ITransaction
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
