namespace SharedKernel;

public class Result
{
    public IEnumerable<ErrorEnum>? Errors { get; private init; }
    public ResultStatus Status => Errors?.First().Status ?? ResultStatus.Ok;
    public virtual bool IsSuccess => Errors is null;

    protected Result() {}

    public static Result Success()
    {
        return new Result();
    }

    public static Result Failure(params ErrorEnum[] errors)
    {
        return new Result
        {
            Errors = errors
        };
    }
}

public class Result<T> : Result
{
    public T? Value { get; private init; }
    public override bool IsSuccess => Errors is null;


    public static Result<T> Success(T value)
    {
        return new Result<T>
        {
            Value = value
        };
    }
}