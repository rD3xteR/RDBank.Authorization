namespace Core.Dto.Auth;

public class LoginResponse : ResponseBase<LoginResponse>
{
    public string? Token { get; set; }
}
