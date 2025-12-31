using Application.Abstractions.Mediator;
using Domain.Shared;
using Microsoft.Extensions.DependencyInjection;
using Domain.Users.Entities;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Domain.Common;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetUserQuery, Option<User>>, GetUserQueryHandler>();
        services.AddScoped<IQueryHandler<GetUsersQuery, List<User>>, GetUsersQueryHandler>();

        return services;
    }
}
