using Application.Abstractions.Mediator;
using Domain.Shared;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Username, int Age) : ICommand<Result<Guid>>;