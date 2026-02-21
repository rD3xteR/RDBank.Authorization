using System.Net;

namespace Core.Exceptions;

public class BusinessException(string message, string errorCode, Exception? innerException = null) : Exception(message, innerException)
{
    public string ErrorCode { get; init; } = errorCode;

    public virtual HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;

    public string? ErrorText { get; init; }
}
