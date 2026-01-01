namespace Application.Users.ReadModels;

public sealed class UserListItemReadModel
{
    public Guid Id { get; init; }
    public string Username { get; init; } = default!;
}
