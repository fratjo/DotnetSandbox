namespace Mediator;

internal interface ICommandHandlerWrapper<TResponse>
{
    Task<TResponse> HandleAsync(ICommand<TResponse> command, CancellationToken cancellationToken = default);
}

internal interface IQueryHandlerWrapper<TResponse>
{
    Task<TResponse> HandleAsync(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}
