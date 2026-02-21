using AutoMapper;

using Core.Abstractions;
using Core.Dal;
using Core.Dto;
using Core.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class UserService(AuthDbContext dbContext, IMapper mapper) : IUserService
{
    public async Task<UserResponse> GetUserAsync(string? userId)
    {
        var idParsed = Guid.TryParse(userId, out var id);
        if (!idParsed)
            throw new UnauthorizedException("An error occured while trying to get the user id");

        var user = await dbContext.Users
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.Id == id);

        return mapper.Map<UserResponse>(user);
    }
}
