using Core.Dto.Auth;
using Core.Dto.Register;

namespace Core.Abstractions;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest);
}
