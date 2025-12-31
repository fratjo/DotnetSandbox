using Domain.Abstractions;
using Domain.Users.Entities;

namespace Domain.Users.Repositories;

public interface IUserRepository : IGenericRepository<User, Guid>
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken? cancellationToken = null);
}
