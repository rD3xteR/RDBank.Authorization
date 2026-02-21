using System.Net;

namespace Api.Middlewares.GlobalExceptionMiddleware;

public class BusinessException(string message, Exception? innerException = null) : Exception(message, innerException)
{
    public required string ErrorCode { get; init; }

    public virtual HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;

    public string? ErrorText { get; init; }
}
