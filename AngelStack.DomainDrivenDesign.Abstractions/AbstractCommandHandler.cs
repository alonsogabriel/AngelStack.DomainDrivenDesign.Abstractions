namespace AngelStack.DomainDrivenDesign.Abstractions;

public abstract class AbstractCommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : class, ICommand<TResponse>
{
    public abstract Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}