namespace Application.Common;

public abstract class Maybe<T>
{
    public static Maybe<T> Some(T value) => new Some<T>(value);
    public static Maybe<T> None() => new None<T>();
}

public sealed class Some<T>(T value) : Maybe<T>
{
    public T Value { get; } = value;
}

public sealed class None<T> : Maybe<T>
{
}