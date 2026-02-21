namespace Core.Abstractions;

public interface IJwtService
{
    string GetToken(Guid userId, string email);
}
