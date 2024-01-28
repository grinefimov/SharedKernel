using System.Net;
using Ardalis.SmartEnum;

namespace SharedKernel;

// TODO: Should it be SmartEnum?
public class ErrorEnum : SmartEnum<ErrorEnum>
{
    public static readonly ErrorEnum NotFound =
        new(nameof(NotFound), 1, "Object was not found.", (int)HttpStatusCode.NotFound);

    public int StatusCode { get; private init; }
    public string Message { get; private init; }
    // TODO: Is StackTrace needed?
    //public StackTrace StackTrace { get; } = new(2);

    private ErrorEnum(string name, int value, string message, int statusCode) : base(name, value)
    {
        Message = message;
        StatusCode = statusCode;
    }
}