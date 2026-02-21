using System.Net;
using System.Text.Json;

namespace Api.Middlewares.GlobalExceptionMiddleware;

public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                var logger = context.RequestServices
                    .GetRequiredService<ILoggerFactory>()
                    .CreateLogger(nameof(GlobalExceptionMiddleware));

                logger.LogError(ex, "Global exception handler caught an error");

                var statusCode = HttpStatusCode.InternalServerError;
                ApiErrorResponse response;

                if (ex is BusinessException businessException)
                {
                    response = new ApiErrorResponse { Error = businessException.ErrorCode, ErrorDescription = businessException.Message, ErrorText = businessException.ErrorText };
                    statusCode = businessException.StatusCode;
                }
                else
                {
                    response = new ApiErrorResponse
                    {
                        Error = JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(HttpStatusCode.InternalServerError)),
                        ErrorDescription = ex.Message
                    };
                }

                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(
                    response,
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower }
                );
            }
        });

        return app;
    }

}
