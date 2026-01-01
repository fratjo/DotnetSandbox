using Application.Abstractions.Mediator;
using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Domain.Common;

namespace Application.Users.Queries.GetUser;

public class GetUserQueryHandler(IUserReadStore store) : IQueryHandler<GetUserQuery, Option<UserReadModel>>
{
    public async Task<Option<UserReadModel>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var row = await store.GetByIdAsync(query.UserId, cancellationToken);

        return row is null ? Option<UserReadModel>.None() : Option<UserReadModel>.Some(new UserReadModel
        {
            Id = row.Id,
            Username = row.Username,
            Age = row.Age
        });
    }
}
