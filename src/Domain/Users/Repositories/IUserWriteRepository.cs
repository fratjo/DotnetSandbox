using Domain.Abstractions;
using Domain.Users.Entities;

namespace Domain.Users.Repositories;

public interface IUserWriteRepository : IGenericWriteRepository<User, Guid>
{
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
}