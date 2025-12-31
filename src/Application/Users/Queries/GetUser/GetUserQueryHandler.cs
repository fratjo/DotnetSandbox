using Application.Abstractions.Mediator;
using Domain.Common;
using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Application.Users.Queries.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, Option<User>>
{
    public async Task<Option<User>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken);
        return user is null ? Option<User>.None() : Option<User>.Some(user);
    }
}
