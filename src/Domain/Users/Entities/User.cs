using Domain.Common;
using Domain.Users.Errors;

namespace Domain.Users.Entities;

public class User
{   
    public Guid Id { get; init; } = Guid.NewGuid();
    private DateTime _createdAt { get; init; } = DateTime.UtcNow;

    public string Username { get; private set; } = string.Empty;
    private DateTime _usernameLastUpdated { get; set; } = default;

    public int Age { get; private set; } = 0;

    private User(string username, int age) 
    {
        Username = username.ToUpperInvariant();
        _usernameLastUpdated = DateTime.UtcNow;
        Age = age;
    }

    public static Result<User> Create(string username, int age)
    {
        var errors = new List<DomainError>();

        var now = DateTime.UtcNow;

        errors.AddRange(ValidateUsername(username, null, now));
        errors.AddRange(ValidateAge(age));

        if (errors.Any())
            return Result<User>.Failure(errors.ToArray());

        return Result<User>.Success(new User (username, age));
    }

    public Result UpdateUsername(string newUsername)
    {
        var now = DateTime.UtcNow;
        var errors = ValidateUsername(newUsername, _usernameLastUpdated, now);

        if (errors.Any())
            return Result.Failure(errors.ToArray());

        Username = newUsername.ToUpperInvariant();
        _usernameLastUpdated = DateTime.UtcNow;

        return Result.Success();
    }

    public Result UpdateAge(int newAge)
    {
        var errors = ValidateAge(newAge);

        if (errors.Any())
            return Result.Failure(errors.ToArray());

        Age = newAge;
        
        return Result.Success();
    }

    private static IEnumerable<DomainError> ValidateUsername(string username, DateTime? lastUpdated, DateTime now)
    {
        if (string.IsNullOrWhiteSpace(username))
            yield return UserErrors.UsernameCannotBeEmpty;
        if (lastUpdated.HasValue && (now - lastUpdated.Value).TotalDays < 30)
            yield return UserErrors.UsernameChangeTooFrequent;
    }

    private static IEnumerable<DomainError> ValidateAge(int age)
    {
        if (age < 18 || age > 100)
            yield return UserErrors.AgeMustBeBetween18And100;
    }
}