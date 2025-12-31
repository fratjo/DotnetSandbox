using Application.Abstractions.Mediator;
using Domain.Shared;
using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, List<User>>
{
    public async Task<List<User>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        return [.. users];
    }
}
