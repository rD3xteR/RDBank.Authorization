using Core.Dal.Models;

namespace Core.Dto;

public class UserResponse : ResponseBase<UserResponse>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }
}
