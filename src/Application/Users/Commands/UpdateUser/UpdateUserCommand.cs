using Application.Abstractions.Mediator;
using Domain.Common;

namespace Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid UserId, string? Username, int? Age) : ICommand<Result>;
