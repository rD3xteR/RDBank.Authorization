using Api.Configuration.Routing;

using Core.Abstractions;
using Core.Dto.Auth;
using Core.Dto.Register;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public abstract class PostRegister : IEndpointsRegister
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/auth/register", HandlePostAuth);

    private static async Task<Ok<LoginResponse>> HandlePostAuth([FromBody] RegisterRequest request, IAuthService authService)
    {
        return TypedResults.Ok(await authService.RegisterAsync(request));
    }
}
