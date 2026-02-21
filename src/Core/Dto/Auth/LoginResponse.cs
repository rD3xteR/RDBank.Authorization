namespace Core.Dto.Auth;

public class LoginResponse
{
    public bool Success { get; set; }
    public string? Token { get; set; }
}
