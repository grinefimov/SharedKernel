namespace SharedKernel;

public class Result<T> : IResult
{
    public T Value { get; private init; } = default!;
    public ErrorEnum? Error { get; protected init; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess) => IsSuccess = isSuccess;

    protected internal Result(T value) : this(true) => Value = value;

    public static Result<T> Success(T value)
    {
        return new Result<T>(true)
        {
            Value = value
        };
    }

    public static Result<T> Failure(ErrorEnum error)
    {
        return new Result<T>(false)
        {
            Error = error
        };
    }

    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Result result)
    {
        return new Result<T>(default(T))
        {
            Error = result.Error,
        };
    }
}

public class Result : Result<Result>
{
    protected Result(bool isSuccess) : base(isSuccess)
    {
    }

    public static Result Success() => new(true);

    public static Result<T> Success<T>(T value) => new(value);
}