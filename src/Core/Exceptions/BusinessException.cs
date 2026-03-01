using System.Net;
using System.Text.Json;

namespace Core.Exceptions;

public class BusinessException(string message, Exception? innerException = null) : Exception(message, innerException)
{
    public string ErrorCode => JsonNamingPolicy.SnakeCaseLower.ConvertName(StatusCode.ToString());

    public virtual HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;

    public string? ErrorText { get; init; }
}
