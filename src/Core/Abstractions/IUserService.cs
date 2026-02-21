using Core.Dto;

namespace Core.Abstractions;

public interface IUserService
{
    Task<UserResponse> GetUserAsync(string? userId);
    // Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest);
}
