using Application.Users.ReadModels;
using Application.Common;
using Mediator;

namespace Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Maybe<UserReadModel>>;
