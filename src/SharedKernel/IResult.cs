namespace SharedKernel;

public interface IResult
{
    ErrorEnum? Error { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}