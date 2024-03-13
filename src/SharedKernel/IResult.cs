namespace SharedKernel;

// TODO: Consider removing IResult (replace with Result)
public interface IResult
{
    ErrorEnum? Error { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}