using Domain.Common;

namespace Domain.Users.Errors;

public sealed record UserErrorCode(string Value) : DomainErrorCode(Value)
{
    public static readonly UserErrorCode UsernameEmpty =
        new("user.username.empty");

    public static readonly UserErrorCode UsernameTooSoon =
        new("user.username.too_soon");

    public static readonly UserErrorCode AgeInvalid =
        new("user.age.invalid");

    public static readonly UserErrorCode UserNotFound =
        new("user.not_found");

    public static readonly UserErrorCode UsernameAlreadyExists =
        new("user.username.already_exists");
}