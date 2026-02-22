namespace Core.Dal.Models;

public class UserProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
