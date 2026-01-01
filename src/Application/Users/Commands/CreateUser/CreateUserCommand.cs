using Application.Abstractions.Mediator;
using Domain.Common;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Username, int Age) : ICommand<Result<Guid>>;