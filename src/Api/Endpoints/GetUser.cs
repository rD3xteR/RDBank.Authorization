using System.Security.Claims;

using Api.Configuration.Routing;

using Core.Abstractions;
using Core.Dto;
using Core.Exceptions;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints;

public abstract class GetUser : IEndpointsRegister
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/user/profile", HandleGetUser).RequireAuthorization();

    private static async Task<Ok<UserResponse>> HandleGetUser(ClaimsPrincipal token, IUserService userService)
    {
        var id = token.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = token.FindFirstValue(ClaimTypes.Email);

        if (id is null || email is null)
            throw new UnauthorizedException("Not found user");

        return TypedResults.Ok(await userService.GetUserAsync(id, email));
    }
}
