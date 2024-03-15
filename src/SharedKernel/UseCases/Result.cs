namespace SharedKernel.UseCases;

// TODO: Add error methods: NotFound()
public record Result<T> : IResult
{
    public T Value { get; protected init; } = default!;
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

    public static explicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Result result)
    {
        return new Result<T>(default(T))
        {
            Error = result.Error,
        };
    }
    public static implicit operator Result(Result<T> result)
    {
        return new Result(result.IsSuccess)
        {
            Error = result.Error,
        };
    }

    // TODO Consider refactoring
    public static Result<T> FromFailure<T2>(Result<T2> result)
    {
        if (result.IsSuccess) throw new ArgumentException("Result must be Failure.", nameof(result));
        return new Result<T>(false)
        {
            Error = result.Error
        };
    }

    public static Result<T> NotFound(string objectName) => Failure(ErrorEnum.NotFound(objectName));
}

public record Result : Result<Result>
{
    protected internal Result(bool isSuccess) : base(isSuccess)
    {
    }

    public static Result Success() => new(true);

    public static Result<T> Success<T>(T value) => new(value);
}