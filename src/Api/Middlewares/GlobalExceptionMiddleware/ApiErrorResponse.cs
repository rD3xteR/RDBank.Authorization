namespace Api
    .Middlewares.GlobalExceptionMiddleware;

public class ApiErrorResponse
{
    /// <summary>
    /// Машиночитаемый код ошибки латиницей
    /// </summary>
    public required string Error { get; init; }

    /// <summary>
    /// Человекочитаемый текст ошибки латиницей для разработчика
    /// </summary>
    public required string ErrorDescription { get; init; }

    /// <summary>
    /// Человекочитаемый текст ошибки на русском для пользователя
    /// </summary>
    public string? ErrorText { get; set; }
}
