using AutoMapper;

using Core.Abstractions;
using Core.Dal;
using Core.Dal.Models;
using Core.Dto;
using Core.Dto.Auth;

using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class AuthService(AuthDbContext dbContext, IJwtService jwtService, IMapper mapper) : IAuthService
{
    private static readonly UserResponse s_mockUserProfile = new()
    {
        Id = Guid.NewGuid(),
        Name = "Иван Петров",
        Email = "mockuser@rdbank.com",
        Products = new List<Product>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Дебетовая карта",
                Type = "card",
                Balance = Convert.ToDecimal("45230.5"),
                Number = "**** **** **** 4521",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Сберегательный счет",
                Type = "account",
                Balance = Convert.ToDecimal("80200.0"),
                Number = "40817810123456789012",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Депозит \"Прибыль\"",
                Type = "deposit",
                Balance = Convert.ToDecimal("150000.0"),
                Number = "42301810987654321098",
            }
        }
    };

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await AuthUserAsync(loginRequest);

        return new LoginResponse
        {
            Token = jwtService.GetToken(user.Id, loginRequest.Email),
            User = mapper.Map<UserResponse>(user),
        };
    }

    public Task<LoginResponse> Register(LoginRequest loginRequest) => throw new NotImplementedException();

    private async Task<User> AuthUserAsync(LoginRequest loginRequest)
    {
        var user = await dbContext.Users
            .Include(u => u.Profile)
            .Where(u => u.Email == loginRequest.Email)
            .FirstOrDefaultAsync();

        if (user is null || user.Password != loginRequest.Password)
            // TODO: Add normal exception
            throw new NotImplementedException();

        return user;
    }
}
