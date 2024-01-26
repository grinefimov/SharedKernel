using Ardalis.SmartEnum;

namespace SharedKernel;

public class ErrorEnum : SmartEnum<ErrorEnum>
{
    public static readonly ErrorEnum NotFound =
        new(nameof(NotFound), 1, "Object was not found.", ResultStatus.NotFound);

    public ResultStatus Status { get; private init; }
    public string Message { get; private init; }

    private ErrorEnum(string name, int value, string message, ResultStatus status) : base(name, value)
    {
        Message = message;
        Status = status;
    }
}