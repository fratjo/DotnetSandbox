using Application.Users.ReadModels;
using Application.Users.ReadStores;

using Mediator;

namespace Application.Users.Queries.GetUsers;

public sealed class GetUsersQueryHandler(IUserReadStore store) : IQueryHandler<GetUsersQuery, IReadOnlyList<UserListItemReadModel>>
{
    public async Task<IReadOnlyList<UserListItemReadModel>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var userReadItemList = await store.GetAllAsync(cancellationToken);

        return userReadItemList;
    }
}