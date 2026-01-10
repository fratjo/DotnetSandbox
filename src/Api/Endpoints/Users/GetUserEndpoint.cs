using Application.Users.Queries.GetUser;
using Application.Users.ReadModels;

using Domain.Common;

using FastEndpoints;

using Mediator;

using Microsoft.AspNetCore.Mvc;

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

        await user.Match(
            some: u => Send.OkAsync(new GetUserResponse
            {
                Id = u.Id,
                Username = u.Username,
                Age = u.Age
            }),
            none: () => Send.NotFoundAsync()
        );
    }
}