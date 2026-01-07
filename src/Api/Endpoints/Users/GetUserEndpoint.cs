using Mediator;
using Application.Users.Queries.GetUser;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Application.Common;
using Application.Users.ReadModels;

namespace Api.Endpoints.Users;

public class GetUserRequest
{
    [FromRoute]
    public Guid UserId { get; set; } = Guid.Empty;
}

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public int Age { get; set; }
}

public class GetUserEndpoint(IMediator mediator) : Endpoint<GetUserRequest, GetUserResponse>
{
    public override void Configure()
    {
        Get("api/users/{UserId:Guid}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetUserRequest request, CancellationToken ct)
    {
        var query = new GetUserQuery(request.UserId);
        var user = await mediator.AskAsync(query, ct);
        if (user is Some<UserReadModel> u)
            await Send.OkAsync(new GetUserResponse
            {
                Id = u.Value.Id,
                Username = u.Value.Username,
                Age = u.Value.Age
            });
        else
            await Send.NotFoundAsync();
    }
}
