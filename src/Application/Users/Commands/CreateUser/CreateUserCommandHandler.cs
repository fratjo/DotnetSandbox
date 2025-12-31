using Application.Abstractions.Mediator;
using Domain.Shared;
using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        var existingUser = await userRepository.GetByUsernameAsync(command.Username.ToUpperInvariant(), cancellationToken);
        if (existingUser is not null)
            return Result<Guid>.Conflict("Username already exists.");

        var result = User.Create(command.Username, command.Age);

        if (result.IsSuccess && result.Value is not null)
        {
            await userRepository.AddAsync(result.Value, cancellationToken);
            return await Task.FromResult(Result<Guid>.Success(result.Value.Id));
        }
        else
            return await Task.FromResult(Result<Guid>.Failure(result.Message));
        
    }
}