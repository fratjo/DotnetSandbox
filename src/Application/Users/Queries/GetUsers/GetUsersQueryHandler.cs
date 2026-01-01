using Application.Abstractions.Mediator;
using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Domain.Common;
using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUserReadStore store) : IQueryHandler<GetUsersQuery, List<UserListItemReadModel>>
{
    public async Task<List<UserListItemReadModel>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await store.GetAllAsync(cancellationToken);
        
        return rows.Select(user => new UserListItemReadModel
        {
            Id = user.Id,
            Username = user.Username
        }).ToList();
    }
}
