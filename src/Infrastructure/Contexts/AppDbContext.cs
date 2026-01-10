using Domain.Users.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}