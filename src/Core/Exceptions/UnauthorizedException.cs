using System.Net;
using System.Text.Json;

namespace Core.Exceptions;

public class UnauthorizedException(string message, Exception? innerException = null)
    : BusinessException(message, JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(StatusCode)), innerException)
{
    public override HttpStatusCode StatusCode { get; init; } = HttpStatusCode.Unauthorized;
}
