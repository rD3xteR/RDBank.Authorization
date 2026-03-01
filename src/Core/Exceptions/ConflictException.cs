using System.Net;

namespace Core.Exceptions;

public class ConflictException(string message, Exception? innerException = null) : BusinessException(message, innerException)
{
    public override HttpStatusCode StatusCode { get; init; } = HttpStatusCode.Conflict;
}
