using Core.Dal.Models;

namespace Core.Dto;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }
    public ICollection<Product>? Products { get; set; }
}
