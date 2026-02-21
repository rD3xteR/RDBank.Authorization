using Core.Dto.Auth;

namespace Core.Abstractions;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> Register(LoginRequest loginRequest);
}
