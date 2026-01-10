using Application.Users.ReadStores;

using Domain.Abstractions;
using Domain.Users.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Contexts
        services
            .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"), ServiceLifetime.Scoped);

        // Register your repositories here
        services
            .AddScoped<IUnitOfWork, AppDbContextUnitOfWork>();

        // Register Write Repositories
        services
            .AddScoped<IUserWriteRepository, UserWriteRepository>();

        // Register Read Stores
        services
            .AddScoped<IUserReadStore, UserReadStore>();

        return services;
    }
}