using Domain.Abstractions;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class UnitOfWork(CacheContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken? cancellationToken = default) => await Task.CompletedTask;
}
