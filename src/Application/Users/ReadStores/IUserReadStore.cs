using Application.Users.ReadModels;

namespace Application.Users.ReadStores;

public interface IUserReadStore
{
    Task<UserReadModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserListItemReadModel>> GetAllAsync(CancellationToken cancellationToken = default);
}