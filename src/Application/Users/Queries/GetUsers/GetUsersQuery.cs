using Application.Abstractions.Mediator;
using Application.Users.ReadModels;

namespace Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IQuery<List<UserListItemReadModel>>;
