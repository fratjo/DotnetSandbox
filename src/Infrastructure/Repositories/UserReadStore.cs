using Application.Users.ReadStores;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserReadStore(AppDbContext db) : IUserReadStore
{
    public async Task<List<UserReadRow>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await db.Users
            .AsNoTracking()
            .Select(u => new UserReadRow
            {
                Id = u.Id,
                Username = u.Username,
                Age = u.Age
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<UserReadRow?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Select(u => new UserReadRow
            {
                Id = u.Id,
                Username = u.Username,
                Age = u.Age
            })
            .SingleOrDefaultAsync(cancellationToken);
    }
}
