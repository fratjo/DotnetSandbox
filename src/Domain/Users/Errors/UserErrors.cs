using Domain.Common;

namespace Domain.Users.Errors;

public static class UserErrors
{
    public static DomainError UsernameCannotBeEmpty =>
        new (UserErrorCode.UsernameEmpty, "Username cannot be null or empty.");

    public static DomainError UsernameChangeTooFrequent =>
        new (UserErrorCode.UsernameTooSoon, "Username can only be changed once every 30 days.");

   public static DomainError AgeMustBeBetween18And100 =>
        new(UserErrorCode.AgeInvalid, "Age must be between 18 and 100.");

    public static DomainError UserNotFound =>
        new(UserErrorCode.UserNotFound, "User not found.");

    public static DomainError UsernameAlreadyExists =>
        new(UserErrorCode.UsernameAlreadyExists, "Username already exists.");
}
