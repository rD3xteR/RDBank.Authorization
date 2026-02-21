namespace Core.Dal.Models;

public class UserProfile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<Product>? Products { get; set; }
}
