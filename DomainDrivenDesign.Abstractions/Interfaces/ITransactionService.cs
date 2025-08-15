namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface ITransactionService
{
    Task ExecuteAsync(Func<Task> action, CancellationToken cancellationToken = default);
}