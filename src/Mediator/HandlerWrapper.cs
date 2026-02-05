
namespace Mediator;

internal sealed class CommandHandlerWrapper<TCommand, TResponse> : ICommandHandlerWrapper<TResponse> where TCommand : ICommand<TResponse>
{
    private readonly ICommandHandler<TCommand, TResponse> _handler;

    public CommandHandlerWrapper(ICommandHandler<TCommand, TResponse> handler)
    {
        _handler = handler;
    }

    public async Task<TResponse> HandleAsync(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        return await _handler.HandleAsync((TCommand)command, cancellationToken);
    }
}

internal sealed class QueryHandlerWrapper<TQuery, TResponse> : IQueryHandlerWrapper<TResponse> where TQuery : IQuery<TResponse>
{
    private readonly IQueryHandler<TQuery, TResponse> _handler;

    public QueryHandlerWrapper(IQueryHandler<TQuery, TResponse> handler)
    {
        _handler = handler;
    }

    public async Task<TResponse> HandleAsync(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        return await _handler.HandleAsync((TQuery)query, cancellationToken);
    }
}
