using Core.Dto;

namespace Core.Abstractions;

public interface IUserService
{
    Task<UserResponse> GetUserAsync(string userId, string email);
}
