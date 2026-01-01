namespace Domain.Common;

public abstract record DomainErrorCode(string Value);

public sealed record DomainError(DomainErrorCode Code, string Message);

public abstract record ResultBase
{
    public IReadOnlyList<DomainError> Errors { get; init; } = Array.Empty<DomainError>();
    public bool IsSuccess => Errors.Count == 0;
    public bool IsFailure => !IsSuccess;
}

public record Result : ResultBase
{
    public static Result Success() => new();
    public static Result Failure(params DomainError[] errors) => new Result { Errors = errors };
}
public record Result<T> : ResultBase
{
    public T? Value { get; init; }

    public static Result<T> Success(T value)
        => new() { Value = value };

    public static Result<T> Failure(params DomainError[] errors)
        => new() { Errors = errors };

    public static Result<T> Failure(IEnumerable<DomainError> errors)
        => new() { Errors = errors.ToArray() };

    // Convert generic Result<T> to non-generic Result.
    public Result ToResult()
    {
        return new Result
        {
            Errors = this.Errors
        };
    }
}
