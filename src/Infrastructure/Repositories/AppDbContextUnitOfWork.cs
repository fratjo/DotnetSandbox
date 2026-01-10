using Domain.Abstractions;

using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class AppDbContextUnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
}