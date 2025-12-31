using Application.Abstractions.Mediator;
using Domain.Common;
using Domain.Users.Entities;

namespace Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Option<User>>;
