using Application.Abstractions.Mediator;
using Domain.Shared;
using Domain.Users.Entities;

namespace Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IQuery<List<User>>;
