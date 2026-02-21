using System.Security.Claims;

using Api.Configuration.Routing;

using Core.Abstractions;
using Core.Dto;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints;

public abstract class GetUser : IEndpointsRegister
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/user/profile", HandleGetUser).RequireAuthorization();

    private class Dto
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
    }

    private static async Task<Ok<UserResponse>> HandleGetUser(ClaimsPrincipal token, IUserService userService)
    {
        var id = token.FindFirstValue(ClaimTypes.NameIdentifier);
        return TypedResults.Ok(await userService.GetUserAsync(id));
    }
}
