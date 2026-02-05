namespace Mediator;

public class ConcreteMediator : IMediator
{
    private readonly Dictionary<Type, Object> _handlers = [];

    public void Register<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> handler) where TCommand : ICommand<TResponse>
    { 
        var wrapper = new CommandHandlerWrapper<TCommand, TResponse>(handler);
        _handlers[typeof(TCommand)] = wrapper;
    } 

    public void Register<TQuery, TResponse>(IQueryHandler<TQuery, TResponse> handler) where TQuery : IQuery<TResponse>
    {
        var wrapper = new QueryHandlerWrapper<TQuery, TResponse>(handler);
        _handlers[typeof(TQuery)] = wrapper;
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        if (!_handlers.TryGetValue(command.GetType(), out var handler))
        {
            throw new InvalidOperationException($"No handler registered for command of type {command.GetType().Name}");
        }

        var wrapper = (ICommandHandlerWrapper<TResponse>)handler;
        return await wrapper.HandleAsync(command, cancellationToken);
    }

    public async Task<TResponse> AskAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        if (!_handlers.TryGetValue(query.GetType(), out var handler))
        {
            throw new InvalidOperationException($"No handler registered for query of type {query.GetType().Name}");
        }

        var wrapper = (IQueryHandlerWrapper<TResponse>)handler;
        return await wrapper.HandleAsync(query, cancellationToken);
    }
}