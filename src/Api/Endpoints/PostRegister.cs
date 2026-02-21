using Api.Configuration.Routing;

using Core.Dto.Auth;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using LoginRequest = Core.Dto.Auth.LoginRequest;

namespace Api.Endpoints;

public abstract class PostRegister : IEndpointsRegister
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/auth/register", HandlePostAuth);

    private static async Task<Ok<LoginResponse>> HandlePostAuth([FromBody] LoginRequest request, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}
