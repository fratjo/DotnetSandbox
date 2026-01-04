using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserReadStore(AppDbContext db) : IUserReadStore
{
    public async Task<IReadOnlyList<UserListItemReadModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await db.Users
            .AsNoTracking()
            .Select(u => new UserListItemReadModel
            {
                Id = u.Id,
                Username = u.Username
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<UserReadModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Select(u => new UserReadModel
            {
                Id = u.Id,
                Username = u.Username,
                Age = u.Age
            })
            .SingleOrDefaultAsync(cancellationToken);
    }
}
