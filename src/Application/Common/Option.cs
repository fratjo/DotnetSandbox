namespace Application.Common;

public readonly struct Option<T>
{
    private readonly T _value;

    public bool IsSome { get; }
    public bool IsNone => !IsSome;

    private Option(T value)
    {
        _value = value;
        IsSome = true;
    }

    public T Value =>
        IsSome ? _value : throw new InvalidOperationException("No value present.");

    public static Option<T> Some(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        return new Option<T>(value);
    }

    public static Option<T> None() => default;
}

public static class OptionExtensions
{
    public static TResult Match<T, TResult>(
        this Option<T> option,
        Func<T, TResult> some,
        Func<TResult> none)
    {
        return option.IsSome ? some(option.Value) : none();
    }
}