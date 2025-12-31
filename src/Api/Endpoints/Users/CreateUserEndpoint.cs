using Application.Abstractions.Mediator;
using Application.Users.Commands.CreateUser;
using FastEndpoints;

namespace Api.Endpoints.Users;

public class CreateUserRequest
{
    public string Username { get; set; } = null!;
    public int Age { get; set; }
}

public class CreateUserResponse
{
    public Guid UserId { get; set; }
}

public class CreateUserEndpoint(IMediator mediator) : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override void Configure()
    {
        Post("api/users");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create Users";
            s.Description = "Creates a new user in the system.";
            s.Responses[201] = "Returns the newly created user's ID.";
            s.Responses[409] = "Conflict - Already existing user";
        });
    }
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        var command = new CreateUserCommand(
            request.Username, 
            request.Age);
        
        var result = await mediator.SendAsync(command, ct);
        
        if (result.IsSuccess)
            await Send.OkAsync(new CreateUserResponse { UserId = result.Value });
        else
            await Send.ResultAsync(TypedResults.Problem(result.Message ?? "Failed to create user.", null, (int)result.ErrorType));
    }
}
