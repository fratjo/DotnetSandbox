using Application.Abstractions.Mediator;
using Application.Users.ReadModels;
using Domain.Common;

namespace Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Option<UserReadModel>>;
