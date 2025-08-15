namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface ICommandHandler<TCommand, TResponse> where TCommand : class, ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}