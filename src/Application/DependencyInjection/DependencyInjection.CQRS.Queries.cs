using Application.Abstractions.Mediator;
using Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Application.Users.ReadModels;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetUserQuery, Option<UserReadModel>>, GetUserQueryHandler>();
        services.AddScoped<IQueryHandler<GetUsersQuery, List<UserReadModel>>, GetUsersQueryHandler>();

        return services;
    }
}
