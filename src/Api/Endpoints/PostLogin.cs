using Api.Configuration.Routing;

using Core.Abstractions;
using Core.Dto.Auth;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using LoginRequest = Core.Dto.Auth.LoginRequest;

namespace Api.Endpoints;

public abstract class PostLogin : IEndpointsRegister
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/auth/login", HandlePostAuth);

    private static async Task<Ok<LoginResponse>> HandlePostAuth([FromBody] LoginRequest request, IAuthService authService)
        => TypedResults.Ok(await authService.LoginAsync(request));
}
