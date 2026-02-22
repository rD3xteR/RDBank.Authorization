using AutoMapper;

using Core.Abstractions;
using Core.Dal;
using Core.Dal.Models;
using Core.Dto;
using Core.Dto.Auth;
using Core.Dto.Register;
using Core.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class AuthService(AuthDbContext dbContext, IJwtService jwtService, IMapper mapper) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var userId = await AuthUserAsync(loginRequest);
        return new LoginResponse { Success = true, Token = jwtService.GetToken(userId, loginRequest.Email) };
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        var newUser = mapper.Map<User>(registerRequest);
        newUser.Profile.UserId = newUser.Id;
        newUser.Password = GetHashedPassword(registerRequest.Password);

        var users = dbContext.Users;
        users.Add(newUser);
        await dbContext.SaveChangesAsync();

        return new LoginResponse { Success = true, Token = jwtService.GetToken(newUser.Id, newUser.Email) };
    }

    private async Task<Guid> AuthUserAsync(LoginRequest loginRequest)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Include(u => u.Profile)
            .Where(u => u.Email == loginRequest.Email)
            .FirstOrDefaultAsync();

        var hashedPassword = GetHashedPassword(loginRequest.Password);
        if (user is null || user.Password != hashedPassword)
            throw new UnauthorizedException("User or password doesn't match");

        return user.Id;
    }

    private string GetHashedPassword(string password) =>
        Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password)));
}
