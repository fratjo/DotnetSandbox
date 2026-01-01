namespace Application.Users.ReadStores;

public interface IUserReadStore
{
    Task<UserReadRow?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<UserReadRow>> GetAllAsync(CancellationToken cancellationToken = default);
}
