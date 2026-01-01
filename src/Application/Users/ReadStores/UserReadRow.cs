namespace Application.Users.ReadStores;

public sealed class UserReadRow
{
    public Guid Id { get; init; }
    public string Username { get; init; } = default!;
    public int Age { get; init; }
}
