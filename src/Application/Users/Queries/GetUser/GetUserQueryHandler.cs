using Application.Common;
using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Mediator;

namespace Application.Users.Queries.GetUser;

public sealed class GetUserQueryHandler(IUserReadStore store) : IQueryHandler<GetUserQuery, Option<UserReadModel>>
{
    public async Task<Option<UserReadModel>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var userReadModel = await store.GetByIdAsync(query.UserId, cancellationToken);

        return userReadModel is null ? Option<UserReadModel>.None() : Option<UserReadModel>.Some(userReadModel);
    }
}
