using System.Net;
using System.Text.Json;
using Ardalis.SmartEnum;
using FluentValidation.Results;

namespace SharedKernel.UseCases;

// TODO: Should it be SmartEnum?
// TODO: Rework for ProblemDetails
// TODO: How to compare the enum values?
//      (result.Error.Name == nameof(ErrorEnum.ValidationError))
//      (result.Error.Equals(ErrorEnum.ValidationError))
//      (result.Error.When(ErrorEnum.ValidationError).Then(() => ...).When ... ).Default(...);
public class ErrorEnum : SmartEnum<ErrorEnum>
{
    public virtual string Message { get; private init; }
    public int StatusCode => Value;
    // TODO: Is StackTrace needed?
    //public StackTrace StackTrace { get; } = new(2);

    private ErrorEnum(string name, int value, string message) : base(name, value)
    {
        Message = message;
    }

    // TODO: Remove? Merge with ValidationErrors?
    // public static ErrorEnum BadRequest(string message) => new(nameof(BadRequest), 400, message,
    //     (int)HttpStatusCode.BadRequest);

    public static ErrorEnum ValidationError(List<ValidationFailure> failures) =>
        new ValidationErrors(nameof(ValidationErrors), (int)HttpStatusCode.BadRequest,
            "Validation failures have occurred.", failures);

    public static readonly ErrorEnum Unauthorized =
        new(nameof(Unauthorized), (int)HttpStatusCode.Unauthorized, "Unauthorized.");

    public static ErrorEnum NotFound(string objectName) =>
        new(nameof(NotFound), (int)HttpStatusCode.NotFound, $"{objectName} was not found.");

    private sealed class ValidationErrors : ErrorEnum
    {
        private List<ValidationFailure> Failures { get; }
        private readonly string _message;
        public override string Message
        {
            // TODO: Move this logic to App
            get
            {
                var failures = Failures
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage.Replace("\'", ""))
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
                return JsonSerializer.Serialize(new
                {
                    Message = _message,
                    Failures = failures
                });
            }
        }

        internal ValidationErrors(string name, int value, string message, List<ValidationFailure> failures) : base(name,
            value, message)
        {
            _message = message;
            Failures = failures;
        }
    }
}