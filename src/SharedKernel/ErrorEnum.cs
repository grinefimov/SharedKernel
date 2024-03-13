using System.Net;
using Ardalis.SmartEnum;

namespace SharedKernel;

// TODO: Should it be SmartEnum?
public class ErrorEnum : SmartEnum<ErrorEnum>
{
    public static ErrorEnum NotFound(string objectName) => new(nameof(NotFound), 1, $"{objectName} was not found.",
        (int)HttpStatusCode.NotFound);

    public static ErrorEnum BadRequest(string message) => new(nameof(BadRequest), 2, message,
        (int)HttpStatusCode.BadRequest);

    public static readonly ErrorEnum Unauthorized =
        new(nameof(Unauthorized), 3, "User is not authorized.", (int)HttpStatusCode.Unauthorized);

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