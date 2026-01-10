namespace Application.Users.ReadModels;

public sealed class UserReadModel
{
    public Guid Id { get; init; }
    public string Username { get; init; } = default!;
    public int Age { get; init; }
}