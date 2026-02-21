using Core.Dal.Models;

namespace Core.Dto.Auth;

public class LoginResponse
{
    public string? Token { get; set; }
    public UserResponse? User { get; set; }
}
