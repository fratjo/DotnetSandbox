using System.Security.Cryptography;

namespace Domain.Abstractions;

public interface IGenericWriteRepository<TEntity, TId> where TEntity : class
{
    Task<TEntity?> LoadByIdAsync(TId id, CancellationToken cancellationToken = default); // Optional: For checking existence before update/delete in command handlers only
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}
