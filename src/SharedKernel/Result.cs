namespace SharedKernel;

public class Result<T>
{
    public T Value { get; private init; } = default!;
    public IEnumerable<ErrorEnum>? Errors { get; protected init; }
    public ResultStatus Status => Errors?.First().Status ?? ResultStatus.Ok;
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

    public static Result<T> Failure(params ErrorEnum[] errors)
    {
        return new Result<T>(false)
        {
            Errors = errors
        };
    }

    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Result result)
    {
        return new Result<T>(default(T))
        {
            Errors = result.Errors,
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