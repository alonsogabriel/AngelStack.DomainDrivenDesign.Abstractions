namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface ITransactionService
{
    Task ExecuteAsync(Func<Task> action, CancellationToken cancellationToken = default);
}